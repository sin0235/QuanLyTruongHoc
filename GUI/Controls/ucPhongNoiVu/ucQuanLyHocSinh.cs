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
using QuanLyTruongHoc.GUI.Forms;

namespace QuanLyTruongHoc.GUI.Controls.ucPhongNoiVu
{
    public partial class ucQuanLyHocSinh : UserControl
    {
        private DatabaseHelper db;
        public ucQuanLyHocSinh()
        {
            InitializeComponent();
            db = new DatabaseHelper();
            LoadHocSinhData();
            LoadLop();
            this.Load += ucQuanLyHocSinh_Load;
        }

        private void LoadHocSinhData()
        {
            try
            {
                string query = @"
                    SELECT 
                        hs.MaHS, 
                        hs.MaNguoiDung, 
                        hs.HoTen, 
                        hs.NgaySinh, 
                        hs.GioiTinh, 
                        hs.DiaChi, 
                        hs.SDTPhuHuynh, 
                        lh.TenLop AS MaLop
                    FROM HocSinh hs
                    INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop";
                DataTable dataTable = db.ExecuteQuery(query);
                dgvHocSinh.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvHocSinh.ClearSelection();
        }

        private void LoadLop()
        {
            try
            {
                string query = "SELECT MaLop, TenLop FROM LopHoc";
                DataTable dt = db.ExecuteQuery(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    cbLop.DataSource = dt;
                    cbLop.DisplayMember = "TenLop";
                    cbLop.ValueMember = "MaLop";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu lớp học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHocSinhData(int? maLop = null)
        {
            try
            {
                string query = @"
            SELECT 
                hs.MaHS, 
                hs.MaNguoiDung, 
                hs.HoTen, 
                hs.NgaySinh, 
                hs.GioiTinh, 
                hs.DiaChi, 
                hs.SDTPhuHuynh, 
                lh.TenLop AS MaLop
            FROM HocSinh hs
            INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop";

                if (maLop.HasValue)
                {
                    query += " WHERE hs.MaLop = " + maLop.Value;
                }

                DataTable dataTable = db.ExecuteQuery(query);
                dgvHocSinh.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu học sinh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvHocSinh.ClearSelection();
        }

        private void ucQuanLyHocSinh_Load(object sender, EventArgs e)
        {
            dgvHocSinh.ClearSelection();
            dgvHocSinh.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dgvHocSinh.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            cbLop.SelectedIndex = -1;
        }

        private void dgvHocSinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLop.SelectedValue != null && int.TryParse(cbLop.SelectedValue.ToString(), out int maLop))
            {
                LoadHocSinhData(maLop); 
            }
            else
            {
                LoadHocSinhData();
            }
        }

        private void btnThemHocSinh_Click(object sender, EventArgs e)
        {
            frmQuanLyHocSinh frm = new frmQuanLyHocSinh();
            frm.StartPosition = FormStartPosition.CenterScreen; // Hiển thị chính giữa màn hình
            frm.ShowDialog(); // Hiển thị form dưới dạng modal
            LoadHocSinhData(); // Tải lại danh sách học sinh sau khi thêm
        }
    }
}
