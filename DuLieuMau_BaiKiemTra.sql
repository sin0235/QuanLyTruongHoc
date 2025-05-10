USE QuanLyTruongHoc;
GO

-- Dữ liệu mẫu cho BaiKiemTra
INSERT INTO BaiKiemTra (MaBaiKT, TenBaiKT, MaMon, MaGV, ThoiGianLamBai, NgayTao, HocKy, NamHoc, MoTa, TrangThai, ThoiGianBatDau, ThoiGianKetThuc, DiemDatYeuCau, SoLanLamToiDa, LoaiBaiKiemTra, HienThiKetQuaNgay, XaoTronCauHoi, GhiChuChamDiem, CoMatKhau, MatKhau) VALUES
(1, N'Kiểm tra 15 phút Toán đại số', 1, 7, 15, '2025-05-10', 1, N'2025-2025', N'Kiểm tra nhanh về kiến thức đại số', N'Đã công bố', '2025-05-11 08:00:00', '2025-05-14 17:00:00', 5.0, 1, N'Kiểm tra 15 phút', 1, 0, NULL, 0, NULL),
(2, N'Kiểm tra 45 phút Toán hình học', 1, 7, 45, '2025-05-10', 1, N'2025-2025', N'Kiểm tra chương hình học không gian', N'Đã công bố', '2025-05-11 08:00:00', '2025-05-14 17:00:00', 5.0, 2, N'Kiểm tra 45 phút', 1, 0, NULL, 0, NULL),
(3, N'Kiểm tra 15 phút Vật lý', 2, 12, 15, '2025-05-10', 1, N'2025-2025', N'Kiểm tra nhanh về kiến thức cơ học', N'Đã công bố', '2025-05-11 08:00:00', '2025-05-14 17:00:00', 5.0, 3, N'Kiểm tra 15 phút', 1, 1, NULL, 0, NULL);

-- Dữ liệu mẫu cho CauHoiTracNghiem
INSERT INTO CauHoiTracNghiem (MaCauHoiTN, NoiDung, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung, Diem, DoKho, NgayTao, MaMon, MaGV) VALUES
(1, N'Kết quả của phép tính 5 + 3 × 2 là:', N'16', N'11', N'10', N'8', 'B', 1, 1, '2025-05-10', 1, 7),
(2, N'Phương trình x² - 4 = 0 có nghiệm là:', N'x = ±2', N'x = ±4', N'x = 2', N'x = -2', 'A', 1, 2, '2025-05-10', 1, 7),
(3, N'Đạo hàm của hàm số f(x) = x² là:', N'f''(x) = x', N'f''(x) = 2x', N'f''(x) = x²', N'f''(x) = 2', 'B', 1, 3, '2025-05-10', 1, 7),
(4, N'Một vật rơi tự do từ độ cao h. Sau thời gian t giây thì vận tốc của vật là:', N'v = gt', N'v = g²t', N'v = g/t', N'v = g', 'A', 1, 2, '2025-05-10', 2, 12),
(5, N'Đơn vị đo lực trong hệ SI là:', N'Pascal', N'Newton', N'Joule', N'Watt', 'B', 1, 1, '2025-05-10', 2, 12),
(6, N'Biểu thức nào sau đây không đúng?', N'1 N = 1 kg×m/s²', N'1 J = 1 N×m', N'1 W = 1 J/s', N'1 Pa = 1 N/m', 'D', 1, 3, '2025-05-10', 2, 12);

-- Dữ liệu mẫu cho BaiKiemTra_CauHoi
INSERT INTO BaiKiemTra_CauHoi (MaBaiKT, MaCauHoiTL, MaCauHoiTN, ThuTu) VALUES
(1, NULL, 1, 1),
(1, NULL, 2, 2),
(1, NULL, 3, 3),
(3, NULL, 4, 1),
(3, NULL, 5, 2),
(3, NULL, 6, 3);

-- Dữ liệu mẫu cho BaiKiemTra_LopHoc
INSERT INTO BaiKiemTra_LopHoc (MaBaiKT, MaLop, NgayKiemTra, TrangThai) VALUES
(1, 1, '2025-05-11 08:00:00', N'Đang diễn ra'),
(2, 1, '2025-05-11 09:00:00', N'Đang diễn ra'),
(3, 1, '2025-05-11 10:00:00', N'Đang diễn ra');

