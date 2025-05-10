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


    -- Table for storing test information
CREATE TABLE BaiKiemTra (
    MaBaiKT INT IDENTITY(1,1) PRIMARY KEY,
    TenBaiKT NVARCHAR(255) NOT NULL,
    MaMon INT NOT NULL,  -- Foreign key to MonHoc table
    MaGV INT NOT NULL,   -- Foreign key to GiaoVien table  
    ThoiGianLamBai INT NOT NULL, -- Time in minutes
    NgayTao DATETIME DEFAULT GETDATE(),
    HocKy INT NOT NULL,  -- 1 or 2 for semester
    NamHoc NVARCHAR(20) NOT NULL, -- e.g., "2024-2025"
    MoTa NVARCHAR(500) NULL,
    TrangThai NVARCHAR(50) DEFAULT N'Chưa công bố', -- Status: "Chưa công bố", "Đã công bố", "Đã kết thúc"
    CONSTRAINT FK_BaiKiemTra_MonHoc FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon),
    CONSTRAINT FK_BaiKiemTra_GiaoVien FOREIGN KEY (MaGV) REFERENCES GiaoVien(MaGV)
)
GO

-- Table for storing essay questions (Tự luận - TL)
CREATE TABLE CauHoiTuLuan (
    MaCauHoiTL INT IDENTITY(1,1) PRIMARY KEY,
    NoiDung NVARCHAR(MAX) NOT NULL, -- Question content
    DapAn NVARCHAR(MAX) NULL,      -- Answer key/guide
    Diem FLOAT NOT NULL,           -- Point value for this question
    DoKho INT NOT NULL,            -- Difficulty level (1-5)
    NgayTao DATETIME DEFAULT GETDATE(),
    MaMon INT NOT NULL,            -- Subject ID
    MaGV INT NOT NULL,             -- Teacher who created the question
    CONSTRAINT FK_CauHoiTL_MonHoc FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon),
    CONSTRAINT FK_CauHoiTL_GiaoVien FOREIGN KEY (MaGV) REFERENCES GiaoVien(MaGV)
)
GO

-- Table for storing multiple-choice questions (Trắc nghiệm - TN)
CREATE TABLE CauHoiTracNghiem (
    MaCauHoiTN INT IDENTITY(1,1) PRIMARY KEY,
    NoiDung NVARCHAR(MAX) NOT NULL, -- Question content
    DapAnA NVARCHAR(500) NOT NULL,
    DapAnB NVARCHAR(500) NOT NULL,
    DapAnC NVARCHAR(500) NULL,
    DapAnD NVARCHAR(500) NULL,
    DapAnDung CHAR(1) NOT NULL,     -- Correct answer: 'A', 'B', 'C', or 'D'
    Diem FLOAT NOT NULL,            -- Point value for this question
    DoKho INT NOT NULL,             -- Difficulty level (1-5)
    NgayTao DATETIME DEFAULT GETDATE(),
    MaMon INT NOT NULL,             -- Subject ID
    MaGV INT NOT NULL,              -- Teacher who created the question
    CONSTRAINT FK_CauHoiTN_MonHoc FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon),
    CONSTRAINT FK_CauHoiTN_GiaoVien FOREIGN KEY (MaGV) REFERENCES GiaoVien(MaGV),
    CONSTRAINT CK_DapAnDung CHECK (DapAnDung IN ('A', 'B', 'C', 'D'))
)
GO

-- Mapping table to associate questions with tests
CREATE TABLE BaiKiemTra_CauHoi (
    MaBaiKT INT NOT NULL,
    MaCauHoiTL INT NULL,
    MaCauHoiTN INT NULL,
    ThuTu INT NOT NULL,  -- Order of questions in the test
    CONSTRAINT PK_BaiKiemTra_CauHoi PRIMARY KEY (MaBaiKT, ThuTu),
    CONSTRAINT FK_BaiKiemTra_CauHoi_BaiKT FOREIGN KEY (MaBaiKT) REFERENCES BaiKiemTra(MaBaiKT),
    CONSTRAINT FK_BaiKiemTra_CauHoi_TL FOREIGN KEY (MaCauHoiTL) REFERENCES CauHoiTuLuan(MaCauHoiTL),
    CONSTRAINT FK_BaiKiemTra_CauHoi_TN FOREIGN KEY (MaCauHoiTN) REFERENCES CauHoiTracNghiem(MaCauHoiTN),
    -- Ensure that either MaCauHoiTL or MaCauHoiTN is not null, but not both
    CONSTRAINT CK_Either_TL_or_TN CHECK (
        (MaCauHoiTL IS NULL AND MaCauHoiTN IS NOT NULL) OR
        (MaCauHoiTL IS NOT NULL AND MaCauHoiTN IS NULL)
    )
)
GO

