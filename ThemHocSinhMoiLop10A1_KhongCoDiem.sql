USE QuanLyTruongHoc;
GO

-- Tạo tài khoản người dùng mới cho học sinh
DECLARE @NewStudentID INT = (SELECT MAX(MaNguoiDung) FROM NguoiDung) + 1;

-- Thêm tài khoản người dùng
INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro, NgayTao) 
VALUES (@NewStudentID, 'hocsinh10A1_new', 'password123', 4, GETDATE());

-- Thêm thông tin học sinh
DECLARE @NewStudentMaHS INT = (SELECT MAX(MaHS) FROM HocSinh) + 1;
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, SDTPhuHuynh, MaLop, MaDinhDanh, NoiSinh, DanToc, TonGiao, QuocGia, TinhThanh, QuanHuyen, XaPhuong, DiaChiThuongTru, SoDienThoai, Email) 
VALUES 
(
    @NewStudentMaHS, 
    @NewStudentID, 
    N'Nguyễn Học Sinh Mới', 
    '2007-06-15', 
    N'Nam', 
    '0987654321', 
    1, -- MaLop cho lớp 10A1
    '079207001299', 
    N'TP.HCM', 
    N'Kinh', 
    N'Không', 
    N'Việt Nam', 
    N'TP.HCM', 
    N'Quận 10', 
    N'Phường 8', 
    N'123 Đường Lê Hồng Phong, Quận 10, TP.HCM', 
    '0987654322', 
    'hocsinh.moi@gmail.com'
);

-- Thêm thông tin phụ huynh
INSERT INTO PhuHuynh (MaHS, HoTenCha, SoDienThoaiCha, HoTenMe, SoDienThoaiMe) 
VALUES 
(
    @NewStudentMaHS, 
    N'Nguyễn Văn Cha', 
    '0987654321', 
    N'Trần Thị Mẹ', 
    '0987654323'
);

PRINT N'Đã thêm học sinh mới vào lớp 10A1 thành công!';
PRINT N'MaHS: ' + CAST(@NewStudentMaHS AS NVARCHAR(10));
PRINT N'MaNguoiDung: ' + CAST(@NewStudentID AS NVARCHAR(10));
PRINT N'Học sinh này chưa có dữ liệu điểm số nào.'; 