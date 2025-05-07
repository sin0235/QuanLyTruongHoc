using System;

namespace QuanLyTruongHoc.DTO
{
    public class DiemSoDTO
    {
        // Basic properties mapping to database fields
        public int MaDiem { get; set; }
        public int MaHS { get; set; }
        public int MaMon { get; set; }
        public int MaGV { get; set; }
        public int HocKy { get; set; }
        public string LoaiDiem { get; set; }
        public float Diem { get; set; }

        // Additional properties for display
        public string TenMon { get; set; }
        public string TenGV { get; set; }

        public DiemSoDTO()
        {
            // Default constructor
        }

        public DiemSoDTO(int maDiem, int maHS, int maMon, int maGV, int hocKy, string loaiDiem, float diem)
        {
            MaDiem = maDiem;
            MaHS = maHS;
            MaMon = maMon;
            MaGV = maGV;
            HocKy = hocKy;
            LoaiDiem = loaiDiem;
            Diem = diem;
        }
    }

    // Class to aggregate scores for a subject
    public class MonHocScoreDTO
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public float DiemMieng { get; set; }
        public float Diem15Phut { get; set; }
        public float DiemCuoiKy { get; set; }
        public float DiemTrungBinh { get; set; }
        public string NhanXet { get; set; }

        public MonHocScoreDTO()
        {
            DiemMieng = 0;
            Diem15Phut = 0;
            DiemCuoiKy = 0;
            DiemTrungBinh = 0;
            NhanXet = "";
        }

        // Calculate average score with custom weights
        public void CalculateAverage()
        {
            // Weight: 20% DiemMieng, 30% Diem15Phut, 50% DiemCuoiKy
            DiemTrungBinh = (DiemMieng * 0.2f) + (Diem15Phut * 0.3f) + (DiemCuoiKy * 0.5f);
            DiemTrungBinh = (float)Math.Round(DiemTrungBinh, 1);
        }
    }

    // Class to store semester summary information
    public class HocKySummaryDTO
    {
        public int MaHS { get; set; }
        public int HocKy { get; set; }
        public string NamHoc { get; set; }
        public float DiemTrungBinh { get; set; }
        public string XepLoai { get; set; }
        public string HanhKiem { get; set; }
        public int XepHang { get; set; }
        public int SoBuoiNghi { get; set; }
        public string NhanXet { get; set; }

        public HocKySummaryDTO()
        {
            HocKy = 1;
            NamHoc = "2024-2025";
            DiemTrungBinh = 0;
            XepLoai = "Chưa xếp loại";
            HanhKiem = "Tốt";
            XepHang = 0;
            SoBuoiNghi = 0;
            NhanXet = "";
        }

        // Calculate performance tier based on GPA
        public void CalculateXepLoai()
        {
            if (DiemTrungBinh >= 8.0)
                XepLoai = "Giỏi";
            else if (DiemTrungBinh >= 7.0)
                XepLoai = "Khá";
            else if (DiemTrungBinh >= 5.0)
                XepLoai = "Trung bình";
            else
                XepLoai = "Yếu";
        }
    }
}
