--CODE TẠO CƠ SỞ DỮ LIỆU
CREATE DATABASE QuanLyTruongHoc;
GO

USE QuanLyTruongHoc;
GO

-- Tạo bảng VaiTro
CREATE TABLE VaiTro (
    MaVaiTro INT PRIMARY KEY,
    TenVaiTro NVARCHAR(50) NOT NULL
);

-- Tạo bảng NguoiDung
CREATE TABLE NguoiDung (
    MaNguoiDung INT PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(100) NOT NULL,
    MaVaiTro INT NOT NULL,
    NgayTao DATETIME NOT NULL,
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro)
);

-- Tạo bảng MonHoc
CREATE TABLE MonHoc (
    MaMon INT PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL
);

-- Tạo bảng GiaoVien
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

-- Tạo bảng LopHoc
CREATE TABLE LopHoc (
    MaLop INT PRIMARY KEY,
    TenLop NVARCHAR(20) NOT NULL,
    MaGVChuNhiem INT NOT NULL,
    NamHoc NVARCHAR(20) NOT NULL,   
    FOREIGN KEY (MaGVChuNhiem) REFERENCES GiaoVien(MaGV)
);

-- Tạo bảng HocSinh 
CREATE TABLE HocSinh (
    MaHS INT PRIMARY KEY,
    MaNguoiDung INT NOT NULL UNIQUE,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    SDTPhuHuynh VARCHAR(15),
    MaLop INT NOT NULL,
    MaDinhDanh NVARCHAR(20) NULL,
    NoiSinh NVARCHAR(100) NULL,
    DanToc NVARCHAR(50) NULL,
    TonGiao NVARCHAR(50) NULL,
    QuocGia NVARCHAR(50) DEFAULT N'Việt Nam',
    TinhThanh NVARCHAR(50) NULL,
    QuanHuyen NVARCHAR(50) NULL,
    XaPhuong NVARCHAR(50) NULL,
    DiaChiThuongTru NVARCHAR(200) NULL,
    SoDienThoai NVARCHAR(15) NULL,
    Email NVARCHAR(100) NULL,
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop)
);

-- Tạo bảng PhuHuynh
CREATE TABLE PhuHuynh (
    MaPH INT IDENTITY(1,1) PRIMARY KEY,
    MaHS INT NOT NULL,
    HoTenCha NVARCHAR(100) NULL,
    SoDienThoaiCha NVARCHAR(15) NULL,
    HoTenMe NVARCHAR(100) NULL,
    SoDienThoaiMe NVARCHAR(15) NULL,
    FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS)
);

-- Tạo bảng DiemDanh
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

-- Tạo bảng DiemSo
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

-- Tạo bảng ThoiKhoaBieu
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

-- Tạo bảng KeHoachGiangDay
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

-- Tạo bảng ThongBao với cột isActive đã được thêm sẵn
CREATE TABLE ThongBao (
    MaTB INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiGui INT NOT NULL,
    MaNguoiNhan INT NULL,
    MaVaiTroNhan INT NULL,
    MaLop INT NULL,
    MaMon INT NULL,
    TieuDe NVARCHAR(200) NOT NULL,
    NoiDung NVARCHAR(MAX) NOT NULL,
    NgayGui DATETIME NOT NULL,
    isActive BIT DEFAULT 1,
    FOREIGN KEY (MaNguoiGui) REFERENCES NguoiDung(MaNguoiDung),
    FOREIGN KEY (MaNguoiNhan) REFERENCES NguoiDung(MaNguoiDung) ON DELETE CASCADE,
    FOREIGN KEY (MaVaiTroNhan) REFERENCES VaiTro(MaVaiTro),
    FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop),
    FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon)
);

-- Tạo bảng DonXinNghi
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

-- Tạo bảng NhatKyHeThong
CREATE TABLE NhatKyHeThong (
    MaNK INT PRIMARY KEY,
    MaNguoiDung INT NOT NULL,
    HanhDong NVARCHAR(200) NOT NULL,
    ThoiGian DATETIME NOT NULL,
    FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung)
);

-- Tạo bảng ThongBaoNguoiDoc
CREATE TABLE ThongBaoNguoiDoc (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MaTB INT NOT NULL,
    MaNguoiDung INT NOT NULL,
    ThoiGianDoc DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_TBND_ThongBao FOREIGN KEY (MaTB) REFERENCES ThongBao(MaTB),
    CONSTRAINT FK_TBND_NguoiDung FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
    CONSTRAINT UQ_TBND_ThongBao_NguoiDung UNIQUE (MaTB, MaNguoiDung)
);