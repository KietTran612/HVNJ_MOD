import sys
import os
import shutil

sys.stdout.reconfigure(encoding='utf-8', errors='replace')

GAME_DLL = "GameAssembly.dll"
BAK_DLL = "GameAssembly.dll.bak"

# ==============================================================================
# 1. CẤU HÌNH PATCH TỐC ĐỘ RA CHIÊU (0.3s)
# ==============================================================================
# RVA 0x259320 -> File Offset 0x258320 (lm::cwj)
CWJ_OFFSET = 0x258320
CWJ_ORIG = bytes.fromhex("48 83 ec 28 48 8b 91 e0 03 00 00 4c 8b c1 48 85")
CWJ_PATCH_ALL = bytes.fromhex("F3 0F 10 05 7C 90 97 00 C3 90 90 90 90 90 90 90")

# ==============================================================================
# 2. CẤU HÌNH PATCH NÉ QUÁI TINH ANH / THỦ LĨNH / BOSS (AUTO TARGETING)
# ==============================================================================
MOB_AVOID_PATCHES = {
    0x1B8F07: {
        'name': 'mo::dgj lọc quái (bỏ qua levelBoss != 0 & isBos != 0)',
        'orig': bytes.fromhex('44 39 60 44 0f 84 6d 01 00 00 48 8b 0d 10 20 ca 00 f6 81 33 01 00 00 02 74 0e 44 39 a1 e0 00 00 00 75 05 e8 a1 25 f2 ff'),
        'patch': bytes.fromhex('44 39 60 44 0F 84 6D 01 00 00 66 83 B8 B0 00 00 00 00 0F 85 5F 01 00 00 80 B8 B4 00 00 00 00 0F 85 52 01 00 00 90 90 90'),
    },
    0x1B8EAE: {
        'name': 'mo::dgj bỏ qua kiểm tra template nhiệm vụ (tấn công quái thường gần nhất)',
        'orig': bytes.fromhex('0F 85 CA 01 00 00'),
        'patch': bytes.fromhex('90 90 90 90 90 90'),
    },
    0x1B8DFC: {
        'name': 'mo::dgj chuyển hướng kết thúc vòng lặp sang cave trampoline',
        'orig': bytes.fromhex('0F 8D 83 02 00 00'),
        'patch': bytes.fromhex('0F 8D C9 02 00 00'),
    },
    0x1B908A: {
        'name': 'mo::dgj giữ nguyên con quái được chọn (nop xor eax)',
        'orig': bytes.fromhex('33 C0'),
        'patch': bytes.fromhex('90 90'),
    },
    0x1B90CB: {
        'name': 'mo::dgj cave trampoline (mov rax, r14; jmp epilogue)',
        'orig': bytes.fromhex('CC CC CC CC CC'),
        'patch': bytes.fromhex('4C 89 F0 EB B5'),
    },
    0x1B9485: {
        'name': 'mo::dgl auto nhiệm vụ lọc quái (bỏ qua levelBoss != 0 & isBos != 0)',
        'orig': bytes.fromhex('39 68 44 0f 84 6f 01 00 00 48 8b 0d 93 1a ca 00 f6 81 33 01 00 00 02 74 0d 39 a9 e0 00 00 00 75 05 e8 25 20 f2 ff'),
        'patch': bytes.fromhex('39 68 44 0F 84 6F 01 00 00 66 83 B8 B0 00 00 00 00 0F 85 61 01 00 00 80 B8 B4 00 00 00 00 0F 85 54 01 00 00 90 90'),
    }
}

# ==============================================================================
# 3. CẤU HÌNH PATCH QUAY VỀ LIỀN KHI CHẾT (BỎ QUA COUNTDOWN 15s)
# ==============================================================================
DEATH_RETURN_PATCHES = {
    0x1917E2: {
        'name': 'mo.ctq giảm đếm ngược auto chết (15s -> 1 tick)',
        'orig': bytes.fromhex('c6 80 52 01 00 00 0f'),
        'patch': bytes.fromhex('c6 80 52 01 00 00 01'),
    },
    0x191912: {
        'name': 'mo.ctq giảm đếm ngược lần 2 (15s -> 1 tick)',
        'orig': bytes.fromhex('c6 80 52 01 00 00 0f'),
        'patch': bytes.fromhex('c6 80 52 01 00 00 01'),
    },
    0x3602E0: {
        'name': 'kq::cwh giảm đếm ngược hộp thoại chết 1 (10s -> 2 ticks)',
        'orig': bytes.fromhex('c7 41 3c f4 01 00 00'),
        'patch': bytes.fromhex('c7 41 3c 02 00 00 00'),
    },
    0x35F946: {
        'name': 'kq::cvv giảm đếm ngược hộp thoại chết 2 (10s -> 2 ticks)',
        'orig': bytes.fromhex('c7 40 40 f4 01 00 00'),
        'patch': bytes.fromhex('c7 40 40 02 00 00 00'),
    }
}

