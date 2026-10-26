# Phân tích phiên log 20261026-102543

Nguồn: diagnostic-logs/20261026-102543.full.log. Chỉ quan sát, chưa sửa mã game trong lượt này.

## Mốc đã ghi nhận

- Dòng 178: `[HVNJ-DIAG] v=1 seq=1 ms=13437458754962 UI map=68 type=10`
- Dòng 653: `[HVNJ-DIAG] v=1 seq=71 ms=13437458756263 UI map=68 type=4`
- Dòng 678: `[HVNJ-DIAG] v=1 seq=72 ms=13437458756272 TX map=68 cmd=-30 len=2 data=99 04 `
- Dòng 1263: `[HVNJ-DIAG] v=1 seq=163 ms=13437458757531 TX map=68 cmd=17 len=1 data=00 `
- Dòng 1848: `[HVNJ-DIAG] v=1 seq=255 ms=13437458758800 TX map=68 cmd=17 len=1 data=04 `
- Dòng 2559: `[HVNJ-DIAG] v=1 seq=372 ms=13437458760367 UI map=68 type=10`
- Dòng 4797: `[HVNJ-DIAG] v=1 seq=727 ms=13437458766407 TX map=68 cmd=21 len=20 data=00 17 0C FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF `

## Kết quả
- Có 1527 dòng chẩn đoán; mọi mốc UI/TX trong phần quan sát đều ở map 68.
- Cmd -30, payload 99 04: xin dữ liệu rương.
- Cmd 17, payload 00 và 04: cất các ô hành trang 0 và 4.
- Cmd 21: loại tiền 00, ô trang bị 0x17 (23), ô nguyên liệu 0x0C (12), các ô còn lại FF.
- Không thấy RX cmd 17 hoặc cmd 21 trong cửa sổ ghi log. Các mã này đã đối chiếu với bảng dispatch li.caj tại RVA 0x219790: cmd17 -> 0x207B70 -> fp.itemBagToBox; cmd21 -> 0x20803A (xử lý kết quả nâng cấp).
- Trong lúc chờ vẫn có gói server; log sau cửa sổ vẫn có Main.FixedUpdate/pickItem và END_WAIT. Không có bằng chứng toàn bộ client crash hoặc mất kết nối hoàn toàn.
- Không thấy TX cmd40/29/47 trong toàn bộ các dòng chẩn đoán hiện có: chưa có chuỗi mở qua NPC thật trong mẫu này.
- TX chỉ chứng minh đã vào hàng đợi gửi, không chứng minh socket/server đã nhận.

## Điều chưa xác định
- Chưa phân biệt được server yêu cầu map/NPC thực tế hay chỉ thiếu bước mở dịch vụ qua NPC. Dữ liệu -30 không thuộc whitelist bị che nên không suy đoán nội dung các gói đó.
- Cần một mẫu thành công tại NPC gốc (qua menu NPC, không qua nút mod), tốt nhất rương trước, rồi thử lại ngoài map. Không tự sửa packet hoặc gán NPC ID theo phỏng đoán.

## Đối chiếu phiên đúng map: 20261026-103032

Nguồn: diagnostic-logs/20261026-103032.full.log; snapshot quan sát có 833 dòng diagnostic.

