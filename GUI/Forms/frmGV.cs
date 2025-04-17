using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QuanLyTruongHoc
{
    public partial class frmGV : Form
    {
        // Lưu trữ màu gốc của các nút
        private Color closeButtonColor = Color.FromArgb(255, 96, 92); // #FF605C
        private Color maximizeButtonColor = Color.FromArgb(255, 189, 68); // #FFBD44
        private Color minimizeButtonColor = Color.FromArgb(0, 202, 78); // #00CA4E

        private int maNguoiDung; // Biến lưu trữ mã người dùng

        public frmGV(int maNguoiDung)
        {
            InitializeComponent();
            this.maNguoiDung = maNguoiDung; // Lưu mã người dùng
            LoadUserName(); // Gọi phương thức để tải tên giáo viên
        }

        public frmGV()
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
            this.Resize += new EventHandler(Form2_Resize);
            LoadUserName();
        }

        // Hàm cập nhật vị trí nút
        private void UpdateButtonPositions()
        {
            guna2CircleButtonMinimize.Location = new Point(pnlTitleBar.Width - 90, 5);
            guna2CircleButtonMaximize.Location = new Point(pnlTitleBar.Width - 60, 5);
            guna2CircleButtonClose.Location = new Point(pnlTitleBar.Width - 30, 5);
        }

        // Sự kiện Resize
        private void Form2_Resize(object sender, EventArgs e)
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
            Application.Exit();
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

        private void btnViewTimetable_Click(object sender, EventArgs e)
        {
            // Đặt trạng thái cho nút "Thời khóa biểu"
            SetActiveButton(btnViewTimetable);

            // Xóa các control hiện tại trong pnlContent
            pnlContent.Controls.Clear();

            // Tạo một instance của ucThoiKhoaBieu
            var timetableControl = new QuanLyTruongHoc.GUI.Controls.ucThoiKhoaBieu();

            // Đặt Dock để control chiếm toàn bộ panel
            timetableControl.Dock = DockStyle.Fill;

            // Thêm ucThoiKhoaBieu vào pnlContent
            pnlContent.Controls.Add(timetableControl);
        }



        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Đặt trạng thái cho nút "Thông báo"
            SetActiveButton(btnDashboard);

            // Xóa các control hiện tại trong pnlContent
            pnlContent.Controls.Clear();

            // Tạo một instance của ucThongBaoGiaoVien
            var notificationControl = new QuanLyTruongHoc.GUI.Controls.ucThongBaoGiaoVien();

            // Đặt Dock để control chiếm toàn bộ panel
            notificationControl.Dock = DockStyle.Fill;

            // Thêm ucThongBaoGiaoVien vào pnlContent
            pnlContent.Controls.Add(notificationControl);
        }

        private void SetActiveButton(Guna2Button activeButton)
        {
            // Đặt màu nền mặc định cho tất cả các nút
            foreach (Control control in pnlMenu.Controls)
            {
                if (control is Guna2Button button)
                {
                    button.FillColor = Color.Transparent; // Màu nền mặc định
                    button.ForeColor = Color.FromArgb(30, 55, 98); // Màu chữ mặc định
                }
            }

            // Đặt màu nền và màu chữ cho nút được chọn
            activeButton.FillColor = Color.FromArgb(157, 192, 239); // Màu nền khi được chọn
            activeButton.ForeColor = Color.White; // Màu chữ khi được chọn
        }
        private void LoadUserName()
        {
            try
            {
                // Tạo một instance của DatabaseHelper
                var dbHelper = new QuanLyTruongHoc.DAL.DatabaseHelper();

                // Truy vấn tên giáo viên
                string query = $@"
                    SELECT GiaoVien.HoTen
                    FROM GiaoVien
                    INNER JOIN NguoiDung ON GiaoVien.MaNguoiDung = NguoiDung.MaNguoiDung
                    WHERE NguoiDung.MaNguoiDung = {maNguoiDung}";

                // Thực hiện truy vấn
                DataTable result = dbHelper.ExecuteQuery(query);

                // Kiểm tra kết quả và gán tên giáo viên vào lblUserName
                if (result.Rows.Count > 0)
                {
                    lblUserName.Text = result.Rows[0]["HoTen"].ToString(); // Gán tên giáo viên
                }
                else
                {
                    lblUserName.Text = "Không tìm thấy tên giáo viên"; // Thông báo nếu không tìm thấy
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải tên giáo viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}