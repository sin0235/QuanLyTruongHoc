using QuanLyTruongHoc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.BLL
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
        /// <returns>Danh sách tất cả các thông báo</returns>
        public List<ThongBaoDTO> GetAllThongBao()
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, 
                               nguoiGui.TenDangNhap as NguoiGui, 
                               nguoiNhan.TenDangNhap as NguoiNhan,
                               0 as DaDoc
                               FROM ThongBao tb
                               LEFT JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                               LEFT JOIN NguoiDung nguoiNhan ON tb.MaNguoiNhan = nguoiNhan.MaNguoiDung
                               ORDER BY tb.NgayGui DESC";

            DataTable dt = dbHelper.ExecuteQuery(query);
            List<ThongBaoDTO> danhSachThongBao = new List<ThongBaoDTO>();

            foreach (DataRow row in dt.Rows)
            {
                ThongBaoDTO thongBao = new ThongBaoDTO
                {
                    MaTB = Convert.ToInt32(row["MaTB"]),
                    TieuDe = row["TieuDe"].ToString(),
                    NoiDung = row["NoiDung"].ToString(),
                    Ngay = Convert.ToDateTime(row["NgayGui"]),
                    NguoiGui = row["NguoiGui"].ToString(),
                    NguoiNhan = row["NguoiNhan"] == DBNull.Value ? null : row["NguoiNhan"].ToString(),
                    DaDoc = Convert.ToBoolean(row["DaDoc"])
                };

                danhSachThongBao.Add(thongBao);
            }

            return danhSachThongBao;
        }

        /// <summary>
        /// Lấy thông báo theo mã thông báo
        /// </summary>
        /// <param name="maTB">Mã thông báo cần lấy</param>
        /// <returns>Thông báo được tìm thấy hoặc null nếu không tồn tại</returns>
        public ThongBaoDTO GetThongBaoById(int maTB)
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, 
                               nguoiGui.TenDangNhap as NguoiGui, 
                               nguoiNhan.TenDangNhap as NguoiNhan,
                               0 as DaDoc
                               FROM ThongBao tb
                               LEFT JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                               LEFT JOIN NguoiDung nguoiNhan ON tb.MaNguoiNhan = nguoiNhan.MaNguoiDung
                               WHERE tb.MaTB = @MaTB";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaTB", maTB }
                };

            DataTable dt = dbHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new ThongBaoDTO
                {
                    MaTB = Convert.ToInt32(row["MaTB"]),
                    TieuDe = row["TieuDe"].ToString(),
                    NoiDung = row["NoiDung"].ToString(),
                    Ngay = Convert.ToDateTime(row["NgayGui"]),
                    NguoiGui = row["NguoiGui"].ToString(),
                    NguoiNhan = row["NguoiNhan"] == DBNull.Value ? null : row["NguoiNhan"].ToString(),
                    DaDoc = Convert.ToBoolean(row["DaDoc"])
                };
            }

            return null;
        }

        /// <summary>
        /// Lấy danh sách thông báo theo người nhận
        /// </summary>
        /// <param name="maNguoiNhan">Mã người nhận thông báo</param>
        /// <returns>Danh sách thông báo của người nhận</returns>
        public List<ThongBaoDTO> GetThongBaoByNguoiNhan(int maNguoiNhan)
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, 
                               nguoiGui.TenDangNhap as NguoiGui, 
                               nguoiNhan.TenDangNhap as NguoiNhan,
                               0 as DaDoc
                               FROM ThongBao tb
                               LEFT JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                               LEFT JOIN NguoiDung nguoiNhan ON tb.MaNguoiNhan = nguoiNhan.MaNguoiDung
                               WHERE tb.MaNguoiNhan = @MaNguoiNhan
                               ORDER BY tb.NgayGui DESC";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiNhan", maNguoiNhan }
                };

            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            List<ThongBaoDTO> danhSachThongBao = new List<ThongBaoDTO>();

            foreach (DataRow row in dt.Rows)
            {
                ThongBaoDTO thongBao = new ThongBaoDTO
                {
                    MaTB = Convert.ToInt32(row["MaTB"]),
                    TieuDe = row["TieuDe"].ToString(),
                    NoiDung = row["NoiDung"].ToString(),
                    Ngay = Convert.ToDateTime(row["NgayGui"]),
                    NguoiGui = row["NguoiGui"].ToString(),
                    NguoiNhan = row["NguoiNhan"].ToString(),
                    DaDoc = Convert.ToBoolean(row["DaDoc"])
                };

                danhSachThongBao.Add(thongBao);
            }

            return danhSachThongBao;
        }

        /// <summary>
        /// Lấy danh sách thông báo theo vai trò người nhận
        /// </summary>
        /// <param name="maVaiTro">Mã vai trò người nhận</param>
        /// <returns>Danh sách thông báo của vai trò</returns>
        public List<ThongBaoDTO> GetThongBaoByVaiTro(int maVaiTro)
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, 
                               nguoiGui.TenDangNhap as NguoiGui, 
                               vt.TenVaiTro as NguoiNhan,
                               0 as DaDoc
                               FROM ThongBao tb
                               LEFT JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                               LEFT JOIN VaiTro vt ON tb.MaVaiTroNhan = vt.MaVaiTro
                               WHERE tb.MaVaiTroNhan = @MaVaiTro
                               ORDER BY tb.NgayGui DESC";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaVaiTro", maVaiTro }
                };

            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            List<ThongBaoDTO> danhSachThongBao = new List<ThongBaoDTO>();

            foreach (DataRow row in dt.Rows)
            {
                ThongBaoDTO thongBao = new ThongBaoDTO
                {
                    MaTB = Convert.ToInt32(row["MaTB"]),
                    TieuDe = row["TieuDe"].ToString(),
                    NoiDung = row["NoiDung"].ToString(),
                    Ngay = Convert.ToDateTime(row["NgayGui"]),
                    NguoiGui = row["NguoiGui"].ToString(),
                    NguoiNhan = "Vai trò: " + row["NguoiNhan"].ToString(),
                    DaDoc = Convert.ToBoolean(row["DaDoc"])
                };

                danhSachThongBao.Add(thongBao);
            }

            return danhSachThongBao;
        }

        /// <summary>
        /// Lấy danh sách thông báo theo lớp học
        /// </summary>
        /// <param name="maLop">Mã lớp học</param>
        /// <returns>Danh sách thông báo của lớp</returns>
        public List<ThongBaoDTO> GetThongBaoByLop(int maLop)
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, 
                               nguoiGui.TenDangNhap as NguoiGui, 
                               lh.TenLop as NguoiNhan,
                               0 as DaDoc
                               FROM ThongBao tb
                               LEFT JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                               LEFT JOIN LopHoc lh ON tb.MaLop = lh.MaLop
                               WHERE tb.MaLop = @MaLop
                               ORDER BY tb.NgayGui DESC";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaLop", maLop }
                };

            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            List<ThongBaoDTO> danhSachThongBao = new List<ThongBaoDTO>();

            foreach (DataRow row in dt.Rows)
            {
                ThongBaoDTO thongBao = new ThongBaoDTO
                {
                    MaTB = Convert.ToInt32(row["MaTB"]),
                    TieuDe = row["TieuDe"].ToString(),
                    NoiDung = row["NoiDung"].ToString(),
                    Ngay = Convert.ToDateTime(row["NgayGui"]),
                    NguoiGui = row["NguoiGui"].ToString(),
                    NguoiNhan = "Lớp: " + row["NguoiNhan"].ToString(),
                    DaDoc = Convert.ToBoolean(row["DaDoc"])
                };

                danhSachThongBao.Add(thongBao);
            }

            return danhSachThongBao;
        }

        /// <summary>
        /// Thêm một thông báo mới vào cơ sở dữ liệu
        /// </summary>
        /// <param name="thongBao">Thông báo cần thêm</param>
        /// <param name="maNguoiGui">Mã người gửi thông báo</param>
        /// <param name="maNguoiNhan">Mã người nhận thông báo (có thể null)</param>
        /// <param name="maVaiTroNhan">Mã vai trò người nhận (có thể null)</param>
        /// <param name="maLop">Mã lớp học nhận thông báo (có thể null)</param>
        /// <param name="maMon">Mã môn học liên quan đến thông báo (có thể null)</param>
        /// <returns>Mã thông báo nếu thêm thành công, -1 nếu thất bại</returns>
        public int ThemThongBao(ThongBaoDTO thongBao, int maNguoiGui, int? maNguoiNhan = null,
            int? maVaiTroNhan = null, int? maLop = null, int? maMon = null)
        {
            string query = @"INSERT INTO ThongBao (MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, 
                                MaMon, TieuDe, NoiDung, NgayGui)
                                VALUES (@MaNguoiGui, @MaNguoiNhan, @MaVaiTroNhan, @MaLop, 
                                @MaMon, @TieuDe, @NoiDung, @NgayGui);
                                SELECT SCOPE_IDENTITY();";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiGui", maNguoiGui },
                    { "@MaNguoiNhan", maNguoiNhan },
                    { "@MaVaiTroNhan", maVaiTroNhan },
                    { "@MaLop", maLop },
                    { "@MaMon", maMon },
                    { "@TieuDe", thongBao.TieuDe },
                    { "@NoiDung", thongBao.NoiDung },
                    { "@NgayGui", DateTime.Now }
                };

            int maTB = dbHelper.ExecuteInsertAndGetId(query, parameters);
            return maTB;
        }

        /// <summary>
        /// Cập nhật thông tin của một thông báo
        /// </summary>
        /// <param name="thongBao">Thông báo cần cập nhật</param>
        /// <returns>True nếu cập nhật thành công, false nếu thất bại</returns>
        public bool CapNhatThongBao(ThongBaoDTO thongBao)
        {
            string query = @"UPDATE ThongBao 
                              SET TieuDe = @TieuDe, 
                                  NoiDung = @NoiDung
                              WHERE MaTB = @MaTB";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaTB", thongBao.MaTB },
                    { "@TieuDe", thongBao.TieuDe },
                    { "@NoiDung", thongBao.NoiDung }
                };

            return dbHelper.ExecuteNonQuery(query, parameters);
        }

        /// <summary>
        /// Xóa một thông báo khỏi cơ sở dữ liệu
        /// </summary>
        /// <param name="maTB">Mã thông báo cần xóa</param>
        /// <returns>True nếu xóa thành công, false nếu thất bại</returns>
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
        /// Đếm số lượng thông báo mới cho người dùng
        /// </summary>
        /// <param name="maNguoiDung">Mã người dùng</param>
        /// <param name="maVaiTro">Mã vai trò của người dùng</param>
        /// <param name="maLop">Mã lớp của người dùng (nếu là học sinh)</param>
        /// <returns>Số lượng thông báo mới</returns>
        public int DemThongBaoMoi(int maNguoiDung, int maVaiTro, int? maLop = null)
        {
            string query = @"SELECT COUNT(*) FROM ThongBao 
                              WHERE (MaNguoiNhan = @MaNguoiDung 
                              OR MaVaiTroNhan = @MaVaiTro";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiDung", maNguoiDung },
                    { "@MaVaiTro", maVaiTro }
                };

            if (maLop.HasValue)
            {
                query += " OR MaLop = @MaLop";
                parameters.Add("@MaLop", maLop.Value);
            }

            query += ") AND NgayGui > DATEADD(day, -7, GETDATE())";

            object result = dbHelper.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        /// <summary>
        /// Lấy danh sách thông báo cho một người dùng cụ thể, bao gồm cả thông báo gửi cho vai trò và lớp học của họ
        /// </summary>
        /// <param name="maNguoiDung">Mã người dùng</param>
        /// <param name="maVaiTro">Mã vai trò của người dùng</param>
        /// <param name="maLop">Mã lớp của người dùng (nếu là học sinh)</param>
        /// <returns>Danh sách các thông báo cho người dùng</returns>
        public List<ThongBaoDTO> GetThongBaoForUser(int maNguoiDung, int maVaiTro, int? maLop = null)
        {
            string query = @"SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, 
                               nguoiGui.TenDangNhap as NguoiGui, 
                               CASE 
                                   WHEN tb.MaNguoiNhan = @MaNguoiDung THEN nguoiNhan.TenDangNhap
                                   WHEN tb.MaVaiTroNhan = @MaVaiTro THEN vt.TenVaiTro
                                   WHEN tb.MaLop = @MaLop THEN lh.TenLop
                                   ELSE 'Chung'
                               END as NguoiNhan,
                               0 as DaDoc
                               FROM ThongBao tb
                               LEFT JOIN NguoiDung nguoiGui ON tb.MaNguoiGui = nguoiGui.MaNguoiDung
                               LEFT JOIN NguoiDung nguoiNhan ON tb.MaNguoiNhan = nguoiNhan.MaNguoiDung
                               LEFT JOIN VaiTro vt ON tb.MaVaiTroNhan = vt.MaVaiTro
                               LEFT JOIN LopHoc lh ON tb.MaLop = lh.MaLop
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
            List<ThongBaoDTO> danhSachThongBao = new List<ThongBaoDTO>();

            foreach (DataRow row in dt.Rows)
            {
                ThongBaoDTO thongBao = new ThongBaoDTO
                {
                    MaTB = Convert.ToInt32(row["MaTB"]),
                    TieuDe = row["TieuDe"].ToString(),
                    NoiDung = row["NoiDung"].ToString(),
                    Ngay = Convert.ToDateTime(row["NgayGui"]),
                    NguoiGui = row["NguoiGui"].ToString(),
                    NguoiNhan = row["NguoiNhan"].ToString(),
                    DaDoc = Convert.ToBoolean(row["DaDoc"])
                };

                danhSachThongBao.Add(thongBao);
            }

            return danhSachThongBao;
        }
    }
}
