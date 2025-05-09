USE QuanLyTruongHoc;
GO

-- Dữ liệu mẫu cho bảng ThongBao
INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui, isActive) VALUES
-- Thông báo từ Ban Giám Hiệu đến tất cả giáo viên
(1, NULL, 3, NULL, NULL, N'Thông báo về Họp Hội Đồng Sư Phạm tháng 5/2025', N'Kính gửi toàn thể quý thầy cô,\n\nNhà trường trân trọng thông báo lịch họp Hội đồng sư phạm tháng 5/2025 sẽ được tổ chức vào lúc 14h00 ngày 10/05/2025 (Thứ Bảy) tại phòng Hội đồng.\n\nThành phần tham dự: Toàn thể cán bộ, giáo viên, nhân viên nhà trường.\n\nNội dung:\n1. Đánh giá kết quả học tập, rèn luyện của học sinh trong tháng 4/2025\n2. Triển khai kế hoạch tổ chức ôn thi học kỳ 2 năm học 2024-2025\n3. Thông báo lịch thi học kỳ 2\n4. Một số công tác khác\n\nĐề nghị tất cả CB-GV-NV tham dự đầy đủ, đúng giờ.\n\nTrân trọng,\nBan Giám Hiệu', '2025-05-03', 1),

-- Thông báo từ Ban Giám Hiệu đến tất cả học sinh
(1, NULL, 4, NULL, NULL, N'Thông báo lịch thi học kỳ 2 năm học 2024-2025', N'Kính gửi toàn thể học sinh,\n\nNhà trường thông báo lịch thi học kỳ 2 năm học 2024-2025 như sau:\n\n1. Thời gian thi: từ ngày 25/05/2025 đến ngày 05/06/2025\n2. Lịch thi cụ thể:\n   - Ngày 25/05: Môn Toán\n   - Ngày 27/05: Môn Ngữ văn\n   - Ngày 29/05: Môn Tiếng Anh\n   - Ngày 31/05: Môn Vật lý, Hóa học, Sinh học\n   - Ngày 02/06: Môn Lịch sử, Địa lý\n   - Ngày 03/06: Môn GDCD, Tin học\n   - Ngày 05/06: Môn Công nghệ, Thể dục\n\nYêu cầu tất cả học sinh nghiêm túc thực hiện quy chế thi, có mặt trước giờ thi 15 phút. Học sinh mang theo đầy đủ thẻ học sinh và các đồ dùng học tập cần thiết.\n\nTrân trọng,\nBan Giám Hiệu', '2025-05-08', 1),

-- Thông báo từ Giáo viên chủ nhiệm lớp 10A1 đến học sinh lớp 10A1
(7, NULL, NULL, 1, NULL, N'Thông báo về việc nộp Học phí Học kỳ 2 năm học 2024-2025', N'Kính gửi Quý phụ huynh và các em học sinh lớp 10A1,\n\nCô thông báo về việc thu học phí học kỳ 2 năm học 2024-2025 như sau:\n\n1. Mức thu: 2.500.000 VNĐ/học sinh\n2. Thời gian: từ ngày 05/05/2025 đến hết ngày 15/05/2025\n3. Hình thức:\n   - Nộp trực tiếp tại Phòng Tài vụ nhà trường\n   - Chuyển khoản qua ngân hàng (thông tin tài khoản đã được gửi trong sổ liên lạc điện tử)\n\nNhà trường rất mong nhận được sự hợp tác của Quý phụ huynh.\n\nTrân trọng,\nCô Đỗ Thị Hương - GVCN lớp 10A1', '2025-05-04', 1),

-- Thông báo từ Giáo viên môn Văn đến học sinh lớp 10A1
(20, NULL, NULL, 1, 5, N'Thông báo về việc thực hiện bài thí nghiệm Vật lý', N'Các em học sinh lớp 10A1 thân mến,\n\nThầy thông báo về lịch thực hiện bài thí nghiệm Vật lý sắp tới:\n\n1. Thời gian: Tiết học ngày 13/05/2025 (tiết 1-2)\n2. Địa điểm: Phòng thí nghiệm Vật lý\n3. Nội dung: Thí nghiệm về chuyển động thẳng đều và chuyển động thẳng biến đổi đều\n4. Chuẩn bị: Vở thí nghiệm, bút, thước, máy tính cầm tay\n\nĐây là bài thí nghiệm quan trọng và kết quả sẽ được tính vào điểm kiểm tra thường xuyên. Yêu cầu tất cả học sinh có mặt đầy đủ, đúng giờ.\n\nTrân trọng,\nThầy Hồ Văn Anh - GV môn Ngữ Văn', '2025-05-06', 1),

