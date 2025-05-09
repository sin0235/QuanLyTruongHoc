USE QuanLyTruongHoc;
GO

-- Bổ sung dữ liệu điểm số cho học sinh Đinh Văn Long (MaHS=53, MaNguoiDung=153, Lớp 10A4)
-- Học kỳ 1

-- Thêm điểm môn Toán (MaMon = 1) cho học kỳ 1, Giáo viên có MaGV = 7
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(600, 53, 1, 7, 1, N'Miệng', 7.5),
(601, 53, 1, 7, 1, N'15 phút', 8.0),
(602, 53, 1, 7, 1, N'Giữa kỳ', 7.5),
(603, 53, 1, 7, 1, N'Cuối kỳ', 8.0);

-- Thêm điểm môn Vật Lý (MaMon = 2) cho học kỳ 1, Giáo viên có MaGV = 12
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(604, 53, 2, 12, 1, N'Miệng', 8.0),
(605, 53, 2, 12, 1, N'15 phút', 7.5),
(606, 53, 2, 12, 1, N'Giữa kỳ', 8.0),
(607, 53, 2, 12, 1, N'Cuối kỳ', 7.5);

-- Thêm điểm môn Hóa Học (MaMon = 3) cho học kỳ 1, Giáo viên có MaGV = 15
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(608, 53, 3, 15, 1, N'Miệng', 7.0),
(609, 53, 3, 15, 1, N'15 phút', 7.5),
(610, 53, 3, 15, 1, N'Giữa kỳ', 7.0),
(611, 53, 3, 15, 1, N'Cuối kỳ', 7.5);

-- Thêm điểm môn Sinh Học (MaMon = 4) cho học kỳ 1, Giáo viên có MaGV = 18
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(612, 53, 4, 18, 1, N'Miệng', 8.5),
(613, 53, 4, 18, 1, N'15 phút', 8.0),
(614, 53, 4, 18, 1, N'Giữa kỳ', 8.5),
(615, 53, 4, 18, 1, N'Cuối kỳ', 8.0);

-- Thêm điểm môn Ngữ Văn (MaMon = 5) cho học kỳ 1, Giáo viên có MaGV = 20
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(616, 53, 5, 20, 1, N'Miệng', 7.5),
(617, 53, 5, 20, 1, N'15 phút', 8.0),
(618, 53, 5, 20, 1, N'Giữa kỳ', 7.5),
(619, 53, 5, 20, 1, N'Cuối kỳ', 8.0);

-- Thêm điểm môn Lịch Sử (MaMon = 6) cho học kỳ 1, Giáo viên có MaGV = 23
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(620, 53, 6, 23, 1, N'Miệng', 8.0),
(621, 53, 6, 23, 1, N'15 phút', 7.5),
(622, 53, 6, 23, 1, N'Giữa kỳ', 8.0),
(623, 53, 6, 23, 1, N'Cuối kỳ', 7.5);

-- Thêm điểm môn Địa Lý (MaMon = 7) cho học kỳ 1, Giáo viên có MaGV = 25
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(624, 53, 7, 25, 1, N'Miệng', 7.0),
(625, 53, 7, 25, 1, N'15 phút', 7.5),
(626, 53, 7, 25, 1, N'Giữa kỳ', 7.0),
(627, 53, 7, 25, 1, N'Cuối kỳ', 7.5);

-- Thêm điểm môn Tiếng Anh (MaMon = 8) cho học kỳ 1, Giáo viên có MaGV = 27
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(628, 53, 8, 27, 1, N'Miệng', 8.5),
(629, 53, 8, 27, 1, N'15 phút', 9.0),
(630, 53, 8, 27, 1, N'Giữa kỳ', 8.5),
(631, 53, 8, 27, 1, N'Cuối kỳ', 9.0);

-- Thêm điểm môn Giáo Dục Công Dân (MaMon = 9) cho học kỳ 1, Giáo viên có MaGV = 30
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(632, 53, 9, 30, 1, N'Miệng', 9.0),
(633, 53, 9, 30, 1, N'15 phút', 8.5),
(634, 53, 9, 30, 1, N'Giữa kỳ', 9.0),
(635, 53, 9, 30, 1, N'Cuối kỳ', 8.5);

-- Thêm điểm môn Thể Dục (MaMon = 10) cho học kỳ 1, Giáo viên có MaGV = 31
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(636, 53, 10, 31, 1, N'Thực hành', 9.0),
(637, 53, 10, 31, 1, N'Giữa kỳ', 8.5),
(638, 53, 10, 31, 1, N'Cuối kỳ', 9.0);

-- Thêm điểm môn Tin Học (MaMon = 11) cho học kỳ 1, Giáo viên có MaGV = 32
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(639, 53, 11, 32, 1, N'Miệng', 8.0),
(640, 53, 11, 32, 1, N'15 phút', 8.5),
(641, 53, 11, 32, 1, N'Giữa kỳ', 8.0),
(642, 53, 11, 32, 1, N'Cuối kỳ', 8.5);

-- Thêm điểm môn Công Nghệ (MaMon = 12) cho học kỳ 1, Giáo viên có MaGV = 33
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(643, 53, 12, 33, 1, N'Miệng', 7.5),
(644, 53, 12, 33, 1, N'15 phút', 8.0),
(645, 53, 12, 33, 1, N'Giữa kỳ', 7.5),
(646, 53, 12, 33, 1, N'Cuối kỳ', 8.0); 