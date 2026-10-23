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

for _stream in (sys.stdout, sys.stderr):  # stderr: thông báo lỗi tham số của argparse
    if hasattr(_stream, "reconfigure"):
        _stream.reconfigure(encoding="utf-8", errors="replace")

GAME_DLL = "GameAssembly.dll"
BAK_SUFFIX = ".bak"
ORIGINAL_SHA256 = "a17ddc0b955ca4c4ada07feac0d18a1d8f7232d64b6f654c405669419f92df25"
ORIGINAL_SIZE = 0xF65800

FEATURES = ["mob", "die", "trial", "stage", "quest", "party", "stone"]
FEATURE_NAMES = {
    "mob": "1. Né quái Tinh Anh / Thủ Lĩnh / Boss khi Auto",
    "die": "2. Chết: về làng ngay, quay lại map cũ, bật lại Auto",
    "trial": "3. Giữ Auto & tìm đường trong Thí Luyện",
    "stage": "4. Tự qua ải Thí Luyện 161 -> 167, dừng ở ải cuối",
    "quest": "5. Auto nhiệm vụ hàng ngày (dùng auto nhiệm vụ của game)",
    "party": "6. Đánh theo nhóm (chạy theo & đánh cùng quái với trưởng nhóm)",
    "stone": "7. Tự luyện đá tại chỗ khi hành trang đầy (lúc Auto, chỉ luyện 100%)",
}
PAYLOAD_FEATURES = ("mob", "stage", "quest", "party", "die", "stone")
# "die" nhận diện theo patch đơn giản (giống mọi bản cũ); các tính năng còn lại theo cờ cfg + hook
DETECT_BY_CFG = ("mob", "stage", "quest", "party", "stone")
STONE_PAY = {False: "yên (đá ra bị khóa)", True: "xu (đá không khóa vẫn không khóa)"}
STONE_LEVEL_MAX = 12        # đá cấp 12 là cấp cao nhất
STONE_LEVELS_ALL = (0, 0)   # cfg_stone_lo/hi = 0: dùng mọi cấp, không cất rương

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
PAYLOAD_DATA_RVA = 0x1218000
PAYLOAD_CODE_RAW = 0xf65800
PAYLOAD_DATA_RAW = 0xf66c00
PAYLOAD_CODE = bytes.fromhex(
    "0f287c2430498bc6e97f40fafe0f1f00803def1f000000742b488b0dc860c4ff4885c9741f488b89b80000004885c974"
    "130fbf495c81e9a100000083f9060f86eb3efafe803dba1f0000000f84de3efafe6683b8b0000000000f851f40fafe80"
    "b8b4000000000f851240fafee9be3efafe666666666666660f1f840000000000803d821f0000007423e8e20600004885"
    "c07419488b80000200004885c0740883784400750233c0e9c35103ff33c9e8dd3bfafe4885c00f8520020000803d431f"
    "0000000f840e020000488b0d1860c4ff4885c90f84f1010000488b89b80000004885c90f84e10100000fbf515c8d8a5f"
    "ffffff83f9060f87ce0100008b4b5c83f90e0f84c201000083f9050f84b90100003b15f91e0000741c8915f11e000048"
    "c705ee1e00000000000048c705eb1e000000000000488d0dec1e0000ff15ceb09aff488b05df1e000033d2b910270000"
    "48f7f1803daf1e00000074318b0dae1e00003b0dac1e00007523c705a01e0000ffffffff488d883cf6ffff48890d961e"
    "000048c705931e000000000000488b0d841e00004885c9750c488905781e0000e930010000488bd0482bd14881fac409"
    "00000f821d010000488bc8482b0d5e1e00004881f9dc0500000f82060100004889054a1e0000813d301e0000a7000000"
    "751933c933d2e805f2fafe48c705221e000000000000e9da000000488b0de65ec4ff4885c90f84ca000000488b89b800"
    "00004885c90f84ba0000004c8b41604d85c00f84ad000000458b50184d8b40104d85c00f849c0000008b15d11d000033"
    "c933c0413bca7d44413b4818733e4d8b4cc8204d85c97430450fbf5918443bda7526450fbf591a442bda4183fb017424"
    "7c164885c07511450fbf591a4181fba70000007f03498bc1ffc1ebb74885c074444c8bc8410fbf4110410fbf491403c1"
    "d1f8410fbf4912410fbf511603cad1f9f30f2ac8f30f2ad1488bcb4533c9e84da705ff33c0e9a54f03ff48c705431d00"
    "000000000033c0e9934f03ff48c705311d000000000000e9834f03ff0f1f400053565741544155415641574883ec4048"
    "8bd933d2e8a7f3f9fe803dfb1c0000007405e829090000803dec1c0000007410488bcbe85806000085c00f8508040000"
    "803dd21c000000740de8f204000085c00f85f2030000803dba1c0000000f8407040000488d4c2430ff15b2ae9aff488b"
    "44243033d2b91027000048f7f14c8bf8488bc8482b0db61c00004881f9f40100000f82d30300004c893da21c0000488b"
    "05535dc4ff4885c00f84bc030000488b80b80000004885c00f84ac030000440fbf685c488b05463bc4ff4885c00f8497"
    "030000488b80b80000004885c00f8487030000440fb660160fb6057e1c000088442438448825731c0000418d855fffff"
    "ff83f8060f8660030000803d5b1c000000753b4585e40f844e030000807c2438000f8543030000c6053e1c000001c605"
    "391c000000c605331c000000c6052d1c00000048c705121c00000000000033c9e8db8003ff4885c00f840c0300004c8b"
    "f0418b465c83f80e0f84fc02000083f8050f84f3020000488b05ea5cc4ff4885c00f84e3020000488b80b80000004885"
    "c00f84d3020000488b80800000004885c00f84ea0000008b4818488b50104885d20f84da00000033ff3bf90f8dd00000"
    "003b7a180f83c7000000488b44fa204885c07406837810007404ffc7ebdb488bf0c605861b000000c605811b0000008b"
    "4614483b35671b000075083b05671b00007414488935561b00008905581b0000c605581b00000080bb01020000000f85"
    "460200008b461885c07e053946147d1a443b6e3c75144585e40f852b020000807c2438000f85f5010000498bc7482b05"
    "041b0000483d401f00000f820a020000803d081b0000030f83d2010000fe05fc1a00004c893dde1a0000488bcb8d5702"
    "4c8bc64533c9e855d8f9fe90e9b701000048c705c41a000000000000410fbe8670010000ffc883f8070f879001000048"
    "8d0de20c00000fb63401443bee7466c605a81a00000080bb01020000000f8597010000498bc7482b056b1a0000483d10"
    "2700000f8281010000803d801a0000060f8349010000fe05741a00004c893d451a0000488bcb8bd641b8190000004533"
    "c948c744242000000000e801f4f9fe90e923010000c605441a000000b91900000033d2e8b832fdfe4885c00f84290100"
    "00488bf84c8b07488bcf498b908001000041ff9078010000f30f114424284c8b07488bcf498b909001000041ff908801"
    "0000f30f1144242cf30f10442428f30f104c242cf3410f1096b8000000f3410f109ebc00000048c744242000000000e8"
    "8cc813ff0f2f05e50b0000723a498bc7482b0591190000483dd00700000f82a70000004c893d7e190000498bcef30f10"
    "4c2428f30f1054242c4533c9e83fa305ff90e983000000498bc7482b055f190000483da00f00007271803d6e19000004"
    "733dfe05661900004c893d4119000033c9e8fa1302ff4885c0744f488bc8ba190000004533c0440fb60dea18000048c7"
    "44242000000000e8b4cf02ff90eb2bc6052619000000eb22488b05c137c4ff4885c07416488b80b80000004885c0740a"
    "0fb640168805031900004883c440415f415e415d415c5f5e5bc3660f1f44000053564883ec2833f6803d8a180000000f"
    "8499000000488b057437c4ff4885c00f8489000000488b80b80000004885c0747d80781600747733c9e8727d03ff4885"
    "c0746b488bd88b435c83f80e746083f805745b488b054e3fc4ff4885c0744f488b80b80000004885c07443488b401848"
    "85c0743a837818027c34488b40104885c0742b837818007425488b40204885c0741c8b48103b4b60741433d2e8dfacfc"
    "fe4885c07408483bc37403488bf0488bc64883c4285e5bc30f1f8400000000005356574883ec30488d4c2420ff15cea9"
    "9aff488b44242033d2b91027000048f7f1488bf8488bc8482b0d0a1800004883f9640f82fb00000048893df9170000e8"
    "fcfeffff4885c00f84df000000488bf0c605da17000001488b055a58c4ff4885c07416488b80b80000004885c0740a0f"
    "bf405c89056b17000033c9e8707c03ff4885c00f84aa000000488bd8488b86000200004885c0741283784400740c4889"
    "8300020000e98900000048c7830002000000000000f30f1083b8000000f30f5c86b80000000f5405740900000f2f0581"
    "0900007720f30f1083bc000000f30f5c86bc0000000f5405540900000f2f0561090000763e488bc7482b054117000048"
    "3df4010000722c48893d32170000488bcbf30f108eb8000000f30f1096bc0000004533c9e8b7a005ff90eb07c605fe16"
    "0000000fb605f71600004883c4305f5e5bc36666666666660f1f84000000000053565741544883ec38488bd9488d4c24"
    "28ff1579a89aff488b44242833d2b91027000048f7f14c8be0488bc8482b0dc51600004881f9c80000000f8267020000"
    "4c8925b1160000c605d71600000033c9e84b7b03ff4885c00f8449020000488bf0488b050057c4ff4885c00f84360200"
    "00488b80b80000004885c00f84260200000fbf785c8b465c83f80e0f842101000083f8050f8418010000803d83160000"
    "000f8400020000803d2e160000000f85e30100003b3d66160000756b488b05bd34c4ff4885c00f84d4010000488b80b8"
    "0000004885c00f84c4010000807816000f85b1010000488b052b1600004885c07514498d8424dc050000488905171600"
    "00e99a0100004c3be00f8291010000b10133d2e858e9fafeb10133d2e85febfafe90e97001000048c705e61500000000"
    "000033c9e8270426ff4885c00f845e01000080b8fc000000000f855101000080bb01020000000f8544010000498bc448"
    "2b05aa150000483d102700000f822e010000803dad150000060f8318010000fe05a11500004c892584150000488bcb8b"
    "158b15000041b8ffffffff4533c948c744242000000000e8e4eef9fe90e9ee0000008d875fffffff83f8060f86e60000"
    "00803d5c150000007574488b05af33c4ff4885c00f84cd000000488b80b80000004885c00f84bd00000080781600751d"
    "33c9e8690326ff4885c00f84a700000080b8fc000000000f849a000000c6051015000001893d061500004c8925df1400"
    "0048c705e41400000000000048c705e114000000000000c605e814000000498bc4482b05b8140000483dd00700007250"
    "498bc4482b05ae140000483db80b0000723e33c9e8f70226ff4885c0743280b8fc0000000075294c89258a14000033c9"
    "e8fb0e02ff4885c07416488bc833d2e80c5c02ff90eb09c6058614000000eb07c6057e140000010fb605771400004883"
    "c438415c5f5e5bc30f1f8400000000005355565741544155415641574883ec68488d4c2420ff15b5a59aff488b442420"
    "33d2b91027000048f7f14c8bf8488bc8482b0d311400004881f9e80300000f82cf0500004c893d1d1400004c3b3d1e14"
    "00000f82bb050000488b056132c4ff4885c00f84ab050000488b80b80000004885c00f849b050000807816000f849105"
    "0000488b058f3fc4ff4885c00f8481050000488b80b80000004885c00f8471050000488b88280100004885c97421488b"
    "05fb35c4ff4885c07415488b80b80000004885c07409483b080f844405000033c9e80a7803ff4885c00f843405000048"
    "8bd88b435c83f80e0f842505000083f8050f841c050000488bb3b80100004885f60f840c050000488b05d253c4ff4885"
    "c00f84fc040000488b80b80000004885c00f84ec0400004c8ba0080100004d85e40f84dc0400004c8ba8d00000004d85"
    "ed0f84cc040000418b442418418b4d183bc80f42c1b90c0000003bc10f47c1ffc80fb60d6612000085c97407ffc93bc1"
    "0f47c183f8010f8c97040000448bf0488d3d0a13000033c0b918000000f3ab440fb61d361200004585db740341ffcb4c"
    "8d15ea120000448b4e1833ffbdffffffff33c9413bc97368488b44ce204885c07504ffc7eb56488b50104885d2744d80"
    "7a121a754780785e0075410fbf5210440fb605e71100004585c0741041ffc8413bd0750885ed79248be9eb20413bd673"
    "1b413bd37216803dbf11000000740980783800740383c20c41ff0492ffc1eb93488b05511200004885c0747148c70541"
    "120000000000008b0d4b120000413bc97354483b44ce20754dfe053d120000803d36120000027245c6052d1200000080"
    "3d2712000000751cc6051f12000000498bc74805e0930400488905f1110000e98f030000498bc7480540771b00488905"
    "ec110000eb6cc605ef1100000085ed78614c3b3dd81100007258488b83c00100004885c0744c448b481833c9413bc973"
    "4148837cc820007404ffc1ebef488b44ee204889059f110000892da91100008b502888150812000041be01000000c605"
    "9811000001c744242811000000e935020000803d8511000000751083ff010f87ff020000c6057311000001488d3d6e11"
    "0000bd01000000413bee0f8f8b0000004d6344ac204d85c07e7a4533d24533db8d4dff4d634c8c2033c04d85c97e3149"
    "8bc0492bc233d249f7f18b148f483bc2480f47c2ba18000000412bd3483bc2480f47c24403d8488bd0490fafd14c03d2"
    "89448c30ffc979bb4d3bd075274183fb027221496344ad20488b9340010000803d261000000075074803935001000048"
    "3bc27e2cffc5e96cffffff803d0a100000000f8434020000488d05f1100000483bf80f8424020000488bf8e942ffffff"
    "488d05d91000004533c9483bf8410f94c1448b5618488d3df410000033c94533db413bca7372488b44ce204885c07464"
    "488b50104885d2745b807a121a75550fbf52103bd5734d80785e007547803d980f0000007411440fb640384585c0410f"
    "95c0453bc1752d837c9430007426ff4c94308b50284288141f4585db750d48890513100000890d1d10000041ffc34183"
    "fb187304ffc1eb894183fb020f826f010000458bf3c6050110000000c744242814000000803d310f0000007408c74424"
    "2813000000488d0d0432c4ffe80f07f4fe488b0df831c4ff4885c90f8430010000f6813301000002741583b9e0000000"
    "00750ce8b853ecfe488b0dd131c4ff488b81b80000004885c00f840201000048837808007541488d0ddbe2c2ffe8be06"
    "f4fe488b0dcfe2c2ff4885c90f84df000000ba18000000e8a402f4fe4885c00f84cc000000488b0d8431c4ff488b89b8"
    "0000004889410833c9e8820902ff4885c00f84aa000000488be848837d10000f849c000000488d0d842cc4ffe85f06f4"
    "fe488d0d403ac4ffe85306f4fe488b0d6c2cc4ff4885c97478e85207f4fe4885c0746e488bf8488bc88b5424284533c0"
    "e87b1f22ff33f6413bf67320488b4f204885c9744c488d05440f00000fb614304533c0e888560effffc6ebdb4c8b4510"
    "4d85c0742c488b15dc39c4ff4885d27420b9030000004c8bcfe8c2badefe90498bc74805b80b0000488905810e0000eb"
    "2248c7057c0e000000000000c6058b0e000000498bc74805307500004889055d0e00004883c468415f415e415d415c5f"
    "5e5d5bc3666666660f1f840000000000ffffff7fffffff7fffffff7fffffff7f0000c04100002042010148481b1ba0a0"
    "010f08000f720bf009e007d005c003700260013001060300064202600130000001070400075203700260013001090500"
    "096205c003700260013000000110090010c20cf00ae008d006c00470036002500130000021000000909c1b00cca01b00"
    "9c57d70021000000909c1b00cca01b009c57d7002100000093b52400ccb524004482d700000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "0000000000000000000000000000000000000000000000000000000000000000"
)
PAYLOAD_DATA = bytes.fromhex(
    "48564e4a02000000000000000000000000000000ffffffff000000000000000000000000000000000000000000000000"
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
PAYLOAD_CFG = {'cfg_block': 0x0, 'cfg_mob': 0x5, 'cfg_stage': 0x6, 'cfg_quest': 0x7, 'cfg_accept': 0x8, 'cfg_party': 0x9, 'cfg_die': 0xa, 'cfg_stone': 0xb, 'cfg_stone_xu': 0xc, 'cfg_stone_lo': 0xd, 'cfg_stone_hi': 0xe}
PAYLOAD_SYMBOLS = {'dgj_ret': 0x1216000, 'dgj_ret_end': 0x121600d, 'dgj_filter': 0x1216010, 'dgj_filter_end': 0x1216071, 'clo_stage': 0x1216080, 'clo_stage_end': 0x12162ec, 'quest_tick': 0x12162f0, 'party_leader': 0x1216770, 'party_tick': 0x1216830, 'die_tick': 0x1216980, 'stone_tick': 0x1216c40, 'cfg_block': 0x1218000, 'cfg_mob': 0x1218005, 'cfg_stage': 0x1218006, 'cfg_quest': 0x1218007, 'cfg_accept': 0x1218008, 'cfg_party': 0x1218009, 'cfg_die': 0x121800a, 'cfg_stone': 0x121800b, 'cfg_stone_xu': 0x121800c, 'cfg_stone_lo': 0x121800d, 'cfg_stone_hi': 0x121800e}
PAYLOAD_PDATA = [(0x1216000, 0x121600d, 0x12172e4), (0x1216010, 0x1216071, 0x12172f4), (0x1216080, 0x12162ec, 0x1217304), (0x12162f0, 0x121676a, 0x1217290), (0x1216770, 0x1216828, 0x12172a4), (0x1216830, 0x1216972, 0x12172b0), (0x1216980, 0x1216c38, 0x12172bc), (0x1216c40, 0x1217264, 0x12172cc)]
PAYLOAD_HEADER_PATCHES = [
    (0x12e, '0700', '0900'),
    (0x144, '00f2bb00', '0006bc00'),
    (0x148, '00266500', '00286500'),
    (0x178, '00602101', '00902101'),
    (0x1cc, '80bc0800', 'e0bc0800'),
    (0x2d8, '80bc0800', 'e0bc0800'),
    (0x348, '00000000000000000000000000000000000000000000000000000000000000000000000000000000', '2e68766e6a0000001413000000602101001400000058f60000000000000000000000000020000060'),
    (0x370, '00000000000000000000000000000000000000000000000000000000000000000000000000000000', '2e68766e6a640000480100000080210100020000006cf600000000000000000000000000400000c0'),
    (0xf39c80, '000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000', '006021010d602101e47221011060210171602101f472210180602101ec62210104732101f06221016a672101907221017067210128682101a47221013068210172692101b072210180692101386c2101bc722101406c210164722101cc722101'),
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
        (0x19495e, 'e84d0d0200', 'e88d190801'),
    ],
}
PAYLOAD_HOOK_USERS = {'core': ('mob', 'stage'), 'mob': ('mob',), 'clo': ('stage', 'party'), 'tick': ('quest', 'party', 'die', 'stone')}
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