-- Thông báo từ Phòng Nội vụ đến tất cả học sinh
(4, NULL, 4, NULL, NULL, N'Thông báo về việc nộp kế hoạch giảng dạy học kỳ 1 năm học 2025-2026', N'Kính gửi toàn thể giáo viên,\n\nPhòng Nội vụ thông báo về việc nộp kế hoạch giảng dạy học kỳ 1 năm học 2025-2026 như sau:\n\n1. Thời gian nộp: từ ngày 10/05/2025 đến hết ngày 30/05/2025\n2. Hình thức nộp:\n   - Bản in nộp trực tiếp tại Phòng Nội vụ\n   - Bản mềm gửi qua email: noivuCXYZ@school.edu.vn\n\n3. Yêu cầu:\n   - Kế hoạch phải tuân thủ theo mẫu quy định của Sở GD&ĐT\n   - Nội dung phải phù hợp với chương trình khung và tình hình thực tế của nhà trường\n   - Có kế hoạch cụ thể cho từng tuần học\n\nĐề nghị tất cả giáo viên nộp đúng thời hạn để Phòng Nội vụ tổng hợp và trình Ban Giám Hiệu phê duyệt.\n\nTrân trọng,\nPhòng Nội vụ', '2025-05-09', 1),

-- Thông báo từ Giáo viên môn Toán đến học sinh lớp 10A2
(8, NULL, NULL, 2, 1, N'Thông báo về việc ôn tập và kiểm tra Hóa học', N'Các em học sinh lớp 10A2 thân mến,\n\nCô thông báo về lịch ôn tập và kiểm tra Hóa học cuối học kỳ 2 như sau:\n\n1. Lịch ôn tập:\n   - Ngày 14/05: Ôn tập chương 5 và 6\n   - Ngày 18/05: Ôn tập chương 7 và 8\n   - Ngày 21/05: Ôn tập tổng hợp và giải đáp thắc mắc\n\n2. Kiểm tra 1 tiết: Ngày 22/05/2025 (tiết 3-4)\n\nYêu cầu các em chuẩn bị bài đầy đủ, ôn tập kỹ các công thức và bài tập đã học trong học kỳ 2.\n\nTrân trọng,\nCô Võ Thị Thảo', '2025-05-09', 1);

-- Dữ liệu mẫu cho bảng KeHoachGiangDay
INSERT INTO KeHoachGiangDay (MaKH, MaGV, MaMon, Tuan, MaLop, NoiDungGiangDay) VALUES
-- Kế hoạch giảng dạy môn Toán lớp 10A1, Cô Đỗ Thị Hương
(1, 7, 1, 1, 1, N'Tuần 1 (04/05 - 09/05/2025):\n- Ổn định tổ chức lớp học\n- Giới thiệu tổng quan môn Toán lớp 10\n- Bài 1: Mệnh đề - Mệnh đề phủ định (2 tiết)\n- Bài 2: Tập hợp (1 tiết)\n- Bài tập và thực hành (2 tiết)'),
(2, 7, 1, 2, 1, N'Tuần 2 (11/05 - 16/05/2025):\n- Bài 3: Các phép toán tập hợp (2 tiết)\n- Bài 4: Mệnh đề kéo theo - Mệnh đề tương đương (2 tiết)\n- Bài tập và thực hành (1 tiết)'),
(3, 7, 1, 3, 1, N'Tuần 3 (18/05 - 23/05/2025):\n- Bài 5: Các tập hợp số (2 tiết)\n- Bài 6: Khái niệm ban đầu về hàm số (2 tiết)\n- Kiểm tra (1 tiết)'),

-- Kế hoạch giảng dạy môn Văn lớp 10A1, Thầy Hồ Văn Anh
(4, 20, 5, 1, 1, N'Tuần 1 (04/05 - 09/05/2025):\n- Giới thiệu tổng quan môn Ngữ văn lớp 10\n- Tổng quan văn học Việt Nam\n- Văn học dân gian - Khái niệm và đặc trưng\n- Phân tích tác phẩm "Tấm Cám" (2 tiết)'),
(5, 20, 5, 2, 1, N'Tuần 2 (11/05 - 16/05/2025):\n- Tiếp tục văn học dân gian\n- Phân tích tác phẩm "Sơn Tinh - Thủy Tinh" (2 tiết)\n- Thực hành phân tích truyện dân gian (1 tiết)'),
(6, 20, 5, 3, 1, N'Tuần 3 (18/05 - 23/05/2025):\n- Khái quát về thơ ca dân gian\n- Phân tích tác phẩm "Cây tre Việt Nam"\n- Phân tích tác phẩm "Ca dao than thân, yêu thương tình nghĩa"\n- Kiểm tra (1 tiết)'),

