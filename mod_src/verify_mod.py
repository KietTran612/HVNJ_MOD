"""Kiểm thử bản mod (không cần mở game).

    python mod_src/verify_mod.py [--original GameAssembly.dll.bak] [--legacy duong_dan_dll_mod_v1]
                                 [--old-v2 dll_v2_cu [dll_v2_cu ...]]

 1. Cài mod: nhận diện bản v3, mọi tính năng mặc định tắt, khôi phục được bản gốc
    (SHA-256); gỡ được patch "0.3s" đã bỏ khỏi DLL cũ.
 2. Khôi phục bản gốc từ bản mod cũ v1.
 3. Cấu trúc PE: section mới, SizeOfImage, .pdata sắp xếp đúng.
 4. Disassemble mọi khối code (cave asm, hàm C) và hook: lệnh nhảy/gọi trỏ tới địa
    chỉ đã biết, đích nhảy về đầu lệnh của hàm game, không ai nhảy vào giữa vùng đã
    thay, sau lệnh call trong asm không có mẫu epilogue. Nút Shop: mo.dhn luôn trả true
    và chỉ phần nút Shop của thanh Top gọi mo.dhn.
 5. (Windows) Nạp DLL thật bằng LoadLibraryEx: quyền trang nhớ, RtlLookupFunctionEntry
    cho mọi khối, RtlVirtualUnwind từ trong cave = unwind tại vị trí hook gốc.
 6. Chạy THẬT các cave chặn theo cờ (qua trampoline): cờ tắt -> đi đúng đường của lệnh
    gốc, cờ bật -> hành vi của mod.
 7. Chạy THẬT menu "Mod HVNJ" (hvnj_menu.c): hiện menu, tick, lưu / đọc PlayerPrefs,
    dòng "Mod HVNJ" trong menu nhân vật, lệnh của game vẫn tới mo.djh.
 8. Chạy THẬT stone_tick (luyện đá) với nhân vật / hành trang giả.
 9. Chạy THẬT bag_tick (bán đồ thiếu dòng / cất đồ đủ dòng vào rương -> luyện đá) với shop /
    server giả: tải danh sách shop, xem chi tiết, bán, cất rương tới khi đầy, giữ đúng món,
    chờ / nghỉ khi server không trả lời,
    thứ tự bán -> luyện đá, auto nhiệm vụ tạm dừng, menu Xem trước.
10. Chạy THẬT quest_tick (auto nhiệm vụ ngày + tà thú) với NPC / nhiệm vụ / map giả.
11. Chạy CLI patch_skill_delay.py trên bản sao: nâng cấp từ v1, lệnh cũ, restore.
12. (--old-v2) Nâng cấp DLL v2 cũ (chọn tính năng bằng script) hoặc bản v3 dựng trước đó
    lên bản menu hiện tại.
"""
import argparse
import ctypes
import hashlib
import importlib.util
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
CFG_TOGGLES = ["cfg_mob", "cfg_die", "cfg_trial", "cfg_stage", "cfg_quest", "cfg_tathu", "cfg_party",
               "cfg_sell", "cfg_stone"]  # thứ tự dòng tick trong menu (hvnj_menu.c)
PREVIEW_LINE = "Xem trước trang bị sẽ bán"   # dòng ngay sau tick "Tự bán trang bị"
TOGGLE_NAMES = [n for n in P.MENU_ITEMS if n != PREVIEW_LINE][:len(CFG_TOGGLES)]
T_SELL = CFG_TOGGLES.index("cfg_sell")
ACT = 0x48560000                        # MOD_ACT_BASE
ACT_PREVIEW = ACT + 14
ACT_OPEN_BOX, ACT_OPEN_UP = ACT + 15, ACT + 16


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


def call_sites(data, target):
    """Mọi lệnh call/jmp rel32 trong code game nhảy tới target."""
    sites = set()
    for _name, va, vsize, raw, rsize in P.section_table(data)[:2]:      # .text, il2cpp
        sec = bytes(data[raw:raw + min(vsize, rsize)])
        for op in (b"\xe8", b"\xe9"):
            i = sec.find(op)
            while 0 <= i <= len(sec) - 5:
                if va + i + 5 + struct.unpack_from("<i", sec, i + 1)[0] == target:
                    sites.add(va + i)
                i = sec.find(op, i + 1)
    return sites


def kernel32():
    k32 = ctypes.WinDLL("kernel32", use_last_error=True)
    k32.LoadLibraryExW.restype = ctypes.c_void_p
    k32.LoadLibraryExW.argtypes = [ctypes.c_wchar_p, ctypes.c_void_p, ctypes.c_uint32]
    k32.FreeLibrary.argtypes = [ctypes.c_void_p]
    k32.VirtualProtect.argtypes = [ctypes.c_void_p, ctypes.c_size_t, ctypes.c_uint32, ctypes.POINTER(ctypes.c_uint32)]
    k32.VirtualAlloc.restype = ctypes.c_void_p
    k32.VirtualAlloc.argtypes = [ctypes.c_void_p, ctypes.c_size_t, ctypes.c_uint32, ctypes.c_uint32]
    k32.VirtualFree.argtypes = [ctypes.c_void_p, ctypes.c_size_t, ctypes.c_uint32]
    return k32


