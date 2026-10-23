# Học Viện Ninja (HVNJ 186) - Bản Mod Toàn Diện v2 (8 Tính Năng)

[![Game Version](https://img.shields.io/badge/HVNJ-186-orange.svg)](https://github.com/KietTran612/HVNJ_MOD)
[![Unity](https://img.shields.io/badge/Unity-2020.2.7_x64_IL2CPP-blue.svg)](https://unity.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

Bản mod cho game **Học Viện Ninja (HVNJ 186 by G4M Studio)** bản PC x64 Unity IL2CPP. Mod sửa trực tiếp mã máy trong `GameAssembly.dll`.

> **v2 thay cho v1.** Bản v1 có lỗi làm game crash (cave nhiệm vụ ghi vào vùng code chỉ đọc và đè lên code `ClassAndroid`) và nhiều lỗi logic. Xem mục [Thay đổi so với v1](#-thay-đổi-so-với-v1). Script v2 tự nhận ra DLL đã cài v1 và nâng cấp được.

---

## 🚀 8 Tính Năng

> Tính năng "Tốc độ ra chiêu 0.3s" (`--skill`) **đã bị gỡ**. Xem [Thay đổi so với v1](#-thay-đổi-so-với-v1).

### 1. 🛡️ Né quái Tinh Anh / Thủ Lĩnh / Boss khi Auto — `--mob`
- Auto thường (`mo.dgj`) chọn **quái thường gần nhất**. Quái Tinh Anh (`levelBoss == 1`), Thủ Lĩnh (`levelBoss == 2`) và Boss (`isBos`) bị bỏ qua.
- Auto nhiệm vụ (`mo.dgl`) cũng bỏ qua các loại quái trên.
- **Ngoại lệ:** con tà thú của nhiệm vụ tà thú đang nhận (`la.mad = 1`, template = `la.maj`) vẫn được đánh, vì tà thú là boss. Bản trước sửa thẳng byte trong `mo.dgl` nên chặn luôn tà thú, kể cả khi bấm auto nhiệm vụ của game.

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
- **Chọn cổng:** danh sách cổng của game (`mb.nal`) chứa cổng của **mọi** map. Mod lọc các cổng nằm ở map hiện tại (`le+0x18`), rồi ưu tiên cổng dẫn sang `map + 1` (`le+0x1A`), giống cách bộ tìm đường của game làm. Nếu không có cổng sang `map + 1`, mod dùng cổng đầu tiên dẫn tới một ải lớn hơn, tối đa 167.
- Tính năng này tự kèm phần sửa chọn quái của `mo.dgj` (dùng chung với `--mob`), nên bật riêng `--stage` vẫn chạy được.

**Thí Luyện theo nhóm** (bật cùng `--party`):

| Ai | Làm gì |
|---|---|
| Trưởng nhóm | Auto đánh hết quái, rồi tự qua cổng sang ải kế tiếp, như khi đánh một mình. |
| Thành viên, trưởng nhóm còn trong ải | Đánh đúng con quái trưởng nhóm đang đánh. Trưởng nhóm không đánh thì chạy theo, kể cả khi trưởng nhóm đi tới cổng. |
| Thành viên, trưởng nhóm vừa qua cổng | Đánh nốt quái còn lại quanh mình (nếu có), rồi **đi tới cổng ngay**, không chờ 2.5 giây. Sang ải mới lại gặp trưởng nhóm và tiếp tục theo. |

> ⚠️ **Chưa kiểm chứng trong game:**
> - Client chỉ xử lý riêng map 161. Khoảng ải 161–167 lấy theo bản v1.
> - Chưa rõ Thí Luyện có cho cả nhóm vào cùng một ải hay không. Nếu mỗi người vào một phòng riêng, mỗi nhân vật sẽ tự qua ải như khi đánh một mình.

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

### 7. 💎 Tự luyện đá tại chỗ khi hành trang đầy — `--stone`
Khi **đang bật Auto** mà hành trang chỉ còn **≤ 1 ô trống**, mod bắt đầu một **đợt luyện** ngay tại chỗ, không cần tới NPC. Đá cấp thấp được nâng dần lên cho tới khi không còn nhóm nào luyện được, để Auto nhặt tiếp được đồ.

**Cách game luyện đá** (popup "Luyện đá", lớp `ek`):
- Mỗi loại đá (vật phẩm loại 26, id 0–11 = đá cấp 1–12) có một **điểm** do server gửi (`mc.nde`).
- Bỏ 2–24 viên vào, tổng điểm quyết định cấp đá nhận được và tỉ lệ: tổng điểm **bằng đúng** điểm của một cấp thì ra đá cấp đó với tỉ lệ **100%**, thiếu thì tỉ lệ thấp hơn.
- Phí luyện theo cấp đá nhận được (`mc.ncx`). Nút "Luyện" chỉ gửi packet chứa vị trí các viên đá trong hành trang: cmd 20 nếu trả bằng **yên**, cmd 19 nếu trả bằng **xu**.

**Mod làm gì** (kiểm tra mỗi giây):

| Bước | Chi tiết |
|---|---|
| Chọn đá | Tìm nhóm đá có tổng điểm **bằng đúng** điểm của một cấp cao hơn, nên **chỉ luyện khi chắc chắn 100%** và không mất đá. Ưu tiên cấp thấp nhất, ví dụ 4 viên cấp 1 thành 1 viên cấp 2. Tối đa 24 viên. |
| Kiểm tra tiền | Đủ phí mới gửi lệnh. |
| Gửi lệnh | Gửi packet giống nút "Luyện" của game, nhưng không mở hộp thoại. Mỗi lần luyện một nhóm, rồi chờ 3 giây cho server cập nhật hành trang. |
| Luyện tiếp | Trong đợt luyện, mod luyện tiếp từng nhóm kể cả khi hành trang đã có chỗ trống, nên đá cấp thấp được **nâng dần**: 4 viên cấp 1 thành cấp 2, đủ 4 viên cấp 2 thì thành cấp 3, và cứ thế. |
| Hết nhóm luyện được 100%, hoặc không đủ tiền | Kết thúc đợt. Đợt mới chỉ bắt đầu khi hành trang lại đầy. |
| Server không xử lý | Gửi 2 lần mà hành trang không đổi (ví dụ server đòi phải đứng gần NPC) thì nghỉ 5 phút rồi mới thử lại, không spam. |

- **Trả phí:** mặc định bằng **yên**: nếu thiếu yên thì server lấy thêm xu, và đá nhận được **bị khóa**, giống nút luyện bằng yên của game.
- Dùng `--stone-pay xu` để trả bằng **xu**. Khi đó mod chỉ gộp đá cùng trạng thái khóa, nên đá không khóa luyện ra vẫn không khóa.
- **Chọn cấp đá đích:** `--stone-levels A-B` luyện dần từ đá cấp A lên đá cấp B (1 ≤ A < B ≤ 12). Có viên đá cấp B nào là mod **cất vào rương đồ** (cmd 17, giống lệnh chuyển đồ vào rương của game) rồi luyện tiếp.
  - Ví dụ `--stone-levels 6` (tức 1–6): nâng dần đá cấp 1 lên tới cấp 6, cất từng viên cấp 6 vào rương.
  - `--stone-levels 3-6`: chỉ dùng đá từ cấp 3, nên đá cấp 1–2 được giữ nguyên.
  - Đá cao hơn cấp B không bị đụng tới.
  - `--stone-levels all`: luyện mọi cấp và không cất rương. Đây là mặc định.
  - Mod chỉ cất được khi client đã có danh sách rương, tức bạn đã **mở rương đồ ít nhất một lần** từ lúc vào game, và rương còn chỗ trống. Nếu không, viên đá cấp B nằm lại trong hành trang và mod vẫn luyện tiếp bình thường.
  - Gửi lệnh cất 2 lần mà không được (ví dụ server bắt đứng gần thủ kho) thì mod ngừng cất 30 phút. Việc luyện vẫn tiếp tục.
- Các tuỳ chọn trả phí và cấp đá được lưu trong DLL. Chạy script lại với tính năng khác thì vẫn giữ nguyên, `--status` có hiển thị.
- Không đụng tới đá đang được chọn trong popup Luyện đá. Khi popup đang mở thì mod không chạy.
- Không chạy khi chết hoặc khi Auto tắt.

> ⚠️ **Chưa kiểm chứng trong game:**
> - Client cho mở popup Luyện đá ở bất cứ đâu bằng vật phẩm id 729 trong hành trang. Popup đó gửi cùng packet mà mod gửi, nên chắc chắn chạy khi có vật phẩm này. Không có vật phẩm 729 thì server **có thể** bắt phải đứng gần NPC. Khi đó mod tự nghỉ như mô tả ở bảng trên.
> - Cất đá vào rương từ xa: client gửi lệnh chuyển đồ vào rương mà không kèm điều kiện gì, nhưng server có thể chỉ cho chuyển khi đang mở rương ở NPC.

### 8. 🐉 Auto nhiệm vụ tà thú — `--tathu`
Giống `--quest`, mod dùng lại pipeline "tự động làm nhiệm vụ" có sẵn của game, vốn đã xử lý cả tà thú (`la.mad = 1`).

**Game có sẵn** (`mo.dga` → `mo.dgh`, `mo.dgd`):
- **Đi:** tự tìm đường tới map tà thú (`la.mak`). Khác nhiệm vụ ngày, game không dùng NPC dịch chuyển.
- **Đánh:** tìm con tà thú (template `la.maj`). Có thì bật Auto đánh nó, chưa có thì báo "Tà thú chưa xuất hiện".
- **Trả:** giết đủ thì về NPC 25 và gửi `menu(25, 1, 2)`. Vậy **menu 1** của NPC 25 là menu tà thú (nhiệm vụ ngày dùng menu 0).
- **Nhận:** game không tự nhận nhiệm vụ.

**Mod làm thêm** (chung vòng lặp với `--quest`, bắt đầu khi bật Auto ngoài Thí Luyện):

| Tình huống | Mod làm gì |
|---|---|
| Chưa có nhiệm vụ tà thú | Về trường theo hệ phái, tới NPC 25, gửi `menu(25, 1, N)` để **nhận**. N dùng chung với `--accept-option`, mặc định 0. Bật cùng `--quest` thì nhận và làm nhiệm vụ ngày trước. Nhận nhiệm vụ ngày 4 lần không được (hết lượt) thì chuyển sang tà thú. |
| Có nhiệm vụ, chưa ở map tà thú | Gọi pipeline của game để nó tự tìm đường tới map. |
| Ở map tà thú, tà thú chưa xuất hiện | Để Auto đánh quái thường, **cứ 15 giây gọi lại pipeline**. Khi tà thú xuất hiện, game tự chuyển sang đánh nó. Không bỏ cuộc sau 3 lần như nhiệm vụ ngày. |
| Đã giết tà thú | Game tự về NPC 25 trả nhiệm vụ. Mod tiếp tục nhận lượt kế tiếp. |

**Dừng khi:**
- tắt Auto lúc đang ở map tà thú;
- nhận 4 lần không được;
- kẹt nhiều lần khi đi đường;
- nhân vật chưa vào lớp.

> ⚠️ **Chưa kiểm chứng trong game:** option **nhận** trong menu tà thú = 0 là suy luận, giống nhiệm vụ ngày. Menu 1 và option 2 (trả) lấy từ code game nên chắc chắn. Nếu nhận không được, thử `--accept-option 1`. Lưu ý tuỳ chọn này đổi cả option nhận nhiệm vụ ngày.

---

## 🛠️ Cách dùng

Cần Python 3.8+ (chỉ dùng thư viện chuẩn). Chạy trong thư mục game và **tắt game trước khi chạy**:

```bash
python patch_skill_delay.py --status          # xem trạng thái
python patch_skill_delay.py --all             # bật cả 8 tính năng
python patch_skill_delay.py --party           # chỉ thêm đánh theo nhóm (máy thành viên)
python patch_skill_delay.py --tathu           # thêm auto nhiệm vụ tà thú
python patch_skill_delay.py --stone           # thêm tự luyện đá (trả yên)
python patch_skill_delay.py --stone-pay xu    # luyện đá trả bằng xu (đá không khóa vẫn không khóa)
python patch_skill_delay.py --stone-levels 6   # nâng dần đá lên cấp 6, cất đá cấp 6 vào rương; all = mọi cấp
python patch_skill_delay.py --mob --stage     # bật thêm tính năng (giữ các tính năng đang bật)
python patch_skill_delay.py --remove quest    # tắt một tính năng
python patch_skill_delay.py --accept-option 1 # đổi option nhận nhiệm vụ
python patch_skill_delay.py --restore         # trả về bản gốc
```

- Mỗi lần chạy, script **dựng lại DLL từ bản gốc** (đã kiểm tra SHA-256) rồi áp đúng tập tính năng, nên thứ tự chạy không gây xung đột.
- Bản gốc được giữ ở `GameAssembly.dll.bak`. Nếu file này mất hoặc không phải bản gốc, script tự khôi phục bản gốc từ DLL đã mod (kể cả bản v1).
- Nếu game cập nhật lên phiên bản khác (SHA-256 không khớp), script từ chối patch để tránh làm hỏng DLL.
- DLL cũ còn patch "0.3s" sẽ được gỡ patch đó ở lần chạy script kế tiếp (`--status` có cảnh báo).

Cách nhanh: chép `GameAssembly.dll` trong repo (đã bật đủ 8 tính năng, luyện đá trả yên) vào thư mục game.

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
- dựng lại đủ 256 tổ hợp tính năng (cả 2 kiểu trả phí và giới hạn cấp đá) và khôi phục được bản gốc;
- **chạy thật mã máy luyện đá** (`stone_tick`) trong DLL đã nạp:
  - các hàm game được thay bằng callback Python;
  - nhân vật, hành trang và bảng điểm đá là dữ liệu giả;
  - kiểm tra packet gửi ra ở 24 tình huống: chọn đá, chờ/gửi lại/nghỉ, đủ hay thiếu phí, đá khóa khi trả xu, leo cấp tới cấp đích rồi cất rương, rương chưa nạp/đầy/bị từ chối, gộp nhiều cấp, giới hạn 24 viên;
- **chạy thật mã máy auto nhiệm vụ** (`quest_tick`) với NPC, map và nhiệm vụ giả, ở 9 tình huống: thứ tự nhận (ngày → tà thú), menu nhận tà thú, ưu tiên nhiệm vụ ngày, chờ tà thú xuất hiện, tắt Auto thì dừng;
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
| `0x1BA48E` | `mo.dgl` | lọc quái của auto nhiệm vụ (trừ con tà thú của nhiệm vụ tà thú) |
| `0x24B5AC` | `lm.clo` | chọn mục tiêu: theo trưởng nhóm, tự qua ải Thí Luyện |
| `0x19495E` | `mo.ctq` | mỗi frame: luyện đá, chết - quay về, đánh theo nhóm, nhiệm vụ hàng ngày (sau `mo.dgd`) |
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
