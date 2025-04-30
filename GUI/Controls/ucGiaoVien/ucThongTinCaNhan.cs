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

namespace QuanLyTruongHoc.GUI.Controls.ucGiaoVien
{
    public partial class ucThongTinCaNhan : UserControl
    {
        private readonly DatabaseHelper db;
        private int maNguoiDung;
        public ucThongTinCaNhan(int maNguoiDung)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            this.maNguoiDung = maNguoiDung;

            // Load teacher information
            LoadThongTinCaNhan();

        }
        private void LoadThongTinCaNhan()
        {
            try
            {
                // Query to get teacher information
                string query = $@"
            SELECT gv.HoTen, gv.GioiTinh, gv.SDT, gv.Email, gv.MaMon, mh.TenMon, 
                   gv.ChuNhiem, gv.NgaySinh, gv.DiaChi, nd.NgayTao
            FROM GiaoVien gv
            INNER JOIN MonHoc mh ON gv.MaMon = mh.MaMon
            INNER JOIN NguoiDung nd ON gv.MaNguoiDung = nd.MaNguoiDung
            WHERE gv.MaNguoiDung = {maNguoiDung}";
                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    // Populate fields with data
                    DataRow row = dt.Rows[0];
                    hoTenTxt.Text = row["HoTen"].ToString();
                    tenUserLbl.Text = hoTenTxt.Text;
                    gioiTinhCmb.SelectedItem = row["GioiTinh"].ToString();
                    sdtTxt.Text = row["SDT"].ToString();
                    emailTxt.Text = row["Email"].ToString();
                    diaChiTxt.Text = row["DiaChi"].ToString();
                    chyenMonCmb.SelectedIndex = chyenMonCmb.FindStringExact(row["TenMon"].ToString());

                    // Initialize and set ChuNhiem ComboBox
                    chuNhiemCmb.Items.Clear();
                    chuNhiemCmb.Items.Add("Có");
                    chuNhiemCmb.Items.Add("Không");
                    chuNhiemCmb.SelectedItem = Convert.ToBoolean(row["ChuNhiem"]) ? "Có" : "Không";

                    ngaySinhDTP.Value = Convert.ToDateTime(row["NgaySinh"]);
                    ngaySinhDTP.Format = DateTimePickerFormat.Custom;
                    ngaySinhDTP.CustomFormat = "dd/MM/yyyy";

                    // Calculate days of service
                    DateTime ngayTao = Convert.ToDateTime(row["NgayTao"]);
                    int soNgayCongTac = (DateTime.Now - ngayTao).Days;
                    congTacTxt.Text = $"{soNgayCongTac} ngày";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin giáo viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin cá nhân: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
