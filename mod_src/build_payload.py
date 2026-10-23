"""Build payload cho ban mod HVNJ 186 (chi danh cho nguoi phat trien).

- Assemble mod_src/hvnj_caves.asm bang ml64 (Visual Studio).
- Doc file COFF .obj, resolve relocation theo RVA cua GameAssembly.dll goc.
- Tao unwind info (.pdata) cho moi code cave, tinh byte cua cac hook.
- Ghi ket qua vao khoi "GENERATED PAYLOAD" trong patch_skill_delay.py.

Cach dung:
    python mod_src/build_payload.py [--original duong_dan_dll_goc] [--ml64 duong_dan_ml64]
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
}

# Khoi cave chay ben trong frame cua ham game -> unwind info chained toi
# RUNTIME_FUNCTION cua ham do (tim theo dia chi nhay ra).
CHAINED_BLOCKS = [
    ("dgj_ret", "dgj_ret_end", 0x1B9DFC),
    ("dgj_filter", "dgj_filter_end", 0x1B9F11),
    ("clo_stage", "clo_stage_end", 0x24B5AC),
]

# Nhóm hook -> các tính năng cần nhóm đó (patcher cài nhóm nếu bật ít nhất 1 tính năng).
HOOK_USERS = {
    "core": ["mob", "stage"],
    "mob": ["mob"],
    "clo": ["stage", "party"],
    "tick": ["quest", "party", "die", "stone"],
}

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
            value, secnum, _typ, sclass, naux = struct.unpack_from("<IhHBB", data, o + 8)
            self.symbols.append(dict(name=name, value=value, sec=secnum, sclass=sclass))
            for _ in range(naux):
                self.symbols.append(None)
            i += 1 + naux

    def find(self, prefix):
        return [i for i, s in enumerate(self.sections) if s["name"] == prefix or s["name"].startswith(prefix + "$")]


def run_ml64(ml64, asm, obj):
    r = subprocess.run([ml64, "-nologo", "-c", "-Fo" + obj, asm], capture_output=True, text=True)
    if r.returncode != 0:
        sys.exit("ml64 loi:\n" + r.stdout + r.stderr)


def find_ml64():
    pats = [
        r"C:\Program Files\Microsoft Visual Studio\*\*\VC\Tools\MSVC\*\bin\Hostx64\x64\ml64.exe",
        r"C:\Program Files (x86)\Microsoft Visual Studio\*\*\VC\Tools\MSVC\*\bin\Hostx64\x64\ml64.exe",
    ]
    for p in pats:
        hits = sorted(glob.glob(p))
        if hits:
            return hits[-1]
    sys.exit("Khong tim thay ml64.exe, dung --ml64 de chi duong dan")


def find_original():
    for p in (os.path.join(ROOT, "GameAssembly.dll.bak"), os.path.join(ROOT, "GameAssembly.dll")):
        if os.path.exists(p) and hashlib.sha256(open(p, "rb").read()).hexdigest() == ORIGINAL_SHA256:
            return p
    sys.exit("Khong tim thay GameAssembly.dll goc (sha256 khong khop), dung --original")


# ----------------------------------------------------------------------------- build
def build(original_path, ml64):
    orig = open(original_path, "rb").read()
    assert hashlib.sha256(orig).hexdigest() == ORIGINAL_SHA256, "DLL goc khong dung phien ban"
    pe = PE(orig)

    with tempfile.TemporaryDirectory() as td:
        obj_path = os.path.join(td, "hvnj_caves.obj")
        run_ml64(ml64, ASM, obj_path)
        coff = Coff(open(obj_path, "rb").read())

    text_idx = coff.find(".text")
    data_idx = coff.find(".data")
    xdata_idx = coff.find(".xdata")
    pdata_idx = coff.find(".pdata")
    assert len(text_idx) == 1 and len(data_idx) == 1, [s["name"] for s in coff.sections]

    code_rva = pe.size_of_image
    # --- bo tri section code: .text | .xdata (ml64) | unwind chained
    layout = {}  # coff section index -> rva
    code = bytearray()
    layout[text_idx[0]] = code_rva
    code += coff.sections[text_idx[0]]["raw"]
    for xi in xdata_idx:
        code += bytes(align(len(code), 4) - len(code))
        layout[xi] = code_rva + len(code)
        code += coff.sections[xi]["raw"]
    chained_off = align(len(code), 4)
    code += bytes(chained_off - len(code) + 16 * len(CHAINED_BLOCKS))
    code_vsize = len(code)
    data_rva = code_rva + align(code_vsize, SECTION_ALIGN)
    data = bytearray(coff.sections[data_idx[0]]["raw"])
    layout[data_idx[0]] = data_rva
    data_vsize = max(len(data), 0x100)

    def sym_rva(si):
        s = coff.symbols[si]
        if s["sec"] > 0:
            base = layout.get(s["sec"] - 1)
            assert base is not None, f"symbol {s['name']} o section khong duoc bo tri"
            return base + s["value"]
        if s["name"] in GAME_SYMBOLS:
            return GAME_SYMBOLS[s["name"]]
        raise KeyError(f"symbol chua resolve: {s['name']}")

    publics = {}
    for s in coff.symbols:
        if s and s["sec"] > 0 and s["sclass"] == 2 and (s["sec"] - 1) in layout:
            publics[s["name"]] = layout[s["sec"] - 1] + s["value"]

    def apply_relocs(idx, buf, buf_base_off):
        for (va, si, typ) in coff.sections[idx]["relocs"]:
            p = buf_base_off + va
            target = sym_rva(si)
            here = layout[idx] + va
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

    apply_relocs(text_idx[0], code, 0)
    for xi in xdata_idx:
        apply_relocs(xi, code, layout[xi] - code_rva)
    assert not coff.sections[data_idx[0]]["relocs"]

    # --- .pdata: entry cua ml64 + entry chained
    pdata_entries = []
    for pi in pdata_idx:
        buf = bytearray(coff.sections[pi]["raw"])
        layout[pi] = 0  # chi dung ADDR32NB
        apply_relocs(pi, buf, 0)
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
    pdata_sec = pe.section(".pdata")
    pdata_tail_off = pe.rva_to_off(pe.exc_rva) + pe.exc_size
    new_exc_size = pe.exc_size + 12 * len(pdata_entries)
    assert pe.exc_rva + new_exc_size <= pdata_sec["va"] + pdata_sec["rsize"], "het cho trong .pdata"
    assert not any(orig[pdata_tail_off:pdata_tail_off + 12 * len(pdata_entries)])

    file_end = len(orig)
    last = max(pe.sections, key=lambda s: s["raw"])
    assert file_end == last["raw"] + last["rsize"], "file co overlay, khong ho tro"
    code_raw = file_end
    code_rsize = align(code_vsize, FILE_ALIGN)
    data_raw = code_raw + code_rsize
    data_rsize = align(len(data), FILE_ALIGN)
    new_size_of_image = data_rva + align(data_vsize, SECTION_ALIGN)

    hdr_new = pe.sec_table + 40 * pe.nsec
    assert hdr_new + 80 <= pe.size_of_headers and not any(orig[hdr_new:hdr_new + 80])

    def sec_hdr(name, vsize, va, rsize, raw, chars):
        return name.encode().ljust(8, b"\0") + struct.pack("<IIIIIIHHI", vsize, va, rsize, raw, 0, 0, 0, 0, chars)

    header_patches = []

    def hp(off, new):
        header_patches.append((off, orig[off:off + len(new)], new))

    size_of_code = struct.unpack_from("<I", orig, pe.opt + 4)[0]
    size_of_idata = struct.unpack_from("<I", orig, pe.opt + 8)[0]
    hp(pe.nsec_off, struct.pack("<H", pe.nsec + 2))
    hp(pe.opt + 4, struct.pack("<I", size_of_code + code_rsize))
    hp(pe.opt + 8, struct.pack("<I", size_of_idata + data_rsize))
    hp(pe.opt + 56, struct.pack("<I", new_size_of_image))
    hp(pe.exc_dir_off + 4, struct.pack("<I", new_exc_size))
    hp(pdata_sec["hdr"] + 8, struct.pack("<I", new_exc_size if pdata_sec["va"] == pe.exc_rva else pdata_sec["vsize"]))
    hp(hdr_new, sec_hdr(".hvnj", code_vsize, code_rva, code_rsize, code_raw, 0x60000020))
    hp(hdr_new + 40, sec_hdr(".hvnjd", data_vsize, data_rva, data_rsize, data_raw, 0xC0000040))
    hp(pdata_tail_off, b"".join(struct.pack("<III", *e) for e in pdata_entries))
    assert pdata_sec["va"] == pe.exc_rva

    # --- hook vao code game
    def rel32(src_next, target):
        return struct.pack("<i", target - src_next)

    S = publics
    hooks = {
        "core": [
            # bo kiem tra lm.mit == null (khong con dung toi nhiem vu chinh)
            (0x1B9DB1, "0F84CE020000", "660F1F440000"),
            # ket thuc vong lap -> tra ve con quai tot nhat
            (0x1B9DFC, "0F8D83020000", "0F8D" + rel32(0x1B9DFC + 6, S["dgj_ret"]).hex()),
            # bo qua kiem tra "quai cua nhiem vu chinh" (doc maw[mit+1] co the IndexOutOfRange)
            (0x1B9E4B, "8B70", "EB67"),
            # loc quai tinh anh/thu linh/boss + cho phep danh het trong Thi Luyen
            (0x1B9F11, "488B0D1020CA00F6813301000002740E4439A1E0000000750" + "5E8A125F2FF",
             "E9" + rel32(0x1B9F16, S["dgj_filter"]).hex() + "CC" * 25),
        ],
        "mob": [
            # mo.dgl (auto nhiem vu): bo qua tinh anh/thu linh/boss
            (0x1BA485, "3968440F846F010000488B0D931ACA00F6813301000002740D39A9E00000007505E825" + "20F2FF",
             "3968440F846F01000066" + "83B8B0000000000F856101000080B8B4000000000F85540100009090"),
        ],
        "clo": [
            # lm.clo: chọn mục tiêu auto (đánh theo nhóm, tự qua ải Thí Luyện)
            (0x24B5AC, "E8DFE6F6FFE9B9FCFFFF", "E9" + rel32(0x24B5B1, S["clo_stage"]).hex() + "CC" * 5),
        ],
        "tick": [
            # mo.ctq: gọi mỗi frame (luyện đá, chết - quay về, đánh theo nhóm, auto nhiệm vụ ngày)
            (0x19495E, "E84D0D0200", "E8" + rel32(0x194963, S["quest_tick"]).hex()),
        ],
    }
    assert set(hooks) == set(HOOK_USERS)
    for feat, lst in hooks.items():
        for rva, o, p in lst:
            ob, pb = bytes.fromhex(o), bytes.fromhex(p)
            assert len(ob) == len(pb), (feat, hex(rva))
            off = pe.rva_to_off(rva)
            assert orig[off:off + len(ob)] == ob, f"byte goc khong khop tai {rva:#x}"

    data_base = layout[data_idx[0]]
    cfg = {k: S[k] - data_base for k in ("cfg_block", "cfg_mob", "cfg_stage", "cfg_quest", "cfg_accept", "cfg_party",
                                         "cfg_die", "cfg_stone", "cfg_stone_xu")}
    return dict(
        code=bytes(code) + bytes(code_rsize - len(code)),
        data=bytes(data) + bytes(data_rsize - len(data)),
        code_rva=code_rva, data_rva=data_rva, code_raw=code_raw, data_raw=data_raw,
        header_patches=[(o, a.hex(), b.hex()) for (o, a, b) in header_patches],
        hooks=hooks, cfg=cfg, publics={k: v for k, v in sorted(S.items(), key=lambda kv: kv[1])},
        pdata=pdata_entries, file_size=len(orig),
    )


def emit(p):
    def hexblock(b, indent="    "):
        h = b.hex()
        return "\n".join(f'{indent}"{h[i:i + 96]}"' for i in range(0, len(h), 96))

    lines = [
        "# === BEGIN GENERATED PAYLOAD (mod_src/build_payload.py - khong sua tay) ===",
        f"PAYLOAD_CODE_RVA = {p['code_rva']:#x}",
        f"PAYLOAD_DATA_RVA = {p['data_rva']:#x}",
        f"PAYLOAD_CODE_RAW = {p['code_raw']:#x}",
        f"PAYLOAD_DATA_RAW = {p['data_raw']:#x}",
        "PAYLOAD_CODE = bytes.fromhex(",
        hexblock(p["code"]),
        ")",
        "PAYLOAD_DATA = bytes.fromhex(",
        hexblock(p["data"]),
        ")",
        "PAYLOAD_CFG = {" + ", ".join(f"'{k}': {v:#x}" for k, v in p["cfg"].items()) + "}",
        "PAYLOAD_SYMBOLS = {" + ", ".join(f"'{k}': {v:#x}" for k, v in p["publics"].items()) + "}",
        "PAYLOAD_PDATA = [" + ", ".join(f"({a:#x}, {b:#x}, {c:#x})" for a, b, c in p["pdata"]) + "]",
        "PAYLOAD_HEADER_PATCHES = [",
    ]
    lines += [f"    ({o:#x}, '{a}', '{b}')," for (o, a, b) in p["header_patches"]]
    lines += ["]", "PAYLOAD_HOOKS = {"]
    for feat, lst in p["hooks"].items():
        lines.append(f"    '{feat}': [")
        lines += [f"        ({rva:#x}, '{o.lower()}', '{pt.lower()}')," for rva, o, pt in lst]
        lines.append("    ],")
    lines += ["}", "PAYLOAD_HOOK_USERS = {" + ", ".join(f"'{g}': {tuple(u)!r}" for g, u in HOOK_USERS.items()) + "}"]
    lines += ["# === END GENERATED PAYLOAD ==="]
    return "\n".join(lines)


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--original")
    ap.add_argument("--ml64")
    args = ap.parse_args()
    payload = build(args.original or find_original(), args.ml64 or find_ml64())
    block = emit(payload)
    src = open(PATCHER, encoding="utf-8").read()
    b = src.index("# === BEGIN GENERATED PAYLOAD")
    e = src.index("# === END GENERATED PAYLOAD ===") + len("# === END GENERATED PAYLOAD ===")
    open(PATCHER, "w", encoding="utf-8", newline="\n").write(src[:b] + block + src[e:])
    print(f"OK: code {len(payload['code']):#x} bytes @ RVA {payload['code_rva']:#x}, "
          f"data @ {payload['data_rva']:#x}, {len(payload['pdata'])} pdata entries")
    for k, v in payload["publics"].items():
        print(f"  {k:16} {v:#x}")


if __name__ == "__main__":
    main()
