using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucInfoHS : UserControl
    {
        // Sự kiện khi thông tin học sinh được cập nhật
        public event EventHandler<ThongTinHSDTO> StudentInfoUpdated;

        // Dữ liệu học sinh hiện tại
        private ThongTinHSDTO _currentStudent;

        // Đối tượng thao tác với CSDL học sinh
        private HocSinhDAL _hocSinhDAL;
        private readonly int _maHS; // Mã học sinh

        public ucInfoHS(int maHS)
        {
            InitializeComponent();
            _hocSinhDAL = new HocSinhDAL();
            _maHS = maHS;

            // Đăng ký sự kiện Load
            this.Load += ucInfoHS_Load;
        }

        private void ucInfoHS_Load(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị trạng thái đang tải
                this.Cursor = Cursors.WaitCursor;

                // Tải dữ liệu dưới dạng Task để không làm đơ giao diện
                Task.Run(() => _hocSinhDAL.GetStudentById(_maHS))
                    .ContinueWith(task =>
                    {
                        if (this.IsDisposed || !this.IsHandleCreated) return;

                        this.Invoke(new Action(() =>
                        {
                            try
                            {
                                var student = task.Result;
                                if (student != null)
                                {
                                    // Hiển thị thông tin học sinh lên giao diện
                                    LoadStudentInfo(student);
                                }
                                else
                                {
                                    MessageBox.Show($"Không tìm thấy thông tin học sinh có mã {_maHS}.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi hiển thị thông tin học sinh: {ex.Message}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Console.WriteLine($"Chi tiết lỗi: {ex}");
                            }
                            finally
                            {
                                // Khôi phục con trỏ
                                this.Cursor = Cursors.Default;
                            }
                        }));
                    });
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show($"Lỗi khi tải thông tin học sinh: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Chi tiết lỗi: {ex}");
            }
        }

        /// <summary>
        /// Load thông tin học sinh từ CSDL theo mã học sinh
        /// </summary>
        /// <param name="maHS">Mã học sinh cần load</param>
        /// <returns>True nếu load thành công, false nếu thất bại</returns>
        public bool LoadStudentById(int maHS)
        {
            try
            {
                // Log để debug
                Console.WriteLine($"Đang tải thông tin học sinh với mã: {maHS}");

                // Hiển thị trạng thái đang tải
                this.Cursor = Cursors.WaitCursor;

                // Gọi phương thức từ HocSinhDAL để lấy thông tin học sinh
                ThongTinHSDTO student = _hocSinhDAL.GetStudentById(maHS);

                if (student != null)
                {
                    // Hiển thị thông tin học sinh lên giao diện
                    LoadStudentInfo(student);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong LoadStudentById: {ex.Message}");
                throw;
            }
            finally
            {
                // Khôi phục con trỏ
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Tải dữ liệu học sinh vào control
        /// </summary>
        /// <param name="student">Thông tin học sinh</param>
        public void LoadStudentInfo(ThongTinHSDTO student)
        {
            if (student == null)
                return;

            _currentStudent = student;

            lblFullName.Text = !string.IsNullOrEmpty(student.FullName) ? student.FullName : "-----";
            lblStudentId.Text = $"Mã HS: {(!string.IsNullOrEmpty(student.StudentId) ? student.StudentId : "-----")}";
            lblClass.Text = $"Lớp: {(!string.IsNullOrEmpty(student.ClassName) ? student.ClassName : "-----")}";
            lblIdentityCode.Text = $"Mã định danh: {(!string.IsNullOrEmpty(student.IdentityCode) ? student.IdentityCode : "-----")}";

            // Hiển thị thông tin bổ sung
            lblGender.Text = $"Giới tính: {(!string.IsNullOrEmpty(student.Gender) ? student.Gender : "-----")}";
            lblDOB.Text = $"Ngày sinh: {student.DateOfBirth.ToString("dd/MM/yyyy")}";
            lblPlaceOfBirth.Text = $"Nơi sinh: {(!string.IsNullOrEmpty(student.PlaceOfBirth) ? student.PlaceOfBirth : "-----")}";
            lblEthnicity.Text = $"Dân tộc: {(!string.IsNullOrEmpty(student.Ethnicity) ? student.Ethnicity : "-----")}";
            lblReligion.Text = $"Tôn giáo: {(!string.IsNullOrEmpty(student.Religion) ? student.Religion : "-----")}";

            // Hiển thị thông tin liên hệ (có thể chỉnh sửa)
            txtAddress.Text = !string.IsNullOrEmpty(student.Address) ? student.Address : "-----";
            txtPhone.Text = !string.IsNullOrEmpty(student.Phone) ? student.Phone : "-----";
            txtEmail.Text = !string.IsNullOrEmpty(student.Email) ? student.Email : "-----";

            // Hiển thị thông tin người liên hệ khẩn cấp
            txtHoTenCha.Text = !string.IsNullOrEmpty(student.FatherName) ? student.FatherName : "-----";
            txtSoDienThoaiCha.Text = !string.IsNullOrEmpty(student.FatherPhone) ? student.FatherPhone : "-----";
            txtHoTenMe.Text = !string.IsNullOrEmpty(student.MotherName) ? student.MotherName : "-----";
            txtSDTMe.Text = !string.IsNullOrEmpty(student.MotherPhone) ? student.MotherPhone : "-----";

            // Hiển thị ảnh đại diện nếu có
            picAvatar.Image = student.Avatar ?? Properties.Resources.defautAvatar;

            // Vô hiệu hóa các trường nhập liệu khi mới load thông tin
            SetEditableFields(false);
        }

        /// <summary>
        /// Thiết lập trạng thái cho các trường có thể chỉnh sửa
        /// </summary>
        /// <param name="isEditable">True nếu cho phép chỉnh sửa, False nếu không</param>
        private void SetEditableFields(bool isEditable)
        {
            txtAddress.Enabled = isEditable;
            txtPhone.Enabled = isEditable;
            //txtEmail.Enabled = isEditable;
            //txtSoDienThoaiCha.Enabled = isEditable;
            //txtSDTMe.Enabled = isEditable;
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút chỉnh sửa
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            pnlEdit.Controls.Add(btnSave);
            pnlEdit.Controls.Add(btnCancel);

            // Cho phép chỉnh sửa các trường thông tin liên hệ
            SetEditableFields(true);

            // Hiển thị nút lưu và hủy
            this.pnlEdit.Controls.Remove(btnEdit);
            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút lưu
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra và xác thực dữ liệu nhập vào
            if (!ValidateInput())
                return;

            try
            {
                // Lưu lại giá trị cũ để khôi phục nếu cập nhật thất bại
                string oldAddress = _currentStudent.Address;
                string oldPhone = _currentStudent.Phone;
                //string oldEmail = _currentStudent.Email;
                //string oldMotherPhone = _currentStudent.MotherPhone;
                //string oldFatherPhone = _currentStudent.FatherPhone;

                // Cập nhật dữ liệu
                _currentStudent.Address = txtAddress.Text.Trim() == "-----" ? null : txtAddress.Text.Trim();
                _currentStudent.Phone = txtPhone.Text.Trim() == "-----" ? null : txtPhone.Text.Trim();
                //_currentStudent.Email = txtEmail.Text.Trim() == "-----" ? null : txtEmail.Text.Trim();
                //_currentStudent.MotherPhone = txtSDTMe.Text.Trim() == "-----" ? null : txtSDTMe.Text.Trim();
                //_currentStudent.FatherPhone = txtSoDienThoaiCha.Text.Trim() == "-----" ? null : txtSoDienThoaiCha.Text.Trim();

                // Thực hiện cập nhật thông tin học sinh trong Task riêng
                Task.Run(() => _hocSinhDAL.UpdateStudentBasicInfo(_currentStudent))
                    .ContinueWith(task =>
                    {
                        if (this.IsDisposed || !this.IsHandleCreated) return;

                        this.Invoke(new Action(() =>
                        {
                            bool updateResult = task.Result;

                            if (updateResult)
                            {
                                // Thông báo đã cập nhật thành công
                                MessageBox.Show("Cập nhật thông tin liên hệ thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Phát sinh sự kiện thông tin học sinh đã được cập nhật
                                StudentInfoUpdated?.Invoke(this, _currentStudent);
                            }
                            else
                            {
                                // Khôi phục dữ liệu cũ nếu cập nhật thất bại
                                _currentStudent.Address = oldAddress;
                                _currentStudent.Phone = oldPhone;
                                //_currentStudent.Email = oldEmail;
                                //_currentStudent.MotherPhone = oldMotherPhone;
                                //_currentStudent.FatherPhone = oldFatherPhone;

                                // Hiển thị lại các giá trị cũ trên giao diện
                                txtAddress.Text = oldAddress ?? "-----";
                                txtPhone.Text = oldPhone ?? "-----";
                                //txtEmail.Text = oldEmail ?? "-----";
                                //txtSDTMe.Text = oldMotherPhone ?? "-----";
                                //txtSoDienThoaiCha.Text = oldFatherPhone ?? "-----";

                                MessageBox.Show("Không thể cập nhật thông tin vào cơ sở dữ liệu!", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            ExitEditMode();
                        }));
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ExitEditMode();
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút hủy
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Khôi phục dữ liệu ban đầu
            txtAddress.Text = _currentStudent.Address ?? "-----";
            txtPhone.Text = _currentStudent.Phone ?? "-----";
            //txtEmail.Text = _currentStudent.Email ?? "-----";
            //txtSDTMe.Text = _currentStudent.MotherPhone ?? "-----";
            //txtSoDienThoaiCha.Text = _currentStudent.FatherPhone ?? "-----";
            ExitEditMode();
        }

        /// <summary>
        /// Thoát khỏi chế độ chỉnh sửa
        /// </summary>
        private void ExitEditMode()
        {
            // Vô hiệu hóa các trường nhập liệu
            SetEditableFields(false);

            // Ẩn nút lưu và hủy
            pnlEdit.Controls.Remove(btnSave);
            pnlEdit.Controls.Remove(btnCancel);
            pnlEdit.Controls.Add(btnEdit);

            // Loại bỏ các xử lý sự kiện để tránh đăng ký nhiều lần
            btnSave.Click -= btnSave_Click;
            btnCancel.Click -= btnCancel_Click;
        }

        /// <summary>
        /// Xác thực dữ liệu nhập vào
        /// </summary>
        /// <summary>
        /// Xác thực dữ liệu nhập vào
        /// </summary>
        private bool ValidateInput()
        {
            // Kiểm tra địa chỉ
            if (string.IsNullOrWhiteSpace(txtAddress.Text) || txtAddress.Text == "-----")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return false;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || txtPhone.Text == "-----")
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

            // Kiểm tra định dạng số điện thoại của cha (nếu có)
            if (!string.IsNullOrWhiteSpace(txtSoDienThoaiCha.Text) && txtSoDienThoaiCha.Text != "-----" &&
                !System.Text.RegularExpressions.Regex.IsMatch(txtSoDienThoaiCha.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại của cha phải có 10 chữ số!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoaiCha.Focus();
                return false;
            }

            // Kiểm tra định dạng số điện thoại của mẹ (nếu có)
            if (!string.IsNullOrWhiteSpace(txtSDTMe.Text) && txtSDTMe.Text != "-----" &&
                !System.Text.RegularExpressions.Regex.IsMatch(txtSDTMe.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại của mẹ phải có 10 chữ số!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDTMe.Focus();
                return false;
            }

            // Kiểm tra email
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && txtEmail.Text != "-----" &&
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
        private void lblChangeAvatar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
                        Image newImage = Image.FromFile(openFileDialog.FileName);

                        // Cập nhật ảnh đại diện cho học sinh
                        if (_currentStudent != null)
                        {
                            // Thực hiện lưu ảnh đại diện trong Task riêng
                            this.Cursor = Cursors.WaitCursor;

                            Task.Run(() => _hocSinhDAL.SaveStudentAvatar(Convert.ToInt32(_currentStudent.StudentId), newImage))
                                .ContinueWith(task =>
                                {
                                    if (this.IsDisposed || !this.IsHandleCreated) return;

                                    this.Invoke(new Action(() =>
                                    {
                                        this.Cursor = Cursors.Default;

                                        if (task.Result)
                                        {
                                            // Cập nhật ảnh trong object và hiển thị
                                            _currentStudent.Avatar = newImage;
                                            picAvatar.Image = newImage;

                                            MessageBox.Show("Cập nhật ảnh đại diện thành công!", "Thông báo",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            // Phát sinh sự kiện thông tin học sinh đã được cập nhật
                                            StudentInfoUpdated?.Invoke(this, _currentStudent);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Không thể lưu ảnh đại diện vào cơ sở dữ liệu!", "Lỗi",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }));
                                });
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Làm mới thông tin học sinh từ CSDL
        /// </summary>
        public void RefreshStudentInfo()
        {
            if (_currentStudent != null && !string.IsNullOrEmpty(_currentStudent.StudentId))
            {
                LoadStudentById(Convert.ToInt32(_currentStudent.StudentId));
            }
        }
    }
}