-- Table for storing student test submissions
CREATE TABLE BaiLam (
    MaBaiLam INT IDENTITY(1,1) PRIMARY KEY,
    MaBaiKT INT NOT NULL,
    MaHS INT NOT NULL,  -- Student ID
    NgayLam DATETIME DEFAULT GETDATE(),
    ThoiGianLamBai INT NOT NULL, -- Time spent in minutes
    DiemSo FLOAT NULL,  -- Score (null until graded)
    DaNop BIT DEFAULT 0, -- 0 = not submitted, 1 = submitted
    CONSTRAINT FK_BaiLam_BaiKT FOREIGN KEY (MaBaiKT) REFERENCES BaiKiemTra(MaBaiKT),
    CONSTRAINT FK_BaiLam_HocSinh FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS)
)
GO

-- Table for storing student answers for multiple-choice questions
CREATE TABLE BaiLam_TracNghiem (
    MaBaiLam INT NOT NULL,
    MaCauHoiTN INT NOT NULL,
    CauTraLoi CHAR(1) NULL, -- A, B, C, or D; NULL if not answered
    Diem FLOAT NULL,       -- Points earned for this question
    CONSTRAINT PK_BaiLam_TracNghiem PRIMARY KEY (MaBaiLam, MaCauHoiTN),
    CONSTRAINT FK_BaiLam_TN_BaiLam FOREIGN KEY (MaBaiLam) REFERENCES BaiLam(MaBaiLam),
    CONSTRAINT FK_BaiLam_TN_CauHoi FOREIGN KEY (MaCauHoiTN) REFERENCES CauHoiTracNghiem(MaCauHoiTN),
    CONSTRAINT CK_CauTraLoi CHECK (CauTraLoi IN ('A', 'B', 'C', 'D') OR CauTraLoi IS NULL)
)
GO

-- Table for storing student answers for essay questions
CREATE TABLE BaiLam_TuLuan (
    MaBaiLam INT NOT NULL,
    MaCauHoiTL INT NOT NULL,
    CauTraLoi NVARCHAR(MAX) NULL, -- Essay answer; NULL if not answered
    Diem FLOAT NULL,             -- Points earned for this question
    NhanXet NVARCHAR(500) NULL,  -- Teacher's feedback/comment
    CONSTRAINT PK_BaiLam_TuLuan PRIMARY KEY (MaBaiLam, MaCauHoiTL),
    CONSTRAINT FK_BaiLam_TL_BaiLam FOREIGN KEY (MaBaiLam) REFERENCES BaiLam(MaBaiLam),
    CONSTRAINT FK_BaiLam_TL_CauHoi FOREIGN KEY (MaCauHoiTL) REFERENCES CauHoiTuLuan(MaCauHoiTL)
)
GO

-- Table for assigning tests to specific classes
CREATE TABLE BaiKiemTra_LopHoc (
    MaBaiKT INT NOT NULL,
    MaLop INT NOT NULL,
    NgayKiemTra DATETIME NOT NULL, -- Scheduled test date
    TrangThai NVARCHAR(50) DEFAULT N'Chưa bắt đầu', -- Status: "Chưa bắt đầu", "Đang diễn ra", "Đã kết thúc"
    CONSTRAINT PK_BaiKiemTra_LopHoc PRIMARY KEY (MaBaiKT, MaLop),
    CONSTRAINT FK_BaiKiemTra_LopHoc_BaiKT FOREIGN KEY (MaBaiKT) REFERENCES BaiKiemTra(MaBaiKT),
    CONSTRAINT FK_BaiKiemTra_LopHoc_Lop FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop)
)



ALTER TABLE BaiKiemTra ADD
    ThoiGianBatDau DATETIME NOT NULL,
    ThoiGianKetThuc DATETIME NOT NULL,
    DiemDatYeuCau FLOAT NOT NULL DEFAULT 5.0,
    SoLanLamToiDa INT NOT NULL DEFAULT 1,
    LoaiBaiKiemTra NVARCHAR(50) NULL DEFAULT N'Bài kiểm tra',
    HienThiKetQuaNgay BIT NOT NULL DEFAULT 1,
    XaoTronCauHoi BIT NOT NULL DEFAULT 0,
    GhiChuChamDiem NVARCHAR(500) NULL,
    CoMatKhau BIT NOT NULL DEFAULT 0,
    MatKhau NVARCHAR(100) NULL;