-- Dữ liệu mẫu cho BaiLam
-- Học sinh lớp 10A1 làm bài theo giới hạn SoLanLamToiDa

-- BÀI KIỂM TRA 1: SoLanLamToiDa = 1, mỗi học sinh chỉ làm 1 lần
INSERT INTO BaiLam (MaBaiLam, MaBaiKT, MaHS, NgayLam, ThoiGianLamBai, DiemSo, DaNop) VALUES
(1, 1, 1, '2025-05-11 08:15:00', 12, 8.0, 1),
(2, 1, 2, '2025-05-11 08:20:00', 14, 7.5, 1),
(3, 1, 3, '2025-05-11 08:10:00', 10, 9.0, 1),
(4, 1, 4, '2025-05-11 08:12:00', 13, 6.5, 1),
(5, 1, 5, '2025-05-11 08:14:00', 11, 8.5, 1),
(6, 1, 6, '2025-05-11 08:13:00', 13, 7.0, 1),
(7, 1, 7, '2025-05-11 08:11:00', 12, 9.5, 1),
(8, 1, 8, '2025-05-11 08:09:00', 14, 6.0, 1),
(9, 1, 9, '2025-05-11 08:17:00', 12, 8.0, 1),
(10, 1, 10, '2025-05-11 08:19:00', 13, 7.5, 1),
(11, 1, 11, '2025-05-11 08:20:00', 11, 9.0, 1),
(12, 1, 12, '2025-05-11 08:18:00', 14, 6.5, 1),
(13, 1, 13, '2025-05-11 08:22:00', 12, 8.5, 1),
(14, 1, 14, '2025-05-11 08:16:00', 10, 7.0, 1),
(15, 1, 15, '2025-05-11 08:21:00', 13, 9.5, 1);

-- BÀI KIỂM TRA 2: SoLanLamToiDa = 2, mỗi học sinh làm tối đa 2 lần
-- Lần làm thứ nhất
INSERT INTO BaiLam (MaBaiLam, MaBaiKT, MaHS, NgayLam, ThoiGianLamBai, DiemSo, DaNop) VALUES
(16, 2, 1, '2025-05-11 09:10:00', 40, 6.0, 1),
(17, 2, 2, '2025-05-11 09:15:00', 38, 5.5, 1),
(18, 2, 3, '2025-05-11 09:12:00', 42, 7.0, 1),
(19, 2, 4, '2025-05-11 09:14:00', 39, 4.5, 1),
(20, 2, 5, '2025-05-11 09:18:00', 40, 6.5, 1),
(21, 2, 6, '2025-05-11 09:13:00', 41, 5.0, 1),
(22, 2, 7, '2025-05-11 09:11:00', 43, 8.0, 1),
(23, 2, 8, '2025-05-11 09:16:00', 38, 4.0, 1),
(24, 2, 9, '2025-05-11 09:15:00', 40, 6.0, 1),
(25, 2, 10, '2025-05-11 09:17:00', 42, 5.5, 1),
(26, 2, 11, '2025-05-11 09:14:00', 39, 7.0, 1),
(27, 2, 12, '2025-05-11 09:20:00', 41, 4.5, 1),
(28, 2, 13, '2025-05-11 09:12:00', 40, 6.5, 1),
(29, 2, 14, '2025-05-11 09:19:00', 37, 5.0, 1),
(30, 2, 15, '2025-05-11 09:21:00', 42, 8.0, 1);

-- Lần làm thứ hai (chỉ những học sinh có điểm dưới 5.0 mới làm lại)
INSERT INTO BaiLam (MaBaiLam, MaBaiKT, MaHS, NgayLam, ThoiGianLamBai, DiemSo, DaNop) VALUES
(31, 2, 4, '2025-05-12 15:10:00', 43, 6.0, 1),
(32, 2, 8, '2025-05-12 15:15:00', 42, 5.5, 1),
(33, 2, 12, '2025-05-12 15:20:00', 44, 6.5, 1);

