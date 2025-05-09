USE QuanLyTruongHoc;
GO

-- Thêm dữ liệu mẫu cho bảng ThongBao
-- Thông báo chung từ Ban Giám Hiệu đến toàn trường (MaVaiTroNhan = NULL, MaNguoiNhan = NULL, MaLop = NULL)
INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui, isActive) VALUES
(1, NULL, NULL, NULL, NULL, N'Thông báo lịch nghỉ Tết Nguyên Đán', N'Nhà trường thông báo lịch nghỉ Tết Nguyên Đán năm học 2024-2025 sẽ bắt đầu từ ngày 25/01/2025 đến hết ngày 05/02/2025. Học sinh đi học trở lại vào ngày 06/02/2025. Đề nghị các em chuẩn bị bài học và hoàn thành các bài tập được giao trước kỳ nghỉ.', '2024-01-10 08:00:00', 1),
(1, NULL, NULL, NULL, NULL, N'Thông báo về Hội nghị phụ huynh giữa năm', N'Nhà trường tổ chức Hội nghị phụ huynh giữa năm học 2024-2025 vào ngày 15/01/2025. Thời gian cụ thể: Khối 10 từ 7h30-9h30; Khối 11 từ 9h45-11h45; Khối 12 từ 14h00-16h00. Đề nghị các em thông báo đến phụ huynh tham dự đầy đủ.', '2024-01-05 10:30:00', 1),
(2, NULL, NULL, NULL, NULL, N'Kế hoạch tổ chức kỳ thi học kỳ I', N'Kỳ thi học kỳ I năm học 2024-2025 sẽ được tổ chức từ ngày 05/01/2025 đến ngày 12/01/2025. Lịch thi cụ thể đã được niêm yết tại bảng thông báo và website của trường. Các em chuẩn bị ôn tập và tham dự kỳ thi nghiêm túc, đúng quy chế.', '2023-12-20 09:15:00', 1),
(3, NULL, NULL, NULL, NULL, N'Thông báo về việc tăng cường an ninh trường học', N'Để đảm bảo an ninh trường học, nhà trường yêu cầu tất cả học sinh luôn đeo thẻ học sinh khi đến trường, không mang theo các vật dụng nguy hiểm, không tự ý rời khỏi trường trong giờ học. Mọi trường hợp ra vào cần có giấy phép của Ban Giám Hiệu.', '2023-11-10 15:45:00', 1),
(1, NULL, NULL, NULL, NULL, N'Thông báo về hoạt động ngoại khóa cuối học kỳ I', N'Nhà trường tổ chức các hoạt động ngoại khóa, văn nghệ và thể thao chào mừng kết thúc học kỳ I vào ngày 18/01/2025. Các lớp chuẩn bị tiết mục văn nghệ và cử học sinh tham gia các môn thể thao theo thông báo chi tiết của Đoàn trường.', '2024-01-02 13:20:00', 1);

-- Thông báo đến từng khối lớp (MaVaiTroNhan = NULL, MaNguoiNhan = NULL, chỉ định MaLop)
-- Thông báo đến khối 10 (lớp 10A1 - MaLop = 1)
INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui, isActive) VALUES
(7, NULL, NULL, 1, NULL, N'Thông báo họp lớp 10A1', N'Họp lớp 10A1 vào 15h30 ngày 05/01/2025 để phổ biến kế hoạch học tập học kỳ II và bầu lại ban cán sự lớp. Yêu cầu học sinh tham dự đầy đủ.', '2024-01-03 10:00:00', 1),
(7, NULL, NULL, 1, NULL, N'Lịch kiểm tra 15 phút môn Toán lớp 10A1', N'Thông báo lớp 10A1 sẽ có bài kiểm tra 15 phút môn Toán vào tiết 3 ngày 08/01/2025. Nội dung kiểm tra: Chương 3 - Phương trình bậc hai. Các em chuẩn bị bài chu đáo.', '2024-01-04 14:30:00', 1);

