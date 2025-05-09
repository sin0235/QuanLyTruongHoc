USE QuanLyTruongHoc;
GO

-- Thêm điểm môn Hóa học (MaMon = 3) cho lớp 10A1, Giáo viên có MaGV = 15
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 1 - Nguyễn Văn An
(101, 1, 3, 15, 1, N'Miệng', 7.5),
(102, 1, 3, 15, 1, N'15 phút', 8.0),
(103, 1, 3, 15, 1, N'Giữa kỳ', 7.5),
(104, 1, 3, 15, 1, N'Cuối kỳ', 8.0),

-- Học sinh 2 - Trần Thị Bích
(105, 2, 3, 15, 1, N'Miệng', 8.0),
(106, 2, 3, 15, 1, N'15 phút', 8.5),
(107, 2, 3, 15, 1, N'Giữa kỳ', 8.0),
(108, 2, 3, 15, 1, N'Cuối kỳ', 8.5),

-- Học sinh 3 - Lê Minh Cường
(109, 3, 3, 15, 1, N'Miệng', 7.0),
(110, 3, 3, 15, 1, N'15 phút', 7.5),
(111, 3, 3, 15, 1, N'Giữa kỳ', 7.0),
(112, 3, 3, 15, 1, N'Cuối kỳ', 7.5);

-- Thêm điểm môn Sinh học (MaMon = 4) cho lớp 10A1, Giáo viên có MaGV = 18
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 1 - Nguyễn Văn An
(113, 1, 4, 18, 1, N'Miệng', 8.0),
(114, 1, 4, 18, 1, N'15 phút', 7.5),
(115, 1, 4, 18, 1, N'Giữa kỳ', 8.0),
(116, 1, 4, 18, 1, N'Cuối kỳ', 7.5),

-- Học sinh 2 - Trần Thị Bích
(117, 2, 4, 18, 1, N'Miệng', 8.5),
(118, 2, 4, 18, 1, N'15 phút', 9.0),
(119, 2, 4, 18, 1, N'Giữa kỳ', 8.5),
(120, 2, 4, 18, 1, N'Cuối kỳ', 9.0),

-- Học sinh 3 - Lê Minh Cường
(121, 3, 4, 18, 1, N'Miệng', 7.0),
(122, 3, 4, 18, 1, N'15 phút', 6.5),
(123, 3, 4, 18, 1, N'Giữa kỳ', 7.0),
(124, 3, 4, 18, 1, N'Cuối kỳ', 6.5);

-- Thêm điểm môn Tiếng Anh (MaMon = 8) cho lớp 10A1, Giáo viên có MaGV = 27
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 6 - Vũ Thị Hà
(125, 6, 8, 27, 1, N'Miệng', 9.0),
(126, 6, 8, 27, 1, N'15 phút', 8.5),
(127, 6, 8, 27, 1, N'Giữa kỳ', 9.0),
(128, 6, 8, 27, 1, N'Cuối kỳ', 8.5),

-- Học sinh 7 - Đặng Minh Hùng
(129, 7, 8, 27, 1, N'Miệng', 7.5),
(130, 7, 8, 27, 1, N'15 phút', 8.0),
(131, 7, 8, 27, 1, N'Giữa kỳ', 7.5),
(132, 7, 8, 27, 1, N'Cuối kỳ', 8.0),

-- Học sinh 8 - Ngô Thị Lan
(133, 8, 8, 27, 1, N'Miệng', 8.5),
(134, 8, 8, 27, 1, N'15 phút', 9.0),
(135, 8, 8, 27, 1, N'Giữa kỳ', 8.5),
(136, 8, 8, 27, 1, N'Cuối kỳ', 9.0);

-- Thêm điểm môn Lịch sử (MaMon = 6) cho lớp 10A1, Giáo viên có MaGV = 23
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 9 - Phan Văn Minh
(137, 9, 6, 23, 1, N'Miệng', 8.0),
(138, 9, 6, 23, 1, N'15 phút', 7.5),
(139, 9, 6, 23, 1, N'Giữa kỳ', 8.0),
(140, 9, 6, 23, 1, N'Cuối kỳ', 7.5),

-- Học sinh 10 - Bùi Thị Nga
(141, 10, 6, 23, 1, N'Miệng', 7.0),
(142, 10, 6, 23, 1, N'15 phút', 7.5),
(143, 10, 6, 23, 1, N'Giữa kỳ', 7.0),
(144, 10, 6, 23, 1, N'Cuối kỳ', 7.5),

-- Học sinh 11 - Lý Văn Phúc
(145, 11, 6, 23, 1, N'Miệng', 6.5),
(146, 11, 6, 23, 1, N'15 phút', 7.0),
(147, 11, 6, 23, 1, N'Giữa kỳ', 6.5),
(148, 11, 6, 23, 1, N'Cuối kỳ', 7.0);

-- Thêm điểm môn Địa lý (MaMon = 7) cho lớp 10A1, Giáo viên có MaGV = 25
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 12 - Võ Thị Quỳnh
(149, 12, 7, 25, 1, N'Miệng', 8.5),
(150, 12, 7, 25, 1, N'15 phút', 8.0),
(151, 12, 7, 25, 1, N'Giữa kỳ', 8.5),
(152, 12, 7, 25, 1, N'Cuối kỳ', 8.0),

