--CODE TẠO CƠ SỞ DỮ LIỆU
CREATE DATABASE QuanLyTruongHoc;
GO

USE QuanLyTruongHoc;
GO


CREATE TABLE VaiTro (
    MaVaiTro INT PRIMARY KEY,
    TenVaiTro NVARCHAR(50) NOT NULL
);

CREATE TABLE NguoiDung (
	MaNguoiDung INT PRIMARY KEY,
	TenDangNhap NVARCHAR (50) NOT NULL UNIQUE,
	MatKhau NVARCHAR(100) NOT NULL,
	MaVaiTro INT NOT NULL,
	NgayTao DATETIME NOT NULL,
	FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro)
);

CREATE TABLE MonHoc (
    MaMon INT PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL
);

CREATE TABLE GiaoVien (
    MaGV INT PRIMARY KEY,
    MaNguoiDung INT NOT NULL UNIQUE,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    SDT VARCHAR(15),
    Email NVARCHAR(100),
    MaMon INT NOT NULL,
    ChuNhiem BIT NOT NULL,
    NgaySinh DATE,
   DiaChi NVARCHAR(100),
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);

CREATE TABLE LopHoc (
    	MaLop INT PRIMARY KEY,
	TenLop NVARCHAR(20) NOT NULL,
	MaGVChuNhiem INT NOT NULL,
	NamHoc NVARCHAR(20) NOT NULL,   
FOREIGN KEY (MaGVChuNhiem) REFERENCES GiaoVien(MaGV)
);

CREATE TABLE HocSinh (
    MaHS INT PRIMARY KEY,
    MaNguoiDung INT NOT NULL UNIQUE,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    DiaChi NVARCHAR(200),
    SDTPhuHuynh VARCHAR(15),
    MaLop INT NOT NULL,
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop)
);

CREATE TABLE DiemDanh (
    MaDiemDanh INT IDENTITY(1,1) PRIMARY KEY,
    MaHS INT NOT NULL,
    MaLop INT NOT NULL,
    Ngay DATE NOT NULL,
    TrangThai NVARCHAR(30) NOT NULL,
    GhiChu NVARCHAR(200),
    FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS) ON DELETE CASCADE,
    FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop)
);

CREATE TABLE DiemSo (
    MaDiem INT PRIMARY KEY,
    MaHS INT NOT NULL,
    MaMon INT NOT NULL,
    MaGV INT NOT NULL,
    HocKy INT NOT NULL,
    LoaiDiem NVARCHAR(20) NOT NULL,
    Diem FLOAT NOT NULL,
    FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS) ON DELETE CASCADE,
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon),
    FOREIGN KEY (MaGV) REFERENCES GiaoVien(MaGV)
);

CREATE TABLE ThoiKhoaBieu (
    MaTKB INT PRIMARY KEY,
    MaLop INT NOT NULL,
    MaMon INT NOT NULL,
    MaGV INT NOT NULL,
    Ngay DATE NOT NULL,
    Thu INT NOT NULL,
    Tiet NVARCHAR(10) NOT NULL,
    FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon),
    FOREIGN KEY (MaGV) REFERENCES GiaoVien(MaGV)
);

CREATE TABLE KeHoachGiangDay (
    MaKH INT PRIMARY KEY,
    MaGV INT NOT NULL,
    MaMon INT NOT NULL,
    Tuan INT NOT NULL,
    MaLop INT NOT NULL,
    NoiDungGiangDay NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (MaGV) REFERENCES GiaoVien(MaGV),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);

CREATE TABLE ThongBao (
    MaTB INT PRIMARY KEY,
    MaNguoiGui INT NOT NULL,
    MaNguoiNhan INT NULL,
    MaVaiTroNhan INT NULL,
    MaLop INT NULL,
    MaMon INT NULL,
    TieuDe NVARCHAR(200) NOT NULL,
    NoiDung NVARCHAR(MAX) NOT NULL,
    NgayGui DATETIME NOT NULL,
    FOREIGN KEY (MaNguoiGui) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaNguoiNhan) REFERENCES NguoiDung(MaNguoiDung) ON DELETE CASCADE,
    FOREIGN KEY (MaVaiTroNhan) REFERENCES VaiTro(MaVaiTro),
    FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);

CREATE TABLE DonXinNghi (
    MaDon INT PRIMARY KEY,
    MaHS INT NOT NULL,
    NgayGui DATE NOT NULL,
    NgayNghi DATE NOT NULL,
    LyDo NVARCHAR(300) NOT NULL,
    MaGV INT NULL,
    TrangThai NVARCHAR(20) NULL,
    FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS) ON DELETE CASCADE,
    FOREIGN KEY (MaGV) REFERENCES GiaoVien(MaGV)
);

