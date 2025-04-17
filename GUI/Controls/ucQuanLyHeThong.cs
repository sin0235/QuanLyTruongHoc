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
        }
        private void ConfigureDataGridView()
        {
            dgvQuanLyHeThong.AllowUserToAddRows = false;
            dgvQuanLyHeThong.ReadOnly = true;
            dgvQuanLyHeThong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvQuanLyHeThong.ColumnHeadersHeight = 40;
            dgvQuanLyHeThong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvQuanLyHeThong.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvQuanLyHeThong.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvQuanLyHeThong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; 
            dgvQuanLyHeThong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
        private void LoadData()
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
            dgvQuanLyHeThong.DataSource = dt;
            dgvQuanLyHeThong.Columns["MaNguoiDung"].Visible = false;
            dgvQuanLyHeThong.Columns["NguoiHanhDong"].HeaderText = "Người hành động";
            dgvQuanLyHeThong.Columns["HanhDong"].HeaderText = "Hành động";
            dgvQuanLyHeThong.Columns["ThoiGian"].HeaderText = "Thời gian";

            ConfigureDataGridView();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ucQuanLyHeThong_Load(object sender, EventArgs e)
        {
            btnLamMoi.Left = (this.Width - btnLamMoi.Width) / 2;
        }
    }
}