-- Học sinh 13 - Trương Minh Sơn
(153, 13, 7, 25, 1, N'Miệng', 7.5),
(154, 13, 7, 25, 1, N'15 phút', 7.0),
(155, 13, 7, 25, 1, N'Giữa kỳ', 7.5),
(156, 13, 7, 25, 1, N'Cuối kỳ', 7.0),

-- Học sinh 14 - Mai Thị Thảo
(157, 14, 7, 25, 1, N'Miệng', 9.0),
(158, 14, 7, 25, 1, N'15 phút', 8.5),
(159, 14, 7, 25, 1, N'Giữa kỳ', 9.0),
(160, 14, 7, 25, 1, N'Cuối kỳ', 8.5);

-- Thêm điểm môn Vật lý (MaMon = 2) cho lớp 10A2, Giáo viên có MaGV = 12
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 16 - Lương Thị Ánh
(161, 16, 2, 12, 1, N'Miệng', 8.0),
(162, 16, 2, 12, 1, N'15 phút', 8.5),
(163, 16, 2, 12, 1, N'Giữa kỳ', 8.0),
(164, 16, 2, 12, 1, N'Cuối kỳ', 8.5),

-- Học sinh 17 - Đỗ Văn Bằng
(165, 17, 2, 12, 1, N'Miệng', 7.5),
(166, 17, 2, 12, 1, N'15 phút', 7.0),
(167, 17, 2, 12, 1, N'Giữa kỳ', 7.5),
(168, 17, 2, 12, 1, N'Cuối kỳ', 7.0),

-- Học sinh 18 - Nguyễn Thị Châu
(169, 18, 2, 12, 1, N'Miệng', 9.0),
(170, 18, 2, 12, 1, N'15 phút', 9.5),
(171, 18, 2, 12, 1, N'Giữa kỳ', 9.0),
(172, 18, 2, 12, 1, N'Cuối kỳ', 9.5);

-- Thêm điểm môn Tiếng Anh (MaMon = 8) cho lớp 10A2, Giáo viên có MaGV = 28
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 21 - Phạm Văn Khoa
(173, 21, 8, 28, 1, N'Miệng', 8.5),
(174, 21, 8, 28, 1, N'15 phút', 8.0),
(175, 21, 8, 28, 1, N'Giữa kỳ', 8.5),
(176, 21, 8, 28, 1, N'Cuối kỳ', 8.0),

-- Học sinh 22 - Lê Thị Mai
(177, 22, 8, 28, 1, N'Miệng', 9.0),
(178, 22, 8, 28, 1, N'15 phút', 9.5),
(179, 22, 8, 28, 1, N'Giữa kỳ', 9.0),
(180, 22, 8, 28, 1, N'Cuối kỳ', 9.5),

-- Học sinh 23 - Vũ Văn Nam
(181, 23, 8, 28, 1, N'Miệng', 7.0),
(182, 23, 8, 28, 1, N'15 phút', 7.5),
(183, 23, 8, 28, 1, N'Giữa kỳ', 7.0),
(184, 23, 8, 28, 1, N'Cuối kỳ', 7.5);

-- Thêm điểm môn Hóa học (MaMon = 3) cho lớp 10A2, Giáo viên có MaGV = 15
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 24 - Đinh Thị Oanh
(185, 24, 3, 15, 1, N'Miệng', 8.0),
(186, 24, 3, 15, 1, N'15 phút', 8.5),
(187, 24, 3, 15, 1, N'Giữa kỳ', 8.0),
(188, 24, 3, 15, 1, N'Cuối kỳ', 8.5),

-- Học sinh 25 - Nguyễn Văn Phương
(189, 25, 3, 15, 1, N'Miệng', 7.5),
(190, 25, 3, 15, 1, N'15 phút', 7.0),
(191, 25, 3, 15, 1, N'Giữa kỳ', 7.5),
(192, 25, 3, 15, 1, N'Cuối kỳ', 7.0),

-- Học sinh 26 - Trần Thị Quỳnh
(193, 26, 3, 15, 1, N'Miệng', 9.0),
(194, 26, 3, 15, 1, N'15 phút', 9.5),
(195, 26, 3, 15, 1, N'Giữa kỳ', 9.0),
(196, 26, 3, 15, 1, N'Cuối kỳ', 9.5);

-- Thêm điểm môn Ngữ văn (MaMon = 5) cho lớp 10A2, Giáo viên có MaGV = 21
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 27 - Lý Văn Sơn
(197, 27, 5, 21, 1, N'Miệng', 7.0),
(198, 27, 5, 21, 1, N'15 phút', 7.5),
(199, 27, 5, 21, 1, N'Giữa kỳ', 7.0),
(200, 27, 5, 21, 1, N'Cuối kỳ', 7.5),

-- Học sinh 28 - Phan Thị Thu
(201, 28, 5, 21, 1, N'Miệng', 8.5),
(202, 28, 5, 21, 1, N'15 phút', 8.0),
(203, 28, 5, 21, 1, N'Giữa kỳ', 8.5),
(204, 28, 5, 21, 1, N'Cuối kỳ', 8.0),

-- Học sinh 29 - Hoàng Văn Vân
(205, 29, 5, 21, 1, N'Miệng', 6.5),
(206, 29, 5, 21, 1, N'15 phút', 7.0),
(207, 29, 5, 21, 1, N'Giữa kỳ', 6.5),
(208, 29, 5, 21, 1, N'Cuối kỳ', 7.0);