# ==============================================================================
# 4. CẤU HÌNH PATCH AUTO TRONG MAP THÍ LUYỆN (MAP 161)
# ==============================================================================
TRIAL_MAP_PATCHES = {
    0x19B061: {
        'name': 'mo::dek bỏ qua lệnh tắt Auto khi vào Map 161 (Thí Luyện)',
        'orig': bytes.fromhex('75 41'),
        'patch': bytes.fromhex('EB 41'),
    },
    0x476CBF: {
        'name': 'eq::bld bỏ qua blacklist kiểm tra Map 161 (Thí Luyện)',
        'orig': bytes.fromhex('0F 84 D3 03 00 00'),
        'patch': bytes.fromhex('90 90 90 90 90 90'),
    }
}

# ==============================================================================
# 5. CẤU HÌNH PATCH TỰ ĐỘNG CHUYỂN ẢI THÍ LUYỆN (MAP 161 -> 167) & DỪNG Ở MAP CUỐI
# ==============================================================================
TRIAL_PROGRESSION_PATCHES = {
    0x238: {
        'name': 'PE Header: Cập nhật VirtualSize của Section .text (0x18DA08 -> 0x18DC00)',
        'orig': bytes.fromhex('08 DA 18 00'),
        'patch': bytes.fromhex('00 DC 18 00'),
    },
    0x18DE10: {
        'name': 'Code Cave: Tự động qua ải kế tiếp khi hết quái & Né quái thông minh trong Thí Luyện',
        'orig': bytes([0x00] * 356),
        'patch': bytes.fromhex('4883ec2031c9e875b202004883c4204885c0740c48898300020000e946c80b00488b0db1d6cc004885c90f84d7000000488b89b80000004885c90f84c70000000fb7515c81faa10000000f8cb700000081faa70000000f8fab0000000f849400000080bb8d060000000f85980000004c8b41604d85c00f848b000000458b50184585d20f8e7e0000004d8b40104d85c00f8471000000ffc231c94d8b4cc8204d85c97407664139511a740cffc14439d17ce8e950000000410fbf4110410fbf491401c8d1f8410fbf4912410fbf511601d1d1f9f30f2ac8f30f2ad14889d94531c04531c94883ec20e8131f0e004883c420e91100000031c931d24883ec20e8dd6803004883c42048c7830002000000000000e94fc70b00909090909090909090488b0db1d5cc004885c9741b488b89b80000004885c9740f0fb7495c81e9a100000083f90676136683b8b000000000750e80b8b4000000007505e9c0b30200e90ab50200'),
    },
    0x24A5AC: {
        'name': 'lm::clo: Hook kiểm tra khi hết quái trong Thí Luyện (call mo::dgj -> jmp Cave)',
        'orig': bytes.fromhex('E8 DF E6 F6 FF E9 B9 FC FF FF'),
        'patch': bytes.fromhex('E9 5F 34 F4 FF 90 90 90 90 90'),
    },
    0x1B8F07: {
        'name': 'mo::dgj: Hook né quái nâng cao (cho phép đánh Boss/Thủ Lĩnh trong Thí Luyện)',
        'orig': bytes.fromhex('44 39 60 44 0F 84 6D 01 00 00 48 8B 0D 10 20 CA 00 F6 81 33 01 00 00 02 74 0E 44 39 A1 E0 00 00 00 75 05 E8 A1 25 F2 FF'),
        'patch': bytes.fromhex('44 39 60 44 0F 84 6D 01 00 00 E9 1A 4C FD FF 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90 90'),
    }
}

