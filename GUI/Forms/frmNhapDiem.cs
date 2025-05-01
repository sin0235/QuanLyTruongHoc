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
        private readonly ucQuanLyDiemSo ucQuanLyDiemSoRef;

        public frmNhapDiem(int maGV, ucQuanLyDiemSo ucQuanLyDiemSo)
        {
            InitializeComponent();
            this.maGV = maGV;
            this.ucQuanLyDiemSoRef = ucQuanLyDiemSo;
            db = new DatabaseHelper();
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

                int stt = int.Parse(sttTxt.Text);

                // Tìm kiếm trong DataGridView của ucQuanLyDiemSo
                var dgv = ucQuanLyDiemSoRef.dgvDanhSachHocSinh;
                string hoTen = null;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["STT"].Value != null && int.Parse(row.Cells["STT"].Value.ToString()) == stt)
                    {
                        // Lấy tên học sinh
                        hoTen = row.Cells["HoTen"].Value.ToString();
                        break;
                    }
                }

                if (hoTen == null)
                {
                    MessageBox.Show("Không tìm thấy học sinh với STT đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Điền tên học sinh vào textbox
                hoTenTxt.Text = hoTen;

                // Tải thông tin điểm từ cơ sở dữ liệu
                LoadStudentScores(stt);
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
                // Truy vấn để lấy thông tin điểm của học sinh
                string query = $@"
                    SELECT 
                        DS.MaDiem AS [Mã Điểm],
                        M.TenMon AS [Tên Môn],
                        DS.HocKy AS [Học Kỳ],
                        DS.LoaiDiem AS [Loại Điểm],
                        DS.Diem AS [Điểm]
                    FROM DiemSo DS
                    INNER JOIN MonHoc M ON DS.MaMon = M.MaMon
                    WHERE DS.MaHS = {maHS}";

                DataTable dt = db.ExecuteQuery(query);

                // Kiểm tra nếu không có dữ liệu
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin điểm của học sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu vào DataGridView
                dgvDiemChiTietHocSinh.DataSource = dt;
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

                // Lấy giá trị từ các trường
                int maHS = int.Parse(sttTxt.Text);
                string loaiDiem = loaiDiemCmb.Text;
                float diem = float.Parse(diemTxt.Text);
                int hocKy = int.Parse(cmbHocKi.SelectedValue.ToString());

                // Kiểm tra giá trị điểm hợp lệ
                if (diem < 0 || diem > 10)
                {
                    MessageBox.Show("Điểm phải nằm trong khoảng từ 0 đến 10.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                // Truy vấn thêm điểm trực tiếp
                string query = $@"
                    INSERT INTO DiemSo (MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem)
                    VALUES ({maHS}, {maMon}, {maGV}, {hocKy}, N'{loaiDiem}', {diem})";

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
    }
}
