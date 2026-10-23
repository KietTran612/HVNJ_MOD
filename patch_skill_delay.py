"""Bản mod Học Viện Ninja 186 (GameAssembly.dll, Unity 2020.2.7 x64 IL2CPP).

Mỗi lần chạy, script dựng lại DLL từ bản GỐC (kiểm tra SHA-256) rồi áp đúng
tập tính năng được chọn, nên thứ tự chạy các lệnh không còn gây xung đột.
Bản gốc lấy từ GameAssembly.dll.bak; nếu không có, script tự khôi phục từ DLL
đã mod (kể cả bản mod cũ v1).

Code cave nằm trong 2 section mới thêm vào cuối DLL (.hvnj chỉ đọc+chạy,
.hvnjd đọc+ghi) kèm unwind info, không ghi đè code của game.
Mã nguồn cave: mod_src/hvnj_caves.asm, build bằng mod_src/build_payload.py.
"""
import argparse
import hashlib
import os
import struct
import sys

if hasattr(sys.stdout, "reconfigure"):
    sys.stdout.reconfigure(encoding="utf-8", errors="replace")

GAME_DLL = "GameAssembly.dll"
BAK_SUFFIX = ".bak"
ORIGINAL_SHA256 = "a17ddc0b955ca4c4ada07feac0d18a1d8f7232d64b6f654c405669419f92df25"
ORIGINAL_SIZE = 0xF65800

FEATURES = ["mob", "die", "trial", "stage", "quest", "party"]
FEATURE_NAMES = {
    "mob": "1. Né quái Tinh Anh / Thủ Lĩnh / Boss khi Auto",
    "die": "2. Chết quay về ngay (bỏ đếm ngược)",
    "trial": "3. Giữ Auto & tìm đường trong Thí Luyện",
    "stage": "4. Tự qua ải Thí Luyện 161 -> 167, dừng ở ải cuối",
    "quest": "5. Auto nhiệm vụ hàng ngày (dùng auto nhiệm vụ của game)",
    "party": "6. Đánh theo nhóm (chạy theo & đánh cùng quái với trưởng nhóm)",
}
PAYLOAD_FEATURES = ("mob", "stage", "quest", "party")

# ==============================================================================
# CÁC PATCH SỬA TRỰC TIẾP (RVA, byte gốc, byte mới)
# ==============================================================================
SIMPLE_PATCHES = {
    # mo.ctq: đếm ngược quay về khi chết 15 -> 1; hw.cdy / hw.cdq: hộp thoại chết 500 -> 2
    "die": [
        (0x1927E2, "c680520100000f", "c68052010000" + "01"),
        (0x192912, "c680520100000f", "c68052010000" + "01"),
        (0x3612E0, "c7413cf4010000", "c7413c02000000"),
        (0x360946, "c74040f4010000", "c7404002000000"),
    ],
    # mo::dek: không tắt Auto khi vào map 161 | eq::bld: bỏ chặn tìm đường trong map 161
    "trial": [
        (0x19C061, "7541", "eb41"),
        (0x477CBF, "0f84d3030000", "660f1f440000"),
    ],
}

# Tính năng ĐÃ GỠ - chỉ dùng để nhận diện và gỡ khỏi DLL cũ.
# "Tốc độ ra chiêu 0.3s" ép lm::cwj trả về 0.3f, nhưng cwj là SkeletonAnimation.timeScale
# của hiệu ứng skill (gốc 1.3-4.0), không phải hồi chiêu -> chỉ làm hiệu ứng chạy chậm lại.
RETIRED_PATCHES = {
    "skill": [
        (0x259320, "4883ec28488b91e00300004c8bc14885", "f30f10057c909700c390909090909090"),
    ],
}