# ==============================================================================
# 6. CẤU HÌNH PATCH FULL AUTO LÀM NHIỆM VỤ HÀNG NGÀY
# ==============================================================================
DAILY_QUEST_PATCHES = {
    0x19395E: {
        'name': 'mo::ctq: Hook vòng lặp Auto làm nhiệm vụ (call mo::dgd -> call Cave_AutoDailyQuest)',
        'orig': bytes.fromhex('E8 4D 0D 02 00'),
        'patch': bytes.fromhex('E8 2D 91 47 00'),
    },
    0x60CA90: {
        'name': 'Code Cave: Tự nhận NV tại NPC -> Tới nhanh map NV (Đi làm NV) -> Tự đánh quái NV -> Tự về trường (Thông Thành Phù) trả NV -> Lặp lại',
        'orig': bytes.fromhex(
            '89542410534883ec30803d83488a0000752b488d0d57948400e8529db4ff488d0d63318300e8469db4ff488d0df7c48300e83a9db4ffc60556488a0001488b1d44318300488d4c244833d2e81012f4ff4c8b05d1c483004c8bcb488b0d0f948400488bd048c744242000000000e8ceb44b0033d2488bc8e804a4b9ff488bc34883c4305bc3cccccccccccccccccccccc40534883ec20803df9478a0000488bda7513488d0d97718400e8c29cb4ffc605e1478a0001488b0d84718400f6813301000002740e83b9e0000000007505e86de9acff33c9e8b648e4ff4885c074134533c0488bd3488bc84883c4205be91ea1e4ffe8c99db4ffcccccccccccccccccc40534883ec20803d84478a0000488bda7513488d0d27718400e8529cb4ffc6056c478a0001488b0d14718400f6813301000002740e83b9e0000000007505e8fde8acff33c9e84648e4ff4885c074134533c0488bd3488bc84883c4205be94e9ee4ffe8599db4ffcccccccccccccccccc40534883ec20803d18478a0000488bda7513488d0db7708400e8e29bb4ffc60500478a0001488b0da4708400f6813301000002740e83b9e0000000007505e88de8acff33c9e8d647e4ff4885c074134533c0488bd3488bc84883c4205be97e9fe4ffe8e99cb4ffcccccccccccccccccc4883ec28803dad468a0000752b488d0dd4c18400e8779bb4ff488d0dc8cf8400e86b9bb4ff488d0df4cf8400e85f9bb4ffc60580468a0001488b05e1cf8400f6803301000002741883b8e000000000750f488bc8e807e8acff488b05c0cf8400488b80b800000048837858007459488b0d73c18400f6813301000002740e83b9e0000000007505e8d4e7acff33c9e81dbde2ff4885c07434807810007529488b0d43cf8400f6813301000002740e83b9e0000000007505e8a4e7acff33c94883c428e969e1d4ff4883c428c3e80f9cb4ffcccccccccccccccccccccccccccccc40534883ec20803dc7458a0000488bda751f488d0da7c18400e8929ab4ff488d0de3ce8400e8869ab4ffc605a3458a0001488b0d88c184004533c0488bd3e8ddb44b0033d2488bc8e873a1b9ff488b0d6cc184004533c0488bd3e8c1b44b00488b0da2ce8400488bd8f6813301000002740e83b9e0000000007505e800e7acff33d2488bcb4883c4205be9a1c6d4ffcc40534883ec20803d3a458a0000488bda7513488d0d0f7c8200e8029ab4ffc60522458a0001488b0dfc7b82004533c0488bd3e859b44b0033d2488bc8e8efa0b9ff803d00458a0000752b488d0d27c084'
        ),
        'patch': bytes.fromhex(
            'e81b7cbaff5553565741544155415641574883ec2880bb88040000000f8460030000488b052fe684004885c00f8450030000488b80b80000004885c00f84400300000fb7485c81f9a10000007c0c81f9a70000000f8e28030000fe0584020000803d7e020000240f8215030000c605710200000031c9e8150ac4ff4885c00f84fe02000080b88d060000000f85f10200004989c6410fb68e7001000041bc0100000083f903741183f904740c83f905740f83f906740aeb0e41bc48000000eb0641bc1b00000031ff498b86b80100004885c074348b481885c97e2d31d2488b74d0204885f67417488b76104885f6740e0fb7761083fe23740d83fe257408ffc239ca7cd9eb02ffc7488b0549e584004885c00f846a020000488b80b80000004885c00f845a020000440fb7685c85ff75304539e5752b31c9e8339fc2ff4885c0741f4889c1ba100000004531c041b90a00000048c744242000000000e82fc6c2ff488b0560e584004885c00f8411020000488b80b80000004885c00f8401020000488bb0800000004885f60f84f10100008b561885d20f8fb100000080bbe9010000000f85d901000080bbea010000000f85cc0100004539e5743485ff741731c9e8aa9ec2ff4885c0740b4889c14489e2e86afbc2ff4889d94489e241b8190000004531c9e8967dbaffe993010000b91900000031d2e855bcbdff4885c0743431c9e8699ec2ff4885c00f84720100004889c1ba190000004531c041b90200000048c744242000000000e8215ac3ffe94e0100004889d94489e241b8190000004531c9e8387dbaffe935010000488b46104885c00f84280100004c8b78204d85ff0f841b010000418b4710413b47140f8d820000004539e5755eb91900000031d2e8cabbbdff4885c0743431c9e8de9dc2ff4885c00f84e70000004889c1ba190000004531c041b90100000048c744242000000000e89659c3ffe9c30000004889d94489e241b8190000004531c9e8ad7cbaffe9aa0000004c39bbf80100000f849d0000004889d931d24d89f8e84e60baffe98b0000004539e5742d85ff741731c9e8699dc2ff4885c0740b4889c14489e2e829fac2ff4889d931d24d89f8e81c60baffe959000000b91900000031d2e81bbbbdff4885c0743431c9e82f9dc2ff4885c00f84380000004889c1ba190000004531c041b90200000048c744242000000000e8e758c3ffe9140000004889d94489e241b8190000004531c9e8fe7bbaff4883c428415f415e415d415c5f5e5b5dc300000000000000000000000000'
        ),
    }
}

