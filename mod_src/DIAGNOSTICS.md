# Ghi log Shop / Rương / Cường hóa

Logger quan sát hai hàng đợi gửi và đầu hàm xử lý gói nhận. Bản hiện tại đã sửa hai nút Rương/Nâng cấp để gửi chuỗi NPC5/6 và menu(0,0), chờ server cmd30 thay cho mở bảng trực tiếp. Khả năng sử dụng ngoài map vẫn cần kiểm chứng trên server thật; Shop để sau. Không tự gửi lại giao dịch.

## Chạy thử

1. Đóng game. Chạy `Chay_game_ghi_log.cmd` ở thư mục game. Giữ cửa sổ lệnh mở.
2. Đăng nhập, tắt Auto để log không lẫn các tác vụ dọn túi/nhiệm vụ.
3. Tại đúng NPC, lần lượt mở **qua NPC gốc** và thử: cất/rút một món đồ ở rương; mua một món rẻ ở shop; mở cường hóa và chọn trang bị. Không cần tiêu tiền cường hóa nếu chỉ muốn kiểm tra bước chọn đồ. Nhớ thứ tự và thao tác nào đã thành công.
4. Sang map ngoài làng, thử lần lượt các nút mod tương ứng. Khi hiện Waiting, chờ khoảng 15 giây. Nếu kẹt không thao tác tiếp được thì đóng game; làm dịch vụ tiếp theo trong lần chạy khác, không cần cố thử hết trong một lần.
5. Đóng game. Cửa sổ lệnh xuất đường dẫn `diagnostic-logs/<thời gian>.service.log`. Gửi các file `.service.log` và ghi ngắn thao tác đã thử theo thứ tự. Nếu cần đóng cưỡng bức, giữ cửa sổ lệnh chờ xuất log.

File `.full.log` là log Unity gốc, giữ tại máy; file `.service.log` chỉ lấy dòng `[HVNJ-DIAG]`. Mỗi phiên có tên khác nhau, không ghi đè lần thử trước.

## Nội dung và giới hạn

- `UI`: người dùng yêu cầu loại bảng 4 (rương) hoặc 10 (nâng cấp), chưa có nghĩa server đã mở bảng.
- `SERVICE`: mốc request-box/request-upgrade, NPC-ack, select-menu, server-approved-open hoặc timeout. Hai bước xác nhận NPC và mở bảng chờ tối đa 5 giây mỗi bước. Sau timeout, phản hồi muộn được bỏ trong 5 giây; bấm lại sau khoảng đó. Không mở bảng cục bộ để giả thành công.
- `TX`: gói đã tới hàng đợi gửi gốc, **chưa chứng minh socket/server đã nhận**. `map`, `cmd`, `len`, `data` giúp giải mã NPC/menu/option/ô đồ.
- `RX`: gói tới hàm xử lý client, chụp trước khi reader đọc dữ liệu. Chỉ ghi trong 15 giây sau một yêu cầu dịch vụ hoặc nút mod.
- Chỉ dump payload danh sách lệnh dịch vụ đã kiểm tra; các RX khác chỉ ghi mã/độ dài và `redacted`. Không ghi TX đăng nhập/chat. Chuỗi NPC/menu trong RX dịch vụ có thể xuất hiện dưới dạng hex.
- Tối đa 96 byte mỗi payload và 2.000 dòng mỗi phiên để tránh log quá lớn. Mở lại game để bắt đầu phiên mới.
- `ms` là thời gian Windows tính bằng mili giây từ năm 1601; dùng chênh lệch để đối chiếu Waiting. `seq` tăng theo mỗi dòng; đọc theo thời gian nếu cần đối chiếu nhiều luồng.

## Khôi phục

Bản DLL trước chẩn đoán được lưu trong `diagnostic-logs/GameAssembly.before-diagnostics.<thời gian>.dll.bak`. Đóng game rồi sao chép bản đó về `GameAssembly.dll` để tắt logger và trở về đúng bản mod trước. `GameAssembly.dll.bak` ở thư mục gốc vẫn là DLL game nguyên bản.

## Kiểm chứng cho nhà phát triển

Chạy `mod_src/test_service.py`, `mod_src/test_diag.py` và `mod_src/verify_mod.py`. Test service chạy state machine thật, NPC5/6, đúng thứ tự ack/menu, chống bấm chồng, timeout/đổi map, phản hồi muộn, chặn yêu cầu NPC khác trong lúc đang chờ và trả luồng NPC về game khi hết yêu cầu, cùng hook nhận thật khi Auto tắt. Test logger kiểm tra TX/RX, lọc dữ liệu, giới hạn, giữ nguyên message và chuyển tiếp tham số. Bộ verify kiểm tra các hook, PE/unwind, chức năng mod và cài/gỡ trên bản sao. Chưa thay thế kiểm thử với server thật.
