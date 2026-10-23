import json
import sys

sys.stdout.reconfigure(encoding='utf-8', errors='replace')

with open('decompiled_output/il2cpp_dump/stringliteral.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

keywords = ['nhiệm vụ', 'hàng ngày', 'kazeto', 'ookame', 'toyotomi', 'lệnh', 'hoàn thành', 'trả nhiệm vụ', 'nhận nhiệm vụ']

matches = []
for item in data:
    val = item.get('value', '')
    for kw in keywords:
        if kw.lower() in val.lower():
            matches.append((item.get('address'), val))

print(f"Total matching string literals: {len(matches)}")
for addr, val in matches:
    print(f"{addr}: {val}")
