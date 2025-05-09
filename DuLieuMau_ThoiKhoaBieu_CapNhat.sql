USE QuanLyTruongHoc;
GO

-- Đầu tiên, cập nhật lại cấu trúc bảng ThoiKhoaBieu với định dạng tiết mới
ALTER TABLE ThoiKhoaBieu
ALTER COLUMN Tiet NVARCHAR(10) NOT NULL;

-- Xóa toàn bộ dữ liệu cũ trong bảng ThoiKhoaBieu
DELETE FROM ThoiKhoaBieu;

-- Dữ liệu mẫu thời khóa biểu mới cho lớp 10A1 (MaLop = 1) - Thứ Hai
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(1, 1, 1, 7, '2025-05-05', 2, N'1-2'), -- Toán - Cô Đỗ Thị Hương
(2, 1, 5, 20, '2025-05-05', 2, N'3-4'), -- Văn - Thầy Hồ Văn Anh
(3, 1, 8, 27, '2025-05-05', 2, N'5-5'); -- Anh - Cô Dương Thị Linh

-- Dữ liệu mẫu thời khóa biểu cho lớp 10A1 (MaLop = 1) - Thứ Ba
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(4, 1, 2, 12, '2025-05-06', 3, N'1-2'), -- Lý - Thầy Hoàng Văn Phúc
(5, 1, 3, 15, '2025-05-06', 3, N'3-4'), -- Hóa - Cô Võ Thị Thảo
(6, 1, 10, 31, '2025-05-06', 3, N'5-5'); -- Thể dục - Cô Chu Thị Phượng

-- Dữ liệu mẫu thời khóa biểu cho lớp 10A1 (MaLop = 1) - Thứ Tư
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(7, 1, 1, 7, '2025-05-07', 4, N'1-1'), -- Toán - Cô Đỗ Thị Hương
(8, 1, 4, 18, '2025-05-07', 4, N'2-3'), -- Sinh - Thầy Trần Văn Xuân
(9, 1, 6, 23, '2025-05-07', 4, N'4-4'), -- Sử - Cô Lương Thị Đào
(10, 1, 7, 25, '2025-05-07', 4, N'5-5'); -- Địa - Cô Lý Thị Hoa

-- Dữ liệu mẫu thời khóa biểu cho lớp 10A1 (MaLop = 1) - Thứ Năm
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(11, 1, 1, 7, '2025-05-08', 5, N'1-2'), -- Toán - Cô Đỗ Thị Hương
(12, 1, 8, 27, '2025-05-08', 5, N'3-4'), -- Anh - Cô Dương Thị Linh
(13, 1, 11, 32, '2025-05-08', 5, N'5-5'); -- Tin - Thầy Huỳnh Văn Quân

-- Dữ liệu mẫu thời khóa biểu cho lớp 10A1 (MaLop = 1) - Thứ Sáu
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(14, 1, 5, 20, '2025-05-09', 6, N'1-2'), -- Văn - Thầy Hồ Văn Anh
(15, 1, 9, 30, '2025-05-09', 6, N'3-3'), -- GDCD - Thầy Dương Văn Oanh
(16, 1, 12, 33, '2025-05-09', 6, N'4-5'); -- Công nghệ - Cô Trần Thị Uyên

-- Dữ liệu mẫu thời khóa biểu cho lớp 10A2 (MaLop = 2) - Thứ Hai
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(17, 2, 5, 21, '2025-05-05', 2, N'1-2'), -- Văn - Cô Vũ Thị Bảo
(18, 2, 1, 8, '2025-05-05', 2, N'3-4'), -- Toán - Thầy Ngô Văn Dũng
(19, 2, 7, 25, '2025-05-05', 2, N'5-5'); -- Địa - Cô Lý Thị Hoa

-- Dữ liệu mẫu thời khóa biểu cho lớp 10A2 (MaLop = 2) - Thứ Ba
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(20, 2, 3, 15, '2025-05-06', 3, N'1-2'), -- Hóa - Cô Võ Thị Thảo
(21, 2, 2, 12, '2025-05-06', 3, N'3-4'), -- Lý - Thầy Hoàng Văn Phúc
(22, 2, 9, 30, '2025-05-06', 3, N'5-5'); -- GDCD - Thầy Dương Văn Oanh

