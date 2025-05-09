USE QuanLyTruongHoc;
GO

-- Dữ liệu mẫu học sinh cho lớp 10A1 (35 học sinh)
-- Tài khoản người dùng cho học sinh
INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro, NgayTao) VALUES
-- Lớp 10A1
(101, 'hocsinh10A1_01', 'password123', 4, '2023-08-15'),
(102, 'hocsinh10A1_02', 'password123', 4, '2023-08-15'),
(103, 'hocsinh10A1_03', 'password123', 4, '2023-08-15'),
(104, 'hocsinh10A1_04', 'password123', 4, '2023-08-15'),
(105, 'hocsinh10A1_05', 'password123', 4, '2023-08-15'),
(106, 'hocsinh10A1_06', 'password123', 4, '2023-08-15'),
(107, 'hocsinh10A1_07', 'password123', 4, '2023-08-15'),
(108, 'hocsinh10A1_08', 'password123', 4, '2023-08-15'),
(109, 'hocsinh10A1_09', 'password123', 4, '2023-08-15'),
(110, 'hocsinh10A1_10', 'password123', 4, '2023-08-15'),
(111, 'hocsinh10A1_11', 'password123', 4, '2023-08-15'),
(112, 'hocsinh10A1_12', 'password123', 4, '2023-08-15'),
(113, 'hocsinh10A1_13', 'password123', 4, '2023-08-15'),
(114, 'hocsinh10A1_14', 'password123', 4, '2023-08-15'),
(115, 'hocsinh10A1_15', 'password123', 4, '2023-08-15'),

-- Lớp 10A2
(116, 'hocsinh10A2_01', 'password123', 4, '2023-08-15'),
(117, 'hocsinh10A2_02', 'password123', 4, '2023-08-15'),
(118, 'hocsinh10A2_03', 'password123', 4, '2023-08-15'),
(119, 'hocsinh10A2_04', 'password123', 4, '2023-08-15'),
(120, 'hocsinh10A2_05', 'password123', 4, '2023-08-15'),
(121, 'hocsinh10A2_06', 'password123', 4, '2023-08-15'),
(122, 'hocsinh10A2_07', 'password123', 4, '2023-08-15'),
(123, 'hocsinh10A2_08', 'password123', 4, '2023-08-15'),
(124, 'hocsinh10A2_09', 'password123', 4, '2023-08-15'),
(125, 'hocsinh10A2_10', 'password123', 4, '2023-08-15'),
(126, 'hocsinh10A2_11', 'password123', 4, '2023-08-15'),
(127, 'hocsinh10A2_12', 'password123', 4, '2023-08-15'),
(128, 'hocsinh10A2_13', 'password123', 4, '2023-08-15'),
(129, 'hocsinh10A2_14', 'password123', 4, '2023-08-15'),
(130, 'hocsinh10A2_15', 'password123', 4, '2023-08-15');

