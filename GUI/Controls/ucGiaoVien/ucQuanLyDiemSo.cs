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
                // Kiểm tra xem lớp và môn đã được chọn chưa
                if (lopCmb.SelectedValue == null || monCmb.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn lớp và môn học.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maLop = Convert.ToInt32(lopCmb.SelectedValue);
                int maMon = Convert.ToInt32(monCmb.SelectedValue);

                // Truy vấn để lấy danh sách học sinh và điểm
                string queryDiem = $@"
            SELECT 
                HS.MaHS, -- Thêm cột MaHS
                ROW_NUMBER() OVER (ORDER BY HS.HoTen ASC) AS STT,
                HS.HoTen AS [Họ Tên],
                STRING_AGG(CASE WHEN DS.LoaiDiem = N'Miệng' THEN CAST(DS.Diem AS NVARCHAR) END, ', ') AS [Điểm Miệng],
                STRING_AGG(CASE WHEN DS.LoaiDiem = N'15 phút' THEN CAST(DS.Diem AS NVARCHAR) END, ', ') AS [Điểm 15 Phút],
                STRING_AGG(CASE WHEN DS.LoaiDiem = N'Giữa kỳ' THEN CAST(DS.Diem AS NVARCHAR) END, ', ') AS [Điểm Giữa Kỳ],
                STRING_AGG(CASE WHEN DS.LoaiDiem = N'Cuối kỳ' THEN CAST(DS.Diem AS NVARCHAR) END, ', ') AS [Điểm Cuối Kỳ],
                ROUND(AVG(DS.Diem), 2) AS [Trung Bình]
            FROM HocSinh HS
            LEFT JOIN DiemSo DS ON HS.MaHS = DS.MaHS AND DS.MaMon = {maMon}
            WHERE HS.MaLop = {maLop}
            GROUP BY HS.MaHS, HS.HoTen";

                DataTable dtDiem = db.ExecuteQuery(queryDiem);

                // Kiểm tra dữ liệu trước khi gán vào DataGridView
                if (dtDiem.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu điểm cho lớp và môn học đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvDanhSachHocSinh.AutoGenerateColumns = false;
                dgvDanhSachHocSinh.DataSource = dtDiem;

                // Xóa các cột cũ trước khi thêm cột mới
                dgvDanhSachHocSinh.Columns.Clear();

                // Thêm cột và ánh xạ dữ liệu
                dgvDanhSachHocSinh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "STT", DataPropertyName = "STT", Name = "STT" });
                dgvDanhSachHocSinh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ Tên", DataPropertyName = "Họ Tên", Name = "HoTen" });
                dgvDanhSachHocSinh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Điểm Miệng", DataPropertyName = "Điểm Miệng", Name = "DiemMieng" });
                dgvDanhSachHocSinh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Điểm 15 Phút", DataPropertyName = "Điểm 15 Phút", Name = "Diem15Phut" });
                dgvDanhSachHocSinh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Điểm Giữa Kỳ", DataPropertyName = "Điểm Giữa Kỳ", Name = "DiemGiuaKy" });
                dgvDanhSachHocSinh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Điểm Cuối Kỳ", DataPropertyName = "Điểm Cuối Kỳ", Name = "DiemCuoiKy" });
                dgvDanhSachHocSinh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trung Bình", DataPropertyName = "Trung Bình", Name = "DiemTB" });
                dgvDanhSachHocSinh.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "MaHS", DataPropertyName = "MaHS", Name = "MaHS", Visible = false }); // Ẩn cột MaHS
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                // Tải lại danh sách lớp và môn mặc định
                string queryLopMon = $@"
            SELECT DISTINCT LH.MaLop, LH.TenLop, MH.MaMon, MH.TenMon
            FROM LopHoc LH
            INNER JOIN ThoiKhoaBieu TKB ON LH.MaLop = TKB.MaLop
            INNER JOIN MonHoc MH ON TKB.MaMon = MH.MaMon
            WHERE TKB.MaGV = {MaGiaoVien}";

                DataTable dtLopMon = db.ExecuteQuery(queryLopMon);

                if (dtLopMon.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy lớp hoặc môn học nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Cập nhật combobox lớp
                lopCmb.DataSource = dtLopMon.DefaultView.ToTable(true, "MaLop", "TenLop");
                lopCmb.DisplayMember = "TenLop";
                lopCmb.ValueMember = "MaLop";

                // Cập nhật combobox môn
                monCmb.DataSource = dtLopMon.DefaultView.ToTable(true, "MaMon", "TenMon");
                monCmb.DisplayMember = "TenMon";
                monCmb.ValueMember = "MaMon";

                // Đặt giá trị mặc định cho combobox
                if (lopCmb.Items.Count > 0) lopCmb.SelectedIndex = 0;
                if (monCmb.Items.Count > 0) monCmb.SelectedIndex = 0;

                // Tải lại danh sách điểm
                LoadScores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void locBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Lọc dữ liệu cho ComboBox "Lớp"
                string queryLop = "SELECT DISTINCT MaLop, TenLop FROM LopHoc WHERE TenLop LIKE '12%'";
                DataTable dtLop = db.ExecuteQuery(queryLop);

                if (dtLop.Rows.Count > 0)
                {
                    lopCmb.DataSource = dtLop;
                    lopCmb.DisplayMember = "TenLop";
                    lopCmb.ValueMember = "MaLop";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu Lớp phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Lọc dữ liệu cho ComboBox "Môn"
                string queryMon = "SELECT DISTINCT MaMon, TenMon FROM MonHoc WHERE TenMon LIKE 'Toán%'";
                DataTable dtMon = db.ExecuteQuery(queryMon);

                if (dtMon.Rows.Count > 0)
                {
                    monCmb.DataSource = dtMon;
                    monCmb.DisplayMember = "TenMon";
                    monCmb.ValueMember = "MaMon";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu Môn phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Đặt giá trị mặc định cho combobox
                if (lopCmb.Items.Count > 0) lopCmb.SelectedIndex = 0;
                if (monCmb.Items.Count > 0) monCmb.SelectedIndex = 0;

                // Tải lại danh sách điểm
                LoadScores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chinhSuaDiemBtn_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHocSinh.SelectedRows.Count > 0)
            {
                // Lấy mã học sinh từ cột MaHS
                var maHSCell = dgvDanhSachHocSinh.SelectedRows[0].Cells["MaHS"];
                if (maHSCell == null || maHSCell.Value == null)
                {
                    MessageBox.Show("Không thể lấy mã học sinh. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int maHS = Convert.ToInt32(maHSCell.Value);

                // Lấy mã môn học
                if (monCmb.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một môn học.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maMon = Convert.ToInt32(monCmb.SelectedValue);

                // Mở form chỉnh sửa điểm
                frmChinhSuaDiem frm = new frmChinhSuaDiem(maHS, maMon, this.dgvDanhSachHocSinh);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một học sinh để chỉnh sửa điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