-- BÀI KIỂM TRA 3: SoLanLamToiDa = 3, mỗi học sinh có thể làm tối đa 3 lần
-- Lần làm thứ nhất (tất cả học sinh)
INSERT INTO BaiLam (MaBaiLam, MaBaiKT, MaHS, NgayLam, ThoiGianLamBai, DiemSo, DaNop) VALUES
(34, 3, 1, '2025-05-11 10:05:00', 13, 5.0, 1),
(35, 3, 2, '2025-05-11 10:08:00', 12, 4.5, 1),
(36, 3, 3, '2025-05-11 10:06:00', 14, 6.0, 1),
(37, 3, 4, '2025-05-11 10:07:00', 13, 3.5, 1),
(38, 3, 5, '2025-05-11 10:09:00', 12, 7.0, 1),
(39, 3, 6, '2025-05-11 10:10:00', 11, 4.0, 1),
(40, 3, 7, '2025-05-11 10:12:00', 13, 6.5, 1),
(41, 3, 8, '2025-05-11 10:11:00', 12, 3.0, 1),
(42, 3, 9, '2025-05-11 10:08:00', 14, 5.5, 1),
(43, 3, 10, '2025-05-11 10:07:00', 13, 4.0, 1),
(44, 3, 11, '2025-05-11 10:09:00', 12, 7.5, 1),
(45, 3, 12, '2025-05-11 10:10:00', 13, 3.5, 1),
(46, 3, 13, '2025-05-11 10:11:00', 14, 6.0, 1),
(47, 3, 14, '2025-05-11 10:09:00', 12, 4.5, 1),
(48, 3, 15, '2025-05-11 10:08:00', 13, 8.0, 1);

-- Lần làm thứ hai (những học sinh có điểm dưới 5.0)
INSERT INTO BaiLam (MaBaiLam, MaBaiKT, MaHS, NgayLam, ThoiGianLamBai, DiemSo, DaNop) VALUES
(49, 3, 2, '2025-05-12 15:05:00', 14, 5.5, 1),
(50, 3, 4, '2025-05-12 15:08:00', 13, 4.0, 1),
(51, 3, 6, '2025-05-12 15:10:00', 12, 5.0, 1),
(52, 3, 8, '2025-05-12 15:12:00', 14, 4.5, 1),
(53, 3, 10, '2025-05-12 15:15:00', 13, 6.0, 1),
(54, 3, 12, '2025-05-12 15:18:00', 12, 4.0, 1),
(55, 3, 14, '2025-05-12 15:20:00', 13, 5.5, 1);

-- Lần làm thứ ba (chỉ những học sinh vẫn chưa đạt sau 2 lần làm)
INSERT INTO BaiLam (MaBaiLam, MaBaiKT, MaHS, NgayLam, ThoiGianLamBai, DiemSo, DaNop) VALUES
(56, 3, 4, '2025-05-13 15:05:00', 14, 5.0, 1),
(57, 3, 8, '2025-05-13 15:10:00', 13, 5.5, 1),
(58, 3, 12, '2025-05-13 15:15:00', 14, 6.0, 1);

-- BaiLam_TracNghiem cho Bài Kiểm Tra 1 (chỉ làm mẫu cho 3 câu hỏi của học sinh đầu tiên)
INSERT INTO BaiLam_TracNghiem (MaBaiLam, MaCauHoiTN, CauTraLoi, Diem) VALUES
-- Học sinh 1, bài làm 1
(1, 1, 'B', 1.0),
(1, 2, 'A', 1.0),
(1, 3, 'B', 1.0);

-- BaiLam_TracNghiem cho Bài Kiểm Tra 3 (chỉ làm mẫu cho 3 câu hỏi của học sinh làm 3 lần)
INSERT INTO BaiLam_TracNghiem (MaBaiLam, MaCauHoiTN, CauTraLoi, Diem) VALUES
-- Học sinh 4, lần làm thứ nhất
(37, 4, 'C', 0.0),
(37, 5, 'B', 1.0),
(37, 6, 'D', 0.0),
-- Học sinh 4, lần làm thứ hai  
(50, 4, 'A', 1.0),
(50, 5, 'B', 1.0),
(50, 6, 'D', 0.0),
-- Học sinh 4, lần làm thứ ba
(56, 4, 'A', 1.0),
(56, 5, 'B', 1.0),
(56, 6, 'C', 0.0);

-- Tạo stored procedure để kiểm tra số lần làm bài
GO
CREATE OR ALTER PROCEDURE sp_KiemTraLuotLamBaiHopLe
    @MaBaiKT INT,
    @MaHS INT,
    @KetQua BIT OUTPUT,
    @ThongBaoLoi NVARCHAR(500) OUTPUT