- Dòng 200: `[HVNJ-DIAG] v=1 seq=1 ms=13437459061900 TX map=38 cmd=40 len=2 data=00 05 `
- Dòng 210: `[HVNJ-DIAG] v=1 seq=2 ms=13437459061951 RX map=38 cmd=40 len=0 data=`
- Dòng 346: `[HVNJ-DIAG] v=1 seq=21 ms=13437459062918 TX map=38 cmd=29 len=3 data=05 00 00 `
- Dòng 361: `[HVNJ-DIAG] v=1 seq=23 ms=13437459062951 RX map=38 cmd=30 len=1 data=redacted`
- Dòng 375: `[HVNJ-DIAG] v=1 seq=24 ms=13437459062962 TX map=38 cmd=-30 len=2 data=99 04 `
- Dòng 613: `[HVNJ-DIAG] v=1 seq=54 ms=13437459065687 TX map=38 cmd=17 len=1 data=00 `
- Dòng 628: `[HVNJ-DIAG] v=1 seq=55 ms=13437459065721 RX map=38 cmd=17 len=2 data=00 08 `
- Dòng 766: `[HVNJ-DIAG] v=1 seq=74 ms=13437459067156 TX map=38 cmd=17 len=1 data=01 `
- Dòng 787: `[HVNJ-DIAG] v=1 seq=76 ms=13437459067206 RX map=38 cmd=17 len=2 data=01 0A `
- Dòng 1315: `[HVNJ-DIAG] v=1 seq=152 ms=13437459071326 TX map=38 cmd=17 len=1 data=0A `
- Dòng 1330: `[HVNJ-DIAG] v=1 seq=153 ms=13437459071360 RX map=38 cmd=17 len=2 data=0A 0F `
- Dòng 2878: `[HVNJ-DIAG] v=1 seq=402 ms=13437459090662 TX map=38 cmd=40 len=2 data=00 06 `
- Dòng 2888: `[HVNJ-DIAG] v=1 seq=403 ms=13437459090762 RX map=38 cmd=40 len=0 data=`
- Dòng 2976: `[HVNJ-DIAG] v=1 seq=414 ms=13437459091580 TX map=38 cmd=29 len=3 data=06 00 00 `
- Dòng 3015: `[HVNJ-DIAG] v=1 seq=420 ms=13437459091813 RX map=38 cmd=30 len=1 data=redacted`
- Dòng 3595: `[HVNJ-DIAG] v=1 seq=503 ms=13437459096035 TX map=38 cmd=21 len=20 data=00 17 1B FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF `
- Dòng 3610: `[HVNJ-DIAG] v=1 seq=504 ms=13437459096084 RX map=38 cmd=21 len=22 data=01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 B3 3A E7 01 `
- Dòng 3790: `[HVNJ-DIAG] v=1 seq=528 ms=13437459097319 TX map=38 cmd=21 len=20 data=00 17 1A FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF `
- Dòng 4001: `[HVNJ-DIAG] v=1 seq=558 ms=13437459098471 TX map=38 cmd=21 len=20 data=00 17 1A FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF FF `
- Dòng 4023: `[HVNJ-DIAG] v=1 seq=560 ms=13437459098503 RX map=38 cmd=21 len=22 data=01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 B3 35 6F 02 `

### Kết luận đối chiếu
- Rương: map38, cor(5) -> RX40 -> menu(5,0,0) -> RX30 -> mo.djd(4) -> cox(4). Sau đó TX17 được RX17 xác nhận 3 lần, độ trễ 34/50/34 ms.
- Nâng cấp: map38, cor(6) -> RX40 -> menu(6,0,0) -> RX30 -> mo.djd(10). Có 3 TX21 và 2 RX21 trong mẫu, không ghép 1:1 toàn bộ yêu cầu khi đang gửi lặp. RX21 có nghĩa có kết quả, không tự kết luận trang bị lên cấp thành công.
- Đã xác minh từ mã máy: cmd30 tại li.caj -> 0x208C10, đọc một byte và gọi mo.djd(typeUI). Payload RX30 bị redacted nhưng doOpenUI 4/10 ngay sau đó đối chiếu được loại bảng.
- Mẫu map68 không có TXcor/menu và không có RX17/21. Phần khác nhau đã chứng minh là chuỗi tương tác NPC trước mở UI, đồng thời map cũng khác: chưa tách được yếu tố map khỏi trạng thái NPC server.
- Hướng bản thử nghiệm: nút rương dùng cor5/menu5,0,0; nút nâng cấp dùng cor6/menu6,0,0; đợi phản hồi cmd30 mới dùng bảng do server mở, hết hạn thì báo không được server chấp nhận; không tự gửi lại giao dịch. Đây là hướng cần kiểm chứng ngoài map, chưa phải fix đã thành công.
- Chưa có mẫu Shop nên không suy NPC/menu Shop từ hai NPC trên.
- Lượt này chỉ phân tích, không sửa DLL hoặc mã chức năng.
