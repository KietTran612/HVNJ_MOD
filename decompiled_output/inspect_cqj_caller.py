import json
import capstone

with open('decompiled_output/il2cpp_dump/script.json', 'r') as f:
    data = json.load(f)

for m in data.get('ScriptMethod', []):
    addr = m.get('Address', 0)
    if isinstance(addr, str):
        addr = int(addr, 16)
    if addr <= 0x180202689 <= addr + 0x600:
        print(f"Method: {m.get('Name')}, Addr: {hex(addr)}")

with open('GameAssembly.dll.bak', 'rb') as f:
    dll = f.read()

# Disassemble around 0x180202689
# VA 0x180202689 -> File offset: 0x180202689 - 0x180001000 = 0x201689
offset = 0x201600
md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
print("\n--- Disassembly around 0x180202689 ---")
for ins in md.disasm(dll[offset:offset+0x200], 0x180202600):
    print(f"{hex(ins.address)}: {ins.mnemonic} {ins.op_str}")
