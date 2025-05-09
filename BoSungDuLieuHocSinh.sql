USE QuanLyTruongHoc;
GO

-- Thêm tài khoản người dùng cho học sinh các lớp còn lại
INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro, NgayTao) VALUES
-- Lớp 10A3 (15 học sinh)
(131, 'hocsinh10A3_01', 'password123', 4, '2023-08-15'),
(132, 'hocsinh10A3_02', 'password123', 4, '2023-08-15'),
(133, 'hocsinh10A3_03', 'password123', 4, '2023-08-15'),
(134, 'hocsinh10A3_04', 'password123', 4, '2023-08-15'),
(135, 'hocsinh10A3_05', 'password123', 4, '2023-08-15'),
(136, 'hocsinh10A3_06', 'password123', 4, '2023-08-15'),
(137, 'hocsinh10A3_07', 'password123', 4, '2023-08-15'),
(138, 'hocsinh10A3_08', 'password123', 4, '2023-08-15'),
(139, 'hocsinh10A3_09', 'password123', 4, '2023-08-15'),
(140, 'hocsinh10A3_10', 'password123', 4, '2023-08-15'),
(141, 'hocsinh10A3_11', 'password123', 4, '2023-08-15'),
(142, 'hocsinh10A3_12', 'password123', 4, '2023-08-15'),
(143, 'hocsinh10A3_13', 'password123', 4, '2023-08-15'),
(144, 'hocsinh10A3_14', 'password123', 4, '2023-08-15'),
(145, 'hocsinh10A3_15', 'password123', 4, '2023-08-15'),

-- Lớp 10A4 (15 học sinh)
(146, 'hocsinh10A4_01', 'password123', 4, '2023-08-15'),
(147, 'hocsinh10A4_02', 'password123', 4, '2023-08-15'),
(148, 'hocsinh10A4_03', 'password123', 4, '2023-08-15'),
(149, 'hocsinh10A4_04', 'password123', 4, '2023-08-15'),
(150, 'hocsinh10A4_05', 'password123', 4, '2023-08-15'),
(151, 'hocsinh10A4_06', 'password123', 4, '2023-08-15'),
(152, 'hocsinh10A4_07', 'password123', 4, '2023-08-15'),
(153, 'hocsinh10A4_08', 'password123', 4, '2023-08-15'),
(154, 'hocsinh10A4_09', 'password123', 4, '2023-08-15'),
(155, 'hocsinh10A4_10', 'password123', 4, '2023-08-15'),
(156, 'hocsinh10A4_11', 'password123', 4, '2023-08-15'),
(157, 'hocsinh10A4_12', 'password123', 4, '2023-08-15'),
(158, 'hocsinh10A4_13', 'password123', 4, '2023-08-15'),
(159, 'hocsinh10A4_14', 'password123', 4, '2023-08-15'),
(160, 'hocsinh10A4_15', 'password123', 4, '2023-08-15');

