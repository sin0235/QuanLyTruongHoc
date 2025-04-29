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
        public ucXemThongBao()
        {
            InitializeComponent();
            db = new DatabaseHelper();
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
                    ThongBao.MaNguoiNhan IS NULL
                ORDER BY 
                    ThongBao.NgayGui DESC";
            DataTable dt = db.ExecuteQuery(query);
            thongBaoDgv.DataSource = dt;
        }


        // Hiển thị Thông Báo Cá Nhân
        private void LoadThongBaoCaNhan()
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
                    ThongBao.MaVaiTroNhan = 2
                ORDER BY 
                    ThongBao.NgayGui DESC";
            DataTable dt = db.ExecuteQuery(query);
            thongBaoDgv.DataSource = dt;
        }


        // Tìm kiếm thông báo
        private void TimKiemThongBao()
        {
            string keyword = timKiemTBTxt.Text.Trim();
            string selectedDate = thoiDiemDateTimePicker.Value.ToString("yyyy-MM-dd");

            string query = $@"
                SELECT TieuDe, NoiDung, NgayGui
                FROM ThongBao
                WHERE (TieuDe LIKE N'%{keyword}%' OR NoiDung LIKE N'%{keyword}%')
                AND CAST(NgayGui AS DATE) = '{selectedDate}'
                ORDER BY NgayGui DESC";

            DataTable dt = db.ExecuteQuery(query);
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
            if(thongBaoCaNhanBtn.Enabled)
            {
                LoadThongBaoCaNhan();
            }
            else
            {
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
