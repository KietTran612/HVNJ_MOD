# Học Viện Ninja (HVNJ 186) - Bản Mod Toàn Diện v3 (9 Tính Năng, bật / tắt trong game)

[![Game Version](https://img.shields.io/badge/HVNJ-186-orange.svg)](https://github.com/KietTran612/HVNJ_MOD)
[![Unity](https://img.shields.io/badge/Unity-2020.2.7_x64_IL2CPP-blue.svg)](https://unity.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

Bản mod cho game **Học Viện Ninja (HVNJ 186 by G4M Studio)** bản PC x64 Unity IL2CPP. Mod sửa trực tiếp mã máy trong `GameAssembly.dll`.

> **v3:** mọi tính năng được bật / tắt bằng **menu "Mod HVNJ" ngay trong game**, mặc định tắt hết. Tính năng nào được tick thì mới chạy, chưa tick thì game chạy y như bản gốc. Script chỉ còn việc cài và gỡ mod. Script tự nhận ra DLL đã cài bản v1 / v2 cũ và nâng cấp được. Bản v1 có lỗi crash, xem [Thay đổi so với v1](#-thay-đổi-so-với-v1).

---

## 🎛️ Bật / tắt tính năng trong game: menu "Mod HVNJ"

1. Cài mod (xem [Cách dùng](#-cách-dùng)), vào game.
2. Mở **menu nhân vật** (nút menu trên màn hình chơi). Dòng **cuối cùng** là **"Mod HVNJ"**.
3. Bấm vào để mở menu Mod. Mỗi dòng là một tính năng: `[x]` = đang bật, `[   ]` = đang tắt. Bấm vào dòng để đổi; menu tự mở lại để bạn thấy trạng thái mới.

| Dòng | Tác dụng |
|---|---|
| Né Boss / Tinh Anh / Thủ Lĩnh khi Auto | tính năng 1 |
| Chết: về làng ngay, quay lại map, bật Auto | tính năng 2 |
| Giữ Auto trong Thí Luyện | tính năng 3 |
| Tự qua ải Thí Luyện 161 -> 167 | tính năng 4 (nên bật cùng dòng trên) |
| Auto nhiệm vụ hàng ngày | tính năng 5 |
| Auto nhiệm vụ tà thú | tính năng 8 |
| Đánh theo nhóm (theo trưởng nhóm) | tính năng 6 |
| Tự bán đồ thiếu dòng, cất đồ đủ dòng vào rương | tính năng 9 |
| Xem trước trang bị sẽ bán | mở menu liệt kê món sẽ bán / cất rương / giữ, không bán gì |
| Tự luyện đá khi đầy (chỉ trả bằng yên) | tính năng 7 |
| Luyện đá lên cấp: … | mỗi lần bấm: mọi cấp → 2 → 3 → … → 12 → mọi cấp. Chọn cấp thì đá đạt cấp đó được cất vào rương |
| Luyện đá từ cấp: … | chỉ hiện khi đã chọn cấp đích; mỗi lần bấm tăng 1 (vòng lại 1) |
| Option nhận nhiệm vụ ở NPC: … | 0 → 1 → 2 → 3 (dùng khi nhận nhiệm vụ không được) |
| Mở rương đồ | mở bảng rương đồ ở bất kỳ map nào |
| Mở nâng cấp trang bị | mở bảng nâng cấp trang bị ở bất kỳ map nào |
| Đóng | đóng menu |

- **Không auto nào dùng xu.** Chỉ luyện đá là tốn phí, và chỉ trả bằng yên. Bán trang bị thì nhận về yên.
- **Nút Shop trên thanh Top luôn hiện ở mọi map.** Sửa cố định, không có dòng tick (xem [Nút Shop](#-nút-shop-luôn-hiện-ở-mọi-map)).
- **Nút "Rương" và "Nâng cấp" ở cuối hàng 2 thanh Top** mở rương đồ / nâng cấp trang bị ở bất kỳ map nào. Cũng là sửa cố định (xem [Nút Rương / Nâng cấp](#-nút-rương-và-nâng-cấp-trên-thanh-top)).
- **Mặc định tắt hết.** Lựa chọn được lưu (Unity `PlayerPrefs`, khóa `HVNJ_MOD`) nên lần mở game sau vẫn giữ.
- Tick / bỏ tick một tính năng đang chạy dở thì trạng thái dở dang của nó được xoá. Auto nhiệm vụ / tà thú bắt đầu khi bạn **bật Auto** sau khi đã tick.

---

## 🚀 9 Tính Năng

> Tính năng "Tốc độ ra chiêu 0.3s" **đã bị gỡ**. Xem [Thay đổi so với v1](#-thay-đổi-so-với-v1).

### 1. 🛡️ Né quái Tinh Anh / Thủ Lĩnh / Boss khi Auto
- Auto thường (`mo.dgj`) chọn **quái thường gần nhất**. Quái Tinh Anh (`levelBoss == 1`), Thủ Lĩnh (`levelBoss == 2`) và Boss (`isBos`) bị bỏ qua.
- Auto nhiệm vụ (`mo.dgl`) cũng bỏ qua các loại quái trên.
- **Ngoại lệ:** con tà thú của nhiệm vụ tà thú đang nhận (`la.mad = 1`, template = `la.maj`) vẫn được đánh, vì tà thú là boss. Bản trước sửa thẳng byte trong `mo.dgl` nên chặn luôn tà thú, kể cả khi bấm auto nhiệm vụ của game.

### 2. ⏱️ Chết: về làng ngay, quay lại map cũ, bật lại Auto
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
- Nếu auto nhiệm vụ ngày đang chạy thì để nó tự đưa nhân vật về map nhiệm vụ.
- Trong lúc xử lý chết, đánh theo nhóm và auto nhiệm vụ tạm dừng. Về tới map cũ thì đánh theo nhóm tiếp tục như bình thường.
- Chết lúc **không** bật Auto: mod không làm gì.

### 3. 🏰 Giữ Auto trong Thí Luyện
Game không còn tự tắt Auto khi vào map 161 và không còn chặn tìm đường trong map 161. Khi chết và hồi sinh ở cửa, Auto tự chạy lại bãi quái.

### 4. 🎯 Tự qua ải Thí Luyện 161 → 167
- Trong Thí Luyện, Auto đánh **mọi** quái, kể cả Boss và Thủ Lĩnh, để dọn sạch ải.
- Nếu không tìm thấy quái nào **liên tục 2.5 giây**:
  - ở ải 161–166: nhân vật chạy tới cổng sang ải kế tiếp;
  - ở ải 167: Auto tự tắt.
- **Chọn cổng:** danh sách cổng của game (`mb.nal`) chứa cổng của **mọi** map. Mod lọc các cổng nằm ở map hiện tại (`le+0x18`), rồi ưu tiên cổng dẫn sang `map + 1` (`le+0x1A`), giống cách bộ tìm đường của game làm. Nếu không có cổng sang `map + 1`, mod dùng cổng đầu tiên dẫn tới một ải lớn hơn, tối đa 167.
- Tính năng này tự kèm phần sửa chọn quái của `mo.dgj` (dùng chung với Né Boss), nên bật riêng vẫn chạy được.

**Thí Luyện theo nhóm** (bật cùng Đánh theo nhóm):

| Ai | Làm gì |
|---|---|
| Trưởng nhóm | Auto đánh hết quái, rồi tự qua cổng sang ải kế tiếp, như khi đánh một mình. |
| Thành viên, trưởng nhóm còn trong ải | Đánh đúng con quái trưởng nhóm đang đánh. Trưởng nhóm không đánh thì chạy theo, kể cả khi trưởng nhóm đi tới cổng. |
| Thành viên, trưởng nhóm vừa qua cổng | Đánh nốt quái còn lại quanh mình (nếu có), rồi **đi tới cổng ngay**, không chờ 2.5 giây. Sang ải mới lại gặp trưởng nhóm và tiếp tục theo. |

> ⚠️ **Chưa kiểm chứng trong game:**
> - Client chỉ xử lý riêng map 161. Khoảng ải 161–167 lấy theo bản v1.
> - Chưa rõ Thí Luyện có cho cả nhóm vào cùng một ải hay không. Nếu mỗi người vào một phòng riêng, mỗi nhân vật sẽ tự qua ải như khi đánh một mình.

### 5. 📜 Auto nhiệm vụ hàng ngày
Mod không tự viết logic đi lại hay đánh quái mà gọi lại chức năng **"Bấm vào đây để tự động làm nhiệm vụ"** có sẵn trong game (`mo.dga` → `mo.dgh`).

**Bắt đầu:** bật **Auto** ở một map ngoài Thí Luyện. Từ lúc đó mod chạy vòng lặp sau (cứ 0.5 giây kiểm tra một lần):

| Tình huống | Mod làm gì |
|---|---|
| Chưa có nhiệm vụ hàng ngày | Tìm đường về trường theo hệ phái (map 1 / 72 / 27 / 160), đi tới NPC 25, gửi `menu(25, 0, N)` để **nhận** nhiệm vụ. N mặc định là 0, đổi bằng dòng "Option nhận nhiệm vụ ở NPC" trong menu Mod. |
| Có nhiệm vụ, chưa ở map nhiệm vụ | Gọi auto nhiệm vụ của game. Nếu đang đứng cạnh NPC 25, game tự chọn option 3 để **dịch chuyển thẳng tới map nhiệm vụ**; nếu không thì tìm đường tới đó. |
| Đang ở map nhiệm vụ | Game tự bật Auto và đánh đúng loại quái. Nếu bật Né Boss, Tinh Anh/Thủ Lĩnh vẫn bị né. |
| Đánh đủ số lượng | Game tự về trường gặp NPC 25 và chọn option 2 để **trả** nhiệm vụ. Mod tiếp tục nhận nhiệm vụ mới. |
| Vào Thí Luyện (161–167) | Tạm dừng, nhường cho Tự qua ải. |

**Dừng:**
- **Tắt Auto** lúc đang đánh ở map nhiệm vụ.
- Nhận nhiệm vụ 4 lần không được: hết lượt trong ngày, hoặc sai option.
- Gọi auto nhiệm vụ 3 lần liên tiếp mà không có tiến triển.
- Tìm đường về trường 6 lần (khoảng 60 giây) mà không tới được.
- Nhân vật chưa vào lớp.

Muốn chạy lại thì bật Auto lần nữa.

> ⚠️ **Phần chưa kiểm chứng trong game:** menu của NPC do server gửi xuống. Option 2 (trả) và 3 (đi tới) là những option chính code game dùng. Option **nhận** nhiệm vụ = 0 là **suy luận** theo thứ tự menu kiểu Ninja School (Nhận / Hủy / Hoàn thành / Đi tới). Nếu nhận không được, bấm dòng "Option nhận nhiệm vụ ở NPC" trong menu Mod để thử 1, 2…

> Bản v1 có "Thông Thành Phù" và "tự mua phù bằng Yên". Hai chức năng này **đã bị bỏ**: lệnh v1 gọi (`lj.cqj`) thực chất là lệnh xin lại dữ liệu map, không phải lệnh dùng phù, còn lệnh mua dùng chỉ số cửa hàng chưa được kiểm chứng. Thay vào đó, v2 dùng dịch chuyển qua NPC (option 3) của chính game.

### 6. 👥 Đánh theo nhóm
Dành cho **thành viên** trong nhóm (máy của mỗi thành viên đều cần cài mod và tick dòng này). Thành viên chỉ cần **bật Auto**:

| Tình huống | Thành viên làm gì |
|---|---|
| Trưởng nhóm đang đánh một con quái còn sống | Đánh **đúng con quái đó**: chuyển mục tiêu ngay, Auto tự chạy tới đánh. Kể cả Boss/Thủ Lĩnh, dù có bật Né Boss. |
| Trưởng nhóm không đánh gì | Bỏ mục tiêu riêng và **chạy theo trưởng nhóm** khi cách xa hơn 40 đơn vị (cập nhật mỗi 0.5 giây). |
| Mình là trưởng nhóm, chưa vào nhóm, tắt Auto, hoặc trưởng nhóm ở map khác | Không can thiệp: Auto hoạt động như bình thường. |

- Khi đang đi theo trưởng nhóm, auto nhiệm vụ ngày tạm dừng.
- Thông tin lấy từ chính client:
  - danh sách nhóm `gb.hxf` (`List<ko>`);
  - nhân vật trong map tìm qua `mo.djf(charId)`;
  - con quái trưởng nhóm đang đánh là `lm.mjn`, do game ghi khi nhận gói "người chơi khác tấn công".
- Tắt tính năng: tắt Auto, hoặc bỏ tick trong menu Mod.

> ⚠️ **Chưa kiểm chứng trong game:** trưởng nhóm được hiểu là **người đứng đầu danh sách nhóm**. Đó là thứ tự server gửi, và theo quy ước kiểu Ninja School thì người đầu tiên là trưởng nhóm. Thành viên chỉ đi theo được khi **cùng map** với trưởng nhóm, chưa tự tìm đường sang map khác.

### 7. 💎 Tự luyện đá tại chỗ khi hành trang đầy
Khi **đang bật Auto** mà hành trang chỉ còn **≤ 1 ô trống**, mod bắt đầu một **đợt luyện** ngay tại chỗ, không cần tới NPC. Nếu cũng tick bán trang bị thì đợt luyện chạy **ngay sau khi bán xong** (xem [tính năng 9](#9--tự-bán-đồ-thiếu-dòng-cất-đồ-đủ-dòng--phiên-dọn-hành-trang)). Đá cấp thấp được nâng dần lên cho tới khi không còn nhóm nào luyện được, để Auto nhặt tiếp được đồ.

**Cách game luyện đá** (popup "Luyện đá", lớp `ek`):
- Mỗi loại đá (vật phẩm loại 26, id 0–11 = đá cấp 1–12) có một **điểm** do server gửi (`mc.nde`).
- Bỏ 2–24 viên vào, tổng điểm quyết định cấp đá nhận được và tỉ lệ: tổng điểm **bằng đúng** điểm của một cấp thì ra đá cấp đó với tỉ lệ **100%**, thiếu thì tỉ lệ thấp hơn.
- Phí luyện theo cấp đá nhận được (`mc.ncx`). Nút "Luyện" chỉ gửi packet chứa vị trí các viên đá trong hành trang: cmd 20 nếu trả bằng **yên**, cmd 19 nếu trả bằng **xu**. Mod chỉ dùng cmd 20.

**Mod làm gì** (kiểm tra mỗi giây):

| Bước | Chi tiết |
|---|---|
| Chọn đá | Tìm nhóm đá có tổng điểm **bằng đúng** điểm của một cấp cao hơn, nên **chỉ luyện khi chắc chắn 100%** và không mất đá. Ưu tiên cấp thấp nhất, ví dụ 4 viên cấp 1 thành 1 viên cấp 2. Tối đa 24 viên. |
| Kiểm tra tiền | Chỉ tính **yên**: riêng yên đủ phí mới gửi lệnh, thiếu yên thì không luyện (dù có xu). |
| Gửi lệnh | Gửi packet giống nút "Luyện" của game, nhưng không mở hộp thoại. Mỗi lần luyện một nhóm, rồi chờ 3 giây cho server cập nhật hành trang. |
| Luyện tiếp | Trong đợt luyện, mod luyện tiếp từng nhóm kể cả khi hành trang đã có chỗ trống, nên đá cấp thấp được **nâng dần**: 4 viên cấp 1 thành cấp 2, đủ 4 viên cấp 2 thì thành cấp 3, và cứ thế. |
| Hết nhóm luyện được 100%, hoặc không đủ tiền | Kết thúc đợt. Đợt mới chỉ bắt đầu khi hành trang lại đầy. |
| Server không xử lý | Gửi 2 lần mà hành trang không đổi (ví dụ server đòi phải đứng gần NPC) thì nghỉ 5 phút rồi mới thử lại, không spam. |

- **Trả phí: chỉ bằng yên, không bao giờ dùng xu.** Nút luyện bằng yên của game cho phép thiếu yên thì lấy thêm xu; mod tránh điều đó bằng cách chỉ luyện khi riêng yên đã đủ phí. Đá nhận được **bị khóa**, giống nút luyện bằng yên của game. Đá khóa và không khóa được gộp chung.
- **Chọn cấp đá đích:** dòng "Luyện đá lên cấp: B" và "Luyện đá từ cấp: A" trong menu Mod: luyện dần từ đá cấp A lên đá cấp B (1 ≤ A < B ≤ 12). Có viên đá cấp B nào là mod **cất vào rương đồ** (cmd 17, giống lệnh chuyển đồ vào rương của game) rồi luyện tiếp.
  - Ví dụ lên cấp 6, từ cấp 1: nâng dần đá cấp 1 lên tới cấp 6, cất từng viên cấp 6 vào rương.
  - Lên cấp 6, từ cấp 3: chỉ dùng đá từ cấp 3, nên đá cấp 1–2 được giữ nguyên.
  - Đá cao hơn cấp B không bị đụng tới.
  - "Lên cấp: mọi cấp": luyện mọi cấp và không cất rương. Đây là mặc định.
  - Mod chỉ cất được khi client đã có danh sách rương, tức bạn đã **mở rương đồ ít nhất một lần** từ lúc vào game, và rương còn chỗ trống. Nếu không, viên đá cấp B nằm lại trong hành trang và mod vẫn luyện tiếp bình thường.
  - Gửi lệnh cất 2 lần mà không được (ví dụ server bắt đứng gần thủ kho) thì mod ngừng cất 30 phút. Việc luyện vẫn tiếp tục.
- Không đụng tới đá đang được chọn trong popup Luyện đá. Khi popup đang mở thì mod không chạy.
- Không chạy khi chết hoặc khi Auto tắt.

> ⚠️ **Chưa kiểm chứng trong game:**
> - Client cho mở popup Luyện đá ở bất cứ đâu bằng vật phẩm id 729 trong hành trang. Popup đó gửi cùng packet mà mod gửi, nên chắc chắn chạy khi có vật phẩm này. Không có vật phẩm 729 thì server **có thể** bắt phải đứng gần NPC. Khi đó mod tự nghỉ như mô tả ở bảng trên.
> - Cất đá vào rương từ xa: client gửi lệnh chuyển đồ vào rương mà không kèm điều kiện gì, nhưng server có thể chỉ cho chuyển khi đang mở rương ở NPC.

### 8. 🐉 Auto nhiệm vụ tà thú
Giống auto nhiệm vụ ngày, mod dùng lại pipeline "tự động làm nhiệm vụ" có sẵn của game, vốn đã xử lý cả tà thú (`la.mad = 1`).

**Game có sẵn** (`mo.dga` → `mo.dgh`, `mo.dgd`):
- **Đi:** tự tìm đường tới map tà thú (`la.mak`). Khác nhiệm vụ ngày, game không dùng NPC dịch chuyển.
- **Đánh:** tìm con tà thú (template `la.maj`). Có thì bật Auto đánh nó, chưa có thì báo "Tà thú chưa xuất hiện".
- **Trả:** giết đủ thì về NPC 25 và gửi `menu(25, 1, 2)`. Vậy **menu 1** của NPC 25 là menu tà thú (nhiệm vụ ngày dùng menu 0).
- **Nhận:** game không tự nhận nhiệm vụ.

**Mod làm thêm** (chung vòng lặp với auto nhiệm vụ ngày, bắt đầu khi bật Auto ngoài Thí Luyện):

| Tình huống | Mod làm gì |
|---|---|
| Chưa có nhiệm vụ tà thú | Về trường theo hệ phái, tới NPC 25, gửi `menu(25, 1, N)` để **nhận**. N dùng chung dòng "Option nhận nhiệm vụ ở NPC", mặc định 0. Bật cùng auto nhiệm vụ ngày thì nhận và làm nhiệm vụ ngày trước. Nhận nhiệm vụ ngày 4 lần không được (hết lượt) thì chuyển sang tà thú. |
| Có nhiệm vụ, chưa ở map tà thú | Gọi pipeline của game để nó tự tìm đường tới map. |
| Ở map tà thú, tà thú chưa xuất hiện | Để Auto đánh quái thường, **cứ 15 giây gọi lại pipeline**. Khi tà thú xuất hiện, game tự chuyển sang đánh nó. Không bỏ cuộc sau 3 lần như nhiệm vụ ngày. |
| Đã giết tà thú | Game tự về NPC 25 trả nhiệm vụ. Mod tiếp tục nhận lượt kế tiếp. |

**Dừng khi:**
- tắt Auto lúc đang ở map tà thú;
- nhận 4 lần không được;
- kẹt nhiều lần khi đi đường;
- nhân vật chưa vào lớp.

> ⚠️ **Chưa kiểm chứng trong game:** option **nhận** trong menu tà thú = 0 là suy luận, giống nhiệm vụ ngày. Menu 1 và option 2 (trả) lấy từ code game nên chắc chắn. Nếu nhận không được, đổi dòng "Option nhận nhiệm vụ ở NPC" sang 1. Lưu ý dòng này đổi cả option nhận nhiệm vụ ngày.

### 9. 🧹 Tự bán đồ thiếu dòng, cất đồ đủ dòng & phiên dọn hành trang
Khi **đang bật Auto** mà hành trang chỉ còn **≤ 1 ô trống**, mod mở một **phiên dọn hành trang**, làm lần lượt từng việc, mỗi lúc một việc:

1. **Bán trang bị thiếu dòng, cất trang bị đủ dòng vào rương** (dòng tick "Tự bán đồ thiếu dòng, cất đồ đủ dòng vào rương"). Làm theo thứ tự ô trong hành trang.
2. **Luyện đá** (tính năng 7). Bước này chạy ngay sau bước 1, kể cả khi bước 1 đã làm trống chỗ.
3. **Cất đá cấp đích vào rương** (nằm trong tính năng 7).

Bán và luyện đều gửi lệnh theo **vị trí ô** trong hành trang, nên chạy song song có thể bán hoặc luyện nhầm ô. Vì vậy mỗi lệnh đều chờ server trả về rồi mới gửi lệnh tiếp. Trong lúc phiên chạy:
- **auto nhiệm vụ / tà thú tạm dừng**, xong phiên mới chạy tiếp;
- đánh theo nhóm vẫn chạy, vì chỉ di chuyển;
- xử lý chết được ưu tiên hơn hết. Đang chết thì phiên không chạy.

**Món nào bị bán** (phải thỏa tất cả):

| Điều kiện | Chi tiết |
|---|---|
| Loại | Trang phục (nón, áo, găng tay, quần, giày), trang sức (dây chuyền, nhẫn, ngọc bội, phù) hoặc vũ khí |
| Chưa nâng cấp | Đồ +1 trở lên giữ lại (game cũng bắt tách trước khi bán) |
| Không có dòng đặc biệt | Đồ có dòng khảm ngọc / trục luyện giữ lại |
| Không khóa | Đồ khóa giữ lại |
| **Ít dòng chỉ số hơn món cùng mẫu bán trong shop** | Chỉ so **số dòng**, không xét giá trị từng dòng. Bằng hoặc nhiều dòng hơn thì giữ |

Mọi thứ khác **không bao giờ bị bán**: thời trang, đá, bình HP/MP, thức ăn, đồ nhiệm vụ, nguyên liệu, mẫu không có trong shop, và món mod chưa biết số dòng của bản shop.

**Món nào được cất vào rương:** trang bị qua đủ các điều kiện trên (cùng loại, +0, không khóa, không dòng đặc biệt) nhưng có số dòng **bằng hoặc nhiều hơn** bản shop. Mod gửi cmd 17 (ô), giống lệnh chuyển đồ vào rương của game, cho tới khi **rương đầy** thì thôi; món còn lại giữ trong hành trang.
- Mod chỉ biết rương còn chỗ khi client đã có danh sách rương, tức bạn đã **mở rương đồ ít nhất một lần** từ lúc vào game.
- Server không chuyển (ví dụ bắt đứng ở thủ kho) thì mod thôi cất 30 phút, việc bán vẫn chạy.
- Đồ đã nâng cấp, khóa, có dòng khảm ngọc / trục luyện, mẫu không có trong shop không bị cất.

**Lấy số dòng của bản trong shop** (ngầm, không cần về làng, không bật cửa hàng lên màn hình):

| Bước | Lệnh (giống game) |
|---|---|
| Tải danh sách hàng của cửa hàng có bán loại đồ đó | cmd -30 / -103 + mã danh sách, như bấm thẻ cửa hàng: vũ khí 2; dây chuyền 16, nhẫn 17, ngọc bội 18, phù 19; nón 20/21, áo 22/23, găng 24/25, quần 26/27, giày 28/29 (số chẵn = nam, lẻ = nữ) |
| Xem chi tiết món cùng mẫu | cmd 42 + mã danh sách + ô, như bấm vào món trong shop |
| Ghi nhớ | Số dòng theo mẫu được lưu trong PlayerPrefs `HVNJ_SHOP`, nên mỗi mẫu chỉ phải hỏi **một lần** |

Khi cửa hàng chưa mở, game chỉ lưu dữ liệu về: `fp.boa` / `fp.bor` thoát ngay khi chưa dựng bảng shop.

**Bán:** gửi cmd 14 (ô, số lượng) giống lệnh bán của game nhưng không mở hộp thoại. Server trả về số **yên** mới. Không đụng tới xu.

**Không spam:**
- Mỗi lệnh cách nhau ít nhất 0,5 giây và phải chờ server trả lời (tối đa 3 giây).
- Một danh sách shop không về thì 5 phút sau mới xin lại.
- 3 lệnh liên tiếp không được trả lời thì nghỉ 5 phút.
- Hết món để bán thì 30 giây sau mới xét lại.

**Xem trước:** dòng "Xem trước trang bị sẽ bán" trong menu Mod mở một menu liệt kê từng món, ví dụ `Áo vải: 2/4 dòng -> bán`, `Áo da: 4/3 dòng -> cất rương` (hoặc `giữ (rương đầy)`, `giữ (mở rương 1 lần để cất)`). Mở menu này thì mod cũng lấy dần số dòng shop còn thiếu, kể cả khi chưa tick bán, Auto đang tắt hay hành trang chưa đầy. Menu này **không bán gì**. Bấm một dòng bất kỳ để xem lại.

> ⚠️ **Chưa kiểm chứng trong game:** client không chặn tải danh sách shop, xem chi tiết hay bán khi đứng xa NPC, nhưng chưa biết server có chấp nhận không. Nếu server không trả lời thì mod tự nghỉ như trên. Số dòng được đếm giống nhau cho món trong hành trang và bản shop (mọi dòng trong dữ liệu món đồ); nên mở "Xem trước" để đối chiếu với số dòng thấy trong game trước khi bật bán.

### 📦 Mở rương đồ / nâng cấp trang bị ở bất kỳ map nào
Hai dòng **"Mở rương đồ"** và **"Mở nâng cấp trang bị"** trong menu Mod mở bảng tương ứng của game ngay tại chỗ. Đây là lệnh bấm là chạy, không có tick.

- Game mở mọi bảng bằng `mo.djd(loại)`: rương đồ = 4, nâng cấp trang bị = 10. Bình thường hàm này chạy khi server báo "mở bảng" sau lúc nói chuyện với NPC, nhưng chính client cũng tự gọi nó (ví dụ nút Auto trên thanh Top), nên mod gọi được ở bất kỳ map nào.
- **Rương đồ:** nếu từ lúc vào game đã mở rương lần nào thì bảng hiện ngay danh sách rương. Nếu chưa, bảng xin danh sách từ server.
- **Nâng cấp trang bị:** bảng dùng đồ trong hành trang nên mở là có đủ.

> ⚠️ **Chưa kiểm chứng trong game:** client không chặn mở các bảng này ở xa NPC, nhưng chưa biết server có trả danh sách rương, cho chuyển đồ ra / vào rương, hay cho nâng cấp (cmd 21) khi đứng xa NPC không.

### 🔘 Nút "Rương" và "Nâng cấp" trên thanh Top
Sửa cố định, **không có dòng tick**: cài mod là có. Bấm "Rương" mở rương đồ, bấm "Nâng cấp" mở bảng nâng cấp trang bị, ở bất kỳ map nào.

**Vị trí, không đè và không bị che:** thanh Top (góc trên bên phải) được game xếp lại mỗi frame thành 2 hàng (`mo.dhp`):
- hàng 1: nút Shop rồi sang trái, mỗi nút cách 30;
- hàng 2: thấp hơn 30, bắt đầu lệch nửa nút bên phải nút Shop rồi sang trái, tối đa 5 nút.

Mỗi 0,25 giây mod đọc vị trí thật các nút hàng 2 (`hk.bvx` lưu ở `hk+18h`) và đặt "Rương", "Nâng cấp" **nối tiếp ngay sau nút trái nhất của hàng 2**. Hàng 2 trống thì hai nút nằm đúng chỗ game đặt nút đầu hàng 2. Nút hàng 2 thêm / bớt thì hai nút dời theo, nên không đè lên nút nào của thanh Top.

- Tạo đúng như game tạo nút Shop (`mo.dhp`): `ho.bzc` (nút ảnh, cùng ảnh nền với nút Shop) + `ho.cab` (chữ, cùng font / màu), hành động là `mo.mk(mo, id)` giống nút Shop.
- Hai nút là **con của nút Shop**, nên đi theo vị trí (cả hiệu ứng thu / mở thanh Top) và ẩn / hiện cùng nút Shop.
- Bấm nút thì game gọi `mo.dhe(id)` như mọi nút trên thanh Top; mod chặn ở lệnh đầu của `mo.dhe` các id riêng của mod (`0x48560100+`) rồi gọi `mo.djd(4)` / `mo.djd(10)` (giống dòng "Mở rương đồ" / "Mở nâng cấp trang bị" của menu Mod). Id khác chạy nguyên `mo.dhe` của game.
- Mod kiểm tra mỗi 0,25 giây: nút Shop đã có mà chưa có nút của mod thì tạo; nút Shop được tạo lại thì tạo lại nút.

> ⚠️ **Chưa kiểm chứng trong game:** vị trí được tính từ code xếp nút của game, chưa xem trên màn hình thật. Giao diện không thuộc thanh Top (nếu có ở cuối hàng 2) chưa được kiểm tra. Phần server chấp nhận thao tác ở xa NPC giống như mục trên.

### 🛒 Nút Shop luôn hiện ở mọi map
Sửa cố định, **không có dòng tick**: cài mod là có.

- Nút Shop trên thanh Top mở **cửa hàng tổng** (danh sách cửa hàng mã 7), nơi bán được đồ.
- Game gốc chỉ tạo và hiện nút này ở 13 map làng / trường / phân viện (map 1, 10, 17, 22, 27, 32, 38, 43, 48, 72, 110, 129, 160). Ở map khác nút bị ẩn; vào game ở map khác thì nút còn chưa được tạo.
- Điều kiện đó nằm trong `mo.dhn`. Mod sửa `mo.dhn` thành luôn trả về "có". Chỉ phần nút Shop của thanh Top (`mo.dhp`) gọi hàm này, nên không ảnh hưởng chức năng khác.
- Vẫn giữ điều kiện server bật tính năng shop (`hw+0x166`) của game.

> ⚠️ **Chưa kiểm chứng trong game:** client không chặn mở shop ở map khác, nhưng chưa biết server có trả danh sách hàng và cho bán ở map ngoài làng không. Nếu server không trả thì bấm nút sẽ ra cửa hàng trống.

---

## 🛠️ Cách dùng

Cần Python 3.8+ (chỉ dùng thư viện chuẩn). Chạy trong thư mục game và **tắt game trước khi chạy**:

```bash
python patch_skill_delay.py --install   # cài / cập nhật mod (mọi tính năng tắt, bật trong game)
python patch_skill_delay.py --status    # xem trạng thái
python patch_skill_delay.py --restore   # gỡ mod, trả về bản gốc
```

- Sau khi cài, vào game bật tính năng bằng menu "Mod HVNJ" (xem mục ngay đầu tài liệu).
- Các lệnh của bản trước (`--mob`, `--party`, `--stone-levels`, `--remove`…) vẫn chạy được nhưng chỉ còn nghĩa là cài mod; script in lời nhắc dùng menu trong game.
- Mỗi lần chạy, script **dựng lại DLL từ bản gốc** (đã kiểm tra SHA-256), nên chạy bao nhiêu lần cũng cho cùng kết quả.
- Bản gốc được giữ ở `GameAssembly.dll.bak`. Nếu file này mất hoặc không phải bản gốc, script tự khôi phục bản gốc từ DLL đã mod (kể cả bản v1 / v2).
- Nếu game cập nhật lên phiên bản khác (SHA-256 không khớp), script từ chối patch để tránh làm hỏng DLL.
- DLL cũ còn patch "0.3s" sẽ được gỡ patch đó khi chạy `--install` (`--status` có cảnh báo).

Cách nhanh: chép `GameAssembly.dll` trong repo (đã cài mod) vào thư mục game, rồi bật tính năng trong menu Mod.

---

## 🔧 Kỹ thuật

- Code cave nằm trong 3 section mới ở cuối DLL:
  - `.hvnj` (RX): code;
  - `.hvnjd` (RW): cấu hình + trạng thái;
  - `.hvnjp` (R): bảng `.pdata` (exception directory) của game + entry của mod. Bảng gốc chỉ còn chỗ cho 32 entry nên mod chuyển cả bảng sang section mới. Script dựng section này từ DLL gốc lúc cài, `.pdata` gốc giữ nguyên.
- Không ghi vào code của game và chỉ dùng địa chỉ RIP-relative, nên an toàn với ASLR.
- Mỗi cave đều có unwind info đăng ký trong `.pdata`. Cave chạy bên trong frame của hàm game dùng unwind dạng *chained* tới hàm đó. Nhờ vậy exception của game đi qua cave vẫn được xử lý bình thường thay vì làm game thoát.
- **Mọi hook đều được cài, nhưng hành vi do cờ `cfg_*` trong `.hvnjd` quyết định lúc chạy.** Ngoại lệ duy nhất là nút Shop (`mo.dhn`), được sửa cố định theo yêu cầu. Các chỗ bản v2 sửa thẳng byte (đếm ngược khi chết, Thí Luyện, phần lõi chọn quái) nay là cave kiểm tra cờ: cờ tắt thì chạy đúng lệnh gốc của game.
- Mã nguồn:
  - `mod_src/hvnj_caves.asm`: các cave, assemble bằng `ml64`;
  - `mod_src/hvnj_menu.c`: menu Mod và lưu / đọc lựa chọn, biên dịch bằng `cl` (không CRT, không bảng con trỏ tuyệt đối);
  - `mod_src/hvnj_bag.c`: phiên dọn hành trang (bán trang bị thiếu dòng → luyện đá → cất rương), cùng quy ước;
  - `build_payload.py` ghép các file `.obj` thành payload (cần Visual Studio có MSVC).
- Menu dùng chính menu popup của game: tạo `List<iw>` + `iw(chữ, mã lệnh)`, hiện bằng `ms.dla`. Lệnh menu không có đối tượng xử lý riêng nên game gọi `mo.djh`; hook ở `iw.cgd` chuyển các mã `0x48560000+` cho mod, mã khác chuyển nguyên cho game.

```bash
python mod_src/build_payload.py   # assemble + biên dịch + sinh bảng patch vào patch_skill_delay.py
python mod_src/verify_mod.py      # kiểm thử toàn bộ, không cần mở game
```

`verify_mod.py` kiểm tra các mục sau:
- cài mod: nhận ra bản v3, **mọi cờ mặc định tắt**, khôi phục được bản gốc;
- **chạy thật từng cave chặn theo cờ** (31 tình huống, qua trampoline): cờ tắt thì nhảy đúng đích của lệnh gốc và giữ giá trị gốc, cờ bật thì ra hành vi của mod;
- **chạy thật menu Mod** (hàm C): menu nhân vật có thêm dòng "Mod HVNJ"; "Mở rương đồ" / "Mở nâng cấp trang bị" gọi `mo.djd(4)` / `mo.djd(10)` ở map ngoài làng; menu hiện đúng chữ và `[x]`; tick / bỏ tick đổi đúng cờ và xoá trạng thái dở dang; lưu / đọc `PlayerPrefs`, bỏ qua chuỗi lưu sai; lệnh của game vẫn tới `mo.djh` nguyên tham số;
- **chạy thật mã máy luyện đá** (`stone_tick`) trong DLL đã nạp:
  - các hàm game được thay bằng callback Python;
  - nhân vật, hành trang và bảng điểm đá là dữ liệu giả;
  - kiểm tra packet gửi ra ở 24 tình huống, gồm cả chưa tick thì không luyện: chọn đá, chờ/gửi lại/nghỉ, đủ hay thiếu yên (có xu cũng không luyện), chỉ gửi cmd 20, leo cấp tới cấp đích rồi cất rương, rương chưa nạp/đầy/bị từ chối, gộp nhiều cấp, giới hạn 24 viên;
- **chạy thật phiên dọn hành trang** (`bag_tick`) với shop và server giả, ở 17 tình huống: tải danh sách shop (nam / nữ, trang sức, vũ khí), xem chi tiết, bán đúng món thiếu dòng và giữ mọi món khác, cất đồ đủ dòng vào rương tới khi đầy, thôi cất khi server không cho, nhớ số dòng vào `PlayerPrefs`, chờ / thử lại / nghỉ khi server không trả lời, không chạy khi chưa tick / tắt Auto / chưa đầy / đang chết, bán xong mới luyện đá, auto nhiệm vụ tạm dừng trong lúc dọn, menu Xem trước không bán gì;
- **chạy thật mã máy auto nhiệm vụ** (`quest_tick`) với NPC, map và nhiệm vụ giả, ở 10 tình huống: chưa tick thì không làm gì, thứ tự nhận (ngày → tà thú), menu nhận tà thú, ưu tiên nhiệm vụ ngày, chờ tà thú xuất hiện, tắt Auto thì dừng;
- gỡ được patch "0.3s" khỏi DLL cũ;
- nâng cấp các DLL v2 cũ hoặc bản v3 dựng trước đó (`--old-v2`, nhiều file) lên bản menu hiện tại;
- nâng cấp được từ v1;
- cấu trúc PE;
- disassemble mọi lệnh nhảy/gọi của cave asm và hàm C; không lệnh nào của game nhảy vào giữa vùng đã thay;
- nút Shop: `mo.dhn` luôn trả về "có", và cả DLL chỉ có 2 chỗ gọi `mo.dhn`, đều là phần nút Shop của thanh Top;
- nút "Rương" / "Nâng cấp": chạy thật hook `mo.dhe` (id của mod mở đúng bảng, id khác về lại `mo.dhe`) và việc tạo nút (con của nút Shop, đúng ảnh / chữ, không tạo trùng, tạo lại khi nút Shop mới), vị trí nối tiếp cuối hàng 2 khi hàng 2 trống / có nút / bớt nút;
- nạp DLL thật bằng `LoadLibraryEx` để kiểm tra quyền trang nhớ và `RtlLookupFunctionEntry`;
- `RtlVirtualUnwind` từ trong cave cho kết quả giống hệt khi unwind tại vị trí hook gốc;
- chạy thử CLI.

| Hook (RVA) | Hàm game | Mục đích |
|---|---|---|
| `0x1B9DB1`, `0x1B9E4B` | `mo.dgj` | bỏ ràng buộc quái theo nhiệm vụ chính (khi bật Né Boss hoặc Tự qua ải) |
| `0x1B9DFC` | `mo.dgj` | trả về quái gần nhất thay vì `null` |
| `0x1B9F11` | `mo.dgj` | lọc Tinh Anh/Thủ Lĩnh/Boss, cho phép đánh tất cả trong Thí Luyện |
| `0x1BA48E` | `mo.dgl` | lọc quái của auto nhiệm vụ (trừ con tà thú của nhiệm vụ tà thú) |
| `0x24B5AC` | `lm.clo` | chọn mục tiêu: theo trưởng nhóm, tự qua ải Thí Luyện |
| `0x19495E` | `mo.ctq` | mỗi frame (sau `mo.dgd`): chết - quay về, dọn hành trang (bán → luyện đá → cất rương), đánh theo nhóm, nhiệm vụ |
| `0x1927E2`, `0x192912`, `0x3612E0`, `0x360946` | `mo.ctq`, `hw.cdy`, `hw.cdq` | bỏ đếm ngược khi chết (khi bật Chết - về làng) |
| `0x19C061`, `0x477CBF` | `mo.dek`, `eq.bld` | Auto và tìm đường trong map 161 (khi bật Giữ Auto trong Thí Luyện) |
| `0x4E6027` | `iw.cgd` | lệnh của menu Mod (`0x48560000+`) -> `mod_action`, còn lại -> `mo.djh` |
| `0x1EA0BA` | `mo.doMenuChar` | thêm dòng "Mod HVNJ" vào menu nhân vật |
| `0x1CC170` | `mo.dhn` | `mov al, 1 ; ret`: nút Shop trên thanh Top hiện ở mọi map (sửa cố định) |
| `0x1C7870` | `mo.dhe` | bấm nút thanh Top: id nút của mod -> mở rương / nâng cấp, id khác chạy nguyên hàm game |

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
