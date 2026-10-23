"""Kiểm thử bản mod (không cần mở game).

    python mod_src/verify_mod.py [--original GameAssembly.dll.bak] [--legacy duong_dan_dll_mod_v1]

1. Dựng DLL cho mọi tổ hợp tính năng, nhận diện lại đúng tính năng và khôi phục
   được bản gốc (SHA-256); gỡ được patch "0.3s" đã bỏ khỏi DLL cũ.
2. Khôi phục bản gốc từ bản mod cũ v1.
3. Cấu trúc PE: section mới, SizeOfImage, .pdata sắp xếp đúng.
4. Disassemble: mọi lệnh nhảy/gọi trong cave trỏ tới địa chỉ đã biết, đích nhảy
   về ranh giới lệnh của hàm game, sau lệnh call không có mẫu epilogue.
5. (Windows) Nạp DLL thật bằng LoadLibraryEx: quyền trang nhớ RX/RW, tra
   RtlLookupFunctionEntry, và RtlVirtualUnwind từ trong cave phải cho cùng kết
   quả như unwind tại vị trí hook gốc.
6. Chạy CLI patch_skill_delay.py trên bản sao: nâng cấp từ v1, thêm/bớt, restore.
"""
import argparse
import ctypes
import hashlib
import importlib.util
import itertools
import os
import shutil
import struct
import subprocess
import sys
import tempfile

import capstone

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.dirname(HERE)
sys.stdout.reconfigure(encoding="utf-8", errors="replace")

spec = importlib.util.spec_from_file_location("patcher", os.path.join(ROOT, "patch_skill_delay.py"))
P = importlib.util.module_from_spec(spec)
spec.loader.exec_module(P)
spec = importlib.util.spec_from_file_location("builder", os.path.join(HERE, "build_payload.py"))
B = importlib.util.module_from_spec(spec)
spec.loader.exec_module(B)

FAILS = []


def check(cond, msg):
    if not cond:
        FAILS.append(msg)
        print("  FAIL:", msg)
    return cond


def sha(b):
    return hashlib.sha256(b).hexdigest()


MD = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
MD.detail = True


def disasm(data, rva, n):
    off = P.rva_to_off(data, rva)
    return list(MD.disasm(bytes(data[off:off + n]), rva))


def insn_starts(data, start, end):
    """Tập địa chỉ bắt đầu lệnh của một hàm game (disassemble tuyến tính)."""
    return {i.address for i in disasm(data, start, end - start)}


