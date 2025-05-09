using QuanLyTruongHoc.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Forms
{
    public partial class frmThongBaoChiTiet : Form
    {
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string NgayGui { get; set; }
        public string NguoiGui { get; set; }
        public frmThongBaoChiTiet(string tieuDe, string noiDung, string ngayGui, string nguoiGui)
        {
            InitializeComponent();
            // Gán giá trị cho các thuộc tính
            TieuDe = tieuDe;
            NoiDung = noiDung;
            NgayGui = ngayGui;
            NguoiGui = nguoiGui;

            // Hiển thị thông tin trên form
            LoadThongBaoChiTiet();
        }
        private void LoadThongBaoChiTiet()
        {
            string nguoiguitb;
            lblTieuDe.Text = $"Tiêu Đề: {TieuDe}";
            ndThongBaoTxt.Text = NoiDung;
            lblThoiGianGui.Text = $"Ngày: {NgayGui}";
            if (NguoiGui == "bgh")
            {
                nguoiguitb = "Ban Giám Hiệu";
            }
            else
            {
                nguoiguitb = NguoiGui;
            }
            lblNguoiGui.Text = nguoiguitb;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {

        }
    }
}

