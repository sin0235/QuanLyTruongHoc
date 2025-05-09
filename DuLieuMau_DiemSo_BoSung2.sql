USE QuanLyTruongHoc;
GO

-- Dữ liệu bổ sung điểm số học kỳ 2, năm học 2024-2025
-- Thêm điểm cho các môn còn lại và thêm điểm cho học sinh chưa có điểm

-- Điểm học kỳ 2 - Môn Toán (MaMon = 1) cho lớp 10A1, Giáo viên có MaGV = 7
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 1 - Nguyễn Văn An
(301, 1, 1, 7, 2, N'Miệng', 8.0),
(302, 1, 1, 7, 2, N'15 phút', 7.5),
(303, 1, 1, 7, 2, N'15 phút', 8.0),
(304, 1, 1, 7, 2, N'Giữa kỳ', 7.5),
(305, 1, 1, 7, 2, N'Cuối kỳ', 8.0),

-- Học sinh 2 - Trần Thị Bích
(306, 2, 1, 7, 2, N'Miệng', 9.0),
(307, 2, 1, 7, 2, N'15 phút', 8.5),
(308, 2, 1, 7, 2, N'15 phút', 9.0),
(309, 2, 1, 7, 2, N'Giữa kỳ', 8.5),
(310, 2, 1, 7, 2, N'Cuối kỳ', 9.0),

-- Học sinh 3 - Lê Minh Cường
(311, 3, 1, 7, 2, N'Miệng', 7.0),
(312, 3, 1, 7, 2, N'15 phút', 6.5),
(313, 3, 1, 7, 2, N'15 phút', 7.0),
(314, 3, 1, 7, 2, N'Giữa kỳ', 6.5),
(315, 3, 1, 7, 2, N'Cuối kỳ', 7.0);

-- Điểm học kỳ 2 - Môn Hóa Học (MaMon = 3) cho lớp 10A1, Giáo viên có MaGV = 15
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 4 - Phạm Thị Diệu
(316, 4, 3, 15, 2, N'Miệng', 8.5),
(317, 4, 3, 15, 2, N'15 phút', 9.0),
(318, 4, 3, 15, 2, N'15 phút', 8.5),
(319, 4, 3, 15, 2, N'Giữa kỳ', 9.0),
(320, 4, 3, 15, 2, N'Cuối kỳ', 8.5),

-- Học sinh 5 - Hoàng Văn Đức
(321, 5, 3, 15, 2, N'Miệng', 7.5),
(322, 5, 3, 15, 2, N'15 phút', 7.0),
(323, 5, 3, 15, 2, N'15 phút', 7.5),
(324, 5, 3, 15, 2, N'Giữa kỳ', 7.0),
(325, 5, 3, 15, 2, N'Cuối kỳ', 7.5);

-- Điểm học kỳ 2 - Môn Sinh Học (MaMon = 4) cho lớp 10A1, Giáo viên có MaGV = 18
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 6 - Vũ Thị Hà
(326, 6, 4, 18, 2, N'Miệng', 8.0),
(327, 6, 4, 18, 2, N'15 phút', 8.5),
(328, 6, 4, 18, 2, N'15 phút', 8.0),
(329, 6, 4, 18, 2, N'Giữa kỳ', 8.5),
(330, 6, 4, 18, 2, N'Cuối kỳ', 8.0),

-- Học sinh 7 - Đặng Minh Hùng
(331, 7, 4, 18, 2, N'Miệng', 7.0),
(332, 7, 4, 18, 2, N'15 phút', 7.5),
(333, 7, 4, 18, 2, N'15 phút', 7.0),
(334, 7, 4, 18, 2, N'Giữa kỳ', 7.5),
(335, 7, 4, 18, 2, N'Cuối kỳ', 7.0);

