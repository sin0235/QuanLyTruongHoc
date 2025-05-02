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
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmQuanLyHocSinh : Form
    {
        private int maHS;
        private bool isEditMode = false;
        private int maNguoiDung = -1;
        public frmQuanLyHocSinh()
        {
            InitializeComponent();
            isEditMode = false; 
        }

        public frmQuanLyHocSinh(int maHS, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string sdtPhuHuynh, string tenLop)
        {
            InitializeComponent();
            this.maHS = maHS;
            isEditMode = true;
            DatabaseHelper db = new DatabaseHelper();
            string queryMaNguoiDung = $"SELECT MaNguoiDung FROM HocSinh WHERE MaHS = {maHS}";
            object result = db.ExecuteScalar(queryMaNguoiDung);
            if (result != null)
            {
                maNguoiDung = Convert.ToInt32(result);
            }
            txtHoTen.Text = hoTen;
            txtNgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
            if (gioiTinh == "Nam")
            {
                checkNam.Checked = true;
                checkNu.Checked = false;
            }
            else
            {
                checkNam.Checked = false;
                checkNu.Checked = true;
            }
            txtDiaChi.Text = diaChi;
            txtSDTPhuHuynh.Text = sdtPhuHuynh;
            txtLop.Text = tenLop;
            this.Text = "Sửa thông tin học sinh";
            btnXacNhan.Text = "Cập nhật";
        }

        private string GenerateRandomPassword(int length)
        {
            Random random = new Random();
            const string chars = "123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                    string.IsNullOrWhiteSpace(txtNgaySinh.Text) ||
                    string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                    string.IsNullOrWhiteSpace(txtSDTPhuHuynh.Text) ||
                    string.IsNullOrWhiteSpace(txtLop.Text) ||
                    (!checkNam.Checked && !checkNu.Checked))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string hoTen = txtHoTen.Text.Trim();
                string ngaySinhStr = txtNgaySinh.Text.Trim();
                string gioiTinh = checkNam.Checked ? "Nam" : "Nữ";
                string diaChi = txtDiaChi.Text.Trim();
                string sdtPhuHuynh = txtSDTPhuHuynh.Text.Trim();
                string tenLop = txtLop.Text.Trim();

                DateTime ngaySinh;
                if (!DateTime.TryParseExact(ngaySinhStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ! Vui lòng nhập theo định dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DatabaseHelper db = new DatabaseHelper();
                db.OpenConnection();

                string queryMaLop = $"SELECT MaLop FROM LopHoc WHERE TenLop = N'{tenLop}'";
                DataTable dtMaLop = db.ExecuteQuery(queryMaLop);
                if (dtMaLop.Rows.Count == 0)
                {
                    MessageBox.Show("Lớp không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int maLop = Convert.ToInt32(dtMaLop.Rows[0]["MaLop"]);

                if (isEditMode)
                {
                    string queryUpdateHocSinh = $@"
                    UPDATE HocSinh 
                    SET HoTen = N'{hoTen}', 
                        NgaySinh = '{ngaySinh:yyyy-MM-dd}', 
                        GioiTinh = N'{gioiTinh}', 
                        DiaChi = N'{diaChi}', 
                        SDTPhuHuynh = '{sdtPhuHuynh}', 
                        MaLop = {maLop}
                    WHERE MaHS = {maHS}";

                    bool success = db.ExecuteNonQuery(queryUpdateHocSinh);

                    if (success)
                    {
                        MessageBox.Show("Cập nhật thông tin học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin học sinh thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string queryMaxMaNguoiDung = "SELECT ISNULL(MAX(MaNguoiDung), 0) + 1 AS NextMaNguoiDung FROM NguoiDung";
                    DataTable dtMaxMaNguoiDung = db.ExecuteQuery(queryMaxMaNguoiDung);
                    int maNguoiDung = Convert.ToInt32(dtMaxMaNguoiDung.Rows[0]["NextMaNguoiDung"]);

                    string matKhau = GenerateRandomPassword(8);
                    string tenDangNhap = $"hs{maNguoiDung}";
                    string queryInsertNguoiDung = $@"
                    INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro, NgayTao)
                    VALUES ({maNguoiDung}, '{tenDangNhap}', '{matKhau}', 3, GETDATE())";
                    db.ExecuteNonQuery(queryInsertNguoiDung);

                    string queryMaxMaHS = "SELECT ISNULL(MAX(MaHS), 0) + 1 AS NextMaHS FROM HocSinh";
                    DataTable dtMaxMaHS = db.ExecuteQuery(queryMaxMaHS);
                    int maHS = Convert.ToInt32(dtMaxMaHS.Rows[0]["NextMaHS"]);

                    string queryInsertHocSinh = $@"
                    INSERT INTO HocSinh (MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, DiaChi, SDTPhuHuynh, MaLop)
                    VALUES ({maHS}, {maNguoiDung}, N'{hoTen}', '{ngaySinh:yyyy-MM-dd}', N'{gioiTinh}', N'{diaChi}', '{sdtPhuHuynh}', {maLop})";
                    db.ExecuteNonQuery(queryInsertHocSinh);

                    MessageBox.Show($"Thêm học sinh thành công!\nTên đăng nhập: {tenDangNhap}\nMật khẩu: {matKhau}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmQuanLyHocSinh_Load(object sender, EventArgs e)
        {

        }
    }
}
