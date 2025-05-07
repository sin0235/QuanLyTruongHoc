using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DAL
{
    /// <summary>
    /// Lớp xử lý thao tác dữ liệu học sinh với cơ sở dữ liệu
    /// </summary>
    public class HocSinhDAL
    {
        private DatabaseHelper db;

        public HocSinhDAL()
        {
            db = new DatabaseHelper();
        }

        /// <summary>
        /// Lấy thông tin học sinh theo mã học sinh
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <returns>Đối tượng StudentInfo chứa thông tin học sinh</returns>
        public ThongTinHSDTO GetStudentById(int maHS)
        {
            //try
            //{

                string query = @"
                SELECT 
                    HS.MaHS AS StudentId,
                    HS.HoTen AS FullName,
                    HS.NgaySinh AS DateOfBirth,
                    HS.GioiTinh AS Gender,
                    L.MaLop AS ClassName,
                    HS.DiaChi AS Address,
                    HS.SDTPhuHuynh AS Phone
                FROM 
                    HocSinh HS
                LEFT JOIN 
                    LopHoc L ON HS.MaLop = L.MaLop
                LEFT JOIN
                    NguoiDung ND ON HS.MaNguoiDung = ND.MaNguoiDung
                WHERE 
                    HS.MaHS = @MaHS";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                Console.WriteLine($"Số hàng trả về: {dt.Rows.Count}");

                if (dt.Rows.Count > 0)
                {
                    ThongTinHSDTO student = new ThongTinHSDTO();
                    DataRow row = dt.Rows[0];

                    // Map các trường dữ liệu
                    student.StudentId = row["StudentId"].ToString();
                    student.FullName = GetValueOrDefault(row, "FullName", "-----");
                    student.Gender = GetValueOrDefault(row, "Gender", "-----");
                    student.ClassName = GetValueOrDefault(row, "ClassName", "-----");
                    student.Address = GetValueOrDefault(row, "Address", "-----");
                    student.Phone = GetValueOrDefault(row, "Phone", "-----");

                    // Các trường không có trong DB
                    student.IdentityCode = "-----";
                    student.PlaceOfBirth = "-----";
                    student.Ethnicity = "-----";
                    student.Religion = "-----";
                    student.Country = "-----";
                    student.Province = "-----";
                    student.District = "-----";
                    student.Ward = "-----";
                    student.PermanentAddress = "-----";
                    student.Mobile = "-----";
                    student.FatherName = "-----";
                    student.FatherPhone = "-----";
                    student.MotherName = "-----";
                    student.MotherPhone = "-----";

                    // Xử lý ngày sinh
                    if (row["DateOfBirth"] != DBNull.Value)
                    {
                        student.DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                    }
                    else
                    {
                        student.DateOfBirth = DateTime.Now;
                    }

                    Console.WriteLine($"Đã lấy thông tin học sinh: {student.FullName}");
                    return student;
                }
                else
                {
                    Console.WriteLine($"Không tìm thấy học sinh với mã: {maHS}");
                }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Lỗi trong GetStudentById: {ex.Message}");
            //    Console.WriteLine($"StackTrace: {ex.StackTrace}");
            //}

            return null;
        }

        ///// <summary>
        ///// Lấy thông tin phụ huynh nếu có trong cơ sở dữ liệu
        ///// </summary>
        //private void GetParentInfo(int maHS, ThongTinHSDTO student)
        //{
        //    try
        //    {
        //        // Kiểm tra xem có bảng phụ huynh không
        //        string checkTableQuery = @"
        //                        IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PhuHuynh')
        //                        SELECT 1 AS TableExists
        //                        ELSE
        //                        SELECT 0 AS TableExists";

        //        DataTable checkTable = db.ExecuteQuery(checkTableQuery);
        //        bool tableExists = checkTable != null && checkTable.Rows.Count > 0 &&
        //                          Convert.ToBoolean(checkTable.Rows[0]["TableExists"]);

        //        if (tableExists)
        //        {
        //            string query = @"
        //                            SELECT 
        //                                HoTenCha, SoDienThoaiCha, HoTenMe, SoDienThoaiMe
        //                            FROM 
        //                                PhuHuynh
        //                            WHERE 
        //                                MaHS = @MaHS";

        //            Dictionary<string, object> parameters = new Dictionary<string, object>
        //                            {
        //                                { "@MaHS", maHS }
        //                            };

        //            DataTable dt = db.ExecuteQuery(query, parameters);
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                DataRow row = dt.Rows[0];
        //                student.FatherName = GetValueOrDefault(row, "HoTenCha", "-----");
        //                student.FatherPhone = GetValueOrDefault(row, "SoDienThoaiCha", "-----");
        //                student.MotherName = GetValueOrDefault(row, "HoTenMe", "-----");
        //                student.MotherPhone = GetValueOrDefault(row, "SoDienThoaiMe", "-----");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Lỗi khi lấy thông tin phụ huynh: {ex.Message}");
        //    }
        //}

        /// <summary>
        /// Cập nhật thông tin cơ bản của học sinh
        /// </summary>
        /// <param name="student">Thông tin học sinh</param>
        /// <returns>True nếu cập nhật thành công, ngược lại là False</returns>
        public bool UpdateStudentBasicInfo(ThongTinHSDTO student)
        {
            try
            {
                // Cập nhật thông tin trong bảng HocSinh
                string query = @"
                                UPDATE HocSinh SET
                                    DiaChi = @Address,
                                    SDTPhuHuynh = @Phone
                                WHERE MaHS = @StudentId";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                                {
                                    { "@Address", string.IsNullOrEmpty(student.Address) || student.Address == "-----" ? DBNull.Value : (object)student.Address },
                                    { "@Phone", string.IsNullOrEmpty(student.Phone) || student.Phone == "-----" ? DBNull.Value : (object)student.Phone },
                                    { "@StudentId", student.StudentId }
                                };

                bool result = db.ExecuteNonQuery(query, parameters);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật thông tin học sinh: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lưu ảnh đại diện của học sinh
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <param name="avatar">Ảnh đại diện</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public bool SaveStudentAvatar(int maHS, Image avatar)
        {
            try
            {
                if (avatar == null)
                    return false;

                // Chuyển đổi ảnh thành byte[]
                byte[] imageData;
                using (MemoryStream ms = new MemoryStream())
                {
                    avatar.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                }

                // Tạo bảng HinhAnhHocSinh nếu chưa tồn tại
                string createTableQuery = @"
                                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'HinhAnhHocSinh')
                                BEGIN
                                    CREATE TABLE HinhAnhHocSinh (
                                        MaHS INT PRIMARY KEY,
                                        HinhAnh VARBINARY(MAX),
                                        NgayCapNhat DATETIME DEFAULT GETDATE(),
                                        FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS)
                                    )
                                END";

                db.ExecuteNonQuery(createTableQuery);

                // Kiểm tra xem đã có avatar trong CSDL chưa
                string checkQuery = "SELECT COUNT(*) FROM HinhAnhHocSinh WHERE MaHS = @MaHS";
                Dictionary<string, object> checkParams = new Dictionary<string, object>
                                {
                                    { "@MaHS", maHS }
                                };

                int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));

                string query;
                if (count > 0)
                {
                    // Cập nhật avatar hiện có
                    query = "UPDATE HinhAnhHocSinh SET HinhAnh = @HinhAnh, NgayCapNhat = GETDATE() WHERE MaHS = @MaHS";
                }
                else
                {
                    // Thêm avatar mới
                    query = "INSERT INTO HinhAnhHocSinh (MaHS, HinhAnh, NgayCapNhat) VALUES (@MaHS, @HinhAnh, GETDATE())";
                }

                Dictionary<string, object> parameters = new Dictionary<string, object>
                                {
                                    { "@MaHS", maHS },
                                    { "@HinhAnh", imageData }
                                };

                return db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu ảnh đại diện: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách tất cả học sinh
        /// </summary>
        /// <returns>Danh sách các đối tượng StudentInfo</returns>
        public List<ThongTinHSDTO> GetAllStudents()
        {
            List<ThongTinHSDTO> students = new List<ThongTinHSDTO>();

            try
            {
                string query = @"
                                SELECT 
                                    HS.MaHS AS StudentId,
                                    HS.HoTen AS FullName,
                                    HS.NgaySinh AS DateOfBirth,
                                    HS.GioiTinh AS Gender,
                                    L.TenLop AS ClassName,
                                    HS.DiaChi AS Address,
                                    HS.SDTPhuHuynh AS Phone
                                FROM 
                                    HocSinh HS
                                LEFT JOIN 
                                    LopHoc L ON HS.MaLop = L.MaLop
                                ORDER BY 
                                    L.TenLop, HS.HoTen";

                DataTable dt = db.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        // Tạo đối tượng StudentInfo với thông tin cơ bản
                        ThongTinHSDTO student = new ThongTinHSDTO
                        {
                            StudentId = GetValueOrDefault(row, "StudentId", ""),
                            FullName = GetValueOrDefault(row, "FullName", ""),
                            Gender = GetValueOrDefault(row, "Gender", ""),
                            ClassName = GetValueOrDefault(row, "ClassName", ""),
                            Address = GetValueOrDefault(row, "Address", ""),
                            Phone = GetValueOrDefault(row, "Phone", ""),
                            DateOfBirth = row["DateOfBirth"] != DBNull.Value ?
                                Convert.ToDateTime(row["DateOfBirth"]) : DateTime.Now
                        };

                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách học sinh: {ex.Message}");
            }

            return students;
        }

        /// <summary>
        /// Lấy danh sách học sinh theo lớp
        /// </summary>
        /// <param name="maLop">Mã lớp học</param>
        /// <returns>Danh sách các đối tượng StudentInfo</returns>
        public List<ThongTinHSDTO> GetStudentsByClass(int maLop)
        {
            List<ThongTinHSDTO> students = new List<ThongTinHSDTO>();

            try
            {
                string query = @"
                                SELECT 
                                    HS.MaHS AS StudentId,
                                    HS.HoTen AS FullName,
                                    HS.NgaySinh AS DateOfBirth,
                                    HS.GioiTinh AS Gender,
                                    L.TenLop AS ClassName,
                                    HS.DiaChi AS Address,
                                    HS.SDTPhuHuynh AS Phone
                                FROM 
                                    HocSinh HS
                                LEFT JOIN 
                                    LopHoc L ON HS.MaLop = L.MaLop
                                WHERE 
                                    HS.MaLop = @MaLop
                                ORDER BY 
                                    HS.HoTen";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                                {
                                    { "@MaLop", maLop }
                                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        // Tạo đối tượng StudentInfo với thông tin cơ bản
                        ThongTinHSDTO student = new ThongTinHSDTO
                        {
                            StudentId = GetValueOrDefault(row, "StudentId", ""),
                            FullName = GetValueOrDefault(row, "FullName", ""),
                            Gender = GetValueOrDefault(row, "Gender", ""),
                            ClassName = GetValueOrDefault(row, "ClassName", ""),
                            Address = GetValueOrDefault(row, "Address", ""),
                            Phone = GetValueOrDefault(row, "Phone", ""),
                            DateOfBirth = row["DateOfBirth"] != DBNull.Value ?
                                Convert.ToDateTime(row["DateOfBirth"]) : DateTime.Now
                        };

                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách học sinh theo lớp: {ex.Message}");
            }

            return students;
        }

        /// <summary>
        /// Tìm kiếm học sinh theo từ khóa (tên hoặc mã)
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        /// <returns>Danh sách học sinh thỏa điều kiện tìm kiếm</returns>
        public List<ThongTinHSDTO> SearchStudents(string keyword)
        {
            List<ThongTinHSDTO> students = new List<ThongTinHSDTO>();

            try
            {
                string query = @"
                                SELECT 
                                    HS.MaHS AS StudentId,
                                    HS.HoTen AS FullName,
                                    HS.NgaySinh AS DateOfBirth,
                                    HS.GioiTinh AS Gender,
                                    L.TenLop AS ClassName,
                                    HS.DiaChi AS Address,
                                    HS.SDTPhuHuynh AS Phone
                                FROM 
                                    HocSinh HS
                                LEFT JOIN 
                                    LopHoc L ON HS.MaLop = L.MaLop
                                WHERE 
                                    HS.HoTen LIKE @Keyword 
                                    OR CAST(HS.MaHS AS VARCHAR) LIKE @Keyword
                                    OR L.TenLop LIKE @Keyword
                                ORDER BY 
                                    L.TenLop, HS.HoTen";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                                {
                                    { "@Keyword", $"%{keyword}%" }
                                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        // Tạo đối tượng StudentInfo với thông tin cơ bản
                        ThongTinHSDTO student = new ThongTinHSDTO
                        {
                            StudentId = GetValueOrDefault(row, "StudentId", ""),
                            FullName = GetValueOrDefault(row, "FullName", ""),
                            Gender = GetValueOrDefault(row, "Gender", ""),
                            ClassName = GetValueOrDefault(row, "ClassName", ""),
                            Address = GetValueOrDefault(row, "Address", ""),
                            Phone = GetValueOrDefault(row, "Phone", ""),
                            DateOfBirth = row["DateOfBirth"] != DBNull.Value ?
                                Convert.ToDateTime(row["DateOfBirth"]) : DateTime.Now
                        };

                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm học sinh: {ex.Message}");
            }

            return students;
        }

        /// <summary>
        /// Lấy giá trị từ DataRow, trả về giá trị mặc định nếu không có hoặc là DBNull
        /// </summary>
        private string GetValueOrDefault(DataRow row, string columnName, string defaultValue)
        {
            if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                return row[columnName].ToString();
            return defaultValue;
        }
    }
}
