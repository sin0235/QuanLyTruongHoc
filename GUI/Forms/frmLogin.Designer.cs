using Guna.UI2.WinForms;
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
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlMainScreen = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblSchoolName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CircleButtonCloseLogin = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pnlLogin = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.picLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblForgotAcc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblError = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.chkShowPw = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtPW = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblLogin = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblWelcomeText = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSystemName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnFacebook = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnTwitter = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnInstagram = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lblCopyright = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.pnlMainScreen.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.pnlMainScreen;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // pnlMainScreen
            // 
            this.pnlMainScreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlMainScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMainScreen.BorderRadius = 15;
            this.pnlMainScreen.Controls.Add(this.lblSchoolName);
            this.pnlMainScreen.Controls.Add(this.guna2CircleButtonCloseLogin);
            this.pnlMainScreen.Controls.Add(this.pnlLogin);
            this.pnlMainScreen.Controls.Add(this.lblWelcomeText);
            this.pnlMainScreen.Controls.Add(this.lblSystemName);
            this.pnlMainScreen.Controls.Add(this.btnFacebook);
            this.pnlMainScreen.Controls.Add(this.btnTwitter);
            this.pnlMainScreen.Controls.Add(this.btnInstagram);
            this.pnlMainScreen.Controls.Add(this.lblCopyright);
            this.pnlMainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainScreen.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(219)))));
            this.pnlMainScreen.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(222)))), ((int)(((byte)(235)))));
            this.pnlMainScreen.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.pnlMainScreen.Location = new System.Drawing.Point(0, 0);
            this.pnlMainScreen.Name = "pnlMainScreen";
            this.pnlMainScreen.Size = new System.Drawing.Size(1200, 800);
            this.pnlMainScreen.TabIndex = 0;
            this.pnlMainScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainScreen_Paint);
            // 
            // lblSchoolName
            // 
            this.lblSchoolName.BackColor = System.Drawing.Color.Transparent;
            this.lblSchoolName.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblSchoolName.ForeColor = System.Drawing.Color.White;
            this.lblSchoolName.Location = new System.Drawing.Point(50, 360);
            this.lblSchoolName.Name = "lblSchoolName";
            this.lblSchoolName.Size = new System.Drawing.Size(472, 69);
            this.lblSchoolName.TabIndex = 8;
            this.lblSchoolName.Text = "TRƯỜNG THPT ABC";
            this.lblSchoolName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2CircleButtonCloseLogin
            // 
            this.guna2CircleButtonCloseLogin.Animated = true;
            this.guna2CircleButtonCloseLogin.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButtonCloseLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonCloseLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonCloseLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonCloseLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonCloseLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(92)))));
            this.guna2CircleButtonCloseLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButtonCloseLogin.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonCloseLogin.Location = new System.Drawing.Point(1158, 15);
            this.guna2CircleButtonCloseLogin.Name = "guna2CircleButtonCloseLogin";
            this.guna2CircleButtonCloseLogin.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButtonCloseLogin.Size = new System.Drawing.Size(25, 25);
            this.guna2CircleButtonCloseLogin.TabIndex = 4;
            this.guna2CircleButtonCloseLogin.Click += new System.EventHandler(this.guna2CircleButtonCloseLogin_Click);
            // 
            // pnlLogin
            // 
            this.pnlLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLogin.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlLogin.BorderRadius = 30;
            this.pnlLogin.Controls.Add(this.guna2Separator1);
            this.pnlLogin.Controls.Add(this.picLogo);
            this.pnlLogin.Controls.Add(this.lblForgotAcc);
            this.pnlLogin.Controls.Add(this.lblError);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.chkShowPw);
            this.pnlLogin.Controls.Add(this.txtPW);
            this.pnlLogin.Controls.Add(this.txtUserName);
            this.pnlLogin.Controls.Add(this.lblLogin);
            this.pnlLogin.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlLogin.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.pnlLogin.Location = new System.Drawing.Point(660, 100);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.ShadowDecoration.BorderRadius = 30;
            this.pnlLogin.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlLogin.ShadowDecoration.Depth = 50;
            this.pnlLogin.ShadowDecoration.Enabled = true;
            this.pnlLogin.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(8, 8, 16, 16);
            this.pnlLogin.Size = new System.Drawing.Size(480, 600);
            this.pnlLogin.TabIndex = 0;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(48, 164);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(374, 10);
            this.guna2Separator1.TabIndex = 8;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::QuanLyTruongHoc.Properties.Resources.school;
            this.picLogo.ImageRotate = 0F;
            this.picLogo.Location = new System.Drawing.Point(195, 30);
            this.picLogo.Name = "picLogo";
            this.picLogo.ShadowDecoration.BorderRadius = 50;
            this.picLogo.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(188)))), ((int)(((byte)(219)))));
            this.picLogo.ShadowDecoration.Depth = 15;
            this.picLogo.ShadowDecoration.Enabled = true;
            this.picLogo.Size = new System.Drawing.Size(90, 90);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 7;
            this.picLogo.TabStop = false;
            this.picLogo.UseTransparentBackground = true;
            // 
            // lblForgotAcc
            // 
            this.lblForgotAcc.AutoSize = false;
            this.lblForgotAcc.BackColor = System.Drawing.Color.Transparent;
            this.lblForgotAcc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgotAcc.Font = new System.Drawing.Font("Segoe UI", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
            this.lblForgotAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
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
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(48, 505);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(374, 75);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "** The username or password is incorrect, please try again.";
            this.lblError.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.lblError.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Animated = true;
            this.btnLogin.BorderRadius = 25;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            this.btnLogin.Location = new System.Drawing.Point(48, 440);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(374, 52);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chkShowPw
            // 
            this.chkShowPw.AutoSize = true;
            this.chkShowPw.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.chkShowPw.CheckedState.BorderRadius = 2;
            this.chkShowPw.CheckedState.BorderThickness = 0;
            this.chkShowPw.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.chkShowPw.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkShowPw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.chkShowPw.Location = new System.Drawing.Point(51, 348);
            this.chkShowPw.Name = "chkShowPw";
            this.chkShowPw.Size = new System.Drawing.Size(149, 27);
            this.chkShowPw.TabIndex = 3;
            this.chkShowPw.Text = "Show password";
            this.chkShowPw.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chkShowPw.UncheckedState.BorderRadius = 2;
            this.chkShowPw.UncheckedState.BorderThickness = 1;
            this.chkShowPw.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkShowPw.CheckedChanged += new System.EventHandler(this.chbShowPw_CheckedChanged);
            // 
            // txtPW
            // 
            this.txtPW.Animated = true;
            this.txtPW.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.txtPW.BackColor = System.Drawing.Color.Transparent;
            this.txtPW.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.txtPW.BorderRadius = 25;
            this.txtPW.BorderThickness = 2;
            this.txtPW.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPW.DefaultText = "";
            this.txtPW.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPW.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtPW.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPW.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPW.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.txtPW.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.txtPW.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtPW.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.txtPW.IconRight = ((System.Drawing.Image)(resources.GetObject("txtPW.IconRight")));
            this.txtPW.IconRightOffset = new System.Drawing.Point(7, 0);
            this.txtPW.IconRightSize = new System.Drawing.Size(28, 28);
            this.txtPW.Location = new System.Drawing.Point(48, 260);
            this.txtPW.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtPW.Name = "txtPW";
            this.txtPW.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtPW.PlaceholderText = "Password";
            this.txtPW.SelectedText = "";
            this.txtPW.Size = new System.Drawing.Size(374, 52);
            this.txtPW.TabIndex = 2;
            this.txtPW.TextOffset = new System.Drawing.Point(14, 0);
            this.txtPW.UseSystemPasswordChar = true;
            this.txtPW.TextChanged += new System.EventHandler(this.txtPW_TextChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.Animated = true;
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.txtUserName.BorderRadius = 25;
            this.txtUserName.BorderThickness = 2;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.txtUserName.IconRight = ((System.Drawing.Image)(resources.GetObject("txtUserName.IconRight")));
            this.txtUserName.IconRightOffset = new System.Drawing.Point(7, 0);
            this.txtUserName.IconRightSize = new System.Drawing.Size(28, 28);
            this.txtUserName.Location = new System.Drawing.Point(48, 190);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtUserName.PlaceholderText = "Username";
            this.txtUserName.SelectedText = "";
            this.txtUserName.Size = new System.Drawing.Size(374, 52);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.TextOffset = new System.Drawing.Point(14, 0);
            //this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // lblLogin
            // 
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.lblLogin.Location = new System.Drawing.Point(190, 126);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(117, 52);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "LOGIN";
            // 
            // lblWelcomeText
            // 
            this.lblWelcomeText.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeText.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblWelcomeText.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeText.Location = new System.Drawing.Point(50, 320);
            this.lblWelcomeText.Name = "lblWelcomeText";
            this.lblWelcomeText.Size = new System.Drawing.Size(146, 39);
            this.lblWelcomeText.TabIndex = 9;
            this.lblWelcomeText.Text = "Welcome to";
            this.lblWelcomeText.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSystemName
            // 
            this.lblSystemName.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Italic);
            this.lblSystemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblSystemName.Location = new System.Drawing.Point(50, 430);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(278, 33);
            this.lblSystemName.TabIndex = 10;
            this.lblSystemName.Text = "School Management System";
            this.lblSystemName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFacebook
            // 
            this.btnFacebook.BackColor = System.Drawing.Color.Transparent;
            this.btnFacebook.CheckedState.ImageSize = new System.Drawing.Size(32, 32);
            this.btnFacebook.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnFacebook.Image = global::QuanLyTruongHoc.Properties.Resources.facebook;
            this.btnFacebook.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnFacebook.ImageRotate = 0F;
            this.btnFacebook.ImageSize = new System.Drawing.Size(28, 28);
            this.btnFacebook.Location = new System.Drawing.Point(50, 730);
            this.btnFacebook.Name = "btnFacebook";
            this.btnFacebook.PressedState.ImageSize = new System.Drawing.Size(28, 28);
            this.btnFacebook.Size = new System.Drawing.Size(40, 40);
            this.btnFacebook.TabIndex = 11;
            // 
            // btnTwitter
            // 
            this.btnTwitter.BackColor = System.Drawing.Color.Transparent;
            this.btnTwitter.CheckedState.ImageSize = new System.Drawing.Size(32, 32);
            this.btnTwitter.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnTwitter.Image = global::QuanLyTruongHoc.Properties.Resources.twitter;
            this.btnTwitter.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnTwitter.ImageRotate = 0F;
            this.btnTwitter.ImageSize = new System.Drawing.Size(28, 28);
            this.btnTwitter.Location = new System.Drawing.Point(100, 730);
            this.btnTwitter.Name = "btnTwitter";
            this.btnTwitter.PressedState.ImageSize = new System.Drawing.Size(28, 28);
            this.btnTwitter.Size = new System.Drawing.Size(40, 40);
            this.btnTwitter.TabIndex = 12;
            // 
            // btnInstagram
            // 
            this.btnInstagram.BackColor = System.Drawing.Color.Transparent;
            this.btnInstagram.CheckedState.ImageSize = new System.Drawing.Size(32, 32);
            this.btnInstagram.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnInstagram.Image = global::QuanLyTruongHoc.Properties.Resources.instagram;
            this.btnInstagram.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnInstagram.ImageRotate = 0F;
            this.btnInstagram.ImageSize = new System.Drawing.Size(28, 28);
            this.btnInstagram.Location = new System.Drawing.Point(150, 730);
            this.btnInstagram.Name = "btnInstagram";
            this.btnInstagram.PressedState.ImageSize = new System.Drawing.Size(28, 28);
            this.btnInstagram.Size = new System.Drawing.Size(40, 40);
            this.btnInstagram.TabIndex = 13;
            // 
            // lblCopyright
            // 
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblCopyright.Location = new System.Drawing.Point(50, 775);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(262, 22);
            this.lblCopyright.TabIndex = 14;
            this.lblCopyright.Text = "© 2025 ABC School. All rights reserved.";
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlMainScreen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Management System";
            this.pnlMainScreen.ResumeLayout(false);
            this.pnlMainScreen.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlMainScreen;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLogin;
        private Guna2HtmlLabel lblSchoolName;
        private Guna2DragControl guna2DragControl1;
        private Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private Guna.UI2.WinForms.Guna2TextBox txtPW;
        private Guna.UI2.WinForms.Guna2CheckBox chkShowPw;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblError;
        private Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblForgotAcc;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonCloseLogin;
        private Guna2CustomGradientPanel pnlLogin;
        private Guna2Separator guna2Separator1;
        private Guna2PictureBox picLogo;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;

        // 2. Add these new UI components to the class
        private Guna.UI2.WinForms.Guna2HtmlLabel lblWelcomeText;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSystemName;
        private Guna.UI2.WinForms.Guna2ImageButton btnFacebook;
        private Guna.UI2.WinForms.Guna2ImageButton btnTwitter;
        private Guna.UI2.WinForms.Guna2ImageButton btnInstagram;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCopyright;
    }
}