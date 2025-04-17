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
        private Guna.UI2.WinForms.Guna2Panel pnlDetails;

        public ucThongBaoGiaoVien()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

        }

        private void ucThongBaoGiaoVien_Load(object sender, EventArgs e)
        {
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
                  OR nd.MaVaiTro = 1";

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
                  AND nd.MaVaiTro != 1";

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
                DateTime ngayGui = Convert.ToDateTime(row["NgayGui"]);
                string nguoiGui = row["NguoiGui"].ToString();

                NotificationItem notificationItem = new NotificationItem(
                    maTB,
                    tieuDe,
                    nguoiGui,
                    ngayGui,
                    noiDung
                );

                notificationItem.Click += (s, e) =>
                {
                    ShowNotificationDetails(maTB, tieuDe, nguoiGui, ngayGui, noiDung);
                };

                flowLayoutPanel.Controls.Add(notificationItem);
            }
        }

        private void ShowNotificationDetails(int notificationId, string title, string sender, DateTime date, string content)
        {
            // Clear the details panel
            pnlDetails.Controls.Clear();

            // Create and load ucTBChiTiet
            var chiTiet = new ucTBChiTiet
            {
                Dock = DockStyle.Fill
            };

            string receiver = GetReceiverForNotification(notificationId);
            chiTiet.LoadThongBao(notificationId, title, sender, receiver, date, content);

            // Add ucTBChiTiet to pnlDetails
            pnlDetails.Controls.Add(chiTiet);

            // Show the details panel and hide the main list
            pnlDetails.Visible = true;
            flowLayoutPanel.Visible = false;

            // Add a "Back" button to return to the notification list
            var btnBack = new Button
            {
                Text = "Quay lại",
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.LightGray
            };

            btnBack.Click += (s, e) =>
            {
                pnlDetails.Visible = false;
                flowLayoutPanel.Visible = true;
            };

            pnlDetails.Controls.Add(btnBack);
            btnBack.BringToFront();
        }

        private string GetReceiverForNotification(int notificationId)
        {
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
        private void ucThongBao_Load(object sender, EventArgs e)
        {
            // Mặc định hiển thị thông báo chung khi User Control được load
            LoadThongBaoChung();
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
    }
}


