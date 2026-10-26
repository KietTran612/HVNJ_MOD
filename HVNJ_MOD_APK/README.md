# HVNJ Android ARM64 — bản thử mod

APK để thử: **`output/HVNJ_185_mod_arm64.apk`**. Đây là bản Android1.8.5 (package `com.g4m.hocvienninja`, versionCode128), chỉ ARM64. APK gốc `HVNJ_185.apk` được giữ nguyên.

Đã build thư viện native, ghép bootstrap DEX, ký khóa mod riêng; kiểm tra chữ ký v2/v3, ZIP alignment16KB và674 entry gốc giữ nguyên nội dung. Báo cáo: `output/apk-build-report.json` và `build/android/native-build-report.json`. Đã cài qua ADB Wi-Fi trên ASUS Android14 ARM64, vào map160 và xác nhận ghi log file/logcat. Chín tính năng và giao dịch server vẫn đang kiểm thử; chưa xác nhận chạy ổn toàn bộ.

## Bàn giao tiến độ — 26/10/2026

### Đã làm

- Phân tích APK185 Unity6/ARM64, port9 engine/menu, build thư viện riêng, ghép loader DEX và ký khóa mod; đối chiếu chữ kýv2/v3, alignment16KB,674 entry gốc và hash APK gốc.
- Cài cập nhật qua ADB Wi-Fi trên ASUS Android14, vào Học viện kuraisono/map160. Thu logcat và kéo được file `hvnj-mod.log` từ ứng dụng.
- Kiểm chứng menu Mod trên thiết bị:15 dòng mở khoảng10–15ms; Né Boss đổi flags001 rồi000; vuốt tới các mục sau và mở preview. Tất cả cờ được đưa về tắt sau thử.
- Đổi mã hai nút dịch vụ sang menu NPC5/6 để người dùng tự chọn option, bỏ tự gửi hàng0/option0. Thêm giữ/trả ngữ cảnh, timeout, drain phản hồi muộn và đặt menu từ xa giữa màn hình; bản mới đã build/ký/cài, cần xác minh kết quả hiển thị.
- Test logic đã chạy:12 Python unittest và các bộ C++ menu/protocol/startup/field ABI/features/bag/logfile. Test protocol chứng minh không nuốt phản hồi40 và không tự chuyển sang gửi option. Review đã phát hiện và xử lý hai lỗi vòng đời ngữ cảnh NPC.

### Đang làm và chưa kiểm chứng

1. Kiểm thử bản log-v5 mới nhất: bấm Rương/Nâng cấp phải hiện menu gốc, chọn option để mở đúng panel; chưa xác nhận cả hai luồng hoàn chỉnh. Không coi phản hồi40 là bằng chứng dịch vụ đã dùng được.
2. Sau đó đối chiếu ở map khác; chưa thực hiện giao dịch cất đồ/nâng cấp bằng công cụ. Server có thể kiểm tra điều kiện riêng khi chọn option hoặc giao dịch.
3. Chín engine còn thiếu thử từng tình huống thực tế: chết/quay lại, Thí Luyện, nhiệm vụ ngày/tà thú, theo nhóm, túi đầy và luyện đá. Logic host thành công chưa chứng minh hoạt động server.
4. Shop chưa sửa; ARM32 chưa triển khai. Lỗi mất kết nối đăng nhập chưa có nguyên nhân kết luận; không đổi logic xác thực.

### Vấn đề đã gặp

| Vấn đề | Nguyên nhân/bằng chứng và xử lý | Kiểm chứng |
|---|---|---|
| USB mất liên tục | Windows lỗi descriptor, ADB read failed; chuyển Wi-Fi cùng mạng | Đã cài/test qua Wi-Fi |
| Crash khởi động log-v1 | Worker gọi domain_get trước khi VM sẵn sàng; chuyển resolve API vào managed Main.OnGUI | Đã vào map |
| Nút Mod khó thấy/MENU chính thiếu mục Mod | Tăng chữ nút, bổ sung command cùng bảng icon/tên của MenuLeft | Đã nhìn thấy/bấm được |
| Mở Mod lần đầu lỗi doMenuChar | Tạo danh sách phụ thuộc charFocus; đổi sang factory từ kiểu field | Menu15 dòng đã mở |
| Treo/crash dựng chữ | Reference setter lưu địa chỉ stack; sửa ABI theo ELF | Menu/toggle/preview đã thử |
| Hai nút NPC timeout | Nuốt40 rồi tự chọn0; đổi sang giữ menu gốc cho người dùng chọn | Đang thử luồng mới |
| Crash GC handle ở log-v5 | Unity6 dùng handle dạng địa chỉ64bit; đổi new/get/free và storage sang uintptr_t | Lần thử sau qua GC lookup |
| Menu NPC trống dù có40 | initUI(true) neo theo X/Y/H của NPC; ngữ cảnh ngoài map có tọa độ mặc định | Đã build/cài hook centered, chờ thử |
| Ngoại lệ Facebook SDK | Class Java thiếu ở cả APK gốc và APK mod; game vẫn từng vào map | Chưa chứng minh gây mất kết nối |

