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
    public partial class ucControlBar : UserControl
    {
        private Color closeButtonColor = Color.FromArgb(255, 96, 92); // #FF605C
        private Color maximizeButtonColor = Color.FromArgb(255, 189, 68); // #FFBD44
        private Color minimizeButtonColor = Color.FromArgb(0, 202, 78); // #00CA4E

        // Để theo dõi trạng thái kéo thả
        private bool isDragging = false;
        private Point startPoint;

        /// <summary>
        /// Event được kích hoạt khi nút đóng được nhấn
        /// </summary>
        public event EventHandler CloseButtonClicked;

        /// <summary>
        /// Event được kích hoạt khi nút thu nhỏ được nhấn
        /// </summary>
        public event EventHandler MinimizeButtonClicked;

        /// <summary>
        /// Event được kích hoạt khi nút phóng to được nhấn
        /// </summary>
        public event EventHandler MaximizeButtonClicked;

        public ucControlBar()
        {
            InitializeComponent();

            // Thiết lập màu sắc ban đầu
            guna2CircleButtonClose.FillColor = closeButtonColor;
            guna2CircleButtonMinimize.FillColor = minimizeButtonColor;

            // Đăng ký sự kiện cho các nút
            guna2CircleButtonClose.Click += Guna2CircleButtonClose_Click;
            guna2CircleButtonMinimize.Click += Guna2CircleButtonMinimize_Click;

            // Đăng ký sự kiện kéo thả để di chuyển form
            pnlTitleBar.MouseDown += PnlTitleBar_MouseDown;
            pnlTitleBar.MouseMove += PnlTitleBar_MouseMove;
            pnlTitleBar.MouseUp += PnlTitleBar_MouseUp;

            // Thêm hiệu ứng hover cho các nút
            guna2CircleButtonClose.MouseEnter += Guna2CircleButtonClose_MouseEnter;
            guna2CircleButtonClose.MouseLeave += Guna2CircleButtonClose_MouseLeave;
            guna2CircleButtonMinimize.MouseEnter += Guna2CircleButtonMinimize_MouseEnter;
            guna2CircleButtonMinimize.MouseLeave += Guna2CircleButtonMinimize_MouseLeave;
        }

        // Thuộc tính để thay đổi tiêu đề của form
        public Guna.UI2.WinForms.Guna2HtmlLabel FormTitle
        {
            get { return lblFormTitle; }
            set { lblFormTitle = value; }
        }

        // Thuộc tính để đặt text cho tiêu đề
        public string TitleText
        {
            get { return lblFormTitle.Text; }
            set { lblFormTitle.Text = value; }
        }

        #region Xử lý sự kiện cho nút đóng
        private void Guna2CircleButtonClose_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện CloseButtonClicked nếu có đăng ký
            CloseButtonClicked?.Invoke(this, EventArgs.Empty);

            // Nếu không có đăng ký sự kiện, thì đóng form mặc định
            if (CloseButtonClicked == null && this.ParentForm != null)
            {
                this.ParentForm.Close();
            }
        }

        private void Guna2CircleButtonClose_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButtonClose.FillColor = LightenColor(closeButtonColor, 0.2f);
        }

        private void Guna2CircleButtonClose_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButtonClose.FillColor = closeButtonColor;
        }
        #endregion

        #region Xử lý sự kiện cho nút phóng to
        private void Guna2CircleButtonMaximize_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện MaximizeButtonClicked nếu có đăng ký
            MaximizeButtonClicked?.Invoke(this, EventArgs.Empty);

            // Nếu không có đăng ký sự kiện, thì thực hiện hành động mặc định
            if (MaximizeButtonClicked == null && this.ParentForm != null)
            {
                if (this.ParentForm.WindowState == FormWindowState.Normal)
                {
                    this.ParentForm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.ParentForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        #endregion

        #region Xử lý sự kiện cho nút thu nhỏ
        private void Guna2CircleButtonMinimize_Click(object sender, EventArgs e)
        {
            // Kích hoạt sự kiện MinimizeButtonClicked nếu có đăng ký
            MinimizeButtonClicked?.Invoke(this, EventArgs.Empty);

            // Nếu không có đăng ký sự kiện, thì thực hiện hành động mặc định
            if (MinimizeButtonClicked == null && this.ParentForm != null)
            {
                this.ParentForm.WindowState = FormWindowState.Minimized;
            }
        }

        private void Guna2CircleButtonMinimize_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButtonMinimize.FillColor = LightenColor(minimizeButtonColor, 0.2f);
        }

        private void Guna2CircleButtonMinimize_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButtonMinimize.FillColor = minimizeButtonColor;
        }
        #endregion

        #region Xử lý kéo thả form
        private void PnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void PnlTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && this.ParentForm != null)
            {
                Point p = this.ParentForm.PointToScreen(new Point(e.X + this.Location.X, e.Y + this.Location.Y));
                this.ParentForm.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void PnlTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        #endregion

        // Phương thức chung để làm sáng màu sắc cho hiệu ứng hover
        private Color LightenColor(Color color, float factor)
        {
            int r = (int)Math.Min(255, color.R + (255 - color.R) * factor);
            int g = (int)Math.Min(255, color.G + (255 - color.G) * factor);
            int b = (int)Math.Min(255, color.B + (255 - color.B) * factor);
            return Color.FromArgb(r, g, b);
        }

        // Phương thức để cập nhật vị trí của các nút điều khiển
        public void UpdateButtonPositions()
        {
            // Đảm bảo các nút nằm đúng vị trí khi form thay đổi kích thước
            guna2CircleButtonMinimize.Location = new Point(pnlTitleBar.Width - 90, 10);
            guna2CircleButtonClose.Location = new Point(pnlTitleBar.Width - 30, 10);
        }

        // Phương thức được gọi khi control được resize
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateButtonPositions();
        }
    }
}
