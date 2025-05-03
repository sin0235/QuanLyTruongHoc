using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls
{
    public partial class ucTKBItem : UserControl
    {
        // Properties to store data
        private string _monHoc = "Môn học";
        private string _giaoVien = "Giáo viên";
        private string _phongHoc = "Phòng học";
        private string _thoiGian = "Thời gian";
        private string _noiDung = "Nội dung";
        private int _tiet = 1;
        private Color _color = Color.FromArgb(94, 148, 255); // Default blue color

        public string MonHoc
        {
            get { return _monHoc; }
            set { _monHoc = value; lblMonHoc.Text = value; }
        }

        public string GiaoVien
        {
            get { return _giaoVien; }
            set { _giaoVien = value; lblGiaoVien.Text = value; }
        }

        public string PhongHoc
        {
            get { return _phongHoc; }
            set { _phongHoc = value; lblPhong.Text = value; }
        }

        public string ThoiGian
        {
            get { return _thoiGian; }
            set { _thoiGian = value; lblThoigian.Text = value; }
        }

        public string NoiDung
        {
            get { return _noiDung; }
            set { _noiDung = value; lblNoidung.Text = value; }
        }

        public int Tiet
        {
            get { return _tiet; }
            set
            {
                _tiet = value;
                lblTiet.Text = $"#{value}";

                // Update color based on period number
                SetColorByTiet(value);
            }
        }

        public Color TietColor
        {
            get { return _color; }
            set
            {
                _color = value;
                pnlColor.FillColor = value;
            }
        }

        public ucTKBItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with parameters to initialize the control
        /// </summary>
        public ucTKBItem(string monHoc, string giaoVien, string phongHoc, string thoiGian, string noiDung, int tiet)
        {
            InitializeComponent();

            MonHoc = monHoc;
            GiaoVien = giaoVien;
            PhongHoc = phongHoc;
            ThoiGian = thoiGian;
            NoiDung = noiDung;
            Tiet = tiet;
        }

        /// <summary>
        /// Set color based on period number
        /// </summary>
        private void SetColorByTiet(int tiet)
        {
            // Different colors for different periods
            switch (tiet % 5)
            {
                case 1:
                    TietColor = Color.FromArgb(94, 148, 255);  // Blue
                    break;
                case 2:
                    TietColor = Color.FromArgb(121, 85, 196);  // Purple
                    break;
                case 3:
                    TietColor = Color.FromArgb(60, 180, 100);  // Green
                    break;
                case 4:
                    TietColor = Color.FromArgb(255, 128, 0);   // Orange
                    break;
                case 0:
                    TietColor = Color.FromArgb(219, 68, 103);  // Pink
                    break;
            }
        }

        private void lblPhong_Click(object sender, EventArgs e)
        {

        }

        private void lblNoidung_Click(object sender, EventArgs e)
        {

        }

        private void lblThoigian_Click(object sender, EventArgs e)
        {

        }
    }
}
