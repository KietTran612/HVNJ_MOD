import os
import sys

sys.stdout.reconfigure(encoding='utf-8')

keywords = ['livefromdead', 'hồi sinh', 'về làng', 'quay về', 'countdown', 'timedie', 'die']

found = {}
for root, dirs, f_list in os.walk('decompiled_output/CSharp_Source'):
    if 'UnityEngine' in root:
        continue
    for fname in f_list:
        if fname.endswith('.cs'):
            fpath = os.path.join(root, fname)
            try:
                with open(fpath, 'r', encoding='utf-8', errors='ignore') as f:
                    content = f.read()
                matched = [kw for kw in keywords if kw in content.lower()]
                if matched:
                    found[fname] = matched
            except Exception as e:
                pass

print(f'Total matching C# files: {len(found)}')
for fname, kws in sorted(found.items()):
    print(f'{fname}: {kws}')