# Bản mod cũ (v1) ghi theo FILE OFFSET: (offset, byte gốc, byte của bản v1).
# Chỉ dùng để nhận diện và khôi phục bản gốc từ DLL đã cài bản v1.
LEGACY_PATCHES = {
    "skill": [
        (0x258320, "4883ec28488b91e00300004c8bc14885", "f30f10057c909700c390909090909090"),
    ],
    "mob": [
        (0x1B8EAE, "0f85ca010000", "909090909090"),
        (0x1B8DFC, "0f8d83020000", "0f8dc9020000"),
        (0x1B908A, "33c0", "9090"),
        (0x1B90CB, "cccccccccc", "4c89f0ebb5"),
        (0x1B9485, "3968440f846f010000488b0d931aca00f6813301000002740d39a9e00000007505e82520f2ff",
         "3968440f846f0100006683b8b0000000000f856101000080b8b4000000000f85540100009090"),
    ],
    "die": [
        (0x1917E2, "c680520100000f", "c6805201000001"),
        (0x191912, "c680520100000f", "c6805201000001"),
        (0x3602E0, "c7413cf4010000", "c7413c02000000"),
        (0x35F946, "c74040f4010000", "c7404002000000"),
    ],
    "trial": [
        (0x19B061, "7541", "eb41"),
        (0x476CBF, "0f84d3030000", "909090909090"),
    ],
    "stage": [
        (0x238, "08da1800", "00dc1800"),
        (0x24A5AC, "e8dfe6f6ffe9b9fcffff", "e95f34f4ff9090909090"),
        (0x18DE10, "00" * 356, None),  # code cave v1 trong phần đệm cuối .text
    ],
    "quest": [
        (0x19395E, "e84d0d0200", "e82d914700"),
    ],
}
# 0x1B8F07 có 2 biến thể (né quái / né quái + Thí Luyện) dùng chung byte gốc.
LEGACY_SHARED = [
    (0x1B8F07, "443960440f846d010000488b0d1020ca00f6813301000002740e4439a1e00000007505e8a125f2ff"),
]
# Bản v1 đặt cave nhiệm vụ đè lên 928 byte code ClassAndroid (RVA 0x60DA90). Byte gốc:
LEGACY_QUEST_CAVE_OFFSET = 0x60CA90
LEGACY_QUEST_CAVE_ORIG = bytes.fromhex(
    "89542410534883ec30803d83488a0000752b488d0d57948400e8529db4ff488d0d63318300e8469db4ff488d0df7c483"
    "00e83a9db4ffc60556488a0001488b1d44318300488d4c244833d2e81012f4ff4c8b05d1c483004c8bcb488b0d0f9484"
    "00488bd048c744242000000000e8ceb44b0033d2488bc8e804a4b9ff488bc34883c4305bc3cccccccccccccccccccccc"
    "40534883ec20803df9478a0000488bda7513488d0d97718400e8c29cb4ffc605e1478a0001488b0d84718400f6813301"
    "000002740e83b9e0000000007505e86de9acff33c9e8b648e4ff4885c074134533c0488bd3488bc84883c4205be91ea1"
    "e4ffe8c99db4ffcccccccccccccccccc40534883ec20803d84478a0000488bda7513488d0d27718400e8529cb4ffc605"
    "6c478a0001488b0d14718400f6813301000002740e83b9e0000000007505e8fde8acff33c9e84648e4ff4885c0741345"
    "33c0488bd3488bc84883c4205be94e9ee4ffe8599db4ffcccccccccccccccccc40534883ec20803d18478a0000488bda"
    "7513488d0db7708400e8e29bb4ffc60500478a0001488b0da4708400f6813301000002740e83b9e0000000007505e88d"
    "e8acff33c9e8d647e4ff4885c074134533c0488bd3488bc84883c4205be97e9fe4ffe8e99cb4ffcccccccccccccccccc"
    "4883ec28803dad468a0000752b488d0dd4c18400e8779bb4ff488d0dc8cf8400e86b9bb4ff488d0df4cf8400e85f9bb4"
    "ffc60580468a0001488b05e1cf8400f6803301000002741883b8e000000000750f488bc8e807e8acff488b05c0cf8400"
    "488b80b800000048837858007459488b0d73c18400f6813301000002740e83b9e0000000007505e8d4e7acff33c9e81d"
    "bde2ff4885c07434807810007529488b0d43cf8400f6813301000002740e83b9e0000000007505e8a4e7acff33c94883"
    "c428e969e1d4ff4883c428c3e80f9cb4ffcccccccccccccccccccccccccccccc40534883ec20803dc7458a0000488bda"
    "751f488d0da7c18400e8929ab4ff488d0de3ce8400e8869ab4ffc605a3458a0001488b0d88c184004533c0488bd3e8dd"
    "b44b0033d2488bc8e873a1b9ff488b0d6cc184004533c0488bd3e8c1b44b00488b0da2ce8400488bd8f6813301000002"
    "740e83b9e0000000007505e800e7acff33d2488bcb4883c4205be9a1c6d4ffcc40534883ec20803d3a458a0000488bda"
    "7513488d0d0f7c8200e8029ab4ffc60522458a0001488b0dfc7b82004533c0488bd3e859b44b0033d2488bc8e8efa0b9"
    "ff803d00458a0000752b488d0d27c084"
)

