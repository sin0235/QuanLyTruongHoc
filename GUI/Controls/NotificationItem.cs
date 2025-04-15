using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls
{
    public class NotificationItem : Guna.UI2.WinForms.Guna2Panel
    {
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Label lblTitle;
        private Label lblSender;
        private Label lblDate;
        private Label lblContent;
        private Guna.UI2.WinForms.Guna2Separator separator;
        private Guna.UI2.WinForms.Guna2Button btnView;
        private bool isRead = false;

        public int NotificationId { get; set; }
        public bool IsRead
        {
            get { return isRead; }
            set
            {
                isRead = value;
                UpdateReadStatus();
            }
        }

        public NotificationItem(int id, string title, string sender, DateTime date, string content, string avatarPath = null, bool read = false)
        {
            NotificationId = id;
            isRead = read;

            this.Size = new Size(1550, 130);
            this.BorderRadius = 10;
            this.FillColor = isRead ? Color.White : Color.FromArgb(240, 249, 255);
            this.BorderColor = Color.FromArgb(230, 230, 230);
            this.BorderThickness = 1;
            this.Margin = new Padding(10, 5, 10, 5);
            this.Padding = new Padding(10);
            this.Cursor = Cursors.Hand;
            this.ShadowDecoration.Depth = 5;
            this.ShadowDecoration.Enabled = true;
            this.ShadowDecoration.Color = Color.FromArgb(200, 200, 200);

            picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox
            {
                Size = new Size(60, 60),
                Location = new Point(20, 20),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            if (!string.IsNullOrEmpty(avatarPath) && System.IO.File.Exists(avatarPath))
            {
                picAvatar.Image = Image.FromFile(avatarPath);
            }
            else
            {
                // Default avatar
                //picAvatar.Image = Properties.Resources.default_avatar;
            }

            lblTitle = new Label
            {
                AutoSize = false,
                Size = new Size(1000, 30),
                Location = new Point(100, 15),
                Text = title,
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                ForeColor = isRead ? Color.FromArgb(70, 70, 70) : Color.FromArgb(0, 120, 215)
            };

            lblSender = new Label
            {
                AutoSize = true,
                Location = new Point(100, 45),
                Text = sender,
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(100, 100, 100)
            };

            lblDate = new Label
            {
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(1380, 15),
                Text = FormatDate(date),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.FromArgb(150, 150, 150)
            };

            lblContent = new Label
            {
                AutoSize = false,
                Size = new Size(1300, 40),
                Location = new Point(100, 70),
                Text = content,
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(90, 90, 90)
            };

            btnView = new Guna.UI2.WinForms.Guna2Button
            {
                Size = new Size(100, 30),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Location = new Point(1420, 70),
                Text = "Xem",
                BorderRadius = 15,
                FillColor = Color.FromArgb(0, 120, 215),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Cursor = Cursors.Hand
            };

            separator = new Guna.UI2.WinForms.Guna2Separator
            {
                Size = new Size(1520, 1),
                Location = new Point(15, 120),
                FillColor = Color.FromArgb(230, 230, 230)
            };

            this.Controls.Add(picAvatar);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblSender);
            this.Controls.Add(lblDate);
            this.Controls.Add(lblContent);
            this.Controls.Add(btnView);
            this.Controls.Add(separator);

            this.Click += NotificationItem_Click;
            btnView.Click += BtnView_Click;

            foreach (Control control in this.Controls)
            {
                if (control != btnView)
                {
                    control.Click += NotificationItem_Click;
                }
            }
        }

        private void UpdateReadStatus()
        {
            this.FillColor = isRead ? Color.White : Color.FromArgb(240, 249, 255);
            lblTitle.ForeColor = isRead ? Color.FromArgb(70, 70, 70) : Color.FromArgb(0, 120, 215);
        }

        private void NotificationItem_Click(object sender, EventArgs e)
        {
            if (!isRead)
            {
                IsRead = true;
                // Cập nhật trạng thái đã đọc trong database
                // UpdateNotificationStatusInDatabase(NotificationId);
            }

            // Mở chi tiết thông báo
            OpenNotificationDetails();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (!isRead)
            {
                IsRead = true;
                // Cập nhật trạng thái đã đọc trong database
                // UpdateNotificationStatusInDatabase(NotificationId);
            }

            // Mở chi tiết thông báo
            OpenNotificationDetails();
        }

        // Update the OpenNotificationDetails method to call the parent's ShowNotificationDetails method
        private void OpenNotificationDetails()
        {
            // Get the parent ucThongBao control
            ucThongBao parentThongBao = this.FindForm()?.Controls.Find("ucThongBao1", true).FirstOrDefault() as ucThongBao;
            if (parentThongBao == null)
            {
                // Try to find parent in a different way - walking up the control hierarchy
                Control parent = this.Parent;
                while (parent != null && !(parent is ucThongBao))
                {
                    parent = parent.Parent;
                }
                parentThongBao = parent as ucThongBao;
            }

            if (parentThongBao != null)
            {
                // Call the parent's ShowNotificationDetails method
                parentThongBao.ShowNotificationDetails(
                    NotificationId,
                    lblTitle.Text,
                    lblSender.Text.StartsWith("Người gửi:") ? lblSender.Text.Substring(11).Trim() : lblSender.Text,
                    ParseDateFromText(lblDate.Text),
                    lblContent.Text
                );
            }
            else
            {
                // Fallback if parent not found
                MessageBox.Show($"Xem chi tiết thông báo: {lblTitle.Text}", "Chi tiết thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Helper method to parse the date from the formatted string
        private DateTime ParseDateFromText(string dateText)
        {
            try
            {
                // Handle "Hôm nay, HH:mm" format
                if (dateText.StartsWith("Hôm nay"))
                {
                    string timeStr = dateText.Substring(dateText.IndexOf(',') + 1).Trim();
                    TimeSpan time = TimeSpan.Parse(timeStr);
                    return DateTime.Today.Add(time);
                }
                // Handle "Hôm qua, HH:mm" format
                else if (dateText.StartsWith("Hôm qua"))
                {
                    string timeStr = dateText.Substring(dateText.IndexOf(',') + 1).Trim();
                    TimeSpan time = TimeSpan.Parse(timeStr);
                    return DateTime.Today.AddDays(-1).Add(time);
                }
                // Handle "Thứ ..., HH:mm" format
                else if (dateText.StartsWith("Thứ") || dateText.StartsWith("Chủ nhật"))
                {
                    string timeStr = dateText.Substring(dateText.IndexOf(',') + 1).Trim();
                    TimeSpan time = TimeSpan.Parse(timeStr);

                    // Approximate the date as we don't have exact date information
                    // We know it's within the last week
                    DateTime today = DateTime.Today;
                    for (int i = 1; i <= 7; i++)
                    {
                        DateTime checkDate = today.AddDays(-i);
                        if (GetDayOfWeek(checkDate).Equals(dateText.Substring(0, dateText.IndexOf(','))))
                        {
                            return checkDate.Add(time);
                        }
                    }
                    // Default to today if day of week not found
                    return today.Add(time);
                }
                // Handle "dd/MM/yyyy HH:mm" format
                else
                {
                    return DateTime.ParseExact(dateText, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            catch
            {
                // If parsing fails, return current date/time as fallback
                return DateTime.Now;
            }
        }

        private string FormatDate(DateTime date)
        {
            if (date.Date == DateTime.Today)
            {
                return $"Hôm nay, {date:HH:mm}";
            }
            else if (date.Date == DateTime.Today.AddDays(-1))
            {
                return $"Hôm qua, {date:HH:mm}";
            }
            else if ((DateTime.Today - date.Date).TotalDays < 7)
            {
                return $"{GetDayOfWeek(date)}, {date:HH:mm}";
            }
            else
            {
                return date.ToString("dd/MM/yyyy HH:mm");
            }
        }

        private string GetDayOfWeek(DateTime date)
        {
            string[] daysOfWeek = { "Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy" };
            return daysOfWeek[(int)date.DayOfWeek];
        }
    }
}
