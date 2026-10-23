import json
import sys

sys.stdout.reconfigure(encoding='utf-8')

with open('decompiled_output/il2cpp_dump/stringliteral.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

for item in data:
    v = item.get('value', '')
    if any(k in v.lower() for k in ['umaru', 'chiyo', 'furoya', 'tạp hóa', 'tiêu đình', 'kirin', 'hiệu trưởng']):
        print(f"{item.get('address')}: {repr(v)}")