-- Thông báo đến khối 11 (lớp 11A2 - MaLop = 6)
INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui, isActive) VALUES
(18, NULL, NULL, 6, NULL, N'Thông báo chuyến tham quan học tập lớp 11A2', N'Lớp 11A2 sẽ tham gia chuyến tham quan học tập tại Bảo tàng Lịch sử vào ngày 10/01/2025. Tập trung tại sân trường lúc 7h30. Học sinh chuẩn bị dụng cụ ghi chép và đóng phí tham quan 50.000đ cho lớp trưởng trước ngày 09/01/2025.', '2024-01-02 08:45:00', 1),
(18, NULL, NULL, 6, NULL, N'Nộp bài tập lớn môn Sinh học lớp 11A2', N'Nhắc nhở học sinh lớp 11A2 nộp bài tập lớn môn Sinh học với chủ đề "Bảo vệ môi trường" trước ngày 12/01/2025. Bài nộp cho giáo viên bộ môn đúng quy cách theo hướng dẫn đã phát.', '2023-12-28 09:30:00', 1);

-- Thông báo đến khối 12 (lớp 12A3 - MaLop = 11)
INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui, isActive) VALUES
(27, NULL, NULL, 11, NULL, N'Lịch ôn tập cho kỳ thi THPT Quốc gia lớp 12A3', N'Thông báo lịch ôn tập buổi chiều cho kỳ thi THPT Quốc gia đối với lớp 12A3: Thứ 2 - môn Toán; Thứ 3 - môn Văn; Thứ 4 - môn Anh; Thứ 5 - môn Vật Lý; Thứ 6 - môn Hóa học. Thời gian: 14h00-16h30. Bắt đầu từ ngày 08/01/2025.', '2024-01-03 13:15:00', 1),
(27, NULL, NULL, 11, NULL, N'Hướng dẫn đăng ký nguyện vọng đại học cho lớp 12A3', N'Giáo viên chủ nhiệm sẽ tổ chức buổi hướng dẫn đăng ký nguyện vọng đại học cho học sinh lớp 12A3 vào 15h00 ngày 07/01/2025 tại phòng Đa năng. Phụ huynh có thể tham dự cùng học sinh. Mang theo giấy bút để ghi chép thông tin quan trọng.', '2024-01-02 16:40:00', 1);

-- Thông báo theo bộ môn (chỉ định MaMon, có thể kết hợp với MaLop)
INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui, isActive) VALUES
(12, NULL, NULL, NULL, 2, N'Cuộc thi Vật lý trẻ cấp thành phố', N'Thông báo về Cuộc thi Vật lý trẻ cấp thành phố sẽ diễn ra vào ngày 20/01/2025. Học sinh có khả năng môn Vật lý đăng ký tham gia tại văn phòng Đoàn trường trước ngày 12/01/2025. Giáo viên bộ môn sẽ tổ chức ôn luyện cho đội tuyển.', '2024-01-02 10:25:00', 1),
(15, NULL, NULL, NULL, 3, N'Thông báo thi thực hành Hóa học', N'Các lớp 10, 11, 12 sẽ có bài thi thực hành Hóa học vào tuần từ 15/01/2025 đến 19/01/2025 theo lịch của từng lớp. Nội dung: Các bài thực hành đã học trong học kỳ I. Học sinh chuẩn bị đầy đủ dụng cụ bảo hộ theo quy định.', '2024-01-03 11:20:00', 1),
(20, NULL, NULL, 1, 5, N'Cuộc thi viết văn với chủ đề "Tình yêu quê hương" lớp 10A1', N'Thông báo cuộc thi viết văn dành riêng cho lớp 10A1 với chủ đề "Tình yêu quê hương". Bài dự thi không quá 5 trang giấy A4, nộp cho giáo viên môn Văn trước ngày 15/01/2025. Ba bài xuất sắc nhất sẽ được gửi dự thi cấp thành phố.', '2024-01-04 08:15:00', 1);