CREATE TABLE NhatKyHeThong (
	MaNK INT PRIMARY KEY,
	MaNguoiDung INT NOT NULL,
	HanhDong NVARCHAR(200) NOT NULL,
	ThoiGian DATETIME NOT NULL,
	FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
);

   

--THÊM DỮ LIỆU CHO CSDL

-- Thêm dữ liệu mẫu vào bảng VaiTro
INSERT INTO VaiTro (MaVaiTro, TenVaiTro) VALUES
(1, N'Ban giám hiệu'),
(2, N'Giáo viên'),
(3, N'Học sinh'),
(4, N'Nhân viên phòng nội vụ');

-- Thêm dữ liệu mẫu vào bảng NguoiDung
INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro, NgayTao) VALUES
(1, 'bgh', 'bgh123', 1, GETDATE()),
(2, 'gv1', 'gv1', 2, GETDATE()),
(3, 'gv2', 'gv2', 2, GETDATE()),
(4, 'hs1', 'hs1', 3, GETDATE()),
(5, 'hs2', 'hs2', 3, GETDATE()),
(6, 'hs3', 'hs3', 3, GETDATE()),
(7, 'hs4', 'hs4', 3, GETDATE()),
(8, 'hs5', 'hs5', 3, GETDATE()),
(9, 'gv3', 'gv3', 2, GETDATE()),
(10, 'gv4', 'gv4', 2, GETDATE()),
(11, 'pnv', 'pnv', 4, GETDATE());

-- Thêm dữ liệu mẫu vào bảng MonHoc
INSERT INTO MonHoc (MaMon, TenMon) VALUES
(1, N'Toán'),
(2, N'Ngữ văn'),
(3, N'Ngoại ngữ'),
(4, N'Lịch sử'),
(5, N'Vật lý');

-- Thêm dữ liệu mẫu vào bảng GiaoVien
INSERT INTO GiaoVien (MaGV, MaNguoiDung, HoTen, GioiTinh, SDT, Email, MaMon, ChuNhiem, NgaySinh, DiaChi) VALUES
(100, 2, N'Nguyễn Văn A', N'Nam', '0912345678', 'nguyenvana@gmail.com', 1, 1, '1980-05-15', N'Hà Nội'),
(101, 3, N'Trần Thị B', N'Nữ', '0987654321', 'tranthib@gmail.com', 2, 1, '1985-08-20', N'Hồ Chí Minh'),
(102, 9, N'Lê Văn C', N'Nam', '0911223344', 'levanc@gmail.com', 3, 0, '1990-03-10', N'Đà Nẵng'),
(103, 10, N'Phạm Thị D', N'Nữ', '0911333444', 'phamthid@gmail.com', 4, 0, '1992-11-25', N'Hải Phòng');

-- Thêm dữ liệu mẫu vào bảng LopHoc
INSERT INTO LopHoc (MaLop, TenLop, MaGVChuNhiem, NamHoc) VALUES
(1, N'10A3', 100, N'2024–2025'),
(2, N'12A3', 101, N'2024–2025'),
(3, N'11B1', 102, N'2024–2025'),
(4, N'10B2', 103, N'2024–2025');

-- Thêm dữ liệu mẫu vào bảng HocSinh
INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, DiaChi, SDTPhuHuynh, MaLop) VALUES
(43110333, 4, N'Phạm Minh Khoa', '2008-03-15', N'Nam', N'Hà Nội', '0911001100', 1),
(43110222, 5, N'Lê Hồng Ngọc', '2008-07-20', N'Nữ', N'Hà Nội', '0911223344', 2),
(43110444, 6, N'Nguyễn Văn Bình', '2008-05-10', N'Nam', N'Hà Nội', '0911445566', 1),
(43110555, 7, N'Trần Thị Mai', '2008-09-25', N'Nữ', N'Hà Nội', '0911556677', 3),
(43110666, 8, N'Hoàng Văn Nam', '2008-11-30', N'Nam', N'Hà Nội', '0911667788', 4);

