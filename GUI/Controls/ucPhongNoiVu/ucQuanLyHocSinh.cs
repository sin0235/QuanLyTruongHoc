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
                    CONVERT(NVARCHAR, hs.NgaySinh, 103) AS NgaySinh, 
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
                    CONVERT(NVARCHAR, hs.NgaySinh, 103) AS NgaySinh, 
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

            if (frm.ShowDialog() == DialogResult.OK) // Chỉ thực hiện nếu thêm học sinh thành công
            {
                try
                {
                    // Lấy MaHS lớn nhất vừa được thêm vào
                    string queryLatestStudent = @"
                    SELECT TOP 1 
                        hs.MaHS, 
                        hs.HoTen, 
                        lh.MaLop,
                        lh.TenLop 
                    FROM HocSinh hs
                    INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    ORDER BY hs.MaHS DESC";

                    DataTable latestStudent = db.ExecuteQuery(queryLatestStudent);

                    if (latestStudent != null && latestStudent.Rows.Count > 0)
                    {
                        int maHS = Convert.ToInt32(latestStudent.Rows[0]["MaHS"]);
                        int maLop = Convert.ToInt32(latestStudent.Rows[0]["MaLop"]);
                        string hoTenHocSinh = latestStudent.Rows[0]["HoTen"].ToString();
                        string tenLop = latestStudent.Rows[0]["TenLop"].ToString();

                        // Truy vấn để lấy MaNguoiDung của phòng nội vụ
                        string queryPhongNoiVu = "SELECT MaNguoiDung FROM NguoiDung WHERE MaVaiTro = 4";
                        int maNguoiDungPhongNoiVu = Convert.ToInt32(db.ExecuteScalar(queryPhongNoiVu));

                        // Truy vấn để lấy MaNK lớn nhất trong bảng NhatKyHeThong
                        string queryMaxMaNK = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                        int maNK = Convert.ToInt32(db.ExecuteScalar(queryMaxMaNK));

                        // Nội dung hành động
                        string hanhDong = $"Thêm học sinh {hoTenHocSinh} vào lớp {tenLop}";

                        // Thêm vào bảng NhatKyHeThong
                        string insertNhatKy = $@"
                        INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian)
                        VALUES ({maNK}, {maNguoiDungPhongNoiVu}, N'{hanhDong}', GETDATE())";

                        db.ExecuteNonQuery(insertNhatKy);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi ghi nhật ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Tải lại dữ liệu sau khi thêm
                LoadHocSinhData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHocSinh.SelectedRows.Count > 0)
            {
                // Lấy thông tin từ dòng được chọn
                DataGridViewRow selectedRow = dgvHocSinh.SelectedRows[0];
                int maHS = Convert.ToInt32(selectedRow.Cells["MaHS"].Value);
                string hoTen = selectedRow.Cells["HoTen"].Value.ToString();

                // Fetch the correct date from database instead of trying to convert from display format
                string queryGetDate = $"SELECT NgaySinh FROM HocSinh WHERE MaHS = {maHS}";
                DateTime ngaySinh;

                try
                {
                    object dateResult = db.ExecuteScalar(queryGetDate);
                    ngaySinh = Convert.ToDateTime(dateResult);
                }
                catch
                {
                    MessageBox.Show("Không thể lấy ngày sinh chính xác từ cơ sở dữ liệu. Sử dụng ngày mặc định.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ngaySinh = DateTime.Now;
                }

                string gioiTinh = selectedRow.Cells["GioiTinh"].Value.ToString();
                string diaChi = selectedRow.Cells["DiaChi"].Value?.ToString() ?? "";
                string sdtPhuHuynh = selectedRow.Cells["SDTPhuHuynh"].Value?.ToString() ?? "";
                string tenLopCu = selectedRow.Cells["MaLop"].Value.ToString();

                // Hiển thị form sửa thông tin
                frmQuanLyHocSinh frm = new frmQuanLyHocSinh(maHS, hoTen, ngaySinh, gioiTinh, diaChi, sdtPhuHuynh, tenLopCu);
                frm.StartPosition = FormStartPosition.CenterScreen;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Lấy thông tin học sinh sau khi sửa
                        string queryUpdatedStudent = $@"
                        SELECT 
                            hs.HoTen, 
                            lh.TenLop 
                        FROM HocSinh hs
                        INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                        WHERE hs.MaHS = {maHS}";

                        DataTable updatedStudent = db.ExecuteQuery(queryUpdatedStudent);

                        if (updatedStudent != null && updatedStudent.Rows.Count > 0)
                        {
                            string hoTenHocSinh = updatedStudent.Rows[0]["HoTen"].ToString();
                            string tenLopMoi = updatedStudent.Rows[0]["TenLop"].ToString();

                            // Truy vấn để lấy MaNguoiDung của phòng nội vụ
                            string queryPhongNoiVu = "SELECT MaNguoiDung FROM NguoiDung WHERE MaVaiTro = 4";
                            int maNguoiDungPhongNoiVu = Convert.ToInt32(db.ExecuteScalar(queryPhongNoiVu));

                            // Truy vấn để lấy MaNK lớn nhất trong bảng NhatKyHeThong
                            string queryMaxMaNK = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                            int maNK = Convert.ToInt32(db.ExecuteScalar(queryMaxMaNK));

                            // Nội dung hành động
                            string hanhDong = $"Sửa thông tin học sinh {hoTenHocSinh} của lớp {tenLopMoi}";

                            // Thêm vào bảng NhatKyHeThong
                            string insertNhatKy = $@"
                            INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian)
                            VALUES ({maNK}, {maNguoiDungPhongNoiVu}, N'{hanhDong}', GETDATE())";

                            db.ExecuteNonQuery(insertNhatKy);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi ghi nhật ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

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
                string tenLop = selectedRow.Cells["MaLop"].Value.ToString(); // Lấy tên lớp để ghi nhật ký

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
                        try
                        {
                            // Ghi nhật ký xóa học sinh
                            // Truy vấn để lấy MaNguoiDung của phòng nội vụ
                            string queryPhongNoiVu = "SELECT MaNguoiDung FROM NguoiDung WHERE MaVaiTro = 4";
                            int maNguoiDungPhongNoiVu = Convert.ToInt32(db.ExecuteScalar(queryPhongNoiVu));

                            // Truy vấn để lấy MaNK lớn nhất trong bảng NhatKyHeThong
                            string queryMaxMaNK = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                            int maNK = Convert.ToInt32(db.ExecuteScalar(queryMaxMaNK));

                            // Nội dung hành động
                            string hanhDong = $"Xóa học sinh {hoTen} ra khỏi lớp {tenLop}";

                            // Thêm vào bảng NhatKyHeThong
                            string insertNhatKy = $@"
                            INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian)
                            VALUES ({maNK}, {maNguoiDungPhongNoiVu}, N'{hanhDong}', GETDATE())";

                            db.ExecuteNonQuery(insertNhatKy);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã xóa học sinh thành công nhưng xảy ra lỗi khi ghi nhật ký: " + ex.Message,
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

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
                    CONVERT(NVARCHAR, hs.NgaySinh, 103) AS NgaySinh, 
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
