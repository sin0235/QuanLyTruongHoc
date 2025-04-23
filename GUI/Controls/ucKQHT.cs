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
        private int currentStudentId;
        private string currentSchoolYear;
        private int currentSemester = 1; // Mặc định là học kỳ 1
        private List<SubjectScore> subjectScores = new List<SubjectScore>();
        private SemesterSummary semesterSummary;

        public ucKQHT()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void ucKQHT_Load(object sender, EventArgs e)
        {
            // Lấy ID học sinh hiện tại từ form đăng nhập
            currentStudentId = QuanLyTruongHoc.frmLogin.LoggedInStudentId;

            LoadSchoolYears();
            SetupButtonEvents();
            InitializeUI();
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

        }

        private void LoadSummaryData()
        {
        }

        // Lớp hỗ trợ lưu thông tin điểm từng môn học
        public class SubjectScore
        {
            public string SubjectName { get; set; }
            public float AssignmentScore { get; set; }
            public float MidtermScore { get; set; }
            public float FinalScore { get; set; }
            public float AverageScore { get; set; }
            public string TeacherComment { get; set; }
        }

        // Lớp hỗ trợ lưu thông tin tổng kết học kỳ
        public class SemesterSummary
        {
            public string AcademicPerformance { get; set; } // Học lực
            public string Conduct { get; set; } // Hạnh kiểm
            public float GPA { get; set; } // Điểm trung bình
            public string Awards { get; set; } // Danh hiệu
            public int Rank { get; set; } // Xếp hạng
            public int Absent { get; set; } // Số buổi nghỉ
            public string TeacherComment { get; set; } // Nhận xét của giáo viên
        }

        private void btnHK1_Click(object sender, EventArgs e)
        {

        }

        private void cardSummary_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