def ensure_backup(target_dll=GAME_DLL):
    if not os.path.exists(BAK_DLL):
        print(f"[*] Tạo bản sao lưu gốc: {BAK_DLL}...")
        shutil.copyfile(target_dll, BAK_DLL)
        print("[+] Đã sao lưu thành công!")

def check_status(target_dll=GAME_DLL):
    if not os.path.exists(target_dll):
        print(f"[-] Không tìm thấy file {target_dll}")
        return

    with open(target_dll, "rb") as f:
        data = f.read()

    print(f"=== TRẠNG THÁI HIỆN TẠI CỦA {target_dll} ===")
    
    # 1. Kiểm tra tốc độ ra chiêu
    cwj_bytes = data[CWJ_OFFSET:CWJ_OFFSET+16]
    is_cwj_patched = (cwj_bytes == CWJ_PATCH_ALL)
    is_cwj_orig = (cwj_bytes == CWJ_ORIG)
    if is_cwj_patched:
        print("[*] 1. Tốc độ ra chiêu 0.3s: ĐANG BẬT (Global skill cooldown)")
    elif is_cwj_orig:
        print("[*] 1. Tốc độ ra chiêu: GỐC (Chưa patch)")
    else:
        print("[*] 1. Tốc độ ra chiêu: TÙY CHỈNH / KHÔNG XÁC ĐỊNH")

    # 2. Kiểm tra né quái tinh anh/thủ lĩnh
    all_mob_patched = True
    all_mob_orig = True
    for off, item in MOB_AVOID_PATCHES.items():
        chunk = data[off:off+len(item['patch'])]
        if chunk != item['patch']:
            all_mob_patched = False
        if chunk != item['orig']:
            all_mob_orig = False

    if all_mob_patched or data[0x1B8F07:0x1B8F07+15] == bytes.fromhex('44 39 60 44 0F 84 6D 01 00 00 E9 1A 4C FD FF'):
        print("[*] 2. Né quái Tinh Anh / Thủ Lĩnh / Boss: ĐANG BẬT (Auto chỉ chọn quái thường)")
    elif all_mob_orig:
        print("[*] 2. Né quái Tinh Anh / Thủ Lĩnh / Boss: GỐC (Chưa patch)")
    else:
        print("[*] 2. Né quái Tinh Anh / Thủ Lĩnh / Boss: MỘT PHẦN / TÙY CHỈNH")

    # 3. Kiểm tra quay về liền khi chết
    all_die_patched = True
    all_die_orig = True
    for off, item in DEATH_RETURN_PATCHES.items():
        chunk = data[off:off+len(item['patch'])]
        if chunk != item['patch']:
            all_die_patched = False
        if chunk != item['orig']:
            all_die_orig = False

    if all_die_patched:
        print("[*] 3. Quay về liền khi chết: ĐANG BẬT (Bỏ qua thời gian đếm ngược)")
    elif all_die_orig:
        print("[*] 3. Quay về liền khi chết: GỐC (Chờ 15s đếm ngược)")
    else:
        print("[*] 3. Quay về liền khi chết: MỘT PHẦN / TÙY CHỈNH")

    # 4. Kiểm tra Auto trong Map Thí Luyện
    all_trial_patched = True
    all_trial_orig = True
    for off, item in TRIAL_MAP_PATCHES.items():
        chunk = data[off:off+len(item['patch'])]
        if chunk != item['patch']:
            all_trial_patched = False
        if chunk != item['orig']:
            all_trial_orig = False

    if all_trial_patched:
        print("[*] 4. Auto & Quay lại trong Map Thí Luyện: ĐANG BẬT (Không tắt Auto, tự quay lại chỗ cũ)")
    elif all_trial_orig:
        print("[*] 4. Auto & Quay lại trong Map Thí Luyện: GỐC (Bị tắt Auto & chặn di chuyển)")
    else:
        print("[*] 4. Auto & Quay lại trong Map Thí Luyện: MỘT PHẦN / TÙY CHỈNH")

    # 5. Kiểm tra Tự động chuyển ải Thí Luyện
    all_prog_patched = True
    all_prog_orig = True
    for off, item in TRIAL_PROGRESSION_PATCHES.items():
        chunk = data[off:off+len(item['patch'])]
        if chunk != item['patch']:
            all_prog_patched = False
        if chunk != item['orig']:
            all_prog_orig = False

    if all_prog_patched:
        print("[*] 5. Tự động qua ải Thí Luyện (161 -> 167) & Dừng ở map cuối: ĐANG BẬT")
    elif all_prog_orig:
        print("[*] 5. Tự động qua ải Thí Luyện (161 -> 167) & Dừng ở map cuối: GỐC (Chưa bật)")
    else:
        print("[*] 5. Tự động qua ải Thí Luyện (161 -> 167) & Dừng ở map cuối: MỘT PHẦN / TÙY CHỈNH")

    # 6. Kiểm tra Full Auto làm Nhiệm Vụ Hàng Ngày
    all_quest_patched = True
    all_quest_orig = True
    for off, item in DAILY_QUEST_PATCHES.items():
        chunk = data[off:off+len(item['patch'])]
        if chunk != item['patch']:
            all_quest_patched = False
        if chunk != item['orig']:
            all_quest_orig = False

    if all_quest_patched:
        print("[*] 6. Full Auto Nhiệm Vụ Hàng Ngày (Nhận -> Đi -> Đánh -> Trả -> Lặp lại): ĐANG BẬT")
    elif all_quest_orig:
        print("[*] 6. Full Auto Nhiệm Vụ Hàng Ngày: GỐC (Chưa bật)")
    else:
        print("[*] 6. Full Auto Nhiệm Vụ Hàng Ngày: MỘT PHẦN / TÙY CHỈNH")

    print("=" * 50)

