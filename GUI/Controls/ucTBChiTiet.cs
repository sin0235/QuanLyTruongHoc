using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucTBChiTiet : UserControl
    {
        public event EventHandler OnClose;
        public event EventHandler OnReply;
        public event EventHandler OnForward;

        public class AttachmentInfo
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
            public long FileSize { get; set; }
        }

        private List<AttachmentInfo> attachments = new List<AttachmentInfo>();

        public ucTBChiTiet()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            btnClose.Click += (sender, e) => OnClose?.Invoke(this, EventArgs.Empty);
            btnReply.Click += (sender, e) => OnReply?.Invoke(this, EventArgs.Empty);
            btnForward.Click += (sender, e) => OnForward?.Invoke(this, EventArgs.Empty);
            btnPrint.Click += BtnPrint_Click;
            btnDownloadAll.Click += BtnDownloadAll_Click;
        }

        public void LoadThongBao(int thongBaoId, string title, string sender, string receiver,
                         DateTime date, string content, Image senderAvatar = null,
                         List<AttachmentInfo> attachmentList = null)
        {
            // Set the notification details
            lblTitle.Text = title;
            lblNguoiGui.Text = $"Người gửi: {sender}";
            lblNgayGui.Text = $"Ngày gửi: {FormatDate(date)}";
            lblNguoiNhan.Text = $"Người nhận: {receiver}"; // Hiển thị người nhận
            rtbContent.Text = content;

            // Set avatar
            if (senderAvatar != null)
            {
                picAvatar.Image = senderAvatar;
            }

            // Load attachments if any
            LoadAttachments(attachmentList);
        }


        private void LoadAttachments(List<AttachmentInfo> attachmentList)
        {
            flpAttachments.Controls.Clear();
            attachments.Clear();

            if (attachmentList != null && attachmentList.Count > 0)
            {
                attachments.AddRange(attachmentList);
                lblAttachmentTitle.Text = $"Tệp đính kèm ({attachmentList.Count})";
                pnlAttachment.Visible = true;

                foreach (var attachment in attachmentList)
                {
                    AddAttachmentControl(attachment);
                }
            }
            else
            {
                lblAttachmentTitle.Text = "Tệp đính kèm (0)";
                pnlAttachment.Visible = false;
            }
        }

        private void AddAttachmentControl(AttachmentInfo attachment)
        {
            var btnAttachment = new Guna.UI2.WinForms.Guna2Button
            {
                Text = $"{attachment.FileName} ({FormatFileSize(attachment.FileSize)})",
                Size = new Size(180, 30),
                BorderRadius = 5,
                FillColor = Color.FromArgb(245, 248, 250),
                ForeColor = Color.FromArgb(0, 120, 215),
                Font = new Font("Segoe UI", 9),
                TextAlign = HorizontalAlignment.Left,
                Margin = new Padding(5, 0, 5, 0),
                Cursor = Cursors.Hand,
                Tag = attachment
            };

            // Add icon based on file extension
            string extension = Path.GetExtension(attachment.FileName).ToLower();
            Image icon = GetFileIcon(extension);
            if (icon != null)
            {
                btnAttachment.Image = icon;
                btnAttachment.ImageAlign = HorizontalAlignment.Left;
                btnAttachment.ImageSize = new Size(16, 16);
                btnAttachment.TextOffset = new Point(5, 0);
            }

            btnAttachment.Click += BtnAttachment_Click;
            flpAttachments.Controls.Add(btnAttachment);
        }

        private void BtnAttachment_Click(object sender, EventArgs e)
        {
            if (sender is Guna.UI2.WinForms.Guna2Button btn && btn.Tag is AttachmentInfo attachment)
            {
                // Handle file download or open
                try
                {
                    // Check if file exists
                    if (File.Exists(attachment.FilePath))
                    {
                        System.Diagnostics.Process.Start(attachment.FilePath);
                    }
                    else
                    {
                        MessageBox.Show($"Không tìm thấy file: {attachment.FileName}",
                                      "Lỗi mở file",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở file: {ex.Message}",
                                  "Lỗi",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

        private void BtnDownloadAll_Click(object sender, EventArgs e)
        {
            if (attachments.Count == 0)
            {
                MessageBox.Show("Không có tệp đính kèm nào để tải xuống.",
                              "Thông báo",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                return;
            }

            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Chọn thư mục lưu tệp đính kèm";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetFolder = folderDialog.SelectedPath;
                    int successCount = 0;

                    foreach (var attachment in attachments)
                    {
                        try
                        {
                            string targetPath = Path.Combine(targetFolder, attachment.FileName);
                            File.Copy(attachment.FilePath, targetPath, true);
                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi tải file {attachment.FileName}: {ex.Message}",
                                          "Lỗi",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        }
                    }

                    MessageBox.Show($"Đã tải xuống {successCount}/{attachments.Count} tệp đính kèm.",
                                  "Hoàn tất",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            // Print functionality
            PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += PrintDocument_PrintPage;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Set up printing
            Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 12);
            Font contentFont = new Font("Segoe UI", 11);

            int y = 100;
            int leftMargin = 50;
            int rightMargin = e.MarginBounds.Right - 50;
            int width = rightMargin - leftMargin;

            // Print title
            e.Graphics.DrawString(lblTitle.Text, titleFont, Brushes.Navy, leftMargin, y);
            y += 50;

            // Print sender info
            e.Graphics.DrawString(lblNguoiGui.Text, headerFont, Brushes.Black, leftMargin, y);
            y += 30;

            // Print date info
            e.Graphics.DrawString(lblNgayGui.Text, headerFont, Brushes.Black, leftMargin, y);
            y += 30;

            // Print receiver info
            e.Graphics.DrawString(lblNguoiNhan.Text, headerFont, Brushes.Black, leftMargin, y);
            y += 50;

            // Print separator
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), leftMargin, y, rightMargin, y);
            y += 20;

            // Print content
            e.Graphics.DrawString(rtbContent.Text, contentFont, Brushes.Black,
                                new RectangleF(leftMargin, y, width, e.MarginBounds.Bottom - y));

            // Print attachments info if any
            if (attachments.Count > 0)
            {
                y = e.MarginBounds.Bottom - 100;
                e.Graphics.DrawLine(new Pen(Color.Gray, 1), leftMargin, y, rightMargin, y);
                y += 20;
                e.Graphics.DrawString($"Tệp đính kèm ({attachments.Count}):", headerFont, Brushes.Black, leftMargin, y);
                y += 25;

                foreach (var attachment in attachments)
                {
                    e.Graphics.DrawString($"- {attachment.FileName} ({FormatFileSize(attachment.FileSize)})",
                                        contentFont, Brushes.Black, leftMargin, y);
                    y += 20;
                }
            }
        }

        private string FormatDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy HH:mm");
        }

        private string FormatFileSize(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int counter = 0;
            double size = bytes;
            while (size > 1024 && counter < suffixes.Length - 1)
            {
                size /= 1024;
                counter++;
            }
            return $"{size:0.##} {suffixes[counter]}";
        }
        private Image GetFileIcon(string extension)
        {
            // This would be replaced with actual file icons based on extension
            // For example, you could use a switch statement to return different icons
            // based on common file types (PDF, DOC, XLS, etc.)

            // For now, we'll return a generic file icon
            return null; // Replace with actual icon resource
        }
    }
    // No changes needed to ucTBChiTiet.cs. The class already has:
    // 1. The LoadThongBao method to display notification details
    // 2. The OnClose event that gets triggered when the close button is clicked
    // 3. Methods to handle file attachments
}
