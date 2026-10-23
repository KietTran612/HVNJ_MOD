import json
import sys

sys.stdout.reconfigure(encoding='utf-8')

with open('decompiled_output/il2cpp_dump/stringliteral.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

for item in data:
    v = item.get('value', '')
    if any(k in v.lower() for k in ['đi làm', 'làm nv', 'làm nhiệm', 'nhận nv', 'trả nv', 'nhiệm vụ hàng ngày', 'nhiệm vụ ngày']):
        print(f"{item.get('address')}: {repr(v)}")
