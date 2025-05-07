namespace QuanLyTruongHoc.GUI.Controls.ucPhongNoiVu
{
    partial class ucQuanLyHocSinh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbLop = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnThemHocSinh = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.MaNguoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHocSinh = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDTMe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenMe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDTCha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenCha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDTHocSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhThanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanToc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocSinh)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(209, 43);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(84, 27);
            this.guna2HtmlLabel1.TabIndex = 2;
            this.guna2HtmlLabel1.Text = "Chọn lớp: ";
            // 
            // cbLop
            // 
            this.cbLop.AutoRoundedCorners = true;
            this.cbLop.BackColor = System.Drawing.Color.Transparent;
            this.cbLop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLop.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbLop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbLop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.cbLop.ForeColor = System.Drawing.Color.Black;
            this.cbLop.ItemHeight = 30;
            this.cbLop.Location = new System.Drawing.Point(314, 41);
            this.cbLop.Margin = new System.Windows.Forms.Padding(2);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(137, 36);
            this.cbLop.TabIndex = 1;
            this.cbLop.SelectedIndexChanged += new System.EventHandler(this.cbLop_SelectedIndexChanged);
            // 
            // btnThemHocSinh
            // 
            this.btnThemHocSinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemHocSinh.BackColor = System.Drawing.Color.Transparent;
            this.btnThemHocSinh.BorderRadius = 10;
            this.btnThemHocSinh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemHocSinh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemHocSinh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemHocSinh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemHocSinh.FillColor = System.Drawing.Color.Lime;
            this.btnThemHocSinh.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHocSinh.ForeColor = System.Drawing.Color.White;
            this.btnThemHocSinh.Location = new System.Drawing.Point(892, 36);
            this.btnThemHocSinh.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemHocSinh.Name = "btnThemHocSinh";
            this.btnThemHocSinh.Size = new System.Drawing.Size(88, 36);
            this.btnThemHocSinh.TabIndex = 3;
            this.btnThemHocSinh.Text = "Thêm";
            this.btnThemHocSinh.Click += new System.EventHandler(this.btnThemHocSinh_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.BorderRadius = 10;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.FillColor = System.Drawing.Color.Gold;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(993, 36);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(88, 36);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BorderRadius = 10;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.FillColor = System.Drawing.Color.Red;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(1095, 36);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(88, 36);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 10;
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(59, 36);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(114, 46);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimKiem.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(1449, 36);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(122, 36);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // MaNguoiDung
            // 
            this.MaNguoiDung.DataPropertyName = "MaNguoiDung";
            this.MaNguoiDung.HeaderText = "Mã người dùng";
            this.MaNguoiDung.MinimumWidth = 6;
            this.MaNguoiDung.Name = "MaNguoiDung";
            this.MaNguoiDung.ReadOnly = true;
            this.MaNguoiDung.Visible = false;
            // 
            // dgvHocSinh
            // 
            this.dgvHocSinh.AllowUserToAddRows = false;
            this.dgvHocSinh.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvHocSinh.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHocSinh.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHocSinh.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHocSinh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHocSinh.ColumnHeadersHeight = 50;
            this.dgvHocSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvHocSinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHS,
            this.MaNguoiDung,
            this.HoTen,
            this.NgaySinh,
            this.GioiTinh,
            this.CMND,
            this.DanToc,
            this.DiaChi,
            this.TinhThanh,
            this.SDTHocSinh,
            this.HoTenCha,
            this.SDTCha,
            this.HoTenMe,
            this.SDTMe,
            this.MaLop});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHocSinh.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHocSinh.GridColor = System.Drawing.Color.AliceBlue;
            this.dgvHocSinh.Location = new System.Drawing.Point(59, 124);
            this.dgvHocSinh.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHocSinh.Name = "dgvHocSinh";
            this.dgvHocSinh.ReadOnly = true;
            this.dgvHocSinh.RowHeadersVisible = false;
            this.dgvHocSinh.RowHeadersWidth = 51;
            this.dgvHocSinh.RowTemplate.Height = 24;
            this.dgvHocSinh.Size = new System.Drawing.Size(1522, 819);
            this.dgvHocSinh.TabIndex = 0;
            this.dgvHocSinh.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHocSinh.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHocSinh.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHocSinh.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHocSinh.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHocSinh.ThemeStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvHocSinh.ThemeStyle.GridColor = System.Drawing.Color.AliceBlue;
            this.dgvHocSinh.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvHocSinh.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHocSinh.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHocSinh.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHocSinh.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvHocSinh.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvHocSinh.ThemeStyle.ReadOnly = true;
            this.dgvHocSinh.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHocSinh.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHocSinh.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHocSinh.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHocSinh.ThemeStyle.RowsStyle.Height = 24;
            this.dgvHocSinh.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHocSinh.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "TenLop";
            this.MaLop.HeaderText = "Lớp";
            this.MaLop.MinimumWidth = 6;
            this.MaLop.Name = "MaLop";
            this.MaLop.ReadOnly = true;
            // 
            // SDTMe
            // 
            this.SDTMe.DataPropertyName = "SoDienThoaiMe";
            this.SDTMe.HeaderText = "SĐT mẹ";
            this.SDTMe.MinimumWidth = 6;
            this.SDTMe.Name = "SDTMe";
            this.SDTMe.ReadOnly = true;
            // 
            // HoTenMe
            // 
            this.HoTenMe.DataPropertyName = "HoTenMe";
            this.HoTenMe.HeaderText = "Họ tên mẹ";
            this.HoTenMe.MinimumWidth = 6;
            this.HoTenMe.Name = "HoTenMe";
            this.HoTenMe.ReadOnly = true;
            // 
            // SDTCha
            // 
            this.SDTCha.DataPropertyName = "SoDienThoaiCha";
            this.SDTCha.HeaderText = "SĐT cha";
            this.SDTCha.MinimumWidth = 6;
            this.SDTCha.Name = "SDTCha";
            this.SDTCha.ReadOnly = true;
            // 
            // HoTenCha
            // 
            this.HoTenCha.DataPropertyName = "HoTenCha";
            this.HoTenCha.HeaderText = "Họ tên cha";
            this.HoTenCha.MinimumWidth = 6;
            this.HoTenCha.Name = "HoTenCha";
            this.HoTenCha.ReadOnly = true;
            // 
            // SDTHocSinh
            // 
            this.SDTHocSinh.DataPropertyName = "SDT";
            this.SDTHocSinh.HeaderText = "SĐT Học sinh";
            this.SDTHocSinh.MinimumWidth = 6;
            this.SDTHocSinh.Name = "SDTHocSinh";
            this.SDTHocSinh.ReadOnly = true;
            // 
            // TinhThanh
            // 
            this.TinhThanh.DataPropertyName = "TinhThanh";
            this.TinhThanh.HeaderText = "Tỉnh/Thành";
            this.TinhThanh.MinimumWidth = 6;
            this.TinhThanh.Name = "TinhThanh";
            this.TinhThanh.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChiThuongTru";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.MinimumWidth = 6;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // DanToc
            // 
            this.DanToc.DataPropertyName = "DanToc";
            this.DanToc.HeaderText = "Dân tộc";
            this.DanToc.MinimumWidth = 6;
            this.DanToc.Name = "DanToc";
            this.DanToc.ReadOnly = true;
            // 
            // CMND
            // 
            this.CMND.DataPropertyName = "MaDinhDanh";
            this.CMND.HeaderText = "CMND/CCCD";
            this.CMND.MinimumWidth = 6;
            this.CMND.Name = "CMND";
            this.CMND.ReadOnly = true;
            // 
            // GioiTinh
            // 
            this.GioiTinh.DataPropertyName = "GioiTinh";
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.MinimumWidth = 6;
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.ReadOnly = true;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.MinimumWidth = 6;
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ và tên";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // MaHS
            // 
            this.MaHS.DataPropertyName = "MaHS";
            this.MaHS.HeaderText = "Mã học sinh";
            this.MaHS.MinimumWidth = 6;
            this.MaHS.Name = "MaHS";
            this.MaHS.ReadOnly = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderRadius = 10;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiem.Location = new System.Drawing.Point(1199, 36);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(5);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập họ và tên để tìm kiếm";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(234, 36);
            this.txtTimKiem.TabIndex = 7;
            // 
            // ucQuanLyHocSinh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.dgvHocSinh);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThemHocSinh);
            this.Controls.Add(this.cbLop);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucQuanLyHocSinh";
            this.Size = new System.Drawing.Size(1640, 960);
            this.Load += new System.EventHandler(this.ucQuanLyHocSinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocSinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ComboBox cbLop;
        private Guna.UI2.WinForms.Guna2Button btnThemHocSinh;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNguoiDung;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHocSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanToc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhThanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDTHocSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenCha;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDTCha;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenMe;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDTMe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
    }
}
