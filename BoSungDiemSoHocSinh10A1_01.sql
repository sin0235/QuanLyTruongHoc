USE QuanLyTruongHoc;
GO

-- Bổ sung dữ liệu điểm số cho học sinh Nguyễn Văn An (MaHS=1, MaNguoiDung=101, Lớp 10A1)
-- Thêm điểm môn Vật Lý (MaMon = 2) cho học kỳ 1, Giáo viên có MaGV = 12
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(501, 1, 2, 12, 1, N'Miệng', 8.0),
(502, 1, 2, 12, 1, N'15 phút', 7.5),
(503, 1, 2, 12, 1, N'Giữa kỳ', 8.0),
(504, 1, 2, 12, 1, N'Cuối kỳ', 7.5);

-- Thêm điểm môn Ngữ Văn (MaMon = 5) cho học kỳ 1, Giáo viên có MaGV = 20
-- (Học sinh đã có điểm Cuối kỳ của Văn học kỳ 1, chỉ bổ sung các loại điểm còn lại)
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(505, 1, 5, 20, 1, N'Miệng', 7.5),
(506, 1, 5, 20, 1, N'15 phút', 8.0),
(507, 1, 5, 20, 1, N'Giữa kỳ', 7.5);

-- Thêm điểm môn Lịch Sử (MaMon = 6) cho học kỳ 1, Giáo viên có MaGV = 23
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(508, 1, 6, 23, 1, N'Miệng', 8.5),
(509, 1, 6, 23, 1, N'15 phút', 8.0),
(510, 1, 6, 23, 1, N'Giữa kỳ', 8.5),
(511, 1, 6, 23, 1, N'Cuối kỳ', 8.0);

-- Thêm điểm môn Địa Lý (MaMon = 7) cho học kỳ 1, Giáo viên có MaGV = 25
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(512, 1, 7, 25, 1, N'Miệng', 7.0),
(513, 1, 7, 25, 1, N'15 phút', 7.5),
(514, 1, 7, 25, 1, N'Giữa kỳ', 7.0),
(515, 1, 7, 25, 1, N'Cuối kỳ', 7.5);

-- Thêm điểm môn Tiếng Anh (MaMon = 8) cho học kỳ 1, Giáo viên có MaGV = 27
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(516, 1, 8, 27, 1, N'Miệng', 8.5),
(517, 1, 8, 27, 1, N'15 phút', 8.0),
(518, 1, 8, 27, 1, N'Giữa kỳ', 8.5),
(519, 1, 8, 27, 1, N'Cuối kỳ', 8.0);

-- Thêm điểm môn Giáo Dục Công Dân (MaMon = 9) cho học kỳ 1, Giáo viên có MaGV = 30
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(520, 1, 9, 30, 1, N'Miệng', 9.0),
(521, 1, 9, 30, 1, N'15 phút', 8.5),
(522, 1, 9, 30, 1, N'Giữa kỳ', 9.0),
(523, 1, 9, 30, 1, N'Cuối kỳ', 8.5);

-- Thêm điểm môn Thể Dục (MaMon = 10) cho học kỳ 1, Giáo viên có MaGV = 31
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(524, 1, 10, 31, 1, N'Thực hành', 9.0),
(525, 1, 10, 31, 1, N'Giữa kỳ', 8.5),
(526, 1, 10, 31, 1, N'Cuối kỳ', 9.0);

-- Thêm điểm môn Tin Học (MaMon = 11) cho học kỳ 1, Giáo viên có MaGV = 32
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(527, 1, 11, 32, 1, N'Miệng', 8.0),
(528, 1, 11, 32, 1, N'15 phút', 8.5),
(529, 1, 11, 32, 1, N'Giữa kỳ', 8.0),
(530, 1, 11, 32, 1, N'Cuối kỳ', 8.5);

-- Thêm điểm môn Công Nghệ (MaMon = 12) cho học kỳ 1, Giáo viên có MaGV = 33
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(531, 1, 12, 33, 1, N'Miệng', 7.5),
(532, 1, 12, 33, 1, N'15 phút', 8.0),
(533, 1, 12, 33, 1, N'Giữa kỳ', 7.5),
(534, 1, 12, 33, 1, N'Cuối kỳ', 8.0);

-- HỌC KỲ 2 - Bổ sung các môn còn thiếu điểm cho học kỳ 2

-- Thêm điểm môn Vật Lý (MaMon = 2) cho học kỳ 2, Giáo viên có MaGV = 12
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(535, 1, 2, 12, 2, N'Kiểm tra miệng', 7.5),
(536, 1, 2, 12, 2, N'Kiểm tra 15 phút', 8.0),
(537, 1, 2, 12, 2, N'Kiểm tra 1 tiết', 7.5),
(538, 1, 2, 12, 2, N'Kiểm tra giữa kỳ', 8.0),
(539, 1, 2, 12, 2, N'Kiểm tra cuối kỳ', 7.5);

-- Thêm điểm môn Hóa Học (MaMon = 3) cho học kỳ 2, Giáo viên có MaGV = 15
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(540, 1, 3, 15, 2, N'Kiểm tra miệng', 8.0),
(541, 1, 3, 15, 2, N'Kiểm tra 15 phút', 7.5),
(542, 1, 3, 15, 2, N'Kiểm tra 1 tiết', 8.0),
(543, 1, 3, 15, 2, N'Kiểm tra giữa kỳ', 7.5),
(544, 1, 3, 15, 2, N'Kiểm tra cuối kỳ', 8.0);

