using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DAL
{
    public class ThongBaoDTO
    {
        public int MaTB { get; set; } // Mã thông báo
        public string TieuDe { get; set; } // Tiêu đề thông báo
        public string NoiDung { get; set; } // Nội dung thông báo
        public DateTime Ngay { get; set; } // Ngày thông báo
        public string NguoiGui { get; set; } // Người gửi thông báo
        public string NguoiNhan { get; set; } // Người nhận thông báo
        public bool DaDoc { get; set; } // Trạng thái đã đọc hay chưa

        public ThongBaoDTO(int maTB, string tieuDe, string noiDung, DateTime ngay, string nguoiGui, string nguoiNhan, bool daDoc)
        {
            MaTB = maTB;
            TieuDe = tieuDe;
            NoiDung = noiDung;
            Ngay = ngay;
            NguoiGui = nguoiGui;
            NguoiNhan = nguoiNhan;
            DaDoc = daDoc;
        }

        public ThongBaoDTO() { }

    }
}
