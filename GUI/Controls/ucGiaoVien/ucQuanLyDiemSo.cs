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

                // Check if selections are valid
                if (lopCmb.SelectedValue == null || monCmb.SelectedValue == null)
                {
                    MessageBox.Show("Please select class and subject.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maLop = Convert.ToInt32(lopCmb.SelectedValue);
                int maMon = Convert.ToInt32(monCmb.SelectedValue);

                // Query to get all student scores and calculate average
                string queryDiem = $@"
                        SELECT 
                            ROW_NUMBER() OVER (ORDER BY HS.HoTen ASC) AS STT,
                            HS.HoTen AS [Họ Tên],
                            MAX(CASE WHEN DS.LoaiDiem = N'Miệng' THEN DS.Diem END) AS [Điểm Miệng],
                            MAX(CASE WHEN DS.LoaiDiem = N'15 phút' THEN DS.Diem END) AS [Điểm 15 Phút],
                            MAX(CASE WHEN DS.LoaiDiem = N'Giữa kỳ' THEN DS.Diem END) AS [Điểm Giữa Kỳ],
                            MAX(CASE WHEN DS.LoaiDiem = N'Cuối kỳ' THEN DS.Diem END) AS [Điểm Cuối Kỳ],
                            ROUND(AVG(DS.Diem), 2) AS [Trung Bình]
                        FROM HocSinh HS
                        LEFT JOIN DiemSo DS ON HS.MaHS = DS.MaHS AND DS.MaMon = {maMon}
                        WHERE HS.MaLop = {maLop}
                        GROUP BY HS.MaHS, HS.HoTen";


                DataTable dtDiem = db.ExecuteQuery(queryDiem);

                // Debug: Check data before binding
                if (dtDiem.Rows.Count == 0)
                {
                    MessageBox.Show("No scores found for the selected class and subject.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (DataRow row in dtDiem.Rows)
                    {
                        Console.WriteLine($"STT: {row["STT"]}, HoTen: {row["Họ Tên"]}, DiemMieng: {row["Điểm Miệng"]}, Diem15Phut: {row["Điểm 15 Phút"]}, DiemGiuaKy: {row["Điểm Giữa Kỳ"]}, DiemCuoiKy: {row["Điểm Cuối Kỳ"]}, TrungBinh: {row["Trung Bình"]}");
                    }
                }

                // Bind data to DataGridView
                dgvDanhSachHocSinh.AutoGenerateColumns = false;
                dgvDanhSachHocSinh.DataSource = dtDiem;

                // Map columns
                dgvDanhSachHocSinh.Columns["STT"].DataPropertyName = "STT";
                dgvDanhSachHocSinh.Columns["HoTen"].DataPropertyName = "Họ Tên";
                dgvDanhSachHocSinh.Columns["DiemMieng"].DataPropertyName = "Điểm Miệng";
                dgvDanhSachHocSinh.Columns["Diem15Phut"].DataPropertyName = "Điểm 15 Phút";
                dgvDanhSachHocSinh.Columns["DiemGiuaKy"].DataPropertyName = "Điểm Giữa Kỳ";
                dgvDanhSachHocSinh.Columns["DiemCuoiKy"].DataPropertyName = "Điểm Cuối Kỳ";
                dgvDanhSachHocSinh.Columns["DiemTB"].DataPropertyName = "Trung Bình";
                dgvDanhSachHocSinh.Columns["DiemTB"].DefaultCellStyle.Format = "N2";

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
            frmNhapDiem frm = new frmNhapDiem(MaGiaoVien, this.dgvDanhSachHocSinh);
            frm.ShowDialog();
        }

        private void lamMoiBtn_Click(object sender, EventArgs e)
        {
            LoadScores();
        }
    }
}