-- Điểm học kỳ 2 - Môn Văn (MaMon = 5) cho lớp 10A1, Giáo viên có MaGV = 20
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 8 - Ngô Thị Lan
(336, 8, 5, 20, 2, N'Miệng', 8.5),
(337, 8, 5, 20, 2, N'15 phút', 9.0),
(338, 8, 5, 20, 2, N'15 phút', 8.5),
(339, 8, 5, 20, 2, N'Giữa kỳ', 9.0),
(340, 8, 5, 20, 2, N'Cuối kỳ', 8.5),

-- Học sinh 9 - Phan Văn Minh
(341, 9, 5, 20, 2, N'Miệng', 7.5),
(342, 9, 5, 20, 2, N'15 phút', 7.0),
(343, 9, 5, 20, 2, N'15 phút', 7.5),
(344, 9, 5, 20, 2, N'Giữa kỳ', 7.0),
(345, 9, 5, 20, 2, N'Cuối kỳ', 7.5);

-- Điểm học kỳ 2 - Môn Vật Lý (MaMon = 2) cho lớp 10A2, Giáo viên có MaGV = 12
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 19 - Hoàng Văn Duy
(346, 19, 2, 12, 2, N'Miệng', 7.0),
(347, 19, 2, 12, 2, N'15 phút', 7.5),
(348, 19, 2, 12, 2, N'15 phút', 7.0),
(349, 19, 2, 12, 2, N'Giữa kỳ', 7.5),
(350, 19, 2, 12, 2, N'Cuối kỳ', 7.0),

-- Học sinh 20 - Trần Thị Hồng
(351, 20, 2, 12, 2, N'Miệng', 8.0),
(352, 20, 2, 12, 2, N'15 phút', 8.5),
(353, 20, 2, 12, 2, N'15 phút', 8.0),
(354, 20, 2, 12, 2, N'Giữa kỳ', 8.5),
(355, 20, 2, 12, 2, N'Cuối kỳ', 8.0);

-- Điểm học kỳ 2 - Môn Địa Lý (MaMon = 7) cho lớp 10A2, Giáo viên có MaGV = 25
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 21 - Phạm Văn Khoa
(356, 21, 7, 25, 2, N'Miệng', 8.5),
(357, 21, 7, 25, 2, N'15 phút', 8.0),
(358, 21, 7, 25, 2, N'15 phút', 8.5),
(359, 21, 7, 25, 2, N'Giữa kỳ', 8.0),
(360, 21, 7, 25, 2, N'Cuối kỳ', 8.5),

-- Học sinh 22 - Lê Thị Mai
(361, 22, 7, 25, 2, N'Miệng', 9.0),
(362, 22, 7, 25, 2, N'15 phút', 9.5),
(363, 22, 7, 25, 2, N'15 phút', 9.0),
(364, 22, 7, 25, 2, N'Giữa kỳ', 9.5),
(365, 22, 7, 25, 2, N'Cuối kỳ', 9.0);

-- Điểm học kỳ 2 - Môn Lịch Sử (MaMon = 6) cho lớp 10A2, Giáo viên có MaGV = 23
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 23 - Vũ Văn Nam
(366, 23, 6, 23, 2, N'Miệng', 7.5),
(367, 23, 6, 23, 2, N'15 phút', 7.0),
(368, 23, 6, 23, 2, N'15 phút', 7.5),
(369, 23, 6, 23, 2, N'Giữa kỳ', 7.0),
(370, 23, 6, 23, 2, N'Cuối kỳ', 7.5),

-- Học sinh 24 - Đinh Thị Oanh
(371, 24, 6, 23, 2, N'Miệng', 8.0),
(372, 24, 6, 23, 2, N'15 phút', 8.5),
(373, 24, 6, 23, 2, N'15 phút', 8.0),
(374, 24, 6, 23, 2, N'Giữa kỳ', 8.5),
(375, 24, 6, 23, 2, N'Cuối kỳ', 8.0);