-- Thông báo cá nhân (chỉ định MaNguoiNhan cụ thể)
INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui, isActive) VALUES
(7, 101, NULL, NULL, NULL, N'Thông báo kết quả học tập học sinh Nguyễn Văn An', N'Thông báo đến phụ huynh học sinh Nguyễn Văn An về kết quả học tập học kỳ I: Điểm trung bình các môn đạt 7.8, xếp loại Khá. Học sinh cần cải thiện môn Hóa học (điểm trung bình: 5.8) và Tiếng Anh (điểm trung bình: 5.8). Đề nghị phụ huynh quan tâm nhắc nhở.', '2024-01-15 09:30:00', 1),
(12, 101, NULL, NULL, 2, N'Đề nghị tham gia đội tuyển Olympic Vật lý', N'Thông báo học sinh Nguyễn Văn An được đề cử tham gia đội tuyển Olympic Vật lý của trường do có tiến bộ vượt bậc trong học kỳ II. Đề nghị học sinh xác nhận tham gia và gặp giáo viên bộ môn vào 15h00 ngày 12/01/2025 tại phòng Vật lý.', '2024-01-10 14:20:00', 1),
(15, 153, NULL, NULL, 3, N'Nhắc nhở nộp báo cáo thí nghiệm Hóa học', N'Nhắc nhở học sinh Đinh Văn Long (lớp 10A4) nộp báo cáo thí nghiệm Hóa học đã quá hạn 3 ngày. Yêu cầu hoàn thành và nộp trước ngày 10/01/2025. Nếu không nộp đúng hạn sẽ bị trừ điểm quá trình học kỳ I.', '2024-01-07 13:40:00', 1),
(23, 101, NULL, NULL, 6, N'Ghi nhận thành tích xuất sắc môn Lịch sử', N'Ghi nhận và khen ngợi em Nguyễn Văn An đã có bài thuyết trình xuất sắc về đề tài "Chiến tranh thế giới thứ hai và tác động đến Việt Nam". Khuyến khích em tiếp tục phát huy trong học kỳ II và cân nhắc tham gia cuộc thi Sử học cấp thành phố.', '2024-01-08 16:10:00', 1),
(7, 153, NULL, NULL, 1, N'Đề nghị gặp giáo viên chủ nhiệm', N'Đề nghị học sinh Đinh Văn Long gặp giáo viên chủ nhiệm vào giờ ra chơi tiết 3 ngày 11/01/2025 tại phòng giáo viên để trao đổi về tiến độ học tập và một số vấn đề liên quan đến chuyên cần trong thời gian qua.', '2024-01-09 07:50:00', 1);

-- Thông báo đến nhóm người dùng theo vai trò (chỉ định MaVaiTroNhan)
INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui, isActive) VALUES
(1, NULL, 3, NULL, NULL, N'Họp Hội đồng giáo viên đầu học kỳ II', N'Thông báo họp Hội đồng giáo viên toàn trường vào 14h00 ngày 06/01/2025 tại Hội trường lớn. Nội dung: Tổng kết học kỳ I và triển khai kế hoạch học kỳ II năm học 2024-2025. Yêu cầu tất cả giáo viên tham dự đầy đủ, đúng giờ.', '2024-01-03 11:00:00', 1),
(2, NULL, 3, NULL, NULL, N'Nộp kế hoạch giảng dạy học kỳ II', N'Đề nghị tất cả giáo viên nộp kế hoạch giảng dạy chi tiết học kỳ II năm học 2024-2025 cho Phó Hiệu trưởng phụ trách chuyên môn trước ngày 10/01/2025. File mềm gửi qua email, bản cứng có chữ ký nộp tại văn phòng.', '2024-01-04 09:30:00', 1),
(4, NULL, 3, NULL, NULL, N'Hướng dẫn thủ tục thanh toán chế độ đầu năm', N'Thông báo đến toàn thể giáo viên về thủ tục thanh toán các chế độ đầu năm 2025. Đề nghị giáo viên chuẩn bị hồ sơ theo danh mục đính kèm và nộp về phòng Kế toán từ ngày 15/01 đến 20/01/2025.', '2024-01-05 08:15:00', 1);

-- Thông báo đã vô hiệu hóa (isActive = 0)
INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui, isActive) VALUES
(1, NULL, NULL, NULL, NULL, N'Lịch thi học kỳ I (BỎ) - Đã có lịch mới', N'Thông báo lịch thi học kỳ I theo kế hoạch cũ. LƯU Ý: Lịch này đã được thay thế bằng lịch mới do điều chỉnh thời gian của Sở GD&ĐT.', '2023-12-15 10:20:00', 0),
(18, NULL, NULL, 6, NULL, N'Dời lịch kiểm tra Sinh học lớp 11A2', N'Thông báo dời lịch kiểm tra 1 tiết môn Sinh học lớp 11A2 từ ngày 05/01/2025 sang ngày 08/01/2025. LƯU Ý: Thông báo này không còn hiệu lực, kiểm tra vẫn diễn ra theo lịch cũ.', '2024-01-02 13:10:00', 0); 