-- Thông tin học sinh lớp 10A1
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, SDTPhuHuynh, MaLop, MaDinhDanh, NoiSinh, DanToc, TonGiao, QuocGia, TinhThanh, QuanHuyen, XaPhuong, DiaChiThuongTru, SoDienThoai, Email) VALUES
(1, 101, N'Nguyễn Văn An', '2007-05-12', N'Nam', '0912345678', 1, '079207001234', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 1', N'Phường Bến Nghé', N'25 Đường Nguyễn Siêu, Quận 1, TP.HCM', '0912345679', 'nguyenan@gmail.com'),
(2, 102, N'Trần Thị Bích', '2007-08-23', N'Nữ', '0823456789', 1, '079207001235', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 3', N'Phường 1', N'45 Đường Lê Văn Sỹ, Quận 3, TP.HCM', '0823456780', 'tranbich@gmail.com'),
(3, 103, N'Lê Minh Cường', '2007-03-15', N'Nam', '0934567890', 1, '079207001236', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 5', N'Phường 5', N'78 Đường Trần Hưng Đạo, Quận 5, TP.HCM', '0934567891', 'minhcuong@gmail.com'),
(4, 104, N'Phạm Thị Diệu', '2007-11-08', N'Nữ', '0845678901', 1, '079207001237', N'TP.HCM', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 10', N'Phường 8', N'112 Đường 3/2, Quận 10, TP.HCM', '0845678902', 'phamdieu@gmail.com'),
(5, 105, N'Hoàng Văn Đức', '2007-06-22', N'Nam', '0956789012', 1, '079207001238', N'Hà Nội', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Tân Bình', N'Phường 2', N'34 Đường Cộng Hòa, Quận Tân Bình, TP.HCM', '0956789013', 'hoangduc@gmail.com'),
(6, 106, N'Vũ Thị Hà', '2007-09-17', N'Nữ', '0867890123', 1, '079207001239', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận Phú Nhuận', N'Phường 9', N'56 Đường Phan Xích Long, Quận Phú Nhuận, TP.HCM', '0867890124', 'vuha@gmail.com'),
(7, 107, N'Đặng Minh Hùng', '2007-12-05', N'Nam', '0978901234', 1, '079207001240', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 7', N'Phường Tân Thuận Đông', N'123 Đường Nguyễn Thị Thập, Quận 7, TP.HCM', '0978901235', 'danghung@gmail.com'),
(8, 108, N'Ngô Thị Lan', '2007-04-30', N'Nữ', '0889012345', 1, '079207001241', N'Đồng Nai', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 2', N'Phường An Phú', N'56 Đường Trần Não, Quận 2, TP.HCM', '0889012346', 'ngolan@gmail.com'),
(9, 109, N'Phan Văn Minh', '2007-07-11', N'Nam', '0990123456', 1, '079207001242', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 9', N'Phường Phú Hữu', N'78 Đường Lê Văn Việt, Quận 9, TP.HCM', '0990123457', 'phanminh@gmail.com'),
(10, 110, N'Bùi Thị Nga', '2007-01-25', N'Nữ', '0901234567', 1, '079207001243', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 8', N'Phường 1', N'90 Đường Phạm Hùng, Quận 8, TP.HCM', '0901234568', 'buinga@gmail.com'),
(11, 111, N'Lý Văn Phúc', '2007-10-20', N'Nam', '0812345678', 1, '079207001244', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Bình Thạnh', N'Phường 11', N'45 Đường Xô Viết Nghệ Tĩnh, Quận Bình Thạnh, TP.HCM', '0812345679', 'lyphuc@gmail.com'),
(12, 112, N'Võ Thị Quỳnh', '2007-02-14', N'Nữ', '0723456789', 1, '079207001245', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 4', N'Phường 3', N'67 Đường Hoàng Diệu, Quận 4, TP.HCM', '0723456780', 'voquynh@gmail.com'),
(13, 113, N'Trương Minh Sơn', '2007-05-28', N'Nam', '0934567890', 1, '079207001246', N'Vũng Tàu', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 6', N'Phường 8', N'34 Đường Hậu Giang, Quận 6, TP.HCM', '0934567891', 'truongson@gmail.com'),
(14, 114, N'Mai Thị Thảo', '2007-08-03', N'Nữ', '0845678901', 1, '079207001247', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 11', N'Phường 5', N'78 Đường Lạc Long Quân, Quận 11, TP.HCM', '0845678902', 'maithao@gmail.com'),
(15, 115, N'Dương Văn Uy', '2007-12-17', N'Nam', '0956789012', 1, '079207001248', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 12', N'Phường Tân Thới Nhất', N'45 Đường Lê Văn Khương, Quận 12, TP.HCM', '0956789013', 'duonguy@gmail.com'),

-- Thông tin học sinh lớp 10A2
(16, 116, N'Lương Thị Ánh', '2007-03-25', N'Nữ', '0912345670', 2, '079207001249', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 1', N'Phường Bến Nghé', N'30 Đường Lê Lợi, Quận 1, TP.HCM', '0912345671', 'luonganh@gmail.com'),
(17, 117, N'Đỗ Văn Bằng', '2007-07-14', N'Nam', '0823456780', 2, '079207001250', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 3', N'Phường 1', N'55 Đường Nguyễn Đình Chiểu, Quận 3, TP.HCM', '0823456781', 'dobang@gmail.com'),
(18, 118, N'Nguyễn Thị Châu', '2007-01-18', N'Nữ', '0934567891', 2, '079207001251', N'Đồng Nai', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận 5', N'Phường 5', N'88 Đường Trần Phú, Quận 5, TP.HCM', '0934567892', 'nguyenchau@gmail.com'),
(19, 119, N'Hoàng Văn Duy', '2007-09-30', N'Nam', '0845678902', 2, '079207001252', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 10', N'Phường 8', N'122 Đường Lý Thường Kiệt, Quận 10, TP.HCM', '0845678903', 'hoangduy@gmail.com'),
(20, 120, N'Trần Thị Hồng', '2007-05-05', N'Nữ', '0956789013', 2, '079207001253', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận Tân Bình', N'Phường 2', N'45 Đường Hoàng Văn Thụ, Quận Tân Bình, TP.HCM', '0956789014', 'tranhong@gmail.com'),
(21, 121, N'Phạm Văn Khoa', '2007-11-12', N'Nam', '0867890124', 2, '079207001254', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận Phú Nhuận', N'Phường 9', N'67 Đường Nguyễn Kiệm, Quận Phú Nhuận, TP.HCM', '0867890125', 'phamkhoa@gmail.com'),
(22, 122, N'Lê Thị Mai', '2007-08-28', N'Nữ', '0978901235', 2, '079207001255', N'Bình Dương', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 7', N'Phường Tân Thuận Đông', N'133 Đường Huỳnh Tấn Phát, Quận 7, TP.HCM', '0978901236', 'lemai@gmail.com'),
(23, 123, N'Vũ Văn Nam', '2007-04-15', N'Nam', '0889012346', 2, '079207001256', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 2', N'Phường An Phú', N'66 Đường Mai Chí Thọ, Quận 2, TP.HCM', '0889012347', 'vunam@gmail.com'),
(24, 124, N'Đinh Thị Oanh', '2007-06-07', N'Nữ', '0990123457', 2, '079207001257', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 9', N'Phường Phú Hữu', N'88 Đường Đỗ Xuân Hợp, Quận 9, TP.HCM', '0990123458', 'dinhoanh@gmail.com'),
(25, 125, N'Nguyễn Văn Phương', '2007-02-20', N'Nam', '0901234568', 2, '079207001258', N'Vũng Tàu', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 8', N'Phường 1', N'99 Đường Dương Bá Trạc, Quận 8, TP.HCM', '0901234569', 'nguyenphuong@gmail.com'),
(26, 126, N'Trần Thị Quỳnh', '2007-10-01', N'Nữ', '0812345679', 2, '079207001259', N'TP.HCM', N'Kinh', N'Thiên Chúa', N'Việt Nam', N'TP.HCM', N'Quận Bình Thạnh', N'Phường 11', N'55 Đường Phan Văn Trị, Quận Bình Thạnh, TP.HCM', '0812345680', 'tranquynh@gmail.com'),
(27, 127, N'Lý Văn Sơn', '2007-03-09', N'Nam', '0723456780', 2, '079207001260', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 4', N'Phường 3', N'77 Đường Tôn Thất Thuyết, Quận 4, TP.HCM', '0723456781', 'lyson@gmail.com'),
(28, 128, N'Phan Thị Thu', '2007-07-25', N'Nữ', '0934567892', 2, '079207001261', N'TP.HCM', N'Kinh', N'Phật giáo', N'Việt Nam', N'TP.HCM', N'Quận 6', N'Phường 8', N'44 Đường Hậu Giang, Quận 6, TP.HCM', '0934567893', 'phanthu@gmail.com'),
(29, 129, N'Hoàng Văn Vân', '2007-12-18', N'Nam', '0845678903', 2, '079207001262', N'TP.HCM', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 11', N'Phường 5', N'88 Đường Lạc Long Quân, Quận 11, TP.HCM', '0845678904', 'hoangvan@gmail.com'),
(30, 130, N'Mai Thị Xuân', '2007-02-07', N'Nữ', '0956789014', 2, '079207001263', N'Hà Nội', N'Kinh', N'Không', N'Việt Nam', N'TP.HCM', N'Quận 12', N'Phường Tân Thới Nhất', N'55 Đường Phan Văn Hớn, Quận 12, TP.HCM', '0956789015', 'maixuan@gmail.com');

-- Dữ liệu mẫu cho phụ huynh học sinh lớp 10A1
INSERT INTO PhuHuynh (MaHS, HoTenCha, SoDienThoaiCha, HoTenMe, SoDienThoaiMe) VALUES
(1, N'Nguyễn Văn Bình', '0912345678', N'Lê Thị Hoa', '0912345680'),
(2, N'Trần Văn Cường', '0823456789', N'Phạm Thị Lan', '0823456790'),
(3, N'Lê Văn Dũng', '0934567890', N'Hoàng Thị Mai', '0934567895'),
(4, N'Phạm Văn Em', '0845678901', N'Vũ Thị Nga', '0845678905'),
(5, N'Hoàng Văn Giáp', '0956789012', N'Đặng Thị Oanh', '0956789015'),
(6, N'Vũ Văn Hưng', '0867890123', N'Ngô Thị Phương', '0867890125'),
(7, N'Đặng Văn Khang', '0978901234', N'Phan Thị Quỳnh', '0978901236'),
(8, N'Ngô Văn Linh', '0889012345', N'Bùi Thị Sen', '0889012347'),
(9, N'Phan Văn Minh', '0990123456', N'Lý Thị Thanh', '0990123458'),
(10, N'Bùi Văn Nam', '0901234567', N'Võ Thị Uyên', '0901234569'),
(11, N'Lý Văn Oanh', '0812345678', N'Trương Thị Vân', '0812345680'),
(12, N'Võ Văn Phú', '0723456789', N'Mai Thị Xuân', '0723456790'),
(13, N'Trương Văn Quang', '0934567890', N'Dương Thị Yến', '0934567892'),
(14, N'Mai Văn Sơn', '0845678901', N'Đinh Thị Anh', '0845678903'),
(15, N'Dương Văn Thắng', '0956789012', N'Chu Thị Bích', '0956789014'),

-- Dữ liệu mẫu cho phụ huynh học sinh lớp 10A2
(16, N'Lương Văn Bảo', '0912345670', N'Đinh Thị Cúc', '0912345672'),
(17, N'Đỗ Văn Chiến', '0823456780', N'Hoàng Thị Diệp', '0823456782'),
(18, N'Nguyễn Văn Đông', '0934567891', N'Lý Thị Giang', '0934567893'),
(19, N'Hoàng Văn Hải', '0845678902', N'Phạm Thị Hạnh', '0845678904'),
(20, N'Trần Văn Kiên', '0956789013', N'Vũ Thị Liên', '0956789015'),
(21, N'Phạm Văn Long', '0867890124', N'Mai Thị Loan', '0867890126'),
(22, N'Lê Văn Mạnh', '0978901235', N'Nguyễn Thị Mai', '0978901237'),
(23, N'Vũ Văn Ninh', '0889012346', N'Trần Thị Nhung', '0889012348'),
(24, N'Đinh Văn Phát', '0990123457', N'Hoàng Thị Phương', '0990123459'),
(25, N'Nguyễn Văn Quốc', '0901234568', N'Lê Thị Quế', '0901234570'),
(26, N'Trần Văn Sáng', '0812345679', N'Phạm Thị Sương', '0812345681'),
(27, N'Lý Văn Thắng', '0723456780', N'Vũ Thị Thảo', '0723456782'),
(28, N'Phan Văn Trung', '0934567892', N'Đinh Thị Thủy', '0934567894'),
(29, N'Hoàng Văn Vũ', '0845678903', N'Nguyễn Thị Vy', '0845678905'),
(30, N'Mai Văn Xuân', '0956789014', N'Trần Thị Yến', '0956789016');