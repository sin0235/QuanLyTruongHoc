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
using System.Transactions;

namespace QuanLyTruongHoc.GUI.Controls.ucPhongNoiVu
{
    public partial class ucQuanLyLop : UserControl
    {
        private DatabaseHelper db;
        public ucQuanLyLop()
        {
            db = new DatabaseHelper();
            InitializeComponent();
            LoaddgvQuanLyLop();
        }

        private void ucQuanLyLop_Load(object sender, EventArgs e)
        {
            // Thiết lập kiểu hiển thị cho DataGridView
            dgvQuanLyLop.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dgvQuanLyLop.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            dgvQuanLyLop.ClearSelection();
        }
        private void LoaddgvQuanLyLop()
        {
            try
            {
                string query = @"
                    SELECT 
                        lh.TenLop AS Lop,
                        COUNT(hs.MaHS) AS SiSo,
                        gv.HoTen AS GVChuNhiem
                    FROM LopHoc lh
                    LEFT JOIN HocSinh hs ON lh.MaLop = hs.MaLop
                    LEFT JOIN GiaoVien gv ON lh.MaGVChuNhiem = gv.MaGV
                    GROUP BY lh.TenLop, gv.HoTen;
                ";
                DataTable dataTable = db.ExecuteQuery(query);
                dgvQuanLyLop.DataSource = dataTable;
                dgvQuanLyLop.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            frmQuanLyLop frm = new frmQuanLyLop();
            frm.Text = "Thêm lớp mới";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoaddgvQuanLyLop();
                MessageBox.Show("Thêm lớp học mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            if (dgvQuanLyLop.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một lớp để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow selectedRow = dgvQuanLyLop.SelectedRows[0];
            string tenLop = selectedRow.Cells["Lop"].Value.ToString();
            string tenGVChuNhiemCu = selectedRow.Cells["GVChuNhiem"].Value?.ToString() ?? "Chưa phân công";

            frmQuanLyLop frm = new frmQuanLyLop(tenLop, tenGVChuNhiemCu);
            frm.Text = "Sửa thông tin lớp";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoaddgvQuanLyLop();
                MessageBox.Show("Cập nhật thông tin lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoiLop_Click(object sender, EventArgs e)
        {
            try
            {
                LoaddgvQuanLyLop();
                MessageBox.Show("Dữ liệu đã được làm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi làm mới dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvQuanLyLop.ClearSelection();
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvQuanLyLop.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một lớp để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataGridViewRow selectedRow = dgvQuanLyLop.SelectedRows[0];
                string tenLop = selectedRow.Cells["Lop"].Value.ToString();
                string tenGVChuNhiem = selectedRow.Cells["GVChuNhiem"].Value?.ToString() ?? "Chưa phân công";
                int siSo = Convert.ToInt32(selectedRow.Cells["SiSo"].Value);

                string message = $"Bạn có chắc chắn muốn xóa lớp {tenLop} do giáo viên {tenGVChuNhiem} chủ nhiệm?\n" +
                                 $"Lưu ý: Thao tác này sẽ xóa toàn bộ {siSo} học sinh trong lớp và không thể khôi phục.";

                DialogResult result = MessageBox.Show(message, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return;

                string getMaLopQuery = $"SELECT MaLop, MaGVChuNhiem FROM LopHoc WHERE TenLop = N'{tenLop}'";
                DataTable dt = db.ExecuteQuery(getMaLopQuery);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin lớp học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int maLop = Convert.ToInt32(dt.Rows[0]["MaLop"]);
                int maGVChuNhiem = Convert.ToInt32(dt.Rows[0]["MaGVChuNhiem"]);

                string getMaNguoiDungQuery = $"SELECT MaNguoiDung FROM HocSinh WHERE MaLop = {maLop}";
                DataTable dtNguoiDung = db.ExecuteQuery(getMaNguoiDungQuery);

                using (var transaction = new TransactionScope())
                {
                    try
                    {
                        string deleteTKBQuery = $"DELETE FROM ThoiKhoaBieu WHERE MaLop = {maLop}";
                        db.ExecuteNonQuery(deleteTKBQuery);

                        string deleteKHGDQuery = $"DELETE FROM KeHoachGiangDay WHERE MaLop = {maLop}";
                        db.ExecuteNonQuery(deleteKHGDQuery);

                        string deleteTBQuery = $"DELETE FROM ThongBao WHERE MaLop = {maLop}";
                        db.ExecuteNonQuery(deleteTBQuery);

                        // Xóa thông tin bài kiểm tra của lớp
                        string deleteBaiKiemTraLopHocQuery = $"DELETE FROM BaiKiemTra_LopHoc WHERE MaLop = {maLop}";
                        db.ExecuteNonQuery(deleteBaiKiemTraLopHocQuery);

                        // Xử lý xóa các bài làm kiểm tra của học sinh trong lớp
                        string getBaiLamQuery = $"SELECT MaBaiLam FROM BaiLam WHERE MaHS IN (SELECT MaHS FROM HocSinh WHERE MaLop = {maLop})";
                        DataTable dtBaiLam = db.ExecuteQuery(getBaiLamQuery);
                        if (dtBaiLam != null && dtBaiLam.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtBaiLam.Rows)
                            {
                                int maBaiLam = Convert.ToInt32(row["MaBaiLam"]);

                                // Xóa các câu trả lời trắc nghiệm
                                string deleteTNQuery = $"DELETE FROM BaiLam_TracNghiem WHERE MaBaiLam = {maBaiLam}";
                                db.ExecuteNonQuery(deleteTNQuery);

                                // Xóa các câu trả lời tự luận
                                string deleteTLQuery = $"DELETE FROM BaiLam_TuLuan WHERE MaBaiLam = {maBaiLam}";
                                db.ExecuteNonQuery(deleteTLQuery);
                            }

                            // Sau khi xóa tất cả các câu trả lời, xóa bài làm
                            string deleteBaiLamQuery = $"DELETE FROM BaiLam WHERE MaHS IN (SELECT MaHS FROM HocSinh WHERE MaLop = {maLop})";
                            db.ExecuteNonQuery(deleteBaiLamQuery);
                        }

                        string deleteDiemQuery = $"DELETE FROM DiemSo WHERE MaHS IN (SELECT MaHS FROM HocSinh WHERE MaLop = {maLop})";
                        db.ExecuteNonQuery(deleteDiemQuery);

                        string deleteDonNghiQuery = $"DELETE FROM DonXinNghi WHERE MaHS IN (SELECT MaHS FROM HocSinh WHERE MaLop = {maLop})";
                        db.ExecuteNonQuery(deleteDonNghiQuery);

                        string deletePhuHuynhQuery = $"DELETE FROM PhuHuynh WHERE MaHS IN (SELECT MaHS FROM HocSinh WHERE MaLop = {maLop})";
                        db.ExecuteNonQuery(deletePhuHuynhQuery);

                        // Xóa thông báo người đọc liên quan đến người dùng học sinh
                        string deleteThongBaoNguoiDocQuery = $"DELETE FROM ThongBaoNguoiDoc WHERE MaNguoiDung IN (SELECT MaNguoiDung FROM HocSinh WHERE MaLop = {maLop})";
                        db.ExecuteNonQuery(deleteThongBaoNguoiDocQuery);

                        string deleteHocSinhQuery = $"DELETE FROM HocSinh WHERE MaLop = {maLop}";
                        db.ExecuteNonQuery(deleteHocSinhQuery);

                        foreach (DataRow row in dtNguoiDung.Rows)
                        {
                            int maNguoiDung = Convert.ToInt32(row["MaNguoiDung"]);
                            string deleteNguoiDungQuery = $"DELETE FROM NguoiDung WHERE MaNguoiDung = {maNguoiDung}";
                            db.ExecuteNonQuery(deleteNguoiDungQuery);
                        }

                        string checkOtherClassQuery = $"SELECT COUNT(*) FROM LopHoc WHERE MaGVChuNhiem = {maGVChuNhiem} AND MaLop <> {maLop}";
                        int otherClassCount = Convert.ToInt32(db.ExecuteScalar(checkOtherClassQuery));

                        if (otherClassCount == 0)
                        {
                            string updateGVQuery = $"UPDATE GiaoVien SET ChuNhiem = 0 WHERE MaGV = {maGVChuNhiem}";
                            db.ExecuteNonQuery(updateGVQuery);
                        }

                        string deleteLopQuery = $"DELETE FROM LopHoc WHERE MaLop = {maLop}";
                        bool deleteResult = db.ExecuteNonQuery(deleteLopQuery);

                        if (!deleteResult)
                        {
                            throw new Exception("Không thể xóa lớp học. Vui lòng thử lại!");
                        }

                        string getMaxMaNKQuery = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                        int maNK = Convert.ToInt32(db.ExecuteScalar(getMaxMaNKQuery));

                        string getMaNguoiDungPhongNoiVuQuery = "SELECT MaNguoiDung FROM NguoiDung WHERE MaVaiTro = 2";
                        int maNguoiDungPhongNoiVu = Convert.ToInt32(db.ExecuteScalar(getMaNguoiDungPhongNoiVuQuery));

                        string hanhDong = $"Xóa lớp {tenLop} của giáo viên {tenGVChuNhiem} chủ nhiệm ra khỏi hệ thống";

                        string insertNhatKyQuery = @"
                        INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian)
                        VALUES (@MaNK, @MaNguoiDung, @HanhDong, @ThoiGian)";

                        Dictionary<string, object> nhatKyParams = new Dictionary<string, object>
                        {
                            { "@MaNK", maNK },
                            { "@MaNguoiDung", maNguoiDungPhongNoiVu },
                            { "@HanhDong", hanhDong },
                            { "@ThoiGian", DateTime.Now }
                        };

                        db.ExecuteNonQuery(insertNhatKyQuery, nhatKyParams);
                        transaction.Complete();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi trong quá trình xóa: " + ex.Message);
                    }
                }
                LoaddgvQuanLyLop();
                MessageBox.Show($"Đã xóa lớp {tenLop} và tất cả dữ liệu liên quan thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa lớp học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemLop_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtTimKiemLop.Text.Trim();
                if (string.IsNullOrEmpty(searchTerm) || searchTerm == "Nhập lớp vào đây để tìm kiếm")
                {
                    LoaddgvQuanLyLop();
                    return;
                }
                string query = $@"
                SELECT 
                    lh.TenLop AS Lop,
                    COUNT(hs.MaHS) AS SiSo,
                    gv.HoTen AS GVChuNhiem
                FROM LopHoc lh
                LEFT JOIN HocSinh hs ON lh.MaLop = hs.MaLop
                LEFT JOIN GiaoVien gv ON lh.MaGVChuNhiem = gv.MaGV
                WHERE lh.TenLop LIKE N'%{searchTerm}%'
                GROUP BY lh.TenLop, gv.HoTen;
                ";
                DataTable dataTable = db.ExecuteQuery(query);
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy lớp nào có tên chứa '{searchTerm}'",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvQuanLyLop.DataSource = dataTable;
                dgvQuanLyLop.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
