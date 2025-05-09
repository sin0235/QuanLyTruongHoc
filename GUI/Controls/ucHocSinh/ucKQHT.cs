using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucKQHT : UserControl
    {
        private DatabaseHelper dbHelper;
        private DiemSoDAO diemSoDAL;
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
            diemSoDAL = new DiemSoDAO();

            this.Load += ucKQHT_Load;
        }

        private void ucKQHT_Load(object sender, EventArgs e)
        {
            try
            {
                if (id <= 0)
                {
                    MessageBox.Show("Không thể tải dữ liệu vì mã học sinh không hợp lệ!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadSchoolYears();
                SetupButtonEvents();
                InitializeUI();
                SetupEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo giao diện: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeUI()
        {
            btnHK1.FillColor = Color.FromArgb(94, 148, 255);
            btnHK1.ForeColor = Color.White;
            btnHK2.FillColor = Color.FromArgb(240, 240, 240);
            btnHK2.ForeColor = Color.FromArgb(100, 100, 100);
            btnCaNam.FillColor = Color.FromArgb(240, 240, 240);
            btnCaNam.ForeColor = Color.FromArgb(100, 100, 100);
            btnCaNam.Text = "Cả năm";

            if (cboNamHoc.Items.Count > 0)
                cboNamHoc.SelectedIndex = 0;
        }

        private void SetupButtonEvents()
        {
            btnHK1.Click += (sender, e) => SwitchSemester(1);
            btnHK2.Click += (sender, e) => SwitchSemester(2);
            btnCaNam.Click += (sender, e) => SwitchSemester(0);
            cboNamHoc.SelectedIndexChanged += CboNamHoc_SelectedIndexChanged;
        }

        private void LoadSchoolYears()
        {
            try
            {
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
                    schoolYears = new List<string> { "2024-2025", "2023-2024", "2022-2023" };
                }

                cboNamHoc.DataSource = schoolYears;

                if (!string.IsNullOrEmpty(currentYear) && schoolYears.Contains(currentYear))
                {
                    cboNamHoc.SelectedItem = currentYear;
                }
                else if (schoolYears.Count > 0)
                {
                    cboNamHoc.SelectedIndex = 0;
                }

                currentSchoolYear = cboNamHoc.SelectedItem?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách năm học: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

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

            btnHK1.FillColor = (semester == 1) ? Color.FromArgb(94, 148, 255) : Color.FromArgb(240, 240, 240);
            btnHK1.ForeColor = (semester == 1) ? Color.White : Color.FromArgb(100, 100, 100);

            btnHK2.FillColor = (semester == 2) ? Color.FromArgb(94, 148, 255) : Color.FromArgb(240, 240, 240);
            btnHK2.ForeColor = (semester == 2) ? Color.White : Color.FromArgb(100, 100, 100);

            btnCaNam.FillColor = (semester == 0) ? Color.FromArgb(94, 148, 255) : Color.FromArgb(240, 240, 240);
            btnCaNam.ForeColor = (semester == 0) ? Color.White : Color.FromArgb(100, 100, 100);

            lblSummaryTitle.Text = (semester == 0) ? "Tổng kết năm học" : $"Tổng kết học kỳ {semester}";

            LoadSemesterData();
        }

        private void LoadSemesterData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                pnlSubjects.Controls.Clear();
                pnlSubjects.AutoScroll = true;

                List<MonHocScoreDTO> subjectScores = diemSoDAL.GetStudentSubjectsScore(
                    id, currentSemester, currentSchoolYear);

                if (subjectScores == null || subjectScores.Count == 0)
                {
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
                    FlowLayoutPanel flowPanel = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        FlowDirection = FlowDirection.TopDown,
                        WrapContents = false,
                        AutoScroll = true,
                        Padding = new Padding(15, 10, 15, 10)
                    };
                    pnlSubjects.Controls.Add(flowPanel);

                    foreach (MonHocScoreDTO subject in subjectScores)
                    {
                        // Sử dụng constructor mới với các danh sách điểm
                        ucKQHTItem subjectItem = new ucKQHTItem(
                            subject.TenMon,
                            subject.DiemMiengList,
                            subject.Diem15PhutList,
                            subject.DiemGiuaKyList,
                            subject.DiemCuoiKyList,
                            subject.NhanXet
                        );

                        subjectItem.AdjustToContainerWidth(flowPanel.ClientSize.Width);
                        subjectItem.AutoSetColor();
                        subjectItem.Margin = new Padding(0, 0, 0, 10);

                        flowPanel.Controls.Add(subjectItem);
                    }

                    flowPanel.PerformLayout();
                }

                LoadSummaryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu học kỳ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lblGPAValue.Text = "...";
                lblConductValue.Text = "...";
                lblRankValue.Text = "...";
                lblAbsentValue.Text = "...";
                lblAcademicPerformanceValue.Text = "...";
                lblAwardsValue.Text = "...";
                txtTeacherComment.Text = "Đang tải thông tin tổng kết...";

                Task.Run(() => diemSoDAL.GetSemesterSummary(id, currentSemester, currentSchoolYear))
                    .ContinueWith(task =>
                    {
                        if (this.IsHandleCreated && !this.IsDisposed)
                        {
                            this.Invoke(new Action(() =>
                            {
                                try
                                {
                                    HocKySummaryDTO summary = task.Result;

                                    if (summary != null)
                                    {
                                        lblGPAValue.Text = summary.DiemTrungBinh.ToString("0.0");
                                        lblConductValue.Text = summary.HanhKiem;
                                        lblRankValue.Text = summary.XepHang.ToString();
                                        lblAbsentValue.Text = summary.SoBuoiNghi.ToString();
                                        lblAcademicPerformanceValue.Text = summary.XepLoai;
                                        txtTeacherComment.Text = summary.NhanXet ?? "Không có nhận xét.";

                                        if (!string.IsNullOrEmpty(summary.XepLoai))
                                        {
                                            if (summary.XepLoai == "Giỏi" && summary.HanhKiem == "Tốt")
                                                lblAwardsValue.Text = "Học sinh Giỏi";
                                            else if (summary.XepLoai == "Khá" && (summary.HanhKiem == "Tốt" || summary.HanhKiem == "Khá"))
                                                lblAwardsValue.Text = "Học sinh Tiên tiến";
                                            else
                                                lblAwardsValue.Text = "Không có";
                                        }

                                        if (summary.DiemTrungBinh >= 8.0)
                                            lblGPAValue.ForeColor = Color.FromArgb(0, 150, 60);
                                        else if (summary.DiemTrungBinh >= 7.0)
                                            lblGPAValue.ForeColor = Color.FromArgb(0, 180, 80);
                                        else if (summary.DiemTrungBinh >= 5.0)
                                            lblGPAValue.ForeColor = Color.FromArgb(230, 130, 0);
                                        else
                                            lblGPAValue.ForeColor = Color.FromArgb(220, 53, 69);
                                    }
                                    else
                                    {
                                        lblGPAValue.Text = "---";
                                        lblConductValue.Text = "---";
                                        lblRankValue.Text = "---";
                                        lblAbsentValue.Text = "---";
                                        lblAcademicPerformanceValue.Text = "---";
                                        lblAwardsValue.Text = "---";
                                        txtTeacherComment.Text = "Chưa có thông tin tổng kết cho học kỳ này.";
                                        lblGPAValue.ForeColor = Color.Gray;
                                    }
                                }
                                catch (Exception)
                                {
                                    lblGPAValue.Text = "---";
                                    lblConductValue.Text = "---";
                                    lblRankValue.Text = "---";
                                    lblAbsentValue.Text = "---";
                                    lblAcademicPerformanceValue.Text = "---";
                                    lblAwardsValue.Text = "---";
                                    txtTeacherComment.Text = "Lỗi khi tải dữ liệu tổng kết.";
                                }
                            }));
                        }
                    });
            }
            catch (Exception)
            {
                lblGPAValue.Text = "---";
                lblConductValue.Text = "---";
                lblRankValue.Text = "---";
                lblAbsentValue.Text = "---";
                lblAcademicPerformanceValue.Text = "---";
                lblAwardsValue.Text = "---";
                txtTeacherComment.Text = "Lỗi khi tải dữ liệu tổng kết.";
            }
        }

        public void RefreshData()
        {
            try
            {
                LoadSemesterData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupEvents()
        {
            pnlSubjects.Resize += pnlSubjects_Resize;
        }

        private void pnlSubjects_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in pnlSubjects.Controls)
            {
                if (ctrl is FlowLayoutPanel flowPanel)
                {
                    foreach (Control item in flowPanel.Controls)
                    {
                        if (item is ucKQHTItem scoreItem)
                        {
                            scoreItem.AdjustToContainerWidth(flowPanel.ClientSize.Width);
                        }
                    }
                }
            }
        }
    }
}
