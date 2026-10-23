import os
import re

keywords = ['nhiệm vụ', 'nhiem vu', 'kazeto', 'ookamesama', 'toyotomi', 'lệnh bài', 'taskorder', 'task']

results = []
for root, dirs, files in os.walk('decompiled_output/CSharp_Source'):
    for f in files:
        if f.endswith('.cs'):
            path = os.path.join(root, f)
            try:
                with open(path, 'r', encoding='utf-8', errors='ignore') as fp:
                    for i, line in enumerate(fp):
                        for kw in keywords:
                            if kw in line.lower():
                                results.append(f"{f}:{i+1}: {line.strip()[:120]}")
            except Exception as e:
                pass

print(f"Total occurrences: {len(results)}")
for r in results[:40]:
    print(r)
