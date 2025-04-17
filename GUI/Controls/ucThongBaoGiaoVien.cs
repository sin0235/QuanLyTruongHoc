using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucThongBaoGiaoVien : UserControl
    {
        private readonly DatabaseHelper dbHelper;
        private ucThongBao ucThongBaoInstance;

        public ucThongBaoGiaoVien()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(); // Khởi tạo DatabaseHelper
        }

        private void ucThongBaoGiaoVien_Load(object sender, EventArgs e)
        {
            // Mặc định hiển thị thông báo chung khi User Control được load
            LoadThongBaoChung();
        }

        private void btnTBChung_Click(object sender, EventArgs e)
        {
            LoadThongBaoChung();
        }

        private void btnTBCaNhan_Click(object sender, EventArgs e)
        {
            LoadThongBaoCaNhan();
        }

        private void LoadThongBaoChung()
        {
            string query = @"
            SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, nd.TenDangNhap AS NguoiGui
            FROM ThongBao tb
            INNER JOIN NguoiDung nd ON tb.MaNguoiGui = nd.MaNguoiDung
            WHERE (tb.MaVaiTroNhan IS NULL AND tb.MaNguoiNhan IS NULL)
                  OR nd.MaVaiTro = 1"; // Thông báo từ BGH cũng được xem là thông báo chung

            DataTable dataTable = dbHelper.ExecuteQuery(query);
            DisplayThongBao(dataTable);
        }

        private void LoadThongBaoCaNhan()
        {
            string query = @"
                SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, nd.TenDangNhap AS NguoiGui
                FROM ThongBao tb
                INNER JOIN NguoiDung nd ON tb.MaNguoiGui = nd.MaNguoiDung
                WHERE (tb.MaVaiTroNhan = 2 OR tb.MaVaiTroNhan = 3 OR tb.MaNguoiNhan IS NOT NULL)
                      AND nd.MaVaiTro != 1"; // Loại bỏ thông báo từ BGH

            DataTable dataTable = dbHelper.ExecuteQuery(query);
            DisplayThongBao(dataTable);
        }

        private void DisplayThongBao(DataTable dataTable)
        {
            flowLayoutPanel.Controls.Clear();

            if (dataTable.Rows.Count == 0)
            {
                pnlNoData.Visible = true;
                lblNoData.Text = "Không có thông báo nào";
                return;
            }

            pnlNoData.Visible = false;

            foreach (DataRow row in dataTable.Rows)
            {
                int maTB = Convert.ToInt32(row["MaTB"]);
                string tieuDe = row["TieuDe"].ToString();
                string noiDung = row["NoiDung"].ToString();
                string ngayGui = Convert.ToDateTime(row["NgayGui"]).ToString("dd/MM/yyyy HH:mm");
                string nguoiGui = row["NguoiGui"].ToString();

                // Tạo một NotificationItem
                NotificationItem notificationItem = new NotificationItem(
                    maTB,
                    tieuDe,
                    nguoiGui,
                    Convert.ToDateTime(row["NgayGui"]),
                    noiDung
                );

                // Gán sự kiện click để hiển thị chi tiết thông báo
                notificationItem.Click += (s, e) => ShowNotificationDetails(maTB, tieuDe, nguoiGui, Convert.ToDateTime(row["NgayGui"]), noiDung);

                // Thêm NotificationItem vào flowLayoutPanel
                flowLayoutPanel.Controls.Add(notificationItem);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                // Nếu không có nội dung tìm kiếm, hiển thị lại thông báo chung
                LoadThongBaoChung();
                return;
            }

            // Tìm kiếm thông báo theo tiêu đề hoặc nội dung
            string query = $@"
                SELECT tb.MaTB, tb.TieuDe, tb.NoiDung, tb.NgayGui, nd.TenDangNhap AS NguoiGui
                FROM ThongBao tb
                INNER JOIN NguoiDung nd ON tb.MaNguoiGui = nd.MaNguoiDung
                WHERE tb.TieuDe LIKE N'%{searchText}%' OR tb.NoiDung LIKE N'%{searchText}%'";

            DataTable dataTable = dbHelper.ExecuteQuery(query);
            DisplayThongBao(dataTable);
        }

        private void ucThongBao_Load(object sender, EventArgs e)
        {
            // Mặc định hiển thị thông báo chung khi User Control được load
            LoadThongBaoChung();
        }
        private string GetReceiverForNotification(int notificationId)
        {
            // Logic để lấy thông tin người nhận từ cơ sở dữ liệu
            // Ví dụ: Nếu thông báo là chung, trả về "Tất cả"; nếu là cá nhân, trả về tên người nhận
            string query = $@"
                SELECT 
                    CASE 
                        WHEN tb.MaNguoiNhan IS NOT NULL THEN nd.TenDangNhap
                        WHEN tb.MaVaiTroNhan = 2 THEN N'Tất cả giáo viên'
                        WHEN tb.MaVaiTroNhan = 3 THEN N'Tất cả học sinh'
                        ELSE N'Tất cả'
                    END AS Receiver
                FROM ThongBao tb
                LEFT JOIN NguoiDung nd ON tb.MaNguoiNhan = nd.MaNguoiDung
                WHERE tb.MaTB = {notificationId}";

            DataTable result = dbHelper.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["Receiver"].ToString();
            }

            return "Không xác định";
        }

        private void ShowNotificationDetails(int notificationId, string title, string sender, DateTime date, string content)
        {
            var chiTiet = new ucTBChiTiet();

            var form = new Form
            {
                Text = "Chi tiết thông báo",
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            chiTiet.Dock = DockStyle.Fill;
            form.Controls.Add(chiTiet);

            // Load dữ liệu ngay sau khi control đã được add
            string receiver = GetReceiverForNotification(notificationId); // Giả sử bạn đã có hàm này
            chiTiet.LoadThongBao(notificationId, title, sender, receiver, date, content);

            // Ép render UI
            Application.DoEvents();

            // Gán nút đóng
            chiTiet.OnClose += (s, e) => form.Close();

            form.ShowDialog();
        }


    }
}

