import json
import sys

sys.stdout.reconfigure(encoding='utf-8')

with open('decompiled_output/il2cpp_dump/stringliteral.json', 'r', encoding='utf-8') as f:
    data = json.load(f)

keywords = ['thông', 'phù', 'truyền', 'dịch chuyển', 'yên', 'bán', 'mua', 'cửa hàng', 'tạp hóa', 'tiêu đình']

for item in data:
    v = item.get('value', '')
    for kw in keywords:
        if kw in v.lower():
            print(f"{item.get('address')}: {repr(v)}")
            break
