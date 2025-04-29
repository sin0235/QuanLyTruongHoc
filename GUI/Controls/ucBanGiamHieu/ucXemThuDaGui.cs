using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;

namespace QuanLyTruongHoc.GUI.Controls.ucBanGiamHieu
{
    public partial class ucXemThuDaGui : UserControl
    {
        public ucXemThuDaGui()
        {
            InitializeComponent();
            this.Load += ucXemThuDaGui_Load;
        }
        private void LoadData()
        {
            try
            {
                // Khởi tạo đối tượng DatabaseHelper
                DatabaseHelper db = new DatabaseHelper();
                db.OpenConnection();

                // Truy vấn dữ liệu từ bảng ThongBao
                string query = @"
                SELECT MaTB, MaNguoiGui, MaNguoiNhan, MaVaiTroNhan, MaLop, TieuDe, NoiDung, NgayGui
                FROM ThongBao
                WHERE MaNguoiGui = 1
                ORDER BY NgayGui DESC"; 
                DataTable thongBaoTable = db.ExecuteQuery(query);

                // Xóa các hàng cũ trong DataGridView
                dgvXemThu.Rows.Clear();

                foreach (DataRow row in thongBaoTable.Rows)
                {
                    string nguoiGui = "Ban giám hiệu"; // Người gửi mặc định là Ban giám hiệu
                    string nguoiNhan = GetNguoiNhan(db, row); // Xử lý thông tin người nhận
                    string tieuDe = row["TieuDe"].ToString();
                    string noiDung = row["NoiDung"].ToString();
                    string thoiGian = Convert.ToDateTime(row["NgayGui"]).ToString("dd/MM/yyyy HH:mm:ss");
                    int maTB = Convert.ToInt32(row["MaTB"]); // Lấy giá trị MaTB

                    // Thêm hàng vào DataGridView
                    dgvXemThu.Rows.Add(maTB, nguoiGui, nguoiNhan, tieuDe, noiDung, thoiGian);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm xử lý thông tin người nhận
        private string GetNguoiNhan(DatabaseHelper db, DataRow row)
        {
            if (row["MaNguoiNhan"] != DBNull.Value)
            {
                // Trường hợp gửi cho cá nhân
                int maNguoiNhan = Convert.ToInt32(row["MaNguoiNhan"]);

                // Truy vấn thông tin từ bảng GiaoVien
                string query = $@"
                SELECT GV.HoTen AS TenDayDu, VT.TenVaiTro
                FROM GiaoVien GV
                INNER JOIN NguoiDung ND ON GV.MaNguoiDung = ND.MaNguoiDung
                LEFT JOIN VaiTro VT ON ND.MaVaiTro = VT.MaVaiTro
                WHERE ND.MaNguoiDung = {maNguoiNhan}";
                DataTable result = db.ExecuteQuery(query);

                if (result.Rows.Count == 0)
                {
                    // Nếu không tìm thấy trong bảng GiaoVien, tìm trong bảng HocSinh
                    query = $@"
                    SELECT HS.HoTen AS TenDayDu, VT.TenVaiTro
                    FROM HocSinh HS
                    INNER JOIN NguoiDung ND ON HS.MaNguoiDung = ND.MaNguoiDung
                    LEFT JOIN VaiTro VT ON ND.MaVaiTro = VT.MaVaiTro
                    WHERE ND.MaNguoiDung = {maNguoiNhan}";
                    result = db.ExecuteQuery(query);
                }

                if (result.Rows.Count == 0)
                {
                    // Nếu không tìm thấy trong bảng GiaoVien và HocSinh, kiểm tra vai trò "Nhân viên phòng nội vụ"
                    query = $@"
                    SELECT ND.TenDangNhap, VT.TenVaiTro
                    FROM NguoiDung ND
                    INNER JOIN VaiTro VT ON ND.MaVaiTro = VT.MaVaiTro
                    WHERE ND.MaNguoiDung = {maNguoiNhan} AND VT.TenVaiTro = N'Nhân viên phòng nội vụ'";
                    result = db.ExecuteQuery(query);

                    if (result.Rows.Count > 0)
                    {
                        string vaiTro = result.Rows[0]["TenVaiTro"].ToString();
                        // Chỉ trả về vai trò mà không thêm tên đăng nhập
                        return vaiTro;
                    }
                }

                if (result.Rows.Count > 0)
                {
                    string vaiTro = result.Rows[0]["TenVaiTro"].ToString();
                    string hoTen = result.Rows[0]["TenDayDu"].ToString();
                    return $"{vaiTro} {hoTen}";
                }
                else
                {
                    // Nếu không tìm thấy thông tin
                    return "Không xác định";
                }
            }
            else if (row["MaVaiTroNhan"] != DBNull.Value)
            {
                // Trường hợp gửi cho vai trò hoặc phòng ban
                int maVaiTro = Convert.ToInt32(row["MaVaiTroNhan"]);
                string query = $@"
                SELECT TenVaiTro
                FROM VaiTro
                WHERE MaVaiTro = {maVaiTro}";
                DataTable result = db.ExecuteQuery(query);

                if (result.Rows.Count > 0)
                {
                    return result.Rows[0]["TenVaiTro"].ToString(); // Trả về tên vai trò hoặc phòng ban
                }
            }
            else if (row["MaLop"] != DBNull.Value)
            {
                // Trường hợp gửi cho lớp
                string query = $@"
                SELECT TenLop
                FROM LopHoc
                WHERE MaLop IN ({row["MaLop"]})";
                DataTable result = db.ExecuteQuery(query);

                if (result.Rows.Count > 0)
                {
                    return string.Join(", ", result.AsEnumerable().Select(r => r["TenLop"].ToString()));
                }
            }

            // Trường hợp không có thông tin người nhận
            return "Không có thông tin người nhận";
        }
        private void ucXemThuDaGui_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvXemThu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dgvXemThu.ClearSelection();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvXemThu.SelectedRows.Count > 0)
                {
                    // Hiển thị hộp thoại xác nhận
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thư đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DatabaseHelper db = new DatabaseHelper();
                        db.OpenConnection();

                        // Lặp qua tất cả các dòng được chọn
                        foreach (DataGridViewRow selectedRow in dgvXemThu.SelectedRows)
                        {
                            // Lấy giá trị MaTB từ cột tương ứng
                            if (selectedRow.Cells["MaTB"].Value != null)
                            {
                                int maTB = Convert.ToInt32(selectedRow.Cells["MaTB"].Value);

                                // Xóa bản ghi trong cơ sở dữ liệu
                                string deleteQuery = $"DELETE FROM ThongBao WHERE MaTB = {maTB}";
                                db.ExecuteNonQuery(deleteQuery);

                                // Xóa dòng khỏi DataGridView
                                dgvXemThu.Rows.Remove(selectedRow);
                            }
                        }

                        MessageBox.Show("Xóa thư đã chọn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một thư để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa thư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                MessageBox.Show("Dữ liệu đã được làm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi làm mới dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvXemThu.ClearSelection();
        }
    }
}
