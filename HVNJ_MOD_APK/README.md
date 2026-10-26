# HVNJ Android ARM64 — bản thử mod

APK để thử: **`output/HVNJ_185_mod_arm64.apk`**. Đây là bản Android1.8.5 (package `com.g4m.hocvienninja`, versionCode128), chỉ ARM64. APK gốc `HVNJ_185.apk` được giữ nguyên.

Đã build thư viện native, ghép bootstrap DEX, ký khóa mod riêng; kiểm tra chữ ký v2/v3, ZIP alignment16KB và674 entry gốc giữ nguyên nội dung. Báo cáo: `output/apk-build-report.json` và `build/android/native-build-report.json`. Chưa chạy trên thiết bị Android: chưa xác nhận khởi động, đăng nhập SDK, hiển thị/cảm ứng menu hoặc phản hồi giao dịch từ server.

## Menu và chức năng

Trong màn hình map, có các nút **Mod HVNJ**, **Rương**, **Nâng cấp**. Menu nhân vật cũng có dòng Mod HVNJ. Chín tùy chọn ban đầu đều tắt; lựa chọn được lưu bằng PlayerPrefs của game.

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

Rương/Nâng cấp gửi đúng chuỗi NPC5/6: `openMenu` → phản hồi40 → `menu(npc,0,0)` → phản hồi30 mở panel4/10. Có chặn yêu cầu chồng nhau và timeout; không tự mở panel giả. Việc dùng dịch vụ ngoài map còn phụ thuộc server, chưa xác nhận thành công. Shop giữ luồng có sẵn của APK; chưa sửa dịch vụ shop từ xa. Tính năng tốc độ skill0,3giây đã bỏ ở PC không được thêm lại.

## Cách thử

### Bản có log (185-arm64-log-v1)

Cài lại APK mới trong `output/HVNJ_185_mod_arm64.apk` (cùng khóa mod với bản thử trước). Bản này tự ghi `hvnj-mod.log` trong thư mục persistentDataPath của ứng dụng, thông thường `/sdcard/Android/data/com.g4m.hocvienninja/files/`. Mỗi file tối đa1MiB, giữ thêm một file `.previous`, flush sau mỗi dòng và lưu lại tối đa64 dòng khởi tạo trước khi mở file.

Để thu cả lỗi khởi động/crash và đọc file dễ dàng:

1. Bật **Tùy chọn nhà phát triển → Gỡ lỗi USB** trên điện thoại, kết nối USB với máy tính và chấp nhận **Cho phép gỡ lỗi USB**. Mở khóa màn hình điện thoại.
2. Chạy **`Thu_log_APK.cmd`** trong thư mục này. Khi thấy `CAPTURING`, mở APK và thao tác gây lỗi. Nên thử menu mod, Rương, Nâng cấp trước, ghi nhớ đang ở map nào.
3. Quay lại cửa sổ thu log, nhấn Enter. File lưu ở **`HVNJ_MOD_APK/logs/<ngày-giờ>/`**; báo đã thu log để mình đọc ngay từ workspace. Script không cài/gỡ ứng dụng, không tắt game và không tự gửi file đi đâu.

Có thể thu sau khi đã thao tác bằng `Thu_log_APK.cmd -Snapshot`; logcat có thể đã mất đoạn cũ nên thu trực tiếp trước khi mở game vẫn tốt hơn. Android mới thường chặn trình quản lý file truy cập Android/data, nên dùng công cụ USB đi kèm. Nếu chỉ chạy trên điện thoại chưa kết nối USB, file vẫn được ghi nhưng mình không tự đọc được từ xa.

Log mod gồm build/hook, lỗi gọi API, menu/cấu hình, map/popup, NPC và giao dịch bán/cất/lấy đồ/nâng cấp/mua/luyện đá. Sau giao dịch chỉ ghi mã và độ dài của tối đa64 phản hồi trong10giây; không ghi payload, mật khẩu, token hay nội dung chat. Logcat bổ sung lỗi Unity/AndroidRuntime để chẩn đoán crash trước khi file mở được. Việc ghi log trên điện thoại vẫn cần lần chạy thử đầu tiên để xác nhận.

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

APK, khóa ký, công cụ và log chạy được giữ cục bộ, loại khỏi Git. Chưa có kiểm chứng in-game nên bản này là bản thử, chưa phải bản xác nhận đủ9 tính năng chạy ổn trên Android/server thật.
