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

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucGuiThu : UserControl
    {
        int newMaTB = 1;
        public ucGuiThu()
        {
            InitializeComponent();
        }

        private void cbLopCụThe_CheckedChanged(object sender, EventArgs e)
        {
            lblNhapLop.Visible = cbLopCuThe.Checked;
            txtNhapLop.Visible = cbLopCuThe.Checked;
            if (cbLopCuThe.Checked)
            {
                cbTatCa.Checked = false; 
            }
        }

        private void cbCaNhan_CheckedChanged(object sender, EventArgs e)
        {
            lblNhapMaCaNhan.Visible = cbCaNhan.Checked;
            txtNhapMaCaNhan.Visible = cbCaNhan.Checked;
            if (cbCaNhan.Checked)
            {
                cbTatCa.Checked = false;
            }
        }
        private void cbPhongNoiVu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPhongNoiVu.Checked)
            {
                cbTatCa.Checked = false;
            }
        }

        public void cbGiaoVien_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGiaoVien.Checked)
            {
                cbTatCa.Checked = false;
            }
        }

        private void cbHocSinh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHocSinh.Checked)
            {
                cbTatCa.Checked = false;
            }
        }

        private void cbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTatCa.Checked)
            {
                cbGiaoVien.Checked = false;
                cbHocSinh.Checked = false;
                cbLopCuThe.Checked = false;
                cbPhongNoiVu.Checked = false;
                cbCaNhan.Checked = false;
                lblNhapLop.Visible = false;
                txtNhapLop.Visible = false;
                lblNhapMaCaNhan.Visible = false;
                txtNhapMaCaNhan.Visible = false;
            }
        }
        private void ucGuiThu_Load(object sender, EventArgs e)
        {

        }

        private void btnGuiThu_Click(object sender, EventArgs e)
        {
            string tieuDe = txtTieuDe.Text.Trim();
            string noiDung = txtNoiDung.Text.Trim();

            if (string.IsNullOrEmpty(tieuDe) || string.IsNullOrEmpty(noiDung))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề và nội dung.");
                return;
            }

            DatabaseHelper db = null;

            try
            {
                db = new DatabaseHelper();
                db.OpenConnection();
                newMaTB = GetNextMaTB(db);

                if (cbTatCa.Checked)
                {
                    GuiThuTatCa(db, tieuDe, noiDung);
                }
                else
                {
                    GuiThuTheoLuaChon(db, tieuDe, noiDung);
                }

                MessageBox.Show("Gửi thư thành công!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi thư: " + ex.Message);
            }
            finally
            {
                if (db != null)
                {
                    db.CloseConnection();
                }
            }
        }
        private int GetNextMaTB(DatabaseHelper db)
        {
            string query = "SELECT ISNULL(MAX(MaTB), 0) + 1 FROM ThongBao";
            DataTable result = db.ExecuteQuery(query);
            return result.Rows.Count > 0 ? Convert.ToInt32(result.Rows[0][0]) : 1;
        }

        private void GuiThuTatCa(DatabaseHelper db, string tieuDe, string noiDung)
        {
            string query = "SELECT MaNguoiDung FROM NguoiDung WHERE MaNguoiDung != 1";
            DataTable nguoiDungTable = db.ExecuteQuery(query);

            foreach (DataRow row in nguoiDungTable.Rows)
            {
                int maNguoiNhan = Convert.ToInt32(row["MaNguoiDung"]);
                string insertQuery = $@"
                    INSERT INTO ThongBao (MaTB, MaNguoiGui, MaNguoiNhan, TieuDe, NoiDung, NgayGui)
                    VALUES ({newMaTB++}, 1, {maNguoiNhan}, N'{tieuDe}', N'{noiDung}', GETDATE());";
                db.ExecuteNonQuery(insertQuery);
            }
        }

        private void GuiThuTheoLuaChon(DatabaseHelper db, string tieuDe, string noiDung)
        {
            if (cbGiaoVien.Checked)
            {
                GuiThuTheoVaiTro(db, 2, tieuDe, noiDung);
            }

            if (cbHocSinh.Checked)
            {
                GuiThuTheoVaiTro(db, 3, tieuDe, noiDung);
            }

            if (cbLopCuThe.Checked)
            {
                string[] lopList = txtNhapLop.Text.Split(',');
                foreach (string lop in lopList)
                {
                    string insertQuery = $@"
                        INSERT INTO ThongBao (MaTB, MaNguoiGui, MaLop, TieuDe, NoiDung, NgayGui)
                        SELECT {newMaTB++}, 1, MaLop, N'{tieuDe}', N'{noiDung}', GETDATE()
                        FROM LopHoc
                        WHERE TenLop = '{lop.Trim()}';";
                    db.ExecuteNonQuery(insertQuery);
                }
            }

            if (cbPhongNoiVu.Checked)
            {
                GuiThuTheoVaiTro(db, 4, tieuDe, noiDung);
            }

            if (cbCaNhan.Checked)
            {
                string[] maCaNhanList = txtNhapMaCaNhan.Text.Split(',');
                foreach (string maCaNhan in maCaNhanList)
                {
                    GuiThuCaNhan(db, maCaNhan.Trim(), tieuDe, noiDung);
                }
            }
        }

        private void GuiThuTheoVaiTro(DatabaseHelper db, int maVaiTro, string tieuDe, string noiDung)
        {
            string query = $@"
                INSERT INTO ThongBao (MaTB, MaNguoiGui, MaVaiTroNhan, TieuDe, NoiDung, NgayGui)
                VALUES ({newMaTB++}, 1, {maVaiTro}, N'{tieuDe}', N'{noiDung}', GETDATE());";
            db.ExecuteNonQuery(query);
        }

        private void GuiThuCaNhan(DatabaseHelper db, string maCaNhan, string tieuDe, string noiDung)
        {
            string query = $@"
                SELECT NguoiDung.MaNguoiDung
                FROM HocSinh
                INNER JOIN NguoiDung ON HocSinh.MaNguoiDung = NguoiDung.MaNguoiDung
                WHERE HocSinh.MaHS = {maCaNhan}";

            DataTable result = db.ExecuteQuery(query);
            if (result.Rows.Count == 0)
            {
                query = $@"
                    SELECT NguoiDung.MaNguoiDung
                    FROM GiaoVien
                    INNER JOIN NguoiDung ON GiaoVien.MaNguoiDung = NguoiDung.MaNguoiDung
                    WHERE GiaoVien.MaGV = {maCaNhan}";

                result = db.ExecuteQuery(query);
            }

            if (result.Rows.Count > 0)
            {
                int maNguoiNhan = Convert.ToInt32(result.Rows[0]["MaNguoiDung"]);
                string insertQuery = $@"
                    INSERT INTO ThongBao (MaTB, MaNguoiGui, MaNguoiNhan, TieuDe, NoiDung, NgayGui)
                    VALUES ({newMaTB++}, 1, {maNguoiNhan}, N'{tieuDe}', N'{noiDung}', GETDATE());";
                db.ExecuteNonQuery(insertQuery);
            }
            else
            {
                MessageBox.Show($"Không tìm thấy MaHS hoặc MaGV: {maCaNhan}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
