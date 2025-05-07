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
    public partial class ucXinNghi : UserControl
    {
        private DatabaseHelper dbHelper;
        private int currentStudentId = -1;
        private string currentFilter = "all"; // all, approved, pending, rejected
        private string currentTimeFilter = "all"; // all, month, 6months, year
        private ucTaoDonXinNghi ucTaoDon;

        public ucXinNghi()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void ucXinNghi_Load(object sender, EventArgs e)
        {
            // Lấy ID học sinh hiện tại từ form đăng nhập
            //currentStudentId = QuanLyTruongHoc.frmLogin.LoggedInStudentId;

            //// Khởi tạo user control tạo đơn xin nghỉ
            //InitializeNewRequestForm();

            //// Mặc định hiển thị tất cả đơn xin nghỉ
            //LoadLeaveRequests();
        }

        private void InitializeNewRequestForm()
        {
            ucTaoDon = new ucTaoDonXinNghi();
            ucTaoDon.OnSubmitSuccess += UcTaoDon_OnSubmitSuccess;
            ucTaoDon.OnCancel += UcTaoDon_OnCancel;
            ucTaoDon.Dock = DockStyle.Fill;
            pnlTaoDonMoi.Controls.Add(ucTaoDon);
        }

        private void UcTaoDon_OnCancel(object sender, EventArgs e)
        {
            // Trở lại danh sách đơn
            SwitchToListView();
        }

        private void UcTaoDon_OnSubmitSuccess(object sender, EventArgs e)
        {
            // Trở lại danh sách đơn và làm mới
            SwitchToListView();
            LoadLeaveRequests();
        }

        private void SwitchToListView()
        {
            pnlTaoDonMoi.Visible = false;
            pnlDonXinNghi.Visible = true;
        }

        private void SwitchToCreateView()
        {
            pnlDonXinNghi.Visible = false;
            pnlTaoDonMoi.Visible = true;
        }

        private void LoadLeaveRequests()
        {
            // Xóa tất cả các đơn cũ trừ panel thông báo không có dữ liệu
            foreach (Control ctrl in pnlDonXinNghi.Controls)
            {
                if (ctrl != pnlNoData)
                    pnlDonXinNghi.Controls.Remove(ctrl);
            }

            try
            {
                // Thiết lập điều kiện lọc theo trạng thái
                string statusCondition = "";
                switch (currentFilter)
                {
                    case "approved":
                        statusCondition = "AND d.TrangThai = 1";
                        break;
                    case "pending":
                        statusCondition = "AND d.TrangThai = 0";
                        break;
                    case "rejected":
                        statusCondition = "AND d.TrangThai = 2";
                        break;
                }

                // Thiết lập điều kiện lọc theo thời gian
                string timeCondition = "";
                switch (currentTimeFilter)
                {
                    case "month":
                        timeCondition = "AND d.NgayTao >= DATEADD(month, -1, GETDATE())";
                        break;
                    case "6months":
                        timeCondition = "AND d.NgayTao >= DATEADD(month, -6, GETDATE())";
                        break;
                    case "year":
                        timeCondition = "AND d.NgayTao >= DATEADD(year, -1, GETDATE())";
                        break;
                }

                // Truy vấn danh sách đơn xin nghỉ học
                string query = $@"
                        SELECT 
                            d.MaDon, 
                            d.TieuDe, 
                            d.NoiDung, 
                            d.NgayBatDau, 
                            d.NgayKetThuc, 
                            d.NgayTao,
                            d.TrangThai,
                            d.PhanHoi,
                            gv.HoTen as NguoiDuyet
                        FROM DonXin d
                        LEFT JOIN GiaoVien gv ON d.MaGVDuyet = gv.MaGV
                        WHERE d.MaHS = {currentStudentId}
                        {statusCondition}
                        {timeCondition}
                        ORDER BY d.NgayTao DESC";

                DataTable data = dbHelper.ExecuteQuery(query);

                if (data != null && data.Rows.Count > 0)
                {
                    pnlNoData.Visible = false;

                    int yPos = 20;
                    foreach (DataRow row in data.Rows)
                    {
                        // Tạo đối tượng hiển thị đơn xin nghỉ
                        ucDonXinNghiItem donItem = new ucDonXinNghiItem();

                        // Thiết lập dữ liệu
                        donItem.MaDon = Convert.ToInt32(row["MaDon"]);
                        donItem.TieuDe = row["TieuDe"].ToString();
                        donItem.NoiDung = row["NoiDung"].ToString();
                        donItem.NgayBatDau = Convert.ToDateTime(row["NgayBatDau"]);
                        donItem.NgayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]);
                        donItem.NgayTao = Convert.ToDateTime(row["NgayTao"]);
                        donItem.TrangThai = Convert.ToInt32(row["TrangThai"]);
                        donItem.PhanHoi = row["PhanHoi"] == DBNull.Value ? "" : row["PhanHoi"].ToString();
                        donItem.NguoiDuyet = row["NguoiDuyet"] == DBNull.Value ? "" : row["NguoiDuyet"].ToString();

                        // Thiết lập vị trí và kích thước
                        donItem.Location = new Point(20, yPos);
                        donItem.Width = pnlDonXinNghi.Width - 60; // Trừ padding 2 bên
                        donItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                        // Thêm vào panel hiển thị
                        pnlDonXinNghi.Controls.Add(donItem);

                        // Cập nhật vị trí cho đơn tiếp theo
                        yPos += donItem.Height + 15;
                    }
                }
                else
                {
                    // Hiển thị thông báo không có đơn
                    pnlNoData.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đơn xin nghỉ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Event Handlers

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            SwitchToCreateView();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            SetActiveFilterButton(btnAll);
            currentFilter = "all";
            LoadLeaveRequests();
        }

        private void btnDaDuyet_Click(object sender, EventArgs e)
        {
            SetActiveFilterButton(btnDaDuyet);
            currentFilter = "approved";
            LoadLeaveRequests();
        }

        private void btnDangCho_Click(object sender, EventArgs e)
        {
            SetActiveFilterButton(btnDangCho);
            currentFilter = "pending";
            LoadLeaveRequests();
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            SetActiveFilterButton(btnTuChoi);
            currentFilter = "rejected";
            LoadLeaveRequests();
        }

        private void cboThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboThoiGian.SelectedIndex)
            {
                case 0:
                    currentTimeFilter = "all";
                    break;
                case 1:
                    currentTimeFilter = "month";
                    break;
                case 2:
                    currentTimeFilter = "6months";
                    break;
                case 3:
                    currentTimeFilter = "year";
                    break;
            }

            LoadLeaveRequests();
        }

        #endregion

        #region Helper Methods

        private void SetActiveFilterButton(Guna.UI2.WinForms.Guna2Button activeButton)
        {
            // Đặt độ sáng cho tất cả các nút
            foreach (Control control in pnlFilter.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Button button && button != activeButton)
                {
                    button.FillColor = Color.FromArgb(button.FillColor.R, button.FillColor.G, button.FillColor.B);
                    button.ForeColor = Color.White;
                }
            }

            // Làm nổi bật nút được chọn
            activeButton.ForeColor = Color.White;
        }

        #endregion

        private void pnlTaoDonMoi_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
