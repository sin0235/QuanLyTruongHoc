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
    public partial class ucGuiThongBao : UserControl
    {
        private int maGV;
        private readonly DatabaseHelper db;
        public ucGuiThongBao(int maGV)
        {
            InitializeComponent();
            this.maGV = maGV;
            db = new DatabaseHelper();
            LoadLopHoc();
            LoadThongBao();
        }


        public void LoadThongBao()
        {
            try
            {
                string query = $@"
                SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, lh.TenLop
                FROM ThongBao tb
                LEFT JOIN LopHoc lh ON tb.MaLop = lh.MaLop
                WHERE tb.MaNguoiGui = {maGV}";

                DataTable dt = db.ExecuteQuery(query);
                dgvGuiThongBao.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLopHoc()
        {
            try
            {
                // Query to fetch classes taught by the logged-in teacher
                // This assumes teachers have a relationship with classes through GiaoVien.MaMon and MonHoc
                string query = $@"
            SELECT DISTINCT lh.MaLop, lh.TenLop 
            FROM LopHoc lh
            INNER JOIN GiaoVien gv ON gv.MaGV = {maGV}
            INNER JOIN MonHoc mh ON gv.MaMon = mh.MaMon";

                // Execute the query and get the result as a DataTable
                DataTable dt = db.ExecuteQuery(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có lớp nào được phân công cho giáo viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lopCmb.DataSource = null;
                    return;
                }

                // Bind the result to the ComboBox
                lopCmb.DataSource = dt;
                lopCmb.DisplayMember = "TenLop"; // Display the class name
                lopCmb.ValueMember = "MaLop";   // Use the class ID as the value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách lớp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tieuDe = tieuDeTxt.Text.Trim();
                string noiDung = thongBaoTxt.Text.Trim();
                int maLop = Convert.ToInt32(lopCmb.SelectedValue);

                if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(noiDung))
                {
                    MessageBox.Show("Tiêu đề và nội dung không thể để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = $@"
        INSERT INTO ThongBao (MaNguoiGui, MaLop, TieuDe, NoiDung, NgayGui, isActive)
        VALUES ({maGV}, {maLop}, N'{tieuDe}', N'{noiDung}', GETDATE(), 1)";

                if (db.ExecuteNonQuery(query))
                {
                    MessageBox.Show("Thêm thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadThongBao();
                }
                else
                {
                    MessageBox.Show("Thêm thông báo thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGuiThongBao.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dgvGuiThongBao.SelectedRows[0];
                    int maTB = Convert.ToInt32(selectedRow.Cells["MaTB"].Value);

                    // Get the updated values from the user (e.g., from TextBoxes)
                    string tieuDe = tieuDeTxt.Text.Trim(); // Assume you have a TextBox for Title
                    string noiDung = thongBaoTxt.Text.Trim(); // Assume you have a TextBox for Content

                    if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(noiDung))
                    {
                        MessageBox.Show("Nội dung không thể để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Update the notification in the database
                    string query = $@"
                UPDATE ThongBao
                SET TieuDe = N'{tieuDe}', NoiDung = N'{noiDung}'
                WHERE MaTB = {maTB}";

                    if (db.ExecuteNonQuery(query))
                    {
                        MessageBox.Show("Cập nhật thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadThongBao(); // Refresh the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông báo thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một thông báo để chỉnh sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chỉnh sửa thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGuiThongBao.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dgvGuiThongBao.SelectedRows[0];
                    int maTB = Convert.ToInt32(selectedRow.Cells["MaTB"].Value);

                    // Confirm deletion
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông báo này?",
                                                          "Xác nhận xóa",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Delete the notification from the database
                        string query = $@"
                    DELETE FROM ThongBao
                    WHERE MaTB = {maTB}";

                        if (db.ExecuteNonQuery(query))
                        {
                            MessageBox.Show("Xóa thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadThongBao(); // Refresh the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Xóa thông báo thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một thông báo để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
