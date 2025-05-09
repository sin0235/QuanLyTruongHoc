USE QuanLyTruongHoc;
GO

-- Xóa dữ liệu điểm số hiện có của học sinh Nguyễn Văn An (MaHS=1, MaNguoiDung=101, Lớp 10A1)
DELETE FROM DiemSo WHERE MaHS = 1;

-- Thêm lại dữ liệu điểm số cho học sinh với sự chênh lệch giữa các môn và học kỳ
-- HỌC KỲ 1

-- Môn Toán (MaMon = 1) - Học kỳ 1 - Điểm khá cao
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1001, 1, 1, 7, 1, N'Miệng', 9.0),
(1002, 1, 1, 7, 1, N'15 phút', 8.5),
(1003, 1, 1, 7, 1, N'Giữa kỳ', 9.0),
(1004, 1, 1, 7, 1, N'Cuối kỳ', 8.5);

-- Môn Vật Lý (MaMon = 2) - Học kỳ 1 - Điểm trung bình
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1005, 1, 2, 12, 1, N'Miệng', 7.0),
(1006, 1, 2, 12, 1, N'15 phút', 6.5),
(1007, 1, 2, 12, 1, N'Giữa kỳ', 7.0),
(1008, 1, 2, 12, 1, N'Cuối kỳ', 6.5);

-- Môn Hóa Học (MaMon = 3) - Học kỳ 1 - Điểm khá thấp
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1009, 1, 3, 15, 1, N'Miệng', 5.5),
(1010, 1, 3, 15, 1, N'15 phút', 6.0),
(1011, 1, 3, 15, 1, N'Giữa kỳ', 5.5),
(1012, 1, 3, 15, 1, N'Cuối kỳ', 6.0);

-- Môn Sinh Học (MaMon = 4) - Học kỳ 1 - Điểm trung bình khá
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1013, 1, 4, 18, 1, N'Miệng', 7.5),
(1014, 1, 4, 18, 1, N'15 phút', 7.0),
(1015, 1, 4, 18, 1, N'Giữa kỳ', 7.5),
(1016, 1, 4, 18, 1, N'Cuối kỳ', 7.0);

-- Môn Ngữ Văn (MaMon = 5) - Học kỳ 1 - Điểm cao
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1017, 1, 5, 20, 1, N'Miệng', 9.5),
(1018, 1, 5, 20, 1, N'15 phút', 9.0),
(1019, 1, 5, 20, 1, N'Giữa kỳ', 9.5),
(1020, 1, 5, 20, 1, N'Cuối kỳ', 9.0);

-- Môn Lịch Sử (MaMon = 6) - Học kỳ 1 - Điểm trung bình khá
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1021, 1, 6, 23, 1, N'Miệng', 7.5),
(1022, 1, 6, 23, 1, N'15 phút', 7.0),
(1023, 1, 6, 23, 1, N'Giữa kỳ', 7.5),
(1024, 1, 6, 23, 1, N'Cuối kỳ', 7.0);

-- Môn Địa Lý (MaMon = 7) - Học kỳ 1 - Điểm khá
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1025, 1, 7, 25, 1, N'Miệng', 8.0),
(1026, 1, 7, 25, 1, N'15 phút', 8.5),
(1027, 1, 7, 25, 1, N'Giữa kỳ', 8.0),
(1028, 1, 7, 25, 1, N'Cuối kỳ', 8.5);

-- Môn Tiếng Anh (MaMon = 8) - Học kỳ 1 - Điểm thấp
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1029, 1, 8, 27, 1, N'Miệng', 6.0),
(1030, 1, 8, 27, 1, N'15 phút', 5.5),
(1031, 1, 8, 27, 1, N'Giữa kỳ', 6.0),
(1032, 1, 8, 27, 1, N'Cuối kỳ', 5.5);

-- Môn Giáo Dục Công Dân (MaMon = 9) - Học kỳ 1 - Điểm trung bình
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1033, 1, 9, 30, 1, N'Miệng', 7.0),
(1034, 1, 9, 30, 1, N'15 phút', 6.5),
(1035, 1, 9, 30, 1, N'Giữa kỳ', 7.0),
(1036, 1, 9, 30, 1, N'Cuối kỳ', 6.5);

-- Môn Thể Dục (MaMon = 10) - Học kỳ 1 - Điểm rất cao
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1037, 1, 10, 31, 1, N'Thực hành', 10.0),
(1038, 1, 10, 31, 1, N'Giữa kỳ', 9.5),
(1039, 1, 10, 31, 1, N'Cuối kỳ', 10.0);

-- Môn Tin Học (MaMon = 11) - Học kỳ 1 - Điểm khá cao
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1040, 1, 11, 32, 1, N'Miệng', 8.5),
(1041, 1, 11, 32, 1, N'15 phút', 9.0),
(1042, 1, 11, 32, 1, N'Giữa kỳ', 8.5),
(1043, 1, 11, 32, 1, N'Cuối kỳ', 9.0);

-- Môn Công Nghệ (MaMon = 12) - Học kỳ 1 - Điểm trung bình
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1044, 1, 12, 33, 1, N'Miệng', 7.0),
(1045, 1, 12, 33, 1, N'15 phút', 6.5),
(1046, 1, 12, 33, 1, N'Giữa kỳ', 7.0),
(1047, 1, 12, 33, 1, N'Cuối kỳ', 6.5);

