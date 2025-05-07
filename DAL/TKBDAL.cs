using QuanLyTruongHoc.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DAL
{
    public class TKBDAL
    {
        private DatabaseHelper dbHelper;

        public TKBDAL()
        {
            dbHelper = new DatabaseHelper();
        }

        /// <summary>
        /// Lấy danh sách các năm học
        /// </summary>
        public List<string> GetSchoolYears()
        {
            List<string> years = new List<string>();
            try
            {
                // Query is fine as is - it selects distinct school years
                string query = @"SELECT DISTINCT NamHoc FROM LopHoc ORDER BY NamHoc";
                DataTable dt = dbHelper.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    years.Add(row["NamHoc"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách năm học: {ex.Message}");
            }
            return years;
        }

        /// <summary>
        /// Lấy thông tin lớp học của học sinh
        /// </summary>
        public DataRow GetClassInfo(int maHS)
        {
            try
            {
                // Unchanged - this query already matches database structure well
                string query = @"
                        SELECT L.MaLop, L.TenLop, L.NamHoc 
                        FROM HocSinh HS
                        JOIN LopHoc L ON HS.MaLop = L.MaLop
                        WHERE HS.MaHS = @MaHS";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaHS", maHS }
                    };

                DataTable dt = dbHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông tin lớp học: {ex.Message}");
            }
            return null;
        }

        /// <summary>
        /// Tạo danh sách các tuần trong học kỳ
        /// </summary>
        public List<TuanHocDTO> GetWeeks(string namHoc, int hocKy)
        {
            List<TuanHocDTO> weeks = new List<TuanHocDTO>();

            try
            {
                // Parsing school year format like "2024–2025"
                string[] years = namHoc.Split('–');
                if (years.Length != 2)
                {
                    return weeks; // Return empty list if format is invalid
                }

                int startYear = int.Parse(years[0].Trim());
                int endYear = int.Parse(years[1].Trim());
                DateTime startDate;
                int numberOfWeeks;

                if (hocKy == 1)
                {
                    // First semester: September to December of start year
                    startDate = new DateTime(startYear, 9, 1);
                    numberOfWeeks = 18;
                }
                else // hocKy == 2
                {
                    // Second semester: January to May of end year
                    startDate = new DateTime(endYear, 1, 10);
                    numberOfWeeks = 19;
                }

                // Adjust to start on Monday
                while (startDate.DayOfWeek != DayOfWeek.Monday)
                {
                    startDate = startDate.AddDays(1);
                }

                // Generate weeks
                for (int i = 0; i < numberOfWeeks; i++)
                {
                    DateTime weekStart = startDate.AddDays(i * 7);
                    DateTime weekEnd = weekStart.AddDays(6); // Sunday
                    weeks.Add(new TuanHocDTO(i + 1, weekStart, weekEnd));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tính toán các tuần học: {ex.Message}");
            }

            return weeks;
        }

        /// <summary>
        /// Lấy thời khóa biểu của một lớp trong một khoảng thời gian
        /// </summary>
        public List<TKBDTO> GetTimetable(int maLop, DateTime startDate, DateTime endDate)
        {
            List<TKBDTO> result = new List<TKBDTO>();

            try
            {
                // Improved query that matches the exact table structure
                string query = @"
                        SELECT 
                            tkb.MaTKB, 
                            tkb.MaLop, 
                            tkb.MaMon, 
                            tkb.MaGV, 
                            tkb.Ngay, 
                            tkb.Thu, 
                            tkb.Tiet,
                            mh.TenMon, 
                            gv.HoTen AS TenGiaoVien, 
                            lh.TenLop
                        FROM 
                            ThoiKhoaBieu tkb
                        INNER JOIN 
                            MonHoc mh ON tkb.MaMon = mh.MaMon
                        INNER JOIN 
                            GiaoVien gv ON tkb.MaGV = gv.MaGV
                        INNER JOIN 
                            LopHoc lh ON tkb.MaLop = lh.MaLop
                        WHERE 
                            tkb.MaLop = @MaLop 
                            AND tkb.Ngay >= @StartDate 
                            AND tkb.Ngay <= @EndDate
                        ORDER BY 
                            tkb.Thu, 
                            -- More robust parsing of the period format (e.g., '1-3' or '5')
                            CASE 
                                WHEN CHARINDEX('-', tkb.Tiet) > 0 
                                THEN CONVERT(INT, LEFT(tkb.Tiet, CHARINDEX('-', tkb.Tiet) - 1)) 
                                ELSE CONVERT(INT, tkb.Tiet) 
                            END";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaLop", maLop },
                    { "@StartDate", startDate.Date },  // Use Date to ignore time component
                    { "@EndDate", endDate.Date }
                };

                DataTable dt = dbHelper.ExecuteQuery(query, parameters);

                foreach (DataRow row in dt.Rows)
                {
                    TKBDTO tkb = new TKBDTO
                    {
                        MaTKB = Convert.ToInt32(row["MaTKB"]),
                        MaLop = Convert.ToInt32(row["MaLop"]),
                        MaMon = Convert.ToInt32(row["MaMon"]),
                        MaGV = Convert.ToInt32(row["MaGV"]),
                        Ngay = Convert.ToDateTime(row["Ngay"]),
                        Thu = Convert.ToInt32(row["Thu"]),
                        Tiet = row["Tiet"].ToString(),
                        TenMon = row["TenMon"].ToString(),
                        TenGiaoVien = row["TenGiaoVien"].ToString(),
                        TenLop = row["TenLop"].ToString()
                    };
                    result.Add(tkb);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thời khóa biểu: {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Xác định tuần hiện tại trong học kỳ
        /// </summary>
        public int GetCurrentWeekIndex(List<TuanHocDTO> weeks)
        {
            if (weeks == null || weeks.Count == 0)
                return 0;

            DateTime today = DateTime.Now.Date; // Use only the date part for comparison

            for (int i = 0; i < weeks.Count; i++)
            {
                if (today >= weeks[i].NgayBatDau.Date && today <= weeks[i].NgayKetThuc.Date)
                {
                    return i;
                }
            }

            // If current date is before the first week, return the first week
            if (today < weeks[0].NgayBatDau.Date)
                return 0;

            // If current date is after the last week, return the last week
            if (today > weeks[weeks.Count - 1].NgayKetThuc.Date)
                return weeks.Count - 1;
            return 0;
        }

    }
}
