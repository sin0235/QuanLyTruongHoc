USE QuanLyTruongHoc;
GO

-- Dữ liệu mẫu cho bảng VaiTro
INSERT INTO VaiTro (MaVaiTro, TenVaiTro) VALUES
(1, N'Ban Giám Hiệu'),
(2, N'Phòng Nội Vụ'),
(3, N'Giáo Viên'),
(4, N'Học Sinh');

-- Dữ liệu mẫu cho bảng MonHoc
INSERT INTO MonHoc (MaMon, TenMon) VALUES
(1, N'Toán'),
(2, N'Vật Lý'),
(3, N'Hóa Học'),
(4, N'Sinh Học'),
(5, N'Ngữ Văn'),
(6, N'Lịch Sử'),
(7, N'Địa Lý'),
(8, N'Tiếng Anh'),
(9, N'Giáo Dục Công Dân'),
(10, N'Thể Dục'),
(11, N'Tin Học'),
(12, N'Công Nghệ');

-- Dữ liệu mẫu cho bảng NguoiDung (Ban Giám Hiệu và Phòng Nội Vụ)
INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro, NgayTao) VALUES
-- Ban Giám Hiệu (3 người)
(1, 'hiewtruong', 'password123', 1, '2024-08-01'),
(2, 'phohieutruong1', 'password123', 1, '2024-08-01'),
(3, 'phohieutruong2', 'password123', 1, '2024-08-01'),
-- Phòng Nội Vụ (3 người)
(4, 'truongphongnoivu', 'password123', 2, '2024-08-01'),
(5, 'nhanviennoivu1', 'password123', 2, '2024-08-01'),
(6, 'nhanviennoivu2', 'password123', 2, '2024-08-01');

-- Dữ liệu người dùng cho giáo viên (30 giáo viên)
INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro, NgayTao) VALUES
(7, 'giaovien01', 'password123', 3, '2024-08-02'),
(8, 'giaovien02', 'password123', 3, '2024-08-02'),
(9, 'giaovien03', 'password123', 3, '2024-08-02'),
(10, 'giaovien04', 'password123', 3, '2024-08-02'),
(11, 'giaovien05', 'password123', 3, '2024-08-02'),
(12, 'giaovien06', 'password123', 3, '2024-08-02'),
(13, 'giaovien07', 'password123', 3, '2024-08-02'),
(14, 'giaovien08', 'password123', 3, '2024-08-02'),
(15, 'giaovien09', 'password123', 3, '2024-08-02'),
(16, 'giaovien10', 'password123', 3, '2024-08-02'),
(17, 'giaovien11', 'password123', 3, '2024-08-02'),
(18, 'giaovien12', 'password123', 3, '2024-08-02'),
(19, 'giaovien13', 'password123', 3, '2024-08-02'),
(20, 'giaovien14', 'password123', 3, '2024-08-02'),
(21, 'giaovien15', 'password123', 3, '2024-08-02'),
(22, 'giaovien16', 'password123', 3, '2024-08-02'),
(23, 'giaovien17', 'password123', 3, '2024-08-02'),
(24, 'giaovien18', 'password123', 3, '2024-08-02'),
(25, 'giaovien19', 'password123', 3, '2024-08-02'),
(26, 'giaovien20', 'password123', 3, '2024-08-02'),
(27, 'giaovien21', 'password123', 3, '2024-08-02'),
(28, 'giaovien22', 'password123', 3, '2024-08-02'),
(29, 'giaovien23', 'password123', 3, '2024-08-02'),
(30, 'giaovien24', 'password123', 3, '2024-08-02'),
(31, 'giaovien25', 'password123', 3, '2024-08-02'),
(32, 'giaovien26', 'password123', 3, '2024-08-02'),
(33, 'giaovien27', 'password123', 3, '2024-08-02'),
(34, 'giaovien28', 'password123', 3, '2024-08-02'),
(35, 'giaovien29', 'password123', 3, '2024-08-02'),
(36, 'giaovien30', 'password123', 3, '2024-08-02');

-- Dữ liệu mẫu cho GiaoVien (Ban Giám Hiệu và Phòng Nội Vụ)
INSERT INTO GiaoVien (MaGV, MaNguoiDung, HoTen, GioiTinh, SDT, Email, MaMon, ChuNhiem, NgaySinh, DiaChi) VALUES
-- Ban Giám Hiệu
(1, 1, N'Nguyễn Văn An', N'Nam', '0901234567', 'an.nguyen@school.edu.vn', 1, 0, '1970-05-15', N'123 Đường Lê Lợi, Quận 1, TP.HCM'),
(2, 2, N'Trần Thị Bình', N'Nữ', '0912345678', 'binh.tran@school.edu.vn', 5, 0, '1975-08-20', N'456 Đường Nguyễn Huệ, Quận 1, TP.HCM'),
(3, 3, N'Lê Văn Cường', N'Nam', '0923456789', 'cuong.le@school.edu.vn', 2, 0, '1972-03-10', N'789 Đường Trần Hưng Đạo, Quận 5, TP.HCM'),
-- Phòng Nội Vụ
(4, 4, N'Phạm Thị Dung', N'Nữ', '0934567890', 'dung.pham@school.edu.vn', 6, 0, '1980-11-25', N'101 Đường 3/2, Quận 10, TP.HCM'),
(5, 5, N'Hoàng Văn Em', N'Nam', '0945678901', 'em.hoang@school.edu.vn', 9, 0, '1985-04-30', N'202 Đường Cách Mạng Tháng 8, Quận 3, TP.HCM'),
(6, 6, N'Vũ Thị Phương', N'Nữ', '0956789012', 'phuong.vu@school.edu.vn', 8, 0, '1982-07-12', N'303 Đường Điện Biên Phủ, Quận Bình Thạnh, TP.HCM');