# === BEGIN GENERATED PAYLOAD (mod_src/build_payload.py - khong sua tay) ===
PAYLOAD_CODE_RVA = 0x1216000
PAYLOAD_DATA_RVA = 0x1217000
PAYLOAD_CODE_RAW = 0xf65800
PAYLOAD_DATA_RAW = 0xf66200
PAYLOAD_CODE = bytes.fromhex(
    "0f287c2430498bc6e97f40fafe0f1f00803def0f000000742b488b0dc860c4ff4885c9741f488b89b80000004885c974"
    "130fbf495c81e9a100000083f9060f86eb3efafe803dba0f0000000f84de3efafe6683b8b0000000000f851f40fafe80"
    "b8b4000000000f851240fafee9be3efafe666666666666660f1f840000000000803d820f0000007423e8520600004885"
    "c07419488b80000200004885c0740883784400750233c0e9c35103ff33c9e8dd3bfafe4885c00f85b0010000803d430f"
    "0000000f849e010000488b0d1860c4ff4885c90f8481010000488b89b80000004885c90f84710100000fbf515c8d8a5f"
    "ffffff83f9060f875e0100008b4b5c83f90e0f845201000083f9050f84490100003b15f90e0000741c8915f10e000048"
    "c705ee0e00000000000048c705eb0e000000000000488d0dec0e0000ff15ceb09aff488b05df0e000033d2b910270000"
    "48f7f1488b0dbe0e00004885c9750c488905b20e0000e9fa000000488bd0482bd14881fac40900000f82e7000000488b"
    "c8482b0d980e00004881f9dc0500000f82d0000000488905840e0000813d6a0e0000a7000000751933c933d2e83ff2fa"
    "fe48c7055c0e000000000000e9a4000000488b0d205fc4ff4885c90f8494000000488b89b80000004885c90f84840000"
    "004c8b41604d85c0747b458b50184d8b40104d85c0746e8b15130e0000ffc233c9413bca7d5f413b481873594d8b4cc8"
    "204d85c9740a450fbf591a443bda7404ffc1ebdd410fbf4110410fbf491403c1d1f8410fbf4912410fbf511603cad1f9"
    "f30f2ac8f30f2ad1488bcb4533c9e8bda705ff33c0e9155003ff48c705b30d00000000000033c0e9035003ff48c705a1"
    "0d000000000000e9f34f03ff0f1f400053565741544155415641574883ec40488bd933d2e817f4f9fe803d690d000000"
    "740de8f904000085c00f85f2030000803d510d0000000f8407040000488d4c2430ff1549af9aff488b44243033d2b910"
    "27000048f7f14c8bf8488bc8482b0d4d0d00004881f9f40100000f82d30300004c893d390d0000488b05ea5dc4ff4885"
    "c00f84bc030000488b80b80000004885c00f84ac030000440fbf685c488b05dd3bc4ff4885c00f8497030000488b80b8"
    "0000004885c00f8487030000440fb660160fb605150d0000884424384488250a0d0000418d855fffffff83f8060f8660"
    "030000803df20c000000753b4585e40f844e030000807c2438000f8543030000c605d50c000001c605d00c000000c605"
    "ca0c000000c605c40c00000048c705a90c00000000000033c9e8728103ff4885c00f840c0300004c8bf0418b465c83f8"
    "0e0f84fc02000083f8050f84f3020000488b05815dc4ff4885c00f84e3020000488b80b80000004885c00f84d3020000"
    "488b80800000004885c00f84ea0000008b4818488b50104885d20f84da00000033ff3bf90f8dd00000003b7a180f83c7"
    "000000488b44fa204885c07406837810007404ffc7ebdb488bf0c6051d0c000000c605180c0000008b4614483b35fe0b"
    "000075083b05fe0b00007414488935ed0b00008905ef0b0000c605ef0b00000080bb01020000000f85460200008b4618"
    "85c07e053946147d1a443b6e3c75144585e40f852b020000807c2438000f85f5010000498bc7482b059b0b0000483d40"
    "1f00000f820a020000803d9f0b0000030f83d2010000fe05930b00004c893d750b0000488bcb8d57024c8bc64533c9e8"
    "ecd8f9fe90e9b701000048c7055b0b000000000000410fbe8670010000ffc883f8070f8790010000488d0dc90300000f"
    "b63401443bee7466c6053f0b00000080bb01020000000f8597010000498bc7482b05020b0000483d102700000f828101"
    "0000803d170b0000060f8349010000fe050b0b00004c893ddc0a0000488bcb8bd641b8190000004533c948c744242000"
    "000000e898f4f9fe90e923010000c605db0a000000b91900000033d2e84f33fdfe4885c00f8429010000488bf84c8b07"
    "488bcf498b908001000041ff9078010000f30f114424284c8b07488bcf498b909001000041ff9088010000f30f114424"
    "2cf30f10442428f30f104c242cf3410f1096b8000000f3410f109ebc00000048c744242000000000e823c913ff0f2f05"
    "cc020000723a498bc7482b05280a0000483dd00700000f82a70000004c893d150a0000498bcef30f104c2428f30f1054"
    "242c4533c9e8d6a305ff90e983000000498bc7482b05f6090000483da00f00007271803d050a000004733dfe05fd0900"
    "004c893dd809000033c9e8911402ff4885c0744f488bc8ba190000004533c0440fb60d8109000048c744242000000000"
    "e84bd002ff90eb2bc605bd09000000eb22488b055838c4ff4885c07416488b80b80000004885c0740a0fb6401688059a"
    "0900004883c440415f415e415d415c5f5e5bc366666666660f1f84000000000053564883ec2833f6803d1a090000000f"
    "8499000000488b050438c4ff4885c00f8489000000488b80b80000004885c0747d80781600747733c9e8027e03ff4885"
    "c0746b488bd88b435c83f80e746083f805745b488b05de3fc4ff4885c0744f488b80b80000004885c07443488b401848"
    "85c0743a837818027c34488b40104885c0742b837818007425488b40204885c0741c8b48103b4b60741433d2e86fadfc"
    "fe4885c07408483bc37403488bf0488bc64883c4285e5bc30f1f8400000000005356574883ec30488d4c2420ff155eaa"
    "9aff488b44242033d2b91027000048f7f1488bf8488bc8482b0d9a0800004883f9640f82d900000048893d89080000e8"
    "fcfeffff4885c00f84bd000000488bf0c6056a0800000133c9e8227d03ff4885c00f84aa000000488bd8488b86000200"
    "004885c0741283784400740c48898300020000e98900000048c7830002000000000000f30f1083b8000000f30f5c86b8"
    "0000000f5405760000000f2f05830000007720f30f1083bc000000f30f5c86bc0000000f5405560000000f2f05630000"
    "00763e488bc7482b05f3070000483df4010000722c48893de4070000488bcbf30f108eb8000000f30f1096bc00000045"
    "33c9e869a105ff90eb07c605b0070000000fb605a90700004883c4305f5e5bc3ffffff7fffffff7fffffff7fffffff7f"
    "0000c04100002042010148481b1ba0a0010f08000f720bf009e007d005c0037002600130010603000642026001300000"
    "01070400075203700260013021000000909c1b00cca01b009c57d70021000000909c1b00cca01b009c57d70021000000"
    "93b52400ccb524004482d700000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "00000000000000000000000000000000"
)
PAYLOAD_DATA = bytes.fromhex(
    "48564e4a0200000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "0000000000000000000000000000000000000000000000000000000000000000"
)
PAYLOAD_CFG = {'cfg_block': 0x0, 'cfg_mob': 0x5, 'cfg_stage': 0x6, 'cfg_quest': 0x7, 'cfg_accept': 0x8, 'cfg_party': 0x9}
PAYLOAD_SYMBOLS = {'dgj_ret': 0x1216000, 'dgj_ret_end': 0x121600d, 'dgj_filter': 0x1216010, 'dgj_filter_end': 0x1216071, 'clo_stage': 0x1216080, 'clo_stage_end': 0x121627c, 'quest_tick': 0x1216280, 'party_leader': 0x12166e0, 'party_tick': 0x12167a0, 'cfg_block': 0x1217000, 'cfg_mob': 0x1217005, 'cfg_stage': 0x1217006, 'cfg_quest': 0x1217007, 'cfg_accept': 0x1217008, 'cfg_party': 0x1217009}
PAYLOAD_PDATA = [(0x1216000, 0x121600d, 0x121690c), (0x1216010, 0x1216071, 0x121691c), (0x1216080, 0x121627c, 0x121692c), (0x1216280, 0x12166d3, 0x12168e0), (0x12166e0, 0x1216798, 0x12168f4), (0x12167a0, 0x12168c0, 0x1216900)]
PAYLOAD_HEADER_PATCHES = [
    (0x12e, '0700', '0900'),
    (0x144, '00f2bb00', '00fcbb00'),
    (0x148, '00266500', '00286500'),
    (0x178, '00602101', '00802101'),
    (0x1cc, '80bc0800', 'c8bc0800'),
    (0x2d8, '80bc0800', 'c8bc0800'),
    (0x348, '00000000000000000000000000000000000000000000000000000000000000000000000000000000', '2e68766e6a0000003c09000000602101000a00000058f60000000000000000000000000020000060'),
    (0x370, '00000000000000000000000000000000000000000000000000000000000000000000000000000000', '2e68766e6a6400000001000000702101000200000062f600000000000000000000000000400000c0'),
    (0xf39c80, '000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000', '006021010d6021010c69210110602101716021011c692101806021017c6221012c69210180622101d3662101e0682101e066210198672101f4682101a0672101c068210100692101'),
]
PAYLOAD_HOOKS = {
    'core': [
        (0x1b9db1, '0f84ce020000', '660f1f440000'),
        (0x1b9dfc, '0f8d83020000', '0f8dfec10501'),
        (0x1b9e4b, '8b70', 'eb67'),
        (0x1b9f11, '488b0d1020ca00f6813301000002740e4439a1e00000007505e8a125f2ff', 'e9fac00501cccccccccccccccccccccccccccccccccccccccccccccccccc'),
    ],
    'mob': [
        (0x1ba485, '3968440f846f010000488b0d931aca00f6813301000002740d39a9e00000007505e82520f2ff', '3968440f846f0100006683b8b0000000000f856101000080b8b4000000000f85540100009090'),
    ],
    'clo': [
        (0x24b5ac, 'e8dfe6f6ffe9b9fcffff', 'e9cfaafc00cccccccccc'),
    ],
    'tick': [
        (0x19495e, 'e84d0d0200', 'e81d190801'),
    ],
}
PAYLOAD_HOOK_USERS = {'core': ('mob', 'stage'), 'mob': ('mob',), 'clo': ('stage', 'party'), 'tick': ('quest', 'party')}
# === END GENERATED PAYLOAD ===


