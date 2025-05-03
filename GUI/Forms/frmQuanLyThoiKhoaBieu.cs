using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmQuanLyThoiKhoaBieu : Form
    {
        private int maLop;
        private string tenLop;
        private DateTime ngayHoc;
        private DatabaseHelper db;
        public frmQuanLyThoiKhoaBieu()
        {
            InitializeComponent();
        }
        public frmQuanLyThoiKhoaBieu(int maLop, string tenLop, DateTime ngayHoc)
        {
            InitializeComponent();
            this.maLop = maLop;
            this.tenLop = tenLop;
            this.ngayHoc = ngayHoc;
            db = new DatabaseHelper();
        }

        private void LoadMonHoc()
        {
            string query = "SELECT MaMon, TenMon FROM MonHoc";
            DataTable dt = db.ExecuteQuery(query);
            cmbMonHoc.DataSource = dt;
            cmbMonHoc.DisplayMember = "TenMon";
            cmbMonHoc.ValueMember = "MaMon";
        }

        private void LoadGiaoVien(int maMon)
        {
            string query = @"
            SELECT MaGV, HoTen
            FROM GiaoVien
            WHERE MaMon = @MaMon";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaMon", maMon }
            };

            DataTable dt = db.ExecuteQuery(query, parameters);
            cmbGiaoVien.DataSource = dt;
            cmbGiaoVien.DisplayMember = "HoTen";
            cmbGiaoVien.ValueMember = "MaGV";
        }

        private List<int> ParseTietHoc(string tietHoc)
        {
            List<int> result = new List<int>();

            if (string.IsNullOrWhiteSpace(tietHoc))
                return result;

            string[] ranges = tietHoc.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string range in ranges)
            {
                string trimmedRange = range.Trim();
                if (trimmedRange.Contains("-"))
                {
                    string[] bounds = trimmedRange.Split('-');
                    if (bounds.Length == 2 && int.TryParse(bounds[0], out int start) && int.TryParse(bounds[1], out int end))
                    {
                        // Đảm bảo start <= end
                        if (start > end)
                        {
                            int temp = start;
                            start = end;
                            end = temp;
                        }

                        for (int i = start; i <= end; i++)
                        {
                            if (!result.Contains(i)) // Tránh thêm trùng lặp
                                result.Add(i);
                        }
                    }
                }
                else if (int.TryParse(trimmedRange, out int singleTiet))
                {
                    if (!result.Contains(singleTiet)) // Tránh thêm trùng lặp
                        result.Add(singleTiet);
                }
            }

            return result;
        }

        private bool IsValidTietHocFormat(string tietHoc)
        {
            // Kiểm tra định dạng của chuỗi tiết học
            if (string.IsNullOrWhiteSpace(tietHoc))
                return false;

            string pattern = @"^(\d+(-\d+)?)(,\d+(-\d+)?)*$";
            return System.Text.RegularExpressions.Regex.IsMatch(tietHoc, pattern);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (cmbMonHoc.SelectedValue == null || cmbGiaoVien.SelectedValue == null || string.IsNullOrWhiteSpace(txtTietHoc.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int maMon = Convert.ToInt32(cmbMonHoc.SelectedValue);
                int maGV = Convert.ToInt32(cmbGiaoVien.SelectedValue);
                string tietHoc = txtTietHoc.Text.Trim(); // Ví dụ: "1-3"
                DateTime ngay = dtpNgayHoc.Value;
                int thu = (int)ngay.DayOfWeek == 0 ? 7 : (int)ngay.DayOfWeek + 1; // Chủ nhật là 7, Thứ 2 là 2, ..., Thứ 7 là 7

                // Kiểm tra định dạng tiết học hợp lệ trước khi xử lý
                if (!IsValidTietHocFormat(tietHoc))
                {
                    MessageBox.Show("Định dạng tiết học không hợp lệ! Vui lòng nhập theo định dạng: 1-3 hoặc 1,2,3",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy danh sách các tiết trong chuỗi tiết học mới
                List<int> tietMoi = ParseTietHoc(tietHoc);

                // Kiểm tra trùng lịch - chỉ kiểm tra Thu
                string queryCheck = @"
                SELECT Tiet
                FROM ThoiKhoaBieu
                WHERE MaLop = @MaLop AND Thu = @Thu";

                Dictionary<string, object> parametersCheck = new Dictionary<string, object>
                {
                    { "@MaLop", maLop },
                    { "@Thu", thu }
                };

                DataTable dt = db.ExecuteQuery(queryCheck, parametersCheck);

                foreach (DataRow row in dt.Rows)
                {
                    // Lấy danh sách các tiết đã tồn tại
                    List<int> tietDaTonTai = ParseTietHoc(row["Tiet"].ToString());

                    // Kiểm tra trùng lặp - tìm phần giao nhau giữa hai tập hợp
                    var overlappingTiets = tietMoi.Intersect(tietDaTonTai).ToList();
                    if (overlappingTiets.Count > 0)
                    {
                        string tietTrung = string.Join(", ", overlappingTiets);
                        MessageBox.Show($"Lịch học đã tồn tại cho tiết: {tietTrung}! Vui lòng chọn thời gian khác.",
                            "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Lấy MaTKB mới
                string queryMaxMaTKB = "SELECT ISNULL(MAX(MaTKB), 0) + 1 FROM ThoiKhoaBieu";
                int maTKB = Convert.ToInt32(db.ExecuteScalar(queryMaxMaTKB));

                // Thêm vào bảng ThoiKhoaBieu
                string queryInsert = @"
                INSERT INTO ThoiKhoaBieu (MaTKB, MaLop, MaMon, MaGV, Ngay, Thu, Tiet)
                VALUES (@MaTKB, @MaLop, @MaMon, @MaGV, @Ngay, @Thu, @Tiet)";

                Dictionary<string, object> parametersInsert = new Dictionary<string, object>
                {
                    { "@MaTKB", maTKB },
                    { "@MaLop", maLop },
                    { "@MaMon", maMon },
                    { "@MaGV", maGV },
                    { "@Ngay", ngay },
                    { "@Thu", thu },
                    { "@Tiet", tietHoc }
                };

                if (db.ExecuteNonQuery(queryInsert, parametersInsert))
                {
                    MessageBox.Show("Thêm lịch học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm lịch học thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMonHoc.SelectedValue == null) return;

            int maMon;
            if (cmbMonHoc.SelectedValue is DataRowView rowView)
            {
                maMon = Convert.ToInt32(rowView["MaMon"]);
            }
            else
            {
                maMon = Convert.ToInt32(cmbMonHoc.SelectedValue);
            }

            // Load danh sách giáo viên dạy môn học này
            LoadGiaoVien(maMon);
        }

        private void frmQuanLyThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            dtpNgayHoc.Value = ngayHoc;
            LoadMonHoc();
        }
    }
}