### Tiếp tục từ đâu

- APK: `output/HVNJ_185_mod_arm64.apk`; hash/chữ ký trong `output/apk-build-report.json`, native trong `build/android/native-build-report.json`. Marker log-v5 có nhiều bản thử, cần đối chiếu hash để nhận đúng bản cài.
- Log/screenshot cục bộ: `logs/device-20261026-154932/`. Menu Mod: `final-mod.png`, `main-menu-fixed.png`, `mod-preview.png`; lỗi NPC: `v5-crash.txt`, `v5b-full.txt`. APK/keys/tools/logs không đưa vào Git.
- Mã cần xem: `src/hv_hooks.cpp` (ngữ cảnh/receive/initUI), `src/hv_protocol.h` (ACK/timeout/drain), `src/hv_runtime.cpp` (IL2CPP ABI), `src/hv_menu.cpp` (nút/menu).
- Cần chứng minh tiếp: NPC5 hiện4 nhóm menu, NPC6 hiện7 nhóm; lựa chọn gửi `TX menu ... internal=0` đúng option, mở panel đúng và không đơ. Chỉ mở panel, không tự giao dịch.
- Các bài học ABI ở cuối README áp dụng cho lần port sau: không dùng domain_get làm readiness; phân biệt primitive/reference; kiểm tra độ rộng GC handle; menu NPC từ xa phải tránh neo vào tọa độ không tồn tại.

## Menu và chức năng

Trong màn hình map, có các nút **Mod HVNJ**, **Rương**, **Nâng cấp** phía trên bên trái, cạnh thanh nhân vật. MENU chính có thêm dòng Mod HVNJ; menu nhân vật cũng có dòng này. Chín tùy chọn ban đầu đều tắt; lựa chọn được lưu bằng PlayerPrefs của game.

Kiểm thử thiết bị ngày26/10: nút nổi và mục **MENU → Mod HVNJ** đều mở danh sách15 dòng trong khoảng10ms; bấm Né Boss đổi dấu `[ ]` thành `[x]`, log flags001, bấm lần nữa về flags000. Danh sách nằm ngang: vuốt sang trái để xem các mục còn lại. Đây là kiểm chứng menu/cấu hình, chưa phải kiểm chứng hành vi chiến đấu của cả9 mod.

| Tùy chọn | Hành vi đã viết và kiểm tra logic trên máy build |
|---|---|
| Né Boss/Tinh Anh/Thủ Lĩnh | Lọc mục tiêu Auto, giữ ngoại lệ quái tà thú đang làm nhiệm vụ |
| Chết khi Auto | Yêu cầu về làng khi cài đặt game cho phép, tìm đường về map cũ, bật Auto; có giới hạn thử và timeout |
| Giữ Auto Thí Luyện | Giữ trạng thái Auto khi vào thử thách161; không ép bật lại khi người chơi tự tắt trong map |
| Qua ải Thí Luyện | Chờ hết quái2,5giây, tìm cổng thực tế tới map tiếp theo trong nhóm161–167 |
| Nhiệm vụ ngày | Dùng pipeline nhiệm vụ của game, NPC25 và trường phái/map lấy từ APK |
| Nhiệm vụ tà thú | Nhận/chạy/trả theo dữ liệu nhiệm vụ; có giới hạn thử và option nhận cấu hình được |
| Theo trưởng nhóm | Đi theo và cùng mục tiêu khi trưởng nhóm có mặt trong dữ liệu map hiện tại |
| Bán/cất trang bị | Khi túi gần đầy: so số dòng với mẫu shop, giữ đồ chưa biết mẫu, tránh đồ khóa/nâng cấp/gắn ngọc; có xem trước |
| Luyện đá | Khi túi gần đầy: chọn tổ hợp điểm chính xác, cấp đá cấu hình được; yêu cầu đủ yên trước khi gọi cmd20, không chọn nhánh dùng xu |

Các giao dịch hành trang được tuần tự hóa, theo dõi thay đổi ô đồ và có timeout. Dữ liệu mẫu shop hiện dùng cache của client trong phiên; chưa có cache riêng bền vững như PC. Theo nhóm chưa điều hướng sang map khác khi client không còn thấy trưởng nhóm.

