import re

with open('decompiled_output/CSharp_Source/lj.cs', 'r') as f:
    content = f.read()

methods = re.findall(r'public void (\w+)\(([^)]*)\)', content)
for name, params in methods:
    if any(k in params.lower() for k in ['item', 'shop', 'npc', 'ui', 'gold', 'coin', 'money', 'buy', 'index']):
        print(f"Service.{name}({params})")
