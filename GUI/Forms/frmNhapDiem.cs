using Guna.UI2.WinForms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.GUI.Controls.ucGiaoVien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmNhapDiem : Form
    {
        private readonly DatabaseHelper db;
        private readonly int maGV;
        private DataGridView dgvDanhSachHocSinh;

        public frmNhapDiem(int maGV, DataGridView dgvDanhSachHocSinh)
        {
            InitializeComponent();
            this.maGV = maGV;
            db = new DatabaseHelper();
            this.dgvDanhSachHocSinh = dgvDanhSachHocSinh;
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Load LoaiDiem từ bảng DiemSo
                string queryLoaiDiem = "SELECT DISTINCT LoaiDiem FROM DiemSo";
                DataTable dtLoaiDiem = db.ExecuteQuery(queryLoaiDiem);

                if (dtLoaiDiem.Rows.Count > 0)
                {
                    loaiDiemCmb.DataSource = dtLoaiDiem;
                    loaiDiemCmb.DisplayMember = "LoaiDiem";
                    loaiDiemCmb.ValueMember = "LoaiDiem";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu Loại Điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Load HocKy từ bảng DiemSo
                string queryHocKy = "SELECT DISTINCT HocKy FROM DiemSo";
                DataTable dtHocKy = db.ExecuteQuery(queryHocKy);

                if (dtHocKy.Rows.Count > 0)
                {
                    cmbHocKi.DataSource = dtHocKy;
                    cmbHocKi.DisplayMember = "HocKy";
                    cmbHocKi.ValueMember = "HocKy";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu Học Kỳ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu ComboBox: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Tìm kiếm trong DataGridView
                foreach (DataGridViewRow row in dgvDanhSachHocSinh.Rows)
                {
                    if (row.Cells["STT"].Value != null && int.Parse(row.Cells["STT"].Value.ToString()) == stt)
                    {
                        // Điền tên học sinh vào textbox
                        string hoTen = row.Cells["HoTen"].Value.ToString();
                        hoTenTxt.Text = hoTen;

                        // Truy vấn để lấy mã học sinh từ tên
                        string query = $@"
                        SELECT MaHS
                        FROM HocSinh
                        WHERE HoTen = N'{hoTen}'";

                        object maHSObj = db.ExecuteScalar(query);

                        if (maHSObj == null)
                        {
                            MessageBox.Show("Không tìm thấy học sinh với tên đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        int maHS = Convert.ToInt32(maHSObj);

                        // Tải thông tin điểm chi tiết của học sinh
                        LoadStudentScores(maHS);
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

        private void LoadStudentScores(int maHS)
        {
            try
            {
                // Adjusted query to group scores by subject and type
                string query = $@"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY M.TenMon) AS [STT],
                    M.TenMon AS [TenMon],
                    MAX(CASE WHEN DS.LoaiDiem = N'Miệng' THEN DS.Diem END) AS [DiemMieng],
                    MAX(CASE WHEN DS.LoaiDiem = N'15 phút' THEN DS.Diem END) AS [Diem15Phut],
                    MAX(CASE WHEN DS.LoaiDiem = N'Giữa kỳ' THEN DS.Diem END) AS [DiemGiuaKy],
                    MAX(CASE WHEN DS.LoaiDiem = N'Cuối kỳ' THEN DS.Diem END) AS [DiemCuoiKy],
                    AVG(DS.Diem) AS [DiemTrungBinh]
                FROM DiemSo DS
                INNER JOIN MonHoc M ON DS.MaMon = M.MaMon
                WHERE DS.MaHS = {maHS}
                GROUP BY M.TenMon";

                DataTable dt = db.ExecuteQuery(query);

                // Check if no data is returned
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin điểm của học sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDiemChiTietHocSinh.DataSource = null;
                    return;
                }

                // Ensure AutoGenerateColumns is false
                dgvDiemChiTietHocSinh.AutoGenerateColumns = false;

                // Bind the data to the DataGridView
                dgvDiemChiTietHocSinh.DataSource = dt;

                // Map columns to DataGridView
                dgvDiemChiTietHocSinh.Columns["STT"].DataPropertyName = "STT";
                dgvDiemChiTietHocSinh.Columns["TenMon"].DataPropertyName = "TenMon";
                dgvDiemChiTietHocSinh.Columns["DiemMieng"].DataPropertyName = "DiemMieng";
                dgvDiemChiTietHocSinh.Columns["Diem15Phut"].DataPropertyName = "Diem15Phut";
                dgvDiemChiTietHocSinh.Columns["DiemGiuaKy"].DataPropertyName = "DiemGiuaKy";
                dgvDiemChiTietHocSinh.Columns["DiemCuoiKy"].DataPropertyName = "DiemCuoiKy";
                dgvDiemChiTietHocSinh.Columns["DiemTrungBinh"].DataPropertyName = "DiemTrungBinh";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường đầu vào
                if (string.IsNullOrWhiteSpace(sttTxt.Text) || string.IsNullOrWhiteSpace(hoTenTxt.Text) ||
                    string.IsNullOrWhiteSpace(loaiDiemCmb.Text) || string.IsNullOrWhiteSpace(diemTxt.Text) ||
                    cmbHocKi.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(sttTxt.Text, out int stt))
                {
                    MessageBox.Show("STT phải là số nguyên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string loaiDiem = loaiDiemCmb.Text;
                if (!float.TryParse(diemTxt.Text, out float diem))
                {
                    MessageBox.Show("Điểm phải là số thực.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int hocKy = int.Parse(cmbHocKi.SelectedValue.ToString());

                // Kiểm tra giá trị điểm hợp lệ
                if (diem < 0 || diem > 10)
                {
                    MessageBox.Show("Điểm phải nằm trong khoảng từ 0 đến 10.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mã học sinh từ Họ Tên
                string fetchMaHSQuery = $@"
                    SELECT MaHS
                    FROM HocSinh
                    WHERE HoTen = N'{hoTenTxt.Text}'";

                object maHSObj = db.ExecuteScalar(fetchMaHSQuery);
                if (maHSObj == null)
                {
                    MessageBox.Show("Không tìm thấy học sinh với STT đã nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int maHS = Convert.ToInt32(maHSObj);

                // Lấy mã môn học của giáo viên
                string fetchMaMonQuery = $@"
                    SELECT DISTINCT MaMon
                    FROM ThoiKhoaBieu
                    WHERE MaGV = {maGV}";

                object maMonObj = db.ExecuteScalar(fetchMaMonQuery);
                if (maMonObj == null)
                {
                    MessageBox.Show("Không thể xác định môn học của giáo viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int maMon = Convert.ToInt32(maMonObj);

                // Lấy giá trị lớn nhất của MaDiem và tăng thêm 1
                string fetchMaxMaDiemQuery = "SELECT ISNULL(MAX(MaDiem), 0) + 1 FROM DiemSo";
                int newMaDiem = Convert.ToInt32(db.ExecuteScalar(fetchMaxMaDiemQuery));

                // Truy vấn thêm điểm trực tiếp
                string query = $@"
                    INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem)
                    VALUES ({newMaDiem}, {maHS}, {maMon}, {maGV}, {hocKy}, N'{loaiDiem}', {diem})";

                // Thực thi truy vấn
                bool isInserted = db.ExecuteNonQuery(query);

                if (isInserted)
                {
                    MessageBox.Show("Thêm điểm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại danh sách điểm chi tiết của học sinh
                    LoadStudentScores(maHS);
                }
                else
                {
                    MessageBox.Show("Thêm điểm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhapDiem_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
        }
    }
}