def patch_skill(target_dll=GAME_DLL):
    ensure_backup(target_dll)
    with open(target_dll, "r+b") as f:
        f.seek(CWJ_OFFSET)
        f.write(CWJ_PATCH_ALL)
    print(f"[+] [Skill] Đã chỉnh thời gian ra chiêu còn 0.3s trong {target_dll}!")

def patch_mob_avoidance(target_dll=GAME_DLL):
    ensure_backup(target_dll)
    with open(target_dll, "r+b") as f:
        for off, item in MOB_AVOID_PATCHES.items():
            f.seek(off)
            f.write(item['patch'])
    print(f"[+] [Auto Mob] Đã bật tính năng né quái Tinh Anh / Thủ Lĩnh / Boss trong {target_dll}!")

def patch_death_return(target_dll=GAME_DLL):
    ensure_backup(target_dll)
    with open(target_dll, "r+b") as f:
        for off, item in DEATH_RETURN_PATCHES.items():
            f.seek(off)
            f.write(item['patch'])
    print(f"[+] [Auto Die] Đã bật tính năng quay về liền khi chết (không chờ đếm ngược) trong {target_dll}!")

def patch_trial_map(target_dll=GAME_DLL):
    ensure_backup(target_dll)
    with open(target_dll, "r+b") as f:
        for off, item in TRIAL_MAP_PATCHES.items():
            f.seek(off)
            f.write(item['patch'])
    print(f"[+] [Trial Map] Đã bật tính năng Auto & tự quay lại map cũ trong Map Thí Luyện trong {target_dll}!")

