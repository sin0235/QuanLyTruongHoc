// GUI/Controls/ucHocSinh/ucTKB.cs
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.DTO;
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
        private TKBDAL tkbDAL;
        private int currentWeek = 0;
        private int maxWeek = 0;
        private int id;
        private int maHS;
        private List<TuanHocDTO> weeks;
        private int maLop;

        private void ucTKB_Load(object sender, EventArgs e)
        {
            // Lấy thông tin lớp của học sinh
            DataRow classInfo = tkbDAL.GetClassInfo(maHS);
            if (classInfo != null)
            {
                maLop = Convert.ToInt32(classInfo["MaLop"]);
                LoadSchoolYears();
                LoadCurrentSemester(); // Thêm dòng này để tự động chọn học kỳ hiện tại
                InitializeTimetableLayout(); // Đảm bảo bảng được khởi tạo
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin lớp của học sinh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.BeginInvoke(new Action(() =>
            {
                TableLayoutPanel1_Resize(tableLayoutPanel1, EventArgs.Empty);
            }));
        }

        // Load danh sách năm học vào combobox

        // Load danh sách học kỳ theo năm học
        private void LoadSemesters()
        {
            cboHocKy.Items.Clear();
            cboHocKy.Items.Add("Học kỳ 1");
            cboHocKy.Items.Add("Học kỳ 2");
            cboHocKy.SelectedIndex = 0;
        }

        // Load danh sách tuần theo năm học và học kỳ
        private void LoadWeeks()
        {
            if (cboNamHoc.SelectedIndex < 0 || cboHocKy.SelectedIndex < 0)
                return;

            string selectedYear = cboNamHoc.SelectedItem.ToString();
            int selectedSemester = cboHocKy.SelectedIndex + 1; // 0 -> HK1, 1 -> HK2

            weeks = tkbDAL.GetWeeks(selectedYear, selectedSemester);
            maxWeek = weeks.Count;

            cboTuan.Items.Clear();
            foreach (var week in weeks)
            {
                cboTuan.Items.Add(week.ToString());
            }

            // Xác định tuần hiện tại
            currentWeek = tkbDAL.GetCurrentWeekIndex(weeks);
            if (cboTuan.Items.Count > 0)
            {
                cboTuan.SelectedIndex = currentWeek;
            }
        }


        private Tuple<int, int> ParseTietInfo(string tiet)
        {
            // Phân tích chuỗi tiết học (ví dụ: "1-3")
            try
            {
                string[] parts = tiet.Split('-');
                if (parts.Length == 2)
                {
                    int start = int.Parse(parts[0]);
                    int end = int.Parse(parts[1]);
                    return new Tuple<int, int>(start, end);
                }
                else
                {
                    int singleTiet = int.Parse(tiet);
                    return new Tuple<int, int>(singleTiet, singleTiet);
                }
            }
            catch
            {
                return new Tuple<int, int>(1, 1); // Giá trị mặc định
            }
        }

        private Panel CreateSubjectPanel(TKBDTO item)
        {
            // Tạo panel hiển thị thông tin môn học
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = GetSubjectColor(item.MaMon);
            panel.Margin = new Padding(1);
            panel.Padding = new Padding(2);

            Label lblSubject = new Label();
            lblSubject.Text = item.TenMon;
            lblSubject.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSubject.Dock = DockStyle.Top;
            lblSubject.TextAlign = ContentAlignment.MiddleCenter;
            lblSubject.Height = 25;

            Label lblTeacher = new Label();
            lblTeacher.Text = $"GV: {item.TenGiaoVien}";
            lblTeacher.Font = new Font("Segoe UI", 8.25f);
            lblTeacher.Dock = DockStyle.Bottom;
            lblTeacher.TextAlign = ContentAlignment.MiddleCenter;
            lblTeacher.Height = 20;

            panel.Controls.Add(lblTeacher);
            panel.Controls.Add(lblSubject);

            // Tạo tooltip hiển thị thông tin chi tiết khi di chuột qua
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(panel, $"Môn: {item.TenMon}\nGiáo viên: {item.TenGiaoVien}\nTiết: {item.Tiet}");

            return panel;
        }

        private Color GetSubjectColor(int maMon)
        {
            // Tạo màu ngẫu nhiên nhưng ổn định cho từng môn học
            Random rnd = new Random(maMon);
            return Color.FromArgb(rnd.Next(180, 240), rnd.Next(180, 240), rnd.Next(180, 240));
        }

        private void SetupColumnHeaders()
        {
            // Thiết lập tiêu đề cho các cột (các ngày trong tuần)
            string[] dayNames = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ Nhật" };

            for (int i = 0; i < Math.Min(dayNames.Length, tableLayoutPanel1.ColumnCount); i++)
            {
                Control header = tableLayoutPanel1.GetControlFromPosition(i, 0);
                if (header != null && header is Label)
                {
                    ((Label)header).Text = dayNames[i];
                }
            }
        }

        private void SetCurrentWeek()
        {
            try
            {
                if (weeks != null && weeks.Count > 0)
                {
                    currentWeek = tkbDAL.GetCurrentWeekIndex(weeks);
                    if (currentWeek >= 0 && currentWeek < cboTuan.Items.Count)
                    {
                        cboTuan.SelectedIndex = currentWeek;
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

        #endregion


        private string GetThoiGianTuTiet(int tiet)
        {
            switch (tiet)
            {
                case 1: return "07:30 - 08:15";
                case 2: return "08:20 - 09:05";
                case 3: return "09:20 - 10:05";
                case 4: return "10:10 - 10:55";
                case 5: return "11:00 - 11:45";
                // Nghỉ trưa
                case 7: return "13:30 - 14:15";
                case 8: return "14:20 - 15:05";
                case 9: return "15:15 - 16:00";
                case 10: return "16:05 - 16:50";
                default: return $"Tiết {tiet}";
            }
        }

        private Guna.UI2.WinForms.Guna2ProgressIndicator loadingIndicator;


        private void InitializeTimetableLayout()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = 1; // Chỉ 1 hàng cho tiêu đề
            tableLayoutPanel1.ColumnCount = 6; // Tổng số cột (6 ngày từ thứ 2 đến thứ 7)

            // Reset row styles collection
            tableLayoutPanel1.RowStyles.Clear();
            // Header row
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

            // Reset column styles collection
            tableLayoutPanel1.ColumnStyles.Clear();
            // Day columns
            for (int i = 0; i < 6; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / 6));
            }

            // Define day names
            string[] dayNames = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" };

            // Add day headers with labels stored for later reference
            for (int col = 0; col < dayNames.Length; col++)
            {
                Guna.UI2.WinForms.Guna2Panel headerPanel = new Guna.UI2.WinForms.Guna2Panel
                {
                    Dock = DockStyle.Fill,
                    FillColor = Color.FromArgb(100, 120, 230),
                    BorderRadius = 5,
                    Margin = new Padding(2),
                    Tag = col, // Store column index for reference
                };

                Guna.UI2.WinForms.Guna2HtmlLabel dayLabel = new Guna.UI2.WinForms.Guna2HtmlLabel
                {
                    Text = dayNames[col],
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = Color.Transparent,
                    TextAlignment = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                };

                headerPanel.Controls.Add(dayLabel);
                tableLayoutPanel1.Controls.Add(headerPanel, col, 0);
            }

            // Thêm một hàng cho nội dung
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Thêm các panel cho các ngày trong tuần
            for (int col = 0; col < 6; col++)
            {
                Guna.UI2.WinForms.Guna2Panel dayPanel = new Guna.UI2.WinForms.Guna2Panel
                {
                    Dock = DockStyle.Fill,
                    FillColor = Color.FromArgb(250, 250, 250),
                    BorderRadius = 5,
                    BorderColor = Color.FromArgb(230, 230, 230),
                    BorderThickness = 1,
                    Margin = new Padding(3),
                    Padding = new Padding(5),
                };

                // Tạo FlowLayoutPanel để chứa các môn học
                FlowLayoutPanel flowLayout = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    BackColor = Color.Transparent,
                };

                dayPanel.Controls.Add(flowLayout);
                tableLayoutPanel1.Controls.Add(dayPanel, col, 1);
            }

            // Đăng ký sự kiện resize cho tableLayoutPanel
            tableLayoutPanel1.Resize += TableLayoutPanel1_Resize;
        }

        private void TableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            // Duyệt qua tất cả các panel tiêu đề và cập nhật vị trí căn giữa của labels
            for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
            {
                Control header = tableLayoutPanel1.GetControlFromPosition(col, 0);
                if (header != null && header is Guna.UI2.WinForms.Guna2Panel headerPanel)
                {
                    foreach (Control ctrl in headerPanel.Controls)
                    {
                        if (ctrl is Guna.UI2.WinForms.Guna2HtmlLabel dayLabel)
                        {
                            // Đảm bảo label luôn căn giữa
                            dayLabel.TextAlignment = ContentAlignment.MiddleCenter;
                        }
                    }
                }
            }

            // Cập nhật kích thước cho các FlowLayoutPanel trong các ngày
            for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
            {
                Control dayPanel = tableLayoutPanel1.GetControlFromPosition(col, 1);
                if (dayPanel != null && dayPanel is Guna.UI2.WinForms.Guna2Panel panel)
                {
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is FlowLayoutPanel flowPanel)
                        {
                            // Với các item trong FlowLayoutPanel, cập nhật chiều rộng của chúng
                            foreach (Control item in flowPanel.Controls)
                            {
                                if (item is ucTKBItem tkbItem)
                                {
                                    tkbItem.Width = flowPanel.Width - 20; // Giữ lại khoảng trống bên lề
                                }
                            }
                        }
                    }
                }
            }
        }


        // Modify constructor to add loading indicator
        public ucTKB(int maHS, int id)
    {
        InitializeComponent();
        dbHelper = new DatabaseHelper();
        tkbDAL = new TKBDAL();
        this.id = id;
        this.maHS = maHS;;

        // Initialize loading indicator
        loadingIndicator = new Guna.UI2.WinForms.Guna2ProgressIndicator
        {
            AutoStart = false,
            Size = new Size(60, 60),
            Location = new Point((pnlContent.Width - 60) / 2, (pnlContent.Height - 60) / 2),
            Anchor = AnchorStyles.None,
            UseTransparentBackground = true,
            Visible = false
        };
        pnlContent.Controls.Add(loadingIndicator);
        loadingIndicator.BringToFront();
    }
    
    // Override OnResize to keep loading indicator centered
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (loadingIndicator != null)
        {
            loadingIndicator.Location = new Point(
                (pnlContent.Width - loadingIndicator.Width) / 2,
                (pnlContent.Height - loadingIndicator.Height) / 2);
        }
    }
    
    // Improved timetable loading method to handle loading state
    private void LoadTimetable()
    {
        if (weeks == null || currentWeek < 0 || currentWeek >= weeks.Count)
            return;

        // Show loading indicator
        pnlNoData.Visible = false;
        tableLayoutPanel1.Visible = false;
        loadingIndicator.Visible = true;
        loadingIndicator.Start();
        
        // Use BeginInvoke to allow UI to update before processing
        BeginInvoke(new Action(() =>
        {
            try
            {
                TuanHocDTO selectedWeek = weeks[currentWeek];
                List<TKBDTO> timetable = tkbDAL.GetTimetable(maLop, selectedWeek.NgayBatDau, selectedWeek.NgayKetThuc);

                // Clear existing timetable data
                ClearTimetable();
                
                // Display the timetable
                DisplayTimetable(timetable);
                
                // Show appropriate UI based on data
                tableLayoutPanel1.Visible = true;
                pnlNoData.Visible = timetable.Count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thời khóa biểu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pnlNoData.Visible = true;
                tableLayoutPanel1.Visible = true;
            }
            finally
            {
                // Hide loading indicator
                loadingIndicator.Stop();
                loadingIndicator.Visible = false;
                
                // Make sure UI is refreshed
                Refresh();
            }
        }));
    }
    
    // Load school years with proper error handling
    private void LoadSchoolYears()
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            
            List<string> years = tkbDAL.GetSchoolYears();

            cboNamHoc.Items.Clear();
            foreach (string year in years)
            {
                cboNamHoc.Items.Add(year);
            }

            if (cboNamHoc.Items.Count > 0)
            {
                cboNamHoc.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi tải danh sách năm học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }
        private void DisplayTimetable(List<TKBDTO> timetable)
        {
            // Đảm bảo bảng được khởi tạo đúng
            if (tableLayoutPanel1.RowStyles.Count < 2)
            {
                InitializeTimetableLayout();
            }

            // Xóa dữ liệu cũ
            ClearDayPanels();

            // Nhóm các lớp học theo ngày
            var timetableByDay = timetable.GroupBy(t => t.Thu)
                    .ToDictionary(g => g.Key, g => g.ToList());

            // Sắp xếp các môn học theo tiết bắt đầu
            foreach (var dayGroup in timetableByDay)
            {
                int thu = dayGroup.Key;
                List<TKBDTO> monHocTrongNgay = dayGroup.Value
                    .OrderBy(m => ParseTietInfo(m.Tiet).Item1)
                    .ToList();

                if (thu >= 2 && thu <= 7) // Thứ 2 đến thứ 7
                {
                    int columnIndex = thu - 2; // Điều chỉnh chỉ số cột (2-7 -> 0-5)

                    // Lấy FlowLayoutPanel của ngày
                    FlowLayoutPanel dayFlow = GetDayFlowPanel(columnIndex);
                    if (dayFlow != null)
                    {
                        // Thêm các môn học vào panel
                        foreach (var item in monHocTrongNgay)
                        {
                            ucTKBItem tkbItem = new ucTKBItem
                            {
                                MonHoc = item.TenMon,
                                GiaoVien = item.TenGiaoVien,
                                ThoiGian = GetThoiGianTuTiet(ParseTietInfo(item.Tiet).Item1),
                                NoiDung = $"Tiết {item.Tiet}",
                                Tiet = ParseTietInfo(item.Tiet).Item1,
                                Width = dayFlow.Width - 20, // Chiều rộng phù hợp với flow panel
                                Margin = new Padding(0, 0, 0, 5),
                            };

                            dayFlow.Controls.Add(tkbItem);
                        }
                    }
                }
            }
        }

        // Phương thức để lấy FlowLayoutPanel cho mỗi ngày - Cập nhật phù hợp với chỉ số cột mới
        private FlowLayoutPanel GetDayFlowPanel(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= tableLayoutPanel1.ColumnCount)
                return null;

            Control dayPanel = tableLayoutPanel1.GetControlFromPosition(columnIndex, 1);
            if (dayPanel != null && dayPanel is Guna.UI2.WinForms.Guna2Panel)
            {
                foreach (Control ctrl in dayPanel.Controls)
                {
                    if (ctrl is FlowLayoutPanel)
                        return ctrl as FlowLayoutPanel;
                }
            }
            return null;
        }

        // Xóa dữ liệu cũ từ các panel ngày - Cập nhật phù hợp với số cột
        private void ClearDayPanels()
        {
            for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
            {
                FlowLayoutPanel dayFlow = GetDayFlowPanel(col);
                if (dayFlow != null)
                {
                    dayFlow.Controls.Clear();
                }
            }
        }

        // Cập nhật lại phương thức ClearTimetable
        private void ClearTimetable()
        {
            ClearDayPanels();
        }
        // Thêm phương thức mới trong ucTKB.cs
        private void LoadCurrentSemester()
        {
            try
            {
                string currentSchoolYear;
                int currentSemester;

                // Lấy năm học và học kỳ hiện tại
                if (tkbDAL.SetupCurrentSemester(out currentSchoolYear, out currentSemester))
                {
                    // Chọn năm học hiện tại trong combobox
                    int yearIndex = cboNamHoc.Items.IndexOf(currentSchoolYear);
                    if (yearIndex >= 0)
                    {
                        cboNamHoc.SelectedIndex = yearIndex;
                    }

                    // Chọn học kỳ hiện tại trong combobox
                    if (currentSemester >= 1 && currentSemester <= cboHocKy.Items.Count)
                    {
                        cboHocKy.SelectedIndex = currentSemester - 1;
                    }
                    else
                    {
                        // Mặc định là học kỳ 1 nếu có lỗi
                        cboHocKy.SelectedIndex = 0;
                    }
                }
                else
                {
                    // Nếu không xác định được học kỳ hiện tại, chọn các giá trị mặc định
                    if (cboNamHoc.Items.Count > 0)
                        cboNamHoc.SelectedIndex = cboNamHoc.Items.Count - 1; // Năm học mới nhất

                    if (cboHocKy.Items.Count > 0)
                        cboHocKy.SelectedIndex = 0; // Học kỳ 1
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải học kỳ hiện tại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