-- Điểm học kỳ 2 - Môn Sinh Học (MaMon = 4) cho lớp 10A2, Giáo viên có MaGV = 18
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 25 - Nguyễn Văn Phương
(376, 25, 4, 18, 2, N'Miệng', 7.0),
(377, 25, 4, 18, 2, N'15 phút', 7.5),
(378, 25, 4, 18, 2, N'15 phút', 7.0),
(379, 25, 4, 18, 2, N'Giữa kỳ', 7.5),
(380, 25, 4, 18, 2, N'Cuối kỳ', 7.0),

-- Học sinh 26 - Trần Thị Quỳnh
(381, 26, 4, 18, 2, N'Miệng', 8.5),
(382, 26, 4, 18, 2, N'15 phút', 9.0),
(383, 26, 4, 18, 2, N'15 phút', 8.5),
(384, 26, 4, 18, 2, N'Giữa kỳ', 9.0),
(385, 26, 4, 18, 2, N'Cuối kỳ', 8.5);

-- Điểm học kỳ 2 - Môn GDCD (MaMon = 9) cho lớp 10A1, Giáo viên có MaGV = 30
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 10 - Bùi Thị Nga
(386, 10, 9, 30, 2, N'Miệng', 9.0),
(387, 10, 9, 30, 2, N'15 phút', 8.5),
(388, 10, 9, 30, 2, N'15 phút', 9.0),
(389, 10, 9, 30, 2, N'Giữa kỳ', 8.5),
(390, 10, 9, 30, 2, N'Cuối kỳ', 9.0),

-- Học sinh 11 - Lý Văn Phúc
(391, 11, 9, 30, 2, N'Miệng', 7.5),
(392, 11, 9, 30, 2, N'15 phút', 7.0),
(393, 11, 9, 30, 2, N'15 phút', 7.5),
(394, 11, 9, 30, 2, N'Giữa kỳ', 7.0),
(395, 11, 9, 30, 2, N'Cuối kỳ', 7.5);

-- Điểm học kỳ 2 - Môn Tin Học (MaMon = 11) cho lớp 10A2, Giáo viên có MaGV = 32
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 27 - Lý Văn Sơn
(396, 27, 11, 32, 2, N'Miệng', 8.0),
(397, 27, 11, 32, 2, N'15 phút', 8.5),
(398, 27, 11, 32, 2, N'15 phút', 8.0),
(399, 27, 11, 32, 2, N'Giữa kỳ', 8.5),
(400, 27, 11, 32, 2, N'Cuối kỳ', 8.0),

-- Học sinh 28 - Phan Thị Thu
(401, 28, 11, 32, 2, N'Miệng', 9.0),
(402, 28, 11, 32, 2, N'15 phút', 9.5),
(403, 28, 11, 32, 2, N'15 phút', 9.0),
(404, 28, 11, 32, 2, N'Giữa kỳ', 9.5),
(405, 28, 11, 32, 2, N'Cuối kỳ', 9.0);

-- Điểm học kỳ 2 - Môn Công Nghệ (MaMon = 12) cho lớp 10A1, Giáo viên có MaGV = 33
INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem) VALUES
-- Học sinh 12 - Võ Thị Quỳnh
(406, 12, 12, 33, 2, N'Miệng', 8.5),
(407, 12, 12, 33, 2, N'15 phút', 8.0),
(408, 12, 12, 33, 2, N'15 phút', 8.5),
(409, 12, 12, 33, 2, N'Giữa kỳ', 8.0),
(410, 12, 12, 33, 2, N'Cuối kỳ', 8.5),

-- Học sinh 13 - Trương Minh Sơn
(411, 13, 12, 33, 2, N'Miệng', 7.0),
(412, 13, 12, 33, 2, N'15 phút', 7.5),
(413, 13, 12, 33, 2, N'15 phút', 7.0),
(414, 13, 12, 33, 2, N'Giữa kỳ', 7.5),
(415, 13, 12, 33, 2, N'Cuối kỳ', 7.0);

