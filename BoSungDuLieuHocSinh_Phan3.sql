USE QuanLyTruongHoc;
GO

-- Thêm tài khoản người dùng cho học sinh khối 11 (tiếp)
INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro, NgayTao) VALUES
-- Lớp 11A3 (15 học sinh)
(191, 'hocsinh11A3_01', 'password123', 4, '2023-08-15'),
(192, 'hocsinh11A3_02', 'password123', 4, '2023-08-15'),
(193, 'hocsinh11A3_03', 'password123', 4, '2023-08-15'),
(194, 'hocsinh11A3_04', 'password123', 4, '2023-08-15'),
(195, 'hocsinh11A3_05', 'password123', 4, '2023-08-15'),
(196, 'hocsinh11A3_06', 'password123', 4, '2023-08-15'),
(197, 'hocsinh11A3_07', 'password123', 4, '2023-08-15'),
(198, 'hocsinh11A3_08', 'password123', 4, '2023-08-15'),
(199, 'hocsinh11A3_09', 'password123', 4, '2023-08-15'),
(200, 'hocsinh11A3_10', 'password123', 4, '2023-08-15'),
(201, 'hocsinh11A3_11', 'password123', 4, '2023-08-15'),
(202, 'hocsinh11A3_12', 'password123', 4, '2023-08-15'),
(203, 'hocsinh11A3_13', 'password123', 4, '2023-08-15'),
(204, 'hocsinh11A3_14', 'password123', 4, '2023-08-15'),
(205, 'hocsinh11A3_15', 'password123', 4, '2023-08-15'),

-- Lớp 11A4 (15 học sinh)
(206, 'hocsinh11A4_01', 'password123', 4, '2023-08-15'),
(207, 'hocsinh11A4_02', 'password123', 4, '2023-08-15'),
(208, 'hocsinh11A4_03', 'password123', 4, '2023-08-15'),
(209, 'hocsinh11A4_04', 'password123', 4, '2023-08-15'),
(210, 'hocsinh11A4_05', 'password123', 4, '2023-08-15'),
(211, 'hocsinh11A4_06', 'password123', 4, '2023-08-15'),
(212, 'hocsinh11A4_07', 'password123', 4, '2023-08-15'),
(213, 'hocsinh11A4_08', 'password123', 4, '2023-08-15'),
(214, 'hocsinh11A4_09', 'password123', 4, '2023-08-15'),
(215, 'hocsinh11A4_10', 'password123', 4, '2023-08-15'),
(216, 'hocsinh11A4_11', 'password123', 4, '2023-08-15'),
(217, 'hocsinh11A4_12', 'password123', 4, '2023-08-15'),
(218, 'hocsinh11A4_13', 'password123', 4, '2023-08-15'),
(219, 'hocsinh11A4_14', 'password123', 4, '2023-08-15'),
(220, 'hocsinh11A4_15', 'password123', 4, '2023-08-15');