Theo yêu cầu26/10, Rương/Nâng cấp mở **menu NPC5/6 để người dùng tự chọn option**. Không tự gửi `menu(npc,0,0)` và không nuốt phản hồi40: game gốc dựng menu từ template đã tải. Nếu NPC không có trong map, đối tượng ngữ cảnh chỉ phục vụ menu, không thêm vào map; lựa chọn vẫn đi qua GameCanvas/Service gốc. Ngữ cảnh được giữ bằng GC handle trong lúc chờ/menu mở và trả lại khi đóng/đổi map; có timeout và chặn phản hồi muộn. Menu hiển thị không đồng nghĩa server cho phép giao dịch ở mọi map; phần đó phải kiểm thử riêng. Shop giữ luồng có sẵn của APK; chưa sửa dịch vụ shop từ xa. Tính năng tốc độ skill0,3giây đã bỏ ở PC không được thêm lại.

## Cách thử

### Bản có log (185-arm64-log-v5)

Cài lại APK mới trong `output/HVNJ_185_mod_arm64.apk` (cùng khóa mod với bản thử trước). Bản này tự ghi `hvnj-mod.log` trong thư mục persistentDataPath của ứng dụng, thông thường `/sdcard/Android/data/com.g4m.hocvienninja/files/`. Mỗi file tối đa1MiB, giữ thêm một file `.previous`, flush sau mỗi dòng và lưu lại tối đa64 dòng khởi tạo trước khi mở file.

Để thu cả lỗi khởi động/crash và đọc file dễ dàng:

1. Bật **Tùy chọn nhà phát triển → Gỡ lỗi USB** trên điện thoại, kết nối USB với máy tính và chấp nhận **Cho phép gỡ lỗi USB**. Mở khóa màn hình điện thoại.
2. Chạy **`Thu_log_APK.cmd`** trong thư mục này. Khi thấy `CAPTURING`, mở APK và thao tác gây lỗi. Nên thử menu mod, Rương, Nâng cấp trước, ghi nhớ đang ở map nào.
3. Quay lại cửa sổ thu log, nhấn Enter. File lưu ở **`HVNJ_MOD_APK/logs/<ngày-giờ>/`**; báo đã thu log để mình đọc ngay từ workspace. Script không cài/gỡ ứng dụng, không tắt game và không tự gửi file đi đâu.

Có thể thu sau khi đã thao tác bằng `Thu_log_APK.cmd -Snapshot`; logcat có thể đã mất đoạn cũ nên thu trực tiếp trước khi mở game vẫn tốt hơn. Android mới thường chặn trình quản lý file truy cập Android/data, nên dùng công cụ USB đi kèm. Nếu chỉ chạy trên điện thoại chưa kết nối USB, file vẫn được ghi nhưng mình không tự đọc được từ xa.

Log mod gồm build/hook, lỗi gọi API, menu/cấu hình, map/popup, NPC và giao dịch bán/cất/lấy đồ/nâng cấp/mua/luyện đá. Sau giao dịch chỉ ghi mã và độ dài của tối đa64 phản hồi trong10giây; không ghi payload, mật khẩu, token hay nội dung chat. Logcat bổ sung lỗi Unity/AndroidRuntime để chẩn đoán crash trước khi file mở được. Đã kéo được file hvnj-mod.log từ điện thoại và thu logcat trực tiếp qua Wi-Fi.

1. Dùng thiết bị/giả lập Android ARM64 và chép APK trong `output/` vào đó. Bản ký mod không cài cập nhật đè lên bản chính thức có chữ ký khác; nên thử ở môi trường riêng. Không có bước tự gỡ ứng dụng hoặc xóa dữ liệu.
2. Mở game và đăng nhập; thử di chuyển/đánh thông thường khi tất cả tùy chọn tắt.
3. Mở Mod HVNJ, bật từng tùy chọn để kiểm tra. Với bán/cất, xem trước trước khi bật tự động.
4. Thử Rương/Nâng cấp cạnh đúng NPC trước, rồi ngoài map. Ghi lại map và hành động cụ thể nếu có lỗi.
5. Có ADB trên máy tính thì thu log bằng `adb logcat -v time HVNJ-MOD:I Unity:E AndroidRuntime:E '*:S'`. Không cần cung cấp mật khẩu/tài khoản cho công cụ build.

## Mã nguồn và build

`src/` chứa adapter IL2CPP, menu, hook, engine chiến đấu/nhiệm vụ và hành trang. `scripts/` chứa tạo profile, build native, đóng gói. `tests/` chứa kiểm tra logic và archive. Xem `BUILD.md` để build lại; toolchain, phân tích dịch ngược, APK/khóa ký và sản phẩm build được loại khỏi Git.

