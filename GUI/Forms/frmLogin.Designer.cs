using System.Drawing;

namespace QuanLyTruongHoc
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pnlMainScreen = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2CircleButtonCloseLogin = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblForgotAcc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblError = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.chkShowPw = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtPW = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblLogin = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlMainScreen.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // pnlMainScreen
            // 
            this.pnlMainScreen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMainScreen.BackgroundImage = global::QuanLyTruongHoc.Properties.Resources.bg;
            this.pnlMainScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMainScreen.BorderColor = System.Drawing.Color.Gray;
            this.pnlMainScreen.BorderRadius = 6;
            this.pnlMainScreen.Controls.Add(this.guna2CircleButtonCloseLogin);
            this.pnlMainScreen.Controls.Add(this.guna2CustomGradientPanel1);
            this.pnlMainScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMainScreen.ForeColor = System.Drawing.Color.Transparent;
            this.pnlMainScreen.Location = new System.Drawing.Point(0, 0);
            this.pnlMainScreen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMainScreen.Name = "pnlMainScreen";
            this.pnlMainScreen.Size = new System.Drawing.Size(1200, 800);
            this.pnlMainScreen.TabIndex = 0;
            this.pnlMainScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainScreen_Paint);
            // 
            // guna2CircleButtonCloseLogin
            // 
            this.guna2CircleButtonCloseLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonCloseLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonCloseLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonCloseLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonCloseLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(92)))));
            this.guna2CircleButtonCloseLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButtonCloseLogin.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonCloseLogin.Location = new System.Drawing.Point(1168, 12);
            this.guna2CircleButtonCloseLogin.Name = "guna2CircleButtonCloseLogin";
            this.guna2CircleButtonCloseLogin.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButtonCloseLogin.Size = new System.Drawing.Size(20, 20);
            this.guna2CircleButtonCloseLogin.TabIndex = 4;
            this.guna2CircleButtonCloseLogin.Text = "guna2CircleButtonCloseLogin";
            this.guna2CircleButtonCloseLogin.Click += new System.EventHandler(this.guna2CircleButtonCloseLogin_Click);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BorderColor = System.Drawing.Color.Gray;
            this.guna2CustomGradientPanel1.BorderRadius = 10;
            this.guna2CustomGradientPanel1.BorderThickness = 1;
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2PictureBox1);
            this.guna2CustomGradientPanel1.Controls.Add(this.lblForgotAcc);
            this.guna2CustomGradientPanel1.Controls.Add(this.lblError);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2Button1);
            this.guna2CustomGradientPanel1.Controls.Add(this.chkShowPw);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtPW);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtUserName);
            this.guna2CustomGradientPanel1.Controls.Add(this.lblLogin);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(360, 100);
            this.guna2CustomGradientPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(480, 600);
            this.guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2PictureBox1.Image = global::QuanLyTruongHoc.Properties.Resources.school;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(205, 31);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(70, 70);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 7;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // lblForgotAcc
            // 
            this.lblForgotAcc.AutoSize = false;
            this.lblForgotAcc.BackColor = System.Drawing.Color.Transparent;
            this.lblForgotAcc.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotAcc.ForeColor = System.Drawing.Color.Black;
            this.lblForgotAcc.Location = new System.Drawing.Point(317, 381);
            this.lblForgotAcc.Name = "lblForgotAcc";
            this.lblForgotAcc.Size = new System.Drawing.Size(142, 30);
            this.lblForgotAcc.TabIndex = 6;
            this.lblForgotAcc.Text = "Forgot account?";
            // 
            // lblError
            // 
            this.lblError.AutoSize = false;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(3, 541);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(430, 47);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "** The username or password is incorrect, please re-operate. If you forgot your a" +
    "ccount, tap forgot account\r\n\r\n";
            this.lblError.Visible = false;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.BorderRadius = 25;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(59, 440);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(374, 52);
            this.guna2Button1.TabIndex = 4;
            this.guna2Button1.Text = "Login";
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // chkShowPw
            // 
            this.chkShowPw.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkShowPw.CheckedState.BorderRadius = 0;
            this.chkShowPw.CheckedState.BorderThickness = 0;
            this.chkShowPw.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.chkShowPw.CheckMarkColor = System.Drawing.Color.DimGray;
            this.chkShowPw.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowPw.ForeColor = System.Drawing.Color.Black;
            this.chkShowPw.Location = new System.Drawing.Point(51, 348);
            this.chkShowPw.Name = "chkShowPw";
            this.chkShowPw.Size = new System.Drawing.Size(143, 27);
            this.chkShowPw.TabIndex = 3;
            this.chkShowPw.Text = "Show password";
            this.chkShowPw.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkShowPw.UncheckedState.BorderRadius = 0;
            this.chkShowPw.UncheckedState.BorderThickness = 0;
            this.chkShowPw.UncheckedState.FillColor = System.Drawing.Color.LightGray;
            this.chkShowPw.CheckedChanged += new System.EventHandler(this.chbShowPw_CheckedChanged);
            // 
            // txtPW
            // 
            this.txtPW.Animated = true;
            this.txtPW.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.txtPW.BackColor = System.Drawing.Color.Transparent;
            this.txtPW.BorderRadius = 25;
            this.txtPW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPW.DefaultText = "";
            this.txtPW.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPW.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtPW.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPW.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPW.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPW.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPW.ForeColor = System.Drawing.Color.Black;
            this.txtPW.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPW.IconLeftSize = new System.Drawing.Size(50, 50);
            this.txtPW.IconRight = ((System.Drawing.Image)(resources.GetObject("txtPW.IconRight")));
            this.txtPW.IconRightOffset = new System.Drawing.Point(7, 0);
            this.txtPW.IconRightSize = new System.Drawing.Size(35, 35);
            this.txtPW.Location = new System.Drawing.Point(48, 260);
            this.txtPW.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtPW.Name = "txtPW";
            this.txtPW.PlaceholderText = "Password";
            this.txtPW.SelectedText = "";
            this.txtPW.Size = new System.Drawing.Size(374, 52);
            this.txtPW.TabIndex = 2;
            this.txtPW.TextOffset = new System.Drawing.Point(14, 0);
            this.txtPW.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Animated = true;
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.BorderRadius = 25;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUserName.ForeColor = System.Drawing.Color.Black;
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.IconLeftSize = new System.Drawing.Size(50, 50);
            this.txtUserName.IconRight = ((System.Drawing.Image)(resources.GetObject("txtUserName.IconRight")));
            this.txtUserName.IconRightOffset = new System.Drawing.Point(7, 0);
            this.txtUserName.IconRightSize = new System.Drawing.Size(35, 35);
            this.txtUserName.Location = new System.Drawing.Point(48, 179);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderText = "Username";
            this.txtUserName.SelectedText = "";
            this.txtUserName.Size = new System.Drawing.Size(374, 52);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.TextOffset = new System.Drawing.Point(14, 0);
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLogin.AutoSize = false;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.Black;
            this.lblLogin.Location = new System.Drawing.Point(181, 109);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(117, 51);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "LOGIN";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = global::QuanLyTruongHoc.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlMainScreen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.pnlMainScreen.ResumeLayout(false);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlMainScreen;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLogin;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private Guna.UI2.WinForms.Guna2TextBox txtPW;
        private Guna.UI2.WinForms.Guna2CheckBox chkShowPw;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblError;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblForgotAcc;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonCloseLogin;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}