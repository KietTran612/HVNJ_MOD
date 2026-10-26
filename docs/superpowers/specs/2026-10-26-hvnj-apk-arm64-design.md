# Port HVNJ mod sang APK ARM64 — thiết kế đề xuất

Trạng thái: người dùng đã duyệt phương án B (M3). Đã triển khai mã9 tính năng/menu và tạo APK ARM64 ký riêng; kiểm tra logic/build/archive, chưa kiểm chứng trên thiết bị/server Android. Hướng dẫn và giới hạn: `HVNJ_MOD_APK/README.md`. Không commit/push trong công việc này nếu chưa có yêu cầu mới.

## Đầu vào đã xác minh

- APK gốc: `HVNJ_MOD_APK/HVNJ_185.apk`, 173674928 byte, SHA256 `2781a4fe636ea3ba52ea73f7b9c952847dd23e1b7e9bd5d7d6df0f403bd4ec0a`.
- Package `com.g4m.hocvienninja`, versionName `1.8.5`, versionCode 128; minSdk25/targetSdk36.
- Unity6000.3.17f1, IL2CPP metadata39. APK có arm64-v8a và armeabi-v7a; chỉ bản thử ARM64 thuộc phạm vi đầu tiên.
- Cpp2IL pre-release21 đọc được metadata và ánh xạ69919 method definitions; xuất6933 C# declarations,446 file trong Assembly-CSharp. Các thân hàm `{ }` là stub, không phải mã nguồn đã phục hồi đầy đủ.
- Tên lớp chính: MapScr, Char, Service, MonsterGame, TaskOrderGame. Chữ ký/địa chỉ đã lấy trong `HVNJ_MOD_APK/analysis/port_targets_arm64.json`; mã ARM64 chọn lọc ở `analysis/arm64_service_and_auto.asm.txt`.
- Il2CppDumper cũ trong repo không hỗ trợ metadata39. Không sửa version header để ép công cụ đọc sai.

## Mục tiêu và phạm vi

Chuyển hành vi của9 tính năng PC cùng menu Mod HVNJ sang Android ARM64; tính năng mặc định tắt, có lưu lựa chọn. Giữ APK gốc nguyên vẹn và tạo đầu ra mới. Giao diện dùng menu popup của game và nút phù hợp màn hình cảm ứng.

1. Né Boss/Tinh Anh/Thủ Lĩnh khi Auto, giữ ngoại lệ tà thú nhiệm vụ.
2. Chết khi Auto: gửi về làng, quay map cũ, bật Auto lại; xử lý ngoại lệ Thí Luyện.
3. Giữ Auto trong Thí Luyện.
4. Tự qua ải, đợi hết quái và chọn cổng hợp lệ.
5. Auto nhiệm vụ ngày bằng pipeline game.
6. Auto nhiệm vụ tà thú bằng pipeline game.
7. Theo trưởng nhóm và cùng mục tiêu trong phạm vi dữ liệu client biết.
8. Dọn túi: bán đồ thiếu dòng, cất đồ đủ dòng; có xem trước; bán/luyện/cất tuần tự.
9. Luyện đá khi đầy túi, chọn cấp, chỉ dùng tiền yên; kiểm tra packet thực tế trước khi bật giao dịch.

UI:9 dòng tick, cấu hình cấp đá/option NPC, xem trước trang bị, mở rương/nâng cấp, nút Top Rương/Nâng cấp. Shop thuộc mục port UI, nhưng không hứa dùng ngoài map; việc sửa dịch vụ từ xa vẫn theo kết quả kiểm chứng PC/Android. Tính năng tốc độ skill0.3s đã bỏ ở PC không được đưa lại.

Không giả map, không thêm trường packet tùy ý, không bỏ xác thực/anti-cheat/signature checks của server hoặc SDK. Quyền dùng rương/shop/nâng cấp xa NPC do server quyết định. Không thay đổi dữ liệu tài khoản.

## Các cách triển khai

A. Vá thêm payload trực tiếp vào ELF libil2cpp.so giống cách PC thêm section: ít thay đổi Java, nhưng phải quản lý load segments, relocation, ABI ARM64, trang16KB, trampoline/unwind; khó duy trì hơn khi Unity thay đổi.

B. **Đề xuất: thư viện native ARM64 riêng** (`libhvnjmod.so`) nạp qua activity bootstrap, kết nối IL2CPP sau khi runtime sẵn sàng và hook các điểm đã xác minh. Các thuật toán PC viết C được tái sử dụng sau khi đổi adapter; ASM x64 phải viết lại. Tách lỗi mod khỏi binary gốc và dễ log/kiểm tra hơn; cần toolchain Android và rebuild/sign APK.