-- Thêm dữ liệu mẫu vào bảng DiemSo
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(1, 43110333, 1, 100, 1, N'Miệng', 8.5),
(2, 43110333, 1, 100, 1, N'15 phút', 7.0),
(3, 43110333, 1, 100, 1, N'Cuối kỳ', 9.0),
(4, 43110222, 2, 101, 1, N'Miệng', 8.0),
(5, 43110222, 2, 101, 1, N'15 phút', 7.5),
(6, 43110222, 2, 101, 1, N'Cuối kỳ', 9.0),
(7, 43110444, 1, 100, 1, N'Miệng', 6.5),
(8, 43110444, 1, 100, 1, N'15 phút', 7.0),
(9, 43110444, 1, 100, 1, N'Cuối kỳ', 8.0),
(10, 43110555, 3, 102, 1, N'Miệng', 9.0),
(11, 43110555, 3, 102, 1, N'15 phút', 8.5),
(12, 43110555, 3, 102, 1, N'Cuối kỳ', 9.5),
(13, 43110666, 4, 103, 1, N'Miệng', 7.5),
(14, 43110666, 4, 103, 1, N'15 phút', 8.0),
(15, 43110666, 4, 103, 1, N'Cuối kỳ', 8.5),
(16, 43110333, 2, 101, 1, N'Miệng', 8.0),
(17, 43110333, 2, 101, 1, N'15 phút', 7.5),
(18, 43110333, 2, 101, 1, N'Cuối kỳ', 9.0),
(19, 43110444, 2, 101, 1, N'Miệng', 7.0),
(20, 43110444, 2, 101, 1, N'15 phút', 6.5),
(21, 43110444, 2, 101, 1, N'Cuối kỳ', 8.0),
(22, 43110333, 2, 101, 1, N'Miệng', 8.0),
(23, 43110333, 2, 101, 1, N'15 phút', 7.5),
(24, 43110333, 2, 101, 1, N'Cuối kỳ', 9.0),
(25, 43110444, 2, 101, 1, N'Miệng', 7.0),
(26, 43110444, 2, 101, 1, N'15 phút', 6.5),
(27, 43110444, 2, 101, 1, N'Cuối kỳ', 8.0);

-- Thêm dữ liệu mẫu vào bảng ThoiKhoaBieu
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(1, 1, 1, 100, '2025-05-01', 2, N'1-3'),
(2, 1, 2, 101, '2025-05-01', 2, N'4-5'),
(3, 1, 3, 102, '2025-05-02', 3, N'1-2'),
(4, 1, 4, 103, '2025-05-02', 3, N'3-4'),
(5, 1, 5, 100, '2025-05-03', 4, N'5-6'),
(6, 2, 1, 100, '2025-05-01', 2, N'1-3'),
(7, 2, 2, 101, '2025-05-02', 3, N'4-5'),
(8, 2, 3, 102, '2025-05-03', 4, N'1-2'),
(9, 2, 4, 103, '2025-05-04', 5, N'3-4'),
(10, 2, 5, 100, '2025-05-05', 6, N'5-6'),
(11, 3, 1, 100, '2025-05-01', 2, N'1-3'),
(12, 3, 2, 101, '2025-05-02', 3, N'4-5'),
(13, 3, 3, 102, '2025-05-03', 4, N'1-2'),
(14, 3, 4, 103, '2025-05-04', 5, N'3-4'),
(15, 3, 5, 100, '2025-05-05', 6, N'5-6'),
(16, 4, 1, 100, '2025-05-01', 2, N'1-3'),
(17, 4, 2, 101, '2025-05-02', 3, N'4-5'),
(18, 4, 3, 102, '2025-05-03', 4, N'1-2'),
(19, 4, 4, 103, '2025-05-04', 5, N'3-4'),
(20, 4, 5, 100, '2025-05-05', 6, N'5-6'),
(21, 1, 1, 100, '2025-05-06', 2, N'1-3'),
(22, 1, 2, 101, '2025-05-06', 2, N'4-5'),
(23, 1, 3, 102, '2025-05-07', 3, N'1-2'),
(24, 1, 4, 103, '2025-05-07', 3, N'3-4'),
(25, 1, 5, 100, '2025-05-08', 4, N'5-6'),
(26, 2, 1, 100, '2025-05-06', 2, N'1-3'),
(27, 2, 2, 101, '2025-05-07', 3, N'4-5'),
(28, 2, 3, 102, '2025-05-08', 4, N'1-2'),
(29, 2, 4, 103, '2025-05-09', 5, N'3-4'),
(30, 2, 5, 100, '2025-05-10', 6, N'5-6'),
(31, 3, 1, 100, '2025-05-06', 2, N'1-3'),
(32, 3, 2, 101, '2025-05-07', 3, N'4-5'),
(33, 3, 3, 102, '2025-05-08', 4, N'1-2'),
(34, 3, 4, 103, '2025-05-09', 5, N'3-4'),
(35, 3, 5, 100, '2025-05-10', 6, N'5-6'),
(36, 4, 1, 100, '2025-05-06', 2, N'1-3'),
(37, 4, 2, 101, '2025-05-07', 3, N'4-5'),
(38, 4, 3, 102, '2025-05-08', 4, N'1-2'),
(39, 4, 4, 103, '2025-05-09', 5, N'3-4'),
(40, 4, 5, 100, '2025-05-10', 6, N'5-6');

