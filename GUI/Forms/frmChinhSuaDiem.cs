using QuanLyTruongHoc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmChinhSuaDiem : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private int selectedMaHS;
        private int selectedMaMon;
        private DataGridView dgvDanhSachHocSinh;

        public frmChinhSuaDiem(int maHS, int maMon, DataGridView dgvDanhSachHocSinh)
        {
            InitializeComponent();
            selectedMaHS = maHS;
            selectedMaMon = maMon;

            if (dgvDanhSachHocSinh == null)
            {
                MessageBox.Show("Danh sách học sinh không được truyền vào.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.dgvDanhSachHocSinh = dgvDanhSachHocSinh;

            // Tải dữ liệu điểm của học sinh
            LoadStudentScores(selectedMaHS, selectedMaMon);
        }



        private void LoadStudentList()
        {
            if (dgvDanhSachHocSinh == null)
            {
                MessageBox.Show("Không thể tải danh sách học sinh vì DataGridView chưa được khởi tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = @"
        SELECT 
            ROW_NUMBER() OVER (ORDER BY HS.MaHS) AS STT,
            HS.MaHS,
            HS.HoTen,
            L.TenLop
        FROM HocSinh HS
        INNER JOIN LopHoc L ON HS.MaLop = L.MaLop";

                DataTable dt = db.ExecuteQuery(query);
                dgvDanhSachHocSinh.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách học sinh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadStudentScores(int maHS, int maMon)
        {
            try
            {
                string query = $@"
        SELECT 
            ROW_NUMBER() OVER (ORDER BY DS.LoaiDiem) AS STT,
            DS.LoaiDiem AS [Loại điểm],
            DS.Diem AS [Điểm],
            DS.HocKy AS [Học kỳ]
        FROM DiemSo DS
        WHERE DS.MaHS = {maHS} AND DS.MaMon = {maMon}";

                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy điểm của học sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDiemChiTietHocSinh.DataSource = null; // Xóa dữ liệu cũ
                    return;
                }

                dgvDiemChiTietHocSinh.AutoGenerateColumns = false; // Ngăn tự động tạo cột
                dgvDiemChiTietHocSinh.Columns.Clear(); // Xóa các cột cũ

                // Thêm cột và ánh xạ dữ liệu
                dgvDiemChiTietHocSinh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "STT", DataPropertyName = "STT", Name = "STT" });
                dgvDiemChiTietHocSinh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại điểm", DataPropertyName = "Loại điểm", Name = "LoaiDiem" });
                dgvDiemChiTietHocSinh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Điểm", DataPropertyName = "Điểm", Name = "Diem" });
                dgvDiemChiTietHocSinh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Học kỳ", DataPropertyName = "Học kỳ", Name = "HocKy" });

                dgvDiemChiTietHocSinh.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dgvDiemChiTietHocSinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDiemChiTietHocSinh.Rows[e.RowIndex];
                loaiDiemCmb.Text = row.Cells["LoaiDiem"].Value.ToString();
                diemTxt.Text = row.Cells["Diem"].Value.ToString();
                cmbHocKi.Text = row.Cells["HocKy"].Value.ToString();
            }
        }

        private void chinhSuaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string loaiDiem = loaiDiemCmb.Text;
                float diem = float.Parse(diemTxt.Text);
                int hocKy = int.Parse(cmbHocKi.Text.Replace("Học kỳ ", ""));

                string query = $@"
                UPDATE DiemSo
                SET Diem = {diem}
                WHERE MaHS = {selectedMaHS} AND MaMon = {selectedMaMon} 
                AND LoaiDiem = N'{loaiDiem}' AND HocKy = {hocKy}";

                bool success = db.ExecuteNonQuery(query);
                if (success)
                {
                    MessageBox.Show("Cập nhật điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudentScores(selectedMaHS, selectedMaMon); // Tải lại danh sách điểm
                }
                else
                {
                    MessageBox.Show("Cập nhật điểm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy STT từ textbox
                if (string.IsNullOrWhiteSpace(sttTxt.Text))
                {
                    MessageBox.Show("Vui lòng nhập STT.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(sttTxt.Text, out int stt))
                {
                    MessageBox.Show("STT phải là số nguyên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tìm kiếm trong DataGridView danh sách học sinh
                foreach (DataGridViewRow row in dgvDanhSachHocSinh.Rows)
                {
                    if (row.Cells["STT"].Value != null && int.Parse(row.Cells["STT"].Value.ToString()) == stt)
                    {
                        // Điền thông tin học sinh vào các trường
                        string hoTen = row.Cells["HoTen"].Value.ToString();
                        hoTenTxt.Text = hoTen;

                        selectedMaHS = Convert.ToInt32(row.Cells["MaHS"].Value);

                        // Tải thông tin điểm của học sinh
                        LoadStudentScores(selectedMaHS, selectedMaMon);
                        return;
                    }
                }

                MessageBox.Show("Không tìm thấy học sinh với STT đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmChinhSuaDiem_Load(object sender, EventArgs e)
        {
            LoadStudentList();
        }

        private void xoaBtn_Click(object sender, EventArgs e)
        {
            if (dgvDiemChiTietHocSinh.SelectedRows.Count > 0)
            {
                // Lấy thông tin từ hàng được chọn
                var selectedRow = dgvDiemChiTietHocSinh.SelectedRows[0];

                // Lấy loại điểm và giá trị điểm
                string loaiDiem = selectedRow.Cells["LoaiDiem"].Value?.ToString();
                string diemValue = selectedRow.Cells["Diem"].Value?.ToString();
                string hocKy = selectedRow.Cells["HocKy"].Value?.ToString();

                if (string.IsNullOrEmpty(loaiDiem) || string.IsNullOrEmpty(diemValue) || string.IsNullOrEmpty(hocKy))
                {
                    MessageBox.Show("Không thể xác định điểm cần xóa. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận xóa
                var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa điểm {diemValue} ({loaiDiem}, Học kỳ {hocKy}) không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // Xóa điểm trong cơ sở dữ liệu
                    string deleteQuery = @"
                DELETE FROM DiemSo
                WHERE MaHS = @MaHS AND MaMon = @MaMon AND LoaiDiem = @LoaiDiem AND Diem = @Diem AND HocKy = @HocKy";
                    var parameters = new Dictionary<string, object>
            {
                { "@MaHS", selectedMaHS },
                { "@MaMon", selectedMaMon },
                { "@LoaiDiem", loaiDiem },
                { "@Diem", diemValue },
                { "@HocKy", hocKy }
            };

                    if (db.ExecuteNonQuery(deleteQuery, parameters))
                    {
                        MessageBox.Show("Xóa điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadStudentScores(selectedMaHS, selectedMaMon); // Làm mới danh sách điểm
                    }
                    else
                    {
                        MessageBox.Show("Xóa điểm thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
