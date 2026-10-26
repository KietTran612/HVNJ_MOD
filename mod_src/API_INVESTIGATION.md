# Điều tra Shop / Rương / Cường hóa ngoài map — 2026-10-26

Phạm vi: đọc chữ ký C# và disassemble GameAssembly.dll.bak. Chưa có packet capture hoặc mã server, chưa sửa payload/DLL.

## Gói thao tác đã xác nhận từ mã máy

| API | RVA | Command | Payload nghiệp vụ |
|---|---|---|---|
| lj.itemBagToBox(indexUI) | 0x243350 | 17 | byte ô hành trang |
| lj.itemBoxToBag(indexUI) | 0x2434B0 | 16 | byte ô rương |
| lj.coi(indexUI, quantity) | 0x23A0F0 | 14 | byte ô, int32 số lượng |
| lj.coj(typeUI, indexUI, quantity) | 0x23A220 | xem disassembly | loại cửa hàng, ô hàng, số lượng |
| lj.cpd(item, items, isGold) | 0x23B660 | 21 | bool loại tiền, byte ô trang bị, các byte ô nguyên liệu (null -> -1) |
| lj.cox(typeUI) | 0x23B110 | -30, sub -103 | byte typeUI |
| lj.cor(npcId) | 0x23AA80 | 40 | int16 NPC ID |
| lj.menu(npcId, menuId, optionId) | 0x2436E0 | 29 | byte NPC ID, byte menu ID, byte option ID |

Các hàm thao tác trên không thêm map ID/NPC ID ngầm trước khi gửi. Writer bat = byte, baz = int16, bbb = int32 đã kiểm tra mã máy.

## Khác biệt luồng gốc và mod

- Mod gọi mo.djd(4/10) trực tiếp trong mod_top_click và mod_action. Đây là mở bảng client.
- mo.djd(4) dùng danh sách rương đã cache nếu có; nếu chưa có mới gọi lj.cox(4). Vì vậy bảng hiện không chứng minh server cho truy cập rương.
- mo.djd(10) khởi tạo popup gw. Thao tác cường hóa đi qua gw.btt -> lj.cpd.
- Luồng tương tác NPC gốc mo.dgg kiểm tra khoảng cách tới NPC, lấy NPC template ID từ nhân vật đang chọn NPC, rồi gọi lj.cor.
- Chọn menu NPC qua fc.bma lấy NPC đang chọn và gọi lj.menu. UI tương ứng cũng được mở từ trình xử lý gói server li.caj (các call tới mo.djd tại 0x208C5E và 0x211FC4).
- Patch Shop hiện tại chỉ đổi mo.dhn để nút hiện ngoài map thông thường, không thay điều kiện server.

## Kết luận và giới hạn

Không có tham số map/NPC bị bỏ quên trong các API cất/rút/bán/cường hóa đã kiểm tra. Có bước tương tác NPC riêng mà lối tắt mở bảng bỏ qua. Chưa thể phân biệt chỉ từ client: server yêu cầu phiên tương tác NPC trước đó hay kiểm tra map/NPC/khoảng cách mỗi lần thao tác. Không được kết luận rằng chỉ gửi cor/menu là sẽ dùng được ngoài map.

Cần đối chiếu một lần thao tác thành công tại NPC với lần thất bại ngoài map: xem có gửi cmd 14/16/17/21 không, phản hồi server, và thử sau khi đã tương tác đúng NPC rồi đổi map. Nếu gói đã gửi và server kiểm tra map hiện tại thì phải đưa nhân vật về đúng map/NPC; thêm ID vào payload gói hiện hành không thay đổi map do server quản lý.

Tệp hỗ trợ: `inspect_service_api.py` (chạy bằng Python có capstone để xem mã máy hoặc các callsite; các bản dump tạm không đưa vào Git).

## Điều tra tiếp: hai giao thức menu NPC

- `lj.cpv(npcTemplateId, menuId, optionId)` tại RVA `0x23C940` gửi **cmd 47**: byte NPC template ID, byte menu ID; chỉ ghi byte option khi option >= 0. `optionId = -1` nghĩa là không có byte option, không phải byte 255.
- Callsite gốc: `cp.bel` tại `0x580AFF`, `cp.bbp` tại `0x58050D`. `cp.bel` lấy NPC template từ `cp.gfp -> kk.lth -> kl.ltx`, và dùng chỉ số dòng menu đang chọn. Không có map ID.
- Luồng `fc.bma` gọi `lj.menu` (cmd 29) tại `0x6186E2`: NPC lấy từ `lm.cua().mjp.lth.ltx`, menu = chỉ số chọn, option = 0. Các menu nhiệm vụ dùng option khác. Không được áp dụng option nhiệm vụ cho rương/cường hóa.
- Cmd 40 và cmd 29/47 là các bước khác nhau. Cmd 47 chưa phải bằng chứng có API truy cập dịch vụ ngoài map.
- Dữ liệu template có cấu trúc `mc.nds: kl[]`, `kl.ltx: id`, `kl.lty: tên`, `kl.ltz: string[][]`, `kl.lua: sbyte[][]`. Không có bằng chứng tĩnh xác định bộ tuple mở rương/cường hóa/shop cho server đang dùng. Không tự gán số NPC hoặc menu theo bản Ninja khác.
- Chỉnh lại ghi chú trình xử lý: call `0x208C5E` chuyển loại UI nhận được vào `mo.djd`; call `0x211FC4` mở riêng loại 37. Không coi call thứ hai là phản hồi rương/cường hóa.

### Triệu chứng người dùng cung cấp

Ngoài map, thao tác cất rương, mua hàng hoặc chọn nâng cấp bật popup Waiting rồi kẹt, không có thông báo. Đây là bằng chứng UI đã vào trạng thái chờ, chưa chứng minh gói đã ra mạng hay server đã nhận. Cần đo tại lớp gửi/nhận để phân biệt.

### Cách xác minh cụ thể trước khi chọn bản sửa

1. Tại đúng NPC: ghi `map thực, NPC template, cmd 40, cmd 29 hoặc 47, menu, option`, rồi ghi phản hồi mở UI. Làm riêng rương, shop, cường hóa.
2. Ngoài map: ghi một lần thao tác từ nút, so có cùng chuỗi yêu cầu mở dịch vụ không và có phản hồi không.
3. Nếu thiếu bước mở qua NPC: thử đúng chuỗi đã ghi; chờ phản hồi mở bảng từ server, không gọi mo.djd để giả lập thành công. Hết hạn thì kết thúc trạng thái chờ và báo không nhận phản hồi; không tự gửi lại mua/cường hóa.
4. Nếu server vẫn không phản hồi ngoài map: client không có tham số map trong các gói này. Không thêm byte tùy ý, không sửa biến map client để giả làm map server. Phương án tương thích là tự đi tới đúng map/NPC hoặc thay đổi server nếu có quyền và mã nguồn server.

Giới hạn tại thời điểm điều tra ban đầu: chưa có phiên tương tác thực tế và chưa sửa payload. **Cập nhật sau khi có log:** xem `LOG_ANALYSIS_20261026.md` cho mẫu lỗi map 68 và mẫu NPC đúng tại map 38; bản sửa `hvnj_service.c` đã được build/cài, đang chờ thử hai nút ngoài map. Không coi báo cáo ban đầu này là trạng thái cuối cùng của bản build.

Nguyên tắc dùng cho các tính năng khác: mở được UI và test server giả không xác nhận server thật cho phép thao tác; chỉ thêm trường vào packet khi đã kiểm tra serializer và đối chiếu giao thức thực tế.
