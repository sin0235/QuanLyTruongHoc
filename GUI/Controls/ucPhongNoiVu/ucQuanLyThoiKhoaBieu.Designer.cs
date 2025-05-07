namespace QuanLyTruongHoc.GUI.Controls.ucPhongNoiVu
{
    partial class ucQuanLyThoiKhoaBieu
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
            this.panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.dtpNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbChonLop = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvThoiKhoaBieu = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colThu2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChuNhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelHeader.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiKhoaBieu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.guna2HtmlLabel2);
            this.panelHeader.Controls.Add(this.guna2Panel1);
            this.panelHeader.Controls.Add(this.dtpNgay);
            this.panelHeader.Controls.Add(this.guna2HtmlLabel1);
            this.panelHeader.Controls.Add(this.cmbChonLop);
            this.panelHeader.Location = new System.Drawing.Point(69, 7);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1325, 68);
            this.panelHeader.TabIndex = 3;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(915, 4);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(123, 33);
            this.guna2HtmlLabel2.TabIndex = 6;
            this.guna2HtmlLabel2.Text = "Chọn ngày:";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.btnLamMoi);
            this.guna2Panel1.Controls.Add(this.btnThem);
            this.guna2Panel1.Controls.Add(this.btnXoa);
            this.guna2Panel1.Controls.Add(this.btnSua);
            this.guna2Panel1.Location = new System.Drawing.Point(307, 4);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(600, 59);
            this.guna2Panel1.TabIndex = 7;
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
            this.btnLamMoi.Location = new System.Drawing.Point(448, 4);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(144, 44);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.BorderRadius = 10;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.Lime;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(3, 4);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(117, 44);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BorderRadius = 10;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.FillColor = System.Drawing.Color.Red;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(304, 4);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(117, 44);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BorderRadius = 10;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.FillColor = System.Drawing.Color.Gold;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(155, 4);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(117, 44);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dtpNgay
            // 
            this.dtpNgay.BorderRadius = 10;
            this.dtpNgay.Checked = true;
            this.dtpNgay.FillColor = System.Drawing.Color.RoyalBlue;
            this.dtpNgay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpNgay.Location = new System.Drawing.Point(1055, 7);
            this.dtpNgay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(267, 44);
            this.dtpNgay.TabIndex = 5;
            this.dtpNgay.Value = new System.DateTime(2025, 5, 3, 19, 51, 58, 495);
            this.dtpNgay.ValueChanged += new System.EventHandler(this.DtpNgay_ValueChanged);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(4, 9);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(106, 33);
            this.guna2HtmlLabel1.TabIndex = 4;
            this.guna2HtmlLabel1.Text = "Chọn lớp:";
            // 
            // cmbChonLop
            // 
            this.cmbChonLop.BackColor = System.Drawing.Color.Transparent;
            this.cmbChonLop.BorderRadius = 10;
            this.cmbChonLop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbChonLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChonLop.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbChonLop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbChonLop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChonLop.ForeColor = System.Drawing.Color.Black;
            this.cmbChonLop.ItemHeight = 30;
            this.cmbChonLop.Location = new System.Drawing.Point(124, 9);
            this.cmbChonLop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbChonLop.Name = "cmbChonLop";
            this.cmbChonLop.Size = new System.Drawing.Size(159, 36);
            this.cmbChonLop.TabIndex = 3;
            this.cmbChonLop.SelectedIndexChanged += new System.EventHandler(this.CmbChonLop_SelectedIndexChanged);
            // 
            // dgvThoiKhoaBieu
            // 
            this.dgvThoiKhoaBieu.AllowUserToAddRows = false;
            this.dgvThoiKhoaBieu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThoiKhoaBieu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvThoiKhoaBieu.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThoiKhoaBieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThoiKhoaBieu.ColumnHeadersHeight = 60;
            this.dgvThoiKhoaBieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThoiKhoaBieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colThu2,
            this.colThu3,
            this.colThu4,
            this.colThu5,
            this.colThu6,
            this.colThu7,
            this.colChuNhat});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThoiKhoaBieu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThoiKhoaBieu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThoiKhoaBieu.Location = new System.Drawing.Point(69, 97);
            this.dgvThoiKhoaBieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvThoiKhoaBieu.Name = "dgvThoiKhoaBieu";
            this.dgvThoiKhoaBieu.ReadOnly = true;
            this.dgvThoiKhoaBieu.RowHeadersVisible = false;
            this.dgvThoiKhoaBieu.RowHeadersWidth = 51;
            this.dgvThoiKhoaBieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvThoiKhoaBieu.Size = new System.Drawing.Size(1325, 773);
            this.dgvThoiKhoaBieu.TabIndex = 8;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThoiKhoaBieu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThoiKhoaBieu.ThemeStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvThoiKhoaBieu.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThoiKhoaBieu.ThemeStyle.HeaderStyle.Height = 60;
            this.dgvThoiKhoaBieu.ThemeStyle.ReadOnly = true;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.Height = 22;
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThoiKhoaBieu.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThoiKhoaBieu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThoiKhoaBieu_CellContentClick);
            // 
            // colThu2
            // 
            this.colThu2.HeaderText = "Thứ 2";
            this.colThu2.MinimumWidth = 6;
            this.colThu2.Name = "colThu2";
            this.colThu2.ReadOnly = true;
            // 
            // colThu3
            // 
            this.colThu3.HeaderText = "Thứ 3";
            this.colThu3.MinimumWidth = 6;
            this.colThu3.Name = "colThu3";
            this.colThu3.ReadOnly = true;
            // 
            // colThu4
            // 
            this.colThu4.HeaderText = "Thứ 4";
            this.colThu4.MinimumWidth = 6;
            this.colThu4.Name = "colThu4";
            this.colThu4.ReadOnly = true;
            // 
            // colThu5
            // 
            this.colThu5.HeaderText = "Thứ 5";
            this.colThu5.MinimumWidth = 6;
            this.colThu5.Name = "colThu5";
            this.colThu5.ReadOnly = true;
            // 
            // colThu6
            // 
            this.colThu6.HeaderText = "Thứ 6";
            this.colThu6.MinimumWidth = 6;
            this.colThu6.Name = "colThu6";
            this.colThu6.ReadOnly = true;
            // 
            // colThu7
            // 
            this.colThu7.HeaderText = "Thứ 7";
            this.colThu7.MinimumWidth = 6;
            this.colThu7.Name = "colThu7";
            this.colThu7.ReadOnly = true;
            // 
            // colChuNhat
            // 
            this.colChuNhat.HeaderText = "Chủ nhật";
            this.colChuNhat.MinimumWidth = 6;
            this.colChuNhat.Name = "colChuNhat";
            this.colChuNhat.ReadOnly = true;
            // 
            // ucQuanLyThoiKhoaBieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.dgvThoiKhoaBieu);
            this.Controls.Add(this.panelHeader);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucQuanLyThoiKhoaBieu";
            this.Size = new System.Drawing.Size(1472, 966);
            this.Load += new System.EventHandler(this.ucQuanLyThoiKhoaBieu_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThoiKhoaBieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel panelHeader;
        private Guna.UI2.WinForms.Guna2ComboBox cmbChonLop;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThoiKhoaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChuNhat;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgay;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
    }
}