-- Thêm dữ liệu mẫu vào bảng KeHoachGiangDay
INSERT INTO KeHoachGiangDay (MaKH, MaGV, MaMon, Tuan, MaLop, NoiDungGiangDay) VALUES
(1, 100, 1, 1, 1, N'Nhập môn đại số chương 1'), -- Nguyễn Văn A dạy Toán cho lớp 10A3
(2, 101, 2, 1, 2, N'Văn bản: Làng'),           -- Trần Thị B dạy Ngữ văn cho lớp 12A3
(3, 102, 3, 1, 3, N'Bài học về giao tiếp'),    -- Lê Văn C dạy Ngoại ngữ cho lớp 11B1
(4, 103, 4, 1, 4, N'Lịch sử thế giới cổ đại'); -- Phạm Thị D dạy Lịch sử cho lớp 10B2


-- Thêm dữ liệu mẫu vào bảng ThongBao
INSERT INTO ThongBao (MaTB, MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui) VALUES
(1, 1, NULL, 3, NULL, NULL, N'Thông báo nghỉ học', N'Thông báo nghỉ học ngày 17/4', GETDATE()),
(2, 2, 4, NULL, NULL, 1, N'Nhắc nhở học tập', N'Nhắc nhở bạn Minh Khoa chuẩn bị bài môn Toán', GETDATE()),
(3, 3, 5, NULL, NULL, 2, N'Nhắc nhở học tập', N'Nhắc nhở bạn Hồng Ngọc chuẩn bị bài môn Văn', GETDATE());

-- Thêm dữ liệu mẫu vào bảng DonXinNghi
INSERT INTO DonXinNghi (MaDon, MaHS, NgayGui, NgayNghi, LyDo, MaGV, TrangThai) VALUES
(1, 43110222, '2025-04-14', '2025-04-15', N'Nghỉ ốm', 100, N'Chờ duyệt'),
(2, 43110333, '2025-04-13', '2025-04-14', N'Gia đình có việc', 101, N'Đã duyệt'),
(3, 43110444, '2025-04-12', '2025-04-13', N'Nghỉ ốm', 100, N'Đã duyệt');

-- Thêm dữ liệu mẫu vào bảng NhatKyHeThong
INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian) VALUES
(1, 1, N'Đăng nhập', GETDATE()),
(2, 2, N'Nhập điểm môn Toán kiểm tra 15 phút học kỳ 1 cho học sinh Phạm Minh Khoa', GETDATE()),
(3, 3, N'Nhập điểm môn Văn cuối kỳ học kỳ 1 cho học sinh Lê Hồng Ngọc', GETDATE());

-- Common notification for all teachers
INSERT INTO ThongBao (MaTB, MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui)
VALUES (4, 1, NULL, 2, NULL, NULL, N'Thông báo họp giáo viên', N'Tất cả giáo viên tham gia họp vào ngày 10/05/2025.', GETDATE());

-- Personal notification for a specific teacher (e.g., MaNguoiNhan = 2)
INSERT INTO ThongBao (MaTB, MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui)
VALUES (5, 1, 2, NULL, NULL, NULL, N'Nhắc nhở công việc', N'Giáo viên Nguyễn Văn A cần hoàn thành báo cáo tuần.', GETDATE());

INSERT INTO ThongBao (MaTB, MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui)
VALUES (6, 1, NULL, NULL, NULL, NULL, N'Thông báo chung', N'Thông báo dành cho tất cả mọi người.', GETDATE());

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('ThongBao') AND name = 'isActive')
BEGIN
    ALTER TABLE ThongBao ADD isActive BIT DEFAULT 1;
    UPDATE ThongBao SET isActive = 1;
END

ALTER TABLE HocSinh
ADD MaDinhDanh NVARCHAR(20) NULL,
    NoiSinh NVARCHAR(100) NULL,
    DanToc NVARCHAR(50) NULL,
    TonGiao NVARCHAR(50) NULL,
    QuocGia NVARCHAR(50) DEFAULT N'Việt Nam',
    TinhThanh NVARCHAR(50) NULL,
    QuanHuyen NVARCHAR(50) NULL,
    XaPhuong NVARCHAR(50) NULL,
    DiaChiThuongTru NVARCHAR(200) NULL,
    SoDienThoai NVARCHAR(15) NULL,
    Email NVARCHAR(100) NULL;

    CREATE TABLE PhuHuynh (
        MaPH INT IDENTITY(1,1) PRIMARY KEY,
        MaHS INT NOT NULL,
        HoTenCha NVARCHAR(100) NULL,
        SoDienThoaiCha NVARCHAR(15) NULL,
        HoTenMe NVARCHAR(100) NULL,
        SoDienThoaiMe NVARCHAR(15) NULL,
        FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS)
    );

    ALTER TABLE HocSinh
    DROP COLUMN DiaChi;