Cả hai đều cần ký lại APK sau khi thay đổi. Không có source project Unity để build lại từ C# như một dự án Unity bình thường.

## Kiến trúc của phương án B

- Bootstrap Java/smali chỉ nạp thư viện mod; không đổi activity hoặc luồng SDK nếu không cần. Tải/hook trên worker thread có giới hạn thời gian, gắn IL2CPP thread đúng cách; cập nhật trạng thái/UI/giao dịch trên main game thread.
- Native hooks dùng thư viện ARM64 có xử lý relocation/trampoline (dự kiến Dobby, builder được chọn phiên bản tương thích và lưu provenance/license). Không tự chép lệnh entry ARM64 nếu chưa xử lý ADRP/PC-relative.
- Adapter runtime theo đúng SHA256 APK: lấy địa chỉ method từ mapping đã xác minh, so byte đầu trước hook; lấy field offset qua IL2CPP API. Không dùng offset Il2CppClass/MethodInfo của Unity2020 để đọc Unity6.
- Mỗi feature có cờ riêng và reset trạng thái khi tắt. Chỉ cài hook sau khi tìm đủ dependency; dependency không khớp thì giữ hành vi game, báo feature chưa khả dụng thay vì gọi địa chỉ phỏng đoán.
- Logic thuần C tách khỏi adapter để test; giữ quy tắc ưu tiên chết/đi đường/dọn túi/nhiệm vụ tránh hai lệnh đổi ô đồ đồng thời.
- Log qua Android logcat/file riêng, tránh credential/chat; có build/version/feature/error markers. Không tự gửi telemetry ra ngoài.
- Giá trị map161–167, NPC25/5/6, option nhiệm vụ và ý nghĩa command19/20 phải đối chiếu mã Android hoặc log Android trước khi dùng; kết quả PC là manh mối, không là bằng chứng cho APK185.
- Phiên bản đầu xuất APK chỉ arm64-v8a để thiết bị không chọn nhầm thư viện32-bit chưa port. Bản gốc vẫn giữ cả hai ABI.

## Đóng gói và ký

Đầu ra dự kiến: `HVNJ_MOD_APK/output/HVNJ_185_mod_arm64.apk`, kèm script build, báo cáo patch và hướng dẫn test. Giữ package gốc để giảm thay đổi SDK. Dùng khóa mod mới lưu cục bộ trong thư mục keys được loại khỏi Git; không dùng hoặc giả chữ ký nhà phát hành. APK ký mới không thể cài cập nhật đè lên bản chính thức ký bằng khóa khác; cài trên thiết bị/giả lập thử nghiệm phù hợp. Đăng nhập qua SDK phụ thuộc chữ ký/package có thể cần kiểm chứng; không hứa mọi provider hoạt động trước test. Không tự gỡ app/cài vào điện thoại của người dùng.

## Xác minh và tiêu chí bàn giao

1. Reverse-engineering: inventory/hash/manifest/ABI và mapping classes-methods-fields; disassemble các nhánh cần hook. Đây không đồng nghĩa phục hồi đầy đủ source.
2. Build nền ARM64 và nạp mod: menu hiện, tick lưu/đọc, tất cả cờ tắt giữ hành vi gốc; test trên runtime Android khi có máy/giả lập.
3. Port đủ9 tính năng theo từng nhóm; không gọi một APK chỉ có menu là đã port đủ. Kiểm tra logic bằng unit tests và thực thi ARM64 qua emulator/device hoặc công cụ mô phỏng phù hợp.
4. Kiểm tra ZIP/DEX/ELF, ABI duy nhấtARM64, alignment16KB phù hợp, zipalign và chữ ký bằng công cụ Android; verify APK gốc không đổi hash.
5. Bàn giao APK có chữ ký kiểm chứng được cùng danh sách chức năng đã test tĩnh/mô phỏng/in-game. Các phần chưa test server thật phải nêu rõ, không đánh dấu hoàn thành vì chỉ build được.

## Builder được tự quyết

Bố trí file source/adapters/test, phiên bản toolchain/NDK và hook dependency tương thích, cách tổ chức cache/build artifacts. Chỉ tải từ nguồn chính thức/primary và lưu versions/hashes. Không đăng APK hoặc khóa ký lên remote nếu chưa được yêu cầu.

## Quyết định đã duyệt

M3 đã duyệt phương án B và phạm vi ARM64/menu9 tính năng. Đã dùng NDK29, Dobby ghim commit31e4ab0cfc2bfa4512b4ea520786ea2403f97dfc, khóa ký mod cục bộ. Kiểm chứng in-game vẫn chưa có thiết bị để thực hiện.