AS
BEGIN
    DECLARE @SoLanLamToiDa INT;
    DECLARE @SoLanDaLam INT;
    DECLARE @ThoiGianBatDau DATETIME;
    DECLARE @ThoiGianKetThuc DATETIME;
    
    -- Lấy thông tin số lần làm tối đa và thời gian của bài kiểm tra
    SELECT @SoLanLamToiDa = SoLanLamToiDa,
           @ThoiGianBatDau = ThoiGianBatDau,
           @ThoiGianKetThuc = ThoiGianKetThuc
    FROM BaiKiemTra 
    WHERE MaBaiKT = @MaBaiKT;
    
    -- Đếm số lần học sinh đã làm bài
    SELECT @SoLanDaLam = COUNT(*)
    FROM BaiLam
    WHERE MaBaiKT = @MaBaiKT AND MaHS = @MaHS;
    
    -- Mặc định là hợp lệ
    SET @KetQua = 1;
    SET @ThongBaoLoi = N'';
    
    -- Kiểm tra nếu ngoài thời gian cho phép
    IF (GETDATE() < @ThoiGianBatDau)
    BEGIN
        SET @KetQua = 0;
        SET @ThongBaoLoi = N'Bài kiểm tra chưa bắt đầu';
        RETURN;
    END
    
    IF (GETDATE() > @ThoiGianKetThuc)
    BEGIN
        SET @KetQua = 0;
        SET @ThongBaoLoi = N'Bài kiểm tra đã kết thúc';
        RETURN;
    END
    
    -- Kiểm tra số lần làm bài
    IF (@SoLanDaLam >= @SoLanLamToiDa)
    BEGIN
        SET @KetQua = 0;
        SET @ThongBaoLoi = N'Bạn đã sử dụng hết số lần làm bài cho phép (' + CAST(@SoLanLamToiDa AS NVARCHAR) + N' lần)';
        RETURN;
    END
END
GO

-- Tạo trigger để kiểm tra trước khi thêm bài làm
CREATE OR ALTER TRIGGER tr_KiemTraLuotLamBai
ON BaiLam
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @MaBaiKT INT;
    DECLARE @MaHS INT;
    DECLARE @KetQua BIT;
    DECLARE @ThongBaoLoi NVARCHAR(500);
    
    -- Lấy thông tin từ dữ liệu chèn vào
    SELECT @MaBaiKT = MaBaiKT, @MaHS = MaHS
    FROM inserted;
    
    -- Kiểm tra hợp lệ
    EXEC sp_KiemTraLuotLamBaiHopLe @MaBaiKT, @MaHS, @KetQua OUTPUT, @ThongBaoLoi OUTPUT;
    
    -- Nếu hợp lệ thì thêm dữ liệu
    IF (@KetQua = 1)
    BEGIN
        INSERT INTO BaiLam (MaBaiKT, MaHS, NgayLam, ThoiGianLamBai, DiemSo, DaNop)
        SELECT MaBaiKT, MaHS, NgayLam, ThoiGianLamBai, DiemSo, DaNop
        FROM inserted;
    END
    ELSE
    BEGIN
        -- Thông báo lỗi nếu không hợp lệ
        RAISERROR(@ThongBaoLoi, 16, 1);
        ROLLBACK TRANSACTION;
    END
END
GO

-- Tạo function để kiểm tra số lượt làm bài còn lại của học sinh
CREATE OR ALTER FUNCTION fn_SoLuotLamBaiConLai(
    @MaBaiKT INT,
    @MaHS INT
)
RETURNS INT
AS
BEGIN
    DECLARE @SoLanLamToiDa INT;
    DECLARE @SoLanDaLam INT;
    
    -- Lấy thông tin số lần làm tối đa
    SELECT @SoLanLamToiDa = SoLanLamToiDa
    FROM BaiKiemTra 
    WHERE MaBaiKT = @MaBaiKT;
    
    -- Đếm số lần học sinh đã làm bài
    SELECT @SoLanDaLam = COUNT(*)
    FROM BaiLam
    WHERE MaBaiKT = @MaBaiKT AND MaHS = @MaHS;
    
    -- Trả về số lượt còn lại
    RETURN (@SoLanLamToiDa - @SoLanDaLam);
