using Guna.UI2.WinForms;
using QuanLyTruongHoc.GUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmKiemTra : Form
    {
        // Danh sách các câu hỏi (có thể là trắc nghiệm hoặc tự luận)
        private List<UserControl> questionItems = new List<UserControl>();
        private int currentQuestionIndex = 0;
        private TimeSpan remainingTime = TimeSpan.FromMinutes(30); // Mặc định 30 phút
        private List<bool> answeredQuestions; // Theo dõi câu hỏi đã trả lời
        private List<bool> markedQuestions; // Theo dõi câu hỏi đã đánh dấu
        private List<Guna2Button> questionButtons = new List<Guna2Button>();

        private Timer animationTimer;
        private double opacity = 0;

        public frmKiemTra()
        {
            InitializeComponent();

            // Thiết lập hiệu ứng mở form
            this.Opacity = 0;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tạo timer cho hiệu ứng mở form
            animationTimer = new Timer();
            animationTimer.Interval = 15; // milliseconds
            animationTimer.Tick += AnimationTimer_Tick;

            // Đăng ký sự kiện
            this.Load += FrmKiemTra_Load;
            btnPrev.Click += BtnPrev_Click;
            btnNext.Click += BtnNext_Click;
            btnSubmit.Click += BtnSubmit_Click;
            chkMarkForReview.CheckedChanged += ChkMarkForReview_CheckedChanged;
            timer.Interval = 1000; // 1 giây
            timer.Tick += Timer_Tick;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            // Tăng dần opacity để tạo hiệu ứng fade-in
            opacity += 0.075;
            if (opacity >= 1)
            {
                this.Opacity = 1;
                animationTimer.Stop();
            }
            else
            {
                this.Opacity = opacity;
            }
        }

        private void FrmKiemTra_Load(object sender, EventArgs e)
        {
            // Bắt đầu hiệu ứng mở form
            animationTimer.Start();

            // Tạo các nút câu hỏi trong sidebar
            CreateQuestionButtons();

            // Hiển thị câu hỏi đầu tiên
            ShowQuestion(0);

            // Bắt đầu đếm thời gian
            timer.Start();
        }

        private void CreateQuestionButtons()
        {
            flowQuestionButtons.Controls.Clear();
            questionButtons.Clear();

            for (int i = 0; i < questionItems.Count; i++)
            {
                Guna2Button btnQuestion = new Guna2Button();
                btnQuestion.Text = (i + 1).ToString();
                btnQuestion.Width = 40;
                btnQuestion.Height = 40;
                btnQuestion.BorderRadius = 8;
                btnQuestion.FillColor = Color.FromArgb(240, 240, 240);
                btnQuestion.ForeColor = Color.Black;
                btnQuestion.Margin = new Padding(5);
                btnQuestion.Tag = i;

                btnQuestion.Click += (s, e) =>
                {
                    ShowQuestion((int)(s as Guna2Button).Tag);
                };

                flowQuestionButtons.Controls.Add(btnQuestion);
                questionButtons.Add(btnQuestion);
            }
        }

        private void UpdateQuestionButtonStyles()
        {
            for (int i = 0; i < questionButtons.Count; i++)
            {
                Guna2Button btn = questionButtons[i];

                // Kiểm tra xem câu hỏi đã được trả lời chưa
                if (answeredQuestions[i])
                {
                    btn.FillColor = Color.FromArgb(230, 245, 255);
                    btn.BorderColor = Color.FromArgb(0, 110, 220);
                    btn.BorderThickness = 1;
                }
                else
                {
                    btn.FillColor = Color.FromArgb(240, 240, 240);
                    btn.BorderThickness = 0;
                }

                // Kiểm tra xem câu hỏi đã được đánh dấu xem lại chưa
                if (markedQuestions[i])
                {
                    btn.BorderColor = Color.FromArgb(220, 180, 0);
                    btn.BorderThickness = 2;
                    btn.FillColor = Color.FromArgb(255, 248, 230);
                }

                // Nếu là câu hỏi hiện tại
                if (i == currentQuestionIndex)
                {
                    btn.FillColor = Color.FromArgb(0, 110, 220);
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.ForeColor = Color.Black;
                }
            }
        }

        private void ShowQuestion(int index)
        {
            if (index < 0 || index >= questionItems.Count)
                return;

            // Ẩn tất cả các câu hỏi
            foreach (UserControl question in questionItems)
            {
                question.Visible = false;
                if (pnlMain.Controls.Contains(question))
                    pnlMain.Controls.Remove(question);
            }

            // Hiển thị câu hỏi được chọn
            UserControl selectedQuestion = questionItems[index];
            pnlMain.Controls.Add(selectedQuestion);
            selectedQuestion.Visible = true;

            // Cập nhật chỉ số câu hỏi hiện tại
            currentQuestionIndex = index;

            // Cập nhật trạng thái checkbox đánh dấu xem lại
            chkMarkForReview.Checked = markedQuestions[currentQuestionIndex];

            // Cập nhật trạng thái các nút điều hướng
            btnPrev.Enabled = (index > 0);
            btnNext.Enabled = (index < questionItems.Count - 1);

            // Cập nhật kiểu dáng các nút câu hỏi
            UpdateQuestionButtonStyles();
        }

        private void UpdateTimerDisplay()
        {
            lblTimerValue.Text = string.Format("{0:00}:{1:00}:{2:00}",
                remainingTime.Hours, remainingTime.Minutes, remainingTime.Seconds);

            // Đổi màu khi thời gian sắp hết (dưới 5 phút)
            if (remainingTime.TotalMinutes < 5)
            {
                lblTimerValue.ForeColor = Color.FromArgb(220, 53, 69);
            }
        }

        private void UpdateProgressBar()
        {
            int answeredCount = 0;
            foreach (bool answered in answeredQuestions)
            {
                if (answered) answeredCount++;
            }

            progressExam.Value = answeredCount;
        }

        private void MarkQuestionAsAnswered(int questionIndex)
        {
            if (questionIndex >= 0 && questionIndex < answeredQuestions.Count)
            {
                answeredQuestions[questionIndex] = true;
                UpdateProgressBar();
                UpdateQuestionButtonStyles();
            }
        }

        #region Event Handlers

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                ShowQuestion(currentQuestionIndex - 1);
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex < questionItems.Count - 1)
            {
                ShowQuestion(currentQuestionIndex + 1);
            }
        }

        private void ChkMarkForReview_CheckedChanged(object sender, EventArgs e)
        {
            markedQuestions[currentQuestionIndex] = chkMarkForReview.Checked;
            UpdateQuestionButtonStyles();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));

            if (remainingTime.TotalSeconds <= 0)
            {
                // Hết thời gian
                timer.Stop();
                MessageBox.Show("Hết thời gian làm bài!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Có thể thêm code để tự động nộp bài
                return;
            }

            UpdateTimerDisplay();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn nộp bài không?",
                "Xác nhận nộp bài",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Dừng đồng hồ
                timer.Stop();

                // Code xử lý nộp bài tại đây
                MessageBox.Show("Bài làm của bạn đã được nộp thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đóng form
                this.Close();
            }
        }

        // Các sự kiện khác có thể thêm vào sau

        #endregion


        private void btnMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblQuestionMap_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }
    }
}
