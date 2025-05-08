namespace QuanLyTruongHoc.GUI.Forms
{
    partial class frmTaoBaiKiemTra
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
            this.ucControlBar1 = new QuanLyTruongHoc.GUI.Controls.ucControlBar();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.tabControlMain = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabThongTinChung = new System.Windows.Forms.TabPage();
            this.lblNoteTimeLimit = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblEndDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStartDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTestPeriod = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.numAttemptsAllowed = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblAttemptsAllowed = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.numDuration = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblDuration = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboTestType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTestType = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDescription = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboClass = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblClass = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboSubject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSubject = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTestName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTestName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblGeneralInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tabCauHoi = new System.Windows.Forms.TabPage();
            this.panelQuestions = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNoQuestions = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnImportQuestions = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddEssayQuestion = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddMultipleChoiceQuestion = new Guna.UI2.WinForms.Guna2Button();
            this.lblQuestionManagement = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tabCauHinhDiem = new System.Windows.Forms.TabPage();
            this.panelGrading = new Guna.UI2.WinForms.Guna2Panel();
            this.chkRandomizeQuestions = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkShowResultImmediately = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtGradingNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblGradingNotes = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.numPassingScore = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.lblPassingScore = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblGradingOptions = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tabXemTruoc = new System.Windows.Forms.TabPage();
            this.panelPreview = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPreviewTest = new Guna.UI2.WinForms.Guna2Button();
            this.lblPreviewInstruction = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.chkPassword = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPreviewTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelActions = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSaveDraft = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnPublish = new Guna.UI2.WinForms.Guna2Button();
            this.panelMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabThongTinChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAttemptsAllowed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.tabCauHoi.SuspendLayout();
            this.panelQuestions.SuspendLayout();
            this.tabCauHinhDiem.SuspendLayout();
            this.panelGrading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPassingScore)).BeginInit();
            this.tabXemTruoc.SuspendLayout();
            this.panelPreview.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucControlBar1
            // 
            this.ucControlBar1.BackColor = System.Drawing.Color.Transparent;
            this.ucControlBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucControlBar1.Location = new System.Drawing.Point(0, 0);
            this.ucControlBar1.Name = "ucControlBar1";
            this.ucControlBar1.Size = new System.Drawing.Size(1100, 40);
            this.ucControlBar1.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.BorderRadius = 15;
            this.panelMain.Controls.Add(this.tabControlMain);
            this.panelMain.Controls.Add(this.panelActions);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.FillColor = System.Drawing.Color.White;
            this.panelMain.Location = new System.Drawing.Point(0, 40);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1100, 660);
            this.panelMain.TabIndex = 1;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabThongTinChung);
            this.tabControlMain.Controls.Add(this.tabCauHoi);
            this.tabControlMain.Controls.Add(this.tabCauHinhDiem);
            this.tabControlMain.Controls.Add(this.tabXemTruoc);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControlMain.Location = new System.Drawing.Point(20, 20);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1060, 560);
            this.tabControlMain.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlMain.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControlMain.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlMain.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabControlMain.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControlMain.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlMain.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControlMain.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlMain.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tabControlMain.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControlMain.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabControlMain.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tabControlMain.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControlMain.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabControlMain.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tabControlMain.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControlMain.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tabThongTinChung
            // 
            this.tabThongTinChung.BackColor = System.Drawing.Color.White;
            this.tabThongTinChung.Controls.Add(this.lblNoteTimeLimit);
            this.tabThongTinChung.Controls.Add(this.dtpEndDate);
            this.tabThongTinChung.Controls.Add(this.dtpStartDate);
            this.tabThongTinChung.Controls.Add(this.lblEndDate);
            this.tabThongTinChung.Controls.Add(this.lblStartDate);
            this.tabThongTinChung.Controls.Add(this.lblTestPeriod);
            this.tabThongTinChung.Controls.Add(this.numAttemptsAllowed);
            this.tabThongTinChung.Controls.Add(this.lblAttemptsAllowed);
            this.tabThongTinChung.Controls.Add(this.numDuration);
            this.tabThongTinChung.Controls.Add(this.lblDuration);
            this.tabThongTinChung.Controls.Add(this.cboTestType);
            this.tabThongTinChung.Controls.Add(this.lblTestType);
            this.tabThongTinChung.Controls.Add(this.txtDescription);
            this.tabThongTinChung.Controls.Add(this.lblDescription);
            this.tabThongTinChung.Controls.Add(this.cboClass);
            this.tabThongTinChung.Controls.Add(this.lblClass);
            this.tabThongTinChung.Controls.Add(this.cboSubject);
            this.tabThongTinChung.Controls.Add(this.lblSubject);
            this.tabThongTinChung.Controls.Add(this.txtTestName);
            this.tabThongTinChung.Controls.Add(this.lblTestName);
            this.tabThongTinChung.Controls.Add(this.lblGeneralInfo);
            this.tabThongTinChung.Location = new System.Drawing.Point(4, 44);
            this.tabThongTinChung.Name = "tabThongTinChung";
            this.tabThongTinChung.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongTinChung.Size = new System.Drawing.Size(1052, 512);
            this.tabThongTinChung.TabIndex = 0;
            this.tabThongTinChung.Text = "Thông tin chung";
            // 
            // lblNoteTimeLimit
            // 
            this.lblNoteTimeLimit.BackColor = System.Drawing.Color.Transparent;
            this.lblNoteTimeLimit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblNoteTimeLimit.ForeColor = System.Drawing.Color.Gray;
            this.lblNoteTimeLimit.Location = new System.Drawing.Point(340, 223);
            this.lblNoteTimeLimit.Name = "lblNoteTimeLimit";
            this.lblNoteTimeLimit.Size = new System.Drawing.Size(279, 17);
            this.lblNoteTimeLimit.TabIndex = 21;
            this.lblNoteTimeLimit.Text = "* Đặt thời gian bằng 0 nếu không giới hạn thời gian";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BorderRadius = 5;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpEndDate.FillColor = System.Drawing.Color.White;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(553, 296);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowUpDown = true;
            this.dtpEndDate.Size = new System.Drawing.Size(200, 36);
            this.dtpEndDate.TabIndex = 19;
            this.dtpEndDate.Value = new System.DateTime(2025, 5, 15, 23, 59, 0, 0);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BorderRadius = 5;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpStartDate.FillColor = System.Drawing.Color.White;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(340, 296);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowUpDown = true;
            this.dtpStartDate.Size = new System.Drawing.Size(200, 36);
            this.dtpStartDate.TabIndex = 18;
            this.dtpStartDate.Value = new System.DateTime(2025, 5, 8, 7, 30, 0, 0);
            // 
            // lblEndDate
            // 
            this.lblEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEndDate.Location = new System.Drawing.Point(553, 272);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(93, 17);
            this.lblEndDate.TabIndex = 17;
            this.lblEndDate.Text = "Thời gian kết thúc";
            // 
            // lblStartDate
            // 
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStartDate.Location = new System.Drawing.Point(340, 272);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(91, 17);
            this.lblStartDate.TabIndex = 16;
            this.lblStartDate.Text = "Thời gian bắt đầu";
            // 
            // lblTestPeriod
            // 
            this.lblTestPeriod.BackColor = System.Drawing.Color.Transparent;
            this.lblTestPeriod.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTestPeriod.Location = new System.Drawing.Point(324, 245);
            this.lblTestPeriod.Name = "lblTestPeriod";
            this.lblTestPeriod.Size = new System.Drawing.Size(191, 22);
            this.lblTestPeriod.TabIndex = 15;
            this.lblTestPeriod.Text = "2. Thời gian mở cho học sinh";
            // 
            // numAttemptsAllowed
            // 
            this.numAttemptsAllowed.BackColor = System.Drawing.Color.Transparent;
            this.numAttemptsAllowed.BorderRadius = 5;
            this.numAttemptsAllowed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numAttemptsAllowed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numAttemptsAllowed.Location = new System.Drawing.Point(553, 194);
            this.numAttemptsAllowed.Maximum = new decimal(new int[] {
                        10,
                        0,
                        0,
                        0});
            this.numAttemptsAllowed.Minimum = new decimal(new int[] {
                        1,
                        0,
                        0,
                        0});
            this.numAttemptsAllowed.Name = "numAttemptsAllowed";
            this.numAttemptsAllowed.Size = new System.Drawing.Size(100, 25);
            this.numAttemptsAllowed.TabIndex = 14;
            this.numAttemptsAllowed.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numAttemptsAllowed.Value = new decimal(new int[] {
                        1,
                        0,
                        0,
                        0});
            // 
            // lblAttemptsAllowed
            // 
            this.lblAttemptsAllowed.BackColor = System.Drawing.Color.Transparent;
            this.lblAttemptsAllowed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAttemptsAllowed.Location = new System.Drawing.Point(553, 171);
            this.lblAttemptsAllowed.Name = "lblAttemptsAllowed";
            this.lblAttemptsAllowed.Size = new System.Drawing.Size(97, 17);
            this.lblAttemptsAllowed.TabIndex = 13;
            this.lblAttemptsAllowed.Text = "Số lần làm tối đa";
            // 
            // numDuration
            // 
            this.numDuration.BackColor = System.Drawing.Color.Transparent;
            this.numDuration.BorderRadius = 5;
            this.numDuration.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numDuration.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numDuration.Location = new System.Drawing.Point(340, 194);
            this.numDuration.Maximum = new decimal(new int[] {
                        180,
                        0,
                        0,
                        0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(100, 25);
            this.numDuration.TabIndex = 12;
            this.numDuration.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numDuration.Value = new decimal(new int[] {
                        45,
                        0,
                        0,
                        0});
            // 
            // lblDuration
            // 
            this.lblDuration.BackColor = System.Drawing.Color.Transparent;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDuration.Location = new System.Drawing.Point(340, 171);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(126, 17);
            this.lblDuration.TabIndex = 11;
            this.lblDuration.Text = "Thời gian làm bài (phút)";
            // 
            // cboTestType
            // 
            this.cboTestType.BackColor = System.Drawing.Color.Transparent;
            this.cboTestType.BorderRadius = 5;
            this.cboTestType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTestType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTestType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboTestType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTestType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboTestType.ItemHeight = 30;
            this.cboTestType.Items.AddRange(new object[] {
                        "Kiểm tra 15 phút",
                        "Kiểm tra 1 tiết",
                        "Kiểm tra học kỳ",
                        "Bài tập về nhà"});
            this.cboTestType.Location = new System.Drawing.Point(553, 120);
            this.cboTestType.Name = "cboTestType";
            this.cboTestType.Size = new System.Drawing.Size(200, 36);
            this.cboTestType.TabIndex = 10;
            // 
            // lblTestType
            // 
            this.lblTestType.BackColor = System.Drawing.Color.Transparent;
            this.lblTestType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTestType.Location = new System.Drawing.Point(553, 97);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(76, 17);
            this.lblTestType.TabIndex = 9;
            this.lblTestType.Text = "Loại kiểm tra";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderRadius = 5;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Location = new System.Drawing.Point(340, 367);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.PlaceholderText = "Hướng dẫn làm bài, mô tả...";
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(413, 100);
            this.txtDescription.TabIndex = 20;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescription.Location = new System.Drawing.Point(340, 343);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(114, 17);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Mô tả/Hướng dẫn làm bài";
            // 
            // cboClass
            // 
            this.cboClass.BackColor = System.Drawing.Color.Transparent;
            this.cboClass.BorderRadius = 5;
            this.cboClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClass.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboClass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboClass.ItemHeight = 30;
            this.cboClass.Location = new System.Drawing.Point(553, 46);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(200, 36);
            this.cboClass.TabIndex = 7;
            // 
            // lblClass
            // 
            this.lblClass.BackColor = System.Drawing.Color.Transparent;
            this.lblClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblClass.Location = new System.Drawing.Point(553, 23);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(23, 17);
            this.lblClass.TabIndex = 6;
            this.lblClass.Text = "Lớp";
            // 
            // cboSubject
            // 
            this.cboSubject.BackColor = System.Drawing.Color.Transparent;
            this.cboSubject.BorderRadius = 5;
            this.cboSubject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubject.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSubject.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSubject.ItemHeight = 30;
            this.cboSubject.Location = new System.Drawing.Point(340, 120);
            this.cboSubject.Name = "cboSubject";
            this.cboSubject.Size = new System.Drawing.Size(200, 36);
            this.cboSubject.TabIndex = 5;
            // 
            // lblSubject
            // 
            this.lblSubject.BackColor = System.Drawing.Color.Transparent;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubject.Location = new System.Drawing.Point(340, 97);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(59, 17);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Môn học";
            // 
            // txtTestName
            // 
            this.txtTestName.BorderRadius = 5;
            this.txtTestName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTestName.DefaultText = "";
            this.txtTestName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTestName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTestName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTestName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTestName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTestName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTestName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTestName.Location = new System.Drawing.Point(340, 46);
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.PasswordChar = '\0';
            this.txtTestName.PlaceholderText = "Nhập tên bài kiểm tra";
            this.txtTestName.SelectedText = "";
            this.txtTestName.Size = new System.Drawing.Size(200, 36);
            this.txtTestName.TabIndex = 3;
            // 
            // lblTestName
            // 
            this.lblTestName.BackColor = System.Drawing.Color.Transparent;
            this.lblTestName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTestName.Location = new System.Drawing.Point(340, 23);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(84, 17);
            this.lblTestName.TabIndex = 2;
            this.lblTestName.Text = "Tên bài kiểm tra";
            // 
            // lblGeneralInfo
            // 
            this.lblGeneralInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblGeneralInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblGeneralInfo.Location = new System.Drawing.Point(324, 0);
            this.lblGeneralInfo.Name = "lblGeneralInfo";
            this.lblGeneralInfo.Size = new System.Drawing.Size(129, 22);
            this.lblGeneralInfo.TabIndex = 1;
            this.lblGeneralInfo.Text = "1. Thông tin chung";
            // 
            // tabCauHoi
            // 
            this.tabCauHoi.BackColor = System.Drawing.Color.White;
            this.tabCauHoi.Controls.Add(this.panelQuestions);
            this.tabCauHoi.Controls.Add(this.btnImportQuestions);
            this.tabCauHoi.Controls.Add(this.btnAddEssayQuestion);
            this.tabCauHoi.Controls.Add(this.btnAddMultipleChoiceQuestion);
            this.tabCauHoi.Controls.Add(this.lblQuestionManagement);
            this.tabCauHoi.Location = new System.Drawing.Point(4, 44);
            this.tabCauHoi.Name = "tabCauHoi";
            this.tabCauHoi.Padding = new System.Windows.Forms.Padding(3);
            this.tabCauHoi.Size = new System.Drawing.Size(1052, 512);
            this.tabCauHoi.TabIndex = 1;
            this.tabCauHoi.Text = "Quản lý câu hỏi";
            // 
            // panelQuestions
            // 
            this.panelQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelQuestions.AutoScroll = true;
            this.panelQuestions.BorderColor = System.Drawing.Color.LightGray;
            this.panelQuestions.BorderRadius = 5;
            this.panelQuestions.BorderThickness = 1;
            this.panelQuestions.Controls.Add(this.lblNoQuestions);
            this.panelQuestions.Location = new System.Drawing.Point(20, 91);
            this.panelQuestions.Name = "panelQuestions";
            this.panelQuestions.Size = new System.Drawing.Size(1012, 403);
            this.panelQuestions.TabIndex = 4;
            // 
            // lblNoQuestions
            // 
            this.lblNoQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoQuestions.BackColor = System.Drawing.Color.Transparent;
            this.lblNoQuestions.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            this.lblNoQuestions.ForeColor = System.Drawing.Color.Gray;
            this.lblNoQuestions.Location = new System.Drawing.Point(395, 180);
            this.lblNoQuestions.Name = "lblNoQuestions";
            this.lblNoQuestions.Size = new System.Drawing.Size(250, 22);
            this.lblNoQuestions.TabIndex = 0;
            this.lblNoQuestions.Text = "Chưa có câu hỏi nào trong bài kiểm tra";
            // 
            // btnImportQuestions
            // 
            this.btnImportQuestions.BorderRadius = 5;
            this.btnImportQuestions.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnImportQuestions.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnImportQuestions.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnImportQuestions.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnImportQuestions.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnImportQuestions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnImportQuestions.ForeColor = System.Drawing.Color.White;
            this.btnImportQuestions.Location = new System.Drawing.Point(459, 50);
            this.btnImportQuestions.Name = "btnImportQuestions";
            this.btnImportQuestions.Size = new System.Drawing.Size(180, 36);
            this.btnImportQuestions.TabIndex = 3;
            this.btnImportQuestions.Text = "Nhập câu hỏi từ tệp";
            // 
            // btnAddEssayQuestion
            // 
            this.btnAddEssayQuestion.BorderRadius = 5;
            this.btnAddEssayQuestion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddEssayQuestion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddEssayQuestion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddEssayQuestion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddEssayQuestion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddEssayQuestion.ForeColor = System.Drawing.Color.White;
            this.btnAddEssayQuestion.Location = new System.Drawing.Point(244, 50);
            this.btnAddEssayQuestion.Name = "btnAddEssayQuestion";
            this.btnAddEssayQuestion.Size = new System.Drawing.Size(180, 36);
            this.btnAddEssayQuestion.TabIndex = 2;
            this.btnAddEssayQuestion.Text = "Thêm câu hỏi tự luận";
            // 
            // btnAddMultipleChoiceQuestion
            // 
            this.btnAddMultipleChoiceQuestion.BorderRadius = 5;
            this.btnAddMultipleChoiceQuestion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddMultipleChoiceQuestion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddMultipleChoiceQuestion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddMultipleChoiceQuestion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddMultipleChoiceQuestion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddMultipleChoiceQuestion.ForeColor = System.Drawing.Color.White;
            this.btnAddMultipleChoiceQuestion.Location = new System.Drawing.Point(20, 50);
            this.btnAddMultipleChoiceQuestion.Name = "btnAddMultipleChoiceQuestion";
            this.btnAddMultipleChoiceQuestion.Size = new System.Drawing.Size(180, 36);
            this.btnAddMultipleChoiceQuestion.TabIndex = 1;
            this.btnAddMultipleChoiceQuestion.Text = "Thêm câu hỏi trắc nghiệm";
            // 
            // lblQuestionManagement
            // 
            this.lblQuestionManagement.BackColor = System.Drawing.Color.Transparent;
            this.lblQuestionManagement.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblQuestionManagement.Location = new System.Drawing.Point(20, 20);
            this.lblQuestionManagement.Name = "lblQuestionManagement";
            this.lblQuestionManagement.Size = new System.Drawing.Size(120, 22);
            this.lblQuestionManagement.TabIndex = 0;
            this.lblQuestionManagement.Text = "Quản lý câu hỏi";
            // 
            // tabCauHinhDiem
            // 
            this.tabCauHinhDiem.BackColor = System.Drawing.Color.White;
            this.tabCauHinhDiem.Controls.Add(this.panelGrading);
            this.tabCauHinhDiem.Controls.Add(this.lblGradingOptions);
            this.tabCauHinhDiem.Location = new System.Drawing.Point(4, 44);
            this.tabCauHinhDiem.Name = "tabCauHinhDiem";
            this.tabCauHinhDiem.Size = new System.Drawing.Size(1052, 512);
            this.tabCauHinhDiem.TabIndex = 2;
            this.tabCauHinhDiem.Text = "Cấu hình điểm số";
            // 
            // panelGrading
            // 
            this.panelGrading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrading.BorderColor = System.Drawing.Color.LightGray;
            this.panelGrading.BorderRadius = 5;
            this.panelGrading.BorderThickness = 1;
            this.panelGrading.Controls.Add(this.chkRandomizeQuestions);
            this.panelGrading.Controls.Add(this.chkShowResultImmediately);
            this.panelGrading.Controls.Add(this.txtGradingNotes);
            this.panelGrading.Controls.Add(this.lblGradingNotes);
            this.panelGrading.Controls.Add(this.numPassingScore);
            this.panelGrading.Controls.Add(this.lblPassingScore);
            this.panelGrading.Location = new System.Drawing.Point(20, 48);
            this.panelGrading.Name = "panelGrading";
            this.panelGrading.Size = new System.Drawing.Size(1012, 446);
            this.panelGrading.TabIndex = 5;
            // 
            // chkRandomizeQuestions
            // 
            this.chkRandomizeQuestions.AutoSize = true;
            this.chkRandomizeQuestions.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkRandomizeQuestions.CheckedState.BorderRadius = 0;
            this.chkRandomizeQuestions.CheckedState.BorderThickness = 0;
            this.chkRandomizeQuestions.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkRandomizeQuestions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRandomizeQuestions.Location = new System.Drawing.Point(334, 89);
            this.chkRandomizeQuestions.Name = "chkRandomizeQuestions";
            this.chkRandomizeQuestions.Size = new System.Drawing.Size(178, 19);
            this.chkRandomizeQuestions.TabIndex = 5;
            this.chkRandomizeQuestions.Text = "Đảo thứ tự câu hỏi ngẫu nhiên";
            this.chkRandomizeQuestions.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkRandomizeQuestions.UncheckedState.BorderRadius = 0;
            this.chkRandomizeQuestions.UncheckedState.BorderThickness = 0;
            this.chkRandomizeQuestions.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkShowResultImmediately
            // 
            this.chkShowResultImmediately.AutoSize = true;
            this.chkShowResultImmediately.Checked = true;
            this.chkShowResultImmediately.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkShowResultImmediately.CheckedState.BorderRadius = 0;
            this.chkShowResultImmediately.CheckedState.BorderThickness = 0;
            this.chkShowResultImmediately.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkShowResultImmediately.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowResultImmediately.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowResultImmediately.Location = new System.Drawing.Point(334, 63);
            this.chkShowResultImmediately.Name = "chkShowResultImmediately";
            this.chkShowResultImmediately.Size = new System.Drawing.Size(153, 19);
            this.chkShowResultImmediately.TabIndex = 4;
            this.chkShowResultImmediately.Text = "Hiển thị kết quả ngay lập tức";
            this.chkShowResultImmediately.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkShowResultImmediately.UncheckedState.BorderRadius = 0;
            this.chkShowResultImmediately.UncheckedState.BorderThickness = 0;
            this.chkShowResultImmediately.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // txtGradingNotes
            // 
            this.txtGradingNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGradingNotes.BorderRadius = 5;
            this.txtGradingNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGradingNotes.DefaultText = "";
            this.txtGradingNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGradingNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGradingNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGradingNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGradingNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGradingNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGradingNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGradingNotes.Location = new System.Drawing.Point(334, 135);
            this.txtGradingNotes.Multiline = true;
            this.txtGradingNotes.Name = "txtGradingNotes";
            this.txtGradingNotes.PasswordChar = '\0';
            this.txtGradingNotes.PlaceholderText = "Nhập ghi chú về cách chấm điểm, tiêu chí...";
            this.txtGradingNotes.SelectedText = "";
            this.txtGradingNotes.Size = new System.Drawing.Size(658, 100);
            this.txtGradingNotes.TabIndex = 3;
            // 
            // lblGradingNotes
            // 
            this.lblGradingNotes.BackColor = System.Drawing.Color.Transparent;
            this.lblGradingNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGradingNotes.Location = new System.Drawing.Point(334, 115);
            this.lblGradingNotes.Name = "lblGradingNotes";
            this.lblGradingNotes.Size = new System.Drawing.Size(142, 17);
            this.lblGradingNotes.TabIndex = 2;
            this.lblGradingNotes.Text = "Ghi chú về cách chấm điểm";
            // 
            // numPassingScore
            // 
            this.numPassingScore.BackColor = System.Drawing.Color.Transparent;
            this.numPassingScore.BorderRadius = 5;
            this.numPassingScore.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numPassingScore.DecimalPlaces = 1;
            this.numPassingScore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numPassingScore.Increment = new decimal(new int[] {
                        5,
                        0,
                        0,
                        65536});
            this.numPassingScore.Location = new System.Drawing.Point(334, 27);
            this.numPassingScore.Maximum = new decimal(new int[] {
                        10,
                        0,
                        0,
                        0});
            this.numPassingScore.Name = "numPassingScore";
            this.numPassingScore.Size = new System.Drawing.Size(100, 25);
            this.numPassingScore.TabIndex = 1;
            this.numPassingScore.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numPassingScore.Value = new decimal(new int[] {
                        5,
                        0,
                        0,
                        0});
            // 
            // lblPassingScore
            // 
            this.lblPassingScore.BackColor = System.Drawing.Color.Transparent;
            this.lblPassingScore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassingScore.Location = new System.Drawing.Point(334, 3);
            this.lblPassingScore.Name = "lblPassingScore";
            this.lblPassingScore.Size = new System.Drawing.Size(94, 17);
            this.lblPassingScore.TabIndex = 0;
            this.lblPassingScore.Text = "Điểm đạt yêu cầu";
            // 
            // lblGradingOptions
            // 
            this.lblGradingOptions.BackColor = System.Drawing.Color.Transparent;
            this.lblGradingOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblGradingOptions.Location = new System.Drawing.Point(20, 20);
            this.lblGradingOptions.Name = "lblGradingOptions";
            this.lblGradingOptions.Size = new System.Drawing.Size(134, 22);
            this.lblGradingOptions.TabIndex = 0;
            this.lblGradingOptions.Text = "Cấu hình điểm số";
            // 
            // tabXemTruoc
            // 
            this.tabXemTruoc.BackColor = System.Drawing.Color.White;
            this.tabXemTruoc.Controls.Add(this.panelPreview);
            this.tabXemTruoc.Controls.Add(this.lblPreviewTitle);
            this.tabXemTruoc.Location = new System.Drawing.Point(4, 44);
            this.tabXemTruoc.Name = "tabXemTruoc";
            this.tabXemTruoc.Size = new System.Drawing.Size(1052, 512);
            this.tabXemTruoc.TabIndex = 3;
            this.tabXemTruoc.Text = "Xem trước và cài đặt";
            // 
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.BorderColor = System.Drawing.Color.LightGray;
            this.panelPreview.BorderRadius = 5;
            this.panelPreview.BorderThickness = 1;
            this.panelPreview.Controls.Add(this.btnPreviewTest);
            this.panelPreview.Controls.Add(this.lblPreviewInstruction);
            this.panelPreview.Controls.Add(this.chkPassword);
            this.panelPreview.Controls.Add(this.txtPassword);
            this.panelPreview.Location = new System.Drawing.Point(20, 48);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(1012, 446);
            this.panelPreview.TabIndex = 5;
            // 
            // btnPreviewTest
            // 
            this.btnPreviewTest.BorderRadius = 5;
            this.btnPreviewTest.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPreviewTest.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPreviewTest.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPreviewTest.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPreviewTest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPreviewTest.ForeColor = System.Drawing.Color.White;
            this.btnPreviewTest.Location = new System.Drawing.Point(429, 301);
            this.btnPreviewTest.Name = "btnPreviewTest";
            this.btnPreviewTest.Size = new System.Drawing.Size(180, 36);
            this.btnPreviewTest.TabIndex = 4;
            this.btnPreviewTest.Text = "Xem trước bài kiểm tra";
            // 
            // lblPreviewInstruction
            // 
            this.lblPreviewInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPreviewInstruction.BackColor = System.Drawing.Color.Transparent;
            this.lblPreviewInstruction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPreviewInstruction.Location = new System.Drawing.Point(344, 100);
            this.lblPreviewInstruction.Name = "lblPreviewInstruction";
            this.lblPreviewInstruction.Size = new System.Drawing.Size(370, 17);
            this.lblPreviewInstruction.TabIndex = 3;
            this.lblPreviewInstruction.Text = "Nhấn nút \"Xem trước bài kiểm tra\" để kiểm tra trước khi đăng bài cho học sinh";
            // 
            // chkPassword
            // 
            this.chkPassword.AutoSize = true;
            this.chkPassword.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkPassword.CheckedState.BorderRadius = 0;
            this.chkPassword.CheckedState.BorderThickness = 0;
            this.chkPassword.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkPassword.Location = new System.Drawing.Point(344, 173);
            this.chkPassword.Name = "chkPassword";
            this.chkPassword.Size = new System.Drawing.Size(156, 19);
            this.chkPassword.TabIndex = 1;
            this.chkPassword.Text = "Yêu cầu mật khẩu để làm bài";
            this.chkPassword.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkPassword.UncheckedState.BorderRadius = 0;
            this.chkPassword.UncheckedState.BorderThickness = 0;
            this.chkPassword.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 5;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.Enabled = false;
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(344, 198);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Nhập mật khẩu cho bài kiểm tra";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(343, 36);
            this.txtPassword.TabIndex = 2;
            // 
            // lblPreviewTitle
            // 
            this.lblPreviewTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPreviewTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblPreviewTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPreviewTitle.Name = "lblPreviewTitle";
            this.lblPreviewTitle.Size = new System.Drawing.Size(171, 22);
            this.lblPreviewTitle.TabIndex = 0;
            this.lblPreviewTitle.Text = "Xem trước và cài đặt thêm";
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnSaveDraft);
            this.panelActions.Controls.Add(this.btnCancel);
            this.panelActions.Controls.Add(this.btnPublish);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(20, 580);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1060, 60);
            this.panelActions.TabIndex = 1;
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveDraft.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSaveDraft.BorderRadius = 5;
            this.btnSaveDraft.BorderThickness = 1;
            this.btnSaveDraft.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveDraft.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveDraft.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveDraft.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveDraft.FillColor = System.Drawing.Color.White;
            this.btnSaveDraft.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaveDraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSaveDraft.Location = new System.Drawing.Point(731, 12);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(120, 36);
            this.btnSaveDraft.TabIndex = 3;
            this.btnSaveDraft.Text = "Lưu nháp";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(3, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy bỏ";
            // 
            // btnPublish
            // 
            this.btnPublish.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPublish.BorderRadius = 5;
            this.btnPublish.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPublish.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPublish.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPublish.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPublish.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPublish.ForeColor = System.Drawing.Color.White;
            this.btnPublish.Location = new System.Drawing.Point(869, 12);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(188, 36);
            this.btnPublish.TabIndex = 2;
            this.btnPublish.Text = "Đăng bài kiểm tra";
            // 
            // frmTaoBaiKiemTra
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.ucControlBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTaoBaiKiemTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo bài kiểm tra";
            this.Load += new System.EventHandler(this.frmTaoBaiKiemTra_Load);
            this.panelMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabThongTinChung.ResumeLayout(false);
            this.tabThongTinChung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAttemptsAllowed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.tabCauHoi.ResumeLayout(false);
            this.tabCauHoi.PerformLayout();
            this.panelQuestions.ResumeLayout(false);
            this.tabCauHinhDiem.ResumeLayout(false);
            this.tabCauHinhDiem.PerformLayout();
            this.panelGrading.ResumeLayout(false);
            this.panelGrading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPassingScore)).EndInit();
            this.tabXemTruoc.ResumeLayout(false);
            this.tabXemTruoc.PerformLayout();
            this.panelPreview.ResumeLayout(false);
            this.panelPreview.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ucControlBar ucControlBar1;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Guna.UI2.WinForms.Guna2TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabThongTinChung;
        private System.Windows.Forms.TabPage tabCauHoi;
        private System.Windows.Forms.TabPage tabCauHinhDiem;
        private System.Windows.Forms.TabPage tabXemTruoc;
        private Guna.UI2.WinForms.Guna2Panel panelActions;
        private Guna.UI2.WinForms.Guna2Button btnSaveDraft;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnPublish;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGeneralInfo;
        private Guna.UI2.WinForms.Guna2TextBox txtTestName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTestName;
        private Guna.UI2.WinForms.Guna2ComboBox cboSubject;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubject;
        private Guna.UI2.WinForms.Guna2ComboBox cboClass;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblClass;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDescription;
        private Guna.UI2.WinForms.Guna2ComboBox cboTestType;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTestType;
        private Guna.UI2.WinForms.Guna2NumericUpDown numAttemptsAllowed;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAttemptsAllowed;
        private Guna.UI2.WinForms.Guna2NumericUpDown numDuration;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDuration;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEndDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStartDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTestPeriod;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNoteTimeLimit;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQuestionManagement;
        private Guna.UI2.WinForms.Guna2Button btnAddMultipleChoiceQuestion;
        private Guna.UI2.WinForms.Guna2Button btnImportQuestions;
        private Guna.UI2.WinForms.Guna2Button btnAddEssayQuestion;
        private Guna.UI2.WinForms.Guna2Panel panelQuestions;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNoQuestions;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGradingOptions;
        private Guna.UI2.WinForms.Guna2Panel panelGrading;
        private Guna.UI2.WinForms.Guna2NumericUpDown numPassingScore;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPassingScore;
        private Guna.UI2.WinForms.Guna2TextBox txtGradingNotes;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGradingNotes;
        private Guna.UI2.WinForms.Guna2CheckBox chkShowResultImmediately;
        private Guna.UI2.WinForms.Guna2CheckBox chkRandomizeQuestions;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPreviewTitle;
        private Guna.UI2.WinForms.Guna2Panel panelPreview;
        private Guna.UI2.WinForms.Guna2CheckBox chkPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPreviewInstruction;
        private Guna.UI2.WinForms.Guna2Button btnPreviewTest;
    }
}
