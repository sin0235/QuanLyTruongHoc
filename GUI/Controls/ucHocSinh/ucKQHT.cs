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
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucKQHT : UserControl
    {
        private DatabaseHelper dbHelper;
        private DiemSoDAL diemSoDAL;
        private int id;
        private int maNguoiDung;
        private string currentSchoolYear;
        private int currentSemester = 1;

        public ucKQHT(int MaHS, int ID)
        {
            InitializeComponent();
            id = MaHS;          // Mã học sinh
            maNguoiDung = ID;   // Mã người dùng

            dbHelper = new DatabaseHelper();
            diemSoDAL = new DiemSoDAL();

            // Đăng ký sự kiện Load
            this.Load += ucKQHT_Load;
        }

        private void ucKQHT_Load(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra ID học sinh
                if (id <= 0)
                {
                    MessageBox.Show("Không thể tải dữ liệu vì mã học sinh không hợp lệ!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tải danh sách năm học
                LoadSchoolYears();

                // Thiết lập sự kiện cho các nút
                SetupButtonEvents();

                // Khởi tạo giao diện
                InitializeUI();
                SetupEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo giao diện: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Chi tiết lỗi: {ex.StackTrace}");
            }
        }

        private void InitializeUI()
        {
            // Thiết lập giá trị mặc định cho các nút học kỳ
            btnHK1.FillColor = Color.FromArgb(94, 148, 255);
            btnHK1.ForeColor = Color.White;
            btnHK2.FillColor = Color.FromArgb(240, 240, 240);
            btnHK2.ForeColor = Color.FromArgb(100, 100, 100);
            btnCaNam.FillColor = Color.FromArgb(240, 240, 240);
            btnCaNam.ForeColor = Color.FromArgb(100, 100, 100);
            btnCaNam.Text = "Cả năm";

            // Load dữ liệu mặc định
            if (cboNamHoc.Items.Count > 0)
                cboNamHoc.SelectedIndex = 0;
        }

        private void SetupButtonEvents()
        {
            btnHK1.Click += (sender, e) => SwitchSemester(1);
            btnHK2.Click += (sender, e) => SwitchSemester(2);
            btnCaNam.Click += (sender, e) => SwitchSemester(0); // 0 = cả năm

            cboNamHoc.SelectedIndexChanged += CboNamHoc_SelectedIndexChanged;
        }

        private void LoadSchoolYears()
        {
            try
            {
                // Lấy năm học hiện tại của học sinh từ database
                string query = @"
                    SELECT LH.NamHoc
                    FROM HocSinh HS
                    JOIN LopHoc LH ON HS.MaLop = LH.MaLop
                    WHERE HS.MaHS = @MaHS";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", id }
                };

                DataTable dtCurrentYear = dbHelper.ExecuteQuery(query, parameters);
                string currentYear = null;

                if (dtCurrentYear != null && dtCurrentYear.Rows.Count > 0)
                {
                    currentYear = dtCurrentYear.Rows[0]["NamHoc"].ToString();
                }

                // Lấy tất cả các năm học có trong CSDL
                string queryAllYears = "SELECT DISTINCT NamHoc FROM LopHoc ORDER BY NamHoc DESC";
                DataTable dt = dbHelper.ExecuteQuery(queryAllYears);

                List<string> schoolYears = new List<string>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        schoolYears.Add(row["NamHoc"].ToString());
                    }
                }
                else
                {
                    // Nếu không có dữ liệu, dùng giá trị mặc định
                    schoolYears = new List<string> { "2024-2025", "2023-2024", "2022-2023" };
                }

                cboNamHoc.DataSource = schoolYears;

                // Chọn năm học hiện tại của học sinh nếu có
                if (!string.IsNullOrEmpty(currentYear) && schoolYears.Contains(currentYear))
                {
                    cboNamHoc.SelectedItem = currentYear;
                }
                else if (schoolYears.Count > 0)
                {
                    // Mặc định chọn năm học đầu tiên trong danh sách
                    cboNamHoc.SelectedIndex = 0;
                }

                currentSchoolYear = cboNamHoc.SelectedItem?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách năm học: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Nếu có lỗi, dùng giá trị mặc định
                List<string> defaultYears = new List<string> { "2024-2025", "2023-2024", "2022-2023" };
                cboNamHoc.DataSource = defaultYears;
                currentSchoolYear = defaultYears[0];
            }
        }

        private void CboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNamHoc.SelectedValue != null)
            {
                currentSchoolYear = cboNamHoc.SelectedValue.ToString();
                LoadSemesterData();
            }
        }

        private void SwitchSemester(int semester)
        {
            currentSemester = semester;

            // Cập nhật UI cho các nút học kỳ
            btnHK1.FillColor = (semester == 1) ? Color.FromArgb(94, 148, 255) : Color.FromArgb(240, 240, 240);
            btnHK1.ForeColor = (semester == 1) ? Color.White : Color.FromArgb(100, 100, 100);

            btnHK2.FillColor = (semester == 2) ? Color.FromArgb(94, 148, 255) : Color.FromArgb(240, 240, 240);
            btnHK2.ForeColor = (semester == 2) ? Color.White : Color.FromArgb(100, 100, 100);

            btnCaNam.FillColor = (semester == 0) ? Color.FromArgb(94, 148, 255) : Color.FromArgb(240, 240, 240);
            btnCaNam.ForeColor = (semester == 0) ? Color.White : Color.FromArgb(100, 100, 100);

            // Cập nhật tiêu đề tổng kết
            lblSummaryTitle.Text = (semester == 0) ? $"Tổng kết năm học" : $"Tổng kết học kỳ {semester}";

            // Load dữ liệu học kỳ
            LoadSemesterData();
        }

        private void NavigateSemester(int direction)
        {
            // Chuyển đổi học kỳ theo hướng
            if (direction > 0)
            {
                if (currentSemester < 2)
                    SwitchSemester(currentSemester + 1);
                else if (currentSemester == 2)
                    SwitchSemester(0); // Chuyển sang cả năm
            }
            else
            {
                if (currentSemester == 0)
                    SwitchSemester(2); // Từ cả năm về học kỳ 2
                else if (currentSemester > 1)
                    SwitchSemester(currentSemester - 1);
            }
        }

        private void LoadSemesterData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Xóa các control hiện tại
                pnlSubjects.Controls.Clear();
                pnlSubjects.AutoScroll = true; // Đảm bảo có thể cuộn khi nội dung dài

                // Lấy điểm số của học sinh theo học kỳ
                List<MonHocScoreDTO> subjectScores = diemSoDAL.GetStudentSubjectsScore(
                    id, currentSemester, currentSchoolYear);

                // Kiểm tra nếu không có dữ liệu
                if (subjectScores == null || subjectScores.Count == 0)
                {
                    // Hiển thị thông báo không có dữ liệu
                    Label lblNoData = new Label
                    {
                        Text = "Không có dữ liệu điểm cho học kỳ này.",
                        Font = new Font("Segoe UI", 12, FontStyle.Regular),
                        ForeColor = Color.FromArgb(100, 100, 100),
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top,
                        Padding = new Padding(0, 50, 0, 0)
                    };
                    pnlSubjects.Controls.Add(lblNoData);
                    lblNoData.BringToFront();
                }
                else
                {
                    // Thêm FlowLayoutPanel để tự động xếp các item
                    FlowLayoutPanel flowPanel = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        FlowDirection = FlowDirection.TopDown,
                        WrapContents = false,
                        AutoScroll = true,
                        Padding = new Padding(15, 10, 15, 10)
                    };
                    pnlSubjects.Controls.Add(flowPanel);

                    // Tạo và hiển thị các item điểm số
                    foreach (MonHocScoreDTO subject in subjectScores)
                    {
                        ucKQHTItem subjectItem = new ucKQHTItem(
                            subject.TenMon,
                            subject.DiemMieng,
                            subject.Diem15Phut,
                            subject.DiemCuoiKy,
                            subject.NhanXet
                        );

                        // Điều chỉnh kích thước phù hợp với flowPanel
                        subjectItem.AdjustToContainerWidth(flowPanel.ClientSize.Width);
                        subjectItem.AutoSetColor();
                        subjectItem.Margin = new Padding(0, 0, 0, 10); // Tạo khoảng cách giữa các item

                        flowPanel.Controls.Add(subjectItem);
                    }

                    // Đảm bảo flowPanel có chiều rộng đúng sau khi thêm các item
                    flowPanel.PerformLayout();
                }

                // Load dữ liệu tổng kết
                LoadSummaryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu học kỳ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Chi tiết lỗi: {ex.StackTrace}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LoadSummaryData()
        {
            try
            {
                // Hiển thị trạng thái đang tải
                lblGPAValue.Text = "...";
                lblConductValue.Text = "...";
                lblRankValue.Text = "...";
                lblAbsentValue.Text = "...";
                lblAcademicPerformanceValue.Text = "...";
                lblAwardsValue.Text = "...";
                txtTeacherComment.Text = "Đang tải thông tin tổng kết...";

                // Sử dụng Task để không block UI thread
                Task.Run(() => diemSoDAL.GetSemesterSummary(id, currentSemester, currentSchoolYear))
                    .ContinueWith(task =>
                    {
                        if (this.IsHandleCreated && !this.IsDisposed)
                        {
                            this.Invoke(new Action(() =>
                            {
                                try
                                {
                                    // Lấy kết quả từ task
                                    HocKySummaryDTO summary = task.Result;

                                    if (summary != null)
                                    {
                                        // Cập nhật UI
                                        lblGPAValue.Text = summary.DiemTrungBinh.ToString("0.0");
                                        lblConductValue.Text = summary.HanhKiem;
                                        lblRankValue.Text = summary.XepHang.ToString();
                                        lblAbsentValue.Text = summary.SoBuoiNghi.ToString();
                                        lblAcademicPerformanceValue.Text = summary.XepLoai;
                                        txtTeacherComment.Text = summary.NhanXet ?? "Không có nhận xét.";

                                        // Đặt danh hiệu nếu có
                                        if (!string.IsNullOrEmpty(summary.XepLoai))
                                        {
                                            if (summary.XepLoai == "Giỏi" && summary.HanhKiem == "Tốt")
                                                lblAwardsValue.Text = "Học sinh Giỏi";
                                            else if (summary.XepLoai == "Khá" && (summary.HanhKiem == "Tốt" || summary.HanhKiem == "Khá"))
                                                lblAwardsValue.Text = "Học sinh Tiên tiến";
                                            else
                                                lblAwardsValue.Text = "Không có";
                                        }

                                        // Đặt màu sắc dựa trên điểm trung bình
                                        if (summary.DiemTrungBinh >= 8.0)
                                            lblGPAValue.ForeColor = Color.FromArgb(0, 150, 60); // Xanh đậm
                                        else if (summary.DiemTrungBinh >= 7.0)
                                            lblGPAValue.ForeColor = Color.FromArgb(0, 180, 80); // Xanh nhạt
                                        else if (summary.DiemTrungBinh >= 5.0)
                                            lblGPAValue.ForeColor = Color.FromArgb(230, 130, 0); // Cam
                                        else
                                            lblGPAValue.ForeColor = Color.FromArgb(220, 53, 69); // Đỏ
                                    }
                                    else
                                    {
                                        // Không có dữ liệu tổng kết, hiển thị thông tin mặc định
                                        lblGPAValue.Text = "---";
                                        lblConductValue.Text = "---";
                                        lblRankValue.Text = "---";
                                        lblAbsentValue.Text = "---";
                                        lblAcademicPerformanceValue.Text = "---";
                                        lblAwardsValue.Text = "---";
                                        txtTeacherComment.Text = "Chưa có thông tin tổng kết cho học kỳ này.";

                                        // Đặt màu mặc định
                                        lblGPAValue.ForeColor = Color.Gray;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Lỗi khi hiển thị dữ liệu tổng kết: {ex.Message}");

                                    // Thiết lập giá trị mặc định nếu có lỗi
                                    lblGPAValue.Text = "---";
                                    lblConductValue.Text = "---";
                                    lblRankValue.Text = "---";
                                    lblAbsentValue.Text = "---";
                                    lblAcademicPerformanceValue.Text = "---";
                                    lblAwardsValue.Text = "---";
                                    txtTeacherComment.Text = $"Lỗi khi tải dữ liệu tổng kết: {ex.Message}";
                                }
                            }));
                        }
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải dữ liệu tổng kết: {ex.Message}");

                // Thiết lập giá trị mặc định nếu có lỗi
                lblGPAValue.Text = "---";
                lblConductValue.Text = "---";
                lblRankValue.Text = "---";
                lblAbsentValue.Text = "---";
                lblAcademicPerformanceValue.Text = "---";
                lblAwardsValue.Text = "---";
                txtTeacherComment.Text = $"Lỗi khi tải dữ liệu tổng kết: {ex.Message}";
            }
        }
       
        /// <summary>
        /// Làm mới dữ liệu hiện tại
        /// </summary>
        public void RefreshData()
        {
            try
            {
                // Tải lại dữ liệu học kỳ hiện tại
                LoadSemesterData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Chi tiết lỗi: {ex.StackTrace}");
            }
        }

        private void SetupEvents()
        {

            pnlSubjects.Resize += pnlSubjects_Resize;
        }


        // Thêm handler cho sự kiện resize của pnlSubjects
        private void pnlSubjects_Resize(object sender, EventArgs e)
        {
            // Cập nhật lại kích thước các item nếu cần
            foreach (Control ctrl in pnlSubjects.Controls)
            {
                if (ctrl is FlowLayoutPanel flowPanel)
                {
                    foreach (Control item in flowPanel.Controls)
                    {
                        if (item is ucKQHTItem scoreItem)
                        {
                            // Điều chỉnh lại kích thước item theo kích thước mới của panel
                            scoreItem.AdjustToContainerWidth(flowPanel.ClientSize.Width);
                        }
                    }
                }
            }
        }
    }
}
