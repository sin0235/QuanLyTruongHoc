USE QuanLyTruongHoc;
GO

-- Thêm tài khoản người dùng cho học sinh khối 12 (tiếp)
INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro, NgayTao) VALUES
-- Lớp 12A3 (15 học sinh)
(251, 'hocsinh12A3_01', 'password123', 4, '2023-08-15'),
(252, 'hocsinh12A3_02', 'password123', 4, '2023-08-15'),
(253, 'hocsinh12A3_03', 'password123', 4, '2023-08-15'),
(254, 'hocsinh12A3_04', 'password123', 4, '2023-08-15'),
(255, 'hocsinh12A3_05', 'password123', 4, '2023-08-15'),
(256, 'hocsinh12A3_06', 'password123', 4, '2023-08-15'),
(257, 'hocsinh12A3_07', 'password123', 4, '2023-08-15'),
(258, 'hocsinh12A3_08', 'password123', 4, '2023-08-15'),
(259, 'hocsinh12A3_09', 'password123', 4, '2023-08-15'),
(260, 'hocsinh12A3_10', 'password123', 4, '2023-08-15'),
(261, 'hocsinh12A3_11', 'password123', 4, '2023-08-15'),
(262, 'hocsinh12A3_12', 'password123', 4, '2023-08-15'),
(263, 'hocsinh12A3_13', 'password123', 4, '2023-08-15'),
(264, 'hocsinh12A3_14', 'password123', 4, '2023-08-15'),
(265, 'hocsinh12A3_15', 'password123', 4, '2023-08-15'),

-- Lớp 12A4 (15 học sinh)
(266, 'hocsinh12A4_01', 'password123', 4, '2023-08-15'),
(267, 'hocsinh12A4_02', 'password123', 4, '2023-08-15'),
(268, 'hocsinh12A4_03', 'password123', 4, '2023-08-15'),
(269, 'hocsinh12A4_04', 'password123', 4, '2023-08-15'),
(270, 'hocsinh12A4_05', 'password123', 4, '2023-08-15'),
(271, 'hocsinh12A4_06', 'password123', 4, '2023-08-15'),
(272, 'hocsinh12A4_07', 'password123', 4, '2023-08-15'),
(273, 'hocsinh12A4_08', 'password123', 4, '2023-08-15'),
(274, 'hocsinh12A4_09', 'password123', 4, '2023-08-15'),
(275, 'hocsinh12A4_10', 'password123', 4, '2023-08-15'),
(276, 'hocsinh12A4_11', 'password123', 4, '2023-08-15'),
(277, 'hocsinh12A4_12', 'password123', 4, '2023-08-15'),
(278, 'hocsinh12A4_13', 'password123', 4, '2023-08-15'),
(279, 'hocsinh12A4_14', 'password123', 4, '2023-08-15'),
(280, 'hocsinh12A4_15', 'password123', 4, '2023-08-15');

