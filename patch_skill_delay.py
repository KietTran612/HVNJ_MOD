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

FEATURES = ["mob", "die", "trial", "stage", "quest", "party", "stone", "tathu"]
FEATURE_NAMES = {
    "mob": "1. Né quái Tinh Anh / Thủ Lĩnh / Boss khi Auto",
    "die": "2. Chết: về làng ngay, quay lại map cũ, bật lại Auto",
    "trial": "3. Giữ Auto & tìm đường trong Thí Luyện",
    "stage": "4. Tự qua ải Thí Luyện 161 -> 167, dừng ở ải cuối",
    "quest": "5. Auto nhiệm vụ hàng ngày (dùng auto nhiệm vụ của game)",
    "party": "6. Đánh theo nhóm (chạy theo & đánh cùng quái với trưởng nhóm)",
    "stone": "7. Tự luyện đá tại chỗ khi hành trang đầy (lúc Auto, chỉ luyện 100%)",
    "tathu": "8. Auto nhiệm vụ tà thú (dùng auto nhiệm vụ của game)",
}
PAYLOAD_FEATURES = ("mob", "stage", "quest", "party", "die", "stone", "tathu")
# "die" nhận diện theo patch đơn giản (giống mọi bản cũ); các tính năng còn lại theo cờ cfg + hook
DETECT_BY_CFG = ("mob", "stage", "quest", "party", "stone", "tathu")
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
PAYLOAD_DATA_RAW = 0xf66e00
PAYLOAD_CODE = bytes.fromhex(
    "0f287c2430498bc6e97f40fafe0f1f00803def1f000000742b488b0dc860c4ff4885c9741f488b89b80000004885c974"
    "130fbf495c81e9a100000083f9060f86eb3efafe803dba1f0000000f84de3efafe6683b8b000000000750d80b8b40000"
    "00000f84c73efafe488b0de960c4ff4885c97454488b89b80000004885c97448488b89800000004885c9743c448b4118"
    "488b49104885c9742f448b487833d2413bd07d243b5118731f4c8b54d1204d85d2741141837a1001750a45394a380f84"
    "6b3efafeffc2ebd7e9b13ffafe0f1f006683b8b000000000750d80b8b4000000000f84c443fafe488b0d6a60c4ff4885"
    "c97454488b89b80000004885c97448488b89800000004885c9743c448b4118488b49104885c9742f448b487833d2413b"
    "d07d243b5118731f4c8b54d1204d85d2741141837a1001750a45394a380f846843fafeffc2ebd7e9b144fafe0f1f4000"
    "803db21e0000007423e8e20700004885c07419488b80000200004885c0740883784400750233c0e9f35003ff33c9e80d"
    "3bfafe4885c00f8520020000803d731e0000000f840e020000488b0d485fc4ff4885c90f84f1010000488b89b8000000"
    "4885c90f84e10100000fbf515c8d8a5fffffff83f9060f87ce0100008b4b5c83f90e0f84c201000083f9050f84b90100"
    "003b15291e0000741c8915211e000048c7051e1e00000000000048c7051b1e000000000000488d0d1c1e0000ff15feaf"
    "9aff488b050f1e000033d2b91027000048f7f1803ddf1d00000074318b0dde1d00003b0ddc1d00007523c705d01d0000"
    "ffffffff488d883cf6ffff48890dc61d000048c705c31d000000000000488b0db41d00004885c9750c488905a81d0000"
    "e930010000488bd0482bd14881fac40900000f821d010000488bc8482b0d8e1d00004881f9dc0500000f820601000048"
    "89057a1d0000813d601d0000a7000000751933c933d2e835f1fafe48c705521d000000000000e9da000000488b0d165e"
    "c4ff4885c90f84ca000000488b89b80000004885c90f84ba0000004c8b41604d85c00f84ad000000458b50184d8b4010"
    "4d85c00f849c0000008b15011d000033c933c0413bca7d44413b4818733e4d8b4cc8204d85c97430450fbf5918443bda"
    "7526450fbf591a442bda4183fb0174247c164885c07511450fbf591a4181fba70000007f03498bc1ffc1ebb74885c074"
    "444c8bc8410fbf4110410fbf491403c1d1f8410fbf4912410fbf511603cad1f9f30f2ac8f30f2ad1488bcb4533c9e87d"
    "a605ff33c0e9d54e03ff48c705731c00000000000033c0e9c34e03ff48c705611c000000000000e9b34e03ff0f1f4000"
    "53565741544155415641574883ec40488bd933d2e8d7f2f9fe803d2b1c0000007405e8290a0000803d1c1c0000007410"
    "488bcbe85807000085c00f8502050000803d021c000000740de8f205000085c00f85ec040000803dea1b000000750d80"
    "3de91b0000000f84f8040000488d4c2430ff15d9ad9aff488b44243033d2b91027000048f7f14c8bf8488bc8482b0ddd"
    "1b00004881f9f40100000f82c40400004c893dc91b0000488b057a5cc4ff4885c00f84ad040000488b80b80000004885"
    "c00f849d040000440fbf685c488b056d3ac4ff4885c00f8488040000488b80b80000004885c00f8478040000440fb660"
    "160fb605a51b0000884424384488259a1b0000418d855fffffff83f8060f8651040000803d821b00000075494585e40f"
    "843f040000807c2438000f8534040000c605651b000001c605601b000000c6055a1b000000c605541b000000c605501b"
    "000000c6054a1b00000048c7052b1b00000000000033c9e8f47f03ff4885c00f84ef0300004c8bf0418b465c83f80e0f"
    "84df03000083f8050f84d603000033f6488b05015cc4ff4885c00f84c4030000488b80b80000004885c00f84b4030000"
    "488b80800000004885c00f84580100008b4818488b50104885d20f844801000033ff3bf97d433b7a18733e488b44fa20"
    "4885c07430448b40104183f800750b803d511a0000007531eb1b4183f8017515803d481a000000740c4885f67507488b"
    "f0897c243cffc7ebb94885f60f84f6000000488bc68b7c243c488bf0c6056b1a000000c605661a0000008b4614483b35"
    "4c1a000075083b054c1a000074144889353b1a000089053d1a0000c6053d1a00000080bb01020000000f85f50200008b"
    "461885c07e053946147d20443b6e3c751a837e100174464585e40f85d4020000807c2438000f859e020000498bc7482b"
    "05e3190000483d401f00000f82b3020000803de7190000030f837b020000fe05db1900004c893dbd190000eb344585e4"
    "750b807c2438000f855c020000498bc7482b05a1190000483d983a00000f82710200004c893d8e190000c6059e190000"
    "00488bcb8d57024c8bc64533c9e8fed6f9fe90e92a02000048c7056d1900000000000033c0803d1b190000007409803d"
    "6e19000000741fb801000000803d0c190000000f84f0010000803d54190000000f85e30100003a0546190000740d8805"
    "3e190000c6053319000000410fbe8670010000ffc883f8070f87bb010000488d0d130d00000fb63401443bee7466c605"
    "091900000080bb01020000000f85c2010000498bc7482b05cc180000483d102700000f82ac010000803de1180000060f"
    "8374010000fe05d51800004c893da6180000488bcb8bd641b8190000004533c948c744242000000000e862f2f9fe90e9"
    "4e010000c605a518000000b91900000033d2e81931fdfe4885c00f8454010000488bf84c8b07488bcf498b9080010000"
    "41ff9078010000f30f114424284c8b07488bcf498b909001000041ff9088010000f30f1144242cf30f10442428f30f10"
    "4c242cf3410f1096b8000000f3410f109ebc00000048c744242000000000e8edc613ff0f2f05160c0000723a498bc748"
    "2b05f2170000483dd00700000f82d20000004c893ddf170000498bcef30f104c2428f30f1054242c4533c9e8a0a105ff"
    "90e9ae000000498bc7482b05c0170000483da00f00000f8298000000803dcb170000047342fe05c31700004c893d9e17"
    "000033c9e8571202ff4885c07476488bc8ba19000000440fb605a4170000440fb60d4217000048c744242000000000e8"
    "0cce02ff90eb4dc6058017000000803d7d170000007509c6057517000001eb34c6056d17000001eb2bc6055c17000000"
    "eb22488b05f735c4ff4885c07416488b80b80000004885c0740a0fb640168805391700004883c440415f415e415d415c"
    "5f5e5bc3666666660f1f84000000000053564883ec2833f6803dba160000000f8499000000488b05a435c4ff4885c00f"
    "8489000000488b80b80000004885c0747d80781600747733c9e8a27b03ff4885c0746b488bd88b435c83f80e746083f8"
    "05745b488b057e3dc4ff4885c0744f488b80b80000004885c07443488b40184885c0743a837818027c34488b40104885"
    "c0742b837818007425488b40204885c0741c8b48103b4b60741433d2e80fabfcfe4885c07408483bc37403488bf0488b"
    "c64883c4285e5bc30f1f8400000000005356574883ec30488d4c2420ff15fea79aff488b44242033d2b91027000048f7"
    "f1488bf8488bc8482b0d3a1600004883f9640f82fb00000048893d29160000e8fcfeffff4885c00f84df000000488bf0"
    "c6050a16000001488b058a56c4ff4885c07416488b80b80000004885c0740a0fbf405c89059b15000033c9e8a07a03ff"
    "4885c00f84aa000000488bd8488b86000200004885c0741283784400740c48898300020000e98900000048c783000200"
    "0000000000f30f1083b8000000f30f5c86b80000000f5405740900000f2f05810900007720f30f1083bc000000f30f5c"
    "86bc0000000f5405540900000f2f0561090000763e488bc7482b0571150000483df4010000722c48893d62150000488b"
    "cbf30f108eb8000000f30f1096bc0000004533c9e8e79e05ff90eb07c6052e150000000fb605271500004883c4305f5e"
    "5bc36666666666660f1f84000000000053565741544883ec38488bd9488d4c2428ff15a9a69aff488b44242833d2b910"
    "27000048f7f14c8be0488bc8482b0df51400004881f9c80000000f82670200004c8925e1140000c605071500000033c9"
    "e87b7903ff4885c00f8449020000488bf0488b053055c4ff4885c00f8436020000488b80b80000004885c00f84260200"
    "000fbf785c8b465c83f80e0f842101000083f8050f8418010000803db3140000000f8400020000803d5e140000000f85"
    "e30100003b3d96140000756b488b05ed32c4ff4885c00f84d4010000488b80b80000004885c00f84c401000080781600"
    "0f85b1010000488b055b1400004885c07514498d8424dc05000048890547140000e99a0100004c3be00f8291010000b1"
    "0133d2e888e7fafeb10133d2e88fe9fafe90e97001000048c705161400000000000033c9e8570226ff4885c00f845e01"
    "000080b8fc000000000f855101000080bb01020000000f8544010000498bc4482b05da130000483d102700000f822e01"
    "0000803ddd130000060f8318010000fe05d11300004c8925b4130000488bcb8b15bb13000041b8ffffffff4533c948c7"
    "44242000000000e814edf9fe90e9ee0000008d875fffffff83f8060f86e6000000803d8c130000007574488b05df31c4"
    "ff4885c00f84cd000000488b80b80000004885c00f84bd00000080781600751d33c9e8990126ff4885c00f84a7000000"
    "80b8fc000000000f849a000000c6054013000001893d361300004c89250f13000048c705141300000000000048c70511"
    "13000000000000c6051813000000498bc4482b05e8120000483dd00700007250498bc4482b05de120000483db80b0000"
    "723e33c9e8270126ff4885c0743280b8fc0000000075294c8925ba12000033c9e82b0d02ff4885c07416488bc833d2e8"
    "3c5a02ff90eb09c605b612000000eb07c605ae120000010fb605a71200004883c438415c5f5e5bc30f1f840000000000"
    "5355565741544155415641574883ec68488d4c2420ff15e5a39aff488b44242033d2b91027000048f7f14c8bf8488bc8"
    "482b0d611200004881f9e80300000f82cf0500004c893d4d1200004c3b3d4e1200000f82bb050000488b059130c4ff48"
    "85c00f84ab050000488b80b80000004885c00f849b050000807816000f8491050000488b05bf3dc4ff4885c00f848105"
    "0000488b80b80000004885c00f8471050000488b88280100004885c97421488b052b34c4ff4885c07415488b80b80000"
    "004885c07409483b080f844405000033c9e83a7603ff4885c00f8434050000488bd88b435c83f80e0f842505000083f8"
    "050f841c050000488bb3b80100004885f60f840c050000488b050252c4ff4885c00f84fc040000488b80b80000004885"
    "c00f84ec0400004c8ba0080100004d85e40f84dc0400004c8ba8d00000004d85ed0f84cc040000418b442418418b4d18"
    "3bc80f42c1b90c0000003bc10f47c1ffc80fb60d9610000085c97407ffc93bc10f47c183f8010f8c97040000448bf048"
    "8d3d3a11000033c0b918000000f3ab440fb61d661000004585db740341ffcb4c8d151a110000448b4e1833ffbdffffff"
    "ff33c9413bc97368488b44ce204885c07504ffc7eb56488b50104885d2744d807a121a754780785e0075410fbf521044"
    "0fb605171000004585c0741041ffc8413bd0750885ed79248be9eb20413bd6731b413bd37216803def0f000000740980"
    "783800740383c20c41ff0492ffc1eb93488b05811000004885c0747148c70571100000000000008b0d7b100000413bc9"
    "7354483b44ce20754dfe056d100000803d66100000027245c6055d10000000803d5710000000751cc6054f1000000049"
    "8bc74805e093040048890521100000e98f030000498bc7480540771b004889051c100000eb6cc6051f1000000085ed78"
    "614c3b3d081000007258488b83c00100004885c0744c448b481833c9413bc9734148837cc820007404ffc1ebef488b44"
    "ee20488905cf0f0000892dd90f00008b502888153810000041be01000000c605c80f000001c744242811000000e93502"
    "0000803db50f000000751083ff010f87ff020000c605a30f000001488d3d9e0f0000bd01000000413bee0f8f8b000000"
    "4d6344ac204d85c07e7a4533d24533db8d4dff4d634c8c2033c04d85c97e31498bc0492bc233d249f7f18b148f483bc2"
    "480f47c2ba18000000412bd3483bc2480f47c24403d8488bd0490fafd14c03d289448c30ffc979bb4d3bd075274183fb"
    "027221496344ad20488b9340010000803d560e000000750748039350010000483bc27e2cffc5e96cffffff803d3a0e00"
    "00000f8434020000488d05210f0000483bf80f8424020000488bf8e942ffffff488d05090f00004533c9483bf8410f94"
    "c1448b5618488d3d240f000033c94533db413bca7372488b44ce204885c07464488b50104885d2745b807a121a75550f"
    "bf52103bd5734d80785e007547803dc80d0000007411440fb640384585c0410f95c0453bc1752d837c9430007426ff4c"
    "94308b50284288141f4585db750d488905430e0000890d4d0e000041ffc34183fb187304ffc1eb894183fb020f826f01"
    "0000458bf3c605310e000000c744242814000000803d610d0000007408c744242813000000488d0d3430c4ffe83f05f4"
    "fe488b0d2830c4ff4885c90f8430010000f6813301000002741583b9e000000000750ce8e851ecfe488b0d0130c4ff48"
    "8b81b80000004885c00f840201000048837808007541488d0d0be1c2ffe8ee04f4fe488b0dffe0c2ff4885c90f84df00"
    "0000ba18000000e8d400f4fe4885c00f84cc000000488b0db42fc4ff488b89b80000004889410833c9e8b20702ff4885"
    "c00f84aa000000488be848837d10000f849c000000488d0db42ac4ffe88f04f4fe488d0d7038c4ffe88304f4fe488b0d"
    "9c2ac4ff4885c97478e88205f4fe4885c0746e488bf8488bc88b5424284533c0e8ab1d22ff33f6413bf67320488b4f20"
    "4885c9744c488d05740d00000fb614304533c0e8b8540effffc6ebdb4c8b45104d85c0742c488b150c38c4ff4885d274"
    "20b9030000004c8bcfe8f2b8defe90498bc74805b80b0000488905b10c0000eb2248c705ac0c000000000000c605bb0c"
    "000000498bc74805307500004889058d0c00004883c468415f415e415d415c5f5e5d5bc3666666660f1f840000000000"
    "ffffff7fffffff7fffffff7fffffff7f0000c04100002042010148481b1ba0a0010f08000f720bf009e007d005c00370"
    "0260013001060300064202600130000001070400075203700260013001090500096205c0037002600130000001100900"
    "10c20cf00ae008d006c00470036002500130000021000000909c1b00cca01b009c57d70021000000909c1b00cca01b00"
    "9c57d7002100000093b52400ccb524004482d70021000000d0a21b00dead1b009848d700000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
    "00000000000000000000000000000000"
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
PAYLOAD_CFG = {'cfg_block': 0x0, 'cfg_mob': 0x5, 'cfg_stage': 0x6, 'cfg_quest': 0x7, 'cfg_accept': 0x8, 'cfg_party': 0x9, 'cfg_die': 0xa, 'cfg_stone': 0xb, 'cfg_stone_xu': 0xc, 'cfg_stone_lo': 0xd, 'cfg_stone_hi': 0xe, 'cfg_tathu': 0xf}
PAYLOAD_SYMBOLS = {'dgj_ret': 0x1216000, 'dgj_ret_end': 0x121600d, 'dgj_filter': 0x1216010, 'dgj_filter_end': 0x12160cd, 'dgl_filter': 0x12160d0, 'dgl_filter_end': 0x121614c, 'clo_stage': 0x1216150, 'clo_stage_end': 0x12163bc, 'quest_tick': 0x12163c0, 'party_leader': 0x1216940, 'party_tick': 0x1216a00, 'die_tick': 0x1216b50, 'stone_tick': 0x1216e10, 'cfg_block': 0x1218000, 'cfg_mob': 0x1218005, 'cfg_stage': 0x1218006, 'cfg_quest': 0x1218007, 'cfg_accept': 0x1218008, 'cfg_party': 0x1218009, 'cfg_die': 0x121800a, 'cfg_stone': 0x121800b, 'cfg_stone_xu': 0x121800c, 'cfg_stone_lo': 0x121800d, 'cfg_stone_hi': 0x121800e, 'cfg_tathu': 0x121800f}
PAYLOAD_PDATA = [(0x1216000, 0x121600d, 0x12174b4), (0x1216010, 0x12160cd, 0x12174c4), (0x12160d0, 0x121614c, 0x12174e4), (0x1216150, 0x12163bc, 0x12174d4), (0x12163c0, 0x1216934, 0x1217460), (0x1216940, 0x12169f8, 0x1217474), (0x1216a00, 0x1216b42, 0x1217480), (0x1216b50, 0x1216e08, 0x121748c), (0x1216e10, 0x1217434, 0x121749c)]
PAYLOAD_HEADER_PATCHES = [
    (0x12e, '0700', '0900'),
    (0x144, '00f2bb00', '0008bc00'),
    (0x148, '00266500', '00286500'),
    (0x178, '00602101', '00902101'),
    (0x1cc, '80bc0800', 'ecbc0800'),
    (0x2d8, '80bc0800', 'ecbc0800'),
    (0x348, '00000000000000000000000000000000000000000000000000000000000000000000000000000000', '2e68766e6a000000f414000000602101001600000058f60000000000000000000000000020000060'),
    (0x370, '00000000000000000000000000000000000000000000000000000000000000000000000000000000', '2e68766e6a640000480100000080210100020000006ef600000000000000000000000000400000c0'),
    (0xf39c80, '000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000', '006021010d602101b474210110602101cd602101c4742101d06021014c612101e474210150612101bc632101d4742101c0632101346921016074210140692101f869210174742101006a2101426b210180742101506b2101086e21018c742101106e2101347421019c742101'),
]
PAYLOAD_HOOKS = {
    'core': [
        (0x1b9db1, '0f84ce020000', '660f1f440000'),
        (0x1b9dfc, '0f8d83020000', '0f8dfec10501'),
        (0x1b9e4b, '8b70', 'eb67'),
        (0x1b9f11, '488b0d1020ca00f6813301000002740e4439a1e00000007505e8a125f2ff', 'e9fac00501cccccccccccccccccccccccccccccccccccccccccccccccccc'),
    ],
    'mob': [
        (0x1ba485, '3968440f846f010000488b0d931aca00f6813301000002740d39a9e00000007505e82520f2ff', '3968440f846f010000e93dbc0501cccccccccccccccccccccccccccccccccccccccccccccccc'),
    ],
    'clo': [
        (0x24b5ac, 'e8dfe6f6ffe9b9fcffff', 'e99fabfc00cccccccccc'),
    ],
    'tick': [
        (0x19495e, 'e84d0d0200', 'e85d1a0801'),
    ],
}
PAYLOAD_HOOK_USERS = {'core': ('mob', 'stage'), 'mob': ('mob',), 'clo': ('stage', 'party'), 'tick': ('quest', 'party', 'die', 'stone', 'tathu')}
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
        print(f"      menu nhận nhiệm vụ ngày: menu(25, 0, {accept})")
    if "tathu" in on:
        print(f"      menu nhận nhiệm vụ tà thú: menu(25, 1, {accept})")
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
    ap.add_argument("--tathu", action="store_true", help="auto nhiệm vụ tà thú (nhận ở NPC 25 menu 1, sau nhiệm vụ ngày)")
    ap.add_argument("--remove", nargs="+", choices=FEATURES, metavar="TÍNH_NĂNG", help="tắt tính năng")
    ap.add_argument("--accept-option", type=int, choices=range(0, 16), metavar="N",
                    help="optionId để NHẬN nhiệm vụ ở NPC 25: menu(25, 0, N) (ngày) / menu(25, 1, N) (tà thú). "
                         "Mặc định 0")
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
