using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.GUI.Forms;

namespace QuanLyTruongHoc.GUI.Controls.ucPhongNoiVu
{
    public partial class ucQuanLyThoiKhoaBieu : UserControl
    {
        DatabaseHelper db;

        public ucQuanLyThoiKhoaBieu()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        private void LoadDanhSachLop()
        {
            string query = "SELECT MaLop, TenLop FROM LopHoc";
            DataTable dt = db.ExecuteQuery(query);
            cmbChonLop.DataSource = dt;
            cmbChonLop.DisplayMember = "TenLop";
            cmbChonLop.ValueMember = "MaLop";
        }

        private void ucQuanLyThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            LoadDanhSachLop();

            // Không chọn lớp nào khi mới tải
            cmbChonLop.SelectedIndex = -1;

            // Đặt giá trị mặc định cho dtpNgay là ngày hôm nay
            dtpNgay.Value = DateTime.Today;

            // Tùy chỉnh DataGridView
            dgvThoiKhoaBieu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dgvThoiKhoaBieu.ClearSelection();
        }

        private void CmbChonLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThoiKhoaBieu();
        }

        private void DtpNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadThoiKhoaBieu();
        }

        private void LoadThoiKhoaBieu()
        {
            if (cmbChonLop.SelectedValue == null)
            {
                // Xóa dữ liệu trong DataGridView nếu không có lớp nào được chọn
                dgvThoiKhoaBieu.Rows.Clear();
                return;
            }

            int maLop;
            if (cmbChonLop.SelectedValue is DataRowView rowView)
            {
                maLop = Convert.ToInt32(rowView["MaLop"]);
            }
            else
            {
                maLop = Convert.ToInt32(cmbChonLop.SelectedValue);
            }

            DateTime selectedDate = dtpNgay.Value;

            // Tính ngày bắt đầu tuần (thứ 2) và ngày kết thúc tuần (chủ nhật)
            DateTime startOfWeek = selectedDate.AddDays(-(int)selectedDate.DayOfWeek + 1);
            if (selectedDate.DayOfWeek == DayOfWeek.Sunday)
                startOfWeek = selectedDate.AddDays(-6); // Đảm bảo chủ nhật thuộc về tuần hiện tại
            DateTime endOfWeek = startOfWeek.AddDays(6);

            // Cập nhật tiêu đề cột với ngày tương ứng
            for (int i = 0; i < dgvThoiKhoaBieu.Columns.Count; i++)
            {
                DateTime currentDay = startOfWeek.AddDays(i);
                string thu = i == 6 ? "Chủ nhật" : $"Thứ {i + 2}";
                dgvThoiKhoaBieu.Columns[i].HeaderText = $"{thu}\r\n{currentDay:dd/MM/yyyy}";
                dgvThoiKhoaBieu.Columns[i].Tag = currentDay;  // Lưu ngày vào Tag để tham chiếu sau này
            }

            // Truy vấn lấy dữ liệu thời khóa biểu
            string query = @"
            SELECT Ngay, Thu, Tiet, TenMon, HoTen AS TenGiaoVien
            FROM ThoiKhoaBieu
            INNER JOIN MonHoc ON ThoiKhoaBieu.MaMon = MonHoc.MaMon
            INNER JOIN GiaoVien ON ThoiKhoaBieu.MaGV = GiaoVien.MaGV
            WHERE ThoiKhoaBieu.MaLop = @MaLop AND Ngay BETWEEN @StartOfWeek AND @EndOfWeek
            ORDER BY Ngay, Thu, Tiet";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaLop", maLop },
                { "@StartOfWeek", startOfWeek },
                { "@EndOfWeek", endOfWeek }
            };

            DataTable dt = db.ExecuteQuery(query, parameters);

            // Xóa dữ liệu cũ trong DataGridView
            dgvThoiKhoaBieu.Rows.Clear();

            // Tổ chức dữ liệu theo ngày và tiết học
            Dictionary<DateTime, Dictionary<string, string>> organizedData = new Dictionary<DateTime, Dictionary<string, string>>();

            // Khởi tạo dictionary cho mỗi ngày trong tuần
            for (int i = 0; i < 7; i++)
            {
                DateTime day = startOfWeek.AddDays(i);
                organizedData[day.Date] = new Dictionary<string, string>();
            }

            // Gom nhóm dữ liệu theo ngày và tiết
            foreach (DataRow row in dt.Rows)
            {
                DateTime ngay = Convert.ToDateTime(row["Ngay"]).Date;
                string tiet = row["Tiet"].ToString();
                string monGV = $"Môn: {row["TenMon"]}\nGV: {row["TenGiaoVien"]}";

                if (organizedData.ContainsKey(ngay))
                {
                    organizedData[ngay][tiet] = monGV;
                }
            }

            // Xác định số dòng cần thiết
            int maxRowsNeeded = 0;
            foreach (var dayData in organizedData.Values)
            {
                maxRowsNeeded = Math.Max(maxRowsNeeded, dayData.Count);
            }

            // Thêm đủ số dòng cần thiết
            while (dgvThoiKhoaBieu.Rows.Count < maxRowsNeeded)
            {
                dgvThoiKhoaBieu.Rows.Add();
            }

            // Điền dữ liệu vào DataGridView
            for (int columnIndex = 0; columnIndex < dgvThoiKhoaBieu.Columns.Count; columnIndex++)
            {
                DateTime currentDay = (DateTime)dgvThoiKhoaBieu.Columns[columnIndex].Tag;

                if (organizedData.ContainsKey(currentDay.Date))
                {
                    var dayData = organizedData[currentDay.Date];
                    int rowIndex = 0;

                    foreach (var tietPair in dayData)
                    {
                        string tiet = tietPair.Key;
                        string monGV = tietPair.Value;

                        if (rowIndex < dgvThoiKhoaBieu.Rows.Count)
                        {
                            dgvThoiKhoaBieu.Rows[rowIndex].Cells[columnIndex].Value = $"Tiết: {tiet}\n{monGV}";
                            rowIndex++;
                        }
                    }
                }
            }

            // Xóa các dòng trống dư thừa
            while (dgvThoiKhoaBieu.Rows.Count > maxRowsNeeded && maxRowsNeeded > 0)
            {
                dgvThoiKhoaBieu.Rows.RemoveAt(dgvThoiKhoaBieu.Rows.Count - 1);
            }

            // Nếu không có dữ liệu, thêm một dòng trống để DataGridView không trống hoàn toàn
            if (dgvThoiKhoaBieu.Rows.Count == 0)
            {
                dgvThoiKhoaBieu.Rows.Add();
            }

            // Loại bỏ các ô trống cuối cùng
            dgvThoiKhoaBieu.AllowUserToAddRows = false;
            dgvThoiKhoaBieu.ClearSelection();
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cmbChonLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp trước khi thêm lịch học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maLop = Convert.ToInt32(cmbChonLop.SelectedValue);
            string tenLop = cmbChonLop.Text;

            // Xác định ngày từ ô được chọn (nếu có)
            DateTime selectedDate = dtpNgay.Value;

            // Nếu có ô được chọn trong DataGridView
            if (dgvThoiKhoaBieu.SelectedCells.Count > 0)
            {
                int columnIndex = dgvThoiKhoaBieu.SelectedCells[0].ColumnIndex;

                // Lấy ngày từ tiêu đề cột
                string headerText = dgvThoiKhoaBieu.Columns[columnIndex].HeaderText;
                string[] headerParts = headerText.Split(new[] { "\r\n" }, StringSplitOptions.None);

                if (headerParts.Length > 1)
                {
                    if (DateTime.TryParseExact(headerParts[1], "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out DateTime date))
                    {
                        selectedDate = date;
                    }
                }

                // Hoặc lấy từ Tag của cột nếu đã thiết lập (nếu bạn đã lưu ngày vào Tag)
                if (dgvThoiKhoaBieu.Columns[columnIndex].Tag != null &&
                    dgvThoiKhoaBieu.Columns[columnIndex].Tag is DateTime)
                {
                    selectedDate = (DateTime)dgvThoiKhoaBieu.Columns[columnIndex].Tag;
                }
            }

            // Hiển thị form thêm lịch học với ngày được chọn
            frmQuanLyThoiKhoaBieu frm = new frmQuanLyThoiKhoaBieu(maLop, tenLop, selectedDate);
            frm.Text = "Thêm lịch học";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Truy vấn để lấy thông tin thời khóa biểu vừa thêm
                    string queryLatestSchedule = @"
                    SELECT TOP 1 
                        Thu, 
                        Tiet, 
                        MonHoc.TenMon,
                        GiaoVien.HoTen AS TenGiaoVien,
                        LopHoc.TenLop
                    FROM ThoiKhoaBieu
                    INNER JOIN MonHoc ON ThoiKhoaBieu.MaMon = MonHoc.MaMon
                    INNER JOIN GiaoVien ON ThoiKhoaBieu.MaGV = GiaoVien.MaGV
                    INNER JOIN LopHoc ON ThoiKhoaBieu.MaLop = LopHoc.MaLop
                    WHERE ThoiKhoaBieu.MaLop = @MaLop
                    ORDER BY MaTKB DESC";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaLop", maLop }
                    };

                    DataTable latestSchedule = db.ExecuteQuery(queryLatestSchedule, parameters);

                    if (latestSchedule != null && latestSchedule.Rows.Count > 0)
                    {
                        string thu = latestSchedule.Rows[0]["Thu"].ToString();
                        string tiet = latestSchedule.Rows[0]["Tiet"].ToString();
                        string tenMon = latestSchedule.Rows[0]["TenMon"].ToString();
                        string tenGiaoVien = latestSchedule.Rows[0]["TenGiaoVien"].ToString();
                        string tenLopMoi = latestSchedule.Rows[0]["TenLop"].ToString();

                        // Truy vấn để lấy MaNguoiDung của phòng nội vụ
                        string queryPhongNoiVu = "SELECT MaNguoiDung FROM NguoiDung WHERE MaVaiTro = 4";
                        int maNguoiDungPhongNoiVu = Convert.ToInt32(db.ExecuteScalar(queryPhongNoiVu));

                        // Truy vấn để lấy MaNK lớn nhất trong bảng NhatKyHeThong
                        string queryMaxMaNK = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                        int maNK = Convert.ToInt32(db.ExecuteScalar(queryMaxMaNK));

                        // Nội dung hành động
                        string hanhDong = $"Thêm thời khóa biểu vào thứ {thu} với môn {tenMon} của giáo viên {tenGiaoVien} từ tiết {tiet} lớp {tenLopMoi}";

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

                // Reload thời khóa biểu sau khi thêm
                LoadThoiKhoaBieu();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cmbChonLop.SelectedIndex = -1;
            dtpNgay.Value = DateTime.Today;
            dgvThoiKhoaBieu.Rows.Clear();
            MessageBox.Show("Đã làm mới cửa sổ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int GetMaTKBFromDatabase(int maLop, DateTime ngay, string tiet)
        {
            try
            {
                string query = @"
                SELECT MaTKB 
                FROM ThoiKhoaBieu 
                WHERE MaLop = @MaLop 
                  AND CONVERT(DATE, Ngay) = CONVERT(DATE, @Ngay) 
                  AND Tiet = @Tiet";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaLop", maLop },
                    { "@Ngay", ngay },
                    { "@Tiet", tiet }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["MaTKB"]);
                }

                return -1; // Không tìm thấy
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn MaTKB: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cmbChonLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp trước khi sửa thời khóa biểu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvThoiKhoaBieu.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một ô trong thời khóa biểu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ ô được chọn
            DataGridViewCell selectedCell = dgvThoiKhoaBieu.SelectedCells[0];
            int columnIndex = selectedCell.ColumnIndex;
            int rowIndex = selectedCell.RowIndex;

            if (selectedCell.Value == null || string.IsNullOrWhiteSpace(selectedCell.Value.ToString()))
            {
                MessageBox.Show("Ô được chọn không có dữ liệu để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin ngày từ tiêu đề cột - SỬA LỖI Ở ĐÂY
            DateTime selectedDate;

            // Lấy ngày từ Tag của cột (cách này an toàn hơn)
            if (dgvThoiKhoaBieu.Columns[columnIndex].Tag != null &&
                dgvThoiKhoaBieu.Columns[columnIndex].Tag is DateTime)
            {
                selectedDate = (DateTime)dgvThoiKhoaBieu.Columns[columnIndex].Tag;
            }
            else
            {
                // Nếu không có Tag, sử dụng ngày hiện tại
                selectedDate = DateTime.Today;
                MessageBox.Show("Không thể xác định ngày từ cột. Sử dụng ngày hiện tại thay thế.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                // Phân tích dữ liệu từ ô được chọn
                string[] cellData = selectedCell.Value.ToString().Split('\n');
                string tiet = cellData[0].Replace("Tiết: ", "").Trim();
                string mon = cellData.Length > 1 ? cellData[1].Replace("Môn: ", "").Trim() : "";
                string giaoVien = cellData.Length > 2 ? cellData[2].Replace("GV: ", "").Trim() : "";

                // Lấy MaTKB từ cơ sở dữ liệu
                int maLop = Convert.ToInt32(cmbChonLop.SelectedValue);
                int maTKB = GetMaTKBFromDatabase(maLop, selectedDate, tiet);

                if (maTKB <= 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu thời khóa biểu để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hiển thị form sửa thời khóa biểu
                frmQuanLyThoiKhoaBieu frm = new frmQuanLyThoiKhoaBieu(Convert.ToInt32(cmbChonLop.SelectedValue), cmbChonLop.Text, selectedDate)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    Text = "Sửa thời khóa biểu"
                };

                // Cố gắng truyền thông tin vào form một cách an toàn
                try
                {
                    if (frm.Controls["cmbMonHoc"] != null)
                        frm.Controls["cmbMonHoc"].Tag = mon;

                    if (frm.Controls["cmbGiaoVien"] != null)
                        frm.Controls["cmbGiaoVien"].Tag = giaoVien;

                    if (frm.Controls["txtTietHoc"] != null)
                        frm.Controls["txtTietHoc"].Text = tiet;

                    // Truyền MaTKB để cập nhật thay vì tạo mới
                    frm.Tag = maTKB;

                    // Đổi nút "Xác nhận" thành "Cập nhật"
                    if (frm.Controls["btnXacNhan"] != null)
                        frm.Controls["btnXacNhan"].Text = "Cập nhật";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi truyền thông tin vào form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Reload thời khóa biểu sau khi cập nhật
                    LoadThoiKhoaBieu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvThoiKhoaBieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có lớp nào được chọn không
                if (cmbChonLop.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn lớp trước khi xóa thời khóa biểu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem có ô nào được chọn không
                if (dgvThoiKhoaBieu.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một buổi học trong thời khóa biểu để xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin từ ô được chọn
                DataGridViewCell selectedCell = dgvThoiKhoaBieu.SelectedCells[0];
                int columnIndex = selectedCell.ColumnIndex;

                // Kiểm tra xem ô có dữ liệu không
                if (selectedCell.Value == null || string.IsNullOrWhiteSpace(selectedCell.Value.ToString()))
                {
                    MessageBox.Show("Ô được chọn không có dữ liệu để xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin ngày từ tiêu đề cột - SỬA LỖI Ở ĐÂY
                DateTime selectedDate;

                // Lấy ngày từ Tag của cột (cách ưu tiên)
                if (dgvThoiKhoaBieu.Columns[columnIndex].Tag != null &&
                    dgvThoiKhoaBieu.Columns[columnIndex].Tag is DateTime)
                {
                    selectedDate = (DateTime)dgvThoiKhoaBieu.Columns[columnIndex].Tag;
                }
                else
                {
                    // Sử dụng ngày hiện tại nếu không thể xác định
                    selectedDate = DateTime.Today;
                    MessageBox.Show("Không thể xác định ngày. Sử dụng ngày hiện tại thay thế.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Phân tích dữ liệu từ ô được chọn
                string[] cellData = selectedCell.Value.ToString().Split('\n');
                string tiet = cellData[0].Replace("Tiết: ", "").Trim();
                string mon = cellData.Length > 1 ? cellData[1].Replace("Môn: ", "").Trim() : "";
                string giaoVien = cellData.Length > 2 ? cellData[2].Replace("GV: ", "").Trim() : "";

                // Lấy MaTKB từ cơ sở dữ liệu
                int maLop = Convert.ToInt32(cmbChonLop.SelectedValue);
                int maTKB = GetMaTKBFromDatabase(maLop, selectedDate, tiet);

                if (maTKB <= 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu thời khóa biểu để xóa!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa buổi học này?\nMôn: {mon}\nGiáo viên: {giaoVien}\nTiết: {tiet}\nNgày: {selectedDate:dd/MM/yyyy}",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // Nếu người dùng xác nhận xóa
                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa dữ liệu
                    bool deleteSuccess = DeleteThoiKhoaBieu(maTKB);

                    if (deleteSuccess)
                    {
                        MessageBox.Show("Đã xóa buổi học thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reload thời khóa biểu sau khi xóa
                        LoadThoiKhoaBieu();
                    }
                    else
                    {
                        MessageBox.Show("Xóa buổi học thất bại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Nếu người dùng chọn No - không làm gì
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý xóa thời khóa biểu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm phương thức để xóa thời khóa biểu từ cơ sở dữ liệu
        private bool DeleteThoiKhoaBieu(int maTKB)
        {
            try
            {
                string query = "DELETE FROM ThoiKhoaBieu WHERE MaTKB = @MaTKB";
                Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@MaTKB", maTKB }
        };
                return db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa thời khóa biểu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
