using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.DAL
{
    internal class DatabaseHelper
    {
        private SqlConnection sqlConn;
        private SqlDataAdapter da;
        private DataSet ds;


        private string strCnn = "Data Source=localhost;Initial Catalog=QuanLyTruongHoc;User ID=sa;Password=123";

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
        //Lấy thông báo
        public List<Notification> GetNotifications(int maNguoiNhan, int maVaiTroNhan)
        {
            var notifications = new List<Notification>();
            string query = @"
        SELECT MaTB, TieuDe, NoiDung, NgayGui
        FROM ThongBao
        WHERE MaNguoiNhan = @MaNguoiNhan OR MaVaiTroNhan = @MaVaiTroNhan
        ORDER BY NgayGui DESC";

            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                {
                    cmd.Parameters.AddWithValue("@MaNguoiNhan", maNguoiNhan);
                    cmd.Parameters.AddWithValue("@MaVaiTroNhan", maVaiTroNhan);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notifications.Add(new Notification
                            {
                                MaTB = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Content = reader.GetString(2),
                                Date = reader.GetDateTime(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông báo: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return notifications;
        }


    }
}
