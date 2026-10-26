"""Convert Cpp2IL ELF file offsets to actual runtime virtual addresses.

Cpp2IL's diffable-cs Address RVA/Offset both contain file offsets for this APK.
Never feed them back through a VA-to-file mapper or hook the declared RVA.
"""
import argparse
import hashlib
import json
from pathlib import Path
import re
import struct

EXPECTED = "2781a4fe636ea3ba52ea73f7b9c952847dd23e1b7e9bd5d7d6df0f403bd4ec0a"
METHOD = re.compile(r'\[Address\(RVA = "0x([0-9A-F]+)", Offset = "0x([0-9A-F]+)", Length = "0x([0-9A-F]+)"\)\]\s*\[Token[^\n]*\]\s*([^{};]+?)\s*\{ \}')
HOOKS = {
    "MapScr": {"update", "initData", "doMenuChar", "actionPerform", "getTaskPhuMonster", "getTaskMob", "autoFocus", "mapShowShop", "doActionButtonTop"},
    "Char": {"findFocus", "setFocus", "update"},
    "CommandGame": {"performAction"},
    "GlobalMessage": {"onMessage"},
    "Main": {"OnGUI"},
    "Service": {"openMenu", "menu", "itemBagToBox", "itemBoxToBag", "upgradeItem", "buyItem", "sellItem", "crystalCollectLock"},
}


class Elf:
    def __init__(self, b):
        if b[:6] != b"\x7fELF\x02\x01" or struct.unpack_from("<H", b, 18)[0] != 183:
            raise ValueError("expected ARM64 ELF64 little endian")
        self.data = b
        po = struct.unpack_from("<Q", b, 32)[0]
        size, count = struct.unpack_from("<HH", b, 54)
        self.loads = []
        for i in range(count):
            typ, flags, off, va, _, fs, ms, al = struct.unpack_from("<IIQQQQQQ", b, po + size * i)
            if typ == 1:
                self.loads.append(dict(offset=off, va=va, filesz=fs, memsz=ms, flags=flags, align=al))

    def virtual_for_file(self, off):
        for s in self.loads:
            if s["offset"] <= off < s["offset"] + s["filesz"]:
                return s["va"] + off - s["offset"]
        raise ValueError(f"file offset {off:#x} outside ELF loads")


def generate(root):
    apk_hash = hashlib.sha256((root / "HVNJ_185.apk").read_bytes()).hexdigest()
    if apk_hash != EXPECTED:
        raise ValueError("APK input differs from inspected version")
    elf = Elf((root / "analysis/lib/arm64-v8a/libil2cpp.so").read_bytes())
    methods = []
    game = root / "analysis/csharp_arm64/DiffableCs/Assembly-CSharp"
    for cls, names in HOOKS.items():
        p = game / (cls + ".cs")
        if not p.exists():
            continue
        for m in METHOD.finditer(p.read_text(encoding="utf-8-sig")):
            sig = " ".join(m[4].split())
            name = sig.split("(")[0].split()[-1]
            if name not in names:
                continue
            off, length = int(m[2], 16), int(m[3], 16)
            va = elf.virtual_for_file(off)
            if not any(s["flags"] & 1 and s["offset"] <= off and off + length <= s["offset"] + s["filesz"] for s in elf.loads):
                raise ValueError("method is outside executable segment")
            methods.append(dict(owner=cls, name=name, signature=sig, file_offset=off,
                                virtual_address=va, length=length, guard=elf.data[off:off + min(16, length)].hex()))
    return dict(apk_sha256=apk_hash, unity="6000.3.17f1", metadata=39, methods=methods)


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--root", type=Path, default=Path(__file__).resolve().parents[1])
    ap.add_argument("--output", type=Path)
    args = ap.parse_args()
    p = generate(args.root)
    out = args.output or args.root / "build/generated"
    out.mkdir(parents=True, exist_ok=True)
    (out / "profile.json").write_text(json.dumps(p, indent=2), encoding="utf-8")
    header = ["#pragma once", "#include <cstdint>",
              "struct HvHookProfile { const char* owner; const char* name; uintptr_t va; unsigned size; unsigned char guard[16]; };",
              "static const HvHookProfile hv_hook_profiles[] = {"]
    for m in p["methods"]:
        guard = ",".join("0x" + m["guard"][i:i+2] for i in range(0, len(m["guard"]), 2))
        header.append('{"%s","%s",0x%x,%d,{%s}},' % (m["owner"], m["name"], m["virtual_address"], min(16, m["length"]), guard))
    header += ["};"]
    (out / "hv_profile.h").write_text("\n".join(header) + "\n", encoding="utf-8")
    print(f"Generated {len(p['methods'])} guarded ARM64 hook profiles in {out}")


if __name__ == "__main__":
    main()
