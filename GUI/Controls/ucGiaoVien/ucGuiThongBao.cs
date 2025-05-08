using Guna.UI2.WinForms;
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
        private int maNguoiDung;
        private int maGV;
        private readonly DatabaseHelper db;
        public ucGuiThongBao(int maNguoiDung, int maGV)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            this.maGV = maGV;
            this.maNguoiDung = maNguoiDung;

            LoadLopHoc();
            LoadThongBao();
        }


        public void LoadThongBao(int? selectedMaLop = null)
        {
            try
            {
                string query;
                if (selectedMaLop.HasValue)
                {
                    // Filter by both teacher and selected class
                    query = $@"
            SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, lh.TenLop
            FROM ThongBao tb
            LEFT JOIN LopHoc lh ON tb.MaLop = lh.MaLop
            WHERE tb.MaNguoiGui = {maNguoiDung} AND tb.MaLop = {selectedMaLop}";
                }
                else
                {
                    // Only filter by teacher
                    query = $@"
            SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, lh.TenLop
            FROM ThongBao tb
            LEFT JOIN LopHoc lh ON tb.MaLop = lh.MaLop
            WHERE tb.MaNguoiGui = {maNguoiDung}";
                }

                DataTable dt = db.ExecuteQuery(query);
                dgvGuiThongBao.DataSource = dt;

                // Update the title to show filtering status
                string filterStatus = selectedMaLop.HasValue ? $"Lọc theo lớp: {lopCmb.Text}" : "Tất cả các lớp";
                lblThongBao.Text = $"Thông báo ({filterStatus})";
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

                // Check if something is selected in the ComboBox
                if (lopCmb.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một lớp học trước khi gửi thông báo.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maLop = Convert.ToInt32(lopCmb.SelectedValue);

                if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(noiDung))
                {
                    MessageBox.Show("Tiêu đề và nội dung không thể để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Avoid SQL injection by escaping single quotes
                tieuDe = tieuDe.Replace("'", "''");
                noiDung = noiDung.Replace("'", "''");

                string query = $@"
        INSERT INTO ThongBao (MaNguoiGui, MaLop, TieuDe, NoiDung, NgayGui, isActive)
        VALUES ({maNguoiDung}, {maLop}, N'{tieuDe}', N'{noiDung}', GETDATE(), 1)";

                if (db.ExecuteNonQuery(query))
                {
                    MessageBox.Show("Thêm thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Clear input fields after successful insertion
                    tieuDeTxt.Text = "";
                    thongBaoTxt.Text = "";

                    // Get the current filter (if any) from the title label
                    bool isFiltered = thongBaoTxt.Text.Contains("Lọc theo lớp");
                    if (isFiltered && lopCmb.SelectedValue != null)
                    {
                        LoadThongBao(Convert.ToInt32(lopCmb.SelectedValue));
                    }
                    else
                    {
                        LoadThongBao(null);
                    }
                }
                else
                {
                    MessageBox.Show("Thêm thông báo thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (InvalidCastException icex)
            {
                MessageBox.Show($"Lỗi khi chuyển đổi dữ liệu: {icex.Message}\nVui lòng kiểm tra lại thông tin lớp học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                            // Get the current filter (if any) from the title label
                            bool isFiltered = thongBaoTxt.Text.Contains("Lọc theo lớp");
                            if (isFiltered && lopCmb.SelectedValue != null)
                            {
                                LoadThongBao(Convert.ToInt32(lopCmb.SelectedValue));
                            }
                            else
                            {
                                LoadThongBao(null);
                            }
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

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGuiThongBao.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dgvGuiThongBao.SelectedRows[0];
                    if (selectedRow.Cells["MaTB"].Value == null)
                    {
                        MessageBox.Show("Không thể xác định thông báo được chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int maTB = Convert.ToInt32(selectedRow.Cells["MaTB"].Value);

                    // Get the updated values from the user
                    string tieuDe = tieuDeTxt.Text.Trim();
                    string noiDung = thongBaoTxt.Text.Trim();

                    if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(noiDung))
                    {
                        MessageBox.Show("Tiêu đề và nội dung không thể để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Avoid SQL injection
                    tieuDe = tieuDe.Replace("'", "''");
                    noiDung = noiDung.Replace("'", "''");

                    // Update the notification in the database
                    string query = $@"
                UPDATE ThongBao
                SET TieuDe = N'{tieuDe}', NoiDung = N'{noiDung}'
                WHERE MaTB = {maTB}";

                    if (db.ExecuteNonQuery(query))
                    {
                        MessageBox.Show("Cập nhật thông báo thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Get the current filter (if any) from the title label
                        bool isFiltered = thongBaoTxt.Text.Contains("Lọc theo lớp");
                        if (isFiltered && lopCmb.SelectedValue != null)
                        {
                            LoadThongBao(Convert.ToInt32(lopCmb.SelectedValue));
                        }
                        else
                        {
                            LoadThongBao(null);
                        }
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
            catch (InvalidCastException icex)
            {
                MessageBox.Show($"Lỗi khi chuyển đổi dữ liệu: {icex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chỉnh sửa thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lopCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvGuiThongBao_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (lopCmb.SelectedValue != null)
                {
                    int selectedMaLop = Convert.ToInt32(lopCmb.SelectedValue);
                    LoadThongBao(selectedMaLop);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một lớp để lọc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            LoadThongBao(null);
        }

        private void dgvGuiThongBao_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Make sure a valid row is double-clicked (not header row)
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvGuiThongBao.Rows[e.RowIndex];

                    // Fill text fields with notification data
                    tieuDeTxt.Text = row.Cells["TieuDe"].Value?.ToString() ?? string.Empty;
                    thongBaoTxt.Text = row.Cells["NoiDung"].Value?.ToString() ?? string.Empty;

                    // Find and select the matching class in the ComboBox
                    string tenLop = row.Cells["TenLop"].Value?.ToString();
                    if (!string.IsNullOrEmpty(tenLop))
                    {
                        // Query database to get the MaLop for this notification
                        string query = $@"
                SELECT MaLop 
                FROM ThongBao 
                WHERE MaTB = {row.Cells["MaTB"].Value}";

                        DataTable dt = db.ExecuteQuery(query);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            int maLop = Convert.ToInt32(dt.Rows[0]["MaLop"]);

                            // Find the corresponding index in the ComboBox
                            for (int i = 0; i < lopCmb.Items.Count; i++)
                            {
                                DataRowView drv = (DataRowView)lopCmb.Items[i];
                                if (Convert.ToInt32(drv["MaLop"]) == maLop)
                                {
                                    lopCmb.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }

                    // Optional: Scroll to the selected row to ensure it's visible
                    dgvGuiThongBao.CurrentCell = dgvGuiThongBao.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị thông tin thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