-- HỌC KỲ 2 - Có sự thay đổi điểm so với học kỳ 1

-- Môn Toán (MaMon = 1) - Học kỳ 2 - Điểm tăng so với học kỳ 1
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1048, 1, 1, 7, 2, N'Miệng', 9.5),
(1049, 1, 1, 7, 2, N'15 phút', 9.0),
(1050, 1, 1, 7, 2, N'Giữa kỳ', 9.5),
(1051, 1, 1, 7, 2, N'Cuối kỳ', 9.0);

-- Môn Vật Lý (MaMon = 2) - Học kỳ 2 - Điểm cải thiện chút so với học kỳ 1
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1052, 1, 2, 12, 2, N'Miệng', 7.5),
(1053, 1, 2, 12, 2, N'15 phút', 7.0),
(1054, 1, 2, 12, 2, N'Giữa kỳ', 7.5),
(1055, 1, 2, 12, 2, N'Cuối kỳ', 7.0);

-- Môn Hóa Học (MaMon = 3) - Học kỳ 2 - Điểm tăng đáng kể
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1056, 1, 3, 15, 2, N'Miệng', 7.0),
(1057, 1, 3, 15, 2, N'15 phút', 7.5),
(1058, 1, 3, 15, 2, N'Giữa kỳ', 7.0),
(1059, 1, 3, 15, 2, N'Cuối kỳ', 7.5);

-- Môn Sinh Học (MaMon = 4) - Học kỳ 2 - Điểm giảm so với học kỳ 1
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1060, 1, 4, 18, 2, N'Miệng', 6.5),
(1061, 1, 4, 18, 2, N'15 phút', 6.0),
(1062, 1, 4, 18, 2, N'Giữa kỳ', 6.5),
(1063, 1, 4, 18, 2, N'Cuối kỳ', 6.0);

-- Môn Ngữ Văn (MaMon = 5) - Học kỳ 2 - Điểm giảm nhẹ so với học kỳ 1
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1064, 1, 5, 20, 2, N'Miệng', 9.0),
(1065, 1, 5, 20, 2, N'15 phút', 8.5),
(1066, 1, 5, 20, 2, N'Giữa kỳ', 9.0),
(1067, 1, 5, 20, 2, N'Cuối kỳ', 8.5);

-- Môn Lịch Sử (MaMon = 6) - Học kỳ 2 - Điểm tăng đáng kể
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1068, 1, 6, 23, 2, N'Miệng', 8.5),
(1069, 1, 6, 23, 2, N'15 phút', 9.0),
(1070, 1, 6, 23, 2, N'Giữa kỳ', 8.5),
(1071, 1, 6, 23, 2, N'Cuối kỳ', 9.0);

-- Môn Địa Lý (MaMon = 7) - Học kỳ 2 - Điểm giảm so với học kỳ 1
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1072, 1, 7, 25, 2, N'Miệng', 7.0),
(1073, 1, 7, 25, 2, N'15 phút', 6.5),
(1074, 1, 7, 25, 2, N'Giữa kỳ', 7.0),
(1075, 1, 7, 25, 2, N'Cuối kỳ', 6.5);

-- Môn Tiếng Anh (MaMon = 8) - Học kỳ 2 - Điểm tăng mạnh
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1076, 1, 8, 27, 2, N'Miệng', 8.0),
(1077, 1, 8, 27, 2, N'15 phút', 8.5),
(1078, 1, 8, 27, 2, N'Giữa kỳ', 8.0),
(1079, 1, 8, 27, 2, N'Cuối kỳ', 8.5);

-- Môn Giáo Dục Công Dân (MaMon = 9) - Học kỳ 2 - Điểm tăng
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1080, 1, 9, 30, 2, N'Miệng', 8.0),
(1081, 1, 9, 30, 2, N'15 phút', 7.5),
(1082, 1, 9, 30, 2, N'Giữa kỳ', 8.0),
(1083, 1, 9, 30, 2, N'Cuối kỳ', 7.5);

-- Môn Thể Dục (MaMon = 10) - Học kỳ 2 - Điểm vẫn giữ ở mức cao
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1084, 1, 10, 31, 2, N'Thực hành', 9.5),
(1085, 1, 10, 31, 2, N'Giữa kỳ', 10.0),
(1086, 1, 10, 31, 2, N'Cuối kỳ', 9.5);

-- Môn Tin Học (MaMon = 11) - Học kỳ 2 - Điểm tăng lên khá cao
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1087, 1, 11, 32, 2, N'Miệng', 9.5),
(1088, 1, 11, 32, 2, N'15 phút', 9.0),
(1089, 1, 11, 32, 2, N'Giữa kỳ', 9.5),
(1090, 1, 11, 32, 2, N'Cuối kỳ', 9.0);

-- Môn Công Nghệ (MaMon = 12) - Học kỳ 2 - Điểm giảm so với học kỳ 1
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1091, 1, 12, 33, 2, N'Miệng', 6.0),
(1092, 1, 12, 33, 2, N'15 phút', 5.5),
(1093, 1, 12, 33, 2, N'Giữa kỳ', 6.0),
(1094, 1, 12, 33, 2, N'Cuối kỳ', 5.5); 