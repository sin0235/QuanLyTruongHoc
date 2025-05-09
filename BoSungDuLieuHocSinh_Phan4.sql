USE QuanLyTruongHoc;
GO

-- Thêm tài khoản người dùng cho học sinh khối 12
INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro, NgayTao) VALUES
-- Lớp 12A1 (15 học sinh)
(221, 'hocsinh12A1_01', 'password123', 4, '2023-08-15'),
(222, 'hocsinh12A1_02', 'password123', 4, '2023-08-15'),
(223, 'hocsinh12A1_03', 'password123', 4, '2023-08-15'),
(224, 'hocsinh12A1_04', 'password123', 4, '2023-08-15'),
(225, 'hocsinh12A1_05', 'password123', 4, '2023-08-15'),
(226, 'hocsinh12A1_06', 'password123', 4, '2023-08-15'),
(227, 'hocsinh12A1_07', 'password123', 4, '2023-08-15'),
(228, 'hocsinh12A1_08', 'password123', 4, '2023-08-15'),
(229, 'hocsinh12A1_09', 'password123', 4, '2023-08-15'),
(230, 'hocsinh12A1_10', 'password123', 4, '2023-08-15'),
(231, 'hocsinh12A1_11', 'password123', 4, '2023-08-15'),
(232, 'hocsinh12A1_12', 'password123', 4, '2023-08-15'),
(233, 'hocsinh12A1_13', 'password123', 4, '2023-08-15'),
(234, 'hocsinh12A1_14', 'password123', 4, '2023-08-15'),
(235, 'hocsinh12A1_15', 'password123', 4, '2023-08-15'),

-- Lớp 12A2 (15 học sinh)
(236, 'hocsinh12A2_01', 'password123', 4, '2023-08-15'),
(237, 'hocsinh12A2_02', 'password123', 4, '2023-08-15'),
(238, 'hocsinh12A2_03', 'password123', 4, '2023-08-15'),
(239, 'hocsinh12A2_04', 'password123', 4, '2023-08-15'),
(240, 'hocsinh12A2_05', 'password123', 4, '2023-08-15'),
(241, 'hocsinh12A2_06', 'password123', 4, '2023-08-15'),
(242, 'hocsinh12A2_07', 'password123', 4, '2023-08-15'),
(243, 'hocsinh12A2_08', 'password123', 4, '2023-08-15'),
(244, 'hocsinh12A2_09', 'password123', 4, '2023-08-15'),
(245, 'hocsinh12A2_10', 'password123', 4, '2023-08-15'),
(246, 'hocsinh12A2_11', 'password123', 4, '2023-08-15'),
(247, 'hocsinh12A2_12', 'password123', 4, '2023-08-15'),
(248, 'hocsinh12A2_13', 'password123', 4, '2023-08-15'),
(249, 'hocsinh12A2_14', 'password123', 4, '2023-08-15'),
(250, 'hocsinh12A2_15', 'password123', 4, '2023-08-15');

