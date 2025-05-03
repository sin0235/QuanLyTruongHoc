using QuanLyTruongHoc.DAL;
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
    public partial class ucQuanLyLop_GVCN : UserControl
    {
        private readonly DatabaseHelper db = new DatabaseHelper();
        private int maGVChuNhiem;
        public ucQuanLyLop_GVCN(int maGVChuNhiem)
        {
            InitializeComponent();
            this.maGVChuNhiem = maGVChuNhiem;
            LoadStudentList();
        }
        private void LoadStudentList()
        {
            try
            {
                // Truy vấn danh sách học sinh trong lớp của GVCN
                string query = $@"
        SELECT 
            ROW_NUMBER() OVER (ORDER BY hs.HoTen) AS STT,
            hs.MaHS,
            hs.HoTen,
            hs.NgaySinh,
            hs.GioiTinh,
            hs.DiaChi,
            hs.SDTPhuHuynh
        FROM HocSinh hs
        INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
        WHERE lh.MaGVChuNhiem = {maGVChuNhiem}";

                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    dgvHocSinh.AutoGenerateColumns = false; // Tắt tự động sinh cột
                    dgvHocSinh.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có học sinh nào trong lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvHocSinh.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách học sinh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvHocSinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin học sinh từ hàng được chọn
                DataGridViewRow row = dgvHocSinh.Rows[e.RowIndex];
                txtSTT.Text = row.Cells["STT"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtNgaySinh.Text = Convert.ToDateTime(row.Cells["NgaySinh"].Value).ToString("dd/MM/yyyy");
                txtGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDTPhuHuynh.Text = row.Cells["SDTPhuHuynh"].Value.ToString();
            }
        }
    }
}
