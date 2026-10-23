"""Build payload cho ban mod HVNJ 186 (chi danh cho nguoi phat trien).

- Assemble mod_src/hvnj_caves.asm bang ml64 va bien dich mod_src/hvnj_menu.c
  bang cl (Visual Studio, khong CRT).
- Doc cac file COFF .obj, ghep section, resolve relocation theo RVA cua
  GameAssembly.dll goc (symbol cua obj nay -> obj kia -> GAME_SYMBOLS).
- Tao unwind info (.pdata) cho moi code cave, tinh byte cua cac hook.
- Ghi ket qua vao khoi "GENERATED PAYLOAD" trong patch_skill_delay.py.

Cach dung:
    python mod_src/build_payload.py [--original duong_dan_dll_goc] [--ml64 duong_dan_ml64] [--cl duong_dan_cl]
"""
import argparse
import glob
import hashlib
import os
import struct
import subprocess
import sys
import tempfile

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.dirname(HERE)
ASM = os.path.join(HERE, "hvnj_caves.asm")
CSRCS = [os.path.join(HERE, n) for n in ("hvnj_menu.c", "hvnj_bag.c")]   # menu Mod, phien don hanh trang
PAYLOAD_VERSION = 3   # cfg_version: 3 = bat/tat tinh nang bang menu Mod trong game
PATCHER = os.path.join(ROOT, "patch_skill_delay.py")

ORIGINAL_SHA256 = "a17ddc0b955ca4c4ada07feac0d18a1d8f7232d64b6f654c405669419f92df25"

