using QuanLyTruongHoc.DAL;
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
        // Object để gọi các phương thức thao tác với CSDL
        private ThongBaoDAL thongBaoDAL;
        // Thông tin người dùng hiện tại
        private int maNguoiDung;
        private int maVaiTro;
        private int? maLop;

        public ucThongBao(int ID)
        {
            InitializeComponent();
            thongBaoDAL = new ThongBaoDAL();
            maNguoiDung = ID;

        }


        private void ucThongBao_Load(object sender, EventArgs e)
        {
            // Thay thế dữ liệu mẫu bằng dữ liệu từ CSDL
            LoadDataFromDatabase();

            // Hiển thị thông báo chung ban đầu
            DisplayCommonNotifications();
        }

        /// <summary>
        /// Tải dữ liệu thông báo từ cơ sở dữ liệu
        /// </summary>
        private void LoadDataFromDatabase()
        {
            allNotifications.Clear();
            commonNotifications.Clear();
            personalNotifications.Clear();

            try
            {
                // Nếu chưa khởi tạo thông tin người dùng, không thể tải dữ liệu
                if (maNguoiDung == 0)
                {
                    MessageBox.Show("Không thể tải thông báo vì chưa xác định được người dùng.");
                    return;
                }

                // Lấy tất cả thông báo mà người dùng có thể xem
                List<ThongBaoDTO> thongBaoList = thongBaoDAL.GetThongBaoForUser(maNguoiDung, maVaiTro, maLop);

                foreach (var thongBao in thongBaoList)
                {
                    // Tạo một NotificationItem mới cho mỗi thông báo
                    var notificationItem = new NotificationItem(
                        thongBao.MaTB,
                        thongBao.TieuDe,
                        thongBao.NguoiGui,
                        thongBao.Ngay,
                        thongBao.NoiDung,
                        null, // Hiện tại không có đường dẫn avatar
                        thongBao.DaDoc
                    );

                    // Phân loại thông báo là chung hay cá nhân dựa vào người nhận
                    if (thongBao.NguoiNhan.Contains("Cá nhân") || thongBao.NguoiNhan == maNguoiDung.ToString())
                    {
                        personalNotifications.Add(notificationItem);
                    }
                    else
                    {
                        commonNotifications.Add(notificationItem);
                    }

                    // Thêm vào danh sách tổng hợp
                    allNotifications.Add(notificationItem);
                }

                // Nếu không có thông báo, hiển thị thông báo trống
                if (allNotifications.Count == 0)
                {
                    pnlNoData.Visible = true;
                    lblNoData.Text = "Không có thông báo nào";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải thông báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị chi tiết thông báo khi người dùng nhấp vào một thông báo
        /// </summary>
        /// <param name="MaTB">ID của thông báo</param>
        /// <param name="NguoiGui">Tiêu đề thông báo</param>
        /// <param name="NguoiNhan">Người gửi thông báo</param>
        /// <param name="NgayGui">Ngày gửi thông báo</param>
        /// <param name="NoiDung">Nội dung thông báo</param>
        /// <param name="TieuDe">Tiêu đề thông báo</param>
        public void ShowNotificationDetails(int maTB, string tieuDe, string nguoiGui, DateTime date, string noiDung)
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
                tbChiTiet.OnClose += (s, e) =>
                {
                    // Khi đóng chi tiết, ẩn control chi tiết
                    tbChiTiet.Visible = false;
                   
                    flowLayoutPanel.Visible = currentVisibilityOfFlowPanel;
                    btnTBChung.Visible = true;
                    btnTBCaNhan.Visible = true;
                    txtSearch.Visible = true;
                    pnlNoData.Visible = currentVisibilityOfNoData;
                    guna2VSeparator1.Visible = true;
                    guna2VScrollBar1.Visible = true;

                    // Làm mới lại danh sách thông báo
                    LoadDataFromDatabase();

                    // Hiển thị đúng loại thông báo đang xem
                    if (isShowingCommonNotifications)
                        DisplayCommonNotifications();
                    else
                        DisplayPersonalNotifications();
                };

                // Thêm control chi tiết vào panel nội dung
                pnlContent.Controls.Add(tbChiTiet);
            }

            // Lấy thông tin chi tiết về thông báo từ CSDL
            ThongBaoDTO thongBaoDetails = thongBaoDAL.GetThongBaoById(maTB);
            string receiver = thongBaoDetails != null ? thongBaoDetails.NguoiNhan : "Không xác định";
            Image nguoiGuiAvatar = GetnguoiGuiAvatar(nguoiGui); // Lấy avatar người gửi
            List<ucTBChiTiet.AttachmentInfo> attachments = GetAttachmentsForNotification(maTB); // Lấy danh sách file đính kèm

            // Hiển thị chi tiết thông báo
            tbChiTiet.LoadThongBao(maTB, tieuDe, nguoiGui, receiver, date, noiDung, nguoiGuiAvatar, attachments);
            tbChiTiet.Visible = true;
            tbChiTiet.BringToFront();

            // Cập nhật trạng thái đã đọc trong CSDL (đây là mẫu, cần triển khai thêm)
            // UpdateReadStatus(maTB);
        }

        /// <summary>
        /// Lấy thông tin người nhận của thông báo
        /// </summary>
        /// <param name="maTB">ID của thông báo</param>
        /// <returns>Chuỗi mô tả người nhận</returns>
        private string GetReceiverForNotification(int maTB)
        {
            // Lấy thông tin chi tiết về thông báo từ CSDL
            ThongBaoDTO thongBao = thongBaoDAL.GetThongBaoById(maTB);
            if (thongBao != null)
            {
                return thongBao.NguoiNhan;
            }
            return "Không xác định";
        }

        /// <summary>
        /// Lấy ảnh đại diện của người gửi thông báo
        /// </summary>
        /// <param name="nguoiGui">Tên người gửi</param>
        /// <returns>Ảnh đại diện hoặc null nếu không có</returns>
        private Image GetnguoiGuiAvatar(string nguoiGui)
        {
            // Trong thực tế, sẽ truy vấn ảnh đại diện từ cơ sở dữ liệu
            // Hiện tại, trả về null (control có avatar mặc định)
            return null;
        }

        /// <summary>
        /// Lấy danh sách file đính kèm của thông báo
        /// </summary>
        /// <param name="maTB">ID của thông báo</param>
        /// <returns>Danh sách file đính kèm</returns>
        private List<ucTBChiTiet.AttachmentInfo> GetAttachmentsForNotification(int maTB)
        {
            // Trong thực tế, sẽ truy vấn danh sách file đính kèm từ cơ sở dữ liệu
            // Hiện tại, trả về danh sách rỗng
            return new List<ucTBChiTiet.AttachmentInfo>();
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

        /// <summary>
        /// Làm mới dữ liệu thông báo
        /// </summary>
        public void RefreshNotifications()
        {
            LoadDataFromDatabase();
            if (isShowingCommonNotifications)
                DisplayCommonNotifications();
            else
                DisplayPersonalNotifications();
        }
    }

}
