# Học Viện Ninja (HVNJ 186) - Bản Mod Toàn Diện (6 Tính Năng Cao Cấp)

[![Game Version](https://img.shields.io/badge/HVNJ-186-orange.svg)](https://github.com/KietTran612/HVNJ_MOD)
[![Unity](https://img.shields.io/badge/Unity-2020.2.7_x64_IL2CPP-blue.svg)](https://unity.com/)
[![Status](https://img.shields.io/badge/Status-Fully_Patched-brightgreen.svg)](https://github.com/KietTran612/HVNJ_MOD)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

Bản mod toàn diện dành cho game **Học Viện Ninja (HVNJ 186 by G4M Studio)** nền tảng PC x64 Unity IL2CPP, can thiệp trực tiếp vào binary machine code `GameAssembly.dll` để tối ưu hóa trải nghiệm chơi, tốc độ ra chiêu và tự động hóa chu trình luyện tập & làm nhiệm vụ.

---

## 🚀 Danh Sách 6 Tính Năng Mod Đỉnh Cao

### 1. ⚡ Tốc Độ Ra Chiêu Siêu Tốc (0.3s Cooldown)
- **Cơ chế:** Gỡ bỏ hoàn toàn thời gian khựng động tác (animation-lock) và giảm hồi chiêu toàn cục xuống còn **0.3 giây**.
- **Hiệu quả:** Ra chiêu liên hoàn, dồn sát thương cực nhanh cho tất cả các hệ phái.

### 2. 🛡️ Tự Động Né Quái Tinh Anh, Thủ Lĩnh & Boss
- **Cơ chế:** Tự động lọc danh sách mục tiêu quái:
  - Bỏ qua quái Tinh Anh (`levelBoss == 1`).
  - Bỏ qua quái Thủ Lĩnh (`levelBoss == 2`).
  - Bỏ qua Boss thế giới / Boss map (`isBos == true`).
- **Hiệu quả:** Nhân vật chỉ chọn quái thường gần nhất để đánh, tránh bị sốc sát thương khi treo máy train quái.

### 3. ⏱️ Chết Tự Động Quay Về Liền (0s Instant Return)
- **Cơ chế:** Giảm thời gian đếm ngược 15 giây (500 frames) khi nhân vật chết xuống **0 giây**.
- **Hiệu quả:** Nhân vật hồi sinh / quay về ngay lập tức, tự động tiếp tục lộ trình quay lại bãi train mà không bị gián đoạn.

### 4. 🏰 Auto & Tự Quay Lại Map Trong Khu Thí Luyện (Map 161)
- **Cơ chế:** 
  - Gỡ bỏ lệnh tự động tắt Auto của game khi bước vào Khu Thí Luyện.
  - Gỡ bỏ blacklist kiểm tra bản đồ cấm di chuyển.
- **Hiệu quả:** Giữ nguyên trạng thái Auto trong Thí Luyện; khi chết hồi sinh ở cửa map, Auto tự động chạy ngược lại bãi quái để đánh tiếp.

### 5. 🎯 Tự Động Chuyển Ải Thí Luyện (Ải 161 ➔ 167) & Dừng Ở Map Cuối
- **Cơ chế:** Code Cave thông minh kiểm tra trạng thái quái trong Thí Luyện:
  - Khi tiêu diệt hết quái ở ải hiện tại (161 ➔ 166), nhân vật tự động tìm cổng dịch chuyển và bước qua ải kế tiếp.
  - Nhận diện thông minh: Cho phép đánh Boss / Thủ Lĩnh trong Thí Luyện để dọn sạch ải.
  - Khi tới ải cuối cùng (Map 167) và tiêu diệt xong quái/Boss, Auto tự động tắt và dừng lại an toàn.

### 6. 📜 Full Auto Làm Nhiệm Vụ Hàng Ngày Siêu Tốc (Dịch Chuyển Tức Thời)
- **Cơ chế khép kín 100% tự động:**
  - **Tới nhanh map nhiệm vụ ("Đi làm nhiệm vụ"):** Ngay sau khi nhận nhiệm vụ tại NPC 25 (Thầy/Cô hiệu trưởng), Auto kích hoạt tính năng *"Đi làm nhiệm vụ"* (`Service.cmy().menu(25, 0, 1)`) để **dịch chuyển tức thời đến thẳng map có quái**, không tốn thời gian chạy bộ qua từng map!
  - **Auto đánh quái:** Tự động tìm và diệt đúng loại quái nhiệm vụ (vẫn né quái tinh anh/thủ lĩnh).
  - **Dịch chuyển về trường tức thời bằng Thông Thành Phù:** Đánh đủ số lượng quái, nhân vật lập tức sử dụng **Thông Thành Phù** (`Service.cmy().cqj(schoolMap)`) bay về trường chỉ trong 1 tick.
  - **Tự mua Thông Thành Phù bằng Yên:** Nếu kiểm tra trong túi đồ hết Thông Thành Phù, Auto tự động mua 10 Thông Thành Phù từ Tạp Hóa bằng Yên khi ở trường.
  - **Trả & nhận tiếp:** Gặp NPC 25 chọn *"Hoàn thành nhiệm vụ"* (`menu(25, 0, 2)`), nhận thưởng và lặp lại liên tục cho đến khi hết lượt nhiệm vụ ngày!
- **Tách biệt thông minh:** Tạm dừng Auto nhiệm vụ ngày khi đang ở Thí Luyện (161–167) để ưu tiên vượt ải.

---

## 🛠️ Hướng Dẫn Sử Dụng

### Cách 1: Sử Dụng Trực Tiếp File Đã Patch Sẵn
Chỉ cần tải file `GameAssembly.dll` trong repository này và chép đè vào thư mục game **Học Viện Ninja**, sau đó mở `Hoc Vien Ninja.exe` và bật Auto trong game.

### Cách 2: Sử Dụng Script Patch `patch_skill_delay.py`
Yêu cầu Python 3.8+ trên Windows:

```bash
# Xem trạng thái hiện tại của file game
python patch_skill_delay.py --status

# Bật đầy đủ cả 6 tính năng mod cao cấp
python patch_skill_delay.py --all

# Bật riêng lẻ từng tính năng tùy nhu cầu:
python patch_skill_delay.py --quest   # Auto Nhiệm vụ Hàng ngày (Dịch chuyển siêu tốc)
python patch_skill_delay.py --stage   # Tự chuyển ải Thí Luyện (161->167)
python patch_skill_delay.py --trial   # Auto trong map Thí Luyện
python patch_skill_delay.py --die     # Hồi sinh / quay về liền khi chết
python patch_skill_delay.py --mob     # Né quái tinh anh / thủ lĩnh / boss
python patch_skill_delay.py --skill   # Tốc độ ra chiêu 0.3s

# Khôi phục về file gốc ban đầu (từ GameAssembly.dll.bak)
python patch_skill_delay.py --restore
```

---

## 📂 Cấu Trúc Repository

```
├── GameAssembly.dll        # File binary đã patch sẵn đầy đủ 6 tính năng
├── patch_skill_delay.py    # Tool Python tự động patch / khôi phục game
├── README.md               # Tài liệu hướng dẫn chi tiết
├── decompiled_output/      # Scripts phân tích reverse engineering & assembler code cave
└── ...
```

---

## ⚠️ Lưu Ý & Miễn Trừ Trách Nhiệm
- Bản mod được phát triển cho mục đích học tập, nghiên cứu kỹ thuật Reverse Engineering và IL2CPP binary patching trên nền tảng Unity x64.
- Người dùng tự chịu trách nhiệm khi sử dụng bản mod trong game.

---
**Tác giả:** KietTran612  
**Học Viện Ninja 186 (G4M Studio)**
