using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmChangePW : Form
    {
        public frmChangePW()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            // Thiết lập khả năng di chuyển form
            pnlTitleBar.MouseDown += PnlTitleBar_MouseDown;
            lblFormTitle.MouseDown += PnlTitleBar_MouseDown;

            // Gán sự kiện cho các nút
            guna2CircleButtonClose.Click += (s, e) => this.Close();
            guna2CircleButtonMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // Hiệu ứng hover cho nút đổi mật khẩu
            btnChangePassword.MouseEnter += (s, e) =>
            {
                btnChangePassword.FillColor = System.Drawing.Color.FromArgb(124, 168, 255);
            };

            btnChangePassword.MouseLeave += (s, e) =>
            {
                btnChangePassword.FillColor = System.Drawing.Color.FromArgb(94, 148, 255);
            };

            // Tạo hiệu ứng hiển thị/ẩn mật khẩu
            AddPasswordToggle(txtCurrentPassword);
            AddPasswordToggle(txtNewPassword);
            AddPasswordToggle(txtConfirmPassword);

            // Kiểm tra khớp mật khẩu khi nhập
            txtConfirmPassword.TextChanged += TxtConfirmPassword_TextChanged;
            txtNewPassword.TextChanged += TxtNewPassword_TextChanged;
        }

        private void PnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Cho phép kéo thả form
                ReleaseCapture();
                SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }

        // Hàm hỗ trợ di chuyển form
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void AddPasswordToggle(Guna2TextBox textBox)
        {
            // Tạo nút hiển thị/ẩn mật khẩu
            Guna2Button toggleButton = new Guna2Button();
            toggleButton.Size = new Size(30, 30);
            toggleButton.FillColor = Color.Transparent;
            toggleButton.Image = Properties.Resources.eye_closed; // Thêm hình ảnh vào Resources
            toggleButton.ImageSize = new Size(20, 20);
            toggleButton.Cursor = Cursors.Hand;

            // Đặt nút vào bên phải textBox
            toggleButton.Location = new Point(textBox.Width - 35, (textBox.Height - 30) / 2);
            toggleButton.Anchor = AnchorStyles.Right;

            textBox.Controls.Add(toggleButton);

            // Xử lý sự kiện click để hiển thị/ẩn mật khẩu
            bool passwordVisible = false;
            toggleButton.Click += (s, e) =>
            {
                passwordVisible = !passwordVisible;
                textBox.PasswordChar = passwordVisible ? '\0' : '●';
                toggleButton.Image = passwordVisible ?
                    Properties.Resources.eye_open : Properties.Resources.eye_closed;
            };
        }

        private void TxtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xác nhận mật khẩu
            if (txtConfirmPassword.Text.Length > 0)
            {
                if (txtConfirmPassword.Text != txtNewPassword.Text)
                {
                    lblPasswordHint.Text = "Mật khẩu xác nhận không khớp";
                    lblPasswordHint.ForeColor = Color.Red;
                }
                else
                {
                    lblPasswordHint.Text = "Mật khẩu xác nhận khớp";
                    lblPasswordHint.ForeColor = Color.Green;
                }
            }
        }

        private void TxtNewPassword_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra độ mạnh của mật khẩu
            string password = txtNewPassword.Text;

            if (password.Length == 0)
            {
                lblPasswordHint.Text = "Mật khẩu phải có ít nhất 8 ký tự bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt";
                lblPasswordHint.ForeColor = Color.Gray;
                return;
            }

            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(c => !char.IsLetterOrDigit(c));

            if (password.Length < 8)
            {
                lblPasswordHint.Text = "Mật khẩu quá ngắn (tối thiểu 8 ký tự)";
                lblPasswordHint.ForeColor = Color.Red;
            }
            else if (!hasUpperCase || !hasLowerCase || !hasDigit || !hasSpecialChar)
            {
                lblPasswordHint.Text = "Mật khẩu phải có chữ hoa, chữ thường, số và ký tự đặc biệt";
                lblPasswordHint.ForeColor = Color.Orange;
            }
            else
            {
                lblPasswordHint.Text = "Mật khẩu mạnh";
                lblPasswordHint.ForeColor = Color.Green;
            }

            // Kiểm tra lại với xác nhận mật khẩu
            if (txtConfirmPassword.Text.Length > 0)
            {
                if (txtConfirmPassword.Text != password)
                {
                    lblPasswordHint.Text = "Mật khẩu xác nhận không khớp";
                    lblPasswordHint.ForeColor = Color.Red;
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Hiện hộp thoại xác nhận
            if (string.IsNullOrEmpty(txtCurrentPassword.Text) ||
                string.IsNullOrEmpty(txtNewPassword.Text) ||
                string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra mật khẩu cũ trước khi đổi (Logic thực tế sẽ kiểm tra với CSDL)
            if (CheckOldPassword(txtCurrentPassword.Text))
            {
                // Thực hiện đổi mật khẩu
                if (ChangePassword(txtNewPassword.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức kiểm tra mật khẩu cũ (Cần thay thế bằng logic thực tế)
        private bool CheckOldPassword(string password)
        {
            // TO-DO: Kiểm tra mật khẩu cũ với CSDL
            return true; // Tạm thời cho kết quả true
        }

        // Phương thức thay đổi mật khẩu (Cần thay thế bằng logic thực tế)
        private bool ChangePassword(string newPassword)
        {
            // TO-DO: Cập nhật mật khẩu mới vào CSDL
            return true; // Tạm thời cho kết quả true
        }
    }
}
