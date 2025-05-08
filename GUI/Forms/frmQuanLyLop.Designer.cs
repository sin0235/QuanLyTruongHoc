namespace QuanLyTruongHoc.GUI.Forms
{
    partial class frmQuanLyLop
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
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.txtLop = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbGiaoVienChuNhiem = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.lblLop = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblGVChuNhiem = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.picAvatar.Image = global::QuanLyTruongHoc.Properties.Resources.defautAvatar_Teacher_Male;
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(304, 11);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(186, 119);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 13;
            this.picAvatar.TabStop = false;
            // 
            // txtLop
            // 
            this.txtLop.BorderRadius = 10;
            this.txtLop.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLop.DefaultText = "";
            this.txtLop.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLop.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLop.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLop.ForeColor = System.Drawing.Color.Black;
            this.txtLop.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLop.Location = new System.Drawing.Point(392, 190);
            this.txtLop.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtLop.Name = "txtLop";
            this.txtLop.PlaceholderText = "";
            this.txtLop.SelectedText = "";
            this.txtLop.Size = new System.Drawing.Size(280, 36);
            this.txtLop.TabIndex = 14;
            // 
            // cbGiaoVienChuNhiem
            // 
            this.cbGiaoVienChuNhiem.BackColor = System.Drawing.Color.Transparent;
            this.cbGiaoVienChuNhiem.BorderRadius = 10;
            this.cbGiaoVienChuNhiem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGiaoVienChuNhiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGiaoVienChuNhiem.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGiaoVienChuNhiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGiaoVienChuNhiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbGiaoVienChuNhiem.ForeColor = System.Drawing.Color.Black;
            this.cbGiaoVienChuNhiem.ItemHeight = 30;
            this.cbGiaoVienChuNhiem.Location = new System.Drawing.Point(390, 278);
            this.cbGiaoVienChuNhiem.Name = "cbGiaoVienChuNhiem";
            this.cbGiaoVienChuNhiem.Size = new System.Drawing.Size(282, 36);
            this.cbGiaoVienChuNhiem.TabIndex = 15;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BorderRadius = 10;
            this.btnXacNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXacNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXacNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXacNhan.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(304, 370);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(186, 49);
            this.btnXacNhan.TabIndex = 16;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = false;
            this.lblLop.BackColor = System.Drawing.Color.Transparent;
            this.lblLop.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblLop.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblLop.Location = new System.Drawing.Point(91, 190);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(293, 41);
            this.lblLop.TabIndex = 17;
            this.lblLop.Text = "Nhập lớp:";
            // 
            // lblGVChuNhiem
            // 
            this.lblGVChuNhiem.AutoSize = false;
            this.lblGVChuNhiem.BackColor = System.Drawing.Color.Transparent;
            this.lblGVChuNhiem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblGVChuNhiem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblGVChuNhiem.Location = new System.Drawing.Point(91, 281);
            this.lblGVChuNhiem.Name = "lblGVChuNhiem";
            this.lblGVChuNhiem.Size = new System.Drawing.Size(293, 33);
            this.lblGVChuNhiem.TabIndex = 18;
            this.lblGVChuNhiem.Text = "Chọn GV chủ nhiệm:";
            // 
            // frmQuanLyLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(781, 475);
            this.Controls.Add(this.lblGVChuNhiem);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.cbGiaoVienChuNhiem);
            this.Controls.Add(this.txtLop);
            this.Controls.Add(this.picAvatar);
            this.Name = "frmQuanLyLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý lớp";
            this.Load += new System.EventHandler(this.frmQuanLyLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2TextBox txtLop;
        private Guna.UI2.WinForms.Guna2ComboBox cbGiaoVienChuNhiem;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLop;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGVChuNhiem;
    }
}