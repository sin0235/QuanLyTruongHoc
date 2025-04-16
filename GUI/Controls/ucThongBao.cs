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
        // Danh sách lưu trữ tất cả các thông báo
        private List<NotificationItem> allNotifications = new List<NotificationItem>();
        // Danh sách lưu trữ các thông báo chung
        private List<NotificationItem> commonNotifications = new List<NotificationItem>();
        // Danh sách lưu trữ các thông báo cá nhân
        private List<NotificationItem> personalNotifications = new List<NotificationItem>();
        // Biến đánh dấu đang hiển thị thông báo chung hay cá nhân
        private bool isShowingCommonNotifications = true;
        // Control hiển thị chi tiết thông báo
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

        /// <summary>
        /// Hiển thị chi tiết thông báo khi người dùng nhấp vào một thông báo
        /// </summary>
        /// <param name="notificationId">ID của thông báo</param>
        /// <param name="title">Tiêu đề thông báo</param>
        /// <param name="sender">Người gửi thông báo</param>
        /// <param name="date">Ngày gửi thông báo</param>
        /// <param name="content">Nội dung thông báo</param>
        public void ShowNotificationDetails(int notificationId, string title, string sender, DateTime date, string content)
        {
            // Lưu trạng thái hiện tại của các điều khiển
            bool currentVisibilityOfFlowPanel = flowLayoutPanel.Visible;
            bool currentVisibilityOfNoData = pnlNoData.Visible;

            // Ẩn tất cả các điều khiển hiển thị danh sách thông báo
            flowLayoutPanel.Visible = false;
            btnTBChung.Visible = false;
            btnTBCaNhan.Visible = false;
            txtSearch.Visible = false;
            pnlNoData.Visible = false;
            guna2VSeparator1.Visible = false;
            guna2VScrollBar1.Visible = false;

            // Tạo mới hoặc tái sử dụng control chi tiết thông báo
            if (tbChiTiet == null)
            {
                tbChiTiet = new ucTBChiTiet();
                tbChiTiet.Dock = DockStyle.Fill;
                
                // Đăng ký sự kiện đóng chi tiết thông báo
                tbChiTiet.OnClose += (s, e) => {
                    // Khi đóng chi tiết, ẩn control chi tiết
                    tbChiTiet.Visible = false;
                    
                    // Khôi phục lại trạng thái hiển thị ban đầu của các điều khiển
                    flowLayoutPanel.Visible = currentVisibilityOfFlowPanel;
                    btnTBChung.Visible = true;
                    btnTBCaNhan.Visible = true;
                    txtSearch.Visible = true;
                    pnlNoData.Visible = currentVisibilityOfNoData;
                    guna2VSeparator1.Visible = true;
                    guna2VScrollBar1.Visible = true;

                    // Làm mới lại danh sách thông báo nếu cần
                    if (isShowingCommonNotifications)
                        DisplayCommonNotifications();
                    else
                        DisplayPersonalNotifications();
                };

                // Thêm control chi tiết vào panel nội dung
                pnlContent.Controls.Add(tbChiTiet);
            }

            // Lấy thông tin chi tiết về thông báo
            // Trong ứng dụng thực tế, sẽ lấy từ cơ sở dữ liệu
            string receiver = GetReceiverForNotification(notificationId); // Lấy thông tin người nhận
            Image senderAvatar = GetSenderAvatar(sender); // Lấy avatar người gửi
            List<ucTBChiTiet.AttachmentInfo> attachments = GetAttachmentsForNotification(notificationId); // Lấy danh sách file đính kèm

            // Hiển thị chi tiết thông báo
            tbChiTiet.LoadThongBao(notificationId, title, sender, receiver, date, content, senderAvatar, attachments);
            tbChiTiet.Visible = true;
            tbChiTiet.BringToFront();
        }

        /// <summary>
        /// Lấy thông tin người nhận của thông báo
        /// </summary>
        /// <param name="notificationId">ID của thông báo</param>
        /// <returns>Chuỗi mô tả người nhận</returns>
        private string GetReceiverForNotification(int notificationId)
        {
            // Trong thực tế, sẽ truy vấn thông tin người nhận từ cơ sở dữ liệu
            // Hiện tại, sử dụng dữ liệu mẫu
            if (isShowingCommonNotifications)
            {
                return "Tất cả học sinh";
            }
            else
            {
                return "Nguyễn Văn A"; // Người nhận mẫu cho thông báo cá nhân
            }
        }

        /// <summary>
        /// Lấy ảnh đại diện của người gửi thông báo
        /// </summary>
        /// <param name="sender">Tên người gửi</param>
        /// <returns>Ảnh đại diện hoặc null nếu không có</returns>
        private Image GetSenderAvatar(string sender)
        {
            // Trong thực tế, sẽ truy vấn ảnh đại diện từ cơ sở dữ liệu
            // Hiện tại, trả về null (control có avatar mặc định)
            return null;
        }

        /// <summary>
        /// Lấy danh sách file đính kèm của thông báo
        /// </summary>
        /// <param name="notificationId">ID của thông báo</param>
        /// <returns>Danh sách file đính kèm</returns>
        private List<ucTBChiTiet.AttachmentInfo> GetAttachmentsForNotification(int notificationId)
        {
            // Trong thực tế, sẽ truy vấn danh sách file đính kèm từ cơ sở dữ liệu
            // Hiện tại, tạo dữ liệu mẫu cho một số thông báo cụ thể
            List<ucTBChiTiet.AttachmentInfo> attachments = new List<ucTBChiTiet.AttachmentInfo>();
            
            if (notificationId == 2) // Ví dụ: thông báo có ID = 2 có file đính kèm
            {
                attachments.Add(new ucTBChiTiet.AttachmentInfo 
                { 
                    FileName = "ke-hoach-thi-hk1.pdf", 
                    FilePath = @"C:\sample\ke-hoach-thi-hk1.pdf", 
                    FileSize = 1024 * 1024 // Kích thước 1MB
                });
                
                attachments.Add(new ucTBChiTiet.AttachmentInfo 
                { 
                    FileName = "lich-thi-chi-tiet.xlsx", 
                    FilePath = @"C:\sample\lich-thi-chi-tiet.xlsx", 
                    FileSize = 512 * 1024 // Kích thước 512KB
                });
            }
            
            return attachments;
        }

        /// <summary>
        /// Tạo dữ liệu mẫu cho các thông báo
        /// </summary>
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

        /// <summary>
        /// Hiển thị danh sách thông báo chung
        /// </summary>
        private void DisplayCommonNotifications()
        {
            // Xóa các thông báo cũ trong panel hiển thị
            flowLayoutPanel.Controls.Clear();
            // Đánh dấu đang hiển thị thông báo chung
            isShowingCommonNotifications = true;

            if (commonNotifications.Count > 0)
            {
                // Thêm từng thông báo chung vào panel hiển thị
                foreach (var notification in commonNotifications)
                {
                    flowLayoutPanel.Controls.Add(notification);
                }
                // Ẩn panel "không có dữ liệu"
                pnlNoData.Visible = false;
            }
            else
            {
                // Hiển thị thông báo khi không có dữ liệu
                pnlNoData.Visible = true;
                lblNoData.Text = "Không có thông báo chung nào";
            }
        }

        /// <summary>
        /// Hiển thị danh sách thông báo cá nhân
        /// </summary>
        private void DisplayPersonalNotifications()
        {
            // Xóa các thông báo cũ trong panel hiển thị
            flowLayoutPanel.Controls.Clear();
            // Đánh dấu đang hiển thị thông báo cá nhân
            isShowingCommonNotifications = false;

            if (personalNotifications.Count > 0)
            {
                // Thêm từng thông báo cá nhân vào panel hiển thị
                foreach (var notification in personalNotifications)
                {
                    flowLayoutPanel.Controls.Add(notification);
                }
                // Ẩn panel "không có dữ liệu"
                pnlNoData.Visible = false;
            }
            else
            {
                // Hiển thị thông báo khi không có dữ liệu
                pnlNoData.Visible = true;
                lblNoData.Text = "Không có thông báo cá nhân nào";
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấp vào nút Thông báo chung
        /// </summary>
        private void btnTBChung_Click(object sender, EventArgs e)
        {
            DisplayCommonNotifications();
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấp vào nút Thông báo cá nhân
        /// </summary>
        private void btnTBCaNhan_Click(object sender, EventArgs e)
        {
            DisplayPersonalNotifications();
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhập từ khóa tìm kiếm
        /// </summary>
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

            // Xóa các thông báo cũ trong panel hiển thị
            flowLayoutPanel.Controls.Clear();

            // Xác định danh sách thông báo cần tìm kiếm (chung hoặc cá nhân)
            List<NotificationItem> notificationsToSearch = isShowingCommonNotifications ?
                                                        commonNotifications :
                                                        personalNotifications;

            // Lọc các thông báo theo từ khóa tìm kiếm
            var filteredNotifications = notificationsToSearch.Where(n =>
                n.Controls.OfType<Label>().Any(lbl =>
                    lbl.Text.ToLower().Contains(searchText)
                )
            ).ToList();

            if (filteredNotifications.Count > 0)
            {
                // Hiển thị các thông báo đã lọc
                foreach (var notification in filteredNotifications)
                {
                    flowLayoutPanel.Controls.Add(notification);
                }
                // Ẩn panel "không có dữ liệu"
                pnlNoData.Visible = false;
            }
            else
            {
                // Hiển thị thông báo khi không tìm thấy kết quả
                pnlNoData.Visible = true;
                lblNoData.Text = $"Không tìm thấy thông báo nào với từ khóa \"{searchText}\"";
            }
        }
    }
}
