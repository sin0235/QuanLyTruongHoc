using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.GUI.Controls;
using QuanLyTruongHoc.GUI.Controls.ucGiaoVien;

namespace QuanLyTruongHoc
{

    //Sửa quan trọng trong database: 
    //Thêm cho GiaoVien thuộc tính NgaySinh(DATE)
    //Thêm DiaChi(NVARCHAR(100)) vào bảng GiaoVien
    public partial class frmGV : Form
    {
        private Color closeButtonColor = Color.FromArgb(255, 96, 92); // #FF605C
        private Color maximizeButtonColor = Color.FromArgb(255, 189, 68); // #FFBD44
        private Color minimizeButtonColor = Color.FromArgb(0, 202, 78); // #00CA4E

        private int maNguoiDung; // Lưu mã người dùng
        private string hoTen; // Lưu họ tên giáo viên
        private readonly DatabaseHelper db; // Đối tượng truy cập cơ sở dữ liệu

        public frmGV(int maNguoiDung)
        {
            InitializeComponent();

            this.maNguoiDung = maNguoiDung;
            db = new DatabaseHelper();

            // Load and display the teacher's name
            LoadUserName(maNguoiDung);

            // Ensure buttons are within the Guna2Panel
            guna2CircleButtonClose.Parent = pnlTitleBar;
            guna2CircleButtonMinimize.Parent = pnlTitleBar;
            guna2CircleButtonMaximize.Parent = pnlTitleBar;

            // Assign initial colors to buttons
            guna2CircleButtonClose.FillColor = closeButtonColor;
            guna2CircleButtonMinimize.FillColor = minimizeButtonColor;
            guna2CircleButtonMaximize.FillColor = maximizeButtonColor;

            // Ensure buttons are visible
            guna2CircleButtonClose.Visible = true;
            guna2CircleButtonMinimize.Visible = true;
            guna2CircleButtonMaximize.Visible = true;

            // Update button positions when the form is initialized
            UpdateButtonPositions();


            // Register Resize event
            this.Resize += new EventHandler(Form1_Resize);

            LoadThongBao();
            lblPageTitle.Text = "Thông báo";

        }

        private void LoadUserName(int maNguoiDung)
        {
            try
            {
                // Query to get the user's name
                string query = $@"
            SELECT GiaoVien.HoTen
            FROM GiaoVien
            WHERE GiaoVien.MaNguoiDung = {maNguoiDung}"; // Directly inject maNguoiDung

                // Execute the query using DatabaseHelper
                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    // Retrieve and display the user's name
                    hoTen = dt.Rows[0]["HoTen"].ToString();
                    lblUserName.Text = $"{hoTen}";
                }
                else
                {
                    lblUserName.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void pnlTitleBar_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Add custom painting logic here if needed
            // For now, this method can remain empty if no custom painting is required
        }

        private void guna2PanelTitleBar_MouseUp(object sender, EventArgs e)
        {
            isDragging = false;
        }

        private void ucThongBaoGiaoVien1_Load(object sender, EventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void thongBaoBtn_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Thông báo";
            LoadThongBao();
        }
        private void LoadThongBao()
        {
            pnlContent.Controls.Clear();
            // Mở ucXemThongBao ở pnlContent
            ucXemThongBao uc = new ucXemThongBao();
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc); // Thêm ucXemThongBao vào pnlContent
            uc.BringToFront();
        }

        private void thongTinCaNhanBtn_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Thông tin cá nhân";
            pnlContent.Controls.Clear();
            ucThongTinCaNhan uc = new ucThongTinCaNhan();
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
            uc.LoadThongTinCaNhan(maNguoiDung);

        }

        private void lichDayBtn_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Lịch dạy";
            pnlContent.Controls.Clear();
            ucThoiKhoaBieu uc = new ucThoiKhoaBieu();
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
            uc.LoadLichDay(maNguoiDung);
        }


        private void keHoachGiangDayBtn_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Kế hoạch giảng dạy";
            pnlContent.Controls.Clear();
            ucQuanLyKeHoachGiangDay uc = new ucQuanLyKeHoachGiangDay(GetMaGiaoVien(maNguoiDung));
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void quanLyDiemSoBtn_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Quản lý điểm số";
            pnlContent.Controls.Clear();
            ucQuanLyDiemSo uc = new ucQuanLyDiemSo(maNguoiDung, GetMaGiaoVien(maNguoiDung));
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void quanLyLopBtn_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Quản lý lớp";
            pnlContent.Controls.Clear();
            // Retrieve the teacher's ID (MaGV)
            int maGVChuNhiem = GetMaGiaoVien(maNguoiDung);
            ucQuanLyLop_GVCN uc = new ucQuanLyLop_GVCN(maGVChuNhiem);
            uc.Dock = DockStyle.None;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private int GetMaGiaoVien(int maNguoiDung)
        {
            string query = $@"
            SELECT MaGV
            FROM GiaoVien
            WHERE MaNguoiDung = {maNguoiDung}";
            object result = db.ExecuteScalar(query);
            return Convert.ToInt32(result);

        }

    }
}