-- Dữ liệu mẫu cho GiaoVien (giáo viên thường)
INSERT INTO GiaoVien (MaGV, MaNguoiDung, HoTen, GioiTinh, SDT, Email, MaMon, ChuNhiem, NgaySinh, DiaChi) VALUES
-- Giáo viên Toán (5 người)
(7, 7, N'Đỗ Thị Hương', N'Nữ', '0967890123', 'huong.do@school.edu.vn', 1, 1, '1982-02-18', N'404 Đường Lý Thường Kiệt, Quận 10, TP.HCM'),
(8, 8, N'Ngô Văn Dũng', N'Nam', '0978901234', 'dung.ngo@school.edu.vn', 1, 1, '1980-05-22', N'505 Đường Nguyễn Trãi, Quận 5, TP.HCM'),
(9, 9, N'Lý Thị Lan', N'Nữ', '0989012345', 'lan.ly@school.edu.vn', 1, 1, '1985-09-30', N'606 Đường An Dương Vương, Quận 5, TP.HCM'),
(10, 10, N'Trịnh Văn Mạnh', N'Nam', '0990123456', 'manh.trinh@school.edu.vn', 1, 0, '1983-11-08', N'707 Đường Hùng Vương, Quận 5, TP.HCM'),
(11, 11, N'Bùi Thị Ngọc', N'Nữ', '0901234567', 'ngoc.bui@school.edu.vn', 1, 0, '1984-12-15', N'808 Đường Nguyễn Văn Cừ, Quận 5, TP.HCM'),

-- Giáo viên Lý (3 người)
(12, 12, N'Hoàng Văn Phúc', N'Nam', '0912345678', 'phuc.hoang@school.edu.vn', 2, 1, '1978-03-25', N'909 Đường Võ Văn Kiệt, Quận 1, TP.HCM'),
(13, 13, N'Lê Thị Quỳnh', N'Nữ', '0923456789', 'quynh.le@school.edu.vn', 2, 0, '1981-06-12', N'1010 Đường Nguyễn Thị Minh Khai, Quận 1, TP.HCM'),
(14, 14, N'Phan Văn Sơn', N'Nam', '0934567890', 'son.phan@school.edu.vn', 2, 0, '1979-08-09', N'1111 Đường Phạm Ngũ Lão, Quận 1, TP.HCM'),

-- Giáo viên Hóa (3 người)
(15, 15, N'Võ Thị Thảo', N'Nữ', '0945678901', 'thao.vo@school.edu.vn', 3, 1, '1982-04-17', N'1212 Đường Bùi Viện, Quận 1, TP.HCM'),
(16, 16, N'Đặng Văn Uy', N'Nam', '0956789012', 'uy.dang@school.edu.vn', 3, 0, '1980-01-27', N'1313 Đường Cống Quỳnh, Quận 1, TP.HCM'),
(17, 17, N'Nguyễn Thị Vân', N'Nữ', '0967890123', 'van.nguyen@school.edu.vn', 3, 0, '1983-10-05', N'1414 Đường Nguyễn Cư Trinh, Quận 1, TP.HCM'),

-- Giáo viên Sinh (2 người)
(18, 18, N'Trần Văn Xuân', N'Nam', '0978901234', 'xuan.tran@school.edu.vn', 4, 1, '1981-12-31', N'1515 Đường Lê Lai, Quận 1, TP.HCM'),
(19, 19, N'Phạm Thị Yến', N'Nữ', '0989012345', 'yen.pham@school.edu.vn', 4, 0, '1984-07-19', N'1616 Đường Đồng Khởi, Quận 1, TP.HCM'),

-- Giáo viên Văn (3 người)
(20, 20, N'Hồ Văn Anh', N'Nam', '0990123456', 'anh.ho@school.edu.vn', 5, 1, '1979-05-14', N'1717 Đường Lê Duẩn, Quận 1, TP.HCM'),
(21, 21, N'Vũ Thị Bảo', N'Nữ', '0901234567', 'bao.vu@school.edu.vn', 5, 1, '1982-08-22', N'1818 Đường Nam Kỳ Khởi Nghĩa, Quận 3, TP.HCM'),
(22, 22, N'Đinh Văn Cẩm', N'Nam', '0912345678', 'cam.dinh@school.edu.vn', 5, 0, '1981-03-11', N'1919 Đường Võ Thị Sáu, Quận 3, TP.HCM'),