# Dia chi (RVA) trong GameAssembly.dll goc - lay tu il2cpp dump va disassembly.
GAME_SYMBOLS = {
    "mo_dgd": 0x1B56B0,
    "mo_dga": 0x1B3DD0,
    "mo_dgf": 0x1B5A10,
    "mo_dgj": 0x1B9C90,
    "mo_dgv": 0x1C53F0,
    "mo_dgw": 0x1C5600,
    "eq_bkx": 0x476EE0,
    "lj_cpt": 0x23C820,
    "mo_dky": 0x1E98E0,
    "mo_djf": 0x1E14F0,
    "lm_cua": 0x24E520,
    "lm_czd": 0x270A10,
    "lj_cmy": 0x237B00,
    "lj_menu": 0x2436E0,
    "ht_cbt": 0x352F20,
    "bc_ctor": 0x439150,
    "bl_bat": 0x2FC880,
    "bl_bbb": 0x2FCBC0,             # bl.bbb(int) - writeInt
    "il2cpp_init_md": 0x157800,
    "il2cpp_class_init": 0x0DC4D0,
    "il2cpp_object_new": 0x157910,
    "il2cpp_array_new": 0x157400,
    "il2cpp_iface_invoke1": 0x002CE0,
    "imp_GetSystemTimeAsFileTime": 0xBC1210,
    "ca_TypeInfo": 0xE59F00,
    "mb_TypeInfo": 0xE5C0E8,
    "mo_TypeInfo": 0xE5C158,
    "gb_TypeInfo": 0xE5A718,
    "mc_TypeInfo": 0xE5C120,
    "hw_TypeInfo": 0xE5AC58,
    "ek_TypeInfo": 0xE5A2F0,
    "jr_array_TypeInfo": 0xE45418,
    "bc_TypeInfo": 0xE59E20,
    "hs_TypeInfo": 0xE5ABE8,
    "dgj_accept": 0x1B9F2F,
    "dgj_skip": 0x1BA07E,
    "dgj_epilogue_tail": 0x1BA08C,
    "clo_store": 0x24B26F,
    "dgl_accept": 0x1BA4AB,
    "dgl_skip": 0x1BA5FD,
    # diem quay lai / dich nhay goc cua cac cave chan theo co
    "dgj_null": 0x1BA085,
    "dgj_core1_back": 0x1B9DB7,
    "dgj_core2_back": 0x1B9E55,
    "dgj_core2_skip": 0x1B9EB4,
    "ctq_cd1_back": 0x1927E9,
    "ctq_cd2_back": 0x192919,
    "cdy_back": 0x3612E7,
    "cdq_back": 0x36094D,
    "dek_keep_auto": 0x19C0A4,
    "dek_back": 0x19C06A,
    "bld_back": 0x477CC5,
    "bld_block": 0x478098,
    "lm_TypeInfo": 0xE5BF28,
    # menu Mod (hvnj_menu.c + action_hook / menuchar_hook)
    "mo_djh": 0x1E16C0,
    "ms_dkz": 0x62A7A0,
    "ms_dla": 0x62A810,
    "il2cpp_string_new_utf16": 0x0DC990,
    "list_iw_ctor": 0x56DD80,
    "list_iw_add": 0xB30F70,
    "iw_ctor_caption": 0x4E5E80,
    "prefs_get_string": 0x675D70,
    "prefs_set_string": 0x675E20,
    "list_iw_TypeInfo": 0xE40378,
    "list_iw_ctor_mi": 0xE3D510,
    "list_iw_add_mi": 0xE3D550,
    "iw_TypeInfo": 0xE5B128,
    # phien don hanh trang (hvnj_bag.c)
    "jr_cih": 0x4EB880,             # bool jr.cih() - co dong kham ngoc / truc luyen (jr.lfu)
    "fp_TypeInfo": 0xE5A638,        # fp (cua hang): static jr[] danh sach hang theo ma
    # dong "Mo ruong do" / "Mo nang cap trang bi" cua menu Mod
    "mo_ddt": 0x1992D0,             # static mo mo.ddt() - GameScr hien tai
    "mo_djd": 0x1E0730,             # mo.djd(int typeUI) - mo bang (4 = ruong do, 10 = nang cap)
    # nut "Ruong" / "Nang cap" tren thanh Top (giong cach mo.dhp tao nut Shop)
    "unity_component_gameobject": 0x65FD70,
    "unity_gameobject_transform": 0x663210,
    "unity_transform_find": 0x5F45E0,
    "unity_object_set_name": 0x670470,
    "ho_bzc": 0x7F0AC0,             # static ImageClickButton ho.bzc(GameObject, x, y, Sprite, i action)
    "ho_cab": 0x7F3930,             # static hm ho.cab(Transform, string, x, y, font, color, colorEff, mode)
    "ho_caf": 0x7F4740,             # static float ho.caf(Sprite) - chieu cao anh
    "hm_bxl": 0x7E5120,             # hm.bxl(x, y) - dat vi tri chu
    "mo_mk_ctor": 0x277DC0,         # mo.mk..ctor(mo, int id): th() -> mo.dhe(id)
    "ka_TypeInfo": 0xE5B748,
    "iv_TypeInfo": 0xE5B0F0,
    "mo_mk_TypeInfo": 0xE3A438,
    "hx_TypeInfo": 0xE5AC90,        # hx static +38h: he so doi toa do game -> UI (hk.bvx)
    "unity_rt_set_anchored": 0x5E4B40,  # RectTransform.set_anchoredPosition(Vector2)
    "dhe_back": 0x1C7875,           # mo.dhe: sau lenh dau "mov [rsp+18h], rbx"
    "__ImageBase": 0x0,
}

# Khoi cave chay ben trong frame cua ham game -> unwind info chained toi
# RUNTIME_FUNCTION cua ham do (tim theo dia chi nhay ra).
CHAINED_BLOCKS = [
    ("dgj_ret", "dgj_ret_end", 0x1B9DFC),
    ("dgj_filter", "dgj_filter_end", 0x1B9F11),
    ("clo_stage", "clo_stage_end", 0x24B5AC),
    ("dgl_filter", "dgl_filter_end", 0x1BA48E),
    ("dgj_core1", "dgj_core1_end", 0x1B9DB1),
    ("dgj_core2", "dgj_core2_end", 0x1B9E4B),
    ("ctq_cd1", "ctq_cd1_end", 0x1927E2),
    ("ctq_cd2", "ctq_cd2_end", 0x192912),
    ("cdy_dlg", "cdy_dlg_end", 0x3612E0),
    ("cdq_dlg", "cdq_dlg_end", 0x360946),
    ("dek_trial", "dek_trial_end", 0x19C061),
    ("bld_trial", "bld_trial_end", 0x477CBF),
]

# mo.dhn: "map nay co nut Shop tren thanh Top khong" (vá thẳng, luôn tra true)
SHOP_DHN = 0x1CC170
SHOP_DHN_CALLERS = (0x1CE0C3, 0x1D1255)   # mo.dhp: tao nut / an-hien nut

