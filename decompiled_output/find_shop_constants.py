import re

with open('decompiled_output/CSharp_Source/fp.cs', 'r', encoding='utf-8', errors='ignore') as f:
    lines = f.readlines()

for i, line in enumerate(lines):
    if 'const ' in line or 'public static int ' in line or 'public int ' in line:
        if any(k in line.lower() for k in ['type', 'shop', 'ui', 'menu', 'item']):
            print(f"{i+1}: {line.strip()}")