END
GO

-- Ví dụ sử dụng thử stored procedure để kiểm tra
-- DECLARE @KetQua BIT;
-- DECLARE @ThongBao NVARCHAR(500);
-- EXEC sp_KiemTraLuotLamBaiHopLe 1, 1, @KetQua OUTPUT, @ThongBao OUTPUT;
-- SELECT @KetQua AS KetQua, @ThongBao AS ThongBao;

-- SELECT dbo.fn_SoLuotLamBaiConLai(1, 1) AS SoLuotConLai;
-- SELECT dbo.fn_SoLuotLamBaiConLai(2, 4) AS SoLuotConLai;
-- SELECT dbo.fn_SoLuotLamBaiConLai(3, 4) AS SoLuotConLai;

-- Truy vấn mẫu để kiểm tra thông tin về thời gian kiểm tra
GO

-- 1. Kiểm tra thông tin thời gian bắt đầu và kết thúc của các bài kiểm tra
SELECT 
    MaBaiKT, 
    TenBaiKT, 
    ThoiGianBatDau, 
    ThoiGianKetThuc,
    DATEDIFF(DAY, ThoiGianBatDau, ThoiGianKetThuc) AS SoNgayLamBai,
    TrangThai,
    SoLanLamToiDa
FROM BaiKiemTra;

-- 2. Kiểm tra xem bài kiểm tra có đang trong thời gian làm bài không (giả sử ngày hiện tại là 11/5/2025)
DECLARE @NgayHienTai DATETIME = '2025-05-11 12:00:00';
SELECT 
    MaBaiKT, 
    TenBaiKT,
    ThoiGianBatDau, 
    ThoiGianKetThuc,
    CASE 
        WHEN @NgayHienTai < ThoiGianBatDau THEN N'Chưa bắt đầu'
        WHEN @NgayHienTai > ThoiGianKetThuc THEN N'Đã kết thúc'
        ELSE N'Đang diễn ra'
    END AS TrangThaiThucTe
FROM BaiKiemTra;

-- 3. Kiểm tra số lượt làm bài đã sử dụng và còn lại của học sinh đối với mỗi bài kiểm tra
SELECT 
    bk.MaBaiKT, 
    bk.TenBaiKT,
    hs.MaHS,
    hs.HoTen,
    bk.SoLanLamToiDa,
    COUNT(bl.MaBaiLam) AS SoLanDaLam,
    bk.SoLanLamToiDa - COUNT(bl.MaBaiLam) AS SoLanConLai
FROM 
    BaiKiemTra bk
CROSS JOIN 
    HocSinh hs
LEFT JOIN 
    BaiLam bl ON bk.MaBaiKT = bl.MaBaiKT AND hs.MaHS = bl.MaHS
WHERE 
    hs.MaHS = 4 -- Lấy ví dụ học sinh có mã 4
GROUP BY 
    bk.MaBaiKT, bk.TenBaiKT, hs.MaHS, hs.HoTen, bk.SoLanLamToiDa
ORDER BY 
    bk.MaBaiKT;

-- 4. Kiểm tra kết quả của hàm fn_SoLuotLamBaiConLai
SELECT 
    MaHS,
    dbo.fn_SoLuotLamBaiConLai(1, MaHS) AS ConLai_BKT1,
    dbo.fn_SoLuotLamBaiConLai(2, MaHS) AS ConLai_BKT2,
    dbo.fn_SoLuotLamBaiConLai(3, MaHS) AS ConLai_BKT3
FROM 
    HocSinh
WHERE 
    MaHS BETWEEN 1 AND 5;

-- 5. Thử nghiệm với stored procedure sp_KiemTraLuotLamBaiHopLe
DECLARE @KetQua BIT;
DECLARE @ThongBao NVARCHAR(500);
DECLARE @MaBaiKT INT = 3;
DECLARE @MaHS INT = 4;

EXEC sp_KiemTraLuotLamBaiHopLe @MaBaiKT, @MaHS, @KetQua OUTPUT, @ThongBao OUTPUT;

SELECT 
    @MaBaiKT AS MaBaiKT,
    @MaHS AS MaHS,
    @KetQua AS KetQua,
    @ThongBao AS ThongBao,
    dbo.fn_SoLuotLamBaiConLai(@MaBaiKT, @MaHS) AS SoLuotConLai; 