-- Thêm học sinh cho lớp 10A3
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, SDTPhuHuynh, MaLop, MaDinhDanh, NoiSinh, DanToc, TonGiao, QuocGia, TinhThanh, QuanHuyen, XaPhuong, DiaChiThuongTru, SoDienThoai, Email) VALUES
(31, 131, N'Tạ Văn Bình', '2007-04-18', N'Nam', '0912345670', 3, '079207001264', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 1', N'Phường Bến Nghé', N'15 Đường Lê Duẩn, Quận 1, TP.HCM', '0912345671', 'tabinh@gmail.com'),
(32, 132, N'Lê Thị Mỹ Chi', '2007-08-05', N'Nữ', '0823456781', 3, '079207001265', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 3', N'Phường 1', N'25 Đường Nguyễn Đình Chiểu, Quận 3, TP.HCM', '0823456782', 'lechi@gmail.com'),
(33, 133, N'Trần Đức Đại', '2007-01-30', N'Nam', '0934567892', 3, '079207001266', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 5', N'Phường 5', N'48 Đường Trần Phú, Quận 5, TP.HCM', '0934567893', 'trandai@gmail.com'),
(34, 134, N'Nguyễn Thị Giang', '2007-06-12', N'Nữ', '0845678904', 3, '079207001267', N'TP.HCM', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 10', N'Phường 8', N'72 Đường Lý Thường Kiệt, Quận 10, TP.HCM', '0845678905', 'nguyengiang@gmail.com'),
(35, 135, N'Lý Hoàng Hải', '2007-09-25', N'Nam', '0956789015', 3, '079207001268', N'Hà Nội', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Tân Bình', N'Phường 2', N'24 Đường Hoàng Văn Thụ, Quận Tân Bình, TP.HCM', '0956789016', 'lyhai@gmail.com'),
(36, 136, N'Phạm Thị Hương', '2007-11-02', N'Nữ', '0867890126', 3, '079207001269', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận Phú Nhuận', N'Phường 9', N'36 Đường Nguyễn Kiệm, Quận Phú Nhuận, TP.HCM', '0867890127', 'phamhuong@gmail.com'),
(37, 137, N'Đỗ Quang Khánh', '2007-03-18', N'Nam', '0978901237', 3, '079207001270', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 7', N'Phường Tân Thuận Đông', N'83 Đường Huỳnh Tấn Phát, Quận 7, TP.HCM', '0978901238', 'dokhanh@gmail.com'),
(38, 138, N'Hoàng Thị Lan', '2007-07-20', N'Nữ', '0889012348', 3, '079207001271', N'Đồng Nai', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 2', N'Phường An Phú', N'46 Đường Mai Chí Thọ, Quận 2, TP.HCM', '0889012349', 'hoanglan@gmail.com'),
(39, 139, N'Vũ Đức Mạnh', '2007-05-10', N'Nam', '0990123459', 3, '079207001272', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 9', N'Phường Phú Hữu', N'58 Đường Đỗ Xuân Hợp, Quận 9, TP.HCM', '0990123460', 'vumanh@gmail.com'),
(40, 140, N'Đinh Thị Ngọc', '2007-02-28', N'Nữ', '0901234570', 3, '079207001273', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 8', N'Phường 1', N'70 Đường Dương Bá Trạc, Quận 8, TP.HCM', '0901234571', 'dinhngoc@gmail.com'),
(41, 141, N'Nguyễn Tiến Phát', '2007-12-15', N'Nam', '0812345681', 3, '079207001274', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Bình Thạnh', N'Phường 11', N'35 Đường Phan Văn Trị, Quận Bình Thạnh, TP.HCM', '0812345682', 'nguyenphat@gmail.com'),
(42, 142, N'Phan Thị Quỳnh', '2007-08-22', N'Nữ', '0723456782', 3, '079207001275', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 4', N'Phường 3', N'57 Đường Tôn Thất Thuyết, Quận 4, TP.HCM', '0723456783', 'phanquynh@gmail.com'),
(43, 143, N'Hoàng Minh Sơn', '2007-04-05', N'Nam', '0934567894', 3, '079207001276', N'Vũng Tàu', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 6', N'Phường 8', N'24 Đường Hậu Giang, Quận 6, TP.HCM', '0934567895', 'hoangson@gmail.com'),
(44, 144, N'Vũ Thị Thu', '2007-10-18', N'Nữ', '0845678905', 3, '079207001277', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 11', N'Phường 5', N'68 Đường Lạc Long Quân, Quận 11, TP.HCM', '0845678906', 'vuthu@gmail.com'),
(45, 145, N'Lê Văn Tuấn', '2007-06-30', N'Nam', '0956789016', 3, '079207001278', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 12', N'Phường Tân Thới Nhất', N'35 Đường Lê Văn Khương, Quận 12, TP.HCM', '0956789017', 'letuan@gmail.com');

-- Thêm học sinh cho lớp 10A4
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, SDTPhuHuynh, MaLop, MaDinhDanh, NoiSinh, DanToc, TonGiao, QuocGia, TinhThanh, QuanHuyen, XaPhuong, DiaChiThuongTru, SoDienThoai, Email) VALUES
(46, 146, N'Trần Thị Ánh', '2007-03-15', N'Nữ', '0912345672', 4, '079207001279', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 1', N'Phường Bến Nghé', N'20 Đường Lê Lợi, Quận 1, TP.HCM', '0912345673', 'trananh@gmail.com'),
(47, 147, N'Nguyễn Văn Bảo', '2007-07-22', N'Nam', '0823456783', 4, '079207001280', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 3', N'Phường 1', N'45 Đường Võ Văn Tần, Quận 3, TP.HCM', '0823456784', 'nguyenbao@gmail.com'),
(48, 148, N'Lê Thị Cẩm', '2007-01-10', N'Nữ', '0934567896', 4, '079207001281', N'Đồng Nai', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 5', N'Phường 5', N'78 Đường An Dương Vương, Quận 5, TP.HCM', '0934567897', 'lecam@gmail.com'),
(49, 149, N'Phạm Đức Duy', '2007-09-08', N'Nam', '0845678907', 4, '079207001282', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 10', N'Phường 8', N'102 Đường 3/2, Quận 10, TP.HCM', '0845678908', 'phamduy@gmail.com'),
(50, 150, N'Trịnh Thị Hà', '2007-05-29', N'Nữ', '0956789018', 4, '079207001283', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận Tân Bình', N'Phường 2', N'24 Đường Cộng Hòa, Quận Tân Bình, TP.HCM', '0956789019', 'trinhha@gmail.com'),
(51, 151, N'Vũ Quang Huy', '2007-11-14', N'Nam', '0867890128', 4, '079207001284', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Phú Nhuận', N'Phường 9', N'46 Đường Phan Xích Long, Quận Phú Nhuận, TP.HCM', '0867890129', 'vuhuy@gmail.com'),
(52, 152, N'Ngô Thị Khánh', '2007-08-05', N'Nữ', '0978901239', 4, '079207001285', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 7', N'Phường Tân Thuận Đông', N'113 Đường Nguyễn Thị Thập, Quận 7, TP.HCM', '0978901240', 'ngokhanh@gmail.com'),
(53, 153, N'Đinh Văn Long', '2007-04-25', N'Nam', '0889012350', 4, '079207001286', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 2', N'Phường An Phú', N'46 Đường Trần Não, Quận 2, TP.HCM', '0889012351', 'dinhlong@gmail.com'),
(54, 154, N'Bùi Thị Mai', '2007-02-18', N'Nữ', '0990123461', 4, '079207001287', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 9', N'Phường Phú Hữu', N'68 Đường Lê Văn Việt, Quận 9, TP.HCM', '0990123462', 'buimai@gmail.com'),
(55, 155, N'Trương Văn Nam', '2007-10-30', N'Nam', '0901234572', 4, '079207001288', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 8', N'Phường 1', N'80 Đường Phạm Hùng, Quận 8, TP.HCM', '0901234573', 'truongnam@gmail.com'),
(56, 156, N'Hoàng Thị Phương', '2007-07-19', N'Nữ', '0812345683', 4, '079207001289', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Bình Thạnh', N'Phường 11', N'35 Đường Xô Viết Nghệ Tĩnh, Quận Bình Thạnh, TP.HCM', '0812345684', 'hoangphuong@gmail.com'),
(57, 157, N'Lý Văn Quang', '2007-03-08', N'Nam', '0723456784', 4, '079207001290', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 4', N'Phường 3', N'57 Đường Hoàng Diệu, Quận 4, TP.HCM', '0723456785', 'lyquang@gmail.com'),
(58, 158, N'Đỗ Thị Thảo', '2007-12-12', N'Nữ', '0934567898', 4, '079207001291', N'Vũng Tàu', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 6', N'Phường 8', N'24 Đường Bình Phú, Quận 6, TP.HCM', '0934567899', 'dothao@gmail.com'),
(59, 159, N'Nguyễn Đức Tuấn', '2007-06-25', N'Nam', '0845678909', 4, '079207001292', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 11', N'Phường 5', N'68 Đường Âu Cơ, Quận 11, TP.HCM', '0845678910', 'nguyentuan@gmail.com'),
(60, 160, N'Trần Thị Uyên', '2007-09-16', N'Nữ', '0956789020', 4, '079207001293', N'TP.HCM', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 12', N'Phường Tân Thới Nhất', N'35 Đường Trường Chinh, Quận 12, TP.HCM', '0956789021', 'tranuyen@gmail.com');

-- Thêm dữ liệu phụ huynh cho học sinh lớp 10A3
INSERT INTO PhuHuynh (MaHS, HoTenCha, SoDienThoaiCha, HoTenMe, SoDienThoaiMe) VALUES
(31, N'Tạ Văn Anh', '0912345670', N'Nguyễn Thị Dung', '0912345672'),
(32, N'Lê Văn Bình', '0823456781', N'Trần Thị Hà', '0823456783'),
(33, N'Trần Văn Cường', '0934567892', N'Phạm Thị Hoa', '0934567894'),
(34, N'Nguyễn Văn Đức', '0845678904', N'Lê Thị Lan', '0845678906'),
(35, N'Lý Văn Giang', '0956789015', N'Hoàng Thị Mai', '0956789017'),
(36, N'Phạm Văn Hải', '0867890126', N'Vũ Thị Nga', '0867890128'),
(37, N'Đỗ Văn Kiên', '0978901237', N'Đặng Thị Oanh', '0978901239'),
(38, N'Hoàng Văn Long', '0889012348', N'Ngô Thị Phương', '0889012350'),
(39, N'Vũ Văn Minh', '0990123459', N'Phan Thị Quỳnh', '0990123461'),
(40, N'Đinh Văn Nam', '0901234570', N'Bùi Thị Sen', '0901234572'),
(41, N'Nguyễn Văn Oanh', '0812345681', N'Lý Thị Thanh', '0812345683'),
(42, N'Phan Văn Phú', '0723456782', N'Võ Thị Uyên', '0723456784'),
(43, N'Hoàng Văn Quang', '0934567894', N'Trương Thị Vân', '0934567896'),
(44, N'Vũ Văn Sơn', '0845678905', N'Mai Thị Xuân', '0845678907'),
(45, N'Lê Văn Thắng', '0956789016', N'Dương Thị Yến', '0956789018');

-- Thêm dữ liệu phụ huynh cho học sinh lớp 10A4
INSERT INTO PhuHuynh (MaHS, HoTenCha, SoDienThoaiCha, HoTenMe, SoDienThoaiMe) VALUES
(46, N'Trần Văn An', '0912345672', N'Đinh Thị Cúc', '0912345674'),
(47, N'Nguyễn Văn Bách', '0823456783', N'Hoàng Thị Diệp', '0823456785'),
(48, N'Lê Văn Cường', '0934567896', N'Lý Thị Giang', '0934567898'),
(49, N'Phạm Văn Dũng', '0845678907', N'Phạm Thị Hạnh', '0845678909'),
(50, N'Trịnh Văn Hải', '0956789018', N'Vũ Thị Liên', '0956789020'),
(51, N'Vũ Văn Hùng', '0867890128', N'Mai Thị Loan', '0867890130'),
(52, N'Ngô Văn Khải', '0978901239', N'Nguyễn Thị Mai', '0978901241'),
(53, N'Đinh Văn Lâm', '0889012350', N'Trần Thị Nhung', '0889012352'),
(54, N'Bùi Văn Minh', '0990123461', N'Hoàng Thị Phương', '0990123463'),
(55, N'Trương Văn Nghĩa', '0901234572', N'Lê Thị Quế', '0901234574'),
(56, N'Hoàng Văn Phát', '0812345683', N'Phạm Thị Sương', '0812345685'),
(57, N'Lý Văn Quân', '0723456784', N'Vũ Thị Thảo', '0723456786'),
(58, N'Đỗ Văn Thái', '0934567898', N'Đinh Thị Thủy', '0934567900'),
(59, N'Nguyễn Văn Thịnh', '0845678909', N'Nguyễn Thị Vy', '0845678911'),
(60, N'Trần Văn Uy', '0956789020', N'Trần Thị Yến', '0956789022'); 