-- Lớp 11A3
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, SDT, MaLop, MaDinhDanh, NoiSinh, DanToc, TonGiao, QuocGia, TinhThanh, QuanHuyen, XaPhuong, DiaChiThuongTru, SoDienThoai, Email) VALUES
(91, 191, N'Tạ Văn Bảo', '2006-05-15', N'Nam', '0912345678', 7, '079206001294', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 1', N'Phường Bến Nghé', N'15 Đường Lê Lai, Quận 1, TP.HCM', '0912345679', 'tabao@gmail.com'),
(92, 192, N'Lê Thị Châu', '2006-08-25', N'Nữ', '0823456789', 7, '079206001295', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 3', N'Phường 1', N'25 Đường Nguyễn Thiện Thuật, Quận 3, TP.HCM', '0823456790', 'lechau@gmail.com'),
(93, 193, N'Trần Đức Duy', '2006-01-30', N'Nam', '0934567908', 7, '079206001296', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 5', N'Phường 5', N'48 Đường Hùng Vương, Quận 5, TP.HCM', '0934567909', 'tranduy@gmail.com'),
(94, 194, N'Nguyễn Thị Giang', '2006-07-12', N'Nữ', '0845678919', 7, '079206001297', N'TP.HCM', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 10', N'Phường 8', N'72 Đường Nguyễn Chí Thanh, Quận 10, TP.HCM', '0845678920', 'nguyengiang@gmail.com'),
(95, 195, N'Lý Hoàng Hải', '2006-04-25', N'Nam', '0956789030', 7, '079206001298', N'Hà Nội', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Tân Bình', N'Phường 2', N'24 Đường Cộng Hòa, Quận Tân Bình, TP.HCM', '0956789031', 'lyhai@gmail.com'),
(96, 196, N'Phạm Thị Hương', '2006-11-02', N'Nữ', '0867890134', 7, '079206001299', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận Phú Nhuận', N'Phường 9', N'36 Đường Phan Xích Long, Quận Phú Nhuận, TP.HCM', '0867890135', 'phamhuong@gmail.com'),
(97, 197, N'Đỗ Quang Khải', '2006-02-18', N'Nam', '0978901245', 7, '079206001300', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 7', N'Phường Tân Thuận Đông', N'83 Đường Nguyễn Thị Thập, Quận 7, TP.HCM', '0978901246', 'dokhai@gmail.com'),
(98, 198, N'Hoàng Thị Lan', '2006-09-20', N'Nữ', '0889012356', 7, '079206001301', N'Đồng Nai', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 2', N'Phường An Phú', N'46 Đường Trần Não, Quận 2, TP.HCM', '0889012357', 'hoanglan@gmail.com'),
(99, 199, N'Vũ Minh Mạnh', '2006-06-10', N'Nam', '0990123467', 7, '079206001302', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 9', N'Phường Phú Hữu', N'58 Đường Lê Văn Việt, Quận 9, TP.HCM', '0990123468', 'vumanh@gmail.com'),
(100, 200, N'Đinh Thị Ngọc', '2006-03-28', N'Nữ', '0901234578', 7, '079206001303', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 8', N'Phường 1', N'70 Đường Phạm Hùng, Quận 8, TP.HCM', '0901234579', 'dinhngoc@gmail.com'),
(101, 201, N'Nguyễn Văn Phúc', '2006-10-15', N'Nam', '0812345689', 7, '079206001304', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Bình Thạnh', N'Phường 11', N'35 Đường Xô Viết Nghệ Tĩnh, Quận Bình Thạnh, TP.HCM', '0812345690', 'nguyenphuc@gmail.com'),
(102, 202, N'Phan Thị Quỳnh', '2006-07-22', N'Nữ', '0723456790', 7, '079206001305', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 4', N'Phường 3', N'57 Đường Hoàng Diệu, Quận 4, TP.HCM', '0723456791', 'phanquynh@gmail.com'),
(103, 203, N'Hoàng Minh Sơn', '2006-04-05', N'Nam', '0934567910', 7, '079206001306', N'Vũng Tàu', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 6', N'Phường 8', N'24 Đường Hậu Giang, Quận 6, TP.HCM', '0934567911', 'hoangson@gmail.com'),
(104, 204, N'Vũ Thị Thu', '2006-12-18', N'Nữ', '0845678921', 7, '079206001307', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 11', N'Phường 5', N'68 Đường Lạc Long Quân, Quận 11, TP.HCM', '0845678922', 'vuthu@gmail.com'),
(105, 205, N'Lê Văn Trung', '2006-08-30', N'Nam', '0956789032', 7, '079206001308', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 12', N'Phường Tân Thới Nhất', N'35 Đường Lê Văn Khương, Quận 12, TP.HCM', '0956789033', 'letrung@gmail.com');

-- Lớp 11A4
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, SDT, MaLop, MaDinhDanh, NoiSinh, DanToc, TonGiao, QuocGia, TinhThanh, QuanHuyen, XaPhuong, DiaChiThuongTru, SoDienThoai, Email) VALUES
(106, 206, N'Trần Thị Ánh', '2006-03-15', N'Nữ', '0912345680', 8, '079206001309', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 1', N'Phường Bến Nghé', N'20 Đường Nguyễn Trãi, Quận 1, TP.HCM', '0912345681', 'trananh@gmail.com'),
(107, 207, N'Nguyễn Văn Bảo', '2006-07-22', N'Nam', '0823456791', 8, '079206001310', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 3', N'Phường 1', N'45 Đường Lê Văn Sỹ, Quận 3, TP.HCM', '0823456792', 'nguyenbao@gmail.com'),
(108, 208, N'Lê Thị Cúc', '2006-01-10', N'Nữ', '0934567912', 8, '079206001311', N'Đồng Nai', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 5', N'Phường 5', N'78 Đường Trần Hưng Đạo, Quận 5, TP.HCM', '0934567913', 'lecuc@gmail.com'),
(109, 209, N'Phạm Đình Duy', '2006-09-08', N'Nam', '0845678923', 8, '079206001312', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 10', N'Phường 8', N'102 Đường 3/2, Quận 10, TP.HCM', '0845678924', 'phamduy@gmail.com'),
(110, 210, N'Trịnh Thị Hà', '2006-05-29', N'Nữ', '0956789034', 8, '079206001313', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận Tân Bình', N'Phường 2', N'24 Đường Cộng Hòa, Quận Tân Bình, TP.HCM', '0956789035', 'trinhha@gmail.com'),
(111, 211, N'Vũ Quốc Huy', '2006-11-14', N'Nam', '0867890136', 8, '079206001314', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Phú Nhuận', N'Phường 9', N'46 Đường Phan Xích Long, Quận Phú Nhuận, TP.HCM', '0867890137', 'vuhuy@gmail.com'),
(112, 212, N'Ngô Thị Khánh', '2006-08-05', N'Nữ', '0978901247', 8, '079206001315', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 7', N'Phường Tân Thuận Đông', N'113 Đường Nguyễn Thị Thập, Quận 7, TP.HCM', '0978901248', 'ngokhanh@gmail.com'),
(113, 213, N'Đinh Thành Long', '2006-04-25', N'Nam', '0889012358', 8, '079206001316', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 2', N'Phường An Phú', N'46 Đường Trần Não, Quận 2, TP.HCM', '0889012359', 'dinhlong@gmail.com'),
(114, 214, N'Bùi Thị Mai', '2006-02-18', N'Nữ', '0990123469', 8, '079206001317', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 9', N'Phường Phú Hữu', N'68 Đường Lê Văn Việt, Quận 9, TP.HCM', '0990123470', 'buimai@gmail.com'),
(115, 215, N'Trương Văn Nam', '2006-10-30', N'Nam', '0901234580', 8, '079206001318', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 8', N'Phường 1', N'80 Đường Phạm Hùng, Quận 8, TP.HCM', '0901234581', 'truongnam@gmail.com'),
(116, 216, N'Hoàng Thị Phương', '2006-07-19', N'Nữ', '0812345691', 8, '079206001319', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Bình Thạnh', N'Phường 11', N'35 Đường Xô Viết Nghệ Tĩnh, Quận Bình Thạnh, TP.HCM', '0812345692', 'hoangphuong@gmail.com'),
(117, 217, N'Lý Thanh Quân', '2006-03-08', N'Nam', '0723456792', 8, '079206001320', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 4', N'Phường 3', N'57 Đường Hoàng Diệu, Quận 4, TP.HCM', '0723456793', 'lyquan@gmail.com'),
(118, 218, N'Đỗ Thị Thanh', '2006-12-12', N'Nữ', '0934567914', 8, '079206001321', N'Vũng Tàu', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 6', N'Phường 8', N'24 Đường Bình Phú, Quận 6, TP.HCM', '0934567915', 'dothanh@gmail.com'),
(119, 219, N'Nguyễn Minh Tuấn', '2006-06-25', N'Nam', '0845678925', 8, '079206001322', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 11', N'Phường 5', N'68 Đường Âu Cơ, Quận 11, TP.HCM', '0845678926', 'nguyentuan@gmail.com'),
(120, 220, N'Trần Thị Vân', '2006-09-16', N'Nữ', '0956789036', 8, '079206001323', N'TP.HCM', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 12', N'Phường Tân Thới Nhất', N'35 Đường Trường Chinh, Quận 12, TP.HCM', '0956789037', 'tranvan@gmail.com'); 