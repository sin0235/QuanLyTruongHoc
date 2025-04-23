using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DAL;
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucTaoDonXinNghi : UserControl
    {
        private DatabaseHelper dbHelper;
        private int currentStudentId;
        private List<FileAttachment> attachments = new List<FileAttachment>();

        // Event để thông báo khi đơn được gửi thành công
        public event EventHandler OnSubmitSuccess;

        // Event để thông báo khi người dùng muốn hủy
        public event EventHandler OnCancel;

        public ucTaoDonXinNghi()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void ucTaoDonXinNghi_Load(object sender, EventArgs e)
        {
            // Lấy ID học sinh hiện tại từ form đăng nhập
            currentStudentId = QuanLyTruongHoc.frmLogin.LoggedInStudentId;

            // Thiết lập ngày mặc định
            dtpBatDau.Value = DateTime.Today;
            dtpKetThuc.Value = DateTime.Today;

            // Chọn loại đơn mặc định
            cboLoaiDon.SelectedIndex = 0;
        }

        /// <summary>
        /// Xử lý sự kiện khi chọn loại đơn khác nhau
        /// </summary>
        private void cboLoaiDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loaiDon = cboLoaiDon.SelectedItem.ToString();
            txtTieuDe.Text = loaiDon; // Tự động điền tiêu đề theo loại đơn
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút đính kèm
        /// </summary>
        private void btnDinhKem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Tất cả tệp|*.*|Hình ảnh|*.jpg;*.jpeg;*.png;*.gif|PDF|*.pdf|Word|*.doc;*.docx";
                    openFileDialog.Multiselect = true;
                    openFileDialog.Title = "Chọn tệp đính kèm";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileName in openFileDialog.FileNames)
                        {
                            // Kiểm tra kích thước tệp (tối đa 10MB)
                            FileInfo fileInfo = new FileInfo(fileName);
                            if (fileInfo.Length > 10 * 1024 * 1024)
                            {
                                MessageBox.Show($"Tệp {fileInfo.Name} có kích thước quá lớn (> 10MB)",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }

                            // Thêm vào danh sách đính kèm
                            FileAttachment attachment = new FileAttachment
                            {
                                FilePath = fileName,
                                FileName = Path.GetFileName(fileName),
                                FileSize = fileInfo.Length
                            };

                            attachments.Add(attachment);
                            AddAttachmentControl(attachment);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đính kèm tệp: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Thêm control hiển thị tệp đính kèm
        /// </summary>
        private void AddAttachmentControl(FileAttachment attachment)
        {
            // Tạo panel cho mỗi tệp đính kèm
            Guna.UI2.WinForms.Guna2Panel pnlAttachment = new Guna.UI2.WinForms.Guna2Panel
            {
                Size = new Size(150, 30),
                Margin = new Padding(3),
                BorderRadius = 5,
                BackColor = Color.FromArgb(240, 245, 255),
            };

            // Tạo label hiển thị tên tệp
            Label lblFileName = new Label
            {
                Text = ShortenFileName(attachment.FileName, 15),
                Font = new Font("Segoe UI", 9),
                Size = new Size(120, 20),
                Location = new Point(5, 5),
                AutoEllipsis = true
            };

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(lblFileName, attachment.FileName);
            // Tạo nút xóa
            Guna.UI2.WinForms.Guna2Button btnRemove = new Guna.UI2.WinForms.Guna2Button
            {
                Size = new Size(20, 20),
                Location = new Point(125, 5),
                FillColor = Color.FromArgb(250, 100, 100),
                Text = "×",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                BorderRadius = 10,
                Tag = attachment
            };
            btnRemove.Click += (s, e) => RemoveAttachment((FileAttachment)((Button)s).Tag, pnlAttachment);

            // Thêm các control vào panel
            pnlAttachment.Controls.Add(lblFileName);
            pnlAttachment.Controls.Add(btnRemove);

            // Thêm panel vào flowLayoutPanel
            flpDinhKem.Controls.Add(pnlAttachment);
        }

        /// <summary>
        /// Xóa tệp đính kèm khỏi danh sách
        /// </summary>
        private void RemoveAttachment(FileAttachment attachment, Control control)
        {
            attachments.Remove(attachment);
            flpDinhKem.Controls.Remove(control);
        }

        /// <summary>
        /// Rút gọn tên file nếu quá dài
        /// </summary>
        private string ShortenFileName(string fileName, int maxLength)
        {
            if (fileName.Length <= maxLength)
                return fileName;

            string extension = Path.GetExtension(fileName);
            string name = Path.GetFileNameWithoutExtension(fileName);

            if (name.Length <= maxLength - 5)
                return name + extension;

            return name.Substring(0, maxLength - 5) + "..." + extension;
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút gửi đơn
        /// </summary>
        private void btnGui_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SubmitLeaveRequest();
            }
        }

        /// <summary>
        /// Xác thực thông tin đầu vào
        /// </summary>
        private bool ValidateInput()
        {
            // Kiểm tra tiêu đề
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề đơn", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTieuDe.Focus();
                return false;
            }

            // Kiểm tra nội dung
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung đơn", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return false;
            }

            // Kiểm tra ngày nghỉ
            if (dtpKetThuc.Value < dtpBatDau.Value)
            {
                MessageBox.Show("Ngày kết thúc không được trước ngày bắt đầu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpKetThuc.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gửi đơn xin nghỉ học
        /// </summary>
        private void SubmitLeaveRequest()
        {
            try
            {
                // Tạo đơn xin nghỉ học mới
                string tieuDe = txtTieuDe.Text.Trim();
                string noiDung = txtNoiDung.Text.Trim();
                DateTime ngayBatDau = dtpBatDau.Value.Date;
                DateTime ngayKetThuc = dtpKetThuc.Value.Date;
                string loaiDon = cboLoaiDon.SelectedItem.ToString();

                // Thêm vào cơ sở dữ liệu
                string query = $@"
                    INSERT INTO DonXin (MaHS, TieuDe, NoiDung, LoaiDon, NgayBatDau, NgayKetThuc, NgayTao, TrangThai)
                    VALUES ({currentStudentId}, @TieuDe, @NoiDung, @LoaiDon, '{ngayBatDau:yyyy-MM-dd}', '{ngayKetThuc:yyyy-MM-dd}', GETDATE(), 0);
                    SELECT SCOPE_IDENTITY();";

                // Tạo tham số
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@TieuDe", tieuDe },
                    { "@NoiDung", noiDung },
                    { "@LoaiDon", loaiDon }
                };

                // Thực hiện truy vấn và lấy ID đơn xin
                object result = dbHelper.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    int donXinId = Convert.ToInt32(result);

                    // Lưu các tệp đính kèm (nếu có)
                    if (attachments.Count > 0)
                    {
                        SaveAttachments(donXinId);
                    }

                    MessageBox.Show("Đơn xin nghỉ học đã được gửi thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Kích hoạt sự kiện thành công
                    OnSubmitSuccess?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Có lỗi khi gửi đơn xin nghỉ học. Vui lòng thử lại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi đơn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lưu các tệp đính kèm vào cơ sở dữ liệu
        /// </summary>
        private void SaveAttachments(int donXinId)
        {
            foreach (FileAttachment attachment in attachments)
            {
                try
                {
                    // Đọc nội dung tệp thành mảng byte
                    byte[] fileContent = File.ReadAllBytes(attachment.FilePath);

                    // Thêm vào cơ sở dữ liệu
                    string query = $@"
                        INSERT INTO DinhKem (MaDon, TenFile, NoiDung, KichThuoc)
                        VALUES ({donXinId}, @TenFile, @NoiDung, {attachment.FileSize})";

                    Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@TenFile", attachment.FileName },
                        { "@NoiDung", fileContent }
                    };

                    dbHelper.ExecuteNonQuery(query, parameters);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu tệp đính kèm {attachment.FileName}: {ex.Message}",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút hủy
        /// </summary>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn hủy viết đơn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Kích hoạt sự kiện hủy
                OnCancel?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    /// <summary>
    /// Lớp lưu trữ thông tin tệp đính kèm
    /// </summary>
    public class FileAttachment
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }

        public string FormattedFileSize
        {
            get
            {
                string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
                int suffixIndex = 0;
                double size = FileSize;

                while (size >= 1024 && suffixIndex < suffixes.Length - 1)
                {
                    size /= 1024;
                    suffixIndex++;
                }

                return $"{size:0.##} {suffixes[suffixIndex]}";
            }
        }
    }
}