def patch_trial_progression(target_dll=GAME_DLL):
    ensure_backup(target_dll)
    with open(target_dll, "r+b") as f:
        for off, item in TRIAL_PROGRESSION_PATCHES.items():
            f.seek(off)
            f.write(item['patch'])
    print(f"[+] [Trial Progression] Đã bật tính năng tự động chuyển ải Thí Luyện (161->167) & dừng ở map cuối trong {target_dll}!")

def patch_daily_quest(target_dll=GAME_DLL):
    ensure_backup(target_dll)
    with open(target_dll, "r+b") as f:
        for off, item in DAILY_QUEST_PATCHES.items():
            f.seek(off)
            f.write(item['patch'])
    print(f"[+] [Daily Quest] Đã bật tính năng Full Auto Nhiệm Vụ Hàng Ngày (Tự nhận -> Tự đi -> Tự đánh -> Tự trả) trong {target_dll}!")

def patch_all_features(target_dll=GAME_DLL):
    patch_skill(target_dll)
    patch_mob_avoidance(target_dll)
    patch_death_return(target_dll)
    patch_trial_map(target_dll)
    patch_trial_progression(target_dll)
    patch_daily_quest(target_dll)
    print(f"[+] HOÀN TẤT BẢN MOD TOÀN DIỆN CHO {target_dll} (ĐẦY ĐỦ CẢ 6 TÍNH NĂNG)!")

def restore(target_dll=GAME_DLL):
    if not os.path.exists(BAK_DLL):
        print(f"[-] Không tìm thấy file sao lưu gốc {BAK_DLL}!")
        return
    shutil.copyfile(BAK_DLL, target_dll)
    print(f"[+] ĐÃ KHÔI PHỤC THÀNH CÔNG {target_dll} về bản gốc ban đầu!")

if __name__ == "__main__":
    if len(sys.argv) < 2 or sys.argv[1] in ["-h", "--help"]:
        print("Sử dụng:")
        print("  python patch_skill_delay.py --all      : Bật đầy đủ cả 6 tính năng mod")
        print("  python patch_skill_delay.py --quest    : Chỉ bật Full Auto Nhiệm vụ Hàng ngày")
        print("  python patch_skill_delay.py --stage    : Chỉ bật tự chuyển ải Thí Luyện (161->167)")
        print("  python patch_skill_delay.py --trial    : Chỉ bật Auto & quay lại trong Map Thí Luyện")
        print("  python patch_skill_delay.py --die      : Chỉ bật quay về liền khi chết")
        print("  python patch_skill_delay.py --mob      : Chỉ bật né quái tinh anh/thủ lĩnh/boss")
        print("  python patch_skill_delay.py --skill    : Chỉ bật tốc độ ra chiêu 0.3s")
        print("  python patch_skill_delay.py --restore  : Khôi phục file game về bản gốc")
        print("  python patch_skill_delay.py --status   : Xem trạng thái hiện tại")
    elif sys.argv[1] in ["--all", "--full"]:
        patch_all_features(GAME_DLL)
        check_status(GAME_DLL)
    elif sys.argv[1] in ["--quest", "--daily"]:
        patch_daily_quest(GAME_DLL)
        check_status(GAME_DLL)
    elif sys.argv[1] in ["--stage", "--progression"]:
        patch_trial_progression(GAME_DLL)
        check_status(GAME_DLL)
    elif sys.argv[1] == "--trial":
        patch_trial_map(GAME_DLL)
        check_status(GAME_DLL)
    elif sys.argv[1] == "--die":
        patch_death_return(GAME_DLL)
        check_status(GAME_DLL)
    elif sys.argv[1] == "--mob":
        patch_mob_avoidance(GAME_DLL)
        check_status(GAME_DLL)
    elif sys.argv[1] == "--skill":
        patch_skill(GAME_DLL)
        check_status(GAME_DLL)
    elif sys.argv[1] == "--restore":
        restore(GAME_DLL)
        check_status(GAME_DLL)
    elif sys.argv[1] == "--status":
        check_status(GAME_DLL)
