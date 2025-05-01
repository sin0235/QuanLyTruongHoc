using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.GUI.Forms;
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
    public partial class ucQuanLyDiemSo : UserControl
    {
        private int MaNguoiDung;
        private int MaGiaoVien;
        private readonly DatabaseHelper db;

        public ucQuanLyDiemSo(int maNguoiDung, int maGiaoVien)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            MaNguoiDung = maNguoiDung;
            MaGiaoVien = maGiaoVien;

            // Debug: Check values
            MessageBox.Show($"MaNguoiDung: {MaNguoiDung}, MaGiaoVien: {MaGiaoVien}");
        }


        private void LoadScores()
        {
            try
            {
                // Query to get classes and subjects taught by the teacher
                string queryLopMon = $@"
        SELECT DISTINCT LH.MaLop, LH.TenLop, MH.MaMon, MH.TenMon
        FROM LopHoc LH
        INNER JOIN ThoiKhoaBieu TKB ON LH.MaLop = TKB.MaLop
        INNER JOIN MonHoc MH ON TKB.MaMon = MH.MaMon
        WHERE TKB.MaGV = {MaGiaoVien}";

                DataTable dtLopMon = db.ExecuteQuery(queryLopMon);

                if (dtLopMon.Rows.Count == 0)
                {
                    MessageBox.Show("No classes or subjects found for this teacher.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Populate class and subject ComboBoxes
                lopCmb.DataSource = dtLopMon.DefaultView.ToTable(true, "MaLop", "TenLop");
                lopCmb.DisplayMember = "TenLop";
                lopCmb.ValueMember = "MaLop";

                monCmb.DataSource = dtLopMon.DefaultView.ToTable(true, "MaMon", "TenMon");
                monCmb.DisplayMember = "TenMon";
                monCmb.ValueMember = "MaMon";

                // Populate LoaiDiem ComboBox
                string queryLoaiDiem = "SELECT DISTINCT LoaiDiem FROM DiemSo";
                DataTable dtLoaiDiem = db.ExecuteQuery(queryLoaiDiem);

                if (dtLoaiDiem.Rows.Count == 0)
                {
                    MessageBox.Show("No score types found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                loaiDiemCmb.DataSource = dtLoaiDiem;
                loaiDiemCmb.DisplayMember = "LoaiDiem";
                loaiDiemCmb.ValueMember = "LoaiDiem";

                // Check if selections are valid
                if (lopCmb.SelectedValue == null || monCmb.SelectedValue == null || loaiDiemCmb.SelectedValue == null)
                {
                    MessageBox.Show("Please select class, subject, and score type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maLop = Convert.ToInt32(lopCmb.SelectedValue);
                int maMon = Convert.ToInt32(monCmb.SelectedValue);
                string loaiDiem = loaiDiemCmb.SelectedValue.ToString();

                // Query to get student scores
                string queryDiem = $@"
        SELECT 
            ROW_NUMBER() OVER (ORDER BY HS.HoTen ASC) AS STT,
            HS.HoTen AS [Họ Tên],
            DS.Diem AS [Điểm Số],
            AVG(DS.Diem) OVER (PARTITION BY HS.MaHS) AS [Trung Bình]
        FROM HocSinh HS
        INNER JOIN DiemSo DS ON HS.MaHS = DS.MaHS
        WHERE HS.MaLop = {maLop} AND DS.MaMon = {maMon} AND DS.LoaiDiem = N'{loaiDiem}'";

                DataTable dtDiem = db.ExecuteQuery(queryDiem);

                // Debug: Check data before binding
                if (dtDiem.Rows.Count == 0)
                {
                    MessageBox.Show("No scores found for the selected class, subject, and score type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (DataRow row in dtDiem.Rows)
                    {
                        Console.WriteLine($"STT: {row["STT"]}, HoTen: {row["Họ Tên"]}, Diem: {row["Điểm Số"]}, TrungBinh: {row["Trung Bình"]}");
                    }
                }

                // Bind data to DataGridView
                dgvDanhSachHocSinh.AutoGenerateColumns = false;
                dgvDanhSachHocSinh.DataSource = dtDiem;

                // Map columns
                dgvDanhSachHocSinh.Columns["STT"].DataPropertyName = "STT";
                dgvDanhSachHocSinh.Columns["HoTen"].DataPropertyName = "Họ Tên";
                dgvDanhSachHocSinh.Columns["DiemSo"].DataPropertyName = "Điểm Số";
                dgvDanhSachHocSinh.Columns["DiemTB"].DataPropertyName = "Trung Bình";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading scores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void loaiDiemCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            // Placeholder for event handling
        }

        private void themDiemBtn_Click(object sender, EventArgs e)
        {
            frmNhapDiem frm = new frmNhapDiem(MaGiaoVien, this);
            frm.ShowDialog();
        }

        private void lamMoiBtn_Click(object sender, EventArgs e)
        {
            LoadScores();
        }
    }
}