class PatchError(Exception):
    pass


def sha256(data):
    return hashlib.sha256(data).hexdigest()


def section_table(data):
    pe = struct.unpack_from("<I", data, 0x3C)[0]
    nsec = struct.unpack_from("<H", data, pe + 6)[0]
    opt_size = struct.unpack_from("<H", data, pe + 20)[0]
    table = pe + 24 + opt_size
    secs = []
    for i in range(nsec):
        o = table + 40 * i
        name = data[o:o + 8].rstrip(b"\0").decode("ascii", "replace")
        vsize, va, rsize, raw = struct.unpack_from("<IIII", data, o + 8)
        secs.append((name, va, vsize, raw, rsize))
    return secs


def rva_to_off(data, rva):
    for _name, va, vsize, raw, rsize in section_table(data):
        if va <= rva < va + max(vsize, rsize):
            return rva - va + raw
    raise PatchError(f"RVA {rva:#x} không thuộc section nào")


def read_at(data, rva, n):
    off = rva_to_off(data, rva)
    return bytes(data[off:off + n])


def has_payload(data):
    return any(s[0] == ".hvnj" for s in section_table(data))


# ==============================================================================
# KHÔI PHỤC BẢN GỐC
# ==============================================================================
def strip_payload(data):
    """DLL do script này tạo -> bản gốc (cắt section mới, trả byte gốc)."""
    buf = bytearray(data[:ORIGINAL_SIZE])
    for off, o, _n in PAYLOAD_HEADER_PATCHES:
        ob = bytes.fromhex(o)
        buf[off:off + len(ob)] = ob
    for lst in list(SIMPLE_PATCHES.values()) + list(RETIRED_PATCHES.values()) + list(PAYLOAD_HOOKS.values()):
        for rva, o, _n in lst:
            off = rva_to_off(buf, rva)
            ob = bytes.fromhex(o)
            buf[off:off + len(ob)] = ob
    return bytes(buf)


