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
    public partial class ucThongBao : UserControl
    {
        private List<NotificationItem> allNotifications = new List<NotificationItem>();
        private List<NotificationItem> commonNotifications = new List<NotificationItem>();
        private List<NotificationItem> personalNotifications = new List<NotificationItem>();
        private bool isShowingCommonNotifications = true;
        private ucTBChiTiet tbChiTiet;

        public ucThongBao()
        {
            InitializeComponent();
        }

        private void ucThongBao_Load(object sender, EventArgs e)
        {
            // Tạo dữ liệu mẫu (sau này sẽ thay thế bằng dữ liệu từ CSDL)
            CreateSampleData();

            // Hiển thị thông báo chung ban đầu
            DisplayCommonNotifications();
        }

        public void ShowNotificationDetails(int notificationId, string title, string sender, DateTime date, string content)
        {
            // Store the current visibility state of controls
            bool currentVisibilityOfFlowPanel = flowLayoutPanel.Visible;
            bool currentVisibilityOfNoData = pnlNoData.Visible;

            // Hide all notification list controls
            flowLayoutPanel.Visible = false;
            btnTBChung.Visible = false;
            btnTBCaNhan.Visible = false;
            txtSearch.Visible = false;
            pnlNoData.Visible = false;
            guna2VSeparator1.Visible = false;
            guna2VScrollBar1.Visible = false;

            // Create or reuse ucTBChiTiet
            if (tbChiTiet == null)
            {
                tbChiTiet = new ucTBChiTiet();
                tbChiTiet.Dock = DockStyle.Fill;
                tbChiTiet.OnClose += (s, e) => {
                    // When detail view is closed, restore the original notification panel
                    tbChiTiet.Visible = false;
                    
                    // Restore all notification list controls to their previous state
                    flowLayoutPanel.Visible = currentVisibilityOfFlowPanel;
                    btnTBChung.Visible = true;
                    btnTBCaNhan.Visible = true;
                    txtSearch.Visible = true;
                    pnlNoData.Visible = currentVisibilityOfNoData;
                    guna2VSeparator1.Visible = true;
                    guna2VScrollBar1.Visible = true;

                    // Refresh notification list if needed
                    if (isShowingCommonNotifications)
                        DisplayCommonNotifications();
                    else
                        DisplayPersonalNotifications();
                };

                pnlContent.Controls.Add(tbChiTiet);
            }

            // Load notification data
            // In a real application, you would fetch the detailed content from a database
            string receiver = GetReceiverForNotification(notificationId); // Replace with actual implementation
            Image senderAvatar = GetSenderAvatar(sender); // Replace with actual implementation
            List<ucTBChiTiet.AttachmentInfo> attachments = GetAttachmentsForNotification(notificationId); // Replace with actual implementation

            // Show notification details
            tbChiTiet.LoadThongBao(notificationId, title, sender, receiver, date, content, senderAvatar, attachments);
            tbChiTiet.Visible = true;
            tbChiTiet.BringToFront();
        }

        // Helper methods to get notification data (in a real app, these would fetch data from a database)
        private string GetReceiverForNotification(int notificationId)
        {
            // This would fetch the actual receiver information from database
            // For now, we're using sample data
            if (isShowingCommonNotifications)
            {
                return "Tất cả học sinh";
            }
            else
            {
                return "Nguyễn Văn A"; // Example personal notification receiver
            }
        }

        private Image GetSenderAvatar(string sender)
        {
            // This would fetch the actual sender avatar from database
            // For now, return null (the control has a default avatar)
            return null;
        }

        private List<ucTBChiTiet.AttachmentInfo> GetAttachmentsForNotification(int notificationId)
        {
            // This would fetch actual attachments from database
            // For demo purposes, we'll create sample attachments for certain notifications
            List<ucTBChiTiet.AttachmentInfo> attachments = new List<ucTBChiTiet.AttachmentInfo>();
            
            if (notificationId == 2) // Example: notification with ID 2 has attachments
            {
                attachments.Add(new ucTBChiTiet.AttachmentInfo 
                { 
                    FileName = "ke-hoach-thi-hk1.pdf", 
                    FilePath = @"C:\sample\ke-hoach-thi-hk1.pdf", 
                    FileSize = 1024 * 1024 
                });
                
                attachments.Add(new ucTBChiTiet.AttachmentInfo 
                { 
                    FileName = "lich-thi-chi-tiet.xlsx", 
                    FilePath = @"C:\sample\lich-thi-chi-tiet.xlsx", 
                    FileSize = 512 * 1024 
                });
            }
            
            return attachments;
        }

        private void CreateSampleData()
        {
            // Thông báo chung
            commonNotifications.Add(new NotificationItem(
                1,
                "Thông báo lịch nghỉ Tết Nguyên Đán năm 2023",
                "Ban Giám Hiệu",
                DateTime.Now.AddDays(-1),
                "Thông báo về lịch nghỉ Tết Nguyên Đán từ ngày 20/01/2023 đến hết ngày 29/01/2023...",
                null,
                false
            ));

            commonNotifications.Add(new NotificationItem(
                2,
                "Thông báo về kế hoạch thi học kỳ 1 năm học 2022-2023",
                "Phòng Đào Tạo",
                DateTime.Now.AddDays(-3),
                "Kế hoạch thi học kỳ 1 năm học 2022-2023 sẽ được tổ chức từ ngày 05/12/2022 đến ngày 15/12/2022...",
                null,
                true
            ));

            commonNotifications.Add(new NotificationItem(
                3,
                "Thông báo về việc tổ chức hội khỏe Phù Đổng cấp trường năm học 2022-2023",
                "Ban Thể Dục Thể Thao",
                DateTime.Now.AddDays(-5),
                "Hội khỏe Phù Đổng cấp trường sẽ được tổ chức từ ngày 15/11/2022 đến ngày 20/11/2022...",
                null,
                true
            ));

            // Thông báo cá nhân
            personalNotifications.Add(new NotificationItem(
                4,
                "Thông báo điểm kiểm tra môn Toán",
                "Thầy Nguyễn Văn A",
                DateTime.Now.AddHours(-5),
                "Điểm kiểm tra 1 tiết môn Toán của em đã được cập nhật lên hệ thống...",
                null,
                false
            ));

            personalNotifications.Add(new NotificationItem(
                5,
                "Thông báo về việc họp phụ huynh học sinh",
                "GVCN Nguyễn Thị B",
                DateTime.Now.AddDays(-2),
                "Nhà trường tổ chức họp phụ huynh học sinh vào ngày 25/11/2022...",
                null,
                false
            ));

            // Thêm tất cả thông báo vào danh sách chung
            allNotifications.AddRange(commonNotifications);
            allNotifications.AddRange(personalNotifications);
        }

        private void DisplayCommonNotifications()
        {
            flowLayoutPanel.Controls.Clear();
            isShowingCommonNotifications = true;

            if (commonNotifications.Count > 0)
            {
                foreach (var notification in commonNotifications)
                {
                    flowLayoutPanel.Controls.Add(notification);
                }
                pnlNoData.Visible = false;
            }
            else
            {
                pnlNoData.Visible = true;
                lblNoData.Text = "Không có thông báo chung nào";
            }
        }

        private void DisplayPersonalNotifications()
        {
            flowLayoutPanel.Controls.Clear();
            isShowingCommonNotifications = false;

            if (personalNotifications.Count > 0)
            {
                foreach (var notification in personalNotifications)
                {
                    flowLayoutPanel.Controls.Add(notification);
                }
                pnlNoData.Visible = false;
            }
            else
            {
                pnlNoData.Visible = true;
                lblNoData.Text = "Không có thông báo cá nhân nào";
            }
        }

        private void btnTBChung_Click(object sender, EventArgs e)
        {
            DisplayCommonNotifications();
        }

        private void btnTBCaNhan_Click(object sender, EventArgs e)
        {
            DisplayPersonalNotifications();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // Nếu không có từ khóa tìm kiếm, hiển thị lại danh sách ban đầu
                if (isShowingCommonNotifications)
                    DisplayCommonNotifications();
                else
                    DisplayPersonalNotifications();

                return;
            }

            flowLayoutPanel.Controls.Clear();

            List<NotificationItem> notificationsToSearch = isShowingCommonNotifications ?
                                                        commonNotifications :
                                                        personalNotifications;

            var filteredNotifications = notificationsToSearch.Where(n =>
                n.Controls.OfType<Label>().Any(lbl =>
                    lbl.Text.ToLower().Contains(searchText)
                )
            ).ToList();

            if (filteredNotifications.Count > 0)
            {
                foreach (var notification in filteredNotifications)
                {
                    flowLayoutPanel.Controls.Add(notification);
                }
                pnlNoData.Visible = false;
            }
            else
            {
                pnlNoData.Visible = true;
                lblNoData.Text = $"Không tìm thấy thông báo nào với từ khóa \"{searchText}\"";
            }
        }
    }

}