-- Thêm điểm môn Sinh Học (MaMon = 4) cho học kỳ 2, Giáo viên có MaGV = 18
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(545, 1, 4, 18, 2, N'Kiểm tra miệng', 7.5),
(546, 1, 4, 18, 2, N'Kiểm tra 15 phút', 8.0),
(547, 1, 4, 18, 2, N'Kiểm tra 1 tiết', 7.5),
(548, 1, 4, 18, 2, N'Kiểm tra giữa kỳ', 8.0),
(549, 1, 4, 18, 2, N'Kiểm tra cuối kỳ', 7.5);

-- Thêm điểm môn Ngữ Văn (MaMon = 5) cho học kỳ 2, Giáo viên có MaGV = 20
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(550, 1, 5, 20, 2, N'Kiểm tra miệng', 8.0),
(551, 1, 5, 20, 2, N'Kiểm tra 15 phút', 7.5),
(552, 1, 5, 20, 2, N'Kiểm tra 1 tiết', 8.0),
(553, 1, 5, 20, 2, N'Kiểm tra giữa kỳ', 7.5),
(554, 1, 5, 20, 2, N'Kiểm tra cuối kỳ', 8.0);

-- Thêm điểm môn Lịch Sử (MaMon = 6) cho học kỳ 2, Giáo viên có MaGV = 23
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(555, 1, 6, 23, 2, N'Kiểm tra miệng', 8.5),
(556, 1, 6, 23, 2, N'Kiểm tra 15 phút', 8.0),
(557, 1, 6, 23, 2, N'Kiểm tra 1 tiết', 8.5),
(558, 1, 6, 23, 2, N'Kiểm tra giữa kỳ', 8.0),
(559, 1, 6, 23, 2, N'Kiểm tra cuối kỳ', 8.5);

-- Thêm điểm môn Địa Lý (MaMon = 7) cho học kỳ 2, Giáo viên có MaGV = 25
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(560, 1, 7, 25, 2, N'Kiểm tra miệng', 7.0),
(561, 1, 7, 25, 2, N'Kiểm tra 15 phút', 7.5),
(562, 1, 7, 25, 2, N'Kiểm tra 1 tiết', 7.0),
(563, 1, 7, 25, 2, N'Kiểm tra giữa kỳ', 7.5),
(564, 1, 7, 25, 2, N'Kiểm tra cuối kỳ', 7.0);

-- Thêm điểm môn Tiếng Anh (MaMon = 8) cho học kỳ 2, Giáo viên có MaGV = 27
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(565, 1, 8, 27, 2, N'Kiểm tra miệng', 8.0),
(566, 1, 8, 27, 2, N'Kiểm tra 15 phút', 8.5),
(567, 1, 8, 27, 2, N'Kiểm tra 1 tiết', 8.0),
(568, 1, 8, 27, 2, N'Kiểm tra giữa kỳ', 8.5),
(569, 1, 8, 27, 2, N'Kiểm tra cuối kỳ', 8.0);

-- Thêm điểm môn Giáo Dục Công Dân (MaMon = 9) cho học kỳ 2, Giáo viên có MaGV = 30
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(570, 1, 9, 30, 2, N'Kiểm tra miệng', 9.0),
(571, 1, 9, 30, 2, N'Kiểm tra 15 phút', 8.5),
(572, 1, 9, 30, 2, N'Kiểm tra 1 tiết', 9.0),
(573, 1, 9, 30, 2, N'Kiểm tra giữa kỳ', 8.5),
(574, 1, 9, 30, 2, N'Kiểm tra cuối kỳ', 9.0);

-- Thêm điểm môn Thể Dục (MaMon = 10) cho học kỳ 2, Giáo viên có MaGV = 31
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(575, 1, 10, 31, 2, N'Kiểm tra thực hành', 9.5),
(576, 1, 10, 31, 2, N'Kiểm tra giữa kỳ', 9.0),
(577, 1, 10, 31, 2, N'Kiểm tra cuối kỳ', 9.5);

-- Thêm điểm môn Tin Học (MaMon = 11) cho học kỳ 2, Giáo viên có MaGV = 32
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(578, 1, 11, 32, 2, N'Kiểm tra miệng', 8.5),
(579, 1, 11, 32, 2, N'Kiểm tra 15 phút', 8.0),
(580, 1, 11, 32, 2, N'Kiểm tra 1 tiết', 8.5),
(581, 1, 11, 32, 2, N'Kiểm tra giữa kỳ', 8.0),
(582, 1, 11, 32, 2, N'Kiểm tra cuối kỳ', 8.5);

-- Thêm điểm môn Công Nghệ (MaMon = 12) cho học kỳ 2, Giáo viên có MaGV = 33
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
(583, 1, 12, 33, 2, N'Kiểm tra miệng', 8.0),
(584, 1, 12, 33, 2, N'Kiểm tra 15 phút', 7.5),
(585, 1, 12, 33, 2, N'Kiểm tra 1 tiết', 8.0),
(586, 1, 12, 33, 2, N'Kiểm tra giữa kỳ', 7.5),
(587, 1, 12, 33, 2, N'Kiểm tra cuối kỳ', 8.0); 