# Bien cau hinh (offset trong .hvnjd) ghi vao PAYLOAD_CFG cho patcher / kiem thu.
CFG_NAMES = ("cfg_block", "cfg_mob", "cfg_stage", "cfg_quest", "cfg_accept", "cfg_party", "cfg_die", "cfg_stone",
             "cfg_stone_lo", "cfg_stone_hi", "cfg_tathu", "cfg_trial", "cfg_sell")

# Section COFF -> noi dat trong payload
SKIP_SECTIONS = (".drectve", ".debug$S", ".debug$T", ".chks64", ".llvm_addrsig")

SECTION_ALIGN = 0x1000
FILE_ALIGN = 0x200

IMAGE_REL_AMD64_ADDR64 = 0x1
IMAGE_REL_AMD64_ADDR32NB = 0x3
IMAGE_REL_AMD64_REL32 = 0x4


def align(v, a):
    return (v + a - 1) // a * a


# ----------------------------------------------------------------------------- PE
class PE:
    def __init__(self, data):
        self.data = data
        self.pe = struct.unpack_from("<I", data, 0x3C)[0]
        self.nsec_off = self.pe + 6
        self.nsec = struct.unpack_from("<H", data, self.nsec_off)[0]
        opt_size = struct.unpack_from("<H", data, self.pe + 20)[0]
        self.opt = self.pe + 24
        self.sec_table = self.opt + opt_size
        self.sections = []
        for i in range(self.nsec):
            o = self.sec_table + 40 * i
            name = data[o:o + 8].rstrip(b"\0").decode()
            vsize, va, rsize, raw = struct.unpack_from("<IIII", data, o + 8)
            chars = struct.unpack_from("<I", data, o + 36)[0]
            self.sections.append(dict(name=name, vsize=vsize, va=va, rsize=rsize, raw=raw, chars=chars, hdr=o))
        self.size_of_image = struct.unpack_from("<I", data, self.opt + 56)[0]
        self.size_of_headers = struct.unpack_from("<I", data, self.opt + 60)[0]
        self.exc_dir_off = self.opt + 112 + 3 * 8
        self.exc_rva, self.exc_size = struct.unpack_from("<II", data, self.exc_dir_off)

    def section(self, name):
        return next(s for s in self.sections if s["name"] == name)

    def rva_to_off(self, rva):
        for s in self.sections:
            if s["va"] <= rva < s["va"] + max(s["vsize"], s["rsize"]):
                return rva - s["va"] + s["raw"]
        raise ValueError(f"RVA {rva:#x} khong thuoc section nao")

    def pdata(self):
        o = self.rva_to_off(self.exc_rva)
        return [struct.unpack_from("<III", self.data, o + 12 * i) for i in range(self.exc_size // 12)]


# ----------------------------------------------------------------------------- COFF
class Coff:
    def __init__(self, data):
        self.data = data
        (machine, nsec, _ts, symptr, nsym, optsz, _ch) = struct.unpack_from("<HHIIIHH", data, 0)
        assert machine == 0x8664, "obj khong phai x64"
        strtab = symptr + 18 * nsym
        self.sections = []
        for i in range(nsec):
            o = 20 + optsz + 40 * i
            name = data[o:o + 8].rstrip(b"\0").decode()
            (_vs, _va, rsize, rawptr, relptr, _ln, nrel, _nln, chars) = struct.unpack_from("<IIIIIIHHI", data, o + 8)
            raw = data[rawptr:rawptr + rsize] if rawptr else bytes(rsize)
            relocs = [struct.unpack_from("<IIH", data, relptr + 10 * k) for k in range(nrel)]
            self.sections.append(dict(name=name, raw=bytearray(raw), relocs=relocs, chars=chars))
        self.symbols = []
        i = 0
        while i < nsym:
            o = symptr + 18 * i
            if data[o:o + 4] == b"\0\0\0\0":
                so = strtab + struct.unpack_from("<I", data, o + 4)[0]
                name = data[so:data.index(b"\0", so)].decode()
            else:
                name = data[o:o + 8].rstrip(b"\0").decode()
            value, secnum, typ, sclass, naux = struct.unpack_from("<IhHBB", data, o + 8)
            self.symbols.append(dict(name=name, value=value, sec=secnum, sclass=sclass, type=typ))
            for _ in range(naux):
                self.symbols.append(None)
            i += 1 + naux

    def find(self, prefix):
        return [i for i, s in enumerate(self.sections) if s["name"] == prefix or s["name"].startswith(prefix + "$")]


def run(cmd, what):
    env = dict(os.environ, MSYS_NO_PATHCONV="1")
    r = subprocess.run(cmd, capture_output=True, text=True, env=env)
    if r.returncode != 0:
        sys.exit(f"{what} loi:\n" + r.stdout + r.stderr)


def run_ml64(ml64, asm, obj):
    run([ml64, "-nologo", "-c", "-Fo" + obj, asm], "ml64")


def run_cl(cl, src, obj):
    # khong CRT, khong stack cookie / probe, chuoi L"" UTF-16 tu nguon UTF-8
    run([cl, "-nologo", "-c", "-O1", "-GS-", "-Gs1000000", "-Zl", "-GR-", "-EHs-c-", "-utf-8", "-W4", "-WX",
         "-Fo" + obj, src], "cl")


def find_tool(exe):
    pats = [
        rf"C:\Program Files\Microsoft Visual Studio\*\*\VC\Tools\MSVC\*\bin\Hostx64\x64\{exe}",
        rf"C:\Program Files (x86)\Microsoft Visual Studio\*\*\VC\Tools\MSVC\*\bin\Hostx64\x64\{exe}",
    ]
    for p in pats:
        hits = sorted(glob.glob(p))
        if hits:
            return hits[-1]
    sys.exit(f"Khong tim thay {exe}, dung --ml64 / --cl de chi duong dan")


def find_original():
    for p in (os.path.join(ROOT, "GameAssembly.dll.bak"), os.path.join(ROOT, "GameAssembly.dll")):
        if os.path.exists(p) and hashlib.sha256(open(p, "rb").read()).hexdigest() == ORIGINAL_SHA256:
            return p
    sys.exit("Khong tim thay GameAssembly.dll goc (sha256 khong khop), dung --original")


def section_kind(name):
    if name in SKIP_SECTIONS:
        return None
    for kind in ("text", "rdata", "xdata", "pdata", "data", "bss"):
        if name == "." + kind or name.startswith("." + kind + "$"):
            return kind
    raise AssertionError(f"section {name} chua ho tro")


def section_align(chars):
    n = (chars >> 20) & 0xF
    return 1 << (n - 1) if n else 16


# ----------------------------------------------------------------------------- build
def build(original_path, ml64, cl):
    orig = open(original_path, "rb").read()
    assert hashlib.sha256(orig).hexdigest() == ORIGINAL_SHA256, "DLL goc khong dung phien ban"
    pe = PE(orig)

    with tempfile.TemporaryDirectory() as td:
        asm_obj = os.path.join(td, "hvnj_caves.obj")
        run_ml64(ml64, ASM, asm_obj)
        objs = [Coff(open(asm_obj, "rb").read())]
        for src in CSRCS:
            c_obj = os.path.join(td, os.path.splitext(os.path.basename(src))[0] + ".obj")
            run_cl(cl, src, c_obj)
            objs.append(Coff(open(c_obj, "rb").read()))

    # --- phan loai section; .data cua asm phai dung dau .hvnjd (cfg_block o offset 0)
    secs = {k: [] for k in ("text", "rdata", "xdata", "pdata", "data", "bss")}
    for oi, coff in enumerate(objs):
        for si, sec in enumerate(coff.sections):
            kind = section_kind(sec["name"])
            if kind:
                secs[kind].append((oi, si))
    assert secs["data"][0] == (0, objs[0].find(".data")[0]) and len(objs[0].find(".data")) == 1

    code_rva = pe.size_of_image
    layout = {}  # (obj, section) -> rva
    code = bytearray()
    for kind in ("text", "rdata", "xdata"):
        for oi, si in secs[kind]:
            sec = objs[oi].sections[si]
            code += bytes(align(len(code), section_align(sec["chars"])) - len(code))
            layout[(oi, si)] = code_rva + len(code)
            code += sec["raw"]
    chained_off = align(len(code), 4)
    code += bytes(chained_off - len(code) + 16 * len(CHAINED_BLOCKS))
    code_vsize = len(code)
    data_rva = code_rva + align(code_vsize, SECTION_ALIGN)
    data = bytearray()
    for kind in ("data", "bss"):
        for oi, si in secs[kind]:
            sec = objs[oi].sections[si]
            data += bytes(align(len(data), section_align(sec["chars"])) - len(data))
            layout[(oi, si)] = data_rva + len(data)
            data += sec["raw"]
    data_vsize = max(len(data), 0x100)

    # moi ham C (ke ca ham static / ham la khong co .pdata) - de kiem thu disassemble het code C
    c_objs = range(1, len(objs))
    c_funcs = sorted((layout[(oi, s_["sec"] - 1)] + s_["value"], s_["name"]) for oi in c_objs for s_ in objs[oi].symbols
                     if s_ and s_["sec"] > 0 and (s_["type"] & 0x30) == 0x20 and (oi, s_["sec"] - 1) in layout)
    c_text_end = {layout[(oi, si)]: layout[(oi, si)] + len(objs[oi].sections[si]["raw"]) for oi, si in secs["text"]
                  if oi in c_objs}
    c_funcs = [(a, next(e for b_, e in c_text_end.items() if b_ <= a < e), n) for a, n in c_funcs]

    publics = {}
    for oi, coff in enumerate(objs):
        for s_ in coff.symbols:
            if s_ and s_["sec"] > 0 and s_["sclass"] == 2 and (oi, s_["sec"] - 1) in layout:
                assert s_["name"] not in publics, f"symbol trung: {s_['name']}"
                publics[s_["name"]] = layout[(oi, s_["sec"] - 1)] + s_["value"]

    def sym_rva(oi, si):
        s_ = objs[oi].symbols[si]
        if s_["sec"] > 0:
            base = layout.get((oi, s_["sec"] - 1))
            assert base is not None, f"symbol {s_['name']} o section khong duoc bo tri"
            return base + s_["value"]
        if s_["name"] in publics:
            return publics[s_["name"]]
        if s_["name"] in GAME_SYMBOLS:
            return GAME_SYMBOLS[s_["name"]]
        raise KeyError(f"symbol chua resolve: {s_['name']}")

    def apply_relocs(oi, si, buf, buf_base_off, here_base):
        for (va, symi, typ) in objs[oi].sections[si]["relocs"]:
            p = buf_base_off + va
            target = sym_rva(oi, symi)
            here = here_base + va
            if typ == IMAGE_REL_AMD64_ADDR32NB:
                add = struct.unpack_from("<I", buf, p)[0]
                struct.pack_into("<I", buf, p, target + add)
            elif IMAGE_REL_AMD64_REL32 <= typ <= IMAGE_REL_AMD64_REL32 + 5:
                extra = typ - IMAGE_REL_AMD64_REL32
                add = struct.unpack_from("<i", buf, p)[0]
                disp = target + add - (here + 4 + extra)
                assert -2**31 <= disp < 2**31
                struct.pack_into("<i", buf, p, disp)
            elif typ == IMAGE_REL_AMD64_ADDR64:
                raise AssertionError("dia chi tuyet doi 64-bit khong duoc phep (ASLR)")
            else:
                raise AssertionError(f"reloc type {typ:#x} chua ho tro")

    for kind in ("text", "rdata", "xdata"):
        for oi, si in secs[kind]:
            apply_relocs(oi, si, code, layout[(oi, si)] - code_rva, layout[(oi, si)])
    for kind in ("data", "bss"):
        for oi, si in secs[kind]:
            assert not objs[oi].sections[si]["relocs"], "du lieu khong duoc chua con tro"

    # --- .pdata: entry cua ml64 / cl + entry chained
    pdata_entries = []
    for oi, si in secs["pdata"]:
        buf = bytearray(objs[oi].sections[si]["raw"])
        apply_relocs(oi, si, buf, 0, 0)  # chi dung ADDR32NB
        pdata_entries += [struct.unpack_from("<III", buf, 12 * k) for k in range(len(buf) // 12)]

    game_pdata = pe.pdata()
    for n, (start, end, site) in enumerate(CHAINED_BLOCKS):
        parent = next(e for e in game_pdata if e[0] <= site < e[1])
        uoff = chained_off + 16 * n
        # UNWIND_INFO: version 1, UNW_FLAG_CHAININFO, prolog 0, 0 code, khong frame reg
        struct.pack_into("<BBBB", code, uoff, 1 | (0x4 << 3), 0, 0, 0)
        struct.pack_into("<III", code, uoff + 4, *parent)
        pdata_entries.append((publics[start], publics[end], code_rva + uoff))
    pdata_entries.sort()
    for a, b in zip(pdata_entries, pdata_entries[1:]):
        assert a[1] <= b[0], "pdata chong lan"
    assert pdata_entries[0][0] > game_pdata[-1][0]

    # --- vi tri ghi
    # .pdata cua game chi con cho cho 32 entry -> chuyen ca bang (exception directory) sang
    # section moi ".hvnjp" = bang goc + entry cua payload (luon dung sau bang goc vi RVA lon hon).
    # Byte cua .hvnjp khong nam trong patch_skill_delay.py: patcher dung lai tu DLL goc luc cai.
    pdata_sec = pe.section(".pdata")
    assert pdata_sec["va"] == pe.exc_rva
    pdata_tail_off = pe.rva_to_off(pe.exc_rva) + pe.exc_size

    file_end = len(orig)
    last = max(pe.sections, key=lambda s: s["raw"])
    assert file_end == last["raw"] + last["rsize"], "file co overlay, khong ho tro"
    code_raw = file_end
    code_rsize = align(code_vsize, FILE_ALIGN)
    data_raw = code_raw + code_rsize
    data_rsize = align(len(data), FILE_ALIGN)
    pdata_rva = data_rva + align(data_vsize, SECTION_ALIGN)
    pdata_raw = data_raw + data_rsize
    pdata_size = pe.exc_size + 12 * len(pdata_entries)
    pdata_rsize = align(pdata_size, FILE_ALIGN)
    new_size_of_image = pdata_rva + align(pdata_size, SECTION_ALIGN)

    hdr_new = pe.sec_table + 40 * pe.nsec
    assert hdr_new + 120 <= pe.size_of_headers and not any(orig[hdr_new:hdr_new + 120])

    def sec_hdr(name, vsize, va, rsize, raw, chars):
        return name.encode().ljust(8, b"\0") + struct.pack("<IIIIIIHHI", vsize, va, rsize, raw, 0, 0, 0, 0, chars)

    header_patches = []

    def hp(off, new):
        header_patches.append((off, orig[off:off + len(new)], new))

    size_of_code = struct.unpack_from("<I", orig, pe.opt + 4)[0]
    size_of_idata = struct.unpack_from("<I", orig, pe.opt + 8)[0]
    hp(pe.nsec_off, struct.pack("<H", pe.nsec + 3))
    hp(pe.opt + 4, struct.pack("<I", size_of_code + code_rsize))
    hp(pe.opt + 8, struct.pack("<I", size_of_idata + data_rsize + pdata_rsize))
    hp(pe.opt + 56, struct.pack("<I", new_size_of_image))
    hp(pe.exc_dir_off, struct.pack("<II", pdata_rva, pdata_size))
    hp(hdr_new, sec_hdr(".hvnj", code_vsize, code_rva, code_rsize, code_raw, 0x60000020))
    hp(hdr_new + 40, sec_hdr(".hvnjd", data_vsize, data_rva, data_rsize, data_raw, 0xC0000040))
    hp(hdr_new + 80, sec_hdr(".hvnjp", pdata_size, pdata_rva, pdata_rsize, pdata_raw, 0x40000040))
    # ban v2 / v3 truoc ghi entry cua payload vao cuoi .pdata va sua VirtualSize cua .pdata:
    # khi go mod phai tra lai byte goc o hai cho nay (ban hien tai khong dung toi chung)
    strip_restore = [(pdata_sec["hdr"] + 8, orig[pdata_sec["hdr"] + 8:pdata_sec["hdr"] + 12]),
                     (pdata_tail_off, orig[pdata_tail_off:pdata_sec["raw"] + pdata_sec["rsize"]])]
    assert not any(strip_restore[1][1])

    # --- hook vao code game (cai het; cfg_* trong game quyet dinh co chay hay khong)
    def rel32(src_next, target):
        return struct.pack("<i", target - src_next)

    S = publics

    def jmp(site, n, target):
        return "E9" + rel32(site + 5, target).hex() + "CC" * (n - 5)

    hooks = [
        # mo.dgj: chon quai cho auto (ne quai / tu qua ai)
        (0x1B9DB1, "0F84CE020000", jmp(0x1B9DB1, 6, S["dgj_core1"])),
        (0x1B9DFC, "0F8D83020000", "0F8D" + rel32(0x1B9DFC + 6, S["dgj_ret"]).hex()),
        (0x1B9E4B, "8B7078488B05D320CA00", jmp(0x1B9E4B, 10, S["dgj_core2"])),
        (0x1B9F11, "488B0D1020CA00F6813301000002740E4439A1E0000000750" + "5E8A125F2FF",
         jmp(0x1B9F11, 30, S["dgj_filter"])),
        # mo.dgl (auto nhiem vu): ne tinh anh/thu linh/boss, tru con ta thu cua nhiem vu ta thu
        (0x1BA485, "3968440F846F010000488B0D931ACA00F6813301000002740D39A9E00000007505E825" + "20F2FF",
         "3968440F846F010000" + jmp(0x1BA48E, 29, S["dgl_filter"])),
        # lm.clo: chon muc tieu auto (danh theo nhom, tu qua ai Thi Luyen)
        (0x24B5AC, "E8DFE6F6FFE9B9FCFFFF", jmp(0x24B5AC, 10, S["clo_stage"])),
        # mo.ctq: goi moi frame (luyen da, chet - quay ve, danh theo nhom, auto nhiem vu)
        (0x19495E, "E84D0D0200", "E8" + rel32(0x194963, S["quest_tick"]).hex()),
        # chet: dem nguoc 15 -> 1, hop thoai 500 -> 2 (mo.ctq, hw.cdy, hw.cdq)
        (0x1927E2, "C680520100000F", jmp(0x1927E2, 7, S["ctq_cd1"])),
        (0x192912, "C680520100000F", jmp(0x192912, 7, S["ctq_cd2"])),
        (0x3612E0, "C7413CF4010000", jmp(0x3612E0, 7, S["cdy_dlg"])),
        (0x360946, "C74040F4010000", jmp(0x360946, 7, S["cdq_dlg"])),
        # Thi Luyen map 161: mo.dek khong tat Auto, eq.bld khong chan tim duong
        (0x19C061, "7541488B05EE00CC00", jmp(0x19C061, 9, S["dek_trial"])),
        (0x477CBF, "0F84D3030000", jmp(0x477CBF, 6, S["bld_trial"])),
        # menu Mod: lenh menu -> action_hook; them dong "Mod HVNJ" vao menu nhan vat
        (0x4E6027, "E894B6CFFF", "E8" + rel32(0x4E602C, S["action_hook"]).hex()),
        (0x1EA0BA, "E8E1064400", "E8" + rel32(0x1EA0BF, S["menuchar_hook"]).hex()),
        # thanh Top: nut Shop (cua hang tong, ban duoc do) hien o moi map, khong can tick.
        # mo.dhn chi tra true o 13 map lang/truong/phan vien; chi mo.dhp (tao + an/hien nut Shop) goi no
        (SHOP_DHN, "4883EC28", "B001C3CC"),     # mov al, 1 ; ret
        # mo.dhe (bam nut thanh Top): id nut cua mod -> mod_top_click
        (0x1C7870, "48895C2418", jmp(0x1C7870, 5, S["dhe_hook"])),
    ]
    for rva, o, p in hooks:
        ob, pb = bytes.fromhex(o), bytes.fromhex(p)
        assert len(ob) == len(pb), hex(rva)
        off = pe.rva_to_off(rva)
        assert orig[off:off + len(ob)] == ob, f"byte goc khong khop tai {rva:#x}"

    data_base = layout[secs["data"][0]]
    assert data[S["cfg_block"] - data_base + 4] == PAYLOAD_VERSION, "cfg_version trong asm != PAYLOAD_VERSION"
    cfg = {k: S[k] - data_base for k in CFG_NAMES}
    return dict(
        code=bytes(code) + bytes(code_rsize - len(code)),
        data=bytes(data) + bytes(data_rsize - len(data)),
        code_rva=code_rva, data_rva=data_rva, code_raw=code_raw, data_raw=data_raw,
        pdata_rva=pdata_rva, pdata_raw=pdata_raw, pdata_rsize=pdata_rsize,
        game_pdata_off=pe.rva_to_off(pe.exc_rva), game_pdata_size=pe.exc_size,
        strip_restore=[(o, b_.hex()) for o, b_ in strip_restore],
        header_patches=[(o, a.hex(), b.hex()) for (o, a, b) in header_patches],
        hooks=hooks, cfg=cfg, publics={k: v for k, v in sorted(S.items(), key=lambda kv: kv[1])},
        pdata=pdata_entries, file_size=len(orig), c_funcs=c_funcs,
    )


def emit(p):
    def hexblock(b, indent="    "):
        h = b.hex()
        return "\n".join(f'{indent}"{h[i:i + 96]}"' for i in range(0, len(h), 96))

    lines = [
        "# === BEGIN GENERATED PAYLOAD (mod_src/build_payload.py - khong sua tay) ===",
        f"PAYLOAD_VERSION = {PAYLOAD_VERSION}",
        f"PAYLOAD_CODE_RVA = {p['code_rva']:#x}",
        f"PAYLOAD_DATA_RVA = {p['data_rva']:#x}",
        f"PAYLOAD_CODE_RAW = {p['code_raw']:#x}",
        f"PAYLOAD_DATA_RAW = {p['data_raw']:#x}",
        f"PAYLOAD_PDATA_RVA = {p['pdata_rva']:#x}",
        f"PAYLOAD_PDATA_RAW = {p['pdata_raw']:#x}",
        f"PAYLOAD_PDATA_RSIZE = {p['pdata_rsize']:#x}",
        f"GAME_PDATA_OFF = {p['game_pdata_off']:#x}",
        f"GAME_PDATA_SIZE = {p['game_pdata_size']:#x}",
        "PAYLOAD_STRIP_RESTORE = [" + ", ".join(f"({o:#x}, '{h}')" for o, h in p["strip_restore"]) + "]",
        "PAYLOAD_CODE = bytes.fromhex(",
        hexblock(p["code"]),
        ")",
        "PAYLOAD_DATA = bytes.fromhex(",
        hexblock(p["data"]),
        ")",
        "PAYLOAD_CFG = {" + ", ".join(f"'{k}': {v:#x}" for k, v in p["cfg"].items()) + "}",
        "PAYLOAD_SYMBOLS = {" + ", ".join(f"'{k}': {v:#x}" for k, v in p["publics"].items()) + "}",
        "PAYLOAD_PDATA = [" + ", ".join(f"({a:#x}, {b:#x}, {c:#x})" for a, b, c in p["pdata"]) + "]",
        "PAYLOAD_C_FUNCS = [" + ", ".join(f"({a:#x}, {b:#x}, '{n}')" for a, b, n in p["c_funcs"]) + "]",
        "PAYLOAD_HEADER_PATCHES = [",
    ]
    lines += [f"    ({o:#x}, '{a}', '{b}')," for (o, a, b) in p["header_patches"]]
    lines += ["]", "PAYLOAD_HOOKS = ["]
    lines += [f"    ({rva:#x}, '{o.lower()}', '{pt.lower()}')," for rva, o, pt in p["hooks"]]
    lines += ["]", "# === END GENERATED PAYLOAD ==="]
    return "\n".join(lines)


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--original")
    ap.add_argument("--ml64")
    ap.add_argument("--cl")
    args = ap.parse_args()
    payload = build(args.original or find_original(), args.ml64 or find_tool("ml64.exe"),
                    args.cl or find_tool("cl.exe"))
    block = emit(payload)
    src = open(PATCHER, encoding="utf-8").read()
    b = src.index("# === BEGIN GENERATED PAYLOAD")
    e = src.index("# === END GENERATED PAYLOAD ===") + len("# === END GENERATED PAYLOAD ===")
    open(PATCHER, "w", encoding="utf-8", newline="\n").write(src[:b] + block + src[e:])
    print(f"OK: code {len(payload['code']):#x} bytes @ RVA {payload['code_rva']:#x}, "
          f"data @ {payload['data_rva']:#x}, {len(payload['pdata'])} pdata entries")
    for k, v in payload["publics"].items():
        if not k.startswith("??_C@"):
            print(f"  {k:20} {v:#x}")


if __name__ == "__main__":
    main()
