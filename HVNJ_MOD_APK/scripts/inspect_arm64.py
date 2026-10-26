"""Regenerate reference targets/disassembly with ELF file-offset translation."""
import json
from pathlib import Path
from generate_profile import Elf, METHOD

ROOT=Path(__file__).resolve().parents[1]
def main():
    from capstone import Cs, CS_ARCH_ARM64, CS_MODE_ARM
    elf=Elf((ROOT/"analysis/lib/arm64-v8a/libil2cpp.so").read_bytes())
    game=ROOT/"analysis/csharp_arm64/DiffableCs/Assembly-CSharp"
    selected={"Service":{"menu","openMenu","crystalCollect","crystalCollectLock","returnTownFromDead","itemBagToBox","sellItem"},
              "MapScr":{"update","initData","getTaskMob","getTaskPhuMonster","clickTaskAuto","mapShowShop"},
              "MapPopupG4M":{"mapThiLuyen","goToMap"},"LuyenDaPopupG4M":{"upPearl"}}
    targets=[];lines=["Corrected mapping: Cpp2IL Address values are file offsets. VA translated through ELF PT_LOAD."]
    dis=Cs(CS_ARCH_ARM64,CS_MODE_ARM)
    for cls,names in selected.items():
        for m in METHOD.finditer((game/(cls+".cs")).read_text(encoding="utf-8-sig")):
            sig=" ".join(m[4].split());name=sig.split("(")[0].split()[-1]
            if name not in names:continue
            off=int(m[2],16);size=int(m[3],16);va=elf.virtual_for_file(off)
            targets.append(dict(owner=cls,signature=sig,file_offset=off,virtual_address=va,length=size))
            lines.append(f"\n{cls}.{sig}: FILE {off:#x} VA {va:#x} SIZE {size:#x}")
            for ins in dis.disasm(elf.data[off:off+size],va):lines.append(f"{ins.address:08x}: {ins.mnemonic:8} {ins.op_str}")
    (ROOT/"analysis/port_targets_arm64.json").write_text(json.dumps({"coordinate_system":"ELF PT_LOAD translated; Cpp2IL RVA is a file offset","methods":targets},indent=2))
    (ROOT/"analysis/arm64_service_and_auto.asm.txt").write_text("\n".join(lines)+"\n")
    print(f"Corrected {len(targets)} reference methods")
if __name__=="__main__":main()