-- Kế hoạch giảng dạy môn Lý lớp 10A1, Thầy Hoàng Văn Phúc
(7, 12, 2, 1, 1, N'Tuần 1 (04/05 - 09/05/2025):\n- Giới thiệu tổng quan môn Vật lý lớp 10\n- Bài 1: Chuyển động cơ\n- Bài 2: Chuyển động thẳng đều\n- Thực hành và bài tập (1 tiết)'),
(8, 12, 2, 2, 1, N'Tuần 2 (11/05 - 16/05/2025):\n- Bài 3: Chuyển động thẳng biến đổi đều\n- Bài 4: Sự rơi tự do\n- Thực hành và bài tập (1 tiết)'),
(9, 12, 2, 3, 1, N'Tuần 3 (18/05 - 23/05/2025):\n- Bài 5: Chuyển động tròn đều\n- Ôn tập chương I\n- Kiểm tra (1 tiết)'),

-- Kế hoạch giảng dạy môn Toán lớp 10A2, Thầy Ngô Văn Dũng
(10, 8, 1, 1, 2, N'Tuần 1 (04/05 - 09/05/2025):\n- Ổn định tổ chức lớp học\n- Giới thiệu tổng quan môn Toán lớp 10\n- Bài 1: Mệnh đề - Mệnh đề phủ định (2 tiết)\n- Bài 2: Tập hợp (1 tiết)\n- Bài tập và thực hành (2 tiết)'),
(11, 8, 1, 2, 2, N'Tuần 2 (11/05 - 16/05/2025):\n- Bài 3: Các phép toán tập hợp (2 tiết)\n- Bài 4: Mệnh đề kéo theo - Mệnh đề tương đương (2 tiết)\n- Bài tập và thực hành (1 tiết)'),
(12, 8, 1, 3, 2, N'Tuần 3 (18/05 - 23/05/2025):\n- Bài 5: Các tập hợp số (2 tiết)\n- Bài 6: Khái niệm ban đầu về hàm số (2 tiết)\n- Kiểm tra (1 tiết)');

-- Dữ liệu mẫu cho bảng DonXinNghi
INSERT INTO DonXinNghi (MaDon, MaHS, NgayGui, NgayNghi, LyDo, MaGV, TrangThai) VALUES
(1, 4, '2025-05-03', '2025-05-04', N'Em bị ốm, sốt cao nên cần nghỉ học để đi khám và điều trị bệnh.', 7, N'Đã duyệt'),
(2, 9, '2025-05-04', '2025-05-05', N'Em có hẹn khám định kỳ tại bệnh viện.', 7, N'Đã duyệt'),
(3, 6, '2025-05-06', '2025-05-07', N'Gia đình em có việc riêng cần em tham gia cùng.', 7, N'Đã duyệt'),
(4, 14, '2025-05-05', '2025-05-06', N'Em cần đi làm giấy tờ cá nhân tại UBND phường.', 7, N'Đã từ chối'),
(5, 3, '2025-05-10', '2025-05-11', N'Em bị ốm, cảm cúm nên cần nghỉ ngơi tại nhà.', 7, N'Đã duyệt'),
(6, 7, '2025-05-11', '2025-05-12', N'Gia đình em có tang nên em cần về quê trong ngày.', 7, N'Đã duyệt'),
(7, 13, '2025-05-07', '2025-05-08', N'Em có hẹn khám chuyên khoa tại bệnh viện.', 7, N'Đã duyệt'),
(8, 18, '2025-05-03', '2025-05-04', N'Em bị viêm họng cần đi khám bệnh', 8, N'Đã duyệt'),
(9, 24, '2025-05-04', '2025-05-05', N'Gia đình em có việc riêng cần em tham gia.', 8, N'Đã duyệt'),
(10, 30, '2025-05-03', '2025-05-04', N'Em bị đau bụng cấp tính, cần nghỉ ngơi.', 8, N'Đã từ chối');