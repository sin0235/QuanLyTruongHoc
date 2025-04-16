using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucInfoHS : UserControl
    {

        // Sự kiện khi thông tin học sinh được cập nhật
        public event EventHandler<StudentInfo> StudentInfoUpdated;

        // Dữ liệu học sinh hiện tại
        private StudentInfo _currentStudent;

        public ucInfoHS()
        {
            InitializeComponent();

            // Đăng ký sự kiện cho các nút
            btnEdit.Click += btnEdit_Click;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
            lblChangeAvatar.Click += lblChangeAvatar_Click;

        }

        private void ucInfoHS_Load(object sender, EventArgs e)
        {
            // Mặc định load dữ liệu mẫu khi control được khởi tạo
            // Trong thực tế, dữ liệu sẽ được lấy từ database
            LoadSampleData();
        }

        /// <summary>
        /// Tải dữ liệu học sinh vào control
        /// </summary>
        /// <param name="student">Thông tin học sinh</param>
        public void LoadStudentInfo(StudentInfo student)
        {
            if (student == null)
                return;

            _currentStudent = student;

            // Hiển thị thông tin chung
            lblFullName.Text = student.FullName;
            lblStudentId.Text = $"Mã HS: {student.StudentId}";
            lblClass.Text = $"Lớp: {student.ClassName}";
            lblIdentityCode.Text = $"Mã định danh: {student.IdentityCode}";

            // Hiển thị thông tin bổ sung
            lblGender.Text = $"Giới tính: {student.Gender}";
            lblDOB.Text = $"Ngày sinh: {student.DateOfBirth.ToString("dd/MM/yyyy")}";
            lblPlaceOfBirth.Text = $"Nơi sinh: {student.PlaceOfBirth}";
            lblEthnicity.Text = $"Dân tộc: {student.Ethnicity}";
            lblReligion.Text = $"Tôn giáo: {student.Religion}";

            // Hiển thị thông tin liên hệ (có thể chỉnh sửa)
            txtAddress.Text = student.Address;
            txtPhone.Text = student.Phone;
            txtEmail.Text = student.Email;


            // Hiển thị thông tin người liên hệ khẩn cấp
            txtHoTenCha.Text = student.EmergencyName ?? "";
            txtSoDienThoaiCha.Text = student.EmergencyRelation ?? "";
            txtHoTenMe.Text = student.EmergencyPhone ?? "";

            // Hiển thị ảnh đại diện nếu có
            if (student.Avatar != null)
                picAvatar.Image = student.Avatar;
            //else
            //    picAvatar.Image = Properties.Resources.defaultAvatar; // Cần thêm ảnh mặc định vào Resources
        }

        /// <summary>
        /// Tải dữ liệu mẫu để kiểm thử giao diện
        /// </summary>
        private void LoadSampleData()
        {
            var student = new StudentInfo()
            {
                StudentId = "HS001",
                FullName = "Nguyễn Văn A",
                ClassName = "12A1",
                Gender = "Nam",
                DateOfBirth = new DateTime(2005, 5, 15),
                Address = "123 Đường Nguyễn Huệ, Phường Bến Nghé, Quận 1, TP.HCM",
                Phone = "0987654321",
                Email = "nguyenvana@example.com",
                ParentName = "Nguyễn Văn B",
                ParentPhone = "0912345678",
                Avatar = null // Sử dụng ảnh mặc định
            };

            LoadStudentInfo(student);
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút chỉnh sửa
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Cho phép chỉnh sửa các trường thông tin liên hệ
            txtAddress.Enabled = true;
            txtPhone.Enabled = true;
            txtEmail.Enabled = true;

            // Hiển thị nút lưu và hủy
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút lưu
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra và xác thực dữ liệu nhập vào
            if (!ValidateInput())
                return;

            // Cập nhật dữ liệu
            _currentStudent.Address = txtAddress.Text.Trim();
            _currentStudent.Phone = txtPhone.Text.Trim();
            _currentStudent.Email = txtEmail.Text.Trim();

            // Thông báo đã cập nhật thành công
            MessageBox.Show("Cập nhật thông tin liên hệ thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Phát sinh sự kiện thông tin học sinh đã được cập nhật
            StudentInfoUpdated?.Invoke(this, _currentStudent);

            // Trở về trạng thái chỉ đọc
            ExitEditMode();
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút hủy
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Khôi phục dữ liệu ban đầu
            txtAddress.Text = _currentStudent.Address;
            txtPhone.Text = _currentStudent.Phone;
            txtEmail.Text = _currentStudent.Email;

            // Trở về trạng thái chỉ đọc
            ExitEditMode();
        }

        /// <summary>
        /// Thoát khỏi chế độ chỉnh sửa
        /// </summary>
        private void ExitEditMode()
        {
            // Vô hiệu hóa các trường nhập liệu
            txtAddress.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;

            // Hiển thị lại nút chỉnh sửa
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Visible = true;
        }

        /// <summary>
        /// Xác thực dữ liệu nhập vào
        /// </summary>
        private bool ValidateInput()
        {
            // Kiểm tra địa chỉ
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return false;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return false;
            }

            // Kiểm tra định dạng số điện thoại
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return false;
            }

            // Kiểm tra email
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                MessageBox.Show("Định dạng email không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn đổi ảnh đại diện
        /// </summary>
        private void lblChangeAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh đại diện";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Đọc ảnh từ file đã chọn
                        picAvatar.Image = Image.FromFile(openFileDialog.FileName);

                        // Cập nhật ảnh đại diện cho học sinh
                        if (_currentStudent != null)
                            _currentStudent.Avatar = picAvatar.Image;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            pnlEdit.Controls.Add(btnSave);
            pnlEdit.Controls.Add(btnCancel);
        }
    }
}