def strip_legacy(data):
    """Bản mod cũ v1 -> bản gốc: ghi lại byte gốc ở mọi vị trí v1 từng sửa
    (kết quả được kiểm tra lại bằng SHA-256 ở nơi gọi)."""
    if len(data) != ORIGINAL_SIZE:
        return None
    buf = bytearray(data)
    entries = [(off, o) for lst in LEGACY_PATCHES.values() for off, o, _p in lst] + LEGACY_SHARED
    for off, o in entries:
        ob = bytes.fromhex(o)
        buf[off:off + len(ob)] = ob
    off = LEGACY_QUEST_CAVE_OFFSET
    buf[off:off + len(LEGACY_QUEST_CAVE_ORIG)] = LEGACY_QUEST_CAVE_ORIG
    return bytes(buf)


def find_original(dll_path):
    """Trả về (bytes gốc, nguồn)."""
    cur = open(dll_path, "rb").read()
    if sha256(cur) == ORIGINAL_SHA256:
        return cur, "file hiện tại"
    bak = dll_path + BAK_SUFFIX
    if os.path.exists(bak):
        b = open(bak, "rb").read()
        if sha256(b) == ORIGINAL_SHA256:
            return b, os.path.basename(bak)
        rec = strip_payload(b) if has_payload(b) else strip_legacy(b)
        if rec is not None and sha256(rec) == ORIGINAL_SHA256:
            return rec, f"khôi phục từ {os.path.basename(bak)}"
    rec = strip_payload(cur) if has_payload(cur) else strip_legacy(cur)
    if rec is not None and sha256(rec) == ORIGINAL_SHA256:
        return rec, "khôi phục từ DLL đã mod"
    raise PatchError(
        "Không tìm được GameAssembly.dll gốc của bản 186 (SHA-256 không khớp).\n"
        "    Có thể game đã cập nhật phiên bản khác - các offset của mod không còn đúng.\n"
        "    Hãy cài lại / kiểm tra file game để có GameAssembly.dll bản 186 gốc rồi chạy lại.")


