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
        /// <summary>
        /// Điều chỉnh kích thước ucKQHTItem theo chiều rộng của container
        /// </summary>
        /// <param name="containerWidth">Chiều rộng của container</param>
        public void AdjustToContainerWidth(int containerWidth)
        {
            try
            {
                if (containerWidth <= 0) return;

                // Tính toán kích thước mới, trừ đi lề phù hợp
                int newWidth = containerWidth - 30;

                // Chỉ cập nhật khi kích thước thực sự thay đổi
                if (this.Width != newWidth)
                {
                    this.Width = newWidth;

                    // Áp dụng kích thước mới cho pnlMain
                    pnlMain.Width = newWidth - 20;

                    // Đảm bảo kích thước tối thiểu cho các thành phần
                    if (pnlMain.Width < 600)
                        pnlMain.Width = 600;

                    // Cập nhật vị trí và kích thước của tất cả các thành phần
                    UpdateLayoutOnResize();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi điều chỉnh kích thước: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật lại giao diện khi kích thước thay đổi
        /// </summary>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            // Cập nhật lại vị trí các thành phần nếu cần
            UpdateLayoutOnResize();
        }

        /// <summary>
        /// Cập nhật vị trí các control khi kích thước thay đổi
        /// </summary>
        private void UpdateLayoutOnResize()
        {
            try
            {
                // Cập nhật kích thước pnlMain để lấp đầy không gian có sẵn
                pnlMain.Width = this.Width - 20;

                // Cập nhật kích thước các panel con để phù hợp với pnlMain
                if (pnlHeader != null)
                    pnlHeader.Width = pnlMain.Width;

                if (pnlScoreDetails != null)
                    pnlScoreDetails.Width = pnlMain.Width;

                if (pnlTeacherComment != null)
                    pnlTeacherComment.Width = pnlMain.Width;

                // Điều chỉnh vị trí của vòng tròn hiển thị điểm trung bình
                if (prgAverage != null)
                {
                    prgAverage.Left = pnlScoreDetails.Width - prgAverage.Width - 30;
                }

                // Điều chỉnh nút chi tiết và nhãn điểm trung bình
                if (btnDetails != null)
                {
                    btnDetails.Left = pnlHeader.Width - btnDetails.Width - 30;
                }

                if (lblAvgScore != null)
                {
                    lblAvgScore.Left = btnDetails.Left - lblAvgScore.Width - 20;
                }

                // Tính toán chiều rộng hợp lý cho các progress bar
                int maxProgressBarWidth = pnlScoreDetails.Width - 250 - prgAverage.Width;
                int progressBarWidth = Math.Min(maxProgressBarWidth, 600); // Giới hạn chiều rộng tối đa

                // Cập nhật chiều rộng của các progress bar
                if (prgAssignment != null)
                    prgAssignment.Width = progressBarWidth;

                if (prgMidtermExam != null)
                    prgMidtermExam.Width = progressBarWidth;

                if (prgFinalExam != null)
                    prgFinalExam.Width = progressBarWidth;

                // Điều chỉnh txtTeacherComment để sử dụng hết không gian
                if (txtTeacherComment != null)
                {
                    txtTeacherComment.Width = pnlTeacherComment.Width - 30;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật layout: {ex.Message}");
            }
        }

        /// <summary>
        /// Đặt margin cho control để tạo khoảng cách giữa các item
        /// </summary>
        public void SetItemMargin(int top = 0, int bottom = 10)
        {
            this.Margin = new Padding(0, top, 0, bottom);
        }
        // Properties for subject data
        private string _subjectName = "";
        private float _assignmentScore = 0;
        private List<float> _midtermScores = new List<float>();
        private float _midtermAvgScore = 0;
        private float _finalScore = 0;
        private float _averageScore = 0;
        private string _teacherComment = "";

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

        // Cập nhật hàm setter cho các thuộc tính để đảm bảo Progress Bar hiển thị đúng
        public float AssignmentScore
        {
            get { return _assignmentScore; }
            set
            {
                _assignmentScore = value;
                lblAssignmentScore.Text = value.ToString("0.0");

                // Đảm bảo progress bar có Maximum = 100
                if (prgAssignment.Maximum != 100) prgAssignment.Maximum = 100;

                // Chuyển đổi điểm thành phần trăm (0-10 -> 0-100)
                prgAssignment.Value = Math.Min(Math.Max((int)(value * 10), 0), 100);
                UpdateAverageScore();
            }
        }

        public List<float> MidtermScores
        {
            get { return _midtermScores; }
            set
            {
                _midtermScores = value ?? new List<float>();
                UpdateMidtermAverage();
            }
        }

        public float MidtermAvgScore
        {
            get { return _midtermAvgScore; }
            private set
            {
                _midtermAvgScore = value;
                lblMidtermExamScore.Text = value.ToString("0.0");
                prgMidtermExam.Value = Math.Min(Math.Max((int)(value * 10), 0), 100);
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
                prgFinalExam.Value = Math.Min(Math.Max((int)(value * 10), 0), 100);
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
                prgAverage.Value = Math.Min(Math.Max((int)(value * 10), 0), 100);
                prgAverage.Text = value.ToString("0.0");

                // Cập nhật màu sắc theo điểm
                UpdateProgressBarColors();
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

        public ucKQHTItem()
        {
            InitializeComponent();

            // Đảm bảo các progress bar có giá trị Maximum đúng
            prgAssignment.Maximum = 100;
            prgMidtermExam.Maximum = 100;
            prgFinalExam.Maximum = 100;
            prgAverage.Maximum = 100;

            // Đăng ký sự kiện Resize để cập nhật layout khi kích thước thay đổi
            this.Resize += (sender, e) => UpdateLayoutOnResize();

            // Đăng ký sự kiện cho nút chi tiết
            btnDetails.Click += BtnDetails_Click;

            // Đặt giá trị mặc định cho các label
            lblAssignmentScore.Text = "0.0";
            lblMidtermExamScore.Text = "0.0";
            lblFinalExamScore.Text = "0.0";
            lblAvgScore.Text = "0.0";

            // Cập nhật hiển thị progress bar với giá trị 0
            UpdateProgressBarsDisplay();
            FixProgressBars();
        }

        // Constructor với danh sách điểm 15 phút
        public ucKQHTItem(string subjectName, float assignmentScore, List<float> midtermScores, float finalScore, string comment = "")
        {
            InitializeComponent();

            SubjectName = subjectName;
            AssignmentScore = assignmentScore;
            MidtermScores = midtermScores ?? new List<float>();
            FinalScore = finalScore;
            TeacherComment = comment;

            // Hook event handlers
            btnDetails.Click += BtnDetails_Click;

            // Cập nhật hiển thị progress bar
            UpdateProgressBarsDisplay();
        }

        // Constructor cũ cho tương thích ngược
        public ucKQHTItem(string subjectName, float assignmentScore, float midtermScore, float finalScore, string comment = "")
        {
            InitializeComponent();

            SubjectName = subjectName;
            AssignmentScore = assignmentScore;
            MidtermScores = new List<float> { midtermScore };
            FinalScore = finalScore;
            TeacherComment = comment;

            // Hook event handlers
            btnDetails.Click += BtnDetails_Click;

            // Cập nhật hiển thị progress bar
            UpdateProgressBarsDisplay();
        }

        private void UpdateMidtermAverage()
        {
            if (_midtermScores == null || _midtermScores.Count == 0)
            {
                MidtermAvgScore = 0;
                return;
            }

            float total = 0;
            foreach (float score in _midtermScores)
            {
                total += score;
            }
            MidtermAvgScore = (float)Math.Round(total / _midtermScores.Count, 1);
        }

        private void UpdateAverageScore()
        {
            // Tính điểm trung bình: 20% điểm thường xuyên, 30% điểm 15 phút, 50% điểm cuối kỳ
            float avg = (_assignmentScore * 0.2f) + (_midtermAvgScore * 0.3f) + (_finalScore * 0.5f);
            AverageScore = (float)Math.Round(avg, 1);
        }

        // Trong ucKQHTItem.cs, cần cập nhật phương thức UpdateProgressBarsDisplay()

        private void UpdateProgressBarsDisplay()
        {
            try
            {
                Console.WriteLine($"AssignmentScore: {AssignmentScore}, Value: {(int)(AssignmentScore * 10)}");
                Console.WriteLine($"MidtermAvgScore: {MidtermAvgScore}, Value: {(int)(MidtermAvgScore * 10)}");
                Console.WriteLine($"FinalScore: {FinalScore}, Value: {(int)(FinalScore * 10)}");

                // Đảm bảo các progress bar có Maximum = 100
                if (prgAssignment.Maximum != 100) prgAssignment.Maximum = 100;
                if (prgMidtermExam.Maximum != 100) prgMidtermExam.Maximum = 100;
                if (prgFinalExam.Maximum != 100) prgFinalExam.Maximum = 100;
                if (prgAverage.Maximum != 100) prgAverage.Maximum = 100;

                // Cập nhật progress bar cho điểm trung bình - thang điểm 10 tương ứng với 100%
                prgAverage.Value = Math.Min(Math.Max((int)(AverageScore * 10), 0), 100);
                prgAverage.Text = AverageScore.ToString("0.0");

                // Cập nhật các progress bar khác dựa trên giá trị điểm tương ứng với thang điểm 10
                prgAssignment.Value = Math.Min((int)(AssignmentScore * 10), 100);
                prgMidtermExam.Value = Math.Min((int)(MidtermAvgScore * 10), 100);
                prgFinalExam.Value = Math.Min((int)(FinalScore * 10), 100);

                // Cập nhật màu sắc dựa trên điểm
                UpdateProgressBarColors();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                Console.WriteLine($"Lỗi khi cập nhật progress bar: {ex.Message}");
            }
        }

        // Cập nhật phương thức UpdateProgressBarColors() để hiển thị màu sắc theo phần trăm điểm chính xác
        private void UpdateProgressBarColors()
        {
            // Đặt màu cho các progress bar dựa trên điểm số chuẩn
            prgAssignment.ProgressColor = GetColorForScore(AssignmentScore);
            prgAssignment.ProgressColor2 = GetSecondaryColorForScore(AssignmentScore);
            lblAssignmentScore.ForeColor = GetColorForScore(AssignmentScore);

            prgMidtermExam.ProgressColor = GetColorForScore(MidtermAvgScore);
            prgMidtermExam.ProgressColor2 = GetSecondaryColorForScore(MidtermAvgScore);
            lblMidtermExamScore.ForeColor = GetColorForScore(MidtermAvgScore);

            prgFinalExam.ProgressColor = GetColorForScore(FinalScore);
            prgFinalExam.ProgressColor2 = GetSecondaryColorForScore(FinalScore);
            lblFinalExamScore.ForeColor = GetColorForScore(FinalScore);

            // Đặt màu cho điểm trung bình
            prgAverage.ProgressColor = GetColorForScore(AverageScore);
            prgAverage.ProgressColor2 = GetSecondaryColorForScore(AverageScore);
            lblAvgScore.ForeColor = GetColorForScore(AverageScore);
        }

        // Điều chỉnh phương thức GetColorForScore() để có thang màu phù hợp với điểm số
        private Color GetColorForScore(float score)
        {
            // Áp dụng thang màu dựa trên điểm số rõ ràng hơn
            if (score >= 8.5f)
                return Color.FromArgb(0, 180, 60);  // Xanh lá đậm - điểm xuất sắc
            else if (score >= 7.0f)
                return Color.FromArgb(90, 180, 100); // Xanh lá - điểm khá giỏi
            else if (score >= 5.0f)
                return Color.FromArgb(240, 180, 0);  // Vàng cam - điểm trung bình
            else if (score >= 3.5f)
                return Color.FromArgb(255, 140, 0);  // Cam - điểm yếu
            else if (score > 0)
                return Color.FromArgb(220, 53, 69);  // Đỏ - điểm kém
            else
                return Color.FromArgb(180, 180, 180); // Xám - chưa có điểm
        }

        private Color GetSecondaryColorForScore(float score)
        {
            Color primary = GetColorForScore(score);
            return Color.FromArgb(
                primary.A,
                Math.Min(primary.R + 30, 255),
                Math.Min(primary.G + 30, 255),
                Math.Min(primary.B + 30, 255)
            );
        }

        private void BtnDetails_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có dữ liệu gì cả
            if (AssignmentScore == 0 && MidtermScores.Count == 0 && FinalScore == 0)
            {
                MessageBox.Show("Chưa có dữ liệu điểm số cho môn học này.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder scoreDetails = new StringBuilder();
            scoreDetails.AppendLine($"Chi tiết điểm môn {SubjectName}:");
            scoreDetails.AppendLine($"- Điểm thường xuyên: {AssignmentScore}");

            // Hiển thị chi tiết từng điểm 15 phút
            scoreDetails.AppendLine($"- Điểm 15 phút:");
            if (_midtermScores != null && _midtermScores.Count > 0)
            {
                for (int i = 0; i < _midtermScores.Count; i++)
                {
                    scoreDetails.AppendLine($"  + Lần {i + 1}: {_midtermScores[i]}");
                }
                scoreDetails.AppendLine($"  => Trung bình: {MidtermAvgScore:0.0}");
            }
            else
            {
                scoreDetails.AppendLine("  (Chưa có điểm)");
            }

            scoreDetails.AppendLine($"- Điểm cuối kỳ: {FinalScore}");
            scoreDetails.AppendLine($"- Điểm trung bình: {AverageScore}");

            MessageBox.Show(scoreDetails.ToString(), "Chi tiết điểm số",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Use this method to set a color theme for the subject
        public void SetSubjectColor(Color primaryColor, Color secondaryColor)
        {
            prgAverage.ProgressColor = primaryColor;
            prgAverage.ProgressColor2 = secondaryColor;
        }

        // Automatically set color based on subject name
        public void AutoSetColor()
        {
            // Nếu tên môn học trống, sử dụng màu mặc định
            if (string.IsNullOrEmpty(SubjectName))
            {
                SetSubjectColor(Color.FromArgb(94, 148, 255), Color.FromArgb(120, 170, 255));
                return;
            }

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

        /// <summary>
        /// Đặt lại toàn bộ dữ liệu về giá trị mặc định
        /// </summary>
        public void Reset()
        {
            // Đặt lại các giá trị về mặc định
            SubjectName = "";
            AssignmentScore = 0;
            MidtermScores = new List<float>();
            FinalScore = 0;
            TeacherComment = "";

            // Cập nhật giao diện
            UpdateProgressBarsDisplay();
        }

        // Thêm phương thức để lấy kích thước lý tưởng của control
        public Size GetIdealSize()
        {
            return new Size(this.Width, 344); // Giữ nguyên chiều cao, chiều rộng có thể thay đổi
        }
        // Thêm phương thức này sau phương thức Reset()
        public void FixProgressBars()
        {
            // Đảm bảo tất cả progress bar có Maximum = 100
            prgAssignment.Maximum = 100;
            prgMidtermExam.Maximum = 100;
            prgFinalExam.Maximum = 100;
            prgAverage.Maximum = 100;

            // Cập nhật lại giá trị của các progress bar
            prgAssignment.Value = Math.Min((int)(_assignmentScore * 10), 100);
            prgMidtermExam.Value = Math.Min((int)(_midtermAvgScore * 10), 100);
            prgFinalExam.Value = Math.Min((int)(_finalScore * 10), 100);
            prgAverage.Value = Math.Min((int)(_averageScore * 10), 100);
        }
    }
}
