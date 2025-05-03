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
    public partial class ucQuanLyLop_GVCN : UserControl
    {
        private readonly DatabaseHelper db = new DatabaseHelper();
        private int maGVChuNhiem;
        private int selectedMaDon = 0;
        public ucQuanLyLop_GVCN(int maGVChuNhiem)
        {
            InitializeComponent();
            this.maGVChuNhiem = maGVChuNhiem;
            LoadStudentList();
            // Mặc định hiển thị thời khóa biểu của tuần hiện tại
            ngayChonTKBDTP.Value = DateTime.Today;
            LoadThoiKhoaBieuLop();
            tabQuanLy.SelectedIndexChanged += tabQuanLy_SelectedIndexChanged;
        }
        private void LoadStudentList()
        {
            try
            {
                // Truy vấn danh sách học sinh trong lớp của GVCN
                string query = $@"
        SELECT 
            ROW_NUMBER() OVER (ORDER BY hs.HoTen) AS STT,
            hs.MaHS,
            hs.HoTen,
            hs.NgaySinh,
            hs.GioiTinh,
            hs.DiaChi,
            hs.SDTPhuHuynh
        FROM HocSinh hs
        INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
        WHERE lh.MaGVChuNhiem = {maGVChuNhiem}";

                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    dgvHocSinh.AutoGenerateColumns = false; // Tắt tự động sinh cột
                    dgvHocSinh.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có học sinh nào trong lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvHocSinh.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách học sinh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvHocSinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin học sinh từ hàng được chọn
                DataGridViewRow row = dgvHocSinh.Rows[e.RowIndex];
                txtSTT.Text = row.Cells["STT"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtNgaySinh.Text = Convert.ToDateTime(row.Cells["NgaySinh"].Value).ToString("dd/MM/yyyy");
                txtGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDTPhuHuynh.Text = row.Cells["SDTPhuHuynh"].Value.ToString();
            }
        }

        private void btnPheDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedMaDon == 0)
                {
                    MessageBox.Show("Vui lòng chọn một đơn nghỉ để phê duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật trạng thái đơn nghỉ
                string updateQuery = $@"
        UPDATE DonXinNghi
        SET TrangThai = N'Đã duyệt'
        WHERE MaDon = {selectedMaDon}";

                db.ExecuteNonQuery(updateQuery);

                // Lấy thông tin học sinh và ngày nghỉ
                string fetchQuery = $@"
        SELECT MaHS, NgayNghi
        FROM DonXinNghi
        WHERE MaDon = {selectedMaDon}";

                DataTable dt = db.ExecuteQuery(fetchQuery);
                if (dt.Rows.Count > 0)
                {
                    int maHS = Convert.ToInt32(dt.Rows[0]["MaHS"]);
                    DateTime ngayNghi = Convert.ToDateTime(dt.Rows[0]["NgayNghi"]);

                    // Cập nhật trạng thái "Vắng có phép" trong bảng DiemDanh
                    string insertOrUpdateQuery = $@"
            IF EXISTS (
                SELECT 1 FROM DiemDanh 
                WHERE MaHS = {maHS} AND Ngay = '{ngayNghi:yyyy-MM-dd}'
            )
            BEGIN
                UPDATE DiemDanh
                SET TrangThai = N'Vắng có phép'
                WHERE MaHS = {maHS} AND Ngay = '{ngayNghi:yyyy-MM-dd}'
            END
            ELSE
            BEGIN
                INSERT INTO DiemDanh (MaHS, MaLop, Ngay, TrangThai, GhiChu)
                VALUES ({maHS}, (SELECT MaLop FROM HocSinh WHERE MaHS = {maHS}), '{ngayNghi:yyyy-MM-dd}', N'Vắng có phép', N'Đơn nghỉ đã duyệt')
            END";

                    db.ExecuteNonQuery(insertOrUpdateQuery);
                }

                MessageBox.Show("Đơn nghỉ đã được phê duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAttendanceList(chonNgayDTP.Value); // Tải lại danh sách điểm danh
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi phê duyệt đơn nghỉ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedMaDon == 0)
                {
                    MessageBox.Show("Vui lòng chọn một đơn nghỉ để từ chối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật trạng thái đơn nghỉ
                string updateQuery = $@"
        UPDATE DonXinNghi
        SET TrangThai = N'Từ chối'
        WHERE MaDon = {selectedMaDon}";

                db.ExecuteNonQuery(updateQuery);

                MessageBox.Show("Đơn nghỉ đã bị từ chối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDonNghi(); // Tải lại danh sách đơn nghỉ
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi từ chối đơn nghỉ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDonNghi()
        {
            try
            {
                string query = $@"
            SELECT 
                ROW_NUMBER() OVER (ORDER BY dn.MaDon) AS STTDonNghi,
                hs.HoTen AS HoTenDonNghi,
                dn.LyDo,
                dn.NgayNghi,
                dn.TrangThai,
                dn.MaDon,
                hs.MaLop
            FROM DonXinNghi dn
            INNER JOIN HocSinh hs ON dn.MaHS = hs.MaHS
            INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
            WHERE dn.TrangThai = N'Chờ duyệt'
            AND lh.MaGVChuNhiem = {maGVChuNhiem}";

                DataTable dt = db.ExecuteQuery(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có đơn nghỉ nào cần duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDonNghi.DataSource = null;
                    return;
                }

                dgvDonNghi.AutoGenerateColumns = false;
                dgvDonNghi.DataSource = dt;

                dgvDonNghi.Columns["STTDonNghi"].DataPropertyName = "STTDonNghi";
                dgvDonNghi.Columns["HoTenDonNghi"].DataPropertyName = "HoTenDonNghi";
                dgvDonNghi.Columns["LyDo"].DataPropertyName = "LyDo";
                dgvDonNghi.Columns["NgayNghi"].DataPropertyName = "NgayNghi";
                dgvDonNghi.Columns["TrangThai"].DataPropertyName = "TrangThai";
                dgvDonNghi.Columns["MaDon"].DataPropertyName = "MaDon";
                dgvDonNghi.Columns["MaDon"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách đơn nghỉ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void dgvDonNghi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDonNghi.Rows[e.RowIndex];

                txtDonNghiSTT.Text = row.Cells["STTDonNghi"].Value.ToString();
                txtDonNghiHoTen.Text = row.Cells["HoTenDonNghi"].Value.ToString();
                txtDonNghiNgay.Text = Convert.ToDateTime(row.Cells["NgayNghi"].Value).ToString("dd/MM/yyyy");
                txtDonNghiLyDo.Text = row.Cells["LyDo"].Value.ToString();

                // Lưu mã đơn để xử lý duyệt hoặc từ chối
                selectedMaDon = Convert.ToInt32(row.Cells["MaDon"].Value);
            }
        }



        private void dgvDonNghi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadAttendanceList(DateTime selectedDate)
        {
            MessageBox.Show($"maGVChuNhiem: {maGVChuNhiem}");

            try
            {
                // Truy vấn danh sách học sinh và trạng thái điểm danh theo ngày
                string query = $@"
        SELECT 
            ROW_NUMBER() OVER (ORDER BY hs.HoTen) AS STTDiemDanh,
            hs.MaHS,
            hs.HoTen AS HoTenDiemDanh,
            ISNULL(dd.TrangThai, N'Có mặt') AS TrangThaiDiemDanh
        FROM HocSinh hs
        INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
        LEFT JOIN DiemDanh dd 
            ON hs.MaHS = dd.MaHS AND dd.Ngay = '{selectedDate:yyyy-MM-dd}'
        WHERE lh.MaGVChuNhiem = {maGVChuNhiem}";

                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    // Tự động thêm trạng thái "Có mặt" nếu chưa có trong bảng DiemDanh
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TrangThaiDiemDanh"].ToString() == "Có mặt")
                        {
                            int maHS = Convert.ToInt32(row["MaHS"]);
                            string insertQuery = $@"
                        IF NOT EXISTS (
                            SELECT 1 FROM DiemDanh 
                            WHERE MaHS = {maHS} AND Ngay = '{selectedDate:yyyy-MM-dd}'
                        )
                        BEGIN
                            INSERT INTO DiemDanh (MaHS, MaLop, Ngay, TrangThai)
                            VALUES ({maHS}, (SELECT MaLop FROM HocSinh WHERE MaHS = {maHS}), '{selectedDate:yyyy-MM-dd}', N'Có mặt')
                        END";
                            db.ExecuteNonQuery(insertQuery);
                        }
                    }

                    dgvDiemDanh.AutoGenerateColumns = false;
                    dgvDiemDanh.DataSource = dt;

                    // Tính tổng sĩ số và cập nhật label
                    UpdateAttendanceSummary(dt);
                }
                else
                {
                    MessageBox.Show("Không có học sinh nào trong lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvDiemDanh.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách điểm danh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateAttendanceSummary(DataTable dt)
        {
            int totalPresent = dt.AsEnumerable().Count(row => row["TrangThaiDiemDanh"].ToString() == "Có mặt");
            int totalAbsent = dt.AsEnumerable().Count(row => row["TrangThaiDiemDanh"].ToString() == "Vắng có phép");

            lblCoMat.Text = $"Có mặt: {totalPresent}";
            lblVang.Text = $"Vắng: {totalAbsent}";
        }


        private void tabQuanLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy tab hiện tại
            var selectedTab = tabQuanLy.SelectedTab;

            if (selectedTab == null) return;

            switch (selectedTab.Name)
            {
                case "tabDanhSachHocSinh": // Tên tab "Danh sách học sinh"
                    LoadStudentList();
                    break;
                case "tabDonNghi": // Tên tab "Đơn nghỉ"
                    LoadDonNghi();
                    break;
                case "tabDiemDanh": // Tên tab "Điểm danh"
                    chonNgayDTP.Value = DateTime.Today; // Đặt ngày mặc định là hôm nay
                    LoadAttendanceList(DateTime.Today); // Tải danh sách điểm danh của ngày hôm nay
                    break;
                case "tabThoiKhoaBieu": // Tên tab "Thời khóa biểu"
                    LoadThoiKhoaBieuLop();
                    break;
                default:
                    break;
            }
        }



        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = chonNgayDTP.Value; // Lấy ngày được chọn từ DateTimePicker
            LoadAttendanceList(selectedDate); // Gọi phương thức để tải danh sách điểm danh
        }

        private void lamMoiBtn_Click(object sender, EventArgs e)
        {
            LoadThoiKhoaBieuLop();
        }

        private void LoadThoiKhoaBieuLop()
        {
            try
            {
                // Lấy ngày được chọn từ DateTimePicker
                DateTime selectedDate = ngayChonTKBDTP.Value;

                // Tính ngày bắt đầu tuần (Thứ Hai) và ngày kết thúc tuần (Chủ Nhật)
                DateTime startOfWeek = selectedDate.AddDays(-(int)selectedDate.DayOfWeek + 1); // Thứ Hai
                DateTime endOfWeek = startOfWeek.AddDays(6); // Chủ Nhật

                // Truy vấn thời khóa biểu của lớp chủ nhiệm
                string query = $@"
        SELECT 
            ThoiKhoaBieu.Thu,
            ThoiKhoaBieu.Tiet,
            MonHoc.TenMon,
            COUNT(ThoiKhoaBieu.Tiet) AS SoTiet
        FROM ThoiKhoaBieu
        INNER JOIN LopHoc ON ThoiKhoaBieu.MaLop = LopHoc.MaLop
        INNER JOIN MonHoc ON ThoiKhoaBieu.MaMon = MonHoc.MaMon
        WHERE LopHoc.MaGVChuNhiem = {maGVChuNhiem}
          AND ThoiKhoaBieu.Ngay BETWEEN '{startOfWeek:yyyy-MM-dd}' AND '{endOfWeek:yyyy-MM-dd}'
        GROUP BY ThoiKhoaBieu.Thu, ThoiKhoaBieu.Tiet, MonHoc.TenMon
        ORDER BY ThoiKhoaBieu.Thu, ThoiKhoaBieu.Tiet";

                DataTable dt = db.ExecuteQuery(query);

                // Xóa các hàng cũ trong DataGridView
                dgvThoiKhoaBieu.Rows.Clear();

                // Tạo dictionary để lưu dữ liệu thời khóa biểu theo thứ
                var scheduleData = new Dictionary<int, List<string>>();
                for (int i = 2; i <= 8; i++) // Khởi tạo cho các ngày từ Thứ Hai (2) đến Chủ Nhật (8)
                {
                    scheduleData[i] = new List<string>();
                }

                // Điền dữ liệu vào dictionary
                foreach (DataRow row in dt.Rows)
                {
                    int thu = Convert.ToInt32(row["Thu"]); // Thứ trong tuần
                    string tiet = row["Tiet"].ToString(); // Tiết học
                    string tenMon = row["TenMon"].ToString(); // Tên môn học

                    // Định dạng thông tin thời khóa biểu
                    string scheduleEntry = $"Tiết: {tiet}\nMôn: {tenMon}";
                    scheduleData[thu].Add(scheduleEntry);
                }

                // Tìm số hàng tối đa cần thiết
                int maxRows = scheduleData.Values.Max(list => list.Count);

                // Thêm hàng vào DataGridView
                for (int i = 0; i < maxRows; i++)
                {
                    dgvThoiKhoaBieu.Rows.Add();
                }

                // Điền dữ liệu vào DataGridView
                for (int thu = 2; thu <= 8; thu++) // Từ Thứ Hai (2) đến Chủ Nhật (8)
                {
                    int columnIndex = thu - 2; // Map "2 = Thứ Hai" thành cột 0
                    for (int rowIndex = 0; rowIndex < scheduleData[thu].Count; rowIndex++)
                    {
                        dgvThoiKhoaBieu.Rows[rowIndex].Cells[columnIndex].Value = scheduleData[thu][rowIndex];
                    }
                }

                // Tính tổng số tiết trong tuần và số tiết mỗi môn
                var subjectSummary = dt.AsEnumerable()
                    .GroupBy(row => row["TenMon"].ToString())
                    .Select(group => new
                    {
                        TenMon = group.Key,
                        SoTiet = group.Sum(row => Convert.ToInt32(row["SoTiet"]))
                    });

                // Hiển thị tổng số tiết trong tuần và số tiết mỗi môn
                StringBuilder summaryText = new StringBuilder();
                int totalPeriods = 0;
                foreach (var subject in subjectSummary)
                {
                    summaryText.AppendLine($"{subject.SoTiet} Tiết {subject.TenMon}");
                    totalPeriods += subject.SoTiet;
                }
                thongKeSoTietTxt.Text = summaryText.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thời khóa biểu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ngayChonTKBDTP_ValueChanged(object sender, EventArgs e)
        {
            LoadThoiKhoaBieuLop();
        }
    }
}
