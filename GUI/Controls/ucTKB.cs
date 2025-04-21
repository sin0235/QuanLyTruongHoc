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

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucTKB : UserControl
    {
        private DatabaseHelper dbHelper;
        private int currentWeek = 0;
        private int maxWeek = 0;

        public ucTKB()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void ucTKB_Load(object sender, EventArgs e)
        {
            LoadSchoolYears();
            SetCurrentWeek();
        }

        // Load danh sách năm học vào combobox
        private void LoadSchoolYears()
        {
            try
            {
                string query = "SELECT DISTINCT NamHoc FROM NamHoc ORDER BY NamHoc DESC";
                DataTable dt = dbHelper.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cboNamHoc.DataSource = dt;
                    cboNamHoc.DisplayMember = "NamHoc";
                    cboNamHoc.ValueMember = "NamHoc";

                    // Sau khi chọn năm học, load học kỳ
                    LoadSemesters();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu năm học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách năm học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách học kỳ theo năm học
        private void LoadSemesters()
        {
            try
            {
                if (cboNamHoc.SelectedValue == null) return;

                string namHoc = cboNamHoc.SelectedValue.ToString();
                string query = $"SELECT DISTINCT HocKy FROM HocKy WHERE NamHoc = '{namHoc}' ORDER BY HocKy";
                DataTable dt = dbHelper.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cboHocKy.DataSource = dt;
                    cboHocKy.DisplayMember = "HocKy";
                    cboHocKy.ValueMember = "HocKy";

                    // Sau khi chọn học kỳ, load danh sách tuần
                    LoadWeeks();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu học kỳ cho năm học này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách tuần theo năm học và học kỳ
        private void LoadWeeks()
        {
            try
            {
                if (cboNamHoc.SelectedValue == null || cboHocKy.SelectedValue == null) return;

                string namHoc = cboNamHoc.SelectedValue.ToString();
                string hocKy = cboHocKy.SelectedValue.ToString();

                string query = $"SELECT MaTuan, TenTuan FROM Tuan WHERE NamHoc = '{namHoc}' AND HocKy = '{hocKy}' ORDER BY MaTuan";
                DataTable dt = dbHelper.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cboTuan.DataSource = dt;
                    cboTuan.DisplayMember = "TenTuan";
                    cboTuan.ValueMember = "MaTuan";

                    maxWeek = dt.Rows.Count;

                    // Load thời khóa biểu sau khi đã chọn tuần
                    LoadTimetable();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu tuần cho học kỳ này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tuần: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lấy MaHS từ thông tin đăng nhập (giả sử thông tin được lưu từ form đăng nhập)
        private int GetCurrentStudentId()
        {
            // Cần thay thế bằng cách lấy thông tin thực từ hệ thống của bạn
            try
            {
                // Giả sử mã học sinh được lưu trong một biến static của form Login
                int maHS = frmLogin.LoggedInStudentId;
                return maHS;
            }
            catch
            {
                // Dành cho mục đích thử nghiệm, có thể trả về ID cố định
                return 0;
            }
        }

        // Load thời khóa biểu dựa trên các thông tin đã chọn
        private void LoadTimetable()
        {
            try
            {
                if (cboTuan.SelectedValue == null) return;

                int maTuan = Convert.ToInt32(cboTuan.SelectedValue);
                int maHS = GetCurrentStudentId();

                string query = "";

                if (maHS > 0)
                {
                    // Nếu là học sinh đăng nhập, lấy thời khóa biểu theo lớp của học sinh
                    query = $@"
                        SELECT 
                            CONCAT('Thứ ', TKB.Thu) AS [Thứ],
                            TKB.Tiet AS [Tiết],
                            MH.TenMon AS [Môn học],
                            GV.HoTen AS [Giáo viên],
                            PH.TenPhong AS [Phòng học]
                        FROM ThoiKhoaBieu TKB
                        INNER JOIN MonHoc MH ON TKB.MaMon = MH.MaMon
                        INNER JOIN GiaoVien GV ON TKB.MaGV = GV.MaGV
                        INNER JOIN PhongHoc PH ON TKB.MaPhong = PH.MaPhong
                        INNER JOIN HocSinh HS ON HS.MaLop = TKB.MaLop
                        WHERE TKB.MaTuan = {maTuan} AND HS.MaHS = {maHS}
                        ORDER BY TKB.Thu, TKB.Tiet";
                }
                else
                {
                    // Nếu không có thông tin học sinh, hiển thị thông báo
                    MessageBox.Show("Không xác định được học sinh đang đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable dt = dbHelper.ExecuteQuery(query);

                if (dt != null)
                {
                    // Định dạng lại dữ liệu thành bảng thời khóa biểu theo ngày và tiết
                    FormatTimetable(dt);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu thời khóa biểu cho tuần này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thời khóa biểu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Định dạng lại dữ liệu thành bảng thời khóa biểu theo ngày và tiết
        private void FormatTimetable(DataTable rawData)
        {
            try
            {
                // Tạo bảng mới cho thời khóa biểu
                DataTable formattedTable = new DataTable();

                // Thêm cột Tiết/Thứ
                formattedTable.Columns.Add("Tiết/Thứ");

                // Thêm các cột cho các ngày trong tuần
                for (int thu = 2; thu <= 8; thu++)
                {
                    formattedTable.Columns.Add($"Thứ {thu}");
                }

                // Thêm các hàng cho các tiết học (giả sử có 5 tiết buổi sáng và 5 tiết buổi chiều)
                for (int tiet = 1; tiet <= 10; tiet++)
                {
                    DataRow newRow = formattedTable.NewRow();
                    newRow["Tiết/Thứ"] = $"Tiết {tiet}";

                    for (int thu = 2; thu <= 8; thu++)
                    {
                        string columnName = $"Thứ {thu}";
                        string cellValue = "";

                        // Tìm trong dữ liệu gốc các môn học tương ứng với thứ và tiết
                        var matchingRows = rawData.Select($"[Thứ] = 'Thứ {thu}' AND [Tiết] = '{tiet}'");

                        if (matchingRows.Length > 0)
                        {
                            // Nếu có môn học, hiển thị thông tin môn học
                            var row = matchingRows[0];
                            cellValue = $"{row["Môn học"]}\n{row["Giáo viên"]}\n{row["Phòng học"]}";
                        }

                        newRow[columnName] = cellValue;
                    }

                    formattedTable.Rows.Add(newRow);
                }

                // Hiển thị dữ liệu đã định dạng trong DataGridView
                dgvThoiKhoaBieu.DataSource = formattedTable;

                // Định dạng hiển thị cho DataGridView
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi định dạng thời khóa biểu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Định dạng hiển thị cho DataGridView
        private void FormatDataGridView()
        {
            dgvThoiKhoaBieu.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvThoiKhoaBieu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Định dạng các cột
            foreach (DataGridViewColumn col in dgvThoiKhoaBieu.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                if (col.Name == "Tiết/Thứ")
                {
                    col.Width = 80;
                }
                else
                {
                    col.Width = 150;
                }
            }

            // Thiết lập màu nền cho các ô
            foreach (DataGridViewRow row in dgvThoiKhoaBieu.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 0)
                    {
                        cell.Style.BackColor = Color.LightGray;
                    }
                    else if (!string.IsNullOrEmpty(cell.Value?.ToString()))
                    {
                        cell.Style.BackColor = Color.LightBlue;
                    }
                }
            }
        }

        // Đặt tuần hiện tại
        private void SetCurrentWeek()
        {
            try
            {
                // Lấy thông tin tuần hiện tại từ cơ sở dữ liệu
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

                string query = $@"
                    SELECT TOP 1 MaTuan 
                    FROM Tuan 
                    WHERE '{currentDate}' BETWEEN NgayBatDau AND NgayKetThuc
                    ORDER BY MaTuan";

                DataTable dt = dbHelper.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int maTuan = Convert.ToInt32(dt.Rows[0]["MaTuan"]);

                    // Thiết lập giá trị cho ComboBox tuần
                    if (cboTuan.Items.Count > 0)
                    {
                        for (int i = 0; i < cboTuan.Items.Count; i++)
                        {
                            DataRowView row = (DataRowView)cboTuan.Items[i];
                            if (Convert.ToInt32(row["MaTuan"]) == maTuan)
                            {
                                cboTuan.SelectedIndex = i;
                                currentWeek = i;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác định tuần hiện tại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Event Handlers

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSemesters();
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWeeks();
        }

        private void cboTuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTuan.SelectedIndex >= 0)
            {
                currentWeek = cboTuan.SelectedIndex;
                LoadTimetable();
            }
        }

        private void btnTuanTruoc_Click(object sender, EventArgs e)
        {
            if (currentWeek > 0)
            {
                currentWeek--;
                cboTuan.SelectedIndex = currentWeek;
            }
            else
            {
                MessageBox.Show("Đây là tuần đầu tiên của học kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTuanHienTai_Click(object sender, EventArgs e)
        {
            SetCurrentWeek();
        }

        private void btnTuanTiepTheo_Click(object sender, EventArgs e)
        {
            if (currentWeek < maxWeek - 1)
            {
                currentWeek++;
                cboTuan.SelectedIndex = currentWeek;
            }
            else
            {
                MessageBox.Show("Đây là tuần cuối cùng của học kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvThoiKhoaBieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện click vào ô trong DataGridView nếu cần
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                string cellValue = dgvThoiKhoaBieu[e.ColumnIndex, e.RowIndex].Value?.ToString();
                if (!string.IsNullOrEmpty(cellValue))
                {
                    // Hiển thị thông tin chi tiết về môn học khi click vào ô
                    MessageBox.Show(cellValue, "Thông tin chi tiết", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion
    }
}
