using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QuanLyTruongHoc.DAL;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucQuanLyHeThong : UserControl
    {
        public ucQuanLyHeThong()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadData();
            this.Load += ucQuanLyHeThong_Load;
            this.VisibleChanged += UcQuanLyHeThong_VisibleChanged;
        }
        private void ConfigureDataGridView()
        {
            dgvQuanLyHeThong.EnableHeadersVisualStyles = false;
            dgvQuanLyHeThong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            if (dgvQuanLyHeThong.Columns.Contains("MaNguoiDung"))
                dgvQuanLyHeThong.Columns["MaNguoiDung"].Visible = false;

            if (dgvQuanLyHeThong.Columns.Contains("NguoiHanhDong"))
                dgvQuanLyHeThong.Columns["NguoiHanhDong"].HeaderText = "Người hành động";

            if (dgvQuanLyHeThong.Columns.Contains("HanhDong"))
                dgvQuanLyHeThong.Columns["HanhDong"].HeaderText = "Hành động";

            if (dgvQuanLyHeThong.Columns.Contains("ThoiGian"))
                dgvQuanLyHeThong.Columns["ThoiGian"].HeaderText = "Thời gian";
        }

        private void dgvQuanLyHeThong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private bool LoadData()
        {
            try
            {
                string query = @"
                SELECT NK.MaNguoiDung, 
                CASE 
                WHEN ND.MaVaiTro = 1 THEN N'Ban giám hiệu'
                WHEN ND.MaVaiTro = 2 THEN GV.HoTen
                WHEN ND.MaVaiTro = 3 THEN HS.HoTen
                ELSE N'Không xác định'
                END AS NguoiHanhDong,
                    NK.HanhDong,
                FORMAT(NK.ThoiGian, 'yyyy-MM-dd HH:mm:ss') AS ThoiGian
                FROM NhatKyHeThong NK
                LEFT JOIN NguoiDung ND ON NK.MaNguoiDung = ND.MaNguoiDung
                LEFT JOIN GiaoVien GV ON ND.MaNguoiDung = GV.MaNguoiDung
                LEFT JOIN HocSinh HS ON ND.MaNguoiDung = HS.MaNguoiDung";

                DatabaseHelper db = new DatabaseHelper();
                DataTable dt = db.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvQuanLyHeThong.DataSource = dt;
                    dgvQuanLyHeThong.Columns["MaNguoiDung"].Visible = false;
                    dgvQuanLyHeThong.Columns["NguoiHanhDong"].HeaderText = "Người hành động";
                    dgvQuanLyHeThong.Columns["HanhDong"].HeaderText = "Hành động";
                    dgvQuanLyHeThong.Columns["ThoiGian"].HeaderText = "Thời gian";
                    dgvQuanLyHeThong.ClearSelection();
                    ConfigureDataGridView();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if (LoadData())
            {
                MessageBox.Show("Đã lấy dữ liệu mới nhất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Làm mới không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CenterControls()
        {
            btnLamMoi.Left = (this.Width - btnLamMoi.Width) / 2;
            dgvQuanLyHeThong.Left = (this.Width - dgvQuanLyHeThong.Width) / 2;
            dgvQuanLyHeThong.ClearSelection();
        }

        private void UcQuanLyHeThong_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                CenterControls();
            }
        }

        private void ucQuanLyHeThong_Load(object sender, EventArgs e)
        {
            CenterControls();
        }
    }
}