# ==============================================================================
# NHẬN DIỆN TRẠNG THÁI
# ==============================================================================
def detect_retired(data):
    """Các tính năng đã gỡ nhưng vẫn còn trong DLL."""
    return {feat for feat, lst in RETIRED_PATCHES.items()
            if all(read_at(data, rva, len(n) // 2) == bytes.fromhex(n) for rva, _o, n in lst)}


def detect(data):
    """Trả về (tập tính năng đang bật, cfg_accept, kiểu bản build)."""
    if sha256(data) == ORIGINAL_SHA256:
        return set(), 0, "gốc"
    if len(data) == ORIGINAL_SIZE and not has_payload(data):
        legacy = set()
        for feat, lst in LEGACY_PATCHES.items():
            if all(data[off:off + len(p) // 2] == bytes.fromhex(p) for off, _o, p in lst if p):
                legacy.add(feat)
        # skill/die của v1 và v2 giống hệt byte; chỉ coi là v1 khi có dấu vết riêng của v1
        if legacy & {"mob", "trial", "stage", "quest"}:
            return legacy & set(FEATURES), 0, "mod cũ v1"
    on = set()
    for feat, lst in SIMPLE_PATCHES.items():
        if all(read_at(data, rva, len(n) // 2) == bytes.fromhex(n) for rva, _o, n in lst):
            on.add(feat)
    accept = 0
    if has_payload(data):
        cfg = rva_to_off(data, PAYLOAD_DATA_RVA)
        accept = data[cfg + PAYLOAD_CFG["cfg_accept"]]
        for feat in PAYLOAD_FEATURES:
            # so với byte GỐC (không so byte mới) để nhận được cả DLL dựng từ payload cũ hơn
            hooks = [h for g, users in PAYLOAD_HOOK_USERS.items() if feat in users for h in PAYLOAD_HOOKS[g]]
            if data[cfg + PAYLOAD_CFG["cfg_" + feat]] and \
                    all(read_at(data, rva, len(o) // 2) != bytes.fromhex(o) for rva, o, _n in hooks):
                on.add(feat)
    return on, accept, "mod v2"


# ==============================================================================
# DỰNG DLL
# ==============================================================================
def build(original, features, accept_option):
    buf = bytearray(original)

    def put(rva, o, n):
        off = rva_to_off(buf, rva)
        ob, nb = bytes.fromhex(o), bytes.fromhex(n)
        if buf[off:off + len(ob)] != ob:
            raise PatchError(f"Byte gốc không khớp tại RVA {rva:#x}")
        buf[off:off + len(nb)] = nb

    for feat in ("die", "trial"):
        if feat in features:
            for rva, o, n in SIMPLE_PATCHES[feat]:
                put(rva, o, n)

    if features & set(PAYLOAD_FEATURES):
        for off, o, n in PAYLOAD_HEADER_PATCHES:
            ob, nb = bytes.fromhex(o), bytes.fromhex(n)
            if buf[off:off + len(ob)] != ob:
                raise PatchError(f"PE header không khớp tại {off:#x}")
            buf[off:off + len(nb)] = nb
        assert len(buf) == PAYLOAD_CODE_RAW
        data = bytearray(PAYLOAD_DATA)
        for feat in PAYLOAD_FEATURES:
            data[PAYLOAD_CFG["cfg_" + feat]] = 1 if feat in features else 0
        data[PAYLOAD_CFG["cfg_accept"]] = accept_option
        buf += PAYLOAD_CODE
        assert len(buf) == PAYLOAD_DATA_RAW
        buf += data
        for group, users in PAYLOAD_HOOK_USERS.items():
            if features & set(users):
                for rva, o, n in PAYLOAD_HOOKS[group]:
                    put(rva, o, n)
    return bytes(buf)


def write_atomic(path, data):
    tmp = path + ".tmp"
    with open(tmp, "wb") as f:
        f.write(data)
    try:
        os.replace(tmp, path)
    except PermissionError:
        os.remove(tmp)
        raise PatchError(f"Không ghi được {path}. Hãy tắt game trước khi chạy script.")


def ensure_backup(dll_path, original):
    bak = dll_path + BAK_SUFFIX
    if os.path.exists(bak):
        if sha256(open(bak, "rb").read()) == ORIGINAL_SHA256:
            return
        keep = bak + ".khong-phai-ban-goc"
        os.replace(bak, keep)
        print(f"[!] {os.path.basename(bak)} không phải bản gốc -> đổi tên thành {os.path.basename(keep)}")
    write_atomic(bak, original)
    print(f"[+] Đã lưu bản gốc vào {os.path.basename(bak)}")


def print_status(dll_path):
    data = open(dll_path, "rb").read()
    on, accept, kind = detect(data)
    print(f"=== TRẠNG THÁI {dll_path} ({kind}) ===")
    for feat in FEATURES:
        print(f"[{'BẬT' if feat in on else '   '}] {FEATURE_NAMES[feat]}")
    if "quest" in on:
        print(f"      menu nhận nhiệm vụ: menu(25, 0, {accept})")
    if "skill" in detect_retired(data):
        print("[!] Còn patch 'tốc độ ra chiêu 0.3s' (đã gỡ vì chỉ làm chậm hiệu ứng). Chạy lại script để gỡ.")
    if kind == "mod cũ v1":
        print("[!] Đây là bản mod cũ (có lỗi crash). Chạy lại với --all hoặc các cờ tính năng để cập nhật.")
    print("=" * 50)


def main(argv=None):
    ap = argparse.ArgumentParser(description="Bản mod Học Viện Ninja 186")
    ap.add_argument("--dll", default=GAME_DLL, help="đường dẫn GameAssembly.dll (mặc định: thư mục hiện tại)")
    ap.add_argument("--all", "--full", action="store_true", help=f"bật cả {len(FEATURES)} tính năng")
    ap.add_argument("--skill", action="store_true", help=argparse.SUPPRESS)  # đã gỡ
    ap.add_argument("--mob", action="store_true", help="né quái tinh anh / thủ lĩnh / boss")
    ap.add_argument("--die", action="store_true", help="chết quay về ngay")
    ap.add_argument("--trial", action="store_true", help="giữ Auto trong Thí Luyện")
    ap.add_argument("--stage", "--progression", action="store_true", help="tự qua ải Thí Luyện")
    ap.add_argument("--quest", "--daily", action="store_true", help="auto nhiệm vụ hàng ngày")
    ap.add_argument("--party", action="store_true", help="đánh theo nhóm: chạy theo & đánh cùng quái với trưởng nhóm")
    ap.add_argument("--remove", nargs="+", choices=FEATURES, metavar="TÍNH_NĂNG", help="tắt tính năng")
    ap.add_argument("--accept-option", type=int, choices=range(0, 16), metavar="N",
                    help="optionId để NHẬN nhiệm vụ ở NPC 25: menu(25, 0, N). Mặc định 0")
    ap.add_argument("--restore", action="store_true", help="khôi phục GameAssembly.dll gốc")
    ap.add_argument("--status", action="store_true", help="xem trạng thái")
    args = ap.parse_args(argv)

    dll = args.dll
    if not os.path.exists(dll):
        print(f"[-] Không tìm thấy {dll}. Chạy script trong thư mục game hoặc dùng --dll.")
        return 1
    if args.skill:
        print("[!] Tính năng 'tốc độ ra chiêu 0.3s' đã bị gỡ: patch cũ chỉ làm hiệu ứng skill chạy chậm,"
              " không giảm hồi chiêu.")
    requested = {f for f in FEATURES if args.all or getattr(args, f)}
    if not (requested or args.remove or args.restore or args.status or args.accept_option is not None):
        ap.print_help()
        return 0
    try:
        if args.status:
            print_status(dll)
            return 0
        original, source = find_original(dll)
        print(f"[*] Bản gốc: {source}")
        ensure_backup(dll, original)
        if args.restore:
            write_atomic(dll, original)
            print(f"[+] Đã khôi phục {dll} về bản gốc.")
        else:
            current, accept, _kind = detect(open(dll, "rb").read())
            features = (current | requested) - set(args.remove or [])
            if args.accept_option is not None:
                accept = args.accept_option
            write_atomic(dll, build(original, features, accept))
            print(f"[+] Đã ghi {dll} với: {', '.join(sorted(features)) or '(không tính năng nào)'}")
        print_status(dll)
    except PatchError as e:
        print(f"[-] {e}")
        return 1
    return 0


if __name__ == "__main__":
    sys.exit(main())