Cpp2IL xuất khai báo C# và ánh xạ method; thân hàm stub không phải source game đầy đủ. Với APK này, số `Address.RVA/Offset` mà Cpp2IL xuất là **file offset**: phải chuyển qua ELF PT_LOAD để có địa chỉ runtime. `scripts/generate_profile.py` làm phép đổi này và lưu byte guard; không dùng các offset class Unity2020 của PC cho Unity6.

Khi chọn điểm nhận tin, phải kiểm tra nhánh xử lý packet thực tế, không chọn theo tên lớp hoặc chữ ký đơn thuần: APK có `ControllerTestGame` cho giả lập, còn `GlobalMessage.onMessage` mới xử lý cmd30 mở panel server. Profile dùng `GlobalMessage`; nhánh cmd30 tại VA0x17036dc đọc byte UI và gọi `MapScr.openPopup`, nhánh cmd40 tại VA0x1709708. Bài học này áp dụng khi port phiên bản APK khác.

Nguồn Dobby ghim commit31e4ab0cfc2bfa4512b4ea520786ea2403f97dfc từ kho chính thức, license giữ trong thư mục giải nén; archive SHA2564522472367e783a51579fbb45f42bb8c674043964a2183e56807a7a55e00b525. Không dùng snapshot mới đang có lỗi build Android trong lần thử này.

APK, khóa ký, công cụ và log chạy được giữ cục bộ, loại khỏi Git. Đã kiểm chứng menu/cấu hình trên thiết bị; bản này vẫn là bản thử, chưa xác nhận đủ9 tính năng chạy ổn trên Android/server thật.

## Bài học kiểm thử khởi động trên thiết bị

Lần chạy ASUS Android14 đầu tiên của log-v1 crash trước khi vào game: worker gọi il2cpp_domain_get khi Unity6 chưa khởi tạo các lớp mặc định. Backtrace: libhvnjmod hv_runtime_init → domain_get → null Class tại0x135. Hàm này có khởi tạo AppDomain lười nên không dùng làm tín hiệu readiness.

Log-v2 chỉ tìm ELF/so byte trên worker và đặt bootstrap Main.OnGUI; resolve API, đọc domain/class và cài các hook còn lại từ callback managed gốc trên Unity main thread. Khi port game/Unity khác cũng phải phân biệt thư viện đã map với VM đã sẵn sàng; không chữa bằng một khoảng sleep cố định.

## Bài học ABI setter reference trên APK185

Crash log-v4 khi mở menu đi qua `UnityEngine.TextGenerator.Populate_Internal` và `UnityEngine.UI.Text.OnPopulateMesh`. Phân tích ELF xác nhận `il2cpp_field_set_value` VA0x155f0fc gọi Field::SetValueRaw với cờ dereference bằng0; nhánh STRING/CLASS/ARRAY/OBJECT/SZARRAY tại VA0x15b3ec8 chuyển thẳng reference cho đoạn `str x1,[x0]; ret` ở VA0x155a5ec. `il2cpp_field_static_set_value` cũng dùng cờ0. Vì vậy cả setter instance/static nhận managed reference trực tiếp (`v`), còn primitive nhận địa chỉ vùng chứa giá trị (`&v`). Không áp dụng quy ước primitive cho reference: truyền `&v` sẽ lưu địa chỉ stack native vào field managed, làm hỏng caption/list và có thể crash muộn khi render.

`src/hv_field_write.h` tách hai quy ước này trong adapter thật. `tests/test_field_write.cpp` mô phỏng đúng biên setter đã chứng minh từ ELF, kiểm tra caption/object identity, null, static reference và primitive. Test đã thất bại với cách truyền reference cũ trước khi đổi sang reference trực tiếp. Khi port Unity/APK khác, kiểm chứng ABI bằng export/thân hàm thực tế hoặc test runtime; không suy từ tên API hay ví dụ phiên bản khác.

Unity6 của APK185 còn dùng GC handle có độ rộng con trỏ (`uintptr_t`), không phải chỉ số32bit như một số bản Unity cũ. `il2cpp_gchandle_get_target` → VA0x1559644 dùng toàn bộ x0 làm địa chỉ, mask0xffffffffffffe000 rồi đọc bảng ở+0x20. Khai báo32bit gây crash tại0x155965c vì cắt phần cao địa chỉ. Mọi chữ ký new/get/free và nơi lưu handle phải cùng độ rộng; test_field_write có static_assert để giữ ràng buộc này. Khi thêm API native, phải kiểm tra cả kiểu trả về/tham số theo binary hiện tại trước khi coi chữ ký cũ là tương thích.