-- Giáo viên Sử (2 người)
(23, 23, N'Lương Thị Đào', N'Nữ', '0923456789', 'dao.luong@school.edu.vn', 6, 1, '1983-04-29', N'2020 Đường Nguyễn Đình Chiểu, Quận 3, TP.HCM'),
(24, 24, N'Mai Văn Giang', N'Nam', '0934567890', 'giang.mai@school.edu.vn', 6, 0, '1980-09-07', N'2121 Đường Calmette, Quận 1, TP.HCM'),

-- Giáo viên Địa (2 người)
(25, 25, N'Lý Thị Hoa', N'Nữ', '0945678901', 'hoa.ly@school.edu.vn', 7, 1, '1984-11-23', N'2222 Đường Trần Quang Khải, Quận 1, TP.HCM'),
(26, 26, N'Trương Văn Khang', N'Nam', '0956789012', 'khang.truong@school.edu.vn', 7, 0, '1979-10-16', N'2323 Đường Nguyễn Công Trứ, Quận 1, TP.HCM'),

-- Giáo viên Anh (3 người)
(27, 27, N'Dương Thị Linh', N'Nữ', '0967890123', 'linh.duong@school.edu.vn', 8, 1, '1985-01-08', N'2424 Đường Hàm Nghi, Quận 1, TP.HCM'),
(28, 28, N'Cao Văn Minh', N'Nam', '0978901234', 'minh.cao@school.edu.vn', 8, 1, '1982-06-19', N'2525 Đường Lý Tự Trọng, Quận 1, TP.HCM'),
(29, 29, N'Tạ Thị Nga', N'Nữ', '0989012345', 'nga.ta@school.edu.vn', 8, 0, '1981-07-25', N'2626 Đường Pasteur, Quận 1, TP.HCM'),

-- Giáo viên các môn khác
(30, 30, N'Dương Văn Oanh', N'Nam', '0990123456', 'oanh.duong@school.edu.vn', 9, 1, '1983-05-15', N'2727 Đường Lê Thánh Tôn, Quận 1, TP.HCM'),
(31, 31, N'Chu Thị Phượng', N'Nữ', '0901234567', 'phuong.chu@school.edu.vn', 10, 1, '1980-03-20', N'2828 Đường Tôn Thất Thiệp, Quận 1, TP.HCM'),
(32, 32, N'Huỳnh Văn Quân', N'Nam', '0912345678', 'quan.huynh@school.edu.vn', 11, 1, '1978-08-14', N'2929 Đường Mạc Thị Bưởi, Quận 1, TP.HCM'),
(33, 33, N'Trần Thị Uyên', N'Nữ', '0923456789', 'uyen.tran@school.edu.vn', 12, 1, '1984-04-01', N'3030 Đường Thái Văn Lung, Quận 1, TP.HCM'),
(34, 34, N'Nguyễn Văn Vinh', N'Nam', '0934567890', 'vinh.nguyen@school.edu.vn', 10, 0, '1979-12-02', N'3131 Đường Ngô Đức Kế, Quận 1, TP.HCM'),
(35, 35, N'Lê Thị Xuân', N'Nữ', '0945678901', 'xuan.le@school.edu.vn', 11, 0, '1982-10-10', N'3232 Đường Huỳnh Thúc Kháng, Quận 1, TP.HCM'),
(36, 36, N'Phạm Văn Yên', N'Nam', '0956789012', 'yen.pham@school.edu.vn', 12, 0, '1981-02-28', N'3333 Đường Nguyễn Siêu, Quận 1, TP.HCM');

-- Dữ liệu mẫu cho LopHoc (12 lớp - mỗi khối 4 lớp)
INSERT INTO LopHoc (MaLop, TenLop, MaGVChuNhiem, NamHoc) VALUES
-- Khối 10
(1, N'10A1', 7, N'2024-2025'),  -- Giáo viên Toán
(2, N'10A2', 8, N'2024-2025'),  -- Giáo viên Toán
(3, N'10A3', 12, N'2024-2025'), -- Giáo viên Lý
(4, N'10A4', 15, N'2024-2025'), -- Giáo viên Hóa

-- Khối 11
(5, N'11A1', 9, N'2024-2025'),  -- Giáo viên Toán
(6, N'11A2', 18, N'2024-2025'), -- Giáo viên Sinh
(7, N'11A3', 20, N'2024-2025'), -- Giáo viên Văn
(8, N'11A4', 21, N'2024-2025'), -- Giáo viên Văn

-- Khối 12
(9, N'12A1', 23, N'2024-2025'),  -- Giáo viên Sử
(10, N'12A2', 25, N'2024-2025'), -- Giáo viên Địa
(11, N'12A3', 27, N'2024-2025'), -- Giáo viên Anh
(12, N'12A4', 28, N'2024-2025'); -- Giáo viên Anh

-- Bắt đầu thêm học sinh
-- Mỗi lớp sẽ có 30-40 học sinh
-- MaNguoiDung bắt đầu từ 101 