# ----------------------------------------------------------------------------- 1, 2
def with_retired_skill(data):
    """Mô phỏng DLL cũ còn patch 'tốc độ ra chiêu 0.3s' (đã gỡ)."""
    buf = bytearray(data)
    for rva, _o, n in P.RETIRED_PATCHES["skill"]:
        off = P.rva_to_off(buf, rva)
        buf[off:off + len(n) // 2] = bytes.fromhex(n)
    return bytes(buf)


def skill_is_original(data):
    return all(P.read_at(data, rva, len(o) // 2) == bytes.fromhex(o) for rva, o, _n in P.RETIRED_PATCHES["skill"])


def test_install(orig):
    print("[1] Cài mod: nhận diện, mặc định tắt hết, khôi phục bản gốc")
    out = P.build(orig)
    kind, on = P.detect(out)
    check(kind == P.KIND_V3 and not on, f"detect bản cài: {kind} {on}")
    check(P.payload_version(out) == P.PAYLOAD_VERSION == 3, "cfg_version = 3")
    cfg = P.cfg_offset(out)
    check(out[cfg:cfg + 4] == b"HVNJ", "magic HVNJ ở đầu .hvnjd")
    flags = [k for k in P.PAYLOAD_CFG if k != "cfg_block"]
    check(all(out[cfg + P.PAYLOAD_CFG[k]] == 0 for k in flags), "mọi cfg phải = 0 (tắt cho tới khi tick)")
    check(all(P.read_at(out, rva, len(n) // 2) == bytes.fromhex(n) for rva, _o, n in P.PAYLOAD_HOOKS), "đủ hook")
    check(sha(P.strip_payload(out)) == P.ORIGINAL_SHA256, "khôi phục gốc từ bản cài")
    check(P.build(P.strip_payload(out)) == out, "cài lại từ bản khôi phục cho cùng kết quả")
    check(skill_is_original(out), "bản cài không còn patch 0.3s")
    old = with_retired_skill(out)
    check(P.detect_retired(old) == {"skill"} and sha(P.strip_payload(old)) == P.ORIGINAL_SHA256,
          "nhận diện và gỡ được patch 0.3s cũ")
    check(P.detect(orig) == (P.KIND_ORIGINAL, set()), "nhận diện bản gốc")
    return out


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
        kind, on = P.detect(lb)
        # skill/die của v1 trùng byte với v2 -> nhận là v2 cũng đúng; skill không còn là tính năng
        want_kind = P.KIND_V2 if set(feats) <= {"skill", "die"} else P.KIND_V1
        check(kind == want_kind and on == set(feats) - {"skill"}, f"detect legacy {feats} -> {kind} {sorted(on)}")
    if legacy_path:
        lb = open(legacy_path, "rb").read()
        kind, on = P.detect(lb)
        print(f"    {os.path.basename(legacy_path)}: {kind}, {sorted(on)}")
        rec = P.strip_legacy(lb)
        check(kind == P.KIND_V1 and rec is not None and sha(rec) == P.ORIGINAL_SHA256,
              f"--legacy phải là DLL v1 và khôi phục được ({kind})")


# ----------------------------------------------------------------------------- 3
def test_pe(orig, out):
    print("[3] Cấu trúc PE")
    pe = B.PE(out)
    names = [s["name"] for s in pe.sections]
    check(names[-3:] == [".hvnj", ".hvnjd", ".hvnjp"], f"section {names}")
    for a, b in zip(pe.sections, pe.sections[1:]):
        check(a["va"] + B.align(max(a["vsize"], 1), B.SECTION_ALIGN) <= b["va"], f"VA chồng {a['name']}")
        check(a["raw"] + a["rsize"] <= b["raw"], f"raw chồng {a['name']}")
    last = pe.sections[-1]
    check(pe.size_of_image == B.align(last["va"] + last["vsize"], B.SECTION_ALIGN), "SizeOfImage")
    check(len(out) == last["raw"] + last["rsize"], "kích thước file")
    hv = pe.section(".hvnj")
    hd = pe.section(".hvnjd")
    check(hv["chars"] == 0x60000020 and hd["chars"] == 0xC0000040, "quyền section")
    # exception directory chuyển sang .hvnjp = bảng .pdata gốc nguyên vẹn + entry của payload
    hp = pe.section(".hvnjp")
    check(hp["chars"] == 0x40000040 and pe.exc_rva == hp["va"] and pe.exc_size == hp["vsize"],
          ".hvnjp chỉ đọc và phủ đúng exception directory")
    game = B.PE(orig).pdata()
    ents = pe.pdata()
    check(ents[:len(game)] == game and len(ents) == len(game) + len(P.PAYLOAD_PDATA),
          "exception directory = bảng .pdata của game + entry payload")
    check(out[pe.section(".pdata")["raw"]:pe.section(".pdata")["raw"] + pe.section(".pdata")["rsize"]]
          == orig[pe.section(".pdata")["raw"]:pe.section(".pdata")["raw"] + pe.section(".pdata")["rsize"]]
          and out[pe.section(".pdata")["hdr"]:pe.section(".pdata")["hdr"] + 40]
          == orig[pe.section(".pdata")["hdr"]:pe.section(".pdata")["hdr"] + 40], "section .pdata gốc không bị sửa")
    check(all(a[0] < b[0] and a[1] <= b[0] for a, b in zip(ents, ents[1:])), ".pdata sắp xếp, không chồng")
    for e in ents[-len(P.PAYLOAD_PDATA):]:
        check(hv["va"] <= e[0] < e[1] <= hv["va"] + hv["vsize"], f"pdata ngoài .hvnj {e}")
        check(hv["va"] <= e[2] < hv["va"] + hv["vsize"], f"unwind info ngoài .hvnj {e}")


# ----------------------------------------------------------------------------- 4
EPILOGUE_START = ("ret", "jmp", "pop")
# Hàm asm có prologue riêng (ml64 PROC FRAME): (cấp phát stack, thanh ghi push theo thứ tự địa chỉ tăng dần)
FRAME_FUNCS = {
    "quest_tick": (0x40, ["R15", "R14", "R13", "R12", "Rdi", "Rsi", "Rbx"]),
    "party_leader": (0x28, ["Rsi", "Rbx"]),
    "party_tick": (0x30, ["Rdi", "Rsi", "Rbx"]),
    "die_tick": (0x38, ["R12", "Rdi", "Rsi", "Rbx"]),
    "stone_tick": (0x68, ["R15", "R14", "R13", "R12", "Rdi", "Rsi", "Rbp", "Rbx"]),
    "action_hook": (0x28, []),
    "menuchar_hook": (0x28, []),
}
# Điểm quay lại / đích nhảy gốc trong hàm game mà cave nhảy tới (phải là đầu lệnh)
BACK_TARGETS = ["dgj_accept", "dgj_skip", "dgj_epilogue_tail", "clo_store", "dgl_accept", "dgl_skip", "dgj_null",
                "dgj_core1_back", "dgj_core2_back", "dgj_core2_skip", "ctq_cd1_back", "ctq_cd2_back", "cdy_back",
                "cdq_back", "dek_keep_auto", "dek_back", "bld_back", "bld_block"]
# Hook -> (lệnh, khối cave) ở đầu vùng thay
HOOK_EXPECT = {
    0x1B9DB1: ("jmp", "dgj_core1"), 0x1B9DFC: ("jge", "dgj_ret"), 0x1B9E4B: ("jmp", "dgj_core2"),
    0x1B9F11: ("jmp", "dgj_filter"), 0x1BA48E: ("jmp", "dgl_filter"), 0x24B5AC: ("jmp", "clo_stage"),
    0x19495E: ("call", "quest_tick"), 0x1927E2: ("jmp", "ctq_cd1"), 0x192912: ("jmp", "ctq_cd2"),
    0x3612E0: ("jmp", "cdy_dlg"), 0x360946: ("jmp", "cdq_dlg"), 0x19C061: ("jmp", "dek_trial"),
    0x477CBF: ("jmp", "bld_trial"), 0x4E6027: ("call", "action_hook"), 0x1EA0BA: ("call", "menuchar_hook"),
}
ASM_FUNCS = set(FRAME_FUNCS)


def code_blocks():
    """(tên, lo, hi, trong frame host?, là asm?) cho mọi entry .pdata của payload và mọi hàm C
    (kể cả hàm lá không có .pdata)."""
    S = P.PAYLOAD_SYMBOLS
    names = {}
    for k, v in S.items():
        names.setdefault(v, k)
    for a, _b, n in P.PAYLOAD_C_FUNCS:
        names.setdefault(a, n)
    chained = {S[s]: s for s, _e, _site in B.CHAINED_BLOCKS}
    out = []
    for lo, hi, _u in P.PAYLOAD_PDATA:
        if lo in chained:
            out.append((chained[lo], lo, hi, True, True))
        else:
            n = names.get(lo, f"({lo:#x})")
            out.append((n, lo, hi, False, n in ASM_FUNCS))
    with_pdata = {lo for lo, _hi, _u in P.PAYLOAD_PDATA}
    out += [(n, a, b, False, False) for a, b, n in P.PAYLOAD_C_FUNCS if a not in with_pdata]
    return out


def func_bounds(name):
    start = P.PAYLOAD_SYMBOLS[name]
    return start, next(e[1] for e in P.PAYLOAD_PDATA if e[0] == start)


def test_disasm(orig, out):
    print("[4] Disassemble cave, hàm C và hook")
    S = P.PAYLOAD_SYMBOLS
    code_lo, code_hi = P.PAYLOAD_CODE_RVA, P.PAYLOAD_CODE_RVA + len(P.PAYLOAD_CODE)
    data_lo, data_hi = P.PAYLOAD_DATA_RVA, P.PAYLOAD_DATA_RVA + len(P.PAYLOAD_DATA)
    blocks = code_blocks()
    func_starts = {lo for _n, lo, _hi, in_host, _a in blocks if not in_host} | {a for a, _b, _n in P.PAYLOAD_C_FUNCS}
    allowed_targets = set(B.GAME_SYMBOLS.values()) | func_starts
    allowed_mem = {v for k, v in B.GAME_SYMBOLS.items() if k.endswith(("_TypeInfo", "_mi"))} | \
        {B.GAME_SYMBOLS["imp_GetSystemTimeAsFileTime"]}
    game_pdata = B.PE(orig).pdata()

    def host_of(rva):
        return next((a, b) for a, b, _u in game_pdata if a <= rva < b)

    for name in BACK_TARGETS:
        a, b = host_of(B.GAME_SYMBOLS[name])
        check(B.GAME_SYMBOLS[name] in insn_starts(orig, a, b), f"{name} không phải đầu lệnh")
    check(disasm(orig, 0x1BA085, 0x10)[1].mnemonic == "xor", "1BA08A phải là xor eax,eax")

    with_pdata = {lo for lo, _hi, _u in P.PAYLOAD_PDATA}
    check(len(with_pdata) == len(P.PAYLOAD_PDATA) and len([b for b in blocks if b[3]]) == len(B.CHAINED_BLOCKS)
          and all(lo in with_pdata for _n, lo, _hi, _h, is_asm in blocks if is_asm),
          "mỗi khối asm phải có đúng một entry .pdata")
    check({n for _a, _b, n in P.PAYLOAD_C_FUNCS} >= {"mod_action", "mod_cfg_load", "mod_menu_add_entry", "show_menu"},
          "thiếu hàm C")
    check(all(S[n] in func_starts for n in ("mod_action", "mod_cfg_load", "mod_menu_add_entry")),
          "hàm C phải có unwind info")
    for start, lo, hi, in_host, is_asm in blocks:
        insns = disasm(out, lo, hi - lo)
        check(insns and insns[-1].address + insns[-1].size == hi, f"{start}: disassemble không trọn khối")
        for i, ins in enumerate(insns):
            if ins.mnemonic.startswith("j") or ins.mnemonic == "call":
                op = ins.operands[0]
                if op.type == capstone.x86.X86_OP_IMM:
                    t = op.imm
                    check(lo <= t < hi or t in allowed_targets, f"{start}: {ins.mnemonic} tới {t:#x} lạ")
                elif ins.mnemonic == "call" and op.type == capstone.x86.X86_OP_MEM:
                    # qua IAT (GetSystemTimeAsFileTime) hoặc hàm ảo của đối tượng game (vtable)
                    t = ins.address + ins.size + op.mem.disp
                    check(op.mem.base != capstone.x86.X86_REG_RIP or t == B.GAME_SYMBOLS["imp_GetSystemTimeAsFileTime"],
                          f"{start}: call gián tiếp lạ tại {ins.address:#x}")
                elif not (ins.mnemonic == "jmp" and op.type == capstone.x86.X86_OP_REG):
                    check(False, f"{start}: {ins.mnemonic} {ins.op_str} không xác định được đích")
            if is_asm and ins.mnemonic == "call" and i + 1 < len(insns):
                nxt = insns[i + 1]
                bad = nxt.mnemonic in EPILOGUE_START or (nxt.mnemonic in ("add", "lea") and "rsp" in nxt.op_str.split(",")[0])
                check(not bad, f"{start}: sau call tại {ins.address:#x} là '{nxt.mnemonic}' (giống epilogue)")
            for op in ins.operands:
                if op.type == capstone.x86.X86_OP_MEM and op.mem.base == capstone.x86.X86_REG_RIP:
                    t = ins.address + ins.size + op.mem.disp
                    # cl lấy mảng tĩnh bằng "lea r, __ImageBase" + [r + chỉ số + RVA] (ADDR32NB): vẫn độc lập ASLR
                    image_base = ins.mnemonic == "lea" and t == B.GAME_SYMBOLS["__ImageBase"]
                    check(code_lo <= t < code_hi or data_lo <= t < data_hi or t in allowed_mem or image_base,
                          f"{start}: truy cập bộ nhớ lạ {t:#x} tại {ins.address:#x}")
            if in_host:
                writes_rsp = bool(ins.operands) and ins.operands[0].type == capstone.x86.X86_OP_REG \
                    and ins.operands[0].reg == capstone.x86.X86_REG_RSP
                check(not writes_rsp and ins.mnemonic not in ("push", "pop", "ret"),
                      f"{start}: '{ins.mnemonic} {ins.op_str}' đổi rsp trong frame host")

    check({rva for rva, _o, _n in P.PAYLOAD_HOOKS} >= set(HOOK_EXPECT) - {0x1BA48E} | {0x1BA485},
          "danh sách hook thiếu")
    for rva, (mn, tgt) in HOOK_EXPECT.items():
        ins = disasm(out, rva, 8)[0]
        check(ins.mnemonic == mn and ins.operands[0].imm == S[tgt], f"hook {rva:#x}: {ins.mnemonic} {ins.op_str}")
    # nút Shop luôn hiện: mo.dhn -> mov al, 1 ; ret, và chỉ phần nút Shop của thanh Top gọi mo.dhn
    shop = [(i.mnemonic, i.op_str) for i in disasm(out, B.SHOP_DHN, 3)]
    check(shop == [("mov", "al, 1"), ("ret", "")], f"mo.dhn phải luôn trả true: {shop}")
    check(call_sites(orig, B.SHOP_DHN) == set(B.SHOP_DHN_CALLERS), "mo.dhn có chỗ gọi ngoài nút Shop")
    # không lệnh nào của hàm game nhảy vào giữa vùng đã thay
    for rva, o, _n in P.PAYLOAD_HOOKS:
        end = rva + len(o) // 2
        a, b = host_of(rva)
        for ins in disasm(orig, a, b - a):
            if ins.mnemonic.startswith("j") and ins.operands and ins.operands[0].type == capstone.x86.X86_OP_IMM:
                t = ins.operands[0].imm
                check(not (rva < t < end) or rva <= ins.address < end,
                      f"lệnh {ins.address:#x} nhảy vào giữa vùng hook {rva:#x}")


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
    k32 = kernel32()
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
        cfg = ctypes.string_at(base + P.PAYLOAD_DATA_RVA, 0x18)
        check(cfg[:5] == b"HVNJ\x03" and not any(cfg[o] for k, o in P.PAYLOAD_CFG.items() if k != "cfg_block"),
              f"cfg trong bộ nhớ {cfg.hex()}")

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
        # cave chạy trong frame host: unwind ở đầu cave và sau mỗi call phải giống unwind tại chỗ hook
        pairs = []
        for start, end, site in B.CHAINED_BLOCKS:
            pairs.append((start, S[start], site))
            insns = disasm(out, S[start], S[end] - S[start])
            pairs += [(f"{start} sau call @{i.address:#x}", insns[k + 1].address, site)
                      for k, i in enumerate(insns) if i.mnemonic == "call"]
        for name, cave_rva, host_rva in pairs:
            fill_stack()
            a = unwind(cave_rva, sbase, regs)
            fill_stack()
            b = unwind(host_rva, sbase, regs)
            check(a is not None and a == b, f"unwind {name}: {a} != {b}")
        # hàm asm có prologue riêng: unwind sau mỗi call phải trả đúng thanh ghi đã lưu và địa chỉ về
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
        print(f"    {len(pairs)} vị trí trong frame host + {n_func} vị trí trong {len(FRAME_FUNCS)} hàm asm, "
              f"{len(P.PAYLOAD_PDATA)} entry .pdata")
    finally:
        k32.FreeLibrary(ctypes.c_void_p(base))
        shutil.rmtree(td, ignore_errors=True)


# ----------------------------------------------------------------------------- 6-9
U64 = ctypes.c_uint64
F = ctypes.CFUNCTYPE


def asm_bytes(parts):
    """Ghép mã máy: parts là list bytes, ('call', nhãn) hoặc ('label', nhãn)."""
    out, fix, labels = bytearray(), [], {}
    for p in parts:
        if isinstance(p, tuple) and p[0] == "label":
            labels[p[1]] = len(out)
        elif isinstance(p, tuple) and p[0] == "call":
            out += b"\xe8\0\0\0\0"
            fix.append((len(out), p[1]))
        else:
            out += p
    for end, lab in fix:
        struct.pack_into("<i", out, end - 4, labels[lab] - end)
    return bytes(out)


# T(rcx = rax vào cave, edx = 0 -> ZF = 1, r8 = cave, r9 = kết quả [rax ra, rsi ra, rsi vào]).
# Gọi một nhãn chỉ chứa "jmp r10" để cave chạy với rsp thẳng hàng 16 như trong hàm game; stub ở đích
# nhảy ghi mã đích rồi "ret" về đây.
GATE_TRAMPOLINE = asm_bytes([
    b"\x56", b"\x57", b"\x48\x83\xec\x30", b"\x48\x89\xc8", b"\x4c\x89\xcf", b"\x48\x8b\x77\x10",
    b"\x4d\x89\xc2", b"\x85\xd2", ("call", "L1"), b"\x48\x89\x07", b"\x48\x89\x77\x08",
    b"\x48\x83\xc4\x30", b"\x5f", b"\x5e", b"\xc3", ("label", "L1"), b"\x41\xff\xe2"])
# T2(rcx = List<iw>, rdx = menuchar_hook): đặt rsi = list như mo.doMenuChar rồi gọi hook.
RSI_TRAMPOLINE = asm_bytes([b"\x56", b"\x48\x83\xec\x20", b"\x48\x89\xce", b"\xff\xd2",
                            b"\x48\x83\xc4\x20", b"\x5e", b"\xc3"])


class CaveSim:
    """Chạy THẬT mã máy của mod trong DLL đã dựng (nạp bằng LoadLibraryEx). Mọi hàm game /
    runtime IL2CPP mà mod gọi được thay bằng callback Python, các con trỏ TypeInfo trỏ tới class
    giả; nhân vật, hành trang, đá, nhiệm vụ, NPC, chuỗi, List<iw>, PlayerPrefs là dữ liệu giả."""
    CRYSTALS = [1, 4, 16, 64, 256, 1024, 4096, 16384, 65536, 262144, 1048576, 4194304]
    FEES = [0, 10, 20, 40, 80, 160, 320, 640, 1280, 2560, 5120, 10240]
    T0 = 13_400_000_000_000          # ms tính từ 1601, cỡ năm 2026

    def __init__(self, k32, dll_bytes, name, crystals=None, fees=None, cfg=None):
        self.k32 = k32
        self.heap = ctypes.create_string_buffer(0x80000)
        self.top = ctypes.addressof(self.heap)
        self.path = os.path.join(tempfile.gettempdir(), f"HvnjSim_{os.getpid()}_{name}.dll")
        open(self.path, "wb").write(dll_bytes)
        self.base = k32.LoadLibraryExW(self.path, None, 0x1)
        assert self.base, f"LoadLibraryEx lỗi {ctypes.get_last_error()}"
        self.exec_mem = None
        self.now = self.T0
        self.sends, self.msgs, self.writers = [], {}, {}
        self.array_news, self.class_inits, self.init_md = [], [], []
        self.dga, self.dgf, self.walks, self.menus = [], [], [], []
        self.lists, self.iws, self.shown, self.prefs, self.djh = {}, {}, [], {}, []
        self.cih = {}                    # jr -> 1: có dòng khảm ngọc / trục luyện
        self.djd = []                    # (mo, loại bảng) đã mở bằng mo.djd
        G = B.GAME_SYMBOLS
        self.cbs = {
            "lm_cua": F(U64, U64)(lambda _mi: self.char),
            "lj_cmy": F(U64, U64)(lambda _mi: self.service),
            "il2cpp_init_md": F(U64, U64)(lambda slot: self.init_md.append(slot - self.base) or 0),
            "il2cpp_class_init": F(U64, U64)(lambda k: self.class_inits.append(k) or 0),
            "il2cpp_object_new": F(U64, U64)(lambda _k: self.alloc(0x60)),
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
            # menu Mod (hvnj_menu.c)
            "il2cpp_string_new_utf16": F(U64, U64, U64)(
                lambda p, n: self.make_str(ctypes.wstring_at(p, n & 0xFFFFFFFF))),
            "prefs_get_string": F(U64, U64, U64)(lambda key, _mi: self.make_str(self.prefs.get(self.read_str(key), ""))),
            "prefs_set_string": F(U64, U64, U64, U64)(
                lambda key, val, _mi: self.prefs.__setitem__(self.read_str(key), self.read_str(val)) or 0),
            "list_iw_ctor": F(U64, U64, U64)(lambda lst, _mi: self.lists.__setitem__(lst, []) or 0),
            "list_iw_add": F(U64, U64, U64, U64)(lambda lst, it, _mi: self.lists[lst].append(it) or 0),
            "iw_ctor_caption": F(U64, U64, U64, U64, U64)(
                lambda it, cap, act, _mi: self.iws.__setitem__(it, (self.read_str(cap), act & 0xFFFFFFFF)) or 0),
            "ms_dkz": F(U64, U64)(lambda _mi: self.ms),
            "ms_dla": F(U64, U64, U64, U64, U64, U64, U64, U64)(
                lambda _ms, lst, *_a: self.shown.append([self.iws[i] for i in self.lists[lst]]) or 0),
            "mo_djh": F(U64, U64, U64, U64, U64)(
                lambda mo, act, p, _mi: self.djh.append((mo, act & 0xFFFFFFFF, p)) or 0),
            # phiên dọn hành trang (hvnj_bag.c)
            "bl_bbb": F(U64, U64, U64, U64)(self._bl_bbb),
            "jr_cih": F(U64, U64, U64)(lambda it, _mi: self.cih.get(it, 0)),
            # "Mở rương đồ" / "Mở nâng cấp trang bị"
            "mo_ddt": F(U64, U64)(lambda _mi: self.mo),
            "mo_djd": F(U64, U64, U64, U64)(lambda mo, ui, _mi: self.djd.append((mo, ui & 0xFFFFFFFF)) or 0),
        }
        self.cb_time = F(None, U64)(lambda p: setattr(U64.from_address(p), "value", self.now * 10000))
        for name_, cb in self.cbs.items():
            stub = b"\x48\xb8" + struct.pack("<Q", ctypes.cast(cb, ctypes.c_void_p).value) + b"\xff\xe0"
            self.poke(self.base + G[name_], stub)
        self.poke(self.base + G["imp_GetSystemTimeAsFileTime"],
                  struct.pack("<Q", ctypes.cast(self.cb_time, ctypes.c_void_p).value))
        # class giả: +133h cờ cctor, +0B8h static fields
        self.statics = {}
        for k in ("ca", "hw", "ek", "mc", "jr_array", "bc", "hs", "mb", "mo", "lm", "list_iw", "iw", "fp"):
            klass = self.alloc(0x140)
            st = self.alloc(0x200)
            self.w64(klass + 0xB8, st)
            self.statics[k] = st
            self.poke(self.base + G[k + "_TypeInfo"], struct.pack("<Q", klass))
            setattr(self, k + "_klass", klass)
        for k in ("list_iw_ctor_mi", "list_iw_add_mi"):
            self.poke(self.base + G[k], struct.pack("<Q", self.alloc(0x20)))
        self.ms = self.alloc(0x40)
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
        self.fn = F(None)(self.base + P.PAYLOAD_SYMBOLS["stone_tick"])
        self.bag_fn = F(ctypes.c_int32, ctypes.c_int64)(self.base + P.PAYLOAD_SYMBOLS["bag_tick"])
        # quest_tick: mo (GameScr), NPC 25 có vtable kk.cit()/ciu() trả toạ độ
        self.mo = self.alloc(0x400)
        self.qfn = F(None, U64)(self.base + P.PAYLOAD_SYMBOLS["quest_tick"])
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
        # cấu hình như khi đã tick trong menu; m_loaded = 1: không đọc PlayerPrefs
        self.set_cfg(m_loaded=1, **(cfg or {}))

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

    def r8(self, a):
        return ctypes.c_uint8.from_address(a).value

    def poke(self, addr, data):
        old = ctypes.c_uint32()
        assert self.k32.VirtualProtect(ctypes.c_void_p(addr), len(data), 0x40, ctypes.byref(old))
        ctypes.memmove(addr, data, len(data))

    def sym(self, name):
        return self.base + P.PAYLOAD_SYMBOLS[name]

    def set_cfg(self, **kv):
        for k, v in kv.items():
            self.poke(self.sym(k), bytes([v & 0xFF]))

    def get_cfg(self, k):
        return self.r8(self.sym(k))

    def make_str(self, s):
        """System.String giả: length ở +10h, ký tự UTF-16 ở +14h."""
        raw = s.encode("utf-16-le")
        a = self.alloc(0x18 + len(raw))
        self.w32(a + 0x10, len(raw) // 2)
        ctypes.memmove(a + 0x14, raw, len(raw))
        return a

    def read_str(self, a):
        if not a:
            return None
        n = ctypes.c_int32.from_address(a + 0x10).value
        return ctypes.wstring_at(a + 0x14, n)

    def code(self, blob):
        """Ghi mã máy vào vùng nhớ RWX riêng (gần DLL để nhảy rel32 tới được), trả về địa chỉ."""
        if not self.exec_mem:
            for k in range(1, 64):
                hint = (self.base + 0x1300000 + k * 0x100000) & ~0xFFFF
                self.exec_mem = self.k32.VirtualAlloc(ctypes.c_void_p(hint), 0x10000, 0x3000, 0x40)
                if self.exec_mem:
                    break
            assert self.exec_mem and abs(self.exec_mem - self.base) < 0x7FF00000
            self.exec_top = self.exec_mem
        a = self.exec_top
        ctypes.memmove(a, blob, len(blob))
        self.exec_top += (len(blob) + 15) & ~15
        return a

    def set_table(self, off, values):
        arr = self.alloc(0x20 + 4 * len(values))
        self.w64(arr + 0x18, len(values))
        for i, v in enumerate(values):
            ctypes.c_int32.from_address(arr + 0x20 + 4 * i).value = v
        self.w64(self.statics["mc"] + off, arr)

    def make_opts(self, n):
        """List<jw> giả: chỉ cần _size (+18h) = số dòng chỉ số."""
        lst = self.alloc(0x20)
        self.w32(lst + 0x18, n)
        return lst

    def make_equip(self, index, id, type, lines, lock=0, up=0, qty=1, name="Đồ", cih=0, sel=0):
        """Trang bị: mẫu (id, loại, tên), lines = số dòng chỉ số (None = chưa có List<jw>)."""
        tpl = self.alloc(0x30)
        self.w16(tpl + 0x10, id)
        self.w8(tpl + 0x12, type)
        self.w64(tpl + 0x18, self.make_str(name))
        it = self.alloc(0x60)
        self.w64(it + 0x10, tpl)
        if lines is not None:
            self.w64(it + 0x18, self.make_opts(lines))
        self.w32(it + 0x28, index)
        self.w32(it + 0x2C, qty)
        self.w8(it + 0x38, lock)
        self.w32(it + 0x40, up)
        self.w8(it + 0x5E, sel)
        if cih:
            self.cih[it] = 1
        return it

    def make_item(self, spec, index):
        """spec: None = ô trống, 'eq' = trang bị, (id, khóa, đang chọn) hoặc id = đá (id 0 = cấp 1),
        dict = trang bị cho phiên bán (tham số của make_equip)."""
        if spec is None:
            return 0
        if isinstance(spec, dict):
            return self.make_equip(index, **spec)
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

    # --- cửa hàng (fp static jr[] theo mã danh sách)
    SHOP_OFF = {2: 0x78, **{t: 0x58 + (t - 16) * 8 for t in range(16, 20)},
                **{t: 0x08 + (t - 20) * 8 for t in range(20, 30)}}

    def set_shop(self, ui, items):
        """Server gửi danh sách hàng mã ui: items = [(mẫu, số dòng hoặc None = chưa xem chi tiết)]."""
        arr = self.alloc(0x20 + 8 * max(len(items), 1))
        self.w64(arr + 0x18, len(items))
        for i, (tid, lines) in enumerate(items):
            it = self.make_equip(i, tid, 0, lines)
            self.w32(it + 0x58, ui)
            self.w64(arr + 0x20 + 8 * i, it)
        self.w64(self.statics["fp"] + self.SHOP_OFF[ui], arr)

    def shop_info(self, ui, index, lines):
        """Server trả chi tiết món thứ index của danh sách ui."""
        arr = ctypes.c_uint64.from_address(self.statics["fp"] + self.SHOP_OFF[ui]).value
        self.w64(self.slot(arr, index) + 0x18, self.make_opts(lines))

    def set_status(self, st):
        ctypes.c_int32.from_address(self.char + 0x5C).value = st

    def btick(self, dt_ms=250):
        """Chạy bag_tick(now) sau dt_ms; trả về (giá trị trả về, packet gửi ra)."""
        self.now += dt_ms
        n = len(self.sends)
        r = self.bag_fn(self.now)
        return r, self.sends[n:]

    # --- callback thay hàm game
    def _bl_bbb(self, writer, value, _mi):
        self.msgs[self.writers[writer]]["idx"].append(("int", value & 0xFFFFFFFF))
        return 0

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

    # --- cave chặn theo cờ
    def install_gate_stubs(self):
        """Đặt stub "ghi mã đích; ret" tại các điểm quay lại trong hàm game."""
        self.marker = self.alloc(0x10)
        self.gate_fn = F(None, U64, U64, U64, U64)(self.code(GATE_TRAMPOLINE))
        for i, name in enumerate(BACK_TARGETS):
            # thunk "mov r11, marker; mov dword [r11], i; ret" + stub 5 byte "jmp thunk" ở điểm quay lại
            # (dgj_skip / dgj_null / dgj_epilogue_tail chỉ cách nhau 7 byte)
            thunk = self.code(b"\x49\xbb" + struct.pack("<Q", self.marker) + b"\x41\xc7\x03" + struct.pack("<I", i)
                              + b"\xc3")
            at = self.base + B.GAME_SYMBOLS[name]
            self.poke(at, b"\xe9" + struct.pack("<i", thunk - (at + 5)))

    def gate(self, cave, rax, zf, rsi=0):
        """Chạy cave với rax, cờ ZF; trả về (tên đích nhảy tới, rax ra, rsi ra)."""
        res = self.alloc(0x20)
        self.w64(res + 0x10, rsi)
        self.w32(self.marker, 0xFFFFFFFF)
        self.gate_fn(rax, 0 if zf else 1, self.sym(cave), res)
        i = ctypes.c_uint32.from_address(self.marker).value
        return (BACK_TARGETS[i] if i < len(BACK_TARGETS) else None,
                ctypes.c_uint64.from_address(res).value, ctypes.c_uint64.from_address(res + 8).value)

    # --- menu Mod
    def action(self, act, p=0):
        F(None, U64, U64, U64, U64)(self.sym("action_hook"))(self.mo, act, p, 0)

    def menuchar(self, lst):
        fn = F(U64, U64, U64)(self.code(RSI_TRAMPOLINE))
        return fn(lst, self.sym("menuchar_hook"))

    def close(self):
        self.k32.FreeLibrary(ctypes.c_void_p(self.base))
        if self.exec_mem:
            self.k32.VirtualFree(ctypes.c_void_p(self.exec_mem), 0, 0x8000)
        try:
            os.remove(self.path)
        except OSError:
            pass


def test_gates(orig, out):
    print("[6] Chạy thật các cave chặn theo cờ: tắt = lệnh gốc, bật = hành vi mod")
    if os.name != "nt":
        print("    bỏ qua (không phải Windows)")
        return
    s = CaveSim(kernel32(), out, "gates")
    n = 0
    try:
        s.install_gate_stubs()
        lm_klass = s.lm_klass
        mo_klass = s.mo_klass

        def expect(cave, rax, zf, cfg, want, extra=None, msg=""):
            nonlocal n
            n += 1
            s.set_cfg(cfg_mob=0, cfg_stage=0, cfg_die=0, cfg_trial=0)
            s.set_cfg(**cfg)
            got = s.gate(cave, rax, zf, rsi=0x5151)
            ok = got[0] == want and (extra is None or extra(got))
            check(ok, f"{cave} {msg} cfg={cfg} ZF={int(zf)}: -> {got[0]} (mong đợi {want})")

        obj = s.alloc(0x200)
        for cave, back, off, size, normal, fast in (
                ("ctq_cd1", "ctq_cd1_back", 0x152, 1, 15, 1), ("ctq_cd2", "ctq_cd2_back", 0x152, 1, 15, 1),
                ("cdy_dlg", "cdy_back", 0x3C, 4, 500, 2), ("cdq_dlg", "cdq_back", 0x40, 4, 500, 2)):
            def val(o=off, sz=size):
                return ctypes.c_uint8.from_address(obj + o).value if sz == 1 else ctypes.c_uint32.from_address(obj + o).value
            expect(cave, obj, False, {}, back, lambda _g, v=val, w=normal: v() == w, "chết tắt: giữ giá trị gốc")
            expect(cave, obj, False, {"cfg_die": 1}, back, lambda _g, v=val, w=fast: v() == w, "chết bật: rút ngắn")
        for zf, cfg, want in ((False, {}, "dek_keep_auto"), (True, {}, "dek_back"),
                              (True, {"cfg_trial": 1}, "dek_keep_auto"), (False, {"cfg_trial": 1}, "dek_keep_auto")):
            expect("dek_trial", obj, zf, cfg, want,
                   (lambda g: g[1] == mo_klass) if want == "dek_back" else None, "mo.dek map 161")
        for zf, cfg, want in ((False, {}, "bld_back"), (True, {}, "bld_block"),
                              (True, {"cfg_trial": 1}, "bld_back")):
            expect("bld_trial", obj, zf, cfg, want, None, "eq.bld map 161")
        for zf, cfg, want in ((False, {}, "dgj_core1_back"), (True, {}, "dgj_null"),
                              (True, {"cfg_mob": 1}, "dgj_core1_back"), (True, {"cfg_stage": 1}, "dgj_core1_back")):
            expect("dgj_core1", obj, zf, cfg, want, None, "mo.dgj không có nhiệm vụ chính")
        s.w32(obj + 0x78, 0x1234)
        expect("dgj_core2", obj, False, {}, "dgj_core2_back", lambda g: g[1] == lm_klass and g[2] == 0x1234,
               "tắt: chạy lại 2 lệnh gốc")
        expect("dgj_core2", obj, False, {"cfg_stage": 1}, "dgj_core2_skip", lambda g: g[2] == 0x5151,
               "bật: bỏ kiểm tra quái nhiệm vụ chính")
        # bộ lọc quái
        mob, boss, tathu = s.alloc(0x100), s.alloc(0x100), s.alloc(0x100)
        s.w32(mob + 0x78, 7)
        s.w32(boss + 0x78, 8)
        s.w8(boss + 0xB4, 1)
        s.w32(tathu + 0x78, 50)
        ctypes.c_uint16.from_address(tathu + 0xB0).value = 2
        s.set_tasks([(1, 0, 1, 50, 30)])
        for cave, acc, skip in (("dgj_filter", "dgj_accept", "dgj_skip"), ("dgl_filter", "dgl_accept", "dgl_skip")):
            expect(cave, boss, False, {}, acc, None, "tắt --mob: đánh cả boss")
            expect(cave, mob, False, {"cfg_mob": 1}, acc, None, "quái thường")
            expect(cave, boss, False, {"cfg_mob": 1}, skip, None, "boss")
            expect(cave, tathu, False, {"cfg_mob": 1}, acc, None, "con tà thú của nhiệm vụ")
        s.set_map(163)
        expect("dgj_filter", boss, False, {"cfg_mob": 1, "cfg_stage": 1}, "dgj_accept", None, "Thí Luyện: đánh hết")
        expect("dgj_filter", boss, False, {"cfg_mob": 1}, "dgj_skip", None, "Thí Luyện, tắt tự qua ải")
    finally:
        s.close()
    print(f"    {n} tình huống")


def test_menu(orig, out):
    print("[7] Chạy thật menu \"Mod HVNJ\" (hvnj_menu.c)")
    if os.name != "nt":
        print("    bỏ qua (không phải Windows)")
        return
    s = CaveSim(kernel32(), out, "menu")
    NT = len(CFG_TOGGLES)
    STONE_LINES = NT + 1                # chỉ số dòng "Luyện đá lên cấp" (sau các tick + dòng Xem trước)
    try:
        def state():
            return [s.get_cfg(k) for k in CFG_TOGGLES]

        def pref(t, accept=0, lo=0, hi=0):
            return "5" + "".join("1" if x else "0" for x in t) + chr(97 + accept) + chr(97 + lo) + chr(97 + hi)

        def pref4(t8, accept=0, lo=0, hi=0):
            """Chuỗi của bản trước: 8 tick, luyện đá ở vị trí 7, chưa có bán trang bị."""
            return "4" + "".join("1" if x else "0" for x in t8) + chr(97 + accept) + chr(97 + lo) + chr(97 + hi)

        def menu_ok(menu, t, accept=0, lo=0, hi=0):
            want = []
            for i, on in enumerate(t):
                want.append((("[x] " if on else "[   ] ") + TOGGLE_NAMES[i], ACT + 1 + i))
                if i == T_SELL:
                    want.append((PREVIEW_LINE, ACT_PREVIEW))
            if hi:
                want += [(f"Luyện đá lên cấp: {hi} (cất vào rương)", ACT + 10), (f"Luyện đá từ cấp: {lo}", ACT + 11)]
            else:
                want += [("Luyện đá lên cấp: mọi cấp, không cất rương", ACT + 10)]
            want += [(f"Option nhận nhiệm vụ ở NPC: {accept}", ACT + 12), ("Mở rương đồ", ACT_OPEN_BOX),
                     ("Mở nâng cấp trang bị", ACT_OPEN_UP), ("Đóng", ACT + 13)]
            return menu == want

        # dòng "Mod HVNJ" trong menu nhân vật
        lst = s.alloc(0x40)
        s.lists[lst] = []
        ret = s.menuchar(lst)
        check(ret == s.ms and [s.iws[i] for i in s.lists[lst]] == [("Mod HVNJ", ACT)],
              f"menu nhân vật phải có thêm dòng Mod HVNJ và trả về ms.dkz(): {[s.iws.get(i) for i in s.lists[lst]]}")
        # mở menu: mặc định tắt hết, chưa lưu gì
        s.action(ACT)
        check(len(s.shown) == 1 and menu_ok(s.shown[-1], [0] * NT) and not s.prefs,
              f"mở menu: {s.shown[-1] if s.shown else None} {s.prefs}")
        # tick từng dòng
        check(not any("xu" in c.split() for c, _a in s.shown[-1]), "menu không còn dòng trả bằng xu")
        t = [0] * NT
        for i in range(NT):
            s.action(ACT + 1 + i)
            t[i] = 1
            check(state() == t and s.prefs.get("HVNJ_MOD") == pref(t) and menu_ok(s.shown[-1], t),
                  f"tick dòng {i + 1}: cfg {state()} prefs {s.prefs.get('HVNJ_MOD')} menu {s.shown[-1]}")
        s.action(ACT + 1)
        t[0] = 0
        check(state() == t and s.prefs["HVNJ_MOD"] == pref(t), "bỏ tick dòng 1")
        # bỏ tick thì xoá trạng thái dở dang
        s.set_cfg(q_engaged=1, r_pending=1, s_active=1, p_active=1, sl_state=1)
        for i in (1, 4, 6, T_SELL, CFG_TOGGLES.index("cfg_stone")):
            s.action(ACT + 1 + i)
            s.action(ACT + 1 + i)
        check([s.get_cfg(k) for k in ("q_engaged", "r_pending", "s_active", "p_active", "sl_state")] == [0] * 5,
              "tick / bỏ tick xoá trạng thái đang chạy của tính năng")
        # cấp đá: mọi cấp -> 2 .. 12 -> mọi cấp; từ cấp vòng 1 .. cấp đích - 1
        for _ in range(5):
            s.action(ACT + 10)
        check((s.get_cfg("cfg_stone_lo"), s.get_cfg("cfg_stone_hi")) == (1, 6) and menu_ok(s.shown[-1], t, 0, 1, 6),
              f"lên cấp 6: {s.shown[-1][STONE_LINES:]}")
        s.action(ACT + 11)
        s.action(ACT + 11)
        check(s.get_cfg("cfg_stone_lo") == 3 and s.prefs["HVNJ_MOD"] == pref(t, 0, 3, 6), "từ cấp 3")
        for _ in range(3):
            s.action(ACT + 11)
        check(s.get_cfg("cfg_stone_lo") == 1, "từ cấp quay vòng về 1 (phải < cấp đích)")
        for _ in range(6):
            s.action(ACT + 10)
        check(s.get_cfg("cfg_stone_hi") == 12, "tới cấp 12")
        s.action(ACT + 10)
        check((s.get_cfg("cfg_stone_lo"), s.get_cfg("cfg_stone_hi")) == (0, 0) and menu_ok(s.shown[-1], t),
              "sau cấp 12 về mọi cấp")
        for _ in range(5):
            s.action(ACT + 12)
        check(s.get_cfg("cfg_accept") == 1 and menu_ok(s.shown[-1], t, 1), "option nhận nhiệm vụ vòng 0..3")
        saved = s.prefs["HVNJ_MOD"]
        n_shown = len(s.shown)
        s.action(ACT + 13)
        check(len(s.shown) == n_shown and s.prefs["HVNJ_MOD"] == saved, "Đóng: không mở lại, không lưu")
        # Xem trước: mở menu thứ hai (chưa vào game / hành trang trống), không lưu gì
        s.action(ACT_PREVIEW)
        pv = s.shown[-1]
        check(len(s.shown) == n_shown + 1 and s.prefs["HVNJ_MOD"] == saved
              and pv[0] == ("Bán: 0, cất rương: 0 / 0 món (bấm để xem lại)", ACT_PREVIEW)
              and pv[-2:] == [("Quay lại", ACT), ("Đóng", ACT + 13)], f"Xem trước: {pv}")
        s.action(ACT)
        check(menu_ok(s.shown[-1], t, 1), "Quay lại: về menu Mod")
        # mở rương đồ / nâng cấp trang bị ở bất kỳ map nào: mo.djd(GameScr, 4 / 10), không mở lại menu
        n_shown = len(s.shown)
        s.set_map(55)
        s.action(ACT_OPEN_BOX)
        s.action(ACT_OPEN_UP)
        check(s.djd == [(s.mo, 4), (s.mo, 10)] and len(s.shown) == n_shown and s.prefs["HVNJ_MOD"] == saved,
              f"mở rương đồ = mo.djd(4), nâng cấp = mo.djd(10): {s.djd}")
        # lệnh của game vẫn tới mo.djh nguyên tham số
        s.action(1007, p=0x77)
        s.action(ACT + 32, p=0x78)
        check(s.djh == [(s.mo, 1007, 0x77), (s.mo, ACT + 32, 0x78)] and len(s.shown) == n_shown,
              f"lệnh của game chuyển nguyên cho mo.djh: {s.djh}")
        # đọc lại PlayerPrefs khi vào game
        load = F(None)(s.sym("mod_cfg_load"))
        want = [1, 0, 1, 0, 1, 0, 1, 1, 1]
        s.prefs["HVNJ_MOD"] = pref(want, 2, 3, 7)
        s.set_cfg(m_loaded=0, **{k: 0 for k in CFG_TOGGLES})
        load()
        check(state() == want and s.get_cfg("m_loaded") == 1
              and [s.get_cfg(k) for k in ("cfg_accept", "cfg_stone_lo", "cfg_stone_hi")] == [2, 3, 7],
              f"đọc PlayerPrefs: {state()}")
        # chuỗi "4..." của bản trước: 8 tick, luyện đá ở vị trí 7 -> chuyển sang vị trí mới, chưa bật bán
        s.prefs["HVNJ_MOD"] = pref4([1, 0, 1, 0, 1, 0, 1, 1], 1, 2, 5)
        s.set_cfg(**{k: 0 for k in CFG_TOGGLES})
        load()
        check(state() == [1, 0, 1, 0, 1, 0, 1, 0, 1]
              and [s.get_cfg(k) for k in ("cfg_accept", "cfg_stone_lo", "cfg_stone_hi")] == [1, 2, 5],
              f"đọc chuỗi '4' của bản trước: {state()}")
        # "3..." = chuỗi của bản có dòng "trả bằng xu": bỏ qua
        for bad in ("3" + pref4([1] * 8)[1:] + "a", pref([1] * NT)[:-1], "", pref([1] * NT, 0, 5, 1)):
            s.prefs["HVNJ_MOD"] = bad
            s.set_cfg(**{k: 0 for k in CFG_TOGGLES}, cfg_stone_lo=4, cfg_stone_hi=9)
            load()
            if bad.startswith("5") and len(bad) == NT + 4:
                check(state() == [1] * NT and (s.get_cfg("cfg_stone_lo"), s.get_cfg("cfg_stone_hi")) == (4, 9),
                      f"cấp đá sai trong PlayerPrefs phải bị bỏ qua: {bad}")
            else:
                check(state() == [0] * NT, f"chuỗi PlayerPrefs sai phải bị bỏ qua: {bad!r}")
        # quest_tick tự đọc PlayerPrefs ở frame đầu tiên
        want = [0, 0, 0, 0, 0, 1, 0, 0, 0]
        s.prefs["HVNJ_MOD"] = pref(want)
        s.set_cfg(m_loaded=0, **{k: 0 for k in CFG_TOGGLES})
        s.qtick(1000)
        check(s.get_cfg("m_loaded") == 1 and state() == want, "quest_tick đọc PlayerPrefs")
    finally:
        s.close()


def test_stone_logic(orig):
    print("[8] Chạy thật stone_tick với nhân vật / hành trang giả")
    if os.name != "nt":
        print("    bỏ qua (không phải Windows)")
        return
    k32 = kernel32()
    out = P.build(orig)
    TOO_MUCH = 2**31 - 1        # bảng phí là int32; nhân vật giả có 10^9 yên
    n_cases = 0

    def sim(name, levels=(0, 0), **kw):
        nonlocal n_cases
        n_cases += 1
        cfg = dict(cfg_stone=1, cfg_stone_lo=levels[0], cfg_stone_hi=levels[1])
        return CaveSim(k32, out, name, cfg=cfg, **kw)

    def one(sends, cmd, idx, msg):
        ok = len(sends) == 1 and sends[0]["cmd"] == cmd and sends[0]["idx"] == idx
        return check(ok, f"{msg}: {[(s['cmd'], s['idx']) for s in sends]} (mong đợi cmd {cmd} {idx})")

    s = sim("stone_off")
    try:
        s.set_cfg(cfg_stone=0)
        s.set_bag([0, 0, 0, 0, None])
        s.qtick(1000)
        check(not s.sends, "chưa tick luyện đá: quest_tick không luyện")
        s.set_cfg(cfg_stone=1)
        s.qtick(1000)
        check(len(s.sends) == 1, "tick luyện đá: quest_tick gọi stone_tick")
    finally:
        s.close()

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
            ("poor", lambda s: (s.w64(s.char + 0x140, 0), s.w64(s.char + 0x150, 9))),
            ("rich_xu", lambda s: (s.w64(s.char + 0x140, 10**9), s.w64(s.char + 0x150, 9)))):
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
        s.w64(s.char + 0x140, 0)
        s.w64(s.char + 0x150, 10)
        one(s.tick(), 20, [0, 1, 2, 3], "riêng yên vừa đủ phí (không có xu), popup khác không cản")
    finally:
        s.close()

    # 3. chỉ trả bằng yên (cmd 20), không bao giờ cmd 19 (xu); đá khóa / không khóa gộp chung
    s = sim("yen_mixed_lock")
    try:
        s.set_bag([0, (0, 1, 0), 0, (0, 1, 0), None])
        one(s.tick(), 20, [0, 1, 2, 3], "đá khóa + không khóa luyện chung bằng yên")
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


def pk(send):
    """Packet gửi ra -> (cmd có dấu, [byte & 0xFF | ('int', v)])."""
    cmd = send["cmd"] - 256 if send["cmd"] >= 128 else send["cmd"]
    return cmd, [v if isinstance(v, tuple) else v & 0xFF for v in send["idx"]]


def test_sell_logic(orig):
    print("[9] Chạy thật phiên dọn hành trang (bán đồ thiếu dòng / cất đồ đủ dòng -> luyện đá) với shop / server giả")
    if os.name != "nt":
        print("    bỏ qua (không phải Windows)")
        return
    k32 = kernel32()
    out = P.build(orig)
    n_cases = 0
    LIST = lambda ui: (-30, [0x99, ui])                         # noqa: E731 - như bấm thẻ cửa hàng
    INFO = lambda ui, i: (42, [ui, i])                           # noqa: E731 - như bấm vào món trong shop
    SELL = lambda slot, n=1: (14, [slot, ("int", n)])            # noqa: E731
    BOX = lambda slot: (17, [slot])                              # noqa: E731 - như lj.itemBagToBox
    AO = dict(id=100, type=2, lines=2, name="Áo vải")            # shop bán áo 100 có 4 dòng

    def sim(name, **cfg):
        nonlocal n_cases
        n_cases += 1
        return CaveSim(k32, out, "sell_" + name, cfg=dict({"cfg_sell": 1}, **cfg))

    def i32(s, name):
        return ctypes.c_int32.from_address(s.sym(name)).value

    def nxt(s, max_ms=6000):
        """Chạy bag_tick tới khi có packet (tối đa max_ms); trả về packet hoặc None."""
        for _ in range(max_ms // 250):
            sends = s.btick(250)[1]
            if sends:
                check(len(sends) == 1, f"mỗi lần chỉ được gửi 1 lệnh: {[pk(x) for x in sends]}")
                return pk(sends[0])
        return None

    def run(s, ms, dt=250):
        got = []
        for _ in range(ms // dt):
            got += [pk(x) for x in s.btick(dt)[1]]
        return got

    # 1. đủ quy trình: tải danh sách shop -> xem chi tiết món -> bán, nhớ số dòng vào PlayerPrefs
    s = sim("flow")
    try:
        s.set_bag([AO, 5, 5, 5, 5, None])
        check(nxt(s) == LIST(22), "áo (loại 2): tải danh sách trang phục nam (22) trước")
        check(run(s, 2000) == [], "chưa có danh sách: chờ server, không gửi thêm")
        s.set_shop(22, [(101, None), (100, None)])
        check(nxt(s) == INFO(22, 1), "có danh sách: xem chi tiết đúng món cùng mẫu trong shop")
        s.shop_info(22, 1, 4)
        p = nxt(s)
        check(p == SELL(0), f"áo 2 dòng < shop 4 dòng: bán ô 0 ({p})")
        check(s.prefs.get("HVNJ_SHOP") == "1100:4;", f"nhớ số dòng shop: {s.prefs.get('HVNJ_SHOP')}")
        check(run(s, 2000) == [] and s.get_cfg("sl_state") == 1, "chờ server bán xong mới làm tiếp")
        s.set_slot(0, None)
        rest = run(s, 3000)
        check(rest == [] and s.get_cfg("sl_state") == 0 and i32(s, "sl_sold") == 1,
              f"bán xong, hết món: kết thúc phiên ({rest}, đã bán {i32(s, 'sl_sold')})")
    finally:
        s.close()

    # 2. chỉ bán đúng món thiếu dòng; giữ mọi món còn lại
    s = sim("keep")
    try:
        s.prefs["HVNJ_SHOP"] = "1100:4;"
        s.set_shop(22, [(100, 4)])
        s.set_shop(23, [(200, 3)])
        keep = [dict(AO, lines=4), dict(AO, lines=5), dict(AO, lines=1, up=1), dict(AO, lines=1, lock=1),
                dict(AO, lines=1, cih=1), dict(AO, lines=1, sel=1), dict(AO, lines=None), 3,
                dict(AO, type=11, lines=1), dict(AO, type=16, lines=1), dict(AO, id=999, lines=1)]
        s.set_bag(keep + [dict(AO, lines=3), None])
        check(nxt(s) == SELL(len(keep)), "chỉ bán áo 3 dòng; giữ đủ dòng, nhiều dòng hơn, đã nâng cấp, khóa, "
                                         "khảm ngọc, đang chọn, chưa có dòng, đá, loại khác, mẫu không có trong shop")
        s.set_slot(len(keep), None)
        check(run(s, 5000) == [] and s.get_cfg("sl_state") == 0, "không bán thêm món nào")
    finally:
        s.close()

    # 3. vũ khí (danh sách 2) và trang sức (nhẫn loại 5 -> danh sách 17)
    s = sim("weapon_ring")
    try:
        s.set_bag([dict(id=300, type=1, lines=1, name="Kiếm"), dict(id=400, type=5, lines=1, name="Nhẫn"), None])
        check(nxt(s) == LIST(2), "vũ khí: danh sách 2")
        s.set_shop(2, [(300, 3)])
        check(nxt(s) == SELL(0), "kiếm 1 dòng < 3: bán (chi tiết đã có thì khỏi xem lại)")
        s.set_slot(0, None)
        check(nxt(s) == LIST(17), "nhẫn: danh sách trang sức 17")
        s.set_shop(17, [(400, 2)])
        check(nxt(s) == SELL(1), "nhẫn 1 dòng < 2: bán")
    finally:
        s.close()

    # 4. trang phục nữ: không có trong danh sách nam (24) thì tải danh sách nữ (25)
    s = sim("female")
    try:
        s.set_bag([dict(id=500, type=4, lines=1, name="Găng"), None])
        check(nxt(s) == LIST(24), "găng: danh sách nam 24")
        s.set_shop(24, [(501, 2)])
        check(nxt(s) == LIST(25), "không có ở danh sách nam -> danh sách nữ 25")
        s.set_shop(25, [(500, 3)])
        check(nxt(s) == SELL(0), "găng nữ 1 dòng < 3: bán")
    finally:
        s.close()

    # 5. server không trả danh sách: không xin lại danh sách đó trong 5 phút
    s = sim("list_timeout")
    try:
        s.set_bag([AO, None])
        got = run(s, 4 * 60_000, 1000)
        check(got == [LIST(22), LIST(23)], f"danh sách không về: mỗi danh sách chỉ xin 1 lần trong 4 phút ({got})")
        got = run(s, 2 * 60_000, 1000)
        check(got[:2] == [LIST(22), LIST(23)], f"5 phút sau xin lại ({got})")
    finally:
        s.close()

    # 6. server không bán: thử lại khi hết hạn chờ 3s, 3 lần liên tiếp thì nghỉ 5 phút
    s = sim("sell_timeout")
    try:
        s.prefs["HVNJ_SHOP"] = "1100:4;"
        s.set_bag([AO, None])
        got = run(s, 60_000)
        check(got == [SELL(0)] * 3, f"bán không được: thử 3 lần rồi nghỉ ({got})")
        check(run(s, 3 * 60_000, 1000) == [], "đang nghỉ 5 phút: không gửi gì")
        got = run(s, 2 * 60_000, 1000)
        check(got[:1] == [SELL(0)], f"hết 5 phút: thử lại ({got})")
    finally:
        s.close()

    # 7. không chạy khi: chưa tick, Auto tắt, hành trang chưa đầy, nhân vật chết
    for name, setup in (("off", lambda s: s.set_cfg(cfg_sell=0)), ("auto_off", lambda s: s.set_auto(False)),
                        ("not_full", lambda s: s.set_bag([AO, None, None])), ("dead", lambda s: s.set_status(14))):
        s = sim(name)
        try:
            s.prefs["HVNJ_SHOP"] = "1100:4;"
            s.set_bag([AO, None])
            setup(s)
            r, got = 0, []
            for _ in range(40):
                r2, sends = s.btick(250)
                r |= r2
                got += sends
            check(not got and not r, f"{name}: không bán, không chiếm lượt ({[pk(x) for x in got]}, {r})")
        finally:
            s.close()

    # 8. chuỗi HVNJ_SHOP sai bị bỏ qua (coi như chưa biết số dòng -> xin danh sách)
    s = sim("bad_cache")
    try:
        s.prefs["HVNJ_SHOP"] = "2100:4;"
        s.set_bag([AO, None])
        check(nxt(s) == LIST(22), "chuỗi lưu sai phiên bản: bỏ qua")
    finally:
        s.close()

    # 9. thứ tự: bán xong mới luyện đá (luyện ngay cả khi bán đã làm trống chỗ), không xen kẽ
    s = sim("then_stone", cfg_stone=1)
    try:
        s.prefs["HVNJ_SHOP"] = "1100:4;"
        s.set_bag([AO, 0, 0, 0, 0, None])
        busy, cmds = [], []
        for _ in range(8):
            r, sends = s.btick(250)
            busy.append(r)
            cmds += [pk(x)[0] for x in sends]
        check(cmds == [14] and all(busy), f"bán trước, chưa luyện khi chưa bán xong ({cmds}, {busy})")
        s.set_slot(0, None)
        for _ in range(12):
            cmds += [pk(x)[0] for x in s.btick(250)[1]]
        check(cmds == [14, 20], f"bán xong -> luyện đá ngay: {cmds}")
        check(s.btick(250)[0] == 1, "đang luyện đá: phiên dọn hành trang vẫn bận")
    finally:
        s.close()

    # 10. chưa tick bán: luyện đá chạy như cũ qua bag_tick
    s = sim("stone_only", cfg_sell=0, cfg_stone=1)
    try:
        s.set_bag([0, 0, 0, 0, None])
        got = [pk(x) for x in s.btick(1000)[1]]
        check(got == [(20, [0, 1, 2, 3])], f"chỉ luyện đá: {got}")
    finally:
        s.close()

    # 11. đang dọn hành trang thì auto nhiệm vụ tạm dừng, xong thì chạy tiếp
    s = sim("quest_pause", cfg_quest=1)
    try:
        s.prefs["HVNJ_SHOP"] = "1100:4;"
        s.set_bag([AO, None])
        _d, menus, _f = s.engage()
        menus += s.qtick(500)[1]
        check(not menus and [pk(x) for x in s.sends] == [SELL(0)], f"đang bán: chưa nhận nhiệm vụ ({menus})")
        s.set_slot(0, None)
        for _ in range(4):
            menus += s.qtick(500)[1]
        check(menus == [(25, 0, 0)], f"bán xong: auto nhiệm vụ chạy tiếp ({menus})")
    finally:
        s.close()

    # 12. Xem trước (menu): Auto tắt, chưa tick, hành trang chưa đầy -> chỉ lấy số dòng, không bán
    s = sim("preview", cfg_sell=0)
    try:
        s.set_auto(False)
        s.set_bag([AO, dict(AO, id=101, lines=4, name="Áo da"), None, None])
        s.action(ACT_PREVIEW)
        pv = [c for c, _a in s.shown[-1]]
        check(pv[:4] == ["Bán: 0, cất rương: 0 / 2 món (bấm để xem lại)", "Đang lấy số dòng từ shop...",
                         "Áo vải: 2 dòng, chưa biết số dòng shop, giữ", "Áo da: 4 dòng, chưa biết số dòng shop, giữ"],
              f"xem trước lúc chưa biết: {pv}")
        check(nxt(s) == LIST(22), "xem trước: tải danh sách")
        s.set_shop(22, [(100, None), (101, 3)])
        check(nxt(s) == INFO(22, 0), "xem trước: xem chi tiết món chưa biết")
        s.shop_info(22, 0, 4)
        check(run(s, 5000) == [] and s.get_cfg("sl_state") == 0, "xem trước: không bán gì, xong thì dừng")
        s.action(ACT_PREVIEW)
        pv = [c for c, _a in s.shown[-1]]
        check(pv[:3] == ["Bán: 1, cất rương: 0 / 2 món (bấm để xem lại)", "Áo vải: 2/4 dòng -> bán",
                         "Áo da: 4/3 dòng, giữ (mở rương 1 lần để cất)"], f"xem trước khi đã biết: {pv}")
        s.set_box([None])
        s.action(ACT_PREVIEW)
        pv = [c for c, _a in s.shown[-1]]
        check(pv[0] == "Bán: 1, cất rương: 1 / 2 món (bấm để xem lại)" and pv[2] == "Áo da: 4/3 dòng -> cất rương",
              f"xem trước khi rương còn chỗ: {pv}")
        s.set_box([3])
        s.action(ACT_PREVIEW)
        pv = [c for c, _a in s.shown[-1]]
        check(pv[2] == "Áo da: 4/3 dòng, giữ (rương đầy)", f"xem trước khi rương đầy: {pv}")
    finally:
        s.close()

    # 13. đồ đủ dòng: cất vào rương tới khi rương đầy (xen với bán theo thứ tự trong hành trang)
    s = sim("store")
    try:
        s.prefs["HVNJ_SHOP"] = "1100:4;"
        s.set_box([3, None, None])
        s.set_bag([dict(AO, lines=4), AO, dict(AO, lines=5), dict(AO, lines=4), None])
        check(nxt(s) == BOX(0), "áo 4 dòng = shop: cất rương (cmd 17)")
        s.server_to_box(0)
        check(nxt(s) == SELL(1), "áo 2 dòng: bán")
        s.set_slot(1, None)
        check(nxt(s) == BOX(2), "áo 5 dòng: cất rương")
        s.server_to_box(2)
        rest = run(s, 5000)
        check(rest == [] and s.get_cfg("sl_state") == 0 and (i32(s, "sl_sold"), i32(s, "sl_stored")) == (1, 2),
              f"rương đầy: món đủ dòng còn lại giữ trong hành trang ({rest})")
    finally:
        s.close()

    # 14. server không cho cất rương: thôi cất 30 phút nhưng vẫn bán
    s = sim("box_refused")
    try:
        s.prefs["HVNJ_SHOP"] = "1100:4;"
        s.set_box([None, None])
        s.set_bag([dict(AO, lines=4), AO, None])
        got = run(s, 6000)
        check(got == [BOX(0), SELL(1)], f"cất không được -> chuyển sang bán ngay ({got})")
        s.set_slot(1, None)
        s.set_bag([dict(AO, lines=4), AO, None])
        got = run(s, 10 * 60_000, 1000)
        check(BOX(0) not in got and got[:1] == [SELL(1)], f"30 phút không thử cất lại, vẫn bán ({got[:3]})")
    finally:
        s.close()
    print(f"    {n_cases} tình huống")


def test_quest_logic(orig):
    print("[10] Chạy thật quest_tick (nhiệm vụ ngày + tà thú) với NPC / nhiệm vụ giả")
    if os.name != "nt":
        print("    bỏ qua (không phải Windows)")
        return
    k32 = kernel32()
    out = P.build(orig)
    n_cases = 0
    DAILY, TATHU = 0, 1

    def sim(name, feats):
        nonlocal n_cases
        n_cases += 1
        return CaveSim(k32, out, "q_" + name, cfg={"cfg_" + f: 1 for f in feats})

    s = sim("all_off", [])
    try:
        _d, menus, dgf = s.engage()
        check(not menus and not dgf and not s.dga, "chưa tick nhiệm vụ: không làm gì")
    finally:
        s.close()

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


# ----------------------------------------------------------------------------- 10
def test_cli(orig, legacy_path):
    print("[11] CLI trên bản sao")
    td = tempfile.mkdtemp()
    dll = os.path.join(td, "GameAssembly.dll")
    script = os.path.join(ROOT, "patch_skill_delay.py")
    v3 = P.build(orig)

    def run(*a):
        r = subprocess.run([sys.executable, script, "--dll", dll, *a], capture_output=True, text=True, encoding="utf-8")
        return r.returncode, r.stdout + r.stderr

    def cur():
        return open(dll, "rb").read()

    try:
        src = open(legacy_path, "rb").read() if legacy_path else legacy_build(orig, list(P.LEGACY_PATCHES))
        open(dll, "wb").write(src)
        rc, txt = run("--status")
        check(rc == 0 and P.KIND_V1 in txt and "--install" in txt, f"--status trên v1: {txt}")
        rc, txt = run("--mob")
        check(rc == 0 and "không còn tác dụng" in txt and cur() == v3, f"lệnh cũ --mob trên v1 -> cài bản menu: {txt}")
        check(sha(open(dll + ".bak", "rb").read()) == P.ORIGINAL_SHA256, ".bak là bản gốc")
        # DLL còn 0.3s, không có .bak -> --status cảnh báo, --skill không ghi file, --install gỡ
        os.remove(dll + ".bak")
        open(dll, "wb").write(with_retired_skill(v3))
        rc, txt = run("--status")
        check(rc == 0 and "0.3s" in txt, f"--status cảnh báo 0.3s cũ: {txt}")
        rc, txt = run("--skill")
        check(rc == 0 and "đã bị gỡ" in txt and P.detect_retired(cur()) == {"skill"},
              f"--skill chỉ báo đã gỡ, không ghi file: {txt}")
        rc, txt = run("--install")
        check(rc == 0 and cur() == v3 and "Mod HVNJ" in txt, f"--install gỡ 0.3s: {txt}")
        rc, txt = run("--remove", "quest")
        check(rc == 0 and "không còn tác dụng" in txt and cur() == v3, f"--remove chỉ báo, không ghi: {txt}")
        rc, txt = run("--stone-levels", "1-3", "--stone-pay", "xu", "--accept-option", "1")
        check(rc == 0 and "không còn tác dụng" in txt and cur() == v3, f"tùy chọn cũ: {txt}")
        rc, txt = run("--status")
        check(rc == 0 and P.KIND_V3 in txt and all(n in txt for n in P.MENU_ITEMS[:8]), f"--status: {txt}")
        rc, txt = run()
        check(rc == 0 and "--install" in txt and cur() == v3, "không tham số: in hướng dẫn")
        rc, txt = run("--restore")
        check(rc == 0 and sha(cur()) == P.ORIGINAL_SHA256, f"--restore: {txt}")
        rc, txt = run("--status")
        check(rc == 0 and P.KIND_ORIGINAL in txt, f"--status bản gốc: {txt}")
        open(dll + ".bak", "wb").write(b"rac")
        rc, txt = run("--all")
        check(rc == 0 and os.path.exists(dll + ".bak.khong-phai-ban-goc") and cur() == v3,
              f".bak hỏng được giữ lại: {txt}")
        check(sha(open(dll + ".bak", "rb").read()) == P.ORIGINAL_SHA256, ".bak mới là bản gốc")
    finally:
        shutil.rmtree(td, ignore_errors=True)


def test_old_payload(paths):
    """DLL v2 (chọn tính năng bằng script) hoặc bản menu v3 dựng trước đó -> nhận diện, khôi phục,
    nâng cấp lên bản menu hiện tại."""
    print("[12] Nâng cấp từ DLL cũ (v2 / v3 trước)")
    for old_path in paths:
        old = open(old_path, "rb").read()
        kind, on = P.detect(old)
        print(f"    {os.path.basename(old_path)}: {kind}, {sorted(on)}")
        check((kind == P.KIND_V2 and on) or (kind == P.KIND_V3 and not on),
              f"{old_path}: phải nhận ra bản v2 (kèm tính năng) hoặc bản v3")
        check(sha(P.strip_payload(old)) == P.ORIGINAL_SHA256, f"{old_path}: strip_payload")
        td = tempfile.mkdtemp()
        try:
            dll = os.path.join(td, "GameAssembly.dll")
            open(dll, "wb").write(old)
            r = subprocess.run([sys.executable, os.path.join(ROOT, "patch_skill_delay.py"), "--dll", dll, "--install"],
                               capture_output=True, text=True, encoding="utf-8")
            check(r.returncode == 0 and open(dll, "rb").read() == P.build(P.strip_payload(old)),
                  f"{old_path}: --install -> bản menu dựng từ gốc: {r.stdout}")
        finally:
            shutil.rmtree(td, ignore_errors=True)


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--original", default=os.path.join(ROOT, "GameAssembly.dll.bak"))
    ap.add_argument("--legacy", help="DLL đã cài bản mod v1 (tùy chọn)")
    ap.add_argument("--old-v2", nargs="+", default=[], help="DLL v2 cũ / v3 dựng trước (tùy chọn, nhiều file)")
    args = ap.parse_args()
    orig = open(args.original, "rb").read()
    if sha(orig) != P.ORIGINAL_SHA256:
        sys.exit(f"{args.original} không phải bản gốc")
    out = test_install(orig)
    test_legacy(orig, args.legacy)
    test_pe(orig, out)
    test_disasm(orig, out)
    test_runtime(out)
    test_gates(orig, out)
    test_menu(orig, out)
    test_stone_logic(orig)
    test_sell_logic(orig)
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