def cfg_offset(data):
    """File offset của khối cfg (đầu section .hvnjd). Tìm theo section chứ không theo
    PAYLOAD_DATA_RVA vì DLL dựng từ payload cũ hơn có thể đặt .hvnjd ở RVA khác."""
    return next(raw for name, _va, _vs, raw, _rs in section_table(data) if name == ".hvnjd")


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
        cfg = cfg_offset(data)
        accept = data[cfg + PAYLOAD_CFG["cfg_accept"]]
        for feat in DETECT_BY_CFG:
            # so với byte GỐC (không so byte mới) để nhận được cả DLL dựng từ payload cũ hơn
            hooks = [h for g, users in PAYLOAD_HOOK_USERS.items() if feat in users for h in PAYLOAD_HOOKS[g]]
            if data[cfg + PAYLOAD_CFG["cfg_" + feat]] and \
                    all(read_at(data, rva, len(o) // 2) != bytes.fromhex(o) for rva, o, _n in hooks):
                on.add(feat)
    return on, accept, "mod v2"


def detect_stone_xu(data):
    """True nếu luyện đá đang trả phí bằng xu (mặc định: yên)."""
    if not has_payload(data):
        return False
    return bool(data[cfg_offset(data) + PAYLOAD_CFG["cfg_stone_xu"]])


def detect_stone_levels(data):
    """(A, B): luyện dần từ đá cấp A lên đá cấp B, đá cấp B cất vào rương; STONE_LEVELS_ALL = mọi cấp."""
    if not has_payload(data):
        return STONE_LEVELS_ALL
    cfg = cfg_offset(data)
    lo, hi = data[cfg + PAYLOAD_CFG["cfg_stone_lo"]], data[cfg + PAYLOAD_CFG["cfg_stone_hi"]]
    return (lo, hi) if lo and hi else STONE_LEVELS_ALL


def parse_stone_levels(text):
    """'A-B' (từ cấp A lên cấp B), 'B' (= 1-B) hoặc 'all' -> (A, B) / STONE_LEVELS_ALL (type cho argparse)."""
    t = text.strip().lower()
    if t in ("all", "tat-ca"):
        return STONE_LEVELS_ALL
    try:
        lo, sep, hi = t.partition("-")
        lo, hi = (int(lo), int(hi)) if sep else (1, int(lo))
    except ValueError:
        raise argparse.ArgumentTypeError(f"'{text}' không đúng dạng A-B (vd 1-6), B (vd 6) hoặc all")
    if not 1 <= lo < hi <= STONE_LEVEL_MAX:
        raise argparse.ArgumentTypeError(
            f"cần 1 <= A < B <= {STONE_LEVEL_MAX}: luyện từ đá cấp A lên đá cấp B (nhận '{text}')")
    return lo, hi


def describe_stone_levels(levels):
    if levels == STONE_LEVELS_ALL:
        return f"mọi cấp đá (lên tối đa cấp {STONE_LEVEL_MAX}), không cất rương"
    lo, hi = levels
    return f"dần từ đá cấp {lo} lên đá cấp {hi}, đá cấp {hi} cất vào rương đồ"


# ==============================================================================
# DỰNG DLL
# ==============================================================================
def build(original, features, accept_option, stone_xu=False, stone_levels=STONE_LEVELS_ALL):
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
        data[PAYLOAD_CFG["cfg_stone_xu"]] = 1 if stone_xu else 0
        data[PAYLOAD_CFG["cfg_stone_lo"]], data[PAYLOAD_CFG["cfg_stone_hi"]] = stone_levels
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
    if "stone" in on:
        print(f"      trả phí luyện đá bằng {STONE_PAY[detect_stone_xu(data)]}")
        print(f"      luyện: {describe_stone_levels(detect_stone_levels(data))}")
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
    ap.add_argument("--die", action="store_true", help="chết: về làng ngay, quay lại map cũ, bật lại Auto")
    ap.add_argument("--trial", action="store_true", help="giữ Auto trong Thí Luyện")
    ap.add_argument("--stage", "--progression", action="store_true", help="tự qua ải Thí Luyện")
    ap.add_argument("--quest", "--daily", action="store_true", help="auto nhiệm vụ hàng ngày")
    ap.add_argument("--party", action="store_true", help="đánh theo nhóm: chạy theo & đánh cùng quái với trưởng nhóm")
    ap.add_argument("--stone", action="store_true", help="tự luyện đá tại chỗ khi hành trang đầy (lúc Auto)")
    ap.add_argument("--remove", nargs="+", choices=FEATURES, metavar="TÍNH_NĂNG", help="tắt tính năng")
    ap.add_argument("--accept-option", type=int, choices=range(0, 16), metavar="N",
                    help="optionId để NHẬN nhiệm vụ ở NPC 25: menu(25, 0, N). Mặc định 0")
    ap.add_argument("--stone-pay", choices=["yen", "xu"],
                    help="trả phí luyện đá bằng yen (mặc định, đá ra bị khóa) hoặc xu (đá không khóa vẫn không khóa)")
    ap.add_argument("--stone-levels", type=parse_stone_levels, metavar="A-B",
                    help=f"luyện dần từ đá cấp A lên đá cấp B (1 <= A < B <= {STONE_LEVEL_MAX}) rồi cất đá cấp B "
                         "vào rương đồ; chỉ ghi B = từ cấp 1; 'all' = mọi cấp, không cất rương (mặc định)")
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
    if args.stone_pay is not None or args.stone_levels is not None:
        requested.add("stone")
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
            cur_data = open(dll, "rb").read()
            current, accept, _kind = detect(cur_data)
            stone_xu = detect_stone_xu(cur_data)
            stone_levels = detect_stone_levels(cur_data)
            features = (current | requested) - set(args.remove or [])
            if args.accept_option is not None:
                accept = args.accept_option
            if args.stone_pay is not None:
                stone_xu = args.stone_pay == "xu"
            if args.stone_levels is not None:
                stone_levels = args.stone_levels
            write_atomic(dll, build(original, features, accept, stone_xu, stone_levels))
            print(f"[+] Đã ghi {dll} với: {', '.join(sorted(features)) or '(không tính năng nào)'}")
        print_status(dll)
    except PatchError as e:
        print(f"[-] {e}")
        return 1
    return 0


if __name__ == "__main__":
    sys.exit(main())
