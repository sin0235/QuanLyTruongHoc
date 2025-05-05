using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.GUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls.ucGiaoVien
{
    public partial class ucXemThongBao : UserControl
    {
        private readonly DatabaseHelper db;
        private int maNguoiDung;
        public ucXemThongBao(int maNguoiDung)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            this.maNguoiDung = maNguoiDung;
            LoadThongBaoChung(); // Mặc định load tất cả thông báo
        }


        // Hiển thị Thông Báo Chung
        private void LoadThongBaoChung()
        {
            string query = @"
                SELECT 
                    ThongBao.TieuDe, 
                    ThongBao.NoiDung, 
                    ThongBao.NgayGui, 
                    NguoiDung.TenDangNhap AS NguoiGui
                FROM 
                    ThongBao
                INNER JOIN 
                    NguoiDung ON ThongBao.MaNguoiGui = NguoiDung.MaNguoiDung
                WHERE 
                    ThongBao.MaNguoiNhan IS NULL AND (ThongBao.MaVaiTroNhan IS NULL OR ThongBao.MaVaiTroNhan = 2)
                ORDER BY 
                    ThongBao.NgayGui DESC";
            DataTable dt = db.ExecuteQuery(query);
            thongBaoDgv.DataSource = dt;
        }



        // Hiển thị Thông Báo Cá Nhân
        private void LoadThongBaoCaNhan()
        {
            string query = $@"
                SELECT 
                    ThongBao.TieuDe, 
                    ThongBao.NoiDung, 
                    ThongBao.NgayGui, 
                    NguoiDung.TenDangNhap AS NguoiGui
                FROM 
                    ThongBao
                INNER JOIN 
                    NguoiDung ON ThongBao.MaNguoiGui = NguoiDung.MaNguoiDung
                WHERE 
                    ThongBao.MaNguoiNhan = {maNguoiDung}
                ORDER BY 
                    ThongBao.NgayGui DESC";
            DataTable dt = db.ExecuteQuery(query);
            thongBaoDgv.DataSource = dt;

        }




        // Tìm kiếm thông báo
        private void TimKiemThongBao()
        {
            string keyword = timKiemTBTxt.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
        SELECT 
            ThongBao.TieuDe, 
            ThongBao.NoiDung, 
            ThongBao.NgayGui, 
            NguoiDung.TenDangNhap AS NguoiGui
        FROM 
            ThongBao
        INNER JOIN 
            NguoiDung ON ThongBao.MaNguoiGui = NguoiDung.MaNguoiDung
        WHERE 
            (ThongBao.TieuDe LIKE @Keyword OR ThongBao.NoiDung LIKE @Keyword)
        ORDER BY 
            ThongBao.NgayGui DESC";

            var parameters = new Dictionary<string, object>
    {
        { "@Keyword", $"%{keyword}%" }
    };

            DataTable dt = db.ExecuteQuery(query, parameters);
            thongBaoDgv.DataSource = dt;
        }




        private void thongBaoChungBtn_Click(object sender, EventArgs e)
        {
            LoadThongBaoChung();
        }

        private void thongBaoCaNhanBtn_Click(object sender, EventArgs e)
        {
            LoadThongBaoCaNhan();
        }

        private void timKiemTBBtn_Click(object sender, EventArgs e)
        {
            TimKiemThongBao();
        }

        private void lamMoiTBBtn_Click(object sender, EventArgs e)
        {
            // Check which tab is currently active
            if (thongBaoCaNhanBtn.Focused) // If the "Personal Notifications" tab is active
            {
                LoadThongBaoCaNhan();
            }
            else if (thongBaoChungBtn.Focused) // If the "General Notifications" tab is active
            {
                LoadThongBaoChung();
            }
            else
            {
                // Default behavior: Reload general notifications
                LoadThongBaoChung();
            }
        }

        private void thongBaoDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào header
            {
                // Lấy thông tin từ dòng được chọn
                string tieuDe = thongBaoDgv.Rows[e.RowIndex].Cells["TieuDe"].Value.ToString();
                string noiDung = thongBaoDgv.Rows[e.RowIndex].Cells["NoiDung"].Value.ToString();
                string ngayGui = thongBaoDgv.Rows[e.RowIndex].Cells["NgayGui"].Value.ToString();
                string nguoiGui = thongBaoDgv.Rows[e.RowIndex].Cells["NguoiGui"].Value.ToString();

                // Tạo và hiển thị Form chi tiết
                var frmChiTiet = new frmThongBaoChiTiet(tieuDe, noiDung, ngayGui, nguoiGui);
                frmChiTiet.ShowDialog(); // Hiển thị dưới dạng modal
            }
        }
    }
}
