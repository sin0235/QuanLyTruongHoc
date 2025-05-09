USE QuanLyTruongHoc;
GO

-- Thêm tài khoản người dùng cho học sinh khối 11
INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro, NgayTao) VALUES
-- Lớp 11A1 (15 học sinh)
(161, 'hocsinh11A1_01', 'password123', 4, '2023-08-15'),
(162, 'hocsinh11A1_02', 'password123', 4, '2023-08-15'),
(163, 'hocsinh11A1_03', 'password123', 4, '2023-08-15'),
(164, 'hocsinh11A1_04', 'password123', 4, '2023-08-15'),
(165, 'hocsinh11A1_05', 'password123', 4, '2023-08-15'),
(166, 'hocsinh11A1_06', 'password123', 4, '2023-08-15'),
(167, 'hocsinh11A1_07', 'password123', 4, '2023-08-15'),
(168, 'hocsinh11A1_08', 'password123', 4, '2023-08-15'),
(169, 'hocsinh11A1_09', 'password123', 4, '2023-08-15'),
(170, 'hocsinh11A1_10', 'password123', 4, '2023-08-15'),
(171, 'hocsinh11A1_11', 'password123', 4, '2023-08-15'),
(172, 'hocsinh11A1_12', 'password123', 4, '2023-08-15'),
(173, 'hocsinh11A1_13', 'password123', 4, '2023-08-15'),
(174, 'hocsinh11A1_14', 'password123', 4, '2023-08-15'),
(175, 'hocsinh11A1_15', 'password123', 4, '2023-08-15'),

-- Lớp 11A2 (15 học sinh)
(176, 'hocsinh11A2_01', 'password123', 4, '2023-08-15'),
(177, 'hocsinh11A2_02', 'password123', 4, '2023-08-15'),
(178, 'hocsinh11A2_03', 'password123', 4, '2023-08-15'),
(179, 'hocsinh11A2_04', 'password123', 4, '2023-08-15'),
(180, 'hocsinh11A2_05', 'password123', 4, '2023-08-15'),
(181, 'hocsinh11A2_06', 'password123', 4, '2023-08-15'),
(182, 'hocsinh11A2_07', 'password123', 4, '2023-08-15'),
(183, 'hocsinh11A2_08', 'password123', 4, '2023-08-15'),
(184, 'hocsinh11A2_09', 'password123', 4, '2023-08-15'),
(185, 'hocsinh11A2_10', 'password123', 4, '2023-08-15'),
(186, 'hocsinh11A2_11', 'password123', 4, '2023-08-15'),
(187, 'hocsinh11A2_12', 'password123', 4, '2023-08-15'),
(188, 'hocsinh11A2_13', 'password123', 4, '2023-08-15'),
(189, 'hocsinh11A2_14', 'password123', 4, '2023-08-15'),
(190, 'hocsinh11A2_15', 'password123', 4, '2023-08-15');

