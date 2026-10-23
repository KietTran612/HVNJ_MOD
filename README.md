# Học Viện Ninja (HVNJ 186) - Bản Mod Toàn Diện v2 (6 Tính Năng)

[![Game Version](https://img.shields.io/badge/HVNJ-186-orange.svg)](https://github.com/KietTran612/HVNJ_MOD)
[![Unity](https://img.shields.io/badge/Unity-2020.2.7_x64_IL2CPP-blue.svg)](https://unity.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

Bản mod cho game **Học Viện Ninja (HVNJ 186 by G4M Studio)** bản PC x64 Unity IL2CPP. Mod sửa trực tiếp mã máy trong `GameAssembly.dll`.

> **v2 thay cho v1.** Bản v1 có lỗi làm game crash (cave nhiệm vụ ghi vào vùng code chỉ đọc và đè lên code `ClassAndroid`) và nhiều lỗi logic. Xem mục [Thay đổi so với v1](#-thay-đổi-so-với-v1). Script v2 tự nhận ra DLL đã cài v1 và nâng cấp được.

---

## 🚀 6 Tính Năng

> Tính năng "Tốc độ ra chiêu 0.3s" (`--skill`) **đã bị gỡ**. Xem [Thay đổi so với v1](#-thay-đổi-so-với-v1).

### 1. 🛡️ Né quái Tinh Anh / Thủ Lĩnh / Boss khi Auto — `--mob`
- Auto thường (`mo.dgj`) chọn **quái thường gần nhất**. Quái Tinh Anh (`levelBoss == 1`), Thủ Lĩnh (`levelBoss == 2`) và Boss (`isBos`) bị bỏ qua.
- Auto nhiệm vụ (`mo.dgl`) cũng bỏ qua các loại quái trên.

### 2. ⏱️ Chết: về làng ngay, quay lại map cũ, bật lại Auto — `--die`
Áp dụng khi nhân vật chết **lúc đang bật Auto**.

**Cơ chế có sẵn của game:**
1. Khi Auto bật, `mo.ctq` đặt đếm ngược `mo.nib = 15`.
2. `mo.dfq` chạy mỗi giây: khi đếm về 0 mà nhân vật đang chết thì gửi lệnh về làng (`lj.cpt`) và nhớ map lúc chết.
3. Vào map mới, `mo.dek` tự tìm đường về map đó rồi bật lại Auto.

Cơ chế này chỉ chạy khi tuỳ chọn Auto `ca.fxg` đang bật (mặc định là bật). Với game gốc, sau khi chết phải **chờ tới 15 giây** mới về làng.

**Mod làm thêm:**

| Bước | Mod làm gì |
|---|---|
| Phát hiện chết | Đếm ngược 15 → 1, nên về làng sau khoảng 1–2 giây. Hộp thoại chết đếm 500 → 2 frame. |
| Game không tự về làng | Chết 2 giây mà game chưa gửi lệnh về làng (ví dụ tắt tuỳ chọn Auto) thì mod gửi `lj.cpt`, lặp lại mỗi 3 giây. |
| Hồi sinh ở map khác | Nếu game không tự quay về (`eq.hcr = 0`, không đang tìm đường) thì mod tìm đường về **map lúc chết**: tối đa 6 lần, mỗi lần cách 10 giây. |
| Về tới map cũ | Chờ 1.5 giây cho game tự bật Auto. Nếu Auto vẫn tắt thì mod bật lại, giống bấm nút Auto. |

- Khi game đang tự xử lý (`eq.hcr = 1`), mod đứng yên, không giành điều khiển.
- Bỏ qua Thí Luyện (161–167), vì map ải không đi bộ vào lại được.
- Nếu auto nhiệm vụ ngày (`--quest`) đang chạy thì để nó tự đưa nhân vật về map nhiệm vụ.
- Trong lúc xử lý chết, đánh theo nhóm và auto nhiệm vụ tạm dừng. Về tới map cũ thì đánh theo nhóm tiếp tục như bình thường.
- Chết lúc **không** bật Auto: mod không làm gì.

### 3. 🏰 Giữ Auto trong Thí Luyện — `--trial`
Game không còn tự tắt Auto khi vào map 161 và không còn chặn tìm đường trong map 161. Khi chết và hồi sinh ở cửa, Auto tự chạy lại bãi quái.

### 4. 🎯 Tự qua ải Thí Luyện 161 → 167 — `--stage`
- Trong Thí Luyện, Auto đánh **mọi** quái, kể cả Boss và Thủ Lĩnh, để dọn sạch ải.
- Nếu không tìm thấy quái nào **liên tục 2.5 giây**:
  - ở ải 161–166: nhân vật chạy tới cổng sang ải kế tiếp;
  - ở ải 167: Auto tự tắt.
- Tính năng này tự kèm phần sửa chọn quái của `mo.dgj` (dùng chung với `--mob`), nên bật riêng `--stage` vẫn chạy được.

### 5. 📜 Auto nhiệm vụ hàng ngày — `--quest`
Mod không tự viết logic đi lại hay đánh quái mà gọi lại chức năng **"Bấm vào đây để tự động làm nhiệm vụ"** có sẵn trong game (`mo.dga` → `mo.dgh`).

**Bắt đầu:** bật **Auto** ở một map ngoài Thí Luyện. Từ lúc đó mod chạy vòng lặp sau (cứ 0.5 giây kiểm tra một lần):

| Tình huống | Mod làm gì |
|---|---|
| Chưa có nhiệm vụ hàng ngày | Tìm đường về trường theo hệ phái (map 1 / 72 / 27 / 160), đi tới NPC 25, gửi `menu(25, 0, N)` để **nhận** nhiệm vụ. N mặc định là 0, đổi bằng `--accept-option`. |
| Có nhiệm vụ, chưa ở map nhiệm vụ | Gọi auto nhiệm vụ của game. Nếu đang đứng cạnh NPC 25, game tự chọn option 3 để **dịch chuyển thẳng tới map nhiệm vụ**; nếu không thì tìm đường tới đó. |
| Đang ở map nhiệm vụ | Game tự bật Auto và đánh đúng loại quái. Nếu bật `--mob`, Tinh Anh/Thủ Lĩnh vẫn bị né. |
| Đánh đủ số lượng | Game tự về trường gặp NPC 25 và chọn option 2 để **trả** nhiệm vụ. Mod tiếp tục nhận nhiệm vụ mới. |
| Vào Thí Luyện (161–167) | Tạm dừng, nhường cho `--stage`. |

**Dừng:**
- **Tắt Auto** lúc đang đánh ở map nhiệm vụ.
- Nhận nhiệm vụ 4 lần không được: hết lượt trong ngày, hoặc sai option.
- Gọi auto nhiệm vụ 3 lần liên tiếp mà không có tiến triển.
- Tìm đường về trường 6 lần (khoảng 60 giây) mà không tới được.
- Nhân vật chưa vào lớp.

Muốn chạy lại thì bật Auto lần nữa.

> ⚠️ **Phần chưa kiểm chứng trong game:** menu của NPC do server gửi xuống. Option 2 (trả) và 3 (đi tới) là những option chính code game dùng. Option **nhận** nhiệm vụ = 0 là **suy luận** theo thứ tự menu kiểu Ninja School (Nhận / Hủy / Hoàn thành / Đi tới). Nếu nhận không được, thử `--accept-option 1`, `2`…

> Bản v1 có "Thông Thành Phù" và "tự mua phù bằng Yên". Hai chức năng này **đã bị bỏ**: lệnh v1 gọi (`lj.cqj`) thực chất là lệnh xin lại dữ liệu map, không phải lệnh dùng phù, còn lệnh mua dùng chỉ số cửa hàng chưa được kiểm chứng. Thay vào đó, v2 dùng dịch chuyển qua NPC (option 3) của chính game.

### 6. 👥 Đánh theo nhóm — `--party`
Dành cho **thành viên** trong nhóm (máy của mỗi thành viên đều cần cài mod với `--party`). Thành viên chỉ cần **bật Auto**:

| Tình huống | Thành viên làm gì |
|---|---|
| Trưởng nhóm đang đánh một con quái còn sống | Đánh **đúng con quái đó**: chuyển mục tiêu ngay, Auto tự chạy tới đánh. Kể cả Boss/Thủ Lĩnh, dù có bật `--mob`. |
| Trưởng nhóm không đánh gì | Bỏ mục tiêu riêng và **chạy theo trưởng nhóm** khi cách xa hơn 40 đơn vị (cập nhật mỗi 0.5 giây). |
| Mình là trưởng nhóm, chưa vào nhóm, tắt Auto, hoặc trưởng nhóm ở map khác | Không can thiệp: Auto hoạt động như bình thường. |

- Khi đang đi theo trưởng nhóm, auto nhiệm vụ ngày (`--quest`) tạm dừng.
- Thông tin lấy từ chính client:
  - danh sách nhóm `gb.hxf` (`List<ko>`);
  - nhân vật trong map tìm qua `mo.djf(charId)`;
  - con quái trưởng nhóm đang đánh là `lm.mjn`, do game ghi khi nhận gói "người chơi khác tấn công".
- Tắt tính năng: tắt Auto, hoặc `--remove party`.

> ⚠️ **Chưa kiểm chứng trong game:** trưởng nhóm được hiểu là **người đứng đầu danh sách nhóm**. Đó là thứ tự server gửi, và theo quy ước kiểu Ninja School thì người đầu tiên là trưởng nhóm. Thành viên chỉ đi theo được khi **cùng map** với trưởng nhóm, chưa tự tìm đường sang map khác.

---

## 🛠️ Cách dùng

Cần Python 3.8+ (chỉ dùng thư viện chuẩn). Chạy trong thư mục game và **tắt game trước khi chạy**:

```bash
python patch_skill_delay.py --status          # xem trạng thái
python patch_skill_delay.py --all             # bật cả 6 tính năng
python patch_skill_delay.py --party           # chỉ thêm đánh theo nhóm (máy thành viên)
python patch_skill_delay.py --mob --stage     # bật thêm tính năng (giữ các tính năng đang bật)
python patch_skill_delay.py --remove quest    # tắt một tính năng
python patch_skill_delay.py --accept-option 1 # đổi option nhận nhiệm vụ
python patch_skill_delay.py --restore         # trả về bản gốc
```

- Mỗi lần chạy, script **dựng lại DLL từ bản gốc** (đã kiểm tra SHA-256) rồi áp đúng tập tính năng, nên thứ tự chạy không gây xung đột.
- Bản gốc được giữ ở `GameAssembly.dll.bak`. Nếu file này mất hoặc không phải bản gốc, script tự khôi phục bản gốc từ DLL đã mod (kể cả bản v1).
- Nếu game cập nhật lên phiên bản khác (SHA-256 không khớp), script từ chối patch để tránh làm hỏng DLL.
- DLL cũ còn patch "0.3s" sẽ được gỡ patch đó ở lần chạy script kế tiếp (`--status` có cảnh báo).

Cách nhanh: chép `GameAssembly.dll` trong repo (đã bật đủ 6 tính năng) vào thư mục game.

---

## 🔧 Kỹ thuật

- Code cave nằm trong 2 section mới ở cuối DLL:
  - `.hvnj` (RX): code;
  - `.hvnjd` (RW): cấu hình + trạng thái.
- Không ghi vào code của game và chỉ dùng địa chỉ RIP-relative, nên an toàn với ASLR.
- Mỗi cave đều có unwind info đăng ký trong `.pdata`. Cave chạy bên trong frame của hàm game dùng unwind dạng *chained* tới hàm đó. Nhờ vậy exception của game đi qua cave vẫn được xử lý bình thường thay vì làm game thoát.
- Mã nguồn: `mod_src/hvnj_caves.asm`, assemble bằng `ml64` (Visual Studio).

```bash
python mod_src/build_payload.py   # assemble + sinh bảng patch vào patch_skill_delay.py
python mod_src/verify_mod.py      # kiểm thử toàn bộ, không cần mở game
```

`verify_mod.py` kiểm tra các mục sau:
- dựng lại đủ 64 tổ hợp tính năng và khôi phục được bản gốc;
- gỡ được patch "0.3s" khỏi DLL cũ;
- nâng cấp DLL v2 dựng bằng payload cũ (`--old-v2`) mà vẫn giữ tính năng;
- nâng cấp được từ v1;
- cấu trúc PE;
- disassemble mọi lệnh nhảy/gọi;
- nạp DLL thật bằng `LoadLibraryEx` để kiểm tra quyền trang nhớ và `RtlLookupFunctionEntry`;
- `RtlVirtualUnwind` từ trong cave cho kết quả giống hệt khi unwind tại vị trí hook gốc;
- chạy thử CLI.

| Hook (RVA) | Hàm game | Mục đích |
|---|---|---|
| `0x1B9DB1`, `0x1B9E4B` | `mo.dgj` | bỏ ràng buộc quái theo nhiệm vụ chính |
| `0x1B9DFC` | `mo.dgj` | trả về quái gần nhất thay vì `null` |
| `0x1B9F11` | `mo.dgj` | lọc Tinh Anh/Thủ Lĩnh/Boss, cho phép đánh tất cả trong Thí Luyện |
| `0x1BA485` | `mo.dgl` | lọc quái của auto nhiệm vụ |
| `0x24B5AC` | `lm.clo` | chọn mục tiêu: theo trưởng nhóm, tự qua ải Thí Luyện |
| `0x19495E` | `mo.ctq` | mỗi frame: chết - quay về, đánh theo nhóm, nhiệm vụ hàng ngày (sau `mo.dgd`) |
| `0x1927E2`, `0x192912`, `0x3612E0`, `0x360946` | `mo.ctq`, `hw.cdy`, `hw.cdq` | bỏ đếm ngược khi chết |
| `0x19C061`, `0x477CBF` | `mo.dek`, `eq.bld` | Auto và tìm đường trong map 161 |

---

## 🩹 Thay đổi so với v1

**Gỡ tính năng "Tốc độ ra chiêu 0.3s" (`--skill`):**
- Patch này ép `lm.cwj` trả về 0.3. Nhưng `lm.cwj` không phải hàm hồi chiêu: nó trả về `SkeletonAnimation.timeScale`, tức tốc độ phát hoạt ảnh hiệu ứng skill (giá trị gốc 1.3–4.0).
- Kết quả là hiệu ứng skill chạy **chậm hơn** bản gốc, còn hồi chiêu thật (`Skill.coolDown`, kiểm tra trong `lm.cvg`) không đổi.
- Script vẫn nhận ra patch này trong DLL cũ để gỡ; cờ `--skill` giờ chỉ in thông báo.

**Lỗi gây crash:**
- Cave nhiệm vụ của v1 ghi biến đếm vào section `il2cpp` (chỉ đọc). Vì vậy game crash ngay khi bật Auto.
- Ô nhớ biến đếm đó còn nằm đè lên một lệnh `je`, và ba lệnh `inc`/`cmp`/`mov` trỏ lệch nhau 1 byte.
- Cave đè lên 928 byte code thật của `ClassAndroid` (`loginSuccess`, `logoutSuccess`…).
- Các cave không có unwind info, nên exception đi qua cave làm game thoát.

**Lỗi chọn quái:**
- NOP lệnh `xor eax,eax` làm `mo.dgj` trả về con trỏ rác khi nhân vật không có nhiệm vụ chính.

**Lỗi logic nhiệm vụ:**
- Cave đọc nhầm field của nhiệm vụ: so `taskId` với `count` thay vì `count` với `maxCount`.
- Cave dùng `mo.noz` làm cờ Auto, trong khi đó là cờ ẩn/hiện HUD. Cờ Auto thật là `ca.fxf`.
- "Đi làm nhiệm vụ" gửi option 1. Theo thứ tự menu đã suy luận ở trên, option 1 nhiều khả năng là Hủy, còn option dịch chuyển mà code game dùng là 3.
- `mo.dga` được gọi với index sai (0 thay vì vị trí + 2), nên game không tự trả nhiệm vụ khi đủ số lượng.
- Hệ phái 7/8 (trường map 160) bị bỏ sót.
- Spam lệnh mua phù và dịch chuyển mỗi 1.2 giây.

**Lỗi tính năng Thí Luyện:**
- Chỉ cần 1 tick không thấy quái là đã chạy ra cổng hoặc tắt Auto ở ải 167.
- Cờ "đã chết" kiểm tra sai field.

**Lỗi script:**
- Không kiểm tra byte gốc trước khi ghi.
- `.bak` có thể là bản đã patch.
- `--mob` và `--stage` ghi đè lẫn nhau.
- `--stage` không chạy được khi bật riêng.

---

## ⚠️ Lưu ý & Miễn trừ trách nhiệm
- Đã kiểm chứng bằng phân tích tĩnh và test nạp DLL. **Chưa chạy thử trong game.** Hãy thử trên tài khoản phụ trước.
- Bản mod được phát triển cho mục đích học tập, nghiên cứu Reverse Engineering và IL2CPP binary patching. Người dùng tự chịu trách nhiệm khi sử dụng.

---
**Tác giả:** KietTran612
**Học Viện Ninja 186 (G4M Studio)**
