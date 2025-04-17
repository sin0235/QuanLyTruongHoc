using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyTruongHoc.DAL;

namespace QuanLyTruongHoc.DTO
{
    internal class GiaoVien
    {
        private readonly DatabaseHelper dbHelper;

        public GiaoVien()
        {
            dbHelper = new DatabaseHelper();
        }

        /// <summary>
        /// Fetches the timetable for a specific class.
        /// </summary>
        /// <param name="maLop">The class ID.</param>
        /// <returns>A DataTable containing the timetable.</returns>
        public DataTable GetTimetableByClass(int maLop)
        {
            string query = @"
                SELECT 
                    tkb.Thu,
                    tkb.Tiet,
                    mh.TenMon,
                    gv.HoTen AS GiaoVien
                FROM ThoiKhoaBieu tkb
                INNER JOIN MonHoc mh ON tkb.MaMon = mh.MaMon
                INNER JOIN GiaoVien gv ON tkb.MaGV = gv.MaGV
                WHERE tkb.MaLop = @MaLop
                ORDER BY tkb.Thu, tkb.Tiet";

            try
            {
                dbHelper.OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, dbHelper.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@MaLop", maLop);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            finally
            {
                dbHelper.CloseConnection();
            }
        }
    }
}