# ----------------------------------------------------------------------------- 1, 2
def with_retired_skill(data):
    """Mô phỏng DLL v2 cũ còn patch 'tốc độ ra chiêu 0.3s' (đã gỡ)."""
    buf = bytearray(data)
    for rva, _o, n in P.RETIRED_PATCHES["skill"]:
        off = P.rva_to_off(buf, rva)
        buf[off:off + len(n) // 2] = bytes.fromhex(n)
    return bytes(buf)


def skill_is_original(data):
    return all(P.read_at(data, rva, len(o) // 2) == bytes.fromhex(o) for rva, o, _n in P.RETIRED_PATCHES["skill"])


def test_combinations(orig):
    print(f"[1] Dựng {2 ** len(P.FEATURES)} tổ hợp tính năng")
    for r in range(len(P.FEATURES) + 1):
        for combo in itertools.combinations(P.FEATURES, r):
            feats = set(combo)
            out = P.build(orig, feats, 3)
            on, accept, _kind = P.detect(out)
            check(on == feats, f"detect {sorted(feats)} -> {sorted(on)}")
            if feats & set(P.PAYLOAD_FEATURES):
                check(accept == 3, f"cfg_accept {sorted(feats)}")
            rec = P.strip_payload(out) if P.has_payload(out) else P.strip_legacy(out)
            check(sha(rec) == P.ORIGINAL_SHA256, f"khôi phục gốc từ {sorted(feats)}")
            check(skill_is_original(out), f"patch 0.3s đã gỡ vẫn còn trong {sorted(feats)}")
            old = with_retired_skill(out)
            check(P.detect(old)[0] == feats and P.detect_retired(old) == {"skill"}, f"nhận diện 0.3s cũ {sorted(feats)}")
            rec = P.strip_payload(old) if P.has_payload(old) else P.strip_legacy(old)
            check(sha(rec) == P.ORIGINAL_SHA256, f"khôi phục gốc từ {sorted(feats)} + 0.3s cũ")


def legacy_build(orig, feats):
    """Mô phỏng script v1 (theo bảng LEGACY_PATCHES)."""
    buf = bytearray(orig)
    for f in feats:
        for off, _o, p in P.LEGACY_PATCHES[f]:
            if p:
                pb = bytes.fromhex(p)
                buf[off:off + len(pb)] = pb
    if "stage" in feats:
        buf[0x18DE10:0x18DE10 + 4] = b"\x48\x83\xec\x20"
    if "quest" in feats:
        buf[0x60CA90:0x60CA90 + 5] = b"\xe8\x1b\x7c\xba\xff"
    return bytes(buf)


def test_legacy(orig, legacy_path):
    print("[2] Khôi phục từ bản mod cũ v1")
    for feats in (["skill"], ["mob"], ["die", "trial"], ["stage"], ["quest"], list(P.LEGACY_PATCHES)):
        lb = legacy_build(orig, feats)
        check(sha(P.strip_legacy(lb)) == P.ORIGINAL_SHA256, f"strip_legacy {feats}")
        on, _a, kind = P.detect(lb)
        # skill/die của v1 trùng byte với v2 -> nhận là v2 cũng đúng; skill không còn là tính năng
        want_kind = "mod v2" if set(feats) <= {"skill", "die"} else "mod cũ v1"
        check(kind == want_kind and on == set(feats) - {"skill"}, f"detect legacy {feats} -> {kind} {sorted(on)}")
    if legacy_path:
        lb = open(legacy_path, "rb").read()
        on, _a, kind = P.detect(lb)
        print(f"    {os.path.basename(legacy_path)}: {kind}, {sorted(on)}")
        rec = P.strip_legacy(lb)
        check(kind == "mod cũ v1" and rec is not None and sha(rec) == P.ORIGINAL_SHA256,
              f"--legacy phải là DLL v1 và khôi phục được ({kind})")


# ----------------------------------------------------------------------------- 3
def test_pe(out):
    print("[3] Cấu trúc PE")
    pe = B.PE(out)
    names = [s["name"] for s in pe.sections]
    check(names[-2:] == [".hvnj", ".hvnjd"], f"section {names}")
    for a, b in zip(pe.sections, pe.sections[1:]):
        check(a["va"] + B.align(max(a["vsize"], 1), B.SECTION_ALIGN) <= b["va"], f"VA chồng {a['name']}")
        check(a["raw"] + a["rsize"] <= b["raw"], f"raw chồng {a['name']}")
    last = pe.sections[-1]
    check(pe.size_of_image == B.align(last["va"] + last["vsize"], B.SECTION_ALIGN), "SizeOfImage")
    check(len(out) == last["raw"] + last["rsize"], "kích thước file")
    hv = pe.section(".hvnj")
    hd = pe.section(".hvnjd")
    check(hv["chars"] == 0x60000020 and hd["chars"] == 0xC0000040, "quyền section")
    pd = pe.section(".pdata")
    check(pe.exc_rva == pd["va"] and pe.exc_size <= pd["vsize"], ".pdata VirtualSize phủ exception dir")
    ents = pe.pdata()
    check(all(a[0] < b[0] and a[1] <= b[0] for a, b in zip(ents, ents[1:])), ".pdata sắp xếp, không chồng")
    for e in ents[-len(P.PAYLOAD_PDATA):]:
        check(hv["va"] <= e[0] < e[1] <= hv["va"] + hv["vsize"], f"pdata ngoài .hvnj {e}")
        check(hv["va"] <= e[2] < hv["va"] + hv["vsize"], f"unwind info ngoài .hvnj {e}")


# ----------------------------------------------------------------------------- 4
EPILOGUE_START = ("ret", "jmp", "pop")
# Hàm có prologue riêng (ml64 PROC FRAME): (cấp phát stack, thanh ghi push theo thứ tự địa chỉ tăng dần)
FRAME_FUNCS = {
    "quest_tick": (0x40, ["R15", "R14", "R13", "R12", "Rdi", "Rsi", "Rbx"]),
    "party_leader": (0x28, ["Rsi", "Rbx"]),
    "party_tick": (0x30, ["Rdi", "Rsi", "Rbx"]),
}


def func_bounds(name):
    start = P.PAYLOAD_SYMBOLS[name]
    return start, next(e[1] for e in P.PAYLOAD_PDATA if e[0] == start)


def test_disasm(orig, out):
    print("[4] Disassemble cave và hook")
    S = P.PAYLOAD_SYMBOLS
    code_lo, code_hi = P.PAYLOAD_CODE_RVA, P.PAYLOAD_CODE_RVA + 0x1000
    data_lo, data_hi = P.PAYLOAD_DATA_RVA, P.PAYLOAD_DATA_RVA + 0x1000
    # hàm game đã biết + điểm vào các hàm có prologue riêng của mod (có unwind info riêng)
    allowed_targets = set(B.GAME_SYMBOLS.values()) | {S[n] for n in FRAME_FUNCS}
    allowed_mem = {B.GAME_SYMBOLS[k] for k in ("ca_TypeInfo", "mb_TypeInfo", "mo_TypeInfo", "gb_TypeInfo",
                                                "imp_GetSystemTimeAsFileTime")}

    # đích nhảy về hàm game phải là đầu lệnh
    hosts = {"dgj_accept": (0x1B9C90, 0x1BA0D0), "dgj_skip": (0x1B9C90, 0x1BA0D0),
             "dgj_epilogue_tail": (0x1B9C90, 0x1BA0D0), "clo_store": (0x24AC30, 0x24B5D0)}
    for name, (a, b) in hosts.items():
        check(B.GAME_SYMBOLS[name] in insn_starts(orig, a, b), f"{name} không phải đầu lệnh")
    check(disasm(orig, 0x1BA085, 0x10)[1].mnemonic == "xor", "1BA08A phải là xor eax,eax")

    blocks = [(n, S[n], S[n + "_end"], True) for n in ("dgj_ret", "dgj_filter", "clo_stage")]
    blocks += [(n, *func_bounds(n), False) for n in FRAME_FUNCS]
    check(len(blocks) == len(P.PAYLOAD_PDATA), "mỗi khối code phải có đúng một entry .pdata")
    for start, lo, hi, in_host in blocks:
        insns = disasm(out, lo, hi - lo)
        check(insns and insns[-1].address + insns[-1].size == hi, f"{start}: disassemble không trọn khối")
        for i, ins in enumerate(insns):
            if ins.mnemonic.startswith("j") or ins.mnemonic == "call":
                op = ins.operands[0]
                if op.type == capstone.x86.X86_OP_IMM:
                    t = op.imm
                    check(lo <= t < hi or t in allowed_targets, f"{start}: {ins.mnemonic} tới {t:#x} lạ")
            if ins.mnemonic == "call" and i + 1 < len(insns):
                nxt = insns[i + 1]
                bad = nxt.mnemonic in EPILOGUE_START or (nxt.mnemonic in ("add", "lea") and "rsp" in nxt.op_str.split(",")[0])
                check(not bad, f"{start}: sau call tại {ins.address:#x} là '{nxt.mnemonic}' (giống epilogue)")
            for op in ins.operands:
                if op.type == capstone.x86.X86_OP_MEM and op.mem.base == capstone.x86.X86_REG_RIP:
                    t = ins.address + ins.size + op.mem.disp
                    check(code_lo <= t < code_hi or data_lo <= t < data_hi or t in allowed_mem,
                          f"{start}: truy cập bộ nhớ lạ {t:#x} tại {ins.address:#x}")
            if in_host:
                writes_rsp = bool(ins.operands) and ins.operands[0].type == capstone.x86.X86_OP_REG \
                    and ins.operands[0].reg == capstone.x86.X86_REG_RSP
                check(not writes_rsp and ins.mnemonic not in ("push", "pop", "ret"),
                      f"{start}: '{ins.mnemonic} {ins.op_str}' đổi rsp trong frame host")

    expect = {
        0x1B9DFC: ("jge", S["dgj_ret"]), 0x1B9E4B: ("jmp", 0x1B9EB4), 0x1B9F11: ("jmp", S["dgj_filter"]),
        0x24B5AC: ("jmp", S["clo_stage"]), 0x19495E: ("call", S["quest_tick"]),
    }
    for rva, (mn, tgt) in expect.items():
        ins = disasm(out, rva, 8)[0]
        check(ins.mnemonic == mn and ins.operands[0].imm == tgt, f"hook {rva:#x}: {ins.mnemonic} {ins.op_str}")
    ins = disasm(out, 0x1B9DB1, 6)[0]
    check(ins.mnemonic == "nop" and ins.size == 6, "0x1B9DB1 phải là nop 6 byte")
    # đoạn bị bỏ qua ở 1B9F16..1B9F2F không còn ai nhảy vào
    for ins in disasm(orig, 0x1B9C90, 0x1BA0D0 - 0x1B9C90):
        if ins.mnemonic.startswith("j") and ins.operands[0].type == capstone.x86.X86_OP_IMM:
            t = ins.operands[0].imm
            check(not (0x1B9F16 <= t < 0x1B9F2F) or 0x1B9F11 <= ins.address < 0x1B9F2F,
                  f"lệnh {ins.address:#x} nhảy vào vùng đã thay {t:#x}")
    for ins in disasm(orig, 0x24AC30, 0x24B5D0 - 0x24AC30):
        if ins.mnemonic.startswith("j") and ins.operands[0].type == capstone.x86.X86_OP_IMM:
            t = ins.operands[0].imm
            check(not (0x24B5B1 <= t < 0x24B5B6), f"lệnh {ins.address:#x} nhảy vào giữa hook clo")


# ----------------------------------------------------------------------------- 5
class CONTEXT(ctypes.Structure):
    _fields_ = [("raw", ctypes.c_ubyte * 0x4D0)]
    _pack_ = 16


CTX_OFF = {"Rax": 0x78, "Rcx": 0x80, "Rdx": 0x88, "Rbx": 0x90, "Rsp": 0x98, "Rbp": 0xA0, "Rsi": 0xA8,
           "Rdi": 0xB0, "R12": 0xD8, "R13": 0xE0, "R14": 0xE8, "R15": 0xF0, "Rip": 0xF8}
NONVOL = ["Rbx", "Rbp", "Rsi", "Rdi", "R12", "R13", "R14", "R15"]


def test_runtime(out):
    print("[5] Nạp DLL bằng LoadLibraryEx + RtlVirtualUnwind")
    if os.name != "nt":
        print("    bỏ qua (không phải Windows)")
        return
    k32 = ctypes.WinDLL("kernel32", use_last_error=True)
    k32.LoadLibraryExW.restype = ctypes.c_void_p
    k32.LoadLibraryExW.argtypes = [ctypes.c_wchar_p, ctypes.c_void_p, ctypes.c_uint32]
    k32.FreeLibrary.argtypes = [ctypes.c_void_p]
    k32.RtlLookupFunctionEntry.restype = ctypes.c_void_p
    k32.RtlLookupFunctionEntry.argtypes = [ctypes.c_uint64, ctypes.POINTER(ctypes.c_uint64), ctypes.c_void_p]
    k32.RtlVirtualUnwind.restype = ctypes.c_void_p
    k32.RtlVirtualUnwind.argtypes = [ctypes.c_uint32, ctypes.c_uint64, ctypes.c_uint64, ctypes.c_void_p,
                                     ctypes.c_void_p, ctypes.POINTER(ctypes.c_void_p),
                                     ctypes.POINTER(ctypes.c_uint64), ctypes.c_void_p]

    class MBI(ctypes.Structure):
        _fields_ = [("BaseAddress", ctypes.c_void_p), ("AllocationBase", ctypes.c_void_p),
                    ("AllocationProtect", ctypes.c_uint32), ("PartitionId", ctypes.c_uint16),
                    ("RegionSize", ctypes.c_size_t), ("State", ctypes.c_uint32),
                    ("Protect", ctypes.c_uint32), ("Type", ctypes.c_uint32)]
    k32.VirtualQuery.argtypes = [ctypes.c_void_p, ctypes.POINTER(MBI), ctypes.c_size_t]

    td = tempfile.mkdtemp()
    path = os.path.join(td, "HvnjVerify.dll")
    open(path, "wb").write(out)
    base = k32.LoadLibraryExW(path, None, 0x1)  # DONT_RESOLVE_DLL_REFERENCES: không chạy DllMain
    if not check(base, f"LoadLibraryEx lỗi {ctypes.get_last_error()}"):
        return
    try:
        def prot(rva):
            m = MBI()
            k32.VirtualQuery(ctypes.c_void_p(base + rva), ctypes.byref(m), ctypes.sizeof(m))
            return m.Protect
        check(prot(P.PAYLOAD_CODE_RVA) == 0x20, f".hvnj protect {prot(P.PAYLOAD_CODE_RVA):#x} != PAGE_EXECUTE_READ")
        # trang ghi được của image nạp ở dạng copy-on-write (PAGE_WRITECOPY) cho tới lần ghi đầu
        check(prot(P.PAYLOAD_DATA_RVA) in (0x04, 0x08), f".hvnjd protect {prot(P.PAYLOAD_DATA_RVA):#x} không ghi được")
        check(prot(0x18F000) == 0x20, "section il2cpp vẫn phải là RX (cave cũ ghi vào đây -> crash)")
        cfg = ctypes.string_at(base + P.PAYLOAD_DATA_RVA, 16)
        want = {P.PAYLOAD_CFG["cfg_" + f]: 1 for f in P.PAYLOAD_FEATURES}
        check(cfg[:4] == b"HVNJ" and all(cfg[o] == v for o, v in want.items()), f"cfg trong bộ nhớ {cfg.hex()}")

        def lookup(rva):
            ib = ctypes.c_uint64()
            fe = k32.RtlLookupFunctionEntry(base + rva, ctypes.byref(ib), None)
            return fe, ib.value

        for b_, e_, _u in P.PAYLOAD_PDATA:
            fe, ib = lookup(b_)
            ok = fe and ib == base and struct.unpack("<II", ctypes.string_at(fe, 8)) == (b_, e_)
            check(ok, f"RtlLookupFunctionEntry {b_:#x}")

        stack = (ctypes.c_ubyte * 0x4000)()
        sbase = ctypes.addressof(stack) + 0x2000
        sbase -= sbase % 16

        def fill_stack():
            for i in range(0, 0x4000, 8):
                struct.pack_into("<Q", stack, i, 0x5A5A000000000000 | i)

        def unwind(rva, rsp, regs=None):
            fe, _ib = lookup(rva)
            if not fe:
                return None
            ctx = CONTEXT()
            for k, v in (regs or {}).items():
                struct.pack_into("<Q", ctx.raw, CTX_OFF[k], v)
            struct.pack_into("<Q", ctx.raw, CTX_OFF["Rsp"], rsp)
            struct.pack_into("<Q", ctx.raw, CTX_OFF["Rip"], base + rva)
            hd = ctypes.c_void_p()
            ef = ctypes.c_uint64()
            k32.RtlVirtualUnwind(0, base, base + rva, ctypes.c_void_p(fe), ctypes.byref(ctx),
                                 ctypes.byref(hd), ctypes.byref(ef), None)
            return {k: struct.unpack_from("<Q", ctx.raw, CTX_OFF[k])[0] for k in ["Rip", "Rsp"] + NONVOL}

        regs = {k: 0x1111111100000000 + i for i, k in enumerate(NONVOL)}
        S = P.PAYLOAD_SYMBOLS
        # cave chạy trong frame host: unwind phải giống hệt unwind tại chỗ hook gốc
        pairs = [("dgj_ret", S["dgj_ret"], 0x1B9DFC), ("dgj_filter", S["dgj_filter"], 0x1B9F11)]
        insns = disasm(out, S["clo_stage"], S["clo_stage_end"] - S["clo_stage"])
        pairs += [(f"clo_stage sau call @{i.address:#x}", insns[k + 1].address, 0x24B5B1)
                  for k, i in enumerate(insns) if i.mnemonic == "call"]
        for name, cave_rva, host_rva in pairs:
            fill_stack()
            a = unwind(cave_rva, sbase, regs)
            fill_stack()
            b = unwind(host_rva, sbase, regs)
            check(a is not None and a == b, f"unwind {name}: {a} != {b}")
        # hàm có prologue riêng: unwind sau mỗi call phải trả đúng thanh ghi đã lưu và địa chỉ về
        n_func = 0
        ret = 0x7FF612345678
        for name, (alloc, pushed) in FRAME_FUNCS.items():
            lo, hi = func_bounds(name)
            fi = disasm(out, lo, hi - lo)
            fill_stack()
            saved = {k: alloc + 8 * j for j, k in enumerate(pushed)}
            for k, o in saved.items():
                struct.pack_into("<Q", stack, sbase - ctypes.addressof(stack) + o, 0xAB00 + o)
            struct.pack_into("<Q", stack, sbase - ctypes.addressof(stack) + alloc + 8 * len(pushed), ret)
            for k, i in enumerate(fi):
                if i.mnemonic != "call":
                    continue
                pc = fi[k + 1].address
                r = unwind(pc, sbase, regs)
                ok = r and r["Rip"] == ret and r["Rsp"] == sbase + alloc + 8 * len(pushed) + 8 \
                    and all(r[kk] == 0xAB00 + o for kk, o in saved.items())
                check(ok, f"unwind {name} @{pc:#x}: {r}")
                n_func += 1
        print(f"    {len(pairs)} vị trí trong frame host + {n_func} vị trí trong {len(FRAME_FUNCS)} hàm riêng")
    finally:
        k32.FreeLibrary(ctypes.c_void_p(base))
        shutil.rmtree(td, ignore_errors=True)


# ----------------------------------------------------------------------------- 6
def test_cli(orig, legacy_path):
    print("[6] CLI trên bản sao")
    td = tempfile.mkdtemp()
    dll = os.path.join(td, "GameAssembly.dll")
    script = os.path.join(ROOT, "patch_skill_delay.py")

    def run(*a):
        r = subprocess.run([sys.executable, script, "--dll", dll, *a], capture_output=True, text=True, encoding="utf-8")
        return r.returncode, r.stdout + r.stderr

    try:
        src = open(legacy_path, "rb").read() if legacy_path else legacy_build(orig, list(P.LEGACY_PATCHES))
        open(dll, "wb").write(src)
        rc, txt = run("--mob")
        check(rc == 0, f"--mob trên v1: {txt}")
        cur = open(dll, "rb").read()
        on, _a, kind = P.detect(cur)
        check(kind == "mod v2" and on == set(P.LEGACY_PATCHES) - {"skill"}, f"nâng cấp v1 -> {kind} {sorted(on)}")
        check(skill_is_original(cur), "nâng cấp v1 phải gỡ patch 0.3s")
        check(sha(open(dll + ".bak", "rb").read()) == P.ORIGINAL_SHA256, ".bak là bản gốc")
        # DLL v2 cũ (còn 0.3s, không có .bak) -> --status cảnh báo, chạy lại thì gỡ
        os.remove(dll + ".bak")
        open(dll, "wb").write(with_retired_skill(P.build(orig, set(P.FEATURES), 2)))
        rc, txt = run("--status")
        check(rc == 0 and "0.3s" in txt, f"--status cảnh báo 0.3s cũ: {txt}")
        rc, txt = run("--skill")
        check(rc == 0 and "đã bị gỡ" in txt and P.detect_retired(open(dll, "rb").read()) == {"skill"},
              f"--skill chỉ báo đã gỡ, không ghi file: {txt}")
        rc, txt = run("--die")
        cur = open(dll, "rb").read()
        on, acc, _k = P.detect(cur)
        check(rc == 0 and on == set(P.FEATURES) and acc == 2 and skill_is_original(cur), f"gỡ 0.3s khi chạy lại: {txt}")
        rc, txt = run("--remove", "quest", "stage", "--accept-option", "1")
        on, acc, _k = P.detect(open(dll, "rb").read())
        check(rc == 0 and on == set(P.FEATURES) - {"quest", "stage"} and acc == 1, f"--remove: {sorted(on)} {acc}")
        rc, txt = run("--quest")
        on, acc, _k = P.detect(open(dll, "rb").read())
        check(rc == 0 and "quest" in on and acc == 1, f"--quest giữ accept-option: {sorted(on)} {acc}")
        rc, txt = run("--status")
        check(rc == 0 and "BẬT" in txt, "--status")
        rc, txt = run("--restore")
        check(rc == 0 and sha(open(dll, "rb").read()) == P.ORIGINAL_SHA256, f"--restore: {txt}")
        open(dll + ".bak", "wb").write(b"rac")
        rc, txt = run("--all")
        check(rc == 0 and os.path.exists(dll + ".bak.khong-phai-ban-goc"), f".bak hỏng được giữ lại: {txt}")
        check(sha(open(dll + ".bak", "rb").read()) == P.ORIGINAL_SHA256, ".bak mới là bản gốc")
    finally:
        shutil.rmtree(td, ignore_errors=True)


def test_old_payload(old_path):
    """DLL v2 dựng bằng payload cũ hơn (code cave khác) -> nhận diện, khôi phục, nâng cấp giữ tính năng."""
    print("[7] Nâng cấp từ DLL v2 dựng bằng payload cũ")
    old = open(old_path, "rb").read()
    on, acc, kind = P.detect(old)
    print(f"    {os.path.basename(old_path)}: {kind}, {sorted(on)}, accept={acc}")
    check(kind == "mod v2" and on, "phải nhận ra tính năng của payload cũ")
    check(sha(P.strip_payload(old)) == P.ORIGINAL_SHA256, "strip_payload trên payload cũ")
    td = tempfile.mkdtemp()
    try:
        dll = os.path.join(td, "GameAssembly.dll")
        open(dll, "wb").write(old)
        r = subprocess.run([sys.executable, os.path.join(ROOT, "patch_skill_delay.py"), "--dll", dll, "--party"],
                           capture_output=True, text=True, encoding="utf-8")
        new_on, new_acc, _k = P.detect(open(dll, "rb").read())
        check(r.returncode == 0 and new_on == on | {"party"} and new_acc == acc,
              f"--party trên payload cũ: {sorted(new_on)} {r.stdout}")
        check(open(dll, "rb").read() == P.build(P.strip_payload(old), on | {"party"}, acc), "kết quả = dựng mới từ gốc")
    finally:
        shutil.rmtree(td, ignore_errors=True)


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--original", default=os.path.join(ROOT, "GameAssembly.dll.bak"))
    ap.add_argument("--legacy", help="DLL đã cài bản mod v1 (tùy chọn)")
    ap.add_argument("--old-v2", help="DLL v2 dựng bằng payload cũ hơn (tùy chọn)")
    args = ap.parse_args()
    orig = open(args.original, "rb").read()
    if sha(orig) != P.ORIGINAL_SHA256:
        sys.exit(f"{args.original} không phải bản gốc")
    test_combinations(orig)
    test_legacy(orig, args.legacy)
    full = P.build(orig, set(P.FEATURES), 0)
    test_pe(full)
    test_disasm(orig, full)
    test_runtime(full)
    test_cli(orig, args.legacy)
    if args.old_v2:
        test_old_payload(args.old_v2)
    print()
    if FAILS:
        print(f"THẤT BẠI: {len(FAILS)} lỗi")
        return 1
    print("TẤT CẢ ĐỀU ĐẠT")
    return 0


if __name__ == "__main__":
    sys.exit(main())
