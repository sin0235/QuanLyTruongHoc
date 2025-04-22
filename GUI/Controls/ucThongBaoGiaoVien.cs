using QuanLyTruongHoc.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucThongBaoGiaoVien : UserControl
    {
        private int maNguoiNhan; // Added to store the user ID
        private int maVaiTroNhan; // Already present

        public ucThongBaoGiaoVien(int maNguoiNhan)
        {
            InitializeComponent();

            this.maNguoiNhan = maNguoiNhan; // Initialize maNguoiNhan with the provided value

            // Retrieve maVaiTroNhan from the database
            var dbHelper = new QuanLyTruongHoc.DAL.DatabaseHelper();
            string query = $@"
                SELECT MaVaiTro
                FROM NguoiDung
                WHERE MaNguoiDung = {maNguoiNhan}"; // Updated to use MaNguoiDung

            DataTable result = dbHelper.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                maVaiTroNhan = Convert.ToInt32(result.Rows[0]["MaVaiTro"]);
            }
            else
            {
                MessageBox.Show("Không tìm thấy vai trò của người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadNotifications()
        {
            try
            {
                // Tạo instance của DatabaseHelper
                var dbHelper = new QuanLyTruongHoc.DAL.DatabaseHelper();

                // Lấy danh sách thông báo từ cơ sở dữ liệu
                var notifications = dbHelper.GetNotifications(maNguoiNhan, maVaiTroNhan);

                // Xóa các thông báo cũ
                tbChungPanel.Controls.Clear();

                // Hiển thị từng thông báo
                foreach (var notification in notifications)
                {
                    // Retrieve sender's name
                    string senderName = GetSenderName(notification.MaTB, dbHelper);

                    var notificationItem = new NotificationItem(
                        notification.MaTB,
                        notification.Title,
                        senderName, // Display sender's name
                        notification.Date,
                        notification.Content,
                        null, // Avatar path (nếu có)
                        false // Trạng thái đã đọc
                    );

                    // Thêm sự kiện click để xem chi tiết
                    notificationItem.Click += (s, e) =>
                    {
                        ShowNotificationDetails(notification, senderName);
                    };

                    tbChungPanel.Controls.Add(notificationItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSenderName(int maTB, QuanLyTruongHoc.DAL.DatabaseHelper dbHelper)
        {
            string query = $@"
        SELECT 
            CASE 
                WHEN GV.HoTen IS NOT NULL THEN GV.HoTen
                WHEN HS.HoTen IS NOT NULL THEN HS.HoTen
                ELSE 'Ban Giám Hiệu'
            END AS NguoiGui
        FROM ThongBao TB
        LEFT JOIN NguoiDung ND ON TB.MaNguoiGui = ND.MaNguoiDung
        LEFT JOIN GiaoVien GV ON ND.MaNguoiDung = GV.MaNguoiDung
        LEFT JOIN HocSinh HS ON ND.MaNguoiDung = HS.MaNguoiDung
        WHERE TB.MaTB = {maTB}";

            DataTable result = dbHelper.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["NguoiGui"].ToString();
            }

            return "Không xác định"; // Default if sender's name is not found
        }


        private void ShowNotificationDetails(Notification notification, string senderName)
        {
            var detailControl = new ucTBChiTiet
            {
                Dock = DockStyle.Fill
            };

            detailControl.LoadThongBao(
                notification.MaTB,
                notification.Title,
                senderName, // Display sender's name
                "Giáo viên", // Thay bằng tên người nhận nếu cần
                notification.Date,
                notification.Content
            );

            tbChungPanel.Controls.Clear();
            tbChungPanel.Controls.Add(detailControl);
        }

        private void ucThongBaoGiaoVien_Load(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void lamMoiTBBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Reload notifications
                LoadNotifications();
                MessageBox.Show("Bảng thông báo đã được làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới bảng thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
