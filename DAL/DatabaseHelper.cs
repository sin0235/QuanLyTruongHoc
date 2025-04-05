using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.DAL
{
    internal class DatabaseHelper
    {
        // Kết nối cơ sở dữ liệu ở đây nhen
        private string connectionString  = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public DatabaseHelper()
        {
            // Initialize the connection string or any other database-related setup here
        }


    }
}
