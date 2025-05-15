using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using QuanLyTruongHoc.DAL;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmQuanLyLop : Form
    {
        private DatabaseHelper db;
        private string namHocHienTai;
        private string tenLop;
        private string tenGVChuNhiemCu;
        private bool isEditMode = false;

        public frmQuanLyLop()
        {
            InitializeComponent();
            db = new DatabaseHelper();
            isEditMode = false;

            btnXacNhan.Text = "Cập nhật";
            TKBDAO tkbDAO = new TKBDAO();
            namHocHienTai = tkbDAO.GetCurrentSchoolYear();
            if (string.IsNullOrEmpty(namHocHienTai))
            {
                namHocHienTai = "2024-2025";
            }
        }

        public frmQuanLyLop(string tenLop, string tenGVChuNhiemCu)
        {
            InitializeComponent();
            db = new DatabaseHelper();
            isEditMode = true;

            this.tenLop = tenLop;
            this.tenGVChuNhiemCu = tenGVChuNhiemCu;

            TKBDAO tkbDAO = new TKBDAO();
            namHocHienTai = tkbDAO.GetCurrentSchoolYear();

            if (string.IsNullOrEmpty(namHocHienTai))
            {
                namHocHienTai = "2024-2025";
            }
        }

        private void frmQuanLyLop_Load(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                btnXacNhan.Text = "Cập nhật";
                txtLop.Text = tenLop;
                txtLop.Enabled = false; 
                LoadGiaoVienChoSua();
            }
            else
            {
                btnXacNhan.Text = "Thêm";
                LoadGiaoVienChuaLamChuNhiem();
            }
        }

        private void LoadGiaoVienChoSua()
        {
            try
            {
                // Truy vấn để lấy mã giáo viên chủ nhiệm hiện tại của lớp
                string getMaGVCuQuery = "SELECT MaGVChuNhiem FROM LopHoc WHERE TenLop = @TenLop AND NamHoc = @NamHoc";
                Dictionary<string, object> maGVParams = new Dictionary<string, object>
                {
                    { "@TenLop", tenLop },
                    { "@NamHoc", namHocHienTai }
                };
                object result = db.ExecuteScalar(getMaGVCuQuery, maGVParams);
                int maGVChuNhiemCu = 0;

                if (result != null && result != DBNull.Value)
                {
                    maGVChuNhiemCu = Convert.ToInt32(result);
                }

                // Truy vấn để lấy danh sách giáo viên chưa được phân công làm chủ nhiệm VÀ giáo viên chủ nhiệm hiện tại
                string query = @"
                SELECT gv.MaGV, gv.HoTen
                FROM GiaoVien gv
                WHERE gv.MaGV NOT IN (
                    SELECT DISTINCT MaGVChuNhiem 
                    FROM LopHoc 
                    WHERE NamHoc = @NamHoc AND MaGVChuNhiem <> @MaGVCu
                )
                ORDER BY gv.HoTen
                ";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@NamHoc", namHocHienTai },
                    { "@MaGVCu", maGVChuNhiemCu }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cbGiaoVienChuNhiem.DisplayMember = "HoTen";
                    cbGiaoVienChuNhiem.ValueMember = "MaGV";
                    cbGiaoVienChuNhiem.DataSource = dt;
                    cbGiaoVienChuNhiem.SelectedValue = maGVChuNhiemCu;
                }
                else
                {
                    MessageBox.Show("Không còn giáo viên nào chưa được phân công chủ nhiệm!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbGiaoVienChuNhiem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách giáo viên: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGiaoVienChuaLamChuNhiem()
        {
            try
            {
                // Truy vấn để lấy danh sách giáo viên chưa được phân công làm chủ nhiệm
                string query = @"
                SELECT gv.MaGV, gv.HoTen
                FROM GiaoVien gv
                WHERE gv.ChuNhiem = 0 AND gv.MaGV NOT IN (
                    SELECT DISTINCT MaGVChuNhiem 
                    FROM LopHoc 
                    WHERE NamHoc = @NamHoc
                )
                ORDER BY gv.HoTen
                ";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@NamHoc", namHocHienTai }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cbGiaoVienChuNhiem.DisplayMember = "HoTen";
                    cbGiaoVienChuNhiem.ValueMember = "MaGV";
                    cbGiaoVienChuNhiem.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không còn giáo viên nào chưa được phân công chủ nhiệm!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbGiaoVienChuNhiem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách giáo viên: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu chung cho cả hai chế độ
            if (cbGiaoVienChuNhiem.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giáo viên chủ nhiệm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (isEditMode)
                {
                    int maGVChuNhiemMoi = (int)cbGiaoVienChuNhiem.SelectedValue;
                    string tenGVChuNhiemMoi = cbGiaoVienChuNhiem.Text;

                    // Lấy mã của giáo viên chủ nhiệm cũ
                    string getMaGVChuNhiemCuQuery = "SELECT MaGVChuNhiem FROM LopHoc WHERE TenLop = @TenLop AND NamHoc = @NamHoc";
                    Dictionary<string, object> maGVParams = new Dictionary<string, object>
                    {
                        { "@TenLop", tenLop },
                        { "@NamHoc", namHocHienTai }
                    };
                    object result = db.ExecuteScalar(getMaGVChuNhiemCuQuery, maGVParams);
                    int maGVChuNhiemCu = 0;

                    if (result != null && result != DBNull.Value)
                    {
                        maGVChuNhiemCu = Convert.ToInt32(result);
                    }

                    // Nếu giáo viên chủ nhiệm không thay đổi
                    if (maGVChuNhiemMoi == maGVChuNhiemCu)
                    {
                        MessageBox.Show("Không có thay đổi nào được thực hiện!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Cập nhật trạng thái của giáo viên chủ nhiệm cũ (nếu có)
                    if (maGVChuNhiemCu > 0)
                    {
                        // Kiểm tra xem giáo viên cũ có còn chủ nhiệm lớp nào khác không
                        string checkOtherClassQuery = "SELECT COUNT(*) FROM LopHoc WHERE MaGVChuNhiem = @MaGV AND TenLop <> @TenLop AND NamHoc = @NamHoc";
                        Dictionary<string, object> checkParams = new Dictionary<string, object>
                        {
                            { "@MaGV", maGVChuNhiemCu },
                            { "@TenLop", tenLop },
                            { "@NamHoc", namHocHienTai }
                        };
                        int otherClassCount = Convert.ToInt32(db.ExecuteScalar(checkOtherClassQuery, checkParams));

                        if (otherClassCount == 0)
                        {
                            // Nếu không còn chủ nhiệm lớp nào khác, cập nhật trạng thái ChuNhiem = 0
                            string updateOldGVQuery = "UPDATE GiaoVien SET ChuNhiem = 0 WHERE MaGV = @MaGV";
                            Dictionary<string, object> updateOldParams = new Dictionary<string, object>
                            {
                                { "@MaGV", maGVChuNhiemCu }
                            };
                            db.ExecuteNonQuery(updateOldGVQuery, updateOldParams);
                        }
                    }

                    // Cập nhật trạng thái của giáo viên chủ nhiệm mới
                    string updateNewGVQuery = "UPDATE GiaoVien SET ChuNhiem = 1 WHERE MaGV = @MaGV";
                    Dictionary<string, object> updateNewParams = new Dictionary<string, object>
                    {
                        { "@MaGV", maGVChuNhiemMoi }
                    };
                    db.ExecuteNonQuery(updateNewGVQuery, updateNewParams);

                    // Cập nhật thông tin lớp học
                    string updateLopQuery = "UPDATE LopHoc SET MaGVChuNhiem = @MaGVMoi WHERE TenLop = @TenLop AND NamHoc = @NamHoc";
                    Dictionary<string, object> updateLopParams = new Dictionary<string, object>
                    {
                        { "@MaGVMoi", maGVChuNhiemMoi },
                        { "@TenLop", tenLop },
                        { "@NamHoc", namHocHienTai }
                    };
                    bool updateResult = db.ExecuteNonQuery(updateLopQuery, updateLopParams);

                    if (updateResult)
                    {
                        // Ghi nhật ký hoạt động
                        string getMaxMaNKQuery = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                        int maNK = Convert.ToInt32(db.ExecuteScalar(getMaxMaNKQuery));

                        string getMaNguoiDungPhongNoiVuQuery = "SELECT MaNguoiDung FROM NguoiDung WHERE MaVaiTro = @MaVaiTro";
                        Dictionary<string, object> vaiTroParams = new Dictionary<string, object>
                        {
                            { "@MaVaiTro", 2 }
                        };
                        int maNguoiDungPhongNoiVu = Convert.ToInt32(db.ExecuteScalar(getMaNguoiDungPhongNoiVuQuery, vaiTroParams));

                        string hanhDong = $"Sửa thông tin lớp {tenLop} của giáo viên {tenGVChuNhiemCu} chủ nhiệm thành giáo viên {tenGVChuNhiemMoi} chủ nhiệm";

                        string insertNhatKyQuery = @"
                        INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian)
                        VALUES (@MaNK, @MaNguoiDung, @HanhDong, @ThoiGian)
                        ";

                        Dictionary<string, object> nhatKyParams = new Dictionary<string, object>
                        {
                            { "@MaNK", maNK },
                            { "@MaNguoiDung", maNguoiDungPhongNoiVu },
                            { "@HanhDong", hanhDong },
                            { "@ThoiGian", DateTime.Now }
                        };

                        db.ExecuteNonQuery(insertNhatKyQuery, nhatKyParams);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin lớp. Vui lòng thử lại!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtLop.Text))
                    {
                        MessageBox.Show("Vui lòng nhập tên lớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLop.Focus();
                        return;
                    }

                    string checkQuery = "SELECT COUNT(*) FROM LopHoc WHERE TenLop = @TenLop AND NamHoc = @NamHoc";
                    Dictionary<string, object> checkParams = new Dictionary<string, object>
                    {
                        { "@TenLop", txtLop.Text.Trim() },
                        { "@NamHoc", namHocHienTai }
                    };

                    int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));

                    if (count > 0)
                    {
                        MessageBox.Show("Tên lớp này đã tồn tại trong năm học hiện tại!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLop.Focus();
                        return;
                    }

                    string getMaQuery = "SELECT ISNULL(MAX(MaLop), 0) + 1 FROM LopHoc";
                    int maLopMoi = Convert.ToInt32(db.ExecuteScalar(getMaQuery));

                    int maGV = (int)cbGiaoVienChuNhiem.SelectedValue;

                    // Thêm lớp học mới
                    string insertQuery = @"
                    INSERT INTO LopHoc (MaLop, TenLop, MaGVChuNhiem, NamHoc)
                    VALUES (@MaLop, @TenLop, @MaGVChuNhiem, @NamHoc)
                    ";

                    Dictionary<string, object> insertParams = new Dictionary<string, object>
                    {
                        { "@MaLop", maLopMoi },
                        { "@TenLop", txtLop.Text.Trim() },
                        { "@MaGVChuNhiem", maGV },
                        { "@NamHoc", namHocHienTai }
                    };

                    bool insertResult = db.ExecuteNonQuery(insertQuery, insertParams);

                    if (insertResult)
                    {
                        // Cập nhật trạng thái chủ nhiệm của giáo viên
                        string updateQuery = "UPDATE GiaoVien SET ChuNhiem = 1 WHERE MaGV = @MaGV";
                        Dictionary<string, object> updateParams = new Dictionary<string, object>
                        {
                            { "@MaGV", maGV }
                        };

                        db.ExecuteNonQuery(updateQuery, updateParams);

                        string getMaxMaNKQuery = "SELECT ISNULL(MAX(MaNK), 0) + 1 FROM NhatKyHeThong";
                        int maNK = Convert.ToInt32(db.ExecuteScalar(getMaxMaNKQuery));

                        string getMaNguoiDungPhongNoiVuQuery = "SELECT MaNguoiDung FROM NguoiDung WHERE MaVaiTro = @MaVaiTro";
                        Dictionary<string, object> vaiTroParams = new Dictionary<string, object>
                        {
                            { "@MaVaiTro", 2 }
                        };
                        int maNguoiDungPhongNoiVu = Convert.ToInt32(db.ExecuteScalar(getMaNguoiDungPhongNoiVuQuery, vaiTroParams));

                        string tenGiaoVien = cbGiaoVienChuNhiem.Text;
                        string hanhDong = $"Thêm lớp {txtLop.Text.Trim()} với sự phân công cho giáo viên {tenGiaoVien} chủ nhiệm";

                        string insertNhatKyQuery = @"
                        INSERT INTO NhatKyHeThong (MaNK, MaNguoiDung, HanhDong, ThoiGian)
                        VALUES (@MaNK, @MaNguoiDung, @HanhDong, @ThoiGian)
                        ";

                        Dictionary<string, object> nhatKyParams = new Dictionary<string, object>
                        {
                            { "@MaNK", maNK },
                            { "@MaNguoiDung", maNguoiDungPhongNoiVu },
                            { "@HanhDong", hanhDong },
                            { "@ThoiGian", DateTime.Now }
                        };

                        db.ExecuteNonQuery(insertNhatKyQuery, nhatKyParams);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm lớp học mới. Vui lòng thử lại!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện thao tác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
