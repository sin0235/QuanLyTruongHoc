using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void pnlMainScreen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (lblError.Visible)
            {
                lblError.Visible = false;
            }
        }

        private void chbShowPw_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPw.Checked)
            {
                txtPW.UseSystemPasswordChar = false;
            }
            else
            {
                txtPW.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "") // Điều kiện đăng nhập thành công
            {
                // Tạo hiệu ứng mờ dần cho form hiện tại
                System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer
                {
                    Interval = 10
                };
                double opacity = 1.0;

                fadeTimer.Tick += (s, args) =>
                {
                    opacity -= 0.05;
                    if (opacity <= 0)
                    {
                        fadeTimer.Stop();
                        this.Hide();


                        var newForm = openFormHS();
                        // Hiệu ứng hiện dần form mới
                        System.Windows.Forms.Timer fadeInTimer = new System.Windows.Forms.Timer
                        {
                            Interval = 10
                        };
                        double newOpacity = 0;

                        fadeInTimer.Tick += (s2, args2) =>
                        {
                            newOpacity += 0.05;
                            newForm.Opacity = newOpacity;
                            if (newOpacity >= 1)
                            {
                                fadeInTimer.Stop();

                            }
                        };

                        fadeInTimer.Start();
                    }
                    else
                    {
                        this.Opacity = opacity;
                    }
                };

                fadeTimer.Start();
            }
            else
            {
                this.lblError.Visible = true;
            }
        }

        private void guna2CircleButtonCloseLogin_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void txtPW_TextChanged(object sender, EventArgs e)
        {
            if (lblError.Visible)
            {
                lblError.Visible = false;
            }
        }

        private frmHS openFormHS()
        {
            frmHS hsForm = new frmHS
            {
                Opacity = 0
            };
            hsForm.Show();
            return hsForm;
        }
    }
}
