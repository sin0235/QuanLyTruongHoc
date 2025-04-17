using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.DAL
{
    internal class DatabaseHelper
    {
        private SqlConnection sqlConn;
        private SqlDataAdapter da;
        private DataSet ds;


        private string strCnn = "Data Source=JOHNNYBUIII;Database=QuanLyTruongHoc;user id = sa; password=1;MultipleActiveResultSets=True";

        public SqlConnection GetConnection()
        {
            return sqlConn;
        }

        public DatabaseHelper()
        {
            sqlConn = new SqlConnection(strCnn);
        }
        public void OpenConnection()
        {
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();
        }
        public void CloseConnection()
        {
            if (sqlConn.State == ConnectionState.Open)
                sqlConn.Close();
        }
        public DataTable ExecuteQuery(string sqlStr)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                da = new SqlDataAdapter(sqlStr, sqlConn);
                ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
        public bool ExecuteNonQuery(string sqlStr)
        {
            bool result = false;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sqlStr, sqlConn))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    result = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lệnh: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
    }
}
