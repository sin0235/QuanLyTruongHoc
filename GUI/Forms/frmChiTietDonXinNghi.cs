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
using Guna.UI2.WinForms;
using QuanLyTruongHoc.DAL;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmChiTietDonXinNghi : Form
    {
        private readonly int _maDon;
        private readonly DatabaseHelper _dbHelper;
        private readonly List<int> _attachmentIds = new List<int>();

        // Variables for dragging the form
        private bool isDragging = false;
        private Point startPoint;

        public frmChiTietDonXinNghi(int maDon)
        {
            InitializeComponent();
            _maDon = maDon;
            _dbHelper = new DatabaseHelper();

            // Apply shadow to form
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void frmChiTietDonXinNghi_Load(object sender, EventArgs e)
        {
            LoadDonXinNghi();
            LoadFileAttachments();
        }

        /// <summary>
        /// Tải thông tin đơn xin nghỉ
        /// </summary>
        private void LoadDonXinNghi()
        {
            try
            {
                string query = $@"
                        SELECT 
                            d.MaDon, 
                            d.TieuDe, 
                            d.NoiDung, 
                            d.NgayBatDau, 
                            d.NgayKetThuc, 
                            d.NgayTao,
                            d.TrangThai,
                            d.PhanHoi,
                            hs.HoTen as TenHocSinh,
                            gv.HoTen as NguoiDuyet
                        FROM DonXin d
                        INNER JOIN HocSinh hs ON d.MaHS = hs.MaHS
                        LEFT JOIN GiaoVien gv ON d.MaGVDuyet = gv.MaGV
                        WHERE d.MaDon = {_maDon}";

                DataTable data = _dbHelper.ExecuteQuery(query);

                if (data != null && data.Rows.Count > 0)
                {
                    DataRow row = data.Rows[0];

                    // Hiển thị thông tin đơn xin nghỉ
                    this.Text = $"Chi tiết đơn xin nghỉ #{_maDon}";
                    lblFormTitle.Text = $"Chi tiết đơn xin nghỉ #{_maDon}";
                    lblTieuDe.Text = row["TieuDe"].ToString();
                    lblNgayTao.Text = $"Ngày tạo: {Convert.ToDateTime(row["NgayTao"]).ToString("dd/MM/yyyy HH:mm")}";

                    // Hiển thị thời gian nghỉ
                    DateTime ngayBD = Convert.ToDateTime(row["NgayBatDau"]);
                    DateTime ngayKT = Convert.ToDateTime(row["NgayKetThuc"]);
                    string strNgayNghi;

                    if (ngayBD.Date == ngayKT.Date)
                        strNgayNghi = $"Ngày nghỉ: {ngayBD.ToString("dd/MM/yyyy")}";
                    else
                        strNgayNghi = $"Thời gian nghỉ: {ngayBD.ToString("dd/MM/yyyy")} - {ngayKT.ToString("dd/MM/yyyy")}";

                    lblThoiGianNghi.Text = strNgayNghi;

                    // Hiển thị nội dung đơn
                    txtNoiDung.Text = row["NoiDung"].ToString();

                    // Hiển thị trạng thái
                    int trangThai = Convert.ToInt32(row["TrangThai"]);
                    switch (trangThai)
                    {
                        case 0: // Đang chờ
                            lblTrangThai.Text = "Trạng thái: Đang chờ duyệt";
                            lblTrangThai.ForeColor = Color.FromArgb(255, 240, 150); // Light Yellow
                            break;
                        case 1: // Đã duyệt
                            lblTrangThai.Text = "Trạng thái: Đã duyệt";
                            lblTrangThai.ForeColor = Color.FromArgb(180, 255, 180); // Light Green
                            break;
                        case 2: // Từ chối
                            lblTrangThai.Text = "Trạng thái: Từ chối";
                            lblTrangThai.ForeColor = Color.FromArgb(255, 160, 160); // Light Red
                            break;
                    }

                    // Hiển thị thông tin người duyệt và phản hồi
                    if (trangThai > 0)
                    {
                        string nguoiDuyet = row["NguoiDuyet"].ToString();
                        if (!string.IsNullOrEmpty(nguoiDuyet))
                            lblNguoiDuyet.Text = $"Người duyệt: {nguoiDuyet}";
                        else
                            lblNguoiDuyet.Visible = false;

                        string phanHoi = row["PhanHoi"].ToString();
                        if (!string.IsNullOrEmpty(phanHoi))
                        {
                            lblPhanHoiTitle.Visible = true;
                            txtPhanHoi.Visible = true;
                            txtPhanHoi.Text = phanHoi;
                        }
                        else
                        {
                            lblPhanHoiTitle.Visible = false;
                            txtPhanHoi.Visible = false;
                        }
                    }
                    else
                    {
                        lblNguoiDuyet.Visible = false;
                        lblPhanHoiTitle.Visible = false;
                        txtPhanHoi.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin đơn xin nghỉ.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tải thông tin đơn xin nghỉ: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Tải danh sách tệp đính kèm
        /// </summary>
        private void LoadFileAttachments()
        {
            try
            {
                string query = $@"
                        SELECT MaDinhKem, TenFile, KichThuoc 
                        FROM DinhKem 
                        WHERE MaDon = {_maDon}";

                DataTable data = _dbHelper.ExecuteQuery(query);

                if (data != null && data.Rows.Count > 0)
                {
                    pnlDinhKem.Visible = true;

                    foreach (DataRow row in data.Rows)
                    {
                        int maDinhKem = Convert.ToInt32(row["MaDinhKem"]);
                        string tenFile = row["TenFile"].ToString();
                        long kichThuoc = Convert.ToInt64(row["KichThuoc"]);

                        _attachmentIds.Add(maDinhKem);

                        // Tạo control hiển thị tệp đính kèm
                        AddAttachmentControl(maDinhKem, tenFile, kichThuoc);
                    }
                }
                else
                {
                    pnlDinhKem.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tải tệp đính kèm: {ex.Message}",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pnlDinhKem.Visible = false;
            }
        }

        /// <summary>
        /// Tạo control hiển thị tệp đính kèm
        /// </summary>
        private void AddAttachmentControl(int maDinhKem, string tenFile, long kichThuoc)
        {
            // Tạo panel chứa thông tin tệp
            Guna2Panel pnlFile = new Guna2Panel
            {
                Size = new Size(flpDinhKem.Width - 25, 40),
                Margin = new Padding(3),
                BorderRadius = 5,
                FillColor = Color.FromArgb(250, 252, 255),
                BorderColor = Color.FromArgb(230, 240, 250),
                BorderThickness = 1
            };

            // Tạo icon tệp
            PictureBox picIcon = new PictureBox
            {
                Size = new Size(24, 24),
                Location = new Point(10, 7),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = GetFileIcon(Path.GetExtension(tenFile)),
                BackColor = Color.Transparent
            };

            // Tạo label hiển thị tên tệp
            Label lblFileName = new Label
            {
                Text = tenFile,
                Font = new Font("Segoe UI", 9),
                Size = new Size(pnlFile.Width - 180, 20),
                Location = new Point(40, 10),
                AutoEllipsis = true,
                BackColor = Color.Transparent
            };

            // Tạo label hiển thị kích thước
            Label lblFileSize = new Label
            {
                Text = FormatFileSize(kichThuoc),
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Size = new Size(70, 20),
                Location = new Point(pnlFile.Width - 130, 10),
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.Transparent
            };

            // Tạo nút tải xuống
            Guna2Button btnDownload = new Guna2Button
            {
                Text = "Tải xuống",
                Size = new Size(80, 25),
                Location = new Point(pnlFile.Width - 90, 7),
                Tag = maDinhKem,
                Cursor = Cursors.Hand,
                BorderRadius = 5,
                FillColor = Color.FromArgb(100, 150, 200),
                Font = new Font("Segoe UI", 9)
            };
            btnDownload.Click += (s, e) => DownloadAttachment((int)((Guna2Button)s).Tag, tenFile);

            // Thêm các control vào panel
            pnlFile.Controls.Add(picIcon);
            pnlFile.Controls.Add(lblFileName);
            pnlFile.Controls.Add(lblFileSize);
            pnlFile.Controls.Add(btnDownload);

            // Thêm panel vào flowLayoutPanel
            flpDinhKem.Controls.Add(pnlFile);
        }

        /// <summary>
        /// Tải xuống tệp đính kèm
        /// </summary>
        private void DownloadAttachment(int maDinhKem, string tenFile)
        {
            try
            {
                // Tạo SaveFileDialog để chọn nơi lưu
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.FileName = tenFile;
                    saveDialog.Filter = "All Files|*.*";
                    saveDialog.Title = "Lưu tệp đính kèm";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Truy vấn lấy nội dung tệp
                        string query = $"SELECT NoiDung FROM DinhKem WHERE MaDinhKem = {maDinhKem}";
                        byte[] fileData = _dbHelper.DownloadFile(query);

                        if (fileData != null && fileData.Length > 0)
                        {
                            // Lưu tệp xuống ổ đĩa
                            File.WriteAllBytes(saveDialog.FileName, fileData);
                            MessageBox.Show("Tải xuống tệp thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể tải xuống tệp. Tệp không tồn tại hoặc đã bị xóa.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải xuống tệp: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Format kích thước tệp
        /// </summary>
        private string FormatFileSize(long fileSize)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int suffixIndex = 0;
            double size = fileSize;

            while (size >= 1024 && suffixIndex < suffixes.Length - 1)
            {
                size /= 1024;
                suffixIndex++;
            }

            return $"{size:0.##} {suffixes[suffixIndex]}";
        }

        /// <summary>
        /// Lấy icon tương ứng với loại tệp
        /// </summary>
        private Image GetFileIcon(string extension)
        {
            // Sử dụng SystemIcons.Application thay vì SystemIcons.Document
            return System.Drawing.SystemIcons.Application.ToBitmap();
        }

        #region Form Control Methods

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút đóng
        /// </summary>
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Handle form dragging
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        #endregion
    }
}
