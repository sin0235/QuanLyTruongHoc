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
    public partial class ucKiemTra : UserControl
    {
        // Constants for button states
        private readonly Color ACTIVE_BUTTON_COLOR = Color.FromArgb(0, 110, 220);
        private readonly Color HOMEWORK_BUTTON_COLOR = Color.FromArgb(63, 160, 77);
        private readonly Color COMING_SOON_BUTTON_COLOR = Color.FromArgb(255, 220, 100);
        private readonly Color DEFAULT_TEXT_COLOR = Color.White;
        private readonly Color DARK_TEXT_COLOR = Color.FromArgb(70, 70, 70);

        // Enum to track current view
        private enum ViewMode
        {
            Tests,
            Homework,
            ComingSoon
        }

        // Current view mode
        private ViewMode currentMode = ViewMode.Tests;

        // Sample data for testing
        private List<TestData> testList;
        private List<TestData> homeworkList;

        public ucKiemTra()
        {
            InitializeComponent();

            Load += UcKiemTra_Load;
            btnTests.Click += BtnTests_Click;
            btnHomework.Click += BtnHomework_Click;
            btnComingSoon.Click += BtnComingSoon_Click;
            cmbSchoolYear.SelectedIndexChanged += FilterChanged;
            cmbSemester.SelectedIndexChanged += FilterChanged;
            btnSearch.Click += BtnSearch_Click;
            txtSearch.KeyPress += TxtSearch_KeyPress;
            Label lblNoItems = new Label
            {
                Text = "Chức năng đang trong quá trình phát triển",
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.Gray,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };
            lblNoItems.Location = new Point(
                (pnlTestContainer.Width - lblNoItems.Width) / 2,
                (pnlTestContainer.Height - lblNoItems.Height) / 2
            );
            pnlTestContainer.Controls.Add(lblNoItems);
        }

        private void UcKiemTra_Load(object sender, EventArgs e)
        {

            // Select the default tab
            SetActiveView(ViewMode.Tests);
        }

      
        private void BtnTests_Click(object sender, EventArgs e)
        {
            SetActiveView(ViewMode.Tests);
        }

        private void BtnHomework_Click(object sender, EventArgs e)
        {
            SetActiveView(ViewMode.Homework);
        }

        private void BtnComingSoon_Click(object sender, EventArgs e)
        {
            SetActiveView(ViewMode.ComingSoon);
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            // Refresh the current view when filters change
            RefreshCurrentView();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            RefreshCurrentView();
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                RefreshCurrentView();
                e.Handled = true;
            }
        }

        private void SetActiveView(ViewMode mode)
        {
            currentMode = mode;

            // Reset all buttons to default state
            btnTests.FillColor = Color.LightGray;
            btnTests.ForeColor = Color.DimGray;

            btnHomework.FillColor = Color.LightGray;
            btnHomework.ForeColor = Color.DimGray;

            btnComingSoon.FillColor = Color.LightGray;
            btnComingSoon.ForeColor = Color.DimGray;

            // Set the active button
            switch (mode)
            {
                case ViewMode.Tests:
                    btnTests.FillColor = ACTIVE_BUTTON_COLOR;
                    btnTests.ForeColor = DEFAULT_TEXT_COLOR;
                    break;
                case ViewMode.Homework:
                    btnHomework.FillColor = HOMEWORK_BUTTON_COLOR;
                    btnHomework.ForeColor = DEFAULT_TEXT_COLOR;
                    break;
                case ViewMode.ComingSoon:
                    btnComingSoon.FillColor = COMING_SOON_BUTTON_COLOR;
                    btnComingSoon.ForeColor = DARK_TEXT_COLOR;
                    break;
            }

            // Refresh the view
            //RefreshCurrentView();
        }

        private void RefreshCurrentView()
        {
            // Clear existing items
            pnlTestContainer.Controls.Clear();

            // Get search term
            string searchTerm = txtSearch.Text.ToLower().Trim();

            // Filter and display items based on current view mode
            List<TestData> filteredItems = new List<TestData>();

            switch (currentMode)
            {
                //case ViewMode.Tests:
                //    filteredItems = testList.Where(t => !t.IsHomework).ToList();
                //    break;
                //case ViewMode.Homework:
                //    filteredItems = homeworkList.Where(t => t.IsHomework).ToList();
                //    break;
                //case ViewMode.ComingSoon:
                //    // Get items that are coming soon (start date within 7 days from now)
                //    DateTime sevenDaysFromNow = DateTime.Now.AddDays(7);
                //    filteredItems = testList.Where(t => t.StartTime > DateTime.Now && t.StartTime <= sevenDaysFromNow).ToList();
                //    filteredItems.AddRange(homeworkList.Where(t => t.StartTime > DateTime.Now && t.StartTime <= sevenDaysFromNow).ToList());
                //    break;
            }

            // Apply search filter if provided
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                filteredItems = filteredItems.Where(t =>
                    t.Subject.ToLower().Contains(searchTerm) ||
                    t.TestName.ToLower().Contains(searchTerm) ||
                    t.Notes.ToLower().Contains(searchTerm)).ToList();
            }

            // Sort items by start date
            filteredItems = filteredItems.OrderBy(t => t.StartTime).ToList();

            // Add items to panel
            foreach (var item in filteredItems)
            {
                ucTestItem testItem = new ucTestItem();
                testItem.Width = pnlTestContainer.Width / 3 - 20; // Adjust based on panel width
                testItem.Height = 320;
                testItem.Margin = new Padding(10);

                testItem.LoadTestData(
                    item.TestId,
                    item.Subject,
                    item.TestName,
                    item.Duration,
                    item.StartTime,
                    item.EndTime,
                    item.AttemptsAllowed,
                    item.AttemptsUsed,
                    item.Notes,
                    item.IsHomework);

                testItem.TestStarted += TestItem_TestStarted;
                pnlTestContainer.Controls.Add(testItem);
            }

            // Show message if no items
            if (filteredItems.Count == 0)
            {
                Label lblNoItems = new Label
                {
                    Text = "Không tìm thấy dữ liệu phù hợp",
                    Font = new Font("Segoe UI", 14),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                lblNoItems.Location = new Point(
                    (pnlTestContainer.Width - lblNoItems.Width) / 2,
                    (pnlTestContainer.Height - lblNoItems.Height) / 2
                );
                pnlTestContainer.Controls.Add(lblNoItems);
            }
        }

        private void TestItem_TestStarted(object sender, EventArgs e)
        {
            ucTestItem item = sender as ucTestItem;
            if (item != null)
            {
                // Update the item in the data source
                var test = testList.FirstOrDefault(t => t.TestId == item.TestId);
                if (test != null)
                {
                    test.AttemptsUsed++;
                }

                var homework = homeworkList.FirstOrDefault(t => t.TestId == item.TestId);
                if (homework != null)
                {
                    homework.AttemptsUsed++;
                }
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {

        }
    }

    public class TestData
    {
        public int TestId { get; set; }
        public string Subject { get; set; }
        public string TestName { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AttemptsAllowed { get; set; }
        public int AttemptsUsed { get; set; }
        public string Notes { get; set; }
        public bool IsHomework { get; set; }

        public TestData(int id, string subject, string testName, int duration,
            DateTime startTime, DateTime endTime, int attemptsAllowed,
            int attemptsUsed, string notes, bool isHomework)
        {
            TestId = id;
            Subject = subject;
            TestName = testName;
            Duration = duration;
            StartTime = startTime;
            EndTime = endTime;
            AttemptsAllowed = attemptsAllowed;
            AttemptsUsed = attemptsUsed;
            Notes = notes;
            IsHomework = isHomework;
        }
    }
}
