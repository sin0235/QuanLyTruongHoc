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
    public partial class ucKQHTItem : UserControl
    {
        // Properties for subject data
        private string _subjectName = "Môn học";
        private float _assignmentScore = 0;
        private float _midtermScore = 0;
        private float _finalScore = 0;
        private float _averageScore = 0;
        private string _teacherComment = "";
        private Image _subjectIcon = null;

        // Public properties with getters and setters
        public string SubjectName
        {
            get { return _subjectName; }
            set
            {
                _subjectName = value;
                lblSubjectName.Text = value;
            }
        }

        public float AssignmentScore
        {
            get { return _assignmentScore; }
            set
            {
                _assignmentScore = value;
                lblAssignmentScore.Text = value.ToString("0.0");
                prgAssignment.Value = (int)(value * 10);
                UpdateAverageScore();
            }
        }

        public float MidtermScore
        {
            get { return _midtermScore; }
            set
            {
                _midtermScore = value;
                lblMidtermExamScore.Text = value.ToString("0.0");
                prgMidtermExam.Value = (int)(value * 10);
                UpdateAverageScore();
            }
        }

        public float FinalScore
        {
            get { return _finalScore; }
            set
            {
                _finalScore = value;
                lblFinalExamScore.Text = value.ToString("0.0");
                prgFinalExam.Value = (int)(value * 10);
                UpdateAverageScore();
            }
        }

        public float AverageScore
        {
            get { return _averageScore; }
            set
            {
                _averageScore = value;
                lblAvgScore.Text = value.ToString("0.0");
                prgAverage.Value = (int)(value * 10);
                prgAverage.Text = value.ToString("0.0");
            }
        }

        public string TeacherComment
        {
            get { return _teacherComment; }
            set
            {
                _teacherComment = value;
                txtTeacherComment.Text = value;
            }
        }

        public Image SubjectIcon
        {
            get { return _subjectIcon; }
            set
            {
                _subjectIcon = value;
                if (value != null)
                    imgSubject.Image = value;
            }
        }

        public ucKQHTItem()
        {
            InitializeComponent();

            // Set design-time values
            SubjectName = "Toán";
            AssignmentScore = 7.0f;
            MidtermScore = 8.0f;
            FinalScore = 9.0f;
            AverageScore = 8.2f;
            TeacherComment = "Học sinh đạt kết quả tốt, có nhiều tiến bộ. Cần chú ý thêm về phần thực hành.";

            // Hook event handlers
            btnDetails.Click += BtnDetails_Click;
        }

        // Constructor with parameters for easy initialization
        public ucKQHTItem(string subjectName, float assignmentScore, float midtermScore, float finalScore, string comment = "")
        {
            InitializeComponent();

            SubjectName = subjectName;
            AssignmentScore = assignmentScore;
            MidtermScore = midtermScore;
            FinalScore = finalScore;
            TeacherComment = comment;

            // Calculate average with default weights
            UpdateAverageScore();

            // Hook event handlers
            btnDetails.Click += BtnDetails_Click;
        }

        private void UpdateAverageScore()
        {
            // Calculate weighted average: 20% assignment, 30% midterm, 50% final
            float avg = (_assignmentScore * 0.2f) + (_midtermScore * 0.3f) + (_finalScore * 0.5f);
            AverageScore = avg;
        }

        private void BtnDetails_Click(object sender, EventArgs e)
        {
            // Show detailed scores for this subject
            MessageBox.Show($"Chi tiết điểm môn {SubjectName}:\n" +
                            $"- Điểm thường xuyên: {AssignmentScore}\n" +
                            $"- Điểm giữa kỳ: {MidtermScore}\n" +
                            $"- Điểm cuối kỳ: {FinalScore}\n" +
                            $"- Điểm trung bình: {AverageScore}",
                            "Chi tiết điểm số",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        // Use this method to set a color theme for the subject
        public void SetSubjectColor(Color primaryColor, Color secondaryColor)
        {
            prgAverage.ProgressColor = primaryColor;
            prgAverage.ProgressColor2 = secondaryColor;
            imgSubject.FillColor = Color.FromArgb(primaryColor.A,
                                                 (primaryColor.R + 255) / 2,
                                                 (primaryColor.G + 255) / 2,
                                                 (primaryColor.B + 255) / 2);
        }

        // Automatically set color based on subject name
        public void AutoSetColor()
        {
            // Generate a color based on subject name hash
            int hash = SubjectName.GetHashCode();

            // Create a consistent color based on the subject name
            Color primary = GetSubjectColor(SubjectName);
            Color secondary = Color.FromArgb(primary.A,
                                           Math.Min(primary.R + 30, 255),
                                           Math.Min(primary.G + 30, 255),
                                           Math.Min(primary.B + 30, 255));

            SetSubjectColor(primary, secondary);
        }

        private Color GetSubjectColor(string subject)
        {
            // Predefined colors for common subjects
            subject = subject.ToLower();

            if (subject.Contains("toán"))
                return Color.FromArgb(94, 148, 255);

            if (subject.Contains("lý") || subject.Contains("physics"))
                return Color.FromArgb(240, 120, 80);

            if (subject.Contains("hóa") || subject.Contains("chemistry"))
                return Color.FromArgb(180, 90, 210);

            if (subject.Contains("sinh") || subject.Contains("biology"))
                return Color.FromArgb(90, 180, 100);

            if (subject.Contains("văn") || subject.Contains("literature"))
                return Color.FromArgb(230, 150, 70);

            if (subject.Contains("anh") || subject.Contains("english"))
                return Color.FromArgb(60, 170, 210);

            if (subject.Contains("sử") || subject.Contains("history"))
                return Color.FromArgb(200, 110, 80);

            if (subject.Contains("địa") || subject.Contains("geography"))
                return Color.FromArgb(80, 150, 120);

            // Default color for other subjects - generate based on name hash
            int hash = subject.GetHashCode();
            return Color.FromArgb(
                Math.Abs((hash) % 156) + 100,  // R component (100-255)
                Math.Abs((hash >> 8) % 156) + 100,  // G component (100-255)
                Math.Abs((hash >> 16) % 156) + 100  // B component (100-255)
            );
        }

        private void pnlTeacherComment_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