-- Lớp 12A1
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, SDT, MaLop, MaDinhDanh, NoiSinh, DanToc, TonGiao, QuocGia, TinhThanh, QuanHuyen, XaPhuong, DiaChiThuongTru, SoDienThoai, Email) VALUES
(121, 221, N'Nguyễn Văn An', '2005-03-12', N'Nam', '0912345682', 9, '079205001264', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 1', N'Phường Bến Nghé', N'15 Đường Lê Lợi, Quận 1, TP.HCM', '0912345683', 'nguyenan@gmail.com'),
(122, 222, N'Trần Thị Bình', '2005-07-25', N'Nữ', '0823456793', 9, '079205001265', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 3', N'Phường 1', N'25 Đường Võ Văn Tần, Quận 3, TP.HCM', '0823456794', 'tranbinh@gmail.com'),
(123, 223, N'Lê Minh Cường', '2005-01-18', N'Nam', '0934567916', 9, '079205001266', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 5', N'Phường 5', N'48 Đường Nguyễn Trãi, Quận 5, TP.HCM', '0934567917', 'lecuong@gmail.com'),
(124, 224, N'Phạm Thị Dung', '2005-09-30', N'Nữ', '0845678927', 9, '079205001267', N'TP.HCM', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 10', N'Phường 8', N'72 Đường Cách Mạng Tháng 8, Quận 10, TP.HCM', '0845678928', 'phamdung@gmail.com'),
(125, 225, N'Hoàng Đức Em', '2005-05-15', N'Nam', '0956789038', 9, '079205001268', N'Hà Nội', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Tân Bình', N'Phường 2', N'24 Đường Trường Sơn, Quận Tân Bình, TP.HCM', '0956789039', 'hoangem@gmail.com'),
(126, 226, N'Vũ Thị Hoa', '2005-11-08', N'Nữ', '0867890138', 9, '079205001269', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận Phú Nhuận', N'Phường 9', N'36 Đường Huỳnh Văn Bánh, Quận Phú Nhuận, TP.HCM', '0867890139', 'vuhoa@gmail.com'),
(127, 227, N'Đặng Minh Hiếu', '2005-04-20', N'Nam', '0978901249', 9, '079205001270', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 7', N'Phường Tân Thuận Đông', N'83 Đường Nguyễn Văn Linh, Quận 7, TP.HCM', '0978901250', 'danghieu@gmail.com'),
(128, 228, N'Ngô Thị Lan', '2005-08-12', N'Nữ', '0889012360', 9, '079205001271', N'Đồng Nai', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 2', N'Phường An Phú', N'46 Đường Xa Lộ Hà Nội, Quận 2, TP.HCM', '0889012361', 'ngolan@gmail.com'),
(129, 229, N'Phan Văn Minh', '2005-02-28', N'Nam', '0990123471', 9, '079205001272', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 9', N'Phường Phú Hữu', N'58 Đường Lê Văn Việt, Quận 9, TP.HCM', '0990123472', 'phanminh@gmail.com'),
(130, 230, N'Bùi Thị Nga', '2005-10-05', N'Nữ', '0901234582', 9, '079205001273', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 8', N'Phường 1', N'70 Đường Âu Cơ, Quận 8, TP.HCM', '0901234583', 'buinga@gmail.com'),
(131, 231, N'Lý Văn Phong', '2005-06-15', N'Nam', '0812345693', 9, '079205001274', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Bình Thạnh', N'Phường 11', N'35 Đường Điện Biên Phủ, Quận Bình Thạnh, TP.HCM', '0812345694', 'lyphong@gmail.com'),
(132, 232, N'Võ Thị Quỳnh', '2005-03-22', N'Nữ', '0723456794', 9, '079205001275', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 4', N'Phường 3', N'57 Đường Khánh Hội, Quận 4, TP.HCM', '0723456795', 'voquynh@gmail.com'),
(133, 233, N'Trương Minh Sơn', '2005-12-10', N'Nam', '0934567918', 9, '079205001276', N'Vũng Tàu', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 6', N'Phường 8', N'24 Đường An Dương Vương, Quận 6, TP.HCM', '0934567919', 'truongson@gmail.com'),
(134, 234, N'Mai Thị Thủy', '2005-09-18', N'Nữ', '0845678929', 9, '079205001277', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 11', N'Phường 5', N'68 Đường Lý Thường Kiệt, Quận 11, TP.HCM', '0845678930', 'maithuy@gmail.com'),
(135, 235, N'Dương Văn Uy', '2005-05-28', N'Nam', '0956789040', 9, '079205001278', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 12', N'Phường Tân Thới Nhất', N'35 Đường Trường Chinh, Quận 12, TP.HCM', '0956789041', 'duonguy@gmail.com');

-- Lớp 12A2
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, SDT, MaLop, MaDinhDanh, NoiSinh, DanToc, TonGiao, QuocGia, TinhThanh, QuanHuyen, XaPhuong, DiaChiThuongTru, SoDienThoai, Email) VALUES
(136, 236, N'Lương Thị Ánh', '2005-04-15', N'Nữ', '0912345684', 10, '079205001279', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 1', N'Phường Bến Nghé', N'20 Đường Nguyễn Huệ, Quận 1, TP.HCM', '0912345685', 'luonganh@gmail.com'),
(137, 237, N'Đỗ Văn Bình', '2005-08-22', N'Nam', '0823456795', 10, '079205001280', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 3', N'Phường 1', N'45 Đường Cao Thắng, Quận 3, TP.HCM', '0823456796', 'dobinh@gmail.com'),
(138, 238, N'Nguyễn Thị Châu', '2005-01-30', N'Nữ', '0934567920', 10, '079205001281', N'Đồng Nai', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 5', N'Phường 5', N'78 Đường Trần Phú, Quận 5, TP.HCM', '0934567921', 'nguyenchau@gmail.com'),
(139, 239, N'Hoàng Văn Đạt', '2005-06-12', N'Nam', '0845678931', 10, '079205001282', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 10', N'Phường 8', N'102 Đường Lý Thường Kiệt, Quận 10, TP.HCM', '0845678932', 'hoangdat@gmail.com'),
(140, 240, N'Trần Thị Hà', '2005-11-25', N'Nữ', '0956789042', 10, '079205001283', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận Tân Bình', N'Phường 2', N'24 Đường Hoàng Văn Thụ, Quận Tân Bình, TP.HCM', '0956789043', 'tranha@gmail.com'),
(141, 241, N'Phạm Văn Hùng', '2005-03-08', N'Nam', '0867890140', 10, '079205001284', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Phú Nhuận', N'Phường 9', N'46 Đường Phan Đình Phùng, Quận Phú Nhuận, TP.HCM', '0867890141', 'phamhung@gmail.com'),
(142, 242, N'Lê Thị Khánh', '2005-07-18', N'Nữ', '0978901251', 10, '079205001285', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 7', N'Phường Tân Thuận Đông', N'113 Đường Huỳnh Tấn Phát, Quận 7, TP.HCM', '0978901252', 'lekhanh@gmail.com'),
(143, 243, N'Vũ Văn Linh', '2005-02-25', N'Nam', '0889012362', 10, '079205001286', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 2', N'Phường An Phú', N'46 Đường Mai Chí Thọ, Quận 2, TP.HCM', '0889012363', 'vulinh@gmail.com'),
(144, 244, N'Đinh Thị Mai', '2005-10-12', N'Nữ', '0990123473', 10, '079205001287', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 9', N'Phường Phú Hữu', N'68 Đường Đỗ Xuân Hợp, Quận 9, TP.HCM', '0990123474', 'dinhmai@gmail.com'),
(145, 245, N'Nguyễn Văn Nam', '2005-04-30', N'Nam', '0901234584', 10, '079205001288', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 8', N'Phường 1', N'80 Đường Dương Bá Trạc, Quận 8, TP.HCM', '0901234585', 'nguyennam@gmail.com'),
(146, 246, N'Trần Thị Oanh', '2005-09-05', N'Nữ', '0812345695', 10, '079205001289', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Bình Thạnh', N'Phường 11', N'35 Đường Bùi Đình Túy, Quận Bình Thạnh, TP.HCM', '0812345696', 'tranoanh@gmail.com'),
(147, 247, N'Lý Văn Phúc', '2005-01-18', N'Nam', '0723456796', 10, '079205001290', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 4', N'Phường 3', N'57 Đường Tôn Đản, Quận 4, TP.HCM', '0723456797', 'lyphuc@gmail.com'),
(148, 248, N'Phan Thị Quế', '2005-05-28', N'Nữ', '0934567922', 10, '079205001291', N'Vũng Tàu', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 6', N'Phường 8', N'24 Đường Hậu Giang, Quận 6, TP.HCM', '0934567923', 'phanque@gmail.com'),
(149, 249, N'Hoàng Minh Sơn', '2005-12-15', N'Nam', '0845678933', 10, '079205001292', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 11', N'Phường 5', N'68 Đường Âu Cơ, Quận 11, TP.HCM', '0845678934', 'hoangson@gmail.com'),
(150, 250, N'Vũ Thị Thủy', '2005-08-02', N'Nữ', '0956789044', 10, '079205001293', N'TP.HCM', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 12', N'Phường Tân Thới Nhất', N'35 Đường Phan Văn Hớn, Quận 12, TP.HCM', '0956789045', 'vuthuy@gmail.com'); 