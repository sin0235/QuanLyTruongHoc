using QuanLyTruongHoc.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls.ucGiaoVien
{
    public partial class ucThoiKhoaBieu : UserControl
    {
        private readonly DatabaseHelper db;
        public ucThoiKhoaBieu()
        {
            InitializeComponent();
            db = new DatabaseHelper();

            // Set the DateTimePicker to the current date in Vietnam's timezone
            DateTime vietnamNow = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "SE Asia Standard Time");
            ngayChonDTP.Value = vietnamNow;
        }



        public void LoadLichDay(int maNguoiDung)
        {
            try
            {
                // SQL query to fetch the teaching schedule for the teacher
                string query = $@"
            SELECT 
                ThoiKhoaBieu.Thu,
                ThoiKhoaBieu.Tiet,
                MonHoc.TenMon,
                LopHoc.TenLop
            FROM ThoiKhoaBieu
            INNER JOIN GiaoVien ON ThoiKhoaBieu.MaGV = GiaoVien.MaGV
            INNER JOIN MonHoc ON ThoiKhoaBieu.MaMon = MonHoc.MaMon
            INNER JOIN LopHoc ON ThoiKhoaBieu.MaLop = LopHoc.MaLop
            WHERE GiaoVien.MaNguoiDung = {maNguoiDung}
            ORDER BY ThoiKhoaBieu.Thu, ThoiKhoaBieu.Tiet";


                DataTable dt = db.ExecuteQuery(query);

                // Clear existing rows in the DataGridView
                dgvThoiKhoaBieu.Rows.Clear();

                // Create a dictionary to store schedule data for each day
                var scheduleData = new Dictionary<int, List<string>>();
                for (int i = 2; i <= 8; i++) // Initialize for days 2 (Monday) to 8 (Sunday)
                {
                    scheduleData[i] = new List<string>();
                }

                // Populate the dictionary with schedule data
                foreach (DataRow row in dt.Rows)
                {
                    int thu = Convert.ToInt32(row["Thu"]); // Day of the week
                    string tiet = row["Tiet"].ToString(); // Time slot
                    string tenMon = row["TenMon"].ToString(); // Subject name
                    string tenLop = row["TenLop"].ToString(); // Class name

                    // Format the schedule entry
                    string scheduleEntry = $"Tiết: {tiet}\nMôn: {tenMon}\nLớp: {tenLop}";
                    scheduleData[thu].Add(scheduleEntry);
                }

                // Find the maximum number of rows needed
                int maxRows = scheduleData.Values.Max(list => list.Count);

                // Add rows to the DataGridView
                for (int i = 0; i < maxRows; i++)
                {
                    dgvThoiKhoaBieu.Rows.Add();
                }

                // Populate the DataGridView
                for (int thu = 2; thu <= 8; thu++) // Days 2 (Monday) to 8 (Sunday)
                {
                    int columnIndex = thu - 2; // Map "2 = Monday" to column index 0
                    for (int rowIndex = 0; rowIndex < scheduleData[thu].Count; rowIndex++)
                    {
                        dgvThoiKhoaBieu.Rows[rowIndex].Cells[columnIndex].Value = scheduleData[thu][rowIndex];
                    }
                }
                // Update the total number of periods for the week
                // Update the total number of periods for the week
                int totalPeriods = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string tiet = row["Tiet"].ToString(); // Example: "1-3"
                    if (tiet.Contains("-"))
                    {
                        // Extract start and end periods
                        int startPeriod = int.Parse(tiet.Split('-')[0]);
                        int endPeriod = int.Parse(tiet.Split('-')[1]);
                        totalPeriods += (endPeriod - startPeriod + 1); // Calculate the number of periods
                    }
                    else
                    {
                        // Single period (e.g., "1")
                        totalPeriods += 1;
                    }
                }
                thongKeSoTietTxt.Text = $"{totalPeriods} Tiết";


                // Highlight today's column header
                HighlightTodayColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading schedule: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighlightTodayColumn()
        {
            // Get today's day of the week in Vietnam's timezone
            DateTime vietnamNow = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "SE Asia Standard Time");
            int today = (int)vietnamNow.DayOfWeek; // Sunday = 0, Monday = 1, ..., Saturday = 6

            // Map Sunday (0) to 6, Monday (1) to 0, ..., Saturday (6) to 5
            int columnIndex = today == 0 ? 6 : today - 1;

            // Highlight only today's column header if it exists
            if (columnIndex >= 0 && columnIndex < dgvThoiKhoaBieu.Columns.Count)
            {
                dgvThoiKhoaBieu.Columns[columnIndex].HeaderCell.Style.BackColor = Color.YellowGreen; // Highlight color
                dgvThoiKhoaBieu.Columns[columnIndex].HeaderCell.Style.ForeColor = Color.White; // Highlight text color
            }

            // Force the DataGridView to refresh to apply the styles
            dgvThoiKhoaBieu.Refresh();
        }

    }
}


        