-- Dữ liệu mẫu thời khóa biểu cho lớp 10A2 (MaLop = 2) - Thứ Tư
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(23, 2, 8, 28, '2025-05-07', 4, N'1-2'), -- Anh - Thầy Cao Văn Minh
(24, 2, 1, 8, '2025-05-07', 4, N'3-4'), -- Toán - Thầy Ngô Văn Dũng
(25, 2, 10, 31, '2025-05-07', 4, N'5-5'); -- Thể dục - Cô Chu Thị Phượng

-- Dữ liệu mẫu thời khóa biểu cho lớp 10A2 (MaLop = 2) - Thứ Năm
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(26, 2, 6, 24, '2025-05-08', 5, N'1-1'), -- Sử - Thầy Mai Văn Giang
(27, 2, 4, 19, '2025-05-08', 5, N'2-3'), -- Sinh - Cô Phạm Thị Yến
(28, 2, 11, 32, '2025-05-08', 5, N'4-5'); -- Tin - Thầy Huỳnh Văn Quân

-- Dữ liệu mẫu thời khóa biểu cho lớp 10A2 (MaLop = 2) - Thứ Sáu
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(29, 2, 1, 8, '2025-05-09', 6, N'1-1'), -- Toán - Thầy Ngô Văn Dũng
(30, 2, 5, 21, '2025-05-09', 6, N'2-3'), -- Văn - Cô Vũ Thị Bảo
(31, 2, 12, 36, '2025-05-09', 6, N'4-5'); -- Công nghệ - Thầy Phạm Văn Yên

-- Thời khóa biểu cho tuần tiếp theo
-- Dữ liệu mẫu thời khóa biểu cho lớp 10A1 (MaLop = 1) - Thứ Hai (tuần sau)
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(32, 1, 1, 7, '2025-05-12', 2, N'1-2'), -- Toán - Cô Đỗ Thị Hương
(33, 1, 5, 20, '2025-05-12', 2, N'3-4'), -- Văn - Thầy Hồ Văn Anh
(34, 1, 8, 27, '2025-05-12', 2, N'5-5'); -- Anh - Cô Dương Thị Linh

-- Dữ liệu mẫu thời khóa biểu cho lớp 10A1 (MaLop = 1) - Thứ Ba (tuần sau)
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(35, 1, 2, 12, '2025-05-13', 3, N'1-2'), -- Lý - Thầy Hoàng Văn Phúc
(36, 1, 3, 15, '2025-05-13', 3, N'3-4'), -- Hóa - Cô Võ Thị Thảo
(37, 1, 10, 31, '2025-05-13', 3, N'5-5'); -- Thể dục - Cô Chu Thị Phượng

-- Dữ liệu mẫu thời khóa biểu cho lớp 10A2 (MaLop = 2) - Thứ Hai (tuần sau)
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(38, 2, 5, 21, '2025-05-12', 2, N'1-2'), -- Văn - Cô Vũ Thị Bảo
(39, 2, 1, 8, '2025-05-12', 2, N'3-4'), -- Toán - Thầy Ngô Văn Dũng
(40, 2, 7, 25, '2025-05-12', 2, N'5-5'); -- Địa - Cô Lý Thị Hoa

-- Dữ liệu mẫu thời khóa biểu cho lớp 10A2 (MaLop = 2) - Thứ Ba (tuần sau)
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(41, 2, 3, 15, '2025-05-13', 3, N'1-2'), -- Hóa - Cô Võ Thị Thảo
(42, 2, 2, 12, '2025-05-13', 3, N'3-4'), -- Lý - Thầy Hoàng Văn Phúc
(43, 2, 9, 30, '2025-05-13', 3, N'5-5'); -- GDCD - Thầy Dương Văn Oanh

-- Dữ liệu mẫu cho tiết học kéo dài nhiều tiết
INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet) VALUES
(44, 1, 11, 32, '2025-05-14', 4, N'1-3'), -- Tin học - 3 tiết liên tục
(45, 2, 10, 31, '2025-05-14', 4, N'2-4'); -- Thể dục - 3 tiết liên tục 