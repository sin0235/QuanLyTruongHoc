using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.GUI.Forms;

namespace QuanLyTruongHoc.GUI.Controls.ucPhongNoiVu
{
    public partial class ucQuanLyThoiKhoaBieu : UserControl
    {
        DatabaseHelper db;

        public ucQuanLyThoiKhoaBieu()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        private void LoadDanhSachLop()
        {
            string query = "SELECT MaLop, TenLop FROM LopHoc";
            DataTable dt = db.ExecuteQuery(query);
            cmbChonLop.DataSource = dt;
            cmbChonLop.DisplayMember = "TenLop";
            cmbChonLop.ValueMember = "MaLop";
        }

        private void ucQuanLyThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            LoadDanhSachLop();
            dtpNgay.ValueChanged += DtpNgay_ValueChanged;
            dgvThoiKhoaBieu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dgvThoiKhoaBieu.ClearSelection();
        }

        private void CmbChonLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThoiKhoaBieu();
        }

        private void DtpNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadThoiKhoaBieu();
        }

        private void LoadThoiKhoaBieu()
        {
            if (cmbChonLop.SelectedValue == null) return;

            int maLop;
            if (cmbChonLop.SelectedValue is DataRowView rowView)
            {
                maLop = Convert.ToInt32(rowView["MaLop"]);
            }
            else
            {
                maLop = Convert.ToInt32(cmbChonLop.SelectedValue);
            }

            DateTime selectedDate = dtpNgay.Value;

            // Tính ngày bắt đầu tuần (thứ 2) và ngày kết thúc tuần (chủ nhật)
            DateTime startOfWeek = selectedDate.AddDays(-(int)selectedDate.DayOfWeek + 1);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            // Tùy chỉnh cấu hình của DataGridView để hiển thị tiêu đề nhiều dòng
            dgvThoiKhoaBieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvThoiKhoaBieu.ColumnHeadersHeight = 60; // Đặt chiều cao cho tiêu đề
            dgvThoiKhoaBieu.EnableHeadersVisualStyles = false;
            dgvThoiKhoaBieu.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvThoiKhoaBieu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cập nhật tiêu đề cột với ngày tương ứng
            for (int i = 0; i < dgvThoiKhoaBieu.Columns.Count; i++)
            {
                DateTime currentDay = startOfWeek.AddDays(i);
                string thu = i == 6 ? "Chủ nhật" : $"Thứ {i + 2}";
                dgvThoiKhoaBieu.Columns[i].HeaderText = $"{thu}\r\n{currentDay:dd/MM/yyyy}";
            }

            string query = @"
            SELECT Thu, Tiet, TenMon, HoTen AS TenGiaoVien
            FROM ThoiKhoaBieu
            INNER JOIN MonHoc ON ThoiKhoaBieu.MaMon = MonHoc.MaMon
            INNER JOIN GiaoVien ON ThoiKhoaBieu.MaGV = GiaoVien.MaGV
            WHERE ThoiKhoaBieu.MaLop = @MaLop AND Ngay BETWEEN @StartOfWeek AND @EndOfWeek
            ORDER BY Thu, Tiet";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaLop", maLop },
                { "@StartOfWeek", startOfWeek },
                { "@EndOfWeek", endOfWeek }
            };

            DataTable dt = db.ExecuteQuery(query, parameters);

            // Xóa dữ liệu cũ trong DataGridView
            dgvThoiKhoaBieu.Rows.Clear();

            // Tổ chức dữ liệu theo thứ và tiết học
            Dictionary<int, Dictionary<string, string>> organizedData = new Dictionary<int, Dictionary<string, string>>();

            // Thu từ 2-8 (2=Thứ 2, ..., 8=Chủ nhật)
            for (int thu = 2; thu <= 8; thu++)
            {
                organizedData[thu] = new Dictionary<string, string>();
            }

            // Gom nhóm dữ liệu theo thứ và tiết
            foreach (DataRow row in dt.Rows)
            {
                int thu = Convert.ToInt32(row["Thu"]);
                string tiet = row["Tiet"].ToString();
                string monGV = $"Môn: {row["TenMon"]}\nGV: {row["TenGiaoVien"]}";

                organizedData[thu][tiet] = monGV;
            }

            // Xác định số dòng cần thiết
            int maxRowsNeeded = 0;
            foreach (var thuData in organizedData.Values)
            {
                maxRowsNeeded = Math.Max(maxRowsNeeded, thuData.Count);
            }

            // Thêm đủ số dòng cần thiết
            while (dgvThoiKhoaBieu.Rows.Count < maxRowsNeeded)
            {
                dgvThoiKhoaBieu.Rows.Add();
            }

            // Điền dữ liệu vào DataGridView
            foreach (var thuPair in organizedData)
            {
                int thu = thuPair.Key;
                var tietData = thuPair.Value;
                int columnIndex = thu - 2; // Thứ 2 tương ứng với cột đầu tiên

                if (columnIndex >= 0 && columnIndex < dgvThoiKhoaBieu.Columns.Count)
                {
                    int rowIndex = 0;
                    foreach (var tietPair in tietData)
                    {
                        string tiet = tietPair.Key;
                        string monGV = tietPair.Value;

                        if (rowIndex < dgvThoiKhoaBieu.Rows.Count)
                        {
                            dgvThoiKhoaBieu.Rows[rowIndex].Cells[columnIndex].Value = $"Tiết: {tiet}\n{monGV}";
                            rowIndex++;
                        }
                    }
                }
            }

            // Xóa các dòng trống dư thừa
            while (dgvThoiKhoaBieu.Rows.Count > maxRowsNeeded && maxRowsNeeded > 0)
            {
                dgvThoiKhoaBieu.Rows.RemoveAt(dgvThoiKhoaBieu.Rows.Count - 1);
            }

            // Nếu không có dữ liệu, thêm một dòng trống để DataGridView không trống hoàn toàn
            if (dgvThoiKhoaBieu.Rows.Count == 0)
            {
                dgvThoiKhoaBieu.Rows.Add();
            }

            // Loại bỏ các ô trống cuối cùng
            dgvThoiKhoaBieu.AllowUserToAddRows = false;
            dgvThoiKhoaBieu.ClearSelection();
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cmbChonLop.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp trước khi thêm lịch học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maLop = Convert.ToInt32(cmbChonLop.SelectedValue);
            string tenLop = cmbChonLop.Text;

            // Hiển thị form thêm lịch học
            frmQuanLyThoiKhoaBieu frm = new frmQuanLyThoiKhoaBieu(maLop, tenLop, dtpNgay.Value);
            frm.Text = "Thêm lịch học";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Reload thời khóa biểu sau khi thêm
                LoadThoiKhoaBieu();
            }
        }
    }
}