-- Lớp 11A1
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, SDT, MaLop, MaDinhDanh, NoiSinh, DanToc, TonGiao, QuocGia, TinhThanh, QuanHuyen, XaPhuong, DiaChiThuongTru, SoDienThoai, Email) VALUES
(61, 161, N'Nguyễn Văn Anh', '2006-03-12', N'Nam', '0912345674', 5, '079206001264', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 1', N'Phường Bến Nghé', N'15 Đường Nam Kỳ Khởi Nghĩa, Quận 1, TP.HCM', '0912345675', 'nguyenanh@gmail.com'),
(62, 162, N'Trần Thị Bảo', '2006-07-25', N'Nữ', '0823456785', 5, '079206001265', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 3', N'Phường 1', N'25 Đường Võ Thị Sáu, Quận 3, TP.HCM', '0823456786', 'tranbao@gmail.com'),
(63, 163, N'Lê Minh Cường', '2006-01-18', N'Nam', '0934567900', 5, '079206001266', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 5', N'Phường 5', N'48 Đường Nguyễn Trãi, Quận 5, TP.HCM', '0934567901', 'lecuong@gmail.com'),
(64, 164, N'Phạm Thị Diệp', '2006-09-30', N'Nữ', '0845678911', 5, '079206001267', N'TP.HCM', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 10', N'Phường 8', N'72 Đường Cách Mạng Tháng 8, Quận 10, TP.HCM', '0845678912', 'phamdiep@gmail.com'),
(65, 165, N'Hoàng Đức Dũng', '2006-05-15', N'Nam', '0956789022', 5, '079206001268', N'Hà Nội', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Tân Bình', N'Phường 2', N'24 Đường Trường Sơn, Quận Tân Bình, TP.HCM', '0956789023', 'hoangdung@gmail.com'),
(66, 166, N'Vũ Thị Hà', '2006-11-08', N'Nữ', '0867890130', 5, '079206001269', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận Phú Nhuận', N'Phường 9', N'36 Đường Huỳnh Văn Bánh, Quận Phú Nhuận, TP.HCM', '0867890131', 'vuha@gmail.com'),
(67, 167, N'Đặng Minh Hiếu', '2006-04-20', N'Nam', '0978901241', 5, '079206001270', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 7', N'Phường Tân Thuận Đông', N'83 Đường Nguyễn Văn Linh, Quận 7, TP.HCM', '0978901242', 'danghieu@gmail.com'),
(68, 168, N'Ngô Thị Lan', '2006-08-12', N'Nữ', '0889012352', 5, '079206001271', N'Đồng Nai', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 2', N'Phường An Phú', N'46 Đường Xa Lộ Hà Nội, Quận 2, TP.HCM', '0889012353', 'ngolan@gmail.com'),
(69, 169, N'Phan Văn Minh', '2006-02-28', N'Nam', '0990123463', 5, '079206001272', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 9', N'Phường Phú Hữu', N'58 Đường Lê Văn Việt, Quận 9, TP.HCM', '0990123464', 'phanminh@gmail.com'),
(70, 170, N'Bùi Thị Ngọc', '2006-10-05', N'Nữ', '0901234574', 5, '079206001273', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 8', N'Phường 1', N'70 Đường Âu Cơ, Quận 8, TP.HCM', '0901234575', 'buingoc@gmail.com'),
(71, 171, N'Lý Đức Phong', '2006-06-15', N'Nam', '0812345685', 5, '079206001274', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Bình Thạnh', N'Phường 11', N'35 Đường Điện Biên Phủ, Quận Bình Thạnh, TP.HCM', '0812345686', 'lyphong@gmail.com'),
(72, 172, N'Võ Thị Quỳnh', '2006-03-22', N'Nữ', '0723456786', 5, '079206001275', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 4', N'Phường 3', N'57 Đường Khánh Hội, Quận 4, TP.HCM', '0723456787', 'voquynh@gmail.com'),
(73, 173, N'Trương Minh Sơn', '2006-12-10', N'Nam', '0934567902', 5, '079206001276', N'Vũng Tàu', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 6', N'Phường 8', N'24 Đường An Dương Vương, Quận 6, TP.HCM', '0934567903', 'truongson@gmail.com'),
(74, 174, N'Mai Thị Thảo', '2006-09-18', N'Nữ', '0845678913', 5, '079206001277', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 11', N'Phường 5', N'68 Đường Lý Thường Kiệt, Quận 11, TP.HCM', '0845678914', 'maithao@gmail.com'),
(75, 175, N'Dương Văn Uy', '2006-05-28', N'Nam', '0956789024', 5, '079206001278', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 12', N'Phường Tân Thới Nhất', N'35 Đường Trường Chinh, Quận 12, TP.HCM', '0956789025', 'duonguy@gmail.com');

-- Lớp 11A2
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, SDT, MaLop, MaDinhDanh, NoiSinh, DanToc, TonGiao, QuocGia, TinhThanh, QuanHuyen, XaPhuong, DiaChiThuongTru, SoDienThoai, Email) VALUES
(76, 176, N'Lương Thị Ánh', '2006-04-15', N'Nữ', '0912345676', 6, '079206001279', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 1', N'Phường Bến Nghé', N'20 Đường Nguyễn Huệ, Quận 1, TP.HCM', '0912345677', 'luonganh@gmail.com'),
(77, 177, N'Đỗ Văn Bình', '2006-08-22', N'Nam', '0823456787', 6, '079206001280', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 3', N'Phường 1', N'45 Đường Cao Thắng, Quận 3, TP.HCM', '0823456788', 'dobinh@gmail.com'),
(78, 178, N'Nguyễn Thị Châu', '2006-01-30', N'Nữ', '0934567904', 6, '079206001281', N'Đồng Nai', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 5', N'Phường 5', N'78 Đường Trần Phú, Quận 5, TP.HCM', '0934567905', 'nguyenchau@gmail.com'),
(79, 179, N'Hoàng Văn Đạt', '2006-06-12', N'Nam', '0845678915', 6, '079206001282', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 10', N'Phường 8', N'102 Đường Lý Thường Kiệt, Quận 10, TP.HCM', '0845678916', 'hoangdat@gmail.com'),
(80, 180, N'Trần Thị Hà', '2006-11-25', N'Nữ', '0956789026', 6, '079206001283', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận Tân Bình', N'Phường 2', N'24 Đường Hoàng Văn Thụ, Quận Tân Bình, TP.HCM', '0956789027', 'tranha@gmail.com'),
(81, 181, N'Phạm Văn Hùng', '2006-03-08', N'Nam', '0867890132', 6, '079206001284', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Phú Nhuận', N'Phường 9', N'46 Đường Phan Đình Phùng, Quận Phú Nhuận, TP.HCM', '0867890133', 'phamhung@gmail.com'),
(82, 182, N'Lê Thị Khánh', '2006-07-18', N'Nữ', '0978901243', 6, '079206001285', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 7', N'Phường Tân Thuận Đông', N'113 Đường Huỳnh Tấn Phát, Quận 7, TP.HCM', '0978901244', 'lekhanh@gmail.com'),
(83, 183, N'Vũ Văn Linh', '2006-02-25', N'Nam', '0889012354', 6, '079206001286', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 2', N'Phường An Phú', N'46 Đường Mai Chí Thọ, Quận 2, TP.HCM', '0889012355', 'vulinh@gmail.com'),
(84, 184, N'Đinh Thị Mai', '2006-10-12', N'Nữ', '0990123465', 6, '079206001287', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 9', N'Phường Phú Hữu', N'68 Đường Đỗ Xuân Hợp, Quận 9, TP.HCM', '0990123466', 'dinhmai@gmail.com'),
(85, 185, N'Nguyễn Văn Nam', '2006-04-30', N'Nam', '0901234576', 6, '079206001288', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 8', N'Phường 1', N'80 Đường Dương Bá Trạc, Quận 8, TP.HCM', '0901234577', 'nguyennam@gmail.com'),
(86, 186, N'Trần Thị Oanh', '2006-09-05', N'Nữ', '0812345687', 6, '079206001289', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Bình Thạnh', N'Phường 11', N'35 Đường Bùi Đình Túy, Quận Bình Thạnh, TP.HCM', '0812345688', 'tranoanh@gmail.com'),
(87, 187, N'Lý Văn Phúc', '2006-01-18', N'Nam', '0723456788', 6, '079206001290', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 4', N'Phường 3', N'57 Đường Tôn Đản, Quận 4, TP.HCM', '0723456789', 'lyphuc@gmail.com'),
(88, 188, N'Phan Thị Quỳnh', '2006-05-28', N'Nữ', '0934567906', 6, '079206001291', N'Vũng Tàu', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 6', N'Phường 8', N'24 Đường Hậu Giang, Quận 6, TP.HCM', '0934567907', 'phanquynh@gmail.com'),
(89, 189, N'Hoàng Minh Sơn', '2006-12-15', N'Nam', '0845678917', 6, '079206001292', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 11', N'Phường 5', N'68 Đường Âu Cơ, Quận 11, TP.HCM', '0845678918', 'hoangson@gmail.com'),
(90, 190, N'Vũ Thị Thảo', '2006-08-02', N'Nữ', '0956789028', 6, '079206001293', N'TP.HCM', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 12', N'Phường Tân Thới Nhất', N'35 Đường Phan Văn Hớn, Quận 12, TP.HCM', '0956789029', 'vuthao@gmail.com'); 