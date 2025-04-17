using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucThoiKhoaBieu : UserControl
    {
        public ucThoiKhoaBieu()
        {
            InitializeComponent();

            // Đặt giá trị mặc định cho ComboBox
            cboTimetableType.SelectedItem = "Lớp mình dạy";

            // Tải thời khóa biểu
            LoadTimetable();
        }


        private void LoadTimetable()
        {
            try
            {
                var dbHelper = new QuanLyTruongHoc.DAL.DatabaseHelper();

                // Lấy mã người dùng từ frmLogin
                int maNguoiDung = frmLogin.LoggedInTeacherId;
                if (maNguoiDung == 0)
                {
                    MessageBox.Show("Không thể xác định mã người dùng. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Truy vấn để lấy mã giáo viên (MaGV) từ MaNguoiDung
                string getMaGVQuery = $"SELECT MaGV FROM GiaoVien WHERE MaNguoiDung = {maNguoiDung}";
                DataTable result = dbHelper.ExecuteQuery(getMaGVQuery);

                if (result == null || result.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy mã giáo viên tương ứng với mã người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int maGV = Convert.ToInt32(result.Rows[0]["MaGV"]);

                // Mặc định chọn "Lớp mình dạy" nếu chưa chọn
                string selectedOption = cboTimetableType.SelectedItem?.ToString() ?? "Lớp mình dạy";

                string query = string.Empty;

                if (selectedOption == "Lớp mình dạy")
                {
                    query = $@"
            SELECT 
                LopHoc.TenLop AS [Lớp],
                MonHoc.TenMon AS [Môn học],
                GiaoVien.HoTen AS [Giáo viên],
                ThoiKhoaBieu.Thu AS [Thứ],
                ThoiKhoaBieu.Tiet AS [Tiết]
            FROM ThoiKhoaBieu
            INNER JOIN LopHoc ON ThoiKhoaBieu.MaLop = LopHoc.MaLop
            INNER JOIN MonHoc ON ThoiKhoaBieu.MaMon = MonHoc.MaMon
            INNER JOIN GiaoVien ON ThoiKhoaBieu.MaGV = GiaoVien.MaGV
            WHERE ThoiKhoaBieu.MaGV = {maGV}
            ORDER BY ThoiKhoaBieu.Thu, ThoiKhoaBieu.Tiet";

                    DataTable timetableData = dbHelper.ExecuteQuery(query);
                    if (timetableData == null || timetableData.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu thời khóa biểu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Hiển thị thời khóa biểu dạng bảng
                    DisplayTimetable(timetableData);
                }
                else if (selectedOption == "Lớp mình chủ nhiệm")
                {
                    query = $@"
            SELECT 
                LopHoc.TenLop AS [Lớp],
                MonHoc.TenMon AS [Môn học],
                GiaoVien.HoTen AS [Giáo viên],
                ThoiKhoaBieu.Thu AS [Thứ],
                ThoiKhoaBieu.Tiet AS [Tiết]
            FROM ThoiKhoaBieu
            INNER JOIN LopHoc ON ThoiKhoaBieu.MaLop = LopHoc.MaLop
            INNER JOIN MonHoc ON ThoiKhoaBieu.MaMon = MonHoc.MaMon
            INNER JOIN GiaoVien ON ThoiKhoaBieu.MaGV = GiaoVien.MaGV
            WHERE LopHoc.MaGVChuNhiem = {maGV}
            ORDER BY ThoiKhoaBieu.Thu, ThoiKhoaBieu.Tiet";

                    DataTable timetableData = dbHelper.ExecuteQuery(query);
                    if (timetableData == null || timetableData.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu thời khóa biểu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Hiển thị dữ liệu trong DataGridView
                    guna2DgvTKB.DataSource = timetableData;
                    guna2DgvTKB.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thời khóa biểu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void cboTimetableType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTimetable();
        }


        private void DisplayTimetable(DataTable timetableData)
        {
            // Tìm hoặc tạo Panel chứa ComboBox
            Panel comboBoxPanel = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "comboBoxPanel");
            if (comboBoxPanel == null)
            {
                comboBoxPanel = new Panel
                {
                    Name = "comboBoxPanel",
                    Dock = DockStyle.Top,
                    Height = 50
                };
                comboBoxPanel.Controls.Add(cboTimetableType);
                this.Controls.Add(comboBoxPanel);
            }

            // Tạo TableLayoutPanel
            TableLayoutPanel table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3, // Sáng, Chiều, và cột "Thứ"
                RowCount = 8,   // Thứ 2 -> Chủ Nhật + Tiêu đề
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            // Đặt kích thước cột
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20)); // Cột "Thứ"
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40)); // Cột "Sáng"
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40)); // Cột "Chiều"

            // Đặt kích thước hàng
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50)); // Tiêu đề
            for (int i = 0; i < 7; i++) // Các ngày trong tuần
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / 7f));
            }

            // Thêm tiêu đề cột
            table.Controls.Add(new Label
            {
                Text = "Thứ",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightGray,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12, FontStyle.Bold)
            }, 0, 0);
            table.Controls.Add(new Label
            {
                Text = "Sáng",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightGray,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12, FontStyle.Bold)
            }, 1, 0);
            table.Controls.Add(new Label
            {
                Text = "Chiều",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightGray,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 12, FontStyle.Bold)
            }, 2, 0);

            // Thêm các hàng (Thứ 2 -> Chủ Nhật)
            string[] days = { "2", "3", "4", "5", "6", "7", "8" }; // Tương ứng Thứ Hai -> Chủ Nhật
            string[] dayNames = { "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy", "Chủ Nhật" };
            for (int i = 0; i < dayNames.Length; i++)
            {
                table.Controls.Add(new Label
                {
                    Text = dayNames[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.LightYellow,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 12, FontStyle.Regular)
                }, 0, i + 1);
            }

            // Điền dữ liệu vào các ô
            foreach (DataRow row in timetableData.Rows)
            {
                string day = row["Thứ"].ToString(); // Giá trị "Thứ" là số (2, 3, ...)
                string period = row["Tiết"].ToString();
                string subject = row["Môn học"].ToString();
                string teacher = row["Giáo viên"].ToString();
                string className = row["Lớp"].ToString();

                // Xác định cột (Sáng, Chiều) dựa trên tiết
                int column = GetColumnFromPeriod(period);

                // Xác định hàng dựa trên "Thứ"
                int rowIndex = Array.IndexOf(days, day) + 1;

                // Tạo nội dung hiển thị
                Label label = new Label
                {
                    Text = $"Môn: {subject}\nLớp: {className}\nGV: {teacher}\nTiết: {period}",
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.LightBlue,
                    Dock = DockStyle.Fill,
                    Padding = new Padding(5),
                    Font = new Font("Arial", 11, FontStyle.Regular)
                };

                table.Controls.Add(label, column, rowIndex);
            }

            // Xóa tất cả controls
            this.Controls.Clear();

            // Đặt lại Dock cho comboBoxPanel nếu cần
            comboBoxPanel.Dock = DockStyle.Top;

            // Thêm comboBoxPanel trước
            this.Controls.Add(comboBoxPanel);

            // Thêm bảng thời khóa biểu sau
            this.Controls.Add(table);

            // Đảm bảo table không che mất comboBoxPanel
            table.BringToFront();

        }


        private int GetColumnFromPeriod(string period)
        {
            // Giả sử tiết 1-4 là Sáng, 5-8 là Chiều
            int firstPeriod = int.Parse(period.Split('-')[0]);
            if (firstPeriod <= 4) return 1; // Sáng
            return 2; // Chiều
        }
    }
}
