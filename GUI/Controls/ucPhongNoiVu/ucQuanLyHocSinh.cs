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
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            LoadHocSinhData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHocSinh.SelectedRows.Count > 0)
            {
                // Lấy thông tin từ dòng được chọn
                DataGridViewRow selectedRow = dgvHocSinh.SelectedRows[0];
                int maHS = Convert.ToInt32(selectedRow.Cells["MaHS"].Value);
                string hoTen = selectedRow.Cells["HoTen"].Value.ToString();
                DateTime ngaySinh = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                string gioiTinh = selectedRow.Cells["GioiTinh"].Value.ToString();
                string diaChi = selectedRow.Cells["DiaChi"].Value.ToString();
                string sdtPhuHuynh = selectedRow.Cells["SDTPhuHuynh"].Value.ToString();
                string tenLop = selectedRow.Cells["MaLop"].Value.ToString();

                // Hiển thị form sửa thông tin
                frmQuanLyHocSinh frm = new frmQuanLyHocSinh(maHS, hoTen, ngaySinh, gioiTinh, diaChi, sdtPhuHuynh, tenLop);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();

                // Tải lại dữ liệu sau khi sửa
                LoadHocSinhData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học sinh để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHocSinh.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một học sinh để xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin từ dòng được chọn
                DataGridViewRow selectedRow = dgvHocSinh.SelectedRows[0];
                int maHS = Convert.ToInt32(selectedRow.Cells["MaHS"].Value);
                int maNguoiDung = Convert.ToInt32(selectedRow.Cells["MaNguoiDung"].Value);
                string hoTen = selectedRow.Cells["HoTen"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa học sinh {hoTen} và tài khoản liên kết không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    db.OpenConnection();

                    // Sử dụng transaction để đảm bảo hoặc cả hai bảng đều được xóa hoặc không bảng nào bị xóa
                    List<string> deleteCommands = new List<string>
                    {
                    // Xóa học sinh trước vì có khóa ngoại tham chiếu đến NguoiDung
                    $"DELETE FROM HocSinh WHERE MaHS = {maHS}",
                    // Sau đó xóa người dùng
                    $"DELETE FROM NguoiDung WHERE MaNguoiDung = {maNguoiDung}"
                    };

                    bool success = db.ExecuteTransaction(deleteCommands);

                    if (success)
                    {
                        MessageBox.Show($"Đã xóa học sinh {hoTen} và tài khoản liên kết thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại dữ liệu sau khi xóa
                        LoadHocSinhData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa học sinh thất bại! Có thể còn dữ liệu liên quan đến học sinh này.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa học sinh: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvHocSinh.ClearSelection();
            cbLop.SelectedIndex = -1;
            try
            {
                LoadHocSinhData();
                MessageBox.Show("Dữ liệu đã được làm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi làm mới dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTimKiem.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    MessageBox.Show("Vui lòng nhập tên học sinh cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = $@"
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
                INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                WHERE hs.HoTen LIKE N'%{searchText}%'";

                DataTable dataTable = db.ExecuteQuery(query);

                if (dataTable.Rows.Count > 0)
                {
                    dgvHocSinh.DataSource = dataTable;
                    dgvHocSinh.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy học sinh nào với tên đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvHocSinh.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
