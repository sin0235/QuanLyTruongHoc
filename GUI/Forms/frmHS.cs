using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QuanLyTruongHoc
{
    public partial class frmHS : Form
    {
        // Lưu trữ màu gốc của các nút
        private Color closeButtonColor = Color.FromArgb(255, 96, 92); // #FF605C
        private Color maximizeButtonColor = Color.FromArgb(255, 189, 68); // #FFBD44
        private Color minimizeButtonColor = Color.FromArgb(0, 202, 78); // #00CA4E
        private Color highlightColor  = Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));


        public frmHS()
        {
            InitializeComponent();

            // Đảm bảo các nút nằm trong Guna2Panel
            guna2CircleButtonClose.Parent = pnlTitleBar;
            guna2CircleButtonMinimize.Parent = pnlTitleBar;
            guna2CircleButtonMaximize.Parent = pnlTitleBar;

            // Gán màu ban đầu cho các nút
            guna2CircleButtonClose.FillColor = closeButtonColor;
            guna2CircleButtonMinimize.FillColor = minimizeButtonColor;
            guna2CircleButtonMaximize.FillColor = maximizeButtonColor;

            // Đảm bảo các nút hiển thị
            guna2CircleButtonClose.Visible = true;
            guna2CircleButtonMinimize.Visible = true;
            guna2CircleButtonMaximize.Visible = true;

            // Cập nhật vị trí nút ngay khi Form khởi tạo
            UpdateButtonPositions();

            // Đăng ký sự kiện Resize
            this.Resize += new EventHandler(Form1_Resize);
        }

        // Hàm cập nhật vị trí nút
        private void UpdateButtonPositions()
        {
            guna2CircleButtonMinimize.Location = new Point(pnlTitleBar.Width - 90, 5);
            guna2CircleButtonMaximize.Location = new Point(pnlTitleBar.Width - 60, 5);
            guna2CircleButtonClose.Location = new Point(pnlTitleBar.Width - 30, 5);
        }

        // Sự kiện Resize
        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdateButtonPositions();
        }

        // Hiệu ứng hover cho nút Close
        private void guna2CircleButtonClose_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButtonClose.FillColor = LightenColor(closeButtonColor, 0.2f);
        }

        private void guna2CircleButtonClose_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButtonClose.FillColor = closeButtonColor;
        }

        // Hiệu ứng hover cho nút Minimize
        private void guna2CircleButtonMinimize_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButtonMinimize.FillColor = LightenColor(minimizeButtonColor, 0.2f);
        }

        private void guna2CircleButtonMinimize_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButtonMinimize.FillColor = minimizeButtonColor;
        }

        // Hiệu ứng hover cho nút Maximize
        private void guna2CircleButtonMaximize_MouseEnter(object sender, EventArgs e)
        {
            guna2CircleButtonMaximize.FillColor = LightenColor(maximizeButtonColor, 0.2f);
        }

        private void guna2CircleButtonMaximize_MouseLeave(object sender, EventArgs e)
        {
            guna2CircleButtonMaximize.FillColor = maximizeButtonColor;
        }

        // Hàm làm sáng màu
        private Color LightenColor(Color color, float factor)
        {
            int r = (int)Math.Min(255, color.R + (255 - color.R) * factor);
            int g = (int)Math.Min(255, color.G + (255 - color.G) * factor);
            int b = (int)Math.Min(255, color.B + (255 - color.B) * factor);
            return Color.FromArgb(r, g, b);
        }

        // Các sự kiện điều khiển nút
        private void guna2CircleButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2CircleButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CircleButtonMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        // Di chuyển Form bằng Guna2Panel
        private bool isDragging = false;
        private Point startPoint;

        private void guna2PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void guna2PanelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void guna2PanelTitleBar_MouseUp(object sender, EventArgs e)
        {
            isDragging = false;
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {

            btnInfo.FillColor = highlightColor;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void unLightButton()
        {


        }
        // Sửa phương thức btnSettings_Click
        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlSubSettings.Visible = !pnlSubSettings.Visible;

            // Cập nhật vị trí của panel tương đối so với nút btnSettings
            pnlSubSettings.Location = new Point(btnSettings.Location.X, btnSettings.Location.Y - pnlSubSettings.Height);

            // Thay đổi màu nút "Cài đặt" khi panel hiển thị
            btnSettings.FillColor = pnlSubSettings.Visible ? highlightColor : Color.Transparent;

            // Đảm bảo panel hiển thị trên cùng
            pnlSubSettings.BringToFront();
        }

        // Xử lý các nút trong menu cài đặt
        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Xử lý xem hồ sơ học sinh
            pnlSubSettings.Visible = false;
            btnSettings.FillColor = Color.Transparent;
            
            lblPageTitle.Text = "Hồ sơ học sinh";
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Xử lý đổi mật khẩu
            pnlSubSettings.Visible = false;
            btnSettings.FillColor = Color.Transparent;

            // Hiển thị giao diện đổi mật khẩu (tạm thời hiển thị control có sẵn)
            
            lblPageTitle.Text = "Đổi mật khẩu";
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                                                 "Xác nhận đăng xuất",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Tạo và hiển thị form đăng nhập
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                // Đóng form hiện tại
                this.Hide(); // Ẩn form hiện tại thay vì đóng để tránh đóng ứng dụng

                // Đăng ký sự kiện FormClosed cho form đăng nhập
                loginForm.FormClosed += (s, args) =>
                {
                    // Nếu form đăng nhập đóng (không đăng nhập thành công), thoát ứng dụng
                    this.Close();
                };
            }
        }

    }
}