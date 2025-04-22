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
            this.label1 = new System.Windows.Forms.Label();
            this.lamMoiTBBtn = new Guna.UI2.WinForms.Guna2Button();
            this.tbChungPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "THÔNG BÁO";
            // 
            // lamMoiTBBtn
            // 
            this.lamMoiTBBtn.BorderRadius = 20;
            this.lamMoiTBBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.lamMoiTBBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.lamMoiTBBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.lamMoiTBBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.lamMoiTBBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
            this.lamMoiTBBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lamMoiTBBtn.ForeColor = System.Drawing.Color.White;
            this.lamMoiTBBtn.Location = new System.Drawing.Point(1768, 18);
            this.lamMoiTBBtn.Name = "lamMoiTBBtn";
            this.lamMoiTBBtn.Size = new System.Drawing.Size(180, 45);
            this.lamMoiTBBtn.TabIndex = 5;
            this.lamMoiTBBtn.Text = "Làm mới";
            this.lamMoiTBBtn.Click += new System.EventHandler(this.lamMoiTBBtn_Click);
            // 
            // tbChungPanel
            // 
            this.tbChungPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbChungPanel.Location = new System.Drawing.Point(27, 89);
            this.tbChungPanel.Name = "tbChungPanel";
            this.tbChungPanel.Size = new System.Drawing.Size(1934, 952);
            this.tbChungPanel.TabIndex = 6;
            // 
            // ucThongBaoGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbChungPanel);
            this.Controls.Add(this.lamMoiTBBtn);
            this.Controls.Add(this.label1);
            this.Name = "ucThongBaoGiaoVien";
            this.Size = new System.Drawing.Size(1985, 1060);
            this.Load += new System.EventHandler(this.ucThongBaoGiaoVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button lamMoiTBBtn;
        private Guna.UI2.WinForms.Guna2Panel tbChungPanel;
    }
}
