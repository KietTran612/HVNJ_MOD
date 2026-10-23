with open('decompiled_output/cave_v2.bin', 'rb') as f:
    cave = f.read()

pad_len = 928 - len(cave)
patch_bytes = cave + b'\x00' * pad_len

with open('GameAssembly.dll.bak', 'rb') as f:
    bak = f.read()

orig_bytes = bak[0x60CA90:0x60CA90+928]

with open('decompiled_output/cave_v2_hex.txt', 'w') as f:
    f.write(f"ORIG_HEX = '{orig_bytes.hex()}'\n")
    f.write(f"PATCH_HEX = '{patch_bytes.hex()}'\n")

print('Exported cave_v2_hex.txt successfully!')
