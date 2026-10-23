import json

with open('decompiled_output/il2cpp_dump/script.json', 'r') as f:
    data = json.load(f)

for m in data.get('ScriptMethod', []):
    addr = m.get('Address', 0)
    if isinstance(addr, str):
        addr = int(addr, 16)
    # search methods that start before 0x180202689
    if addr <= 0x180202689 <= addr + 0x20000:
        print(f"Method: {m.get('Name')}, Addr: {hex(addr)}")
