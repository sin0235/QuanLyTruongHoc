namespace QuanLyTruongHoc.GUI.Forms
{
    partial class frmChinhSuaDiem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.xoaBtn = new Guna.UI2.WinForms.Guna2Button();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2CircleButton();
            this.cmbHocKi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chinhSuaBtn = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDiemChiTietHocSinh = new Guna.UI2.WinForms.Guna2DataGridView();
            this.diemTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hoTenTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.sttTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loaiDiemCmb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HocKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemChiTietHocSinh)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.xoaBtn);
            this.guna2GradientPanel1.Controls.Add(this.btnTimKiem);
            this.guna2GradientPanel1.Controls.Add(this.cmbHocKi);
            this.guna2GradientPanel1.Controls.Add(this.label5);
            this.guna2GradientPanel1.Controls.Add(this.chinhSuaBtn);
            this.guna2GradientPanel1.Controls.Add(this.dgvDiemChiTietHocSinh);
            this.guna2GradientPanel1.Controls.Add(this.diemTxt);
            this.guna2GradientPanel1.Controls.Add(this.label4);
            this.guna2GradientPanel1.Controls.Add(this.label3);
            this.guna2GradientPanel1.Controls.Add(this.label2);
            this.guna2GradientPanel1.Controls.Add(this.hoTenTxt);
            this.guna2GradientPanel1.Controls.Add(this.sttTxt);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Controls.Add(this.loaiDiemCmb);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(800, 450);
            this.guna2GradientPanel1.TabIndex = 1;
            // 
            // xoaBtn
            // 
            this.xoaBtn.BorderRadius = 10;
            this.xoaBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.xoaBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.xoaBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.xoaBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.xoaBtn.FillColor = System.Drawing.Color.Red;
            this.xoaBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoaBtn.ForeColor = System.Drawing.Color.White;
            this.xoaBtn.Location = new System.Drawing.Point(421, 393);
            this.xoaBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.xoaBtn.Name = "xoaBtn";
            this.xoaBtn.Size = new System.Drawing.Size(180, 46);
            this.xoaBtn.TabIndex = 18;
            this.xoaBtn.Text = "Xóa";
            this.xoaBtn.Click += new System.EventHandler(this.xoaBtn_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.BackgroundImage = global::QuanLyTruongHoc.Properties.Resources.search;
            this.btnTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimKiem.FillColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(236, 23);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnTimKiem.Size = new System.Drawing.Size(43, 41);
            this.btnTimKiem.TabIndex = 17;
            this.btnTimKiem.Text = "...";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cmbHocKi
            // 
            this.cmbHocKi.BackColor = System.Drawing.Color.Transparent;
            this.cmbHocKi.BorderRadius = 10;
            this.cmbHocKi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbHocKi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHocKi.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbHocKi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbHocKi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbHocKi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbHocKi.ItemHeight = 30;
            this.cmbHocKi.Items.AddRange(new object[] {
            "Học kỳ 1",
            "Học kỳ 2"});
            this.cmbHocKi.Location = new System.Drawing.Point(96, 240);
            this.cmbHocKi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbHocKi.Name = "cmbHocKi";
            this.cmbHocKi.Size = new System.Drawing.Size(231, 36);
            this.cmbHocKi.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 28);
            this.label5.TabIndex = 15;
            this.label5.Text = "Học kì";
            // 
            // chinhSuaBtn
            // 
            this.chinhSuaBtn.BackColor = System.Drawing.Color.Transparent;
            this.chinhSuaBtn.BorderRadius = 10;
            this.chinhSuaBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.chinhSuaBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.chinhSuaBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.chinhSuaBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.chinhSuaBtn.FillColor = System.Drawing.Color.DarkOrange;
            this.chinhSuaBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chinhSuaBtn.ForeColor = System.Drawing.Color.White;
            this.chinhSuaBtn.HoverState.FillColor = System.Drawing.Color.Orange;
            this.chinhSuaBtn.Location = new System.Drawing.Point(608, 393);
            this.chinhSuaBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chinhSuaBtn.Name = "chinhSuaBtn";
            this.chinhSuaBtn.Size = new System.Drawing.Size(180, 46);
            this.chinhSuaBtn.TabIndex = 14;
            this.chinhSuaBtn.Text = "Chỉnh sửa";
            this.chinhSuaBtn.Click += new System.EventHandler(this.chinhSuaBtn_Click);
            // 
            // dgvDiemChiTietHocSinh
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.dgvDiemChiTietHocSinh.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDiemChiTietHocSinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDiemChiTietHocSinh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDiemChiTietHocSinh.ColumnHeadersHeight = 53;
            this.dgvDiemChiTietHocSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDiemChiTietHocSinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.LoaiDiem,
            this.Diem,
            this.HocKy});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDiemChiTietHocSinh.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDiemChiTietHocSinh.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.dgvDiemChiTietHocSinh.Location = new System.Drawing.Point(341, 14);
            this.dgvDiemChiTietHocSinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDiemChiTietHocSinh.Name = "dgvDiemChiTietHocSinh";
            this.dgvDiemChiTietHocSinh.RowHeadersVisible = false;
            this.dgvDiemChiTietHocSinh.RowHeadersWidth = 51;
            this.dgvDiemChiTietHocSinh.RowTemplate.Height = 24;
            this.dgvDiemChiTietHocSinh.Size = new System.Drawing.Size(445, 340);
            this.dgvDiemChiTietHocSinh.TabIndex = 13;
            this.dgvDiemChiTietHocSinh.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.FeterRiver;
            this.dgvDiemChiTietHocSinh.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.dgvDiemChiTietHocSinh.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDiemChiTietHocSinh.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDiemChiTietHocSinh.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDiemChiTietHocSinh.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDiemChiTietHocSinh.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDiemChiTietHocSinh.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.dgvDiemChiTietHocSinh.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.dgvDiemChiTietHocSinh.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDiemChiTietHocSinh.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDiemChiTietHocSinh.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDiemChiTietHocSinh.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDiemChiTietHocSinh.ThemeStyle.HeaderStyle.Height = 53;
            this.dgvDiemChiTietHocSinh.ThemeStyle.ReadOnly = false;
            this.dgvDiemChiTietHocSinh.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            this.dgvDiemChiTietHocSinh.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDiemChiTietHocSinh.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDiemChiTietHocSinh.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDiemChiTietHocSinh.ThemeStyle.RowsStyle.Height = 24;
            this.dgvDiemChiTietHocSinh.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            this.dgvDiemChiTietHocSinh.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDiemChiTietHocSinh.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiemChiTietHocSinh_CellDoubleClick);
            // 
            // diemTxt
            // 
            this.diemTxt.BackColor = System.Drawing.Color.Transparent;
            this.diemTxt.BorderRadius = 10;
            this.diemTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.diemTxt.DefaultText = "";
            this.diemTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.diemTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.diemTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.diemTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.diemTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.diemTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.diemTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.diemTxt.Location = new System.Drawing.Point(96, 306);
            this.diemTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.diemTxt.Name = "diemTxt";
            this.diemTxt.PlaceholderText = "";
            this.diemTxt.SelectedText = "";
            this.diemTxt.Size = new System.Drawing.Size(116, 34);
            this.diemTxt.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Điểm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Họ tên";
            // 
            // hoTenTxt
            // 
            this.hoTenTxt.BorderRadius = 10;
            this.hoTenTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hoTenTxt.DefaultText = "";
            this.hoTenTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.hoTenTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.hoTenTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.hoTenTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.hoTenTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.hoTenTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hoTenTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.hoTenTxt.Location = new System.Drawing.Point(96, 100);
            this.hoTenTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hoTenTxt.Name = "hoTenTxt";
            this.hoTenTxt.PlaceholderText = "";
            this.hoTenTxt.SelectedText = "";
            this.hoTenTxt.Size = new System.Drawing.Size(229, 34);
            this.hoTenTxt.TabIndex = 2;
            // 
            // sttTxt
            // 
            this.sttTxt.BackColor = System.Drawing.Color.Transparent;
            this.sttTxt.BorderRadius = 10;
            this.sttTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.sttTxt.DefaultText = "";
            this.sttTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sttTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.sttTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.sttTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.sttTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sttTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.sttTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.sttTxt.Location = new System.Drawing.Point(96, 23);
            this.sttTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sttTxt.Name = "sttTxt";
            this.sttTxt.PlaceholderText = "";
            this.sttTxt.SelectedText = "";
            this.sttTxt.Size = new System.Drawing.Size(116, 34);
            this.sttTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "STT";
            // 
            // loaiDiemCmb
            // 
            this.loaiDiemCmb.BackColor = System.Drawing.Color.Transparent;
            this.loaiDiemCmb.BorderRadius = 10;
            this.loaiDiemCmb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.loaiDiemCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaiDiemCmb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.loaiDiemCmb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.loaiDiemCmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.loaiDiemCmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.loaiDiemCmb.ItemHeight = 30;
            this.loaiDiemCmb.Items.AddRange(new object[] {
            "Miệng",
            "15 Phút",
            "Giữa kì",
            "Cuối kì"});
            this.loaiDiemCmb.Location = new System.Drawing.Point(96, 178);
            this.loaiDiemCmb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loaiDiemCmb.Name = "loaiDiemCmb";
            this.loaiDiemCmb.Size = new System.Drawing.Size(231, 36);
            this.loaiDiemCmb.TabIndex = 5;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            // 
            // LoaiDiem
            // 
            this.LoaiDiem.HeaderText = "Loại Điểm";
            this.LoaiDiem.MinimumWidth = 6;
            this.LoaiDiem.Name = "LoaiDiem";
            // 
            // Diem
            // 
            this.Diem.HeaderText = "Điểm";
            this.Diem.MinimumWidth = 6;
            this.Diem.Name = "Diem";
            // 
            // HocKy
            // 
            this.HocKy.HeaderText = "Học Kỳ";
            this.HocKy.MinimumWidth = 6;
            this.HocKy.Name = "HocKy";
            // 
            // frmChinhSuaDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmChinhSuaDiem";
            this.Text = "frmChinhSuaDiem";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemChiTietHocSinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDiemChiTietHocSinh;
        private Guna.UI2.WinForms.Guna2TextBox diemTxt;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox loaiDiemCmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox hoTenTxt;
        private Guna.UI2.WinForms.Guna2TextBox sttTxt;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button chinhSuaBtn;
        private Guna.UI2.WinForms.Guna2ComboBox cmbHocKi;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2CircleButton btnTimKiem;
        private Guna.UI2.WinForms.Guna2Button xoaBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diem;
        private System.Windows.Forms.DataGridViewTextBoxColumn HocKy;
    }
}