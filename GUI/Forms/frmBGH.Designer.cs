﻿namespace QuanLyTruongHoc
{
    partial class frmBGH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBGH));
            this.pnlTitleBar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFormTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CircleButtonClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButtonMaximize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButtonMinimize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pnlLeft = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnlMenu = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuiThu = new Guna.UI2.WinForms.Guna2Button();
            this.btnQuanLyHeThong = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLogo = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblSchoolName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlMainScreen = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnlTop = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblPageTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUserName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picUserAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.pnlTitleBar.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlMainScreen.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(165)))), ((int)(((byte)(230)))));
            this.pnlTitleBar.Controls.Add(this.lblFormTitle);
            this.pnlTitleBar.Controls.Add(this.guna2CircleButtonClose);
            this.pnlTitleBar.Controls.Add(this.guna2CircleButtonMaximize);
            this.pnlTitleBar.Controls.Add(this.guna2CircleButtonMinimize);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(1920, 40);
            this.pnlTitleBar.TabIndex = 0;
            this.pnlTitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTitleBar_Paint);
            this.pnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2PanelTitleBar_MouseDown);
            this.pnlTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.guna2PanelTitleBar_MouseMove);
            this.pnlTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.guna2PanelTitleBar_MouseUp);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lblFormTitle.Location = new System.Drawing.Point(12, 8);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(192, 30);
            this.lblFormTitle.TabIndex = 4;
            this.lblFormTitle.Text = "Quản Lý Trường Học";
            // 
            // guna2CircleButtonClose
            // 
            this.guna2CircleButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CircleButtonClose.BorderThickness = 1;
            this.guna2CircleButtonClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.guna2CircleButtonClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButtonClose.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonClose.Location = new System.Drawing.Point(1879, 10);
            this.guna2CircleButtonClose.Name = "guna2CircleButtonClose";
            this.guna2CircleButtonClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButtonClose.Size = new System.Drawing.Size(18, 18);
            this.guna2CircleButtonClose.TabIndex = 3;
            this.guna2CircleButtonClose.Click += new System.EventHandler(this.guna2CircleButtonClose_Click);
            this.guna2CircleButtonClose.MouseEnter += new System.EventHandler(this.guna2CircleButtonClose_MouseEnter);
            this.guna2CircleButtonClose.MouseLeave += new System.EventHandler(this.guna2CircleButtonClose_MouseLeave);
            // 
            // guna2CircleButtonMaximize
            // 
            this.guna2CircleButtonMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CircleButtonMaximize.BorderThickness = 1;
            this.guna2CircleButtonMaximize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonMaximize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonMaximize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonMaximize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonMaximize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(221)))), ((int)(((byte)(160)))));
            this.guna2CircleButtonMaximize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButtonMaximize.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonMaximize.Location = new System.Drawing.Point(1853, 10);
            this.guna2CircleButtonMaximize.Name = "guna2CircleButtonMaximize";
            this.guna2CircleButtonMaximize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButtonMaximize.Size = new System.Drawing.Size(18, 18);
            this.guna2CircleButtonMaximize.TabIndex = 1;
            this.guna2CircleButtonMaximize.Click += new System.EventHandler(this.guna2CircleButtonMaximize_Click);
            this.guna2CircleButtonMaximize.MouseEnter += new System.EventHandler(this.guna2CircleButtonMaximize_MouseEnter);
            this.guna2CircleButtonMaximize.MouseLeave += new System.EventHandler(this.guna2CircleButtonMaximize_MouseLeave);
            // 
            // guna2CircleButtonMinimize
            // 
            this.guna2CircleButtonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2CircleButtonMinimize.BorderThickness = 1;
            this.guna2CircleButtonMinimize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonMinimize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButtonMinimize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButtonMinimize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButtonMinimize.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(239)))), ((int)(((byte)(178)))));
            this.guna2CircleButtonMinimize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButtonMinimize.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButtonMinimize.Location = new System.Drawing.Point(1827, 10);
            this.guna2CircleButtonMinimize.Name = "guna2CircleButtonMinimize";
            this.guna2CircleButtonMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButtonMinimize.Size = new System.Drawing.Size(18, 18);
            this.guna2CircleButtonMinimize.TabIndex = 2;
            this.guna2CircleButtonMinimize.Click += new System.EventHandler(this.guna2CircleButtonMinimize_Click);
            this.guna2CircleButtonMinimize.MouseEnter += new System.EventHandler(this.guna2CircleButtonMinimize_MouseEnter);
            this.guna2CircleButtonMinimize.MouseLeave += new System.EventHandler(this.guna2CircleButtonMinimize_MouseLeave);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 18;
            this.guna2Elipse1.TargetControl = this;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.pnlLeft.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(210)))));
            this.pnlLeft.BorderThickness = 1;
            this.pnlLeft.Controls.Add(this.pnlMenu);
            this.pnlLeft.Controls.Add(this.pnlLogo);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.pnlLeft.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(165)))), ((int)(((byte)(225)))));
            this.pnlLeft.Location = new System.Drawing.Point(0, 40);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(280, 1040);
            this.pnlLeft.TabIndex = 1;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.pnlMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(210)))));
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnGuiThu);
            this.pnlMenu.Controls.Add(this.btnQuanLyHeThong);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.pnlMenu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(165)))), ((int)(((byte)(225)))));
            this.pnlMenu.Location = new System.Drawing.Point(0, 160);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.pnlMenu.Size = new System.Drawing.Size(280, 880);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BorderRadius = 10;
            this.btnSettings.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSettings.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettings.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSettings.FillColor = System.Drawing.Color.Transparent;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnSettings.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSettings.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnSettings.ImageSize = new System.Drawing.Size(24, 24);
            this.btnSettings.Location = new System.Drawing.Point(10, 825);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(260, 55);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Cài đặt";
            this.btnSettings.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSettings.TextOffset = new System.Drawing.Point(15, 0);
            // 
            // btnGuiThu
            // 
            this.btnGuiThu.BackColor = System.Drawing.Color.Transparent;
            this.btnGuiThu.BorderRadius = 10;
            this.btnGuiThu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuiThu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuiThu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuiThu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuiThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGuiThu.FillColor = System.Drawing.Color.Transparent;
            this.btnGuiThu.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnGuiThu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGuiThu.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnGuiThu.ImageSize = new System.Drawing.Size(24, 24);
            this.btnGuiThu.Location = new System.Drawing.Point(10, 55);
            this.btnGuiThu.Name = "btnGuiThu";
            this.btnGuiThu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGuiThu.Size = new System.Drawing.Size(260, 55);
            this.btnGuiThu.TabIndex = 1;
            this.btnGuiThu.Text = "Gửi thư";
            this.btnGuiThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGuiThu.TextOffset = new System.Drawing.Point(15, 0);
            this.btnGuiThu.Click += new System.EventHandler(this.btnGuiThu_Click);
            // 
            // btnQuanLyHeThong
            // 
            this.btnQuanLyHeThong.BackColor = System.Drawing.Color.Transparent;
            this.btnQuanLyHeThong.BorderRadius = 10;
            this.btnQuanLyHeThong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQuanLyHeThong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQuanLyHeThong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQuanLyHeThong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQuanLyHeThong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyHeThong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(192)))), ((int)(((byte)(239)))));
            this.btnQuanLyHeThong.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyHeThong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.btnQuanLyHeThong.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQuanLyHeThong.ImageOffset = new System.Drawing.Point(15, 0);
            this.btnQuanLyHeThong.ImageSize = new System.Drawing.Size(24, 24);
            this.btnQuanLyHeThong.Location = new System.Drawing.Point(10, 0);
            this.btnQuanLyHeThong.Name = "btnQuanLyHeThong";
            this.btnQuanLyHeThong.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQuanLyHeThong.Size = new System.Drawing.Size(260, 55);
            this.btnQuanLyHeThong.TabIndex = 0;
            this.btnQuanLyHeThong.Text = "Quản lý hệ thống";
            this.btnQuanLyHeThong.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnQuanLyHeThong.TextOffset = new System.Drawing.Point(15, 0);
            this.btnQuanLyHeThong.Click += new System.EventHandler(this.btnQuanLyHeThong_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(120)))), ((int)(((byte)(193)))));
            this.pnlLogo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(115)))), ((int)(((byte)(188)))));
            this.pnlLogo.BorderThickness = 1;
            this.pnlLogo.Controls.Add(this.lblSchoolName);
            this.pnlLogo.Controls.Add(this.picLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(120)))), ((int)(((byte)(193)))));
            this.pnlLogo.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(134)))), ((int)(((byte)(207)))));
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(280, 160);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblSchoolName
            // 
            this.lblSchoolName.BackColor = System.Drawing.Color.Transparent;
            this.lblSchoolName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.lblSchoolName.Location = new System.Drawing.Point(28, 111);
            this.lblSchoolName.Name = "lblSchoolName";
            this.lblSchoolName.Size = new System.Drawing.Size(229, 34);
            this.lblSchoolName.TabIndex = 1;
            this.lblSchoolName.Text = "TRƯỜNG THPT ABC";
            this.lblSchoolName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.ImageRotate = 0F;
            this.picLogo.Location = new System.Drawing.Point(90, 15);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 90);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlMainScreen
            // 
            this.pnlMainScreen.Controls.Add(this.pnlContent);
            this.pnlMainScreen.Controls.Add(this.pnlTop);
            this.pnlMainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainScreen.Location = new System.Drawing.Point(280, 40);
            this.pnlMainScreen.Name = "pnlMainScreen";
            this.pnlMainScreen.Size = new System.Drawing.Size(1640, 1040);
            this.pnlMainScreen.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.BorderRadius = 15;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.FillColor = System.Drawing.Color.AliceBlue;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1640, 960);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.pnlTop.BorderThickness = 1;
            this.pnlTop.Controls.Add(this.lblPageTitle);
            this.pnlTop.Controls.Add(this.lblUserName);
            this.pnlTop.Controls.Add(this.picUserAvatar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.pnlTop.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1640, 80);
            this.pnlTop.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lblPageTitle.Location = new System.Drawing.Point(25, 22);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(246, 43);
            this.lblPageTitle.TabIndex = 2;
            this.lblPageTitle.Text = "Quản lý hệ thống";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.lblUserName.Location = new System.Drawing.Point(1486, 28);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(135, 30);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Nguyễn Văn A";
            // 
            // picUserAvatar
            // 
            this.picUserAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picUserAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picUserAvatar.ImageRotate = 0F;
            this.picUserAvatar.Location = new System.Drawing.Point(1596, 20);
            this.picUserAvatar.Name = "picUserAvatar";
            this.picUserAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picUserAvatar.Size = new System.Drawing.Size(40, 40);
            this.picUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserAvatar.TabIndex = 0;
            this.picUserAvatar.TabStop = false;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 18;
            // 
            // frmBGH
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMainScreen);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTitleBar);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBGH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Trường Học";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlMainScreen.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlTitleBar;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonMaximize;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonMinimize;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButtonClose;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlLeft;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlMainScreen;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlTop;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlLogo;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlMenu;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlContent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFormTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSchoolName;
        private Guna.UI2.WinForms.Guna2PictureBox picLogo;
        private Guna.UI2.WinForms.Guna2Button btnQuanLyHeThong;
        private Guna.UI2.WinForms.Guna2Button btnSettings;
        private Guna.UI2.WinForms.Guna2Button btnGuiThu;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picUserAvatar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageTitle;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        public Guna.UI2.WinForms.Guna2HtmlLabel lblUserName;
    }
}