-- Lớp 12A3
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, SDT, MaLop, MaDinhDanh, NoiSinh, DanToc, TonGiao, QuocGia, TinhThanh, QuanHuyen, XaPhuong, DiaChiThuongTru, SoDienThoai, Email) VALUES
(151, 251, N'Tạ Văn Bảo', '2005-05-15', N'Nam', '0912345686', 11, '079205001294', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 1', N'Phường Bến Nghé', N'15 Đường Lê Lai, Quận 1, TP.HCM', '0912345687', 'tabao@gmail.com'),
(152, 252, N'Lê Thị Cẩm', '2005-08-25', N'Nữ', '0823456797', 11, '079205001295', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 3', N'Phường 1', N'25 Đường Nguyễn Thiện Thuật, Quận 3, TP.HCM', '0823456798', 'lecam@gmail.com'),
(153, 253, N'Trần Đức Duy', '2005-01-30', N'Nam', '0934567924', 11, '079205001296', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 5', N'Phường 5', N'48 Đường Hùng Vương, Quận 5, TP.HCM', '0934567925', 'tranduy@gmail.com'),
(154, 254, N'Nguyễn Thị Giang', '2005-07-12', N'Nữ', '0845678935', 11, '079205001297', N'TP.HCM', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 10', N'Phường 8', N'72 Đường Nguyễn Chí Thanh, Quận 10, TP.HCM', '0845678936', 'nguyengiang@gmail.com'),
(155, 255, N'Lý Hoàng Hải', '2005-04-25', N'Nam', '0956789046', 11, '079205001298', N'Hà Nội', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Tân Bình', N'Phường 2', N'24 Đường Cộng Hòa, Quận Tân Bình, TP.HCM', '0956789047', 'lyhai@gmail.com'),
(156, 256, N'Phạm Thị Hương', '2005-11-02', N'Nữ', '0867890142', 11, '079205001299', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận Phú Nhuận', N'Phường 9', N'36 Đường Phan Xích Long, Quận Phú Nhuận, TP.HCM', '0867890143', 'phamhuong@gmail.com'),
(157, 257, N'Đỗ Quang Khải', '2005-02-18', N'Nam', '0978901253', 11, '079205001300', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 7', N'Phường Tân Thuận Đông', N'83 Đường Nguyễn Thị Thập, Quận 7, TP.HCM', '0978901254', 'dokhai@gmail.com'),
(158, 258, N'Hoàng Thị Lan', '2005-09-20', N'Nữ', '0889012364', 11, '079205001301', N'Đồng Nai', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 2', N'Phường An Phú', N'46 Đường Trần Não, Quận 2, TP.HCM', '0889012365', 'hoanglan@gmail.com'),
(159, 259, N'Vũ Minh Mạnh', '2005-06-10', N'Nam', '0990123475', 11, '079205001302', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 9', N'Phường Phú Hữu', N'58 Đường Lê Văn Việt, Quận 9, TP.HCM', '0990123476', 'vumanh@gmail.com'),
(160, 260, N'Đinh Thị Ngọc', '2005-03-28', N'Nữ', '0901234586', 11, '079205001303', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 8', N'Phường 1', N'70 Đường Phạm Hùng, Quận 8, TP.HCM', '0901234587', 'dinhngoc@gmail.com'),
(161, 261, N'Nguyễn Văn Phúc', '2005-10-15', N'Nam', '0812345697', 11, '079205001304', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Bình Thạnh', N'Phường 11', N'35 Đường Xô Viết Nghệ Tĩnh, Quận Bình Thạnh, TP.HCM', '0812345698', 'nguyenphuc@gmail.com'),
(162, 262, N'Phan Thị Quỳnh', '2005-07-22', N'Nữ', '0723456798', 11, '079205001305', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 4', N'Phường 3', N'57 Đường Hoàng Diệu, Quận 4, TP.HCM', '0723456799', 'phanquynh@gmail.com'),
(163, 263, N'Hoàng Minh Sơn', '2005-04-05', N'Nam', '0934567926', 11, '079205001306', N'Vũng Tàu', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 6', N'Phường 8', N'24 Đường Hậu Giang, Quận 6, TP.HCM', '0934567927', 'hoangson@gmail.com'),
(164, 264, N'Vũ Thị Thu', '2005-12-18', N'Nữ', '0845678937', 11, '079205001307', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 11', N'Phường 5', N'68 Đường Lạc Long Quân, Quận 11, TP.HCM', '0845678938', 'vuthu@gmail.com'),
(165, 265, N'Lê Văn Trung', '2005-08-30', N'Nam', '0956789048', 11, '079205001308', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 12', N'Phường Tân Thới Nhất', N'35 Đường Lê Văn Khương, Quận 12, TP.HCM', '0956789049', 'letrung@gmail.com');

-- Lớp 12A4
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, SDT, MaLop, MaDinhDanh, NoiSinh, DanToc, TonGiao, QuocGia, TinhThanh, QuanHuyen, XaPhuong, DiaChiThuongTru, SoDienThoai, Email) VALUES
(166, 266, N'Trần Thị Ánh', '2005-03-15', N'Nữ', '0912345688', 12, '079205001309', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 1', N'Phường Bến Nghé', N'20 Đường Nguyễn Trãi, Quận 1, TP.HCM', '0912345689', 'trananh@gmail.com'),
(167, 267, N'Nguyễn Văn Bảo', '2005-07-22', N'Nam', '0823456799', 12, '079205001310', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 3', N'Phường 1', N'45 Đường Lê Văn Sỹ, Quận 3, TP.HCM', '0823456800', 'nguyenbao@gmail.com'),
(168, 268, N'Lê Thị Cúc', '2005-01-10', N'Nữ', '0934567928', 12, '079205001311', N'Đồng Nai', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 5', N'Phường 5', N'78 Đường Trần Hưng Đạo, Quận 5, TP.HCM', '0934567929', 'lecuc@gmail.com'),
(169, 269, N'Phạm Đình Duy', '2005-09-08', N'Nam', '0845678939', 12, '079205001312', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 10', N'Phường 8', N'102 Đường 3/2, Quận 10, TP.HCM', '0845678940', 'phamduy@gmail.com'),
(170, 270, N'Trịnh Thị Hà', '2005-05-29', N'Nữ', '0956789050', 12, '079205001313', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận Tân Bình', N'Phường 2', N'24 Đường Cộng Hòa, Quận Tân Bình, TP.HCM', '0956789051', 'trinhha@gmail.com'),
(171, 271, N'Vũ Quốc Huy', '2005-11-14', N'Nam', '0867890144', 12, '079205001314', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Phú Nhuận', N'Phường 9', N'46 Đường Phan Xích Long, Quận Phú Nhuận, TP.HCM', '0867890145', 'vuhuy@gmail.com'),
(172, 272, N'Ngô Thị Khánh', '2005-08-05', N'Nữ', '0978901255', 12, '079205001315', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 7', N'Phường Tân Thuận Đông', N'113 Đường Nguyễn Thị Thập, Quận 7, TP.HCM', '0978901256', 'ngokhanh@gmail.com'),
(173, 273, N'Đinh Thành Long', '2005-04-25', N'Nam', '0889012366', 12, '079205001316', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 2', N'Phường An Phú', N'46 Đường Trần Não, Quận 2, TP.HCM', '0889012367', 'dinhlong@gmail.com'),
(174, 274, N'Bùi Thị Mai', '2005-02-18', N'Nữ', '0990123477', 12, '079205001317', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 9', N'Phường Phú Hữu', N'68 Đường Lê Văn Việt, Quận 9, TP.HCM', '0990123478', 'buimai@gmail.com'),
(175, 275, N'Trương Văn Nam', '2005-10-30', N'Nam', '0901234588', 12, '079205001318', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 8', N'Phường 1', N'80 Đường Phạm Hùng, Quận 8, TP.HCM', '0901234589', 'truongnam@gmail.com'),
(176, 276, N'Hoàng Thị Phương', '2005-07-19', N'Nữ', '0812345699', 12, '079205001319', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Bình Thạnh', N'Phường 11', N'35 Đường Xô Viết Nghệ Tĩnh, Quận Bình Thạnh, TP.HCM', '0812345700', 'hoangphuong@gmail.com'),
(177, 277, N'Lý Thanh Quân', '2005-03-08', N'Nam', '0723456800', 12, '079205001320', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 4', N'Phường 3', N'57 Đường Hoàng Diệu, Quận 4, TP.HCM', '0723456801', 'lyquan@gmail.com'),
(178, 278, N'Đỗ Thị Thanh', '2005-12-12', N'Nữ', '0934567930', 12, '079205001321', N'Vũng Tàu', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 6', N'Phường 8', N'24 Đường Bình Phú, Quận 6, TP.HCM', '0934567931', 'dothanh@gmail.com'),
(179, 279, N'Nguyễn Minh Tuấn', '2005-06-25', N'Nam', '0845678941', 12, '079205001322', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 11', N'Phường 5', N'68 Đường Âu Cơ, Quận 11, TP.HCM', '0845678942', 'nguyentuan@gmail.com'),
(180, 280, N'Trần Thị Vân', '2005-09-16', N'Nữ', '0956789052', 12, '079205001323', N'TP.HCM', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 12', N'Phường Tân Thới Nhất', N'35 Đường Trường Chinh, Quận 12, TP.HCM', '0956789053', 'tranvan@gmail.com'); 