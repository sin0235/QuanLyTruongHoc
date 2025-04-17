namespace QuanLyTruongHoc.GUI.Controls
{
    partial class ucTBChiTiet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTBChiTiet));
            this.pnlMain = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.pnlAttachment = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAttachmentTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.flpAttachments = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDownloadAll = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNguoiGui = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNgayGui = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNguoiNhan = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnReply = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
            this.btnForward = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlAttachment.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.pnlMain.BorderRadius = 15;
            this.pnlMain.BorderThickness = 1;
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlAttachment);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.FillColor = System.Drawing.Color.White;
            this.pnlMain.FillColor2 = System.Drawing.Color.White;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMain.ShadowDecoration.BorderRadius = 15;
            this.pnlMain.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlMain.ShadowDecoration.Depth = 10;
            this.pnlMain.ShadowDecoration.Enabled = true;
            this.pnlMain.Size = new System.Drawing.Size(900, 700);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlContent.BorderRadius = 10;
            this.pnlContent.BorderThickness = 1;
            this.pnlContent.Controls.Add(this.rtbContent);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this.pnlContent.Location = new System.Drawing.Point(15, 185);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(15);
            this.pnlContent.Size = new System.Drawing.Size(870, 360);
            this.pnlContent.TabIndex = 2;
            // 
            // rtbContent
            // 
            this.rtbContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(254)))));
            this.rtbContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbContent.Location = new System.Drawing.Point(15, 15);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.ReadOnly = true;
            this.rtbContent.Size = new System.Drawing.Size(840, 330);
            this.rtbContent.TabIndex = 0;
            this.rtbContent.Text = "Nội dung thông báo sẽ hiển thị ở đây...";
            // 
            // pnlAttachment
            // 
            this.pnlAttachment.BackColor = System.Drawing.Color.Transparent;
            this.pnlAttachment.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlAttachment.BorderRadius = 10;
            this.pnlAttachment.BorderThickness = 1;
            this.pnlAttachment.Controls.Add(this.lblAttachmentTitle);
            this.pnlAttachment.Controls.Add(this.flpAttachments);
            this.pnlAttachment.Controls.Add(this.btnDownloadAll);
            this.pnlAttachment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAttachment.FillColor = System.Drawing.Color.White;
            this.pnlAttachment.Location = new System.Drawing.Point(15, 545);
            this.pnlAttachment.Name = "pnlAttachment";
            this.pnlAttachment.Size = new System.Drawing.Size(870, 85);
            this.pnlAttachment.TabIndex = 3;
            // 
            // lblAttachmentTitle
            // 
            this.lblAttachmentTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAttachmentTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttachmentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblAttachmentTitle.Location = new System.Drawing.Point(15, 10);
            this.lblAttachmentTitle.Name = "lblAttachmentTitle";
            this.lblAttachmentTitle.Size = new System.Drawing.Size(131, 25);
            this.lblAttachmentTitle.TabIndex = 6;
            this.lblAttachmentTitle.Text = "Tệp đính kèm (0)";
            // 
            // flpAttachments
            // 
            this.flpAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpAttachments.Location = new System.Drawing.Point(15, 40);
            this.flpAttachments.Name = "flpAttachments";
            this.flpAttachments.Size = new System.Drawing.Size(728, 35);
            this.flpAttachments.TabIndex = 1;
            // 
            // btnDownloadAll
            // 
            this.btnDownloadAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadAll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnDownloadAll.BorderRadius = 8;
            this.btnDownloadAll.BorderThickness = 1;
            this.btnDownloadAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDownloadAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDownloadAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDownloadAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDownloadAll.FillColor = System.Drawing.Color.White;
            this.btnDownloadAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDownloadAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnDownloadAll.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadAll.Image")));
            this.btnDownloadAll.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDownloadAll.ImageSize = new System.Drawing.Size(16, 16);
            this.btnDownloadAll.Location = new System.Drawing.Point(749, 40);
            this.btnDownloadAll.Name = "btnDownloadAll";
            this.btnDownloadAll.Size = new System.Drawing.Size(107, 35);
            this.btnDownloadAll.TabIndex = 0;
            this.btnDownloadAll.Text = "Tải tất cả";
            this.btnDownloadAll.TextOffset = new System.Drawing.Point(8, 0);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.picAvatar);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblNguoiGui);
            this.pnlHeader.Controls.Add(this.lblNgayGui);
            this.pnlHeader.Controls.Add(this.lblNguoiNhan);
            this.pnlHeader.Controls.Add(this.guna2Separator1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(15, 15);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(870, 170);
            this.pnlHeader.TabIndex = 1;
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.picAvatar.Image = ((System.Drawing.Image)(resources.GetObject("picAvatar.Image")));
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(15, 15);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(60, 60);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(180)))));
            this.lblTitle.Location = new System.Drawing.Point(90, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(776, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Tiêu đề thông báo";
            // 
            // lblNguoiGui
            // 
            this.lblNguoiGui.BackColor = System.Drawing.Color.Transparent;
            this.lblNguoiGui.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiGui.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblNguoiGui.Location = new System.Drawing.Point(90, 55);
            this.lblNguoiGui.Name = "lblNguoiGui";
            this.lblNguoiGui.Size = new System.Drawing.Size(85, 25);
            this.lblNguoiGui.TabIndex = 2;
            this.lblNguoiGui.Text = "Người gửi:";
            // 
            // lblNgayGui
            // 
            this.lblNgayGui.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayGui.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayGui.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblNgayGui.Location = new System.Drawing.Point(90, 85);
            this.lblNgayGui.Name = "lblNgayGui";
            this.lblNgayGui.Size = new System.Drawing.Size(194, 22);
            this.lblNgayGui.TabIndex = 3;
            this.lblNgayGui.Text = "Ngày gửi: 15/04/2025 15:30";
            // 
            // lblNguoiNhan
            // 
            this.lblNguoiNhan.BackColor = System.Drawing.Color.Transparent;
            this.lblNguoiNhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblNguoiNhan.Location = new System.Drawing.Point(90, 115);
            this.lblNguoiNhan.Name = "lblNguoiNhan";
            this.lblNguoiNhan.Size = new System.Drawing.Size(267, 22);
            this.lblNguoiNhan.TabIndex = 4;
            this.lblNguoiNhan.Text = "Người nhận: Tất cả học sinh khối 10, 11, 12";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.guna2Separator1.Location = new System.Drawing.Point(15, 155);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(840, 10);
            this.guna2Separator1.TabIndex = 5;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFooter.Controls.Add(this.btnReply);
            this.pnlFooter.Controls.Add(this.btnPrint);
            this.pnlFooter.Controls.Add(this.btnForward);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(15, 630);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(870, 55);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnReply
            // 
            this.btnReply.BorderRadius = 8;
            this.btnReply.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReply.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReply.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReply.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReply.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnReply.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReply.ForeColor = System.Drawing.Color.White;
            this.btnReply.Image = ((System.Drawing.Image)(resources.GetObject("btnReply.Image")));
            this.btnReply.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReply.ImageSize = new System.Drawing.Size(18, 18);
            this.btnReply.Location = new System.Drawing.Point(15, 10);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(130, 36);
            this.btnReply.TabIndex = 0;
            this.btnReply.Text = "Trả lời";
            this.btnReply.TextOffset = new System.Drawing.Point(8, 0);
            // 
            // btnPrint
            // 
            this.btnPrint.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.btnPrint.BorderRadius = 8;
            this.btnPrint.BorderThickness = 1;
            this.btnPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrint.FillColor = System.Drawing.Color.White;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPrint.ImageSize = new System.Drawing.Size(18, 18);
            this.btnPrint.Location = new System.Drawing.Point(160, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 36);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "In";
            this.btnPrint.TextOffset = new System.Drawing.Point(8, 0);
            // 
            // btnForward
            // 
            this.btnForward.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.btnForward.BorderRadius = 8;
            this.btnForward.BorderThickness = 1;
            this.btnForward.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnForward.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnForward.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnForward.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnForward.FillColor = System.Drawing.Color.White;
            this.btnForward.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
            this.btnForward.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnForward.ImageSize = new System.Drawing.Size(18, 18);
            this.btnForward.Location = new System.Drawing.Point(285, 10);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(160, 36);
            this.btnForward.TabIndex = 2;
            this.btnForward.Text = "Chuyển tiếp";
            this.btnForward.TextOffset = new System.Drawing.Point(8, 0);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.btnClose.BorderRadius = 8;
            this.btnClose.BorderThickness = 1;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnClose.Location = new System.Drawing.Point(760, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 36);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            // 
            // ucTBChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlMain);
            this.Name = "ucTBChiTiet";
            this.Size = new System.Drawing.Size(900, 700);
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlAttachment.ResumeLayout(false);
            this.pnlAttachment.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNguoiGui;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNgayGui;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNguoiNhan;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private System.Windows.Forms.RichTextBox rtbContent;
        private Guna.UI2.WinForms.Guna2Panel pnlAttachment;
        private System.Windows.Forms.FlowLayoutPanel flpAttachments;
        private Guna.UI2.WinForms.Guna2Button btnDownloadAll;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAttachmentTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlFooter;
        private Guna.UI2.WinForms.Guna2Button btnReply;
        private Guna.UI2.WinForms.Guna2Button btnPrint;
        private Guna.UI2.WinForms.Guna2Button btnForward;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}
