namespace QuanLyTruongHoc.GUI.Controls
{
    partial class ucThongBaoGiaoVien
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
            this.lamMoiTBBtn = new Guna.UI2.WinForms.Guna2Button();
            this.tbChungPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lamMoiTBBtn
            // 
            this.lamMoiTBBtn.BorderRadius = 25;
            this.lamMoiTBBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.lamMoiTBBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.lamMoiTBBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.lamMoiTBBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.lamMoiTBBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.lamMoiTBBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lamMoiTBBtn.ForeColor = System.Drawing.Color.White;
            this.lamMoiTBBtn.Location = new System.Drawing.Point(8, 20);
            this.lamMoiTBBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lamMoiTBBtn.Name = "lamMoiTBBtn";
            this.lamMoiTBBtn.Size = new System.Drawing.Size(191, 52);
            this.lamMoiTBBtn.TabIndex = 5;
            this.lamMoiTBBtn.Text = "Làm mới";
            this.lamMoiTBBtn.Click += new System.EventHandler(this.lamMoiTBBtn_Click);
            // 
            // tbChungPanel
            // 
            this.tbChungPanel.AutoScroll = true;
            this.tbChungPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(145)))), ((int)(((byte)(215)))));
            this.tbChungPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.tbChungPanel.Location = new System.Drawing.Point(8, 87);
            this.tbChungPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tbChungPanel.Name = "tbChungPanel";
            this.tbChungPanel.Size = new System.Drawing.Size(1588, 698);
            this.tbChungPanel.TabIndex = 6;
            this.tbChungPanel.WrapContents = false;
            // 
            // ucThongBaoGiaoVien
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.lamMoiTBBtn);
            this.Controls.Add(this.tbChungPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucThongBaoGiaoVien";
            this.Size = new System.Drawing.Size(1600, 800);
            this.Load += new System.EventHandler(this.ucThongBaoGiaoVien_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button lamMoiTBBtn;
        private System.Windows.Forms.FlowLayoutPanel tbChungPanel;
    }
}
