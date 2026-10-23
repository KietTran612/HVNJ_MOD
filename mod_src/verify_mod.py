"""Kiểm thử bản mod (không cần mở game).

    python mod_src/verify_mod.py [--original GameAssembly.dll.bak] [--legacy duong_dan_dll_mod_v1]
                                 [--old-v2 duong_dan_dll_v2_cu]

1. Dựng DLL cho mọi tổ hợp tính năng, nhận diện lại đúng tính năng và khôi phục
   được bản gốc (SHA-256); gỡ được patch "0.3s" đã bỏ khỏi DLL cũ.
2. Khôi phục bản gốc từ bản mod cũ v1.
3. Cấu trúc PE: section mới, SizeOfImage, .pdata sắp xếp đúng.
4. Disassemble: mọi lệnh nhảy/gọi trong cave trỏ tới địa chỉ đã biết, đích nhảy
   về ranh giới lệnh của hàm game, sau lệnh call không có mẫu epilogue.
5. (Windows) Nạp DLL thật bằng LoadLibraryEx: quyền trang nhớ RX/RW, tra
   RtlLookupFunctionEntry, và RtlVirtualUnwind từ trong cave phải cho cùng kết
   quả như unwind tại vị trí hook gốc.
6. Chạy THẬT mã máy stone_tick (luyện đá) với hàm game thay bằng callback Python và
   nhân vật / hành trang / bảng điểm đá giả: kiểm tra packet gửi ra ở từng tình huống.
7. Chạy THẬT quest_tick (auto nhiệm vụ ngày + tà thú) với NPC / nhiệm vụ / map giả.
8. Chạy CLI patch_skill_delay.py trên bản sao: nâng cấp từ v1, thêm/bớt, restore.
9. (--old-v2) Nâng cấp DLL v2 dựng bằng payload cũ hơn.
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
            check(P.has_payload(out) == bool(feats & set(P.PAYLOAD_FEATURES)), f"payload {sorted(feats)}")
            if P.has_payload(out):
                cfg = P.rva_to_off(out, P.PAYLOAD_DATA_RVA)
                for f in P.PAYLOAD_FEATURES:
                    check(out[cfg + P.PAYLOAD_CFG["cfg_" + f]] == (f in feats), f"cfg_{f} trong {sorted(feats)}")
                for g, users in P.PAYLOAD_HOOK_USERS.items():
                    want = bool(feats & set(users))
                    got = all(P.read_at(out, rva, len(n) // 2) == bytes.fromhex(n) for rva, _o, n in P.PAYLOAD_HOOKS[g])
                    check(got == want, f"nhóm hook {g} trong {sorted(feats)}")
            old = with_retired_skill(out)
            check(P.detect(old)[0] == feats and P.detect_retired(old) == {"skill"}, f"nhận diện 0.3s cũ {sorted(feats)}")
            rec = P.strip_payload(old) if P.has_payload(old) else P.strip_legacy(old)
            check(sha(rec) == P.ORIGINAL_SHA256, f"khôi phục gốc từ {sorted(feats)} + 0.3s cũ")
            check(not P.detect_stone_xu(out) and P.detect_stone_levels(out) == P.STONE_LEVELS_ALL,
                  f"mặc định luyện đá trả yên, mọi cấp {sorted(feats)}")
            if "stone" in feats:
                xu = P.build(orig, feats, 3, stone_xu=True, stone_levels=(2, 5))
                check(P.detect(xu)[0] == feats and P.detect_stone_xu(xu) and P.detect_stone_levels(xu) == (2, 5),
                      f"luyện đá trả xu, cấp 2-5 {sorted(feats)}")
                check(sha(P.strip_payload(xu)) == P.ORIGINAL_SHA256, f"khôi phục gốc từ {sorted(feats)} + xu")


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
    "die_tick": (0x38, ["R12", "Rdi", "Rsi", "Rbx"]),
    "stone_tick": (0x68, ["R15", "R14", "R13", "R12", "Rdi", "Rsi", "Rbp", "Rbx"]),
}


def func_bounds(name):
    start = P.PAYLOAD_SYMBOLS[name]
    return start, next(e[1] for e in P.PAYLOAD_PDATA if e[0] == start)


def test_disasm(orig, out):
    print("[4] Disassemble cave và hook")
    S = P.PAYLOAD_SYMBOLS
    code_lo, code_hi = P.PAYLOAD_CODE_RVA, P.PAYLOAD_CODE_RVA + len(P.PAYLOAD_CODE)
    data_lo, data_hi = P.PAYLOAD_DATA_RVA, P.PAYLOAD_DATA_RVA + len(P.PAYLOAD_DATA)
    # hàm game đã biết + điểm vào các hàm có prologue riêng của mod (có unwind info riêng)
    allowed_targets = set(B.GAME_SYMBOLS.values()) | {S[n] for n in FRAME_FUNCS}
    allowed_mem = {v for k, v in B.GAME_SYMBOLS.items() if k.endswith("_TypeInfo")} | \
        {B.GAME_SYMBOLS["imp_GetSystemTimeAsFileTime"]}

    # đích nhảy về hàm game phải là đầu lệnh
    hosts = {"dgj_accept": (0x1B9C90, 0x1BA0D0), "dgj_skip": (0x1B9C90, 0x1BA0D0),
             "dgj_epilogue_tail": (0x1B9C90, 0x1BA0D0), "clo_store": (0x24AC30, 0x24B5D0),
             "dgl_accept": (0x1BA2D0, 0x1BADE0), "dgl_skip": (0x1BA2D0, 0x1BADE0)}
    for name, (a, b) in hosts.items():
        check(B.GAME_SYMBOLS[name] in insn_starts(orig, a, b), f"{name} không phải đầu lệnh")
    check(disasm(orig, 0x1BA085, 0x10)[1].mnemonic == "xor", "1BA08A phải là xor eax,eax")

    blocks = [(n, S[n], S[n + "_end"], True) for n in ("dgj_ret", "dgj_filter", "clo_stage", "dgl_filter")]
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
        0x1BA48E: ("jmp", S["dgl_filter"]),
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
    for ins in disasm(orig, 0x1BA2D0, 0x1BADE0 - 0x1BA2D0):
        if ins.mnemonic.startswith("j") and ins.operands[0].type == capstone.x86.X86_OP_IMM:
            t = ins.operands[0].imm
            check(not (0x1BA48E <= t < 0x1BA4AB) or 0x1BA48E <= ins.address < 0x1BA4AB,
                  f"lệnh {ins.address:#x} nhảy vào vùng đã thay của mo.dgl {t:#x}")
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
        pairs = [("dgj_ret", S["dgj_ret"], 0x1B9DFC), ("dgj_filter", S["dgj_filter"], 0x1B9F11),
                 ("dgl_filter", S["dgl_filter"], 0x1BA48E)]
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


# ----------------------------------------------------------------------------- 8
def test_cli(orig, legacy_path):
    print("[8] CLI trên bản sao")
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
        rc, txt = run("--remove", "stone")
        rc, txt = run("--stone-pay", "xu")
        cur = open(dll, "rb").read()
        check(rc == 0 and "stone" in P.detect(cur)[0] and P.detect_stone_xu(cur) and "xu" in txt,
              f"--stone-pay xu bật luyện đá trả xu: {txt}")
        rc, txt = run("--mob")
        check(rc == 0 and P.detect_stone_xu(open(dll, "rb").read()), "chạy lại giữ chế độ trả xu")
        rc, txt = run("--stone-pay", "yen")
        check(rc == 0 and not P.detect_stone_xu(open(dll, "rb").read()), "--stone-pay yen")
        rc, txt = run("--remove", "stone")
        rc, txt = run("--stone-levels", "1-3")
        cur = open(dll, "rb").read()
        check(rc == 0 and "stone" in P.detect(cur)[0] and P.detect_stone_levels(cur) == (1, 3)
              and "lên đá cấp 3" in txt, f"--stone-levels 1-3 bật luyện đá: {txt}")
        rc, txt = run("--die")
        check(rc == 0 and P.detect_stone_levels(open(dll, "rb").read()) == (1, 3), "chạy lại giữ cấp đá")
        for bad in ("3-1", "3-3", "0-2", "1-13", "1", "abc"):
            before = open(dll, "rb").read()
            rc, txt = run("--stone-levels", bad)
            check(rc != 0 and open(dll, "rb").read() == before, f"--stone-levels {bad} phải bị từ chối: {txt}")
        rc, txt = run("--stone-levels", "6")
        check(rc == 0 and P.detect_stone_levels(open(dll, "rb").read()) == (1, 6), f"--stone-levels 6 = 1-6: {txt}")
        rc, txt = run("--stone-levels", "all")
        check(rc == 0 and P.detect_stone_levels(open(dll, "rb").read()) == P.STONE_LEVELS_ALL, "--stone-levels all")
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
    print("[9] Nâng cấp từ DLL v2 dựng bằng payload cũ")
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


# ----------------------------------------------------------------------------- 6
class CaveSim:
    """Chạy THẬT mã máy của cave (stone_tick, quest_tick) trong DLL đã dựng (nạp bằng
    LoadLibraryEx). Mọi hàm game / runtime IL2CPP mà cave gọi được thay bằng callback Python,
    các con trỏ TypeInfo trỏ tới class giả; nhân vật, hành trang, đá, nhiệm vụ, NPC là vùng
    nhớ giả có đúng offset."""
    CRYSTALS = [1, 4, 16, 64, 256, 1024, 4096, 16384, 65536, 262144, 1048576, 4194304]
    FEES = [0, 10, 20, 40, 80, 160, 320, 640, 1280, 2560, 5120, 10240]
    T0 = 13_400_000_000_000          # ms tính từ 1601, cỡ năm 2026

    def __init__(self, k32, dll_bytes, name, crystals=None, fees=None):
        self.k32 = k32
        self.heap = ctypes.create_string_buffer(0x80000)
        self.top = ctypes.addressof(self.heap)
        self.path = os.path.join(tempfile.gettempdir(), f"HvnjSim_{os.getpid()}_{name}.dll")
        open(self.path, "wb").write(dll_bytes)
        self.base = k32.LoadLibraryExW(self.path, None, 0x1)
        assert self.base, f"LoadLibraryEx lỗi {ctypes.get_last_error()}"
        self.now = self.T0
        self.sends, self.msgs, self.writers = [], {}, {}
        self.array_news, self.class_inits, self.init_md = [], [], []
        G = B.GAME_SYMBOLS
        U64 = ctypes.c_uint64
        F = ctypes.CFUNCTYPE
        self.cbs = {
            "lm_cua": F(U64, U64)(lambda _mi: self.char),
            "lj_cmy": F(U64, U64)(lambda _mi: self.service),
            "il2cpp_init_md": F(U64, U64)(lambda slot: self.init_md.append(slot - self.base) or 0),
            "il2cpp_class_init": F(U64, U64)(lambda k: self.class_inits.append(k) or 0),
            "il2cpp_object_new": F(U64, U64)(self._object_new),
            "il2cpp_array_new": F(U64, U64, U64)(self._array_new),
            "bc_ctor": F(U64, U64, U64, U64)(self._bc_ctor),
            "bl_bat": F(U64, U64, U64, U64)(self._bl_bat),
            "il2cpp_iface_invoke1": F(U64, U64, U64, U64, U64)(self._invoke),
            # quest_tick
            "mo_dgd": F(U64, U64, U64)(lambda _mo, _mi: 0),
            "mo_dga": F(U64, U64, U64, U64, U64)(lambda _mo, idx, la, _mi: self.dga.append((idx & 0xFF, la)) or 0),
            "mo_dgf": F(U64, U64, U64, U64, U64)(lambda _mo, m, npc, _o: self.dgf.append((m & 0xFFFFFFFF, npc)) or 0),
            "mo_dky": F(U64, U64, U64)(lambda npc, _mi: self.npc if (npc == 25 and self.npc_here) else 0),
            "ht_cbt": F(ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float, U64)(
                lambda x1, y1, x2, y2, _mi: ((x1 - x2) ** 2 + (y1 - y2) ** 2) ** 0.5),
            "lm_czd": F(U64, U64, ctypes.c_float, ctypes.c_float, U64)(
                lambda _c, x, y, _mi: self.walks.append((x, y)) or 0),
            "lj_menu": F(U64, U64, U64, U64, U64)(
                lambda _s, npc, menu, opt: self.menus.append((npc & 0xFFFFFFFF, menu & 0xFFFFFFFF, opt & 0xFFFFFFFF)) or 0),
        }
        self.dga, self.dgf, self.walks, self.menus = [], [], [], []
        self.cb_time = F(None, U64)(lambda p: setattr(U64.from_address(p), "value", self.now * 10000))
        for name_, cb in self.cbs.items():
            stub = b"\x48\xb8" + struct.pack("<Q", ctypes.cast(cb, ctypes.c_void_p).value) + b"\xff\xe0"
            self.poke(self.base + G[name_], stub)
        self.poke(self.base + G["imp_GetSystemTimeAsFileTime"],
                  struct.pack("<Q", ctypes.cast(self.cb_time, ctypes.c_void_p).value))
        # class giả: +133h cờ cctor, +0B8h static fields
        self.statics = {}
        for k in ("ca", "hw", "ek", "mc", "jr_array", "bc", "hs", "mb", "mo"):
            klass = self.alloc(0x140)
            st = self.alloc(0x200)
            self.w64(klass + 0xB8, st)
            self.statics[k] = st
            self.poke(self.base + G[k + "_TypeInfo"], struct.pack("<Q", klass))
            setattr(self, k + "_klass", klass)
        self.ek_instance = self.alloc(0x80)
        self.w64(self.statics["ek"], self.ek_instance)
        self.w8(self.statics["ca"] + 0x16, 1)                      # Auto bật
        self.set_table(0x108, crystals or self.CRYSTALS)
        self.set_table(0xD0, fees or self.FEES)
        self.char = self.alloc(0x200)
        self.w64(self.char + 0x140, 10**9)                          # xu
        self.w64(self.char + 0x150, 10**9)                          # yên
        self.service = self.alloc(0x40)
        self.session = self.alloc(0x40)
        self.w64(self.service + 0x10, self.session)
        self.fn = ctypes.CFUNCTYPE(None)(self.base + P.PAYLOAD_SYMBOLS["stone_tick"])
        # quest_tick: mo (GameScr), NPC 25 có vtable kk.cit()/ciu() trả toạ độ
        self.mo = self.alloc(0x400)
        self.qfn = ctypes.CFUNCTYPE(None, U64)(self.base + P.PAYLOAD_SYMBOLS["quest_tick"])
        self.w8(self.char + 0x170, 1)                               # hệ phái 1 -> trường map 1
        ctypes.c_float.from_address(self.char + 0xB8).value = 100.0
        ctypes.c_float.from_address(self.char + 0xBC).value = 100.0
        self.npc_here = True
        self.npc = self.alloc(0x40)
        vt = self.alloc(0x200)
        self.w64(self.npc, vt)
        self.cb_npc_x = F(ctypes.c_float, U64, U64)(lambda _n, _mi: 110.0)
        self.cb_npc_y = F(ctypes.c_float, U64, U64)(lambda _n, _mi: 100.0)
        self.w64(vt + 0x178, ctypes.cast(self.cb_npc_x, ctypes.c_void_p).value)
        self.w64(vt + 0x188, ctypes.cast(self.cb_npc_y, ctypes.c_void_p).value)
        self.set_map(1)
        self.set_tasks([])

    # --- bộ nhớ giả
    def alloc(self, n):
        a = self.top
        self.top += (n + 15) & ~15
        assert self.top <= ctypes.addressof(self.heap) + len(self.heap)
        return a

    def w64(self, a, v):
        ctypes.c_uint64.from_address(a).value = v

    def w32(self, a, v):
        ctypes.c_uint32.from_address(a).value = v

    def w16(self, a, v):
        ctypes.c_int16.from_address(a).value = v

    def w8(self, a, v):
        ctypes.c_uint8.from_address(a).value = v

    def poke(self, addr, data):
        old = ctypes.c_uint32()
        assert self.k32.VirtualProtect(ctypes.c_void_p(addr), len(data), 0x40, ctypes.byref(old))
        ctypes.memmove(addr, data, len(data))

    def set_table(self, off, values):
        arr = self.alloc(0x20 + 4 * len(values))
        self.w64(arr + 0x18, len(values))
        for i, v in enumerate(values):
            ctypes.c_int32.from_address(arr + 0x20 + 4 * i).value = v
        self.w64(self.statics["mc"] + off, arr)

    def make_item(self, spec, index):
        """spec: None = ô trống, 'eq' = trang bị, (id, khóa, đang chọn) hoặc id = đá (id 0 = cấp 1)."""
        if spec is None:
            return 0
        tpl = self.alloc(0x20)
        it = self.alloc(0x60)
        if spec == "eq":
            self.w16(tpl + 0x10, 1)
            self.w8(tpl + 0x12, 1)
        else:
            sid, lock, sel = (spec, 0, 0) if isinstance(spec, int) else spec
            self.w16(tpl + 0x10, sid)
            self.w8(tpl + 0x12, 26)
            self.w8(it + 0x38, lock)
            self.w8(it + 0x5E, sel)
        self.w64(it + 0x10, tpl)
        self.w32(it + 0x28, index)
        return it

    def make_array(self, specs):
        arr = self.alloc(0x20 + 8 * len(specs))
        self.w64(arr + 0x18, len(specs))
        for i, s in enumerate(specs):
            self.w64(arr + 0x20 + 8 * i, self.make_item(s, i))
        return arr

    def set_bag(self, specs):
        self.bag = self.make_array(specs)
        self.w64(self.char + 0x1B8, self.bag)

    def set_box(self, specs):
        """Rương đồ đã nạp (lm.miw); không gọi = client chưa mở rương lần nào (null)."""
        self.box = self.make_array(specs)
        self.w64(self.char + 0x1C0, self.box)

    def slot(self, arr, i):
        return ctypes.c_uint64.from_address(arr + 0x20 + 8 * i).value

    def set_slot(self, i, spec):
        self.w64(self.bag + 0x20 + 8 * i, self.make_item(spec, i))

    def server_combine(self, slots, new_id):
        """Server luyện xong: các viên đã gửi biến mất, viên mới (đối tượng mới) nằm ở ô đầu."""
        for i in slots:
            self.set_slot(i, None)
        self.set_slot(slots[0], new_id)

    def server_to_box(self, i):
        n = ctypes.c_uint64.from_address(self.box + 0x18).value
        j = next(k for k in range(n) if not self.slot(self.box, k))
        self.w64(self.box + 0x20 + 8 * j, self.slot(self.bag, i))
        self.set_slot(i, None)

    def clear_slots(self, slots):
        for i in slots:
            self.set_slot(i, None)

    # --- callback thay hàm game
    def _object_new(self, klass):
        assert klass == self.bc_klass
        return self.alloc(0x40)

    def _array_new(self, klass, n):
        self.array_news.append((klass, n))
        return self.alloc(0x20 + 8 * n)

    def _bc_ctor(self, this, cmd, _mi):
        w = self.alloc(0x20)
        self.writers[w] = this
        self.msgs[this] = {"cmd": cmd & 0xFF, "idx": []}
        self.w64(this + 0x20, w)
        return 0

    def _bl_bat(self, writer, value, _mi):
        self.msgs[self.writers[writer]]["idx"].append(value & 0xFFFFFFFF)
        return 0

    def _invoke(self, slot, iface, obj, msg):
        self.sends.append(dict(self.msgs[msg], slot=slot, iface=iface, obj=obj))
        return 0

    def set_map(self, m):
        self.w16(self.statics["mb"] + 0x5C, m)

    def set_auto(self, on):
        self.w8(self.statics["ca"] + 0x16, 1 if on else 0)

    def set_tasks(self, tasks):
        """tasks: (la.mad, count, max, killId, map) -> mo.nfl (List<la>)."""
        self.tasks = []
        arr = self.alloc(0x20 + 8 * max(len(tasks), 1))
        self.w64(arr + 0x18, len(tasks))
        for i, (mad, cnt, mx, kill, m) in enumerate(tasks):
            la = self.alloc(0x60)
            self.w32(la + 0x10, mad)
            self.w32(la + 0x14, cnt)
            self.w32(la + 0x18, mx)
            self.w32(la + 0x38, kill)
            self.w32(la + 0x3C, m)
            self.w64(arr + 0x20 + 8 * i, la)
            self.tasks.append(la)
        lst = self.alloc(0x20)
        self.w64(lst + 0x10, arr)
        self.w32(lst + 0x18, len(tasks))
        self.w64(self.statics["mo"] + 0x80, lst)

    def qtick(self, dt_ms=500):
        """Chạy quest_tick(mo) sau dt_ms; trả về (dga, menu, dgf) phát sinh trong lần này."""
        self.now += dt_ms
        a, b, c = len(self.dga), len(self.menus), len(self.dgf)
        self.qfn(self.mo)
        return self.dga[a:], self.menus[b:], self.dgf[c:]

    def engage(self):
        """Bật Auto (cạnh lên của ca.fxf) như người chơi bấm nút."""
        self.set_auto(False)
        self.qtick(1000)
        self.set_auto(True)
        return self.qtick(1000)

    def tick(self, dt_ms=1000):
        """Chạy stone_tick sau dt_ms; trả về các packet gửi ra trong lần này."""
        self.now += dt_ms
        n = len(self.sends)
        self.fn()
        return self.sends[n:]

    def close(self):
        self.k32.FreeLibrary(ctypes.c_void_p(self.base))
        try:
            os.remove(self.path)
        except OSError:
            pass


def test_stone_logic(orig):
    print("[6] Chạy thật stone_tick với nhân vật / hành trang giả")
    if os.name != "nt":
        print("    bỏ qua (không phải Windows)")
        return
    k32 = ctypes.WinDLL("kernel32", use_last_error=True)
    k32.LoadLibraryExW.restype = ctypes.c_void_p
    k32.LoadLibraryExW.argtypes = [ctypes.c_wchar_p, ctypes.c_void_p, ctypes.c_uint32]
    k32.FreeLibrary.argtypes = [ctypes.c_void_p]
    k32.VirtualProtect.argtypes = [ctypes.c_void_p, ctypes.c_size_t, ctypes.c_uint32, ctypes.POINTER(ctypes.c_uint32)]
    TOO_MUCH = 2**31 - 1        # bảng phí là int32; nhân vật giả có 10^9 xu + 10^9 yên
    n_cases = 0

    def sim(name, xu=False, levels=P.STONE_LEVELS_ALL, **kw):
        nonlocal n_cases
        n_cases += 1
        return CaveSim(k32, P.build(orig, {"stone"}, 0, stone_xu=xu, stone_levels=levels), name, **kw)

    def one(sends, cmd, idx, msg):
        ok = len(sends) == 1 and sends[0]["cmd"] == cmd and sends[0]["idx"] == idx
        return check(ok, f"{msg}: {[(s['cmd'], s['idx']) for s in sends]} (mong đợi cmd {cmd} {idx})")

    # 1. trả yên: 4 viên cấp 1 đầu tiên -> cấp 2; chờ, gửi lại, nghỉ 5 phút, server xử lý xong
    s = sim("yen")
    try:
        s.set_bag([0, 0, "eq", 0, 1, 0, 0, 1, 1, None])
        sends = s.tick()
        one(sends, 20, [0, 1, 3, 5], "trả yên, 4 viên cấp 1")
        if sends:
            check(sends[0]["slot"] == 3 and sends[0]["iface"] == s.hs_klass and sends[0]["obj"] == s.session,
                  "gửi qua hs slot 3 của session")
        gyo = ctypes.c_uint64.from_address(s.statics["ek"] + 8).value
        check(s.array_news == [(s.jr_array_klass, 24)] and gyo != 0, "phải tạo ek.gyo = new jr[24]")
        check(all(B.GAME_SYMBOLS[k + "_TypeInfo"] in s.init_md for k in ("ek", "jr_array", "bc", "hs")),
              f"phải InitializeRuntimeMetadata các TypeInfo: {[hex(x) for x in s.init_md]}")
        check(not s.tick(500) and not s.tick(1000), "trong 3 giây chờ server không gửi gì")
        one(s.tick(2000), 20, [0, 1, 3, 5], "hành trang không đổi -> gửi lại 1 lần")
        check(not s.tick(3000), "2 lần không đổi -> nghỉ")
        check(not s.tick(60_000) and not s.tick(200_000), "đang nghỉ 5 phút")
        one(s.tick(40_000), 20, [0, 1, 3, 5], "hết 5 phút thử lại")
        check(len(s.array_news) == 1, "ek.gyo đã có thì không tạo lại")
        s.server_combine([0, 1, 3, 5], 1)      # server: 4 viên cấp 1 -> 1 viên cấp 2 ở ô 0
        one(s.tick(3000), 20, [0, 4, 7, 8], "đợt luyện chạy tiếp dù đã có 4 ô trống: 4 viên cấp 2")
        s.server_combine([0, 4, 7, 8], 2)
        check(not s.tick(3000), "hết nhóm luyện được -> kết thúc đợt")
        s.set_slot(1, 0)
        s.set_slot(3, 0)
        s.set_slot(4, 0)
        s.set_slot(5, 0)
        check(not s.tick(30_000), "đợt mới chỉ bắt đầu khi hành trang lại đầy")
    finally:
        s.close()

    # 2. chưa đầy (2 ô trống), không Auto, chết, popup Luyện đá đang mở, thiếu tiền
    for name, setup in (
            ("not_full", lambda s: s.set_bag([0, 0, 0, 0, None, None])),
            ("auto_off", lambda s: s.w8(s.statics["ca"] + 0x16, 0)),
            ("dead", lambda s: s.w32(s.char + 0x5C, 14)),
            ("popup", lambda s: s.w64(s.statics["hw"] + 0x128, s.ek_instance)),
            ("poor", lambda s: (s.w64(s.char + 0x140, 5), s.w64(s.char + 0x150, 4)))):
        s = sim(name)
        try:
            s.set_bag([0, 0, 0, 0, "eq", None])
            setup(s)
            check(not s.tick(), f"{name}: không được luyện")
        finally:
            s.close()
    s = sim("enough")
    try:
        s.set_bag([0, 0, 0, 0, None])
        s.w64(s.statics["hw"] + 0x128, s.alloc(0x40))             # popup khác đang mở
        s.w64(s.char + 0x140, 5)
        s.w64(s.char + 0x150, 5)
        one(s.tick(), 20, [0, 1, 2, 3], "yên + xu vừa đủ phí, popup khác không cản")
    finally:
        s.close()

    # 3. trả xu: không gộp đá khóa với đá không khóa, ưu tiên nhóm không khóa
    s = sim("xu_locked", xu=True)
    try:
        s.set_bag([0, (0, 1, 0), 0, (0, 1, 0), 0, (0, 1, 0), (0, 1, 0), None])
        one(s.tick(), 19, [1, 3, 5, 6], "trả xu: 3 viên không khóa thì luyện 4 viên khóa")
    finally:
        s.close()
    s = sim("xu_unlocked", xu=True)
    try:
        s.set_bag([(0, 1, 0), 0, (0, 1, 0), 0, (0, 1, 0), 0, (0, 1, 0), 0, None])
        one(s.tick(), 19, [1, 3, 5, 7], "trả xu: ưu tiên 4 viên không khóa")
    finally:
        s.close()
    s = sim("xu_poor", xu=True)
    try:
        s.set_bag([0, 0, 0, 0, None])
        s.w64(s.char + 0x140, 5)
        check(not s.tick(), "trả xu: không tính yên vào phí")
    finally:
        s.close()

    # 4. --stone-levels A-B: luyện dần từ cấp A lên cấp B, đá cấp B cất vào rương
    s = sim("lv23", levels=(2, 3))
    try:
        s.set_bag([0, 0, 0, 0, 1, 1, 1, 1, None])
        one(s.tick(), 20, [4, 5, 6, 7], "từ cấp 2 lên cấp 3: bỏ đá cấp 1")
    finally:
        s.close()
    s = sim("lv12", levels=(1, 2))
    try:
        s.set_bag([1, 1, 1, 1, 0, 0, 0, None])
        check(not s.tick(), "lên cấp 2: không đụng đá cấp 2, 3 viên cấp 1 chưa đủ, rương chưa nạp")
    finally:
        s.close()
    fees = [0, TOO_MUCH, TOO_MUCH, 40] + CaveSim.FEES[4:]      # chỉ đủ tiền ra đá cấp 4
    s = sim("lvall_cap", fees=fees)
    try:
        s.set_bag([1] * 16 + [None])
        one(s.tick(), 20, list(range(16)), "16 viên cấp 2 -> cấp 4 khi không giới hạn")
    finally:
        s.close()
    s = sim("lv13_cap", levels=(1, 3), fees=fees)
    try:
        s.set_bag([1] * 16 + [None])
        check(not s.tick(), "lên tối đa cấp 3: không được ra cấp 4")
    finally:
        s.close()
    s = sim("climb", levels=(1, 3))                                 # lên cấp 3 rồi cất rương
    try:
        s.set_bag([0] * 16 + ["eq", None])
        s.set_box(["eq", None, None])
        one(s.tick(), 20, [0, 1, 2, 3], "leo cấp: 4 viên cấp 1 (1)")
        for k, first in enumerate((4, 8, 12)):
            s.server_combine(list(range(first - 4, first)), 1)
            one(s.tick(3000), 20, list(range(first, first + 4)), f"leo cấp: 4 viên cấp 1 ({k + 2})")
        s.server_combine(list(range(12, 16)), 1)
        one(s.tick(3000), 20, [0, 4, 8, 12], "leo cấp: 4 viên cấp 2 -> cấp 3")
        s.server_combine([0, 4, 8, 12], 2)
        one(s.tick(3000), 17, [0], "viên cấp 3 (cấp đích) cất vào rương")
        s.server_to_box(0)
        check(s.slot(s.box, 1) != 0, "rương nhận viên đá")
        check(not s.tick(3000), "cất xong, hết nhóm luyện được -> dừng")
    finally:
        s.close()
    for name, box, msg in (("box_null", None, "rương chưa nạp"), ("box_full", ["eq", "eq"], "rương đầy")):
        s = sim(name, levels=(1, 3))
        try:
            s.set_bag([2, 0, 0, 0, 0, None])
            if box:
                s.set_box(box)
            one(s.tick(), 20, [1, 2, 3, 4], f"{msg}: không cất, vẫn luyện")
        finally:
            s.close()
    s = sim("box_refused", levels=(1, 3))
    try:
        s.set_bag([2, 0, 0, 0, 0, None])
        s.set_box([None])
        one(s.tick(), 17, [0], "cất rương trước khi luyện")
        one(s.tick(3000), 17, [0], "server chưa cất -> thử lại")
        one(s.tick(3000), 20, [1, 2, 3, 4], "server không cho cất 2 lần -> ngừng cất, vẫn luyện ngay")
        s.server_combine([1, 2, 3, 4], 1)
        check(not s.tick(3000), "đang ngừng cất rương 30 phút, hết nhóm luyện được")
        one(s.tick(30 * 60_000), 17, [0], "hết 30 phút thử cất lại")
    finally:
        s.close()
    s = sim("all_no_box")
    try:
        s.set_bag([11, 0, 0, 0, 0, None])
        s.set_box([None, None])
        one(s.tick(), 20, [1, 2, 3, 4], "không chọn cấp: không cất đá vào rương")
    finally:
        s.close()

    # 5. gộp nhiều cấp, đá đang chọn trong popup, tối đa 24 viên, static constructor
    s = sim("mix", fees=[0, TOO_MUCH] + CaveSim.FEES[2:])
    try:
        s.set_bag([1, 0, 1, 0, "eq", 0, 1, 0, None])
        one(s.tick(), 20, [0, 1, 2, 3, 5, 6, 7], "3 viên cấp 2 + 4 viên cấp 1 = cấp 3 (100%)")
    finally:
        s.close()
    s = sim("selected")
    try:
        s.set_bag([(0, 0, 1), 0, 0, 0, 0, None])
        one(s.tick(), 20, [1, 2, 3, 4], "bỏ qua đá đang chọn trong popup")
    finally:
        s.close()
    s = sim("cap24", crystals=[1, 24] + CaveSim.CRYSTALS[2:])
    try:
        s.set_bag([0] * 30 + [None])
        one(s.tick(), 20, list(range(24)), "điểm cấp 2 = 24: luyện đúng 24 viên")
    finally:
        s.close()
    s = sim("over24", crystals=[1, 30, 900] + CaveSim.CRYSTALS[3:])
    try:
        s.set_bag([0] * 30 + [None])
        check(not s.tick(), "cần 30 viên (> 24): không luyện")
    finally:
        s.close()
    s = sim("cctor")
    try:
        s.w8(s.ek_klass + 0x133, 2)                                 # có static constructor, chưa chạy
        s.set_bag([0, 0, 0, 0, None])
        one(s.tick(), 20, [0, 1, 2, 3], "ek chưa khởi tạo")
        check(s.class_inits == [s.ek_klass], "phải chạy static constructor của ek")
    finally:
        s.close()
    print(f"    {n_cases} tình huống")


def test_quest_logic(orig):
    print("[7] Chạy thật quest_tick (nhiệm vụ ngày + tà thú) với NPC / nhiệm vụ giả")
    if os.name != "nt":
        print("    bỏ qua (không phải Windows)")
        return
    k32 = ctypes.WinDLL("kernel32", use_last_error=True)
    k32.LoadLibraryExW.restype = ctypes.c_void_p
    k32.LoadLibraryExW.argtypes = [ctypes.c_wchar_p, ctypes.c_void_p, ctypes.c_uint32]
    k32.FreeLibrary.argtypes = [ctypes.c_void_p]
    k32.VirtualProtect.argtypes = [ctypes.c_void_p, ctypes.c_size_t, ctypes.c_uint32, ctypes.POINTER(ctypes.c_uint32)]
    n_cases = 0
    DAILY, TATHU = 0, 1

    def sim(name, feats):
        nonlocal n_cases
        n_cases += 1
        return CaveSim(k32, P.build(orig, set(feats), 0), "q_" + name)

    # 1. chỉ --tathu, chưa có nhiệm vụ, đứng cạnh NPC 25 ở trường -> nhận tà thú ở menu 1
    s = sim("accept_tathu", ["tathu"])
    try:
        _d, menus, _f = s.engage()
        check(menus == [(25, 1, 0)], f"chỉ --tathu: nhận bằng menu(25, 1, 0): {menus}")
    finally:
        s.close()

    # 2. --quest --tathu: nhận nhiệm vụ ngày trước, 4 lần không được thì sang tà thú, hết thì dừng
    s = sim("accept_order", ["quest", "tathu"])
    try:
        menus = s.engage()[1]
        for _ in range(12):
            menus += s.qtick(4000)[1]
        want = [(25, 0, 0)] * 4 + [(25, 1, 0)] * 4
        check(menus == want, f"thứ tự nhận: {menus}")
    finally:
        s.close()

    # 3. chỉ --quest: bỏ qua nhiệm vụ tà thú đang có, vẫn đi nhận nhiệm vụ ngày
    s = sim("quest_only", ["quest"])
    try:
        s.set_tasks([(TATHU, 0, 1, 50, 30)])
        dga, menus, _f = s.engage()
        check(not dga and menus == [(25, 0, 0)], f"--quest không đụng tà thú: {dga} {menus}")
    finally:
        s.close()

    # 4. có cả hai nhiệm vụ: làm nhiệm vụ ngày trước (index UI = vị trí + 2)
    s = sim("both", ["quest", "tathu"])
    try:
        s.set_tasks([(TATHU, 0, 1, 50, 30), (DAILY, 0, 10, 7, 20)])
        dga = s.engage()[0]
        check(dga == [(3, s.tasks[1])], f"ưu tiên nhiệm vụ ngày: {dga}")
    finally:
        s.close()

    # 5. tà thú chưa ở map: gọi pipeline của game (tự tìm đường); đã xong thì gọi để về trả
    for name, task, msg in (("go", (TATHU, 0, 1, 50, 30), "chưa tới map"),
                            ("done", (TATHU, 1, 1, 50, 30), "đã giết xong")):
        s = sim("tathu_" + name, ["tathu"])
        try:
            s.set_tasks([task])
            dga = s.engage()[0]
            check(dga == [(2, s.tasks[0])], f"tà thú {msg}: phải gọi mo.dga(2, la): {dga}")
            s.w8(s.mo + 0x201, 1)                                   # pipeline đang chạy
            check(not s.qtick(10_000)[0], f"tà thú {msg}: pipeline đang chạy thì không gọi lại")
        finally:
            s.close()

    # 6. ở map tà thú, Auto bật: tà thú chưa xuất hiện -> cứ 15s gọi lại pipeline, không bỏ cuộc
    s = sim("tathu_wait", ["tathu"])
    try:
        s.set_tasks([(TATHU, 0, 1, 50, 30)])
        s.set_map(30)
        n = len(s.engage()[0])
        n += sum(len(s.qtick(5000)[0]) for _ in range(2))           # 10s: chưa tới 15s
        check(n == 1, f"ở map tà thú: lần đầu gọi ngay, chưa tới 15s không gọi lại ({n})")
        calls = sum(len(s.qtick(15_000)[0]) for _ in range(10))
        check(calls == 10, f"chờ tà thú: phải gọi lại mỗi 15s, không dừng sau 3 lần ({calls}/10)")
        s.set_auto(False)                                           # người chơi tắt Auto
        check(not s.qtick(15_000)[0] and not s.qtick(15_000)[0], "tắt Auto ở map tà thú -> dừng")
    finally:
        s.close()

    # 7. nhiệm vụ ngày ở map, Auto bật: để game tự đánh (giữ hành vi cũ)
    s = sim("daily_map", ["quest", "tathu"])
    try:
        s.set_tasks([(DAILY, 3, 10, 7, 20)])
        s.set_map(20)
        dga, menus, _f = s.engage()
        dga2 = s.qtick(20_000)[0]
        check(not dga and not dga2 and not menus, f"nhiệm vụ ngày ở map + Auto: không can thiệp {dga} {dga2}")
    finally:
        s.close()

    # 8. chưa ở trường: tìm đường về trường theo hệ phái tới NPC 25
    s = sim("nav_school", ["tathu"])
    try:
        s.set_map(5)
        _d, menus, dgf = s.engage()
        check(dgf == [(1, 25)] and not menus, f"về trường map 1 tìm NPC 25: {dgf} {menus}")
    finally:
        s.close()
    print(f"    {n_cases} tình huống")


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
    test_stone_logic(orig)
    test_quest_logic(orig)
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
