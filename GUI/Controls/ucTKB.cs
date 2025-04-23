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
    public partial class ucTKB : UserControl
    {
        private DatabaseHelper dbHelper;
        private int currentWeek = 0;
        private int maxWeek = 0;

        public ucTKB()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void ucTKB_Load(object sender, EventArgs e)
        {
            //LoadSchoolYears();
            //SetCurrentWeek();
        }

        // Load danh sách năm học vào combobox
        private void LoadSchoolYears()
        {
            try
            {
                string query = "SELECT DISTINCT NamHoc FROM NamHoc ORDER BY NamHoc DESC";
                DataTable dt = dbHelper.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cboNamHoc.DataSource = dt;
                    cboNamHoc.DisplayMember = "NamHoc";
                    cboNamHoc.ValueMember = "NamHoc";

                    // Sau khi chọn năm học, load học kỳ
                    LoadSemesters();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu năm học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách năm học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách học kỳ theo năm học
        private void LoadSemesters()
        {
            try
            {
                if (cboNamHoc.SelectedValue == null) return;

                string namHoc = cboNamHoc.SelectedValue.ToString();
                string query = $"SELECT DISTINCT HocKy FROM HocKy WHERE NamHoc = '{namHoc}' ORDER BY HocKy";
                DataTable dt = dbHelper.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cboHocKy.DataSource = dt;
                    cboHocKy.DisplayMember = "HocKy";
                    cboHocKy.ValueMember = "HocKy";

                    // Sau khi chọn học kỳ, load danh sách tuần
                    LoadWeeks();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu học kỳ cho năm học này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách học kỳ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách tuần theo năm học và học kỳ
        private void LoadWeeks()
        {
            //try
            //{
            //    if (cboNamHoc.SelectedValue == null || cboHocKy.SelectedValue == null) return;

            //    string namHoc = cboNamHoc.SelectedValue.ToString();
            //    string hocKy = cboHocKy.SelectedValue.ToString();

            //    string query = $"SELECT MaTuan, TenTuan FROM Tuan WHERE NamHoc = '{namHoc}' AND HocKy = '{hocKy}' ORDER BY MaTuan";
            //    DataTable dt = dbHelper.ExecuteQuery(query);

            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        cboTuan.DataSource = dt;
            //        cboTuan.DisplayMember = "TenTuan";
            //        cboTuan.ValueMember = "MaTuan";

            //        maxWeek = dt.Rows.Count;

            //        // Load thời khóa biểu sau khi đã chọn tuần
            //        LoadTimetable();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không có dữ liệu tuần cho học kỳ này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi tải danh sách tuần: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        // Lấy MaHS từ thông tin đăng nhập (giả sử thông tin được lưu từ form đăng nhập)
        private int GetCurrentStudentId()
        {
            // Cần thay thế bằng cách lấy thông tin thực từ hệ thống của bạn
            try
            {
                // Giả sử mã học sinh được lưu trong một biến static của form Login
                int maHS = frmLogin.LoggedInStudentId;
                return maHS;
            }
            catch
            {
                // Dành cho mục đích thử nghiệm, có thể trả về ID cố định
                return 0;
            }
        }

        // Load thời khóa biểu dựa trên các thông tin đã chọn
        private void LoadTimetable()
        {
          
        }

        
        private void SetCurrentWeek()
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác định tuần hiện tại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Event Handlers

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSemesters();
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWeeks();
        }

        private void cboTuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTuan.SelectedIndex >= 0)
            {
                currentWeek = cboTuan.SelectedIndex;
                LoadTimetable();
            }
        }

        private void btnTuanTruoc_Click(object sender, EventArgs e)
        {
            if (currentWeek > 0)
            {
                currentWeek--;
                cboTuan.SelectedIndex = currentWeek;
            }
            else
            {
                MessageBox.Show("Đây là tuần đầu tiên của học kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTuanHienTai_Click(object sender, EventArgs e)
        {
            SetCurrentWeek();
        }

        private void btnTuanTiepTheo_Click(object sender, EventArgs e)
        {
            if (currentWeek < maxWeek - 1)
            {
                currentWeek++;
                cboTuan.SelectedIndex = currentWeek;
            }
            else
            {
                MessageBox.Show("Đây là tuần cuối cùng của học kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
   
}
