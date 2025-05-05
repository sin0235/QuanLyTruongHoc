using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DAL
{
    public class ThongBaoDAL
    {
        private DatabaseHelper dbHelper;

        public ThongBaoDAL()
        {
            dbHelper = new DatabaseHelper();
        }

        /// <summary>
        /// Lấy tất cả thông báo từ cơ sở dữ liệu
        /// </summary>
        /// <returns>Danh sách các thông báo</returns>
        public List<ThongBaoDTO> GetAllThongBao()
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui as Ngay, 
                                nguoiGui.TenDangNhap as NguoiGui,
                                CASE
                                    WHEN tb.MaNguoiNhan IS NOT NULL THEN nguoiNhan.TenDangNhap
                                    WHEN tb.MaVaiTroNhan IS NOT NULL THEN vt.TenVaiTro
                                    WHEN tb.MaLop IS NOT NULL THEN lop.TenLop
                                    ELSE 'Tất cả'
                                END as NguoiNhan,
                                0 as DaDoc
                                FROM ThongBao tb
                                INNER JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                                LEFT JOIN NguoiDung nguoiNhan ON tb.MaNguoiNhan = nguoiNhan.MaNguoiDung
                                LEFT JOIN VaiTro vt ON tb.MaVaiTroNhan = vt.MaVaiTro
                                LEFT JOIN LopHoc lop ON tb.MaLop = lop.MaLop
                                ORDER BY tb.NgayGui DESC";

            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        /// <summary>
        /// Lấy thông tin chi tiết của một thông báo theo mã thông báo
        /// </summary>
        /// <param name="maTB">Mã thông báo cần lấy</param>
        /// <returns>Thông tin chi tiết của thông báo</returns>
        public ThongBaoDTO GetThongBaoById(int maTB)
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui as Ngay, 
                                nguoiGui.TenDangNhap as NguoiGui,
                                CASE
                                    WHEN tb.MaNguoiNhan IS NOT NULL THEN nguoiNhan.TenDangNhap
                                    WHEN tb.MaVaiTroNhan IS NOT NULL THEN vt.TenVaiTro
                                    WHEN tb.MaLop IS NOT NULL THEN lop.TenLop
                                    ELSE 'Tất cả'
                                END as NguoiNhan,
                                0 as DaDoc
                                FROM ThongBao tb
                                INNER JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                                LEFT JOIN NguoiDung nguoiNhan ON tb.MaNguoiNhan = nguoiNhan.MaNguoiDung
                                LEFT JOIN VaiTro vt ON tb.MaVaiTroNhan = vt.MaVaiTro
                                LEFT JOIN LopHoc lop ON tb.MaLop = lop.MaLop
                                WHERE tb.MaTB = @MaTB";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaTB", maTB }
                };

            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return ConvertDataRowToThongBao(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Thêm thông báo mới vào cơ sở dữ liệu
        /// </summary>
        /// <param name="maNguoiGui">Mã người gửi thông báo</param>
        /// <param name="tieuDe">Tiêu đề thông báo</param>
        /// <param name="noiDung">Nội dung thông báo</param>
        /// <param name="maNguoiNhan">Mã người nhận (có thể null)</param>
        /// <param name="maVaiTroNhan">Mã vai trò nhận (có thể null)</param>
        /// <param name="maLop">Mã lớp nhận (có thể null)</param>
        /// <param name="maMon">Mã môn học liên quan (có thể null)</param>
        /// <returns>Mã thông báo mới nếu thành công, -1 nếu thất bại</returns>
        public int ThemThongBao(int maNguoiGui, string tieuDe, string noiDung,
                                int? maNguoiNhan = null, int? maVaiTroNhan = null,
                                int? maLop = null, int? maMon = null)
        {
            string query = @"INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, MaMon, TieuDe, NoiDung, NgayGui)
                                VALUES (@MaNguoiGui, @MaNguoiNhan, @MaVaiTroNhan, @MaLop, @MaMon, @TieuDe, @NoiDung, GETDATE());
                                SELECT SCOPE_IDENTITY();";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiGui", maNguoiGui },
                    { "@MaNguoiNhan", maNguoiNhan },
                    { "@MaVaiTroNhan", maVaiTroNhan },
                    { "@MaLop", maLop },
                    { "@MaMon", maMon },
                    { "@TieuDe", tieuDe },
                    { "@NoiDung", noiDung }
                };

            object result = dbHelper.ExecuteScalar(query, parameters);
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return -1;
        }

        /// <summary>
        /// Cập nhật thông tin thông báo
        /// </summary>
        /// <param name="maTB">Mã thông báo cần cập nhật</param>
        /// <param name="tieuDe">Tiêu đề thông báo mới</param>
        /// <param name="noiDung">Nội dung thông báo mới</param>
        /// <returns>True nếu cập nhật thành công, False nếu thất bại</returns>
        public bool CapNhatThongBao(int maTB, string tieuDe, string noiDung)
        {
            string query = "UPDATE ThongBao SET TieuDe = @TieuDe, NoiDung = @NoiDung WHERE MaTB = @MaTB";
            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaTB", maTB },
                    { "@TieuDe", tieuDe },
                    { "@NoiDung", noiDung }
                };

            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Xóa thông báo từ cơ sở dữ liệu
        /// </summary>
        /// <param name="maTB">Mã thông báo cần xóa</param>
        /// <returns>True nếu xóa thành công, False nếu thất bại</returns>
        public bool XoaThongBao(int maTB)
        {
            string query = "DELETE FROM ThongBao WHERE MaTB = @MaTB";
            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaTB", maTB }
                };

            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Lấy danh sách thông báo gửi đến một người dùng cụ thể
        /// </summary>
        /// <param name="maNguoiDung">Mã người dùng cần lấy thông báo</param>
        /// <returns>Danh sách thông báo của người dùng</returns>
        public List<ThongBaoDTO> GetThongBaoByNguoiNhan(int maNguoiDung)
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui as Ngay, 
                                nguoiGui.TenDangNhap as NguoiGui,
                                nguoiNhan.TenDangNhap as NguoiNhan,
                                0 as DaDoc
                                FROM ThongBao tb
                                INNER JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                                INNER JOIN NguoiDung nguoiNhan ON tb.MaNguoiNhan = nguoiNhan.MaNguoiDung
                                WHERE tb.MaNguoiNhan = @MaNguoiDung
                                ORDER BY tb.NgayGui DESC";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiDung", maNguoiDung }
                };

            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        /// <summary>
        /// Lấy danh sách thông báo gửi đến một vai trò cụ thể
        /// </summary>
        /// <param name="maVaiTro">Mã vai trò cần lấy thông báo</param>
        /// <returns>Danh sách thông báo của vai trò</returns>
        public List<ThongBaoDTO> GetThongBaoByVaiTro(int maVaiTro)
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui as Ngay, 
                                nguoiGui.TenDangNhap as NguoiGui,
                                vt.TenVaiTro as NguoiNhan,
                                0 as DaDoc
                                FROM ThongBao tb
                                INNER JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                                INNER JOIN VaiTro vt ON tb.MaVaiTroNhan = vt.MaVaiTro
                                WHERE tb.MaVaiTroNhan = @MaVaiTro
                                ORDER BY tb.NgayGui DESC";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaVaiTro", maVaiTro }
                };

            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        /// <summary>
        /// Lấy danh sách thông báo gửi đến một lớp học cụ thể
        /// </summary>
        /// <param name="maLop">Mã lớp cần lấy thông báo</param>
        /// <returns>Danh sách thông báo của lớp</returns>
        public List<ThongBaoDTO> GetThongBaoByLop(int maLop)
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui as Ngay, 
                                nguoiGui.TenDangNhap as NguoiGui,
                                lop.TenLop as NguoiNhan,
                                0 as DaDoc
                                FROM ThongBao tb
                                INNER JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                                INNER JOIN LopHoc lop ON tb.MaLop = lop.MaLop
                                WHERE tb.MaLop = @MaLop
                                ORDER BY tb.NgayGui DESC";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaLop", maLop }
                };

            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        /// <summary>
        /// Lấy tất cả thông báo mà người dùng có thể xem (cá nhân, vai trò, lớp học)
        /// </summary>
        /// <param name="maNguoiDung">Mã người dùng</param>
        /// <param name="maVaiTro">Mã vai trò của người dùng</param>
        /// <param name="maLop">Mã lớp của người dùng (nếu là học sinh)</param>
        /// <returns>Danh sách các thông báo cho người dùng</returns>
        public List<ThongBaoDTO> GetThongBaoForUser(int maNguoiDung, int maVaiTro, int? maLop = null)
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui as Ngay, 
                                nguoiGui.TenDangNhap as NguoiGui,
                                CASE
                                    WHEN tb.MaNguoiNhan = @MaNguoiDung THEN 'Cá nhân'
                                    WHEN tb.MaVaiTroNhan = @MaVaiTro THEN vt.TenVaiTro
                                    WHEN tb.MaLop = @MaLop THEN lop.TenLop
                                    ELSE 'Chung'
                                END as NguoiNhan,
                                0 as DaDoc
                                FROM ThongBao tb
                                INNER JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                                LEFT JOIN NguoiDung nguoiNhan ON tb.MaNguoiNhan = nguoiNhan.MaNguoiDung
                                LEFT JOIN VaiTro vt ON tb.MaVaiTroNhan = vt.MaVaiTro
                                LEFT JOIN LopHoc lop ON tb.MaLop = lop.MaLop
                                WHERE tb.MaNguoiNhan = @MaNguoiDung 
                                OR tb.MaVaiTroNhan = @MaVaiTro";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiDung", maNguoiDung },
                    { "@MaVaiTro", maVaiTro }
                };

            if (maLop.HasValue)
            {
                query += " OR tb.MaLop = @MaLop";
                parameters.Add("@MaLop", maLop.Value);
            }

            query += " ORDER BY tb.NgayGui DESC";

            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        /// <summary>
        /// Lấy danh sách thông báo đã gửi bởi một người dùng
        /// </summary>
        /// <param name="maNguoiGui">Mã người dùng đã gửi thông báo</param>
        /// <returns>Danh sách thông báo đã gửi</returns>
        public List<ThongBaoDTO> GetThongBaoByNguoiGui(int maNguoiGui)
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui as Ngay, 
                                nguoiGui.TenDangNhap as NguoiGui,
                                CASE
                                    WHEN tb.MaNguoiNhan IS NOT NULL THEN nguoiNhan.TenDangNhap
                                    WHEN tb.MaVaiTroNhan IS NOT NULL THEN vt.TenVaiTro
                                    WHEN tb.MaLop IS NOT NULL THEN lop.TenLop
                                    ELSE 'Tất cả'
                                END as NguoiNhan,
                                0 as DaDoc
                                FROM ThongBao tb
                                INNER JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                                LEFT JOIN NguoiDung nguoiNhan ON tb.MaNguoiNhan = nguoiNhan.MaNguoiDung
                                LEFT JOIN VaiTro vt ON tb.MaVaiTroNhan = vt.MaVaiTro
                                LEFT JOIN LopHoc lop ON tb.MaLop = lop.MaLop
                                WHERE tb.MaNguoiGui = @MaNguoiGui
                                ORDER BY tb.NgayGui DESC";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiGui", maNguoiGui }
                };

            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        /// <summary>
        /// Đếm số lượng thông báo chưa đọc của người dùng
        /// </summary>
        /// <param name="maNguoiDung">Mã người dùng</param>
        /// <param name="maVaiTro">Mã vai trò của người dùng</param>
        /// <param name="maLop">Mã lớp của người dùng (nếu là học sinh)</param>
        /// <returns>Số lượng thông báo chưa đọc</returns>
        public int CountUnreadNotifications(int maNguoiDung, int maVaiTro, int? maLop = null)
        {
            string query = @"SELECT COUNT(*) FROM ThongBao tb
                                WHERE (tb.MaNguoiNhan = @MaNguoiDung 
                                OR tb.MaVaiTroNhan = @MaVaiTro";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiDung", maNguoiDung },
                    { "@MaVaiTro", maVaiTro }
                };

            if (maLop.HasValue)
            {
                query += " OR tb.MaLop = @MaLop";
                parameters.Add("@MaLop", maLop.Value);
            }

            query += ") AND tb.NgayGui > DATEADD(DAY, -7, GETDATE())";

            object result = dbHelper.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Tìm kiếm thông báo theo từ khóa
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        /// <returns>Danh sách thông báo phù hợp</returns>
        public List<ThongBaoDTO> SearchThongBao(string keyword)
        {
            keyword = $"%{keyword}%";
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui as Ngay, 
                                nguoiGui.TenDangNhap as NguoiGui,
                                CASE
                                    WHEN tb.MaNguoiNhan IS NOT NULL THEN nguoiNhan.TenDangNhap
                                    WHEN tb.MaVaiTroNhan IS NOT NULL THEN vt.TenVaiTro
                                    WHEN tb.MaLop IS NOT NULL THEN lop.TenLop
                                    ELSE 'Tất cả'
                                END as NguoiNhan,
                                0 as DaDoc
                                FROM ThongBao tb
                                INNER JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                                LEFT JOIN NguoiDung nguoiNhan ON tb.MaNguoiNhan = nguoiNhan.MaNguoiDung
                                LEFT JOIN VaiTro vt ON tb.MaVaiTroNhan = vt.MaVaiTro
                                LEFT JOIN LopHoc lop ON tb.MaLop = lop.MaLop
                                WHERE tb.TieuDe LIKE @Keyword OR tb.NoiDung LIKE @Keyword
                                ORDER BY tb.NgayGui DESC";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@Keyword", keyword }
                };

            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        // Helper method để chuyển DataTable sang List<ThongBaoDTO>
        private List<ThongBaoDTO> ConvertDataTableToList(DataTable dt)
        {
            List<ThongBaoDTO> thongBaoList = new List<ThongBaoDTO>();
            foreach (DataRow row in dt.Rows)
            {
                thongBaoList.Add(ConvertDataRowToThongBao(row));
            }
            return thongBaoList;
        }

        // Helper method để chuyển DataRow sang ThongBaoDTO
        private ThongBaoDTO ConvertDataRowToThongBao(DataRow row)
        {
            return new ThongBaoDTO
            {
                MaTB = Convert.ToInt32(row["MaTB"]),
                TieuDe = row["TieuDe"].ToString(),
                NoiDung = row["NoiDung"].ToString(),
                Ngay = Convert.ToDateTime(row["Ngay"]),
                NguoiGui = row["NguoiGui"].ToString(),
                NguoiNhan = row["NguoiNhan"].ToString(),
                DaDoc = row["DaDoc"] != DBNull.Value && Convert.ToBoolean(row["DaDoc"])
            };
        }
    }
}
