namespace QuanLyTruongHoc.GUI.Controls
{
    partial class ucTKB
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlFilters = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTuanHienTai = new Guna.UI2.WinForms.Guna2Button();
            this.btnTuanTruoc = new Guna.UI2.WinForms.Guna2Button();
            this.btnTuanTiepTheo = new Guna.UI2.WinForms.Guna2Button();
            this.lblTuan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboTuan = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblHocKy = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboHocKy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNamHoc = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboNamHoc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvThoiKhoaBieu = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlNoData = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNoData = new System.Windows.Forms.Label();
            this.picNoData = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiKhoaBieu)).BeginInit();
            this.pnlNoData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNoData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.BorderRadius = 8;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlHeader.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1640, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thời Khóa Biểu";
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.White;
            this.pnlFilters.BorderRadius = 8;
            this.pnlFilters.Controls.Add(this.btnTuanHienTai);
            this.pnlFilters.Controls.Add(this.btnTuanTruoc);
            this.pnlFilters.Controls.Add(this.btnTuanTiepTheo);
            this.pnlFilters.Controls.Add(this.lblTuan);
            this.pnlFilters.Controls.Add(this.cboTuan);
            this.pnlFilters.Controls.Add(this.lblHocKy);
            this.pnlFilters.Controls.Add(this.cboHocKy);
            this.pnlFilters.Controls.Add(this.lblNamHoc);
            this.pnlFilters.Controls.Add(this.cboNamHoc);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 60);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.ShadowDecoration.BorderRadius = 8;
            this.pnlFilters.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.pnlFilters.ShadowDecoration.Enabled = true;
            this.pnlFilters.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 2, 0, 6);
            this.pnlFilters.Size = new System.Drawing.Size(1640, 80);
            this.pnlFilters.TabIndex = 1;
            // 
            // btnTuanHienTai
            // 
            this.btnTuanHienTai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTuanHienTai.BorderRadius = 20;
            this.btnTuanHienTai.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTuanHienTai.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTuanHienTai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTuanHienTai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTuanHienTai.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(100)))));
            this.btnTuanHienTai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTuanHienTai.ForeColor = System.Drawing.Color.White;
            this.btnTuanHienTai.Location = new System.Drawing.Point(1131, 18);
            this.btnTuanHienTai.Name = "btnTuanHienTai";
            this.btnTuanHienTai.Size = new System.Drawing.Size(150, 45);
            this.btnTuanHienTai.TabIndex = 9;
            this.btnTuanHienTai.Text = "Hiện tại";
            this.btnTuanHienTai.Click += new System.EventHandler(this.btnTuanHienTai_Click);
            // 
            // btnTuanTruoc
            // 
            this.btnTuanTruoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTuanTruoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTuanTruoc.BorderRadius = 20;
            this.btnTuanTruoc.BorderThickness = 1;
            this.btnTuanTruoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTuanTruoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTuanTruoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTuanTruoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTuanTruoc.FillColor = System.Drawing.Color.White;
            this.btnTuanTruoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTuanTruoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTuanTruoc.Location = new System.Drawing.Point(950, 18);
            this.btnTuanTruoc.Name = "btnTuanTruoc";
            this.btnTuanTruoc.Size = new System.Drawing.Size(150, 45);
            this.btnTuanTruoc.TabIndex = 8;
            this.btnTuanTruoc.Text = "← Tuần trước";
            this.btnTuanTruoc.Click += new System.EventHandler(this.btnTuanTruoc_Click);
            // 
            // btnTuanTiepTheo
            // 
            this.btnTuanTiepTheo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTuanTiepTheo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTuanTiepTheo.BorderRadius = 20;
            this.btnTuanTiepTheo.BorderThickness = 1;
            this.btnTuanTiepTheo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTuanTiepTheo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTuanTiepTheo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTuanTiepTheo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTuanTiepTheo.FillColor = System.Drawing.Color.White;
            this.btnTuanTiepTheo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTuanTiepTheo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnTuanTiepTheo.Location = new System.Drawing.Point(1310, 18);
            this.btnTuanTiepTheo.Name = "btnTuanTiepTheo";
            this.btnTuanTiepTheo.Size = new System.Drawing.Size(150, 45);
            this.btnTuanTiepTheo.TabIndex = 7;
            this.btnTuanTiepTheo.Text = "Tiếp theo →";
            this.btnTuanTiepTheo.Click += new System.EventHandler(this.btnTuanTiepTheo_Click);
            // 
            // lblTuan
            // 
            this.lblTuan.BackColor = System.Drawing.Color.Transparent;
            this.lblTuan.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblTuan.Location = new System.Drawing.Point(560, 30);
            this.lblTuan.Name = "lblTuan";
            this.lblTuan.Size = new System.Drawing.Size(35, 21);
            this.lblTuan.TabIndex = 6;
            this.lblTuan.Text = "Tuần";
            // 
            // cboTuan
            // 
            this.cboTuan.BackColor = System.Drawing.Color.Transparent;
            this.cboTuan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.cboTuan.BorderRadius = 18;
            this.cboTuan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTuan.DropDownWidth = 200;
            this.cboTuan.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTuan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTuan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cboTuan.ItemHeight = 30;
            this.cboTuan.Location = new System.Drawing.Point(604, 22);
            this.cboTuan.Name = "cboTuan";
            this.cboTuan.Size = new System.Drawing.Size(260, 36);
            this.cboTuan.TabIndex = 5;
            this.cboTuan.TextOffset = new System.Drawing.Point(5, 0);
            this.cboTuan.SelectedIndexChanged += new System.EventHandler(this.cboTuan_SelectedIndexChanged);
            // 
            // lblHocKy
            // 
            this.lblHocKy.BackColor = System.Drawing.Color.Transparent;
            this.lblHocKy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblHocKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblHocKy.Location = new System.Drawing.Point(290, 30);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(46, 21);
            this.lblHocKy.TabIndex = 4;
            this.lblHocKy.Text = "Học kỳ";
            // 
            // cboHocKy
            // 
            this.cboHocKy.BackColor = System.Drawing.Color.Transparent;
            this.cboHocKy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.cboHocKy.BorderRadius = 18;
            this.cboHocKy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboHocKy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboHocKy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboHocKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cboHocKy.ItemHeight = 30;
            this.cboHocKy.Location = new System.Drawing.Point(345, 22);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(140, 36);
            this.cboHocKy.TabIndex = 3;
            this.cboHocKy.TextOffset = new System.Drawing.Point(5, 0);
            this.cboHocKy.SelectedIndexChanged += new System.EventHandler(this.cboHocKy_SelectedIndexChanged);
            // 
            // lblNamHoc
            // 
            this.lblNamHoc.BackColor = System.Drawing.Color.Transparent;
            this.lblNamHoc.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblNamHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblNamHoc.Location = new System.Drawing.Point(20, 30);
            this.lblNamHoc.Name = "lblNamHoc";
            this.lblNamHoc.Size = new System.Drawing.Size(60, 21);
            this.lblNamHoc.TabIndex = 2;
            this.lblNamHoc.Text = "Năm học";
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.BackColor = System.Drawing.Color.Transparent;
            this.cboNamHoc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(220)))));
            this.cboNamHoc.BorderRadius = 18;
            this.cboNamHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamHoc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNamHoc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNamHoc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNamHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cboNamHoc.ItemHeight = 30;
            this.cboNamHoc.Location = new System.Drawing.Point(88, 22);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(140, 36);
            this.cboNamHoc.TabIndex = 0;
            this.cboNamHoc.TextOffset = new System.Drawing.Point(5, 0);
            this.cboNamHoc.SelectedIndexChanged += new System.EventHandler(this.cboNamHoc_SelectedIndexChanged);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(0, 140);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1640, 10);
            this.guna2Separator1.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvThoiKhoaBieu);
            this.pnlContent.Controls.Add(this.pnlNoData);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 140);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.pnlContent.Size = new System.Drawing.Size(1640, 900);
            this.pnlContent.TabIndex = 3;
            // 
            // dgvThoiKhoaBieu
            // 
            this.dgvThoiKhoaBieu.AllowUserToAddRows = false;
            this.dgvThoiKhoaBieu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.dgvThoiKhoaBieu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThoiKhoaBieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThoiKhoaBieu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThoiKhoaBieu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThoiKhoaBieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThoiKhoaBieu.ColumnHeadersHeight = 45;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThoiKhoaBieu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThoiKhoaBieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThoiKhoaBieu.EnableHeadersVisualStyles = false;
            this.dgvThoiKhoaBieu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.dgvThoiKhoaBieu.Location = new System.Drawing.Point(20, 10);
            this.dgvThoiKhoaBieu.Name = "dgvThoiKhoaBieu";
            this.dgvThoiKhoaBieu.ReadOnly = true;
            this.dgvThoiKhoaBieu.RowHeadersVisible = false;
            this.dgvThoiKhoaBieu.RowTemplate.Height = 70;
            this.dgvThoiKhoaBieu.Size = new System.Drawing.Size(1600, 870);
            this.dgvThoiKhoaBieu.TabIndex = 1;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThoiKhoaBieu.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(230)))));
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.Height = 45;
            this.dgvThoiKhoaBieu.ThemeStyle.ReadOnly = true;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.Height = 70;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.dgvThoiKhoaBieu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThoiKhoaBieu_CellContentClick);
            // 
            // pnlNoData
            // 
            this.pnlNoData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlNoData.BackColor = System.Drawing.Color.White;
            this.pnlNoData.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlNoData.BorderRadius = 15;
            this.pnlNoData.BorderThickness = 1;
            this.pnlNoData.Controls.Add(this.lblNoData);
            this.pnlNoData.Controls.Add(this.picNoData);
            this.pnlNoData.Location = new System.Drawing.Point(571, 300);
            this.pnlNoData.Name = "pnlNoData";
            this.pnlNoData.Size = new System.Drawing.Size(500, 300);
            this.pnlNoData.TabIndex = 2;
            this.pnlNoData.Visible = false;
            // 
            // lblNoData
            // 
            this.lblNoData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblNoData.Location = new System.Drawing.Point(30, 200);
            this.lblNoData.Name = "lblNoData";
            this.lblNoData.Size = new System.Drawing.Size(440, 60);
            this.lblNoData.TabIndex = 1;
            this.lblNoData.Text = "Không có thời khóa biểu cho tuần này";
            this.lblNoData.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picNoData
            // 
            this.picNoData.Location = new System.Drawing.Point(175, 40);
            this.picNoData.Name = "picNoData";
            this.picNoData.Size = new System.Drawing.Size(150, 150);
            this.picNoData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNoData.TabIndex = 0;
            this.picNoData.TabStop = false;
            // 
            // ucTKB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ucTKB";
            this.Size = new System.Drawing.Size(1640, 1040);
            this.Load += new System.EventHandler(this.ucTKB_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiKhoaBieu)).EndInit();
            this.pnlNoData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picNoData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnlHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlFilters;
        private Guna.UI2.WinForms.Guna2ComboBox cboNamHoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNamHoc;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHocKy;
        private Guna.UI2.WinForms.Guna2ComboBox cboHocKy;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTuan;
        private Guna.UI2.WinForms.Guna2ComboBox cboTuan;
        private Guna.UI2.WinForms.Guna2Button btnTuanTiepTheo;
        private Guna.UI2.WinForms.Guna2Button btnTuanTruoc;
        private Guna.UI2.WinForms.Guna2Button btnTuanHienTai;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThoiKhoaBieu;
        private Guna.UI2.WinForms.Guna2Panel pnlNoData;
        private System.Windows.Forms.Label lblNoData;
        private System.Windows.Forms.PictureBox picNoData;
    }
}
