with open('decompiled_output/cave_v2_hex.txt', 'r') as f:
    lines = f.readlines()

orig_hex = lines[0].strip().split("'")[1]
patch_hex = lines[1].strip().split("'")[1]

with open('patch_skill_delay.py', 'r', encoding='utf-8') as f:
    content = f.read()

# Replace the DAILY_QUEST_PATCHES block
old_block_start = "DAILY_QUEST_PATCHES = {"
old_block_end = "def ensure_backup(target_dll=GAME_DLL):"

start_idx = content.find(old_block_start)
end_idx = content.find(old_block_end)

assert start_idx != -1 and end_idx != -1, "Could not find DAILY_QUEST_PATCHES block"

new_block = f"""DAILY_QUEST_PATCHES = {{
    0x19395E: {{
        'name': 'mo::ctq: Hook vòng lặp Auto làm nhiệm vụ (call mo::dgd -> call Cave_AutoDailyQuest)',
        'orig': bytes.fromhex('E8 4D 0D 02 00'),
        'patch': bytes.fromhex('E8 2D 91 47 00'),
    }},
    0x60CA90: {{
        'name': 'Code Cave: Tự nhận NV tại NPC -> Tới nhanh map NV (Đi làm NV) -> Tự đánh quái NV -> Tự về trường (Thông Thành Phù) trả NV -> Lặp lại',
        'orig': bytes.fromhex(
            '{orig_hex}'
        ),
        'patch': bytes.fromhex(
            '{patch_hex}'
        ),
    }}
}}

"""

new_content = content[:start_idx] + new_block + content[end_idx:]

with open('patch_skill_delay.py', 'w', encoding='utf-8') as f:
    f.write(new_content)

print("Updated patch_skill_delay.py successfully!")
