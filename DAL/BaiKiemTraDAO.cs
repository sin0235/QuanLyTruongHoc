using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.DAL
{
    public class BaiKiemTraDAO
    {
        private DatabaseHelper db;
        
        public BaiKiemTraDAO()
        {
            db = new DatabaseHelper();
        }
        
        /// <summary>
        /// Create a new test/quiz in the database
        /// </summary>
        /// <param name="baiKiemTra">The test/quiz data to save</param>
        /// <returns>ID of the created test or -1 if failed</returns>
        public int CreateBaiKiemTra(BaiKiemTraDTO baiKiemTra)
        {
            try
            {
                // Standardize the status to Vietnamese
                string standardizedStatus = baiKiemTra.TrangThai;
                if (baiKiemTra.TrangThai == "Published")
                    standardizedStatus = "Đã công bố";
                else if (baiKiemTra.TrangThai == "Draft")
                    standardizedStatus = "Chưa công bố";

                // 1. Tạo bài kiểm tra với các thuộc tính mới
                string insertTestQuery = @"
                INSERT INTO BaiKiemTra (
                    MaGV, TenBaiKT, MoTa, ThoiGianLamBai, 
                    MaMon, TrangThai, NgayTao, HocKy, NamHoc,
                    ThoiGianBatDau, ThoiGianKetThuc, DiemDatYeuCau, 
                    SoLanLamToiDa, LoaiBaiKiemTra, HienThiKetQuaNgay, 
                    XaoTronCauHoi, GhiChuChamDiem, CoMatKhau, MatKhau
                )
                VALUES (
                    @MaGV, @TenBaiKT, @MoTa, @ThoiGianLamBai, 
                    @MaMH, @TrangThai, GETDATE(), @HocKy, @NamHoc,
                    @ThoiGianBatDau, @ThoiGianKetThuc, @DiemDatYeuCau, 
                    @SoLanLamToiDa, @LoaiBaiKiemTra, @HienThiKetQuaNgay, 
                    @XaoTronCauHoi, @GhiChuChamDiem, @CoMatKhau, @MatKhau
                );
                SELECT SCOPE_IDENTITY();";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaGV", baiKiemTra.MaGV },
                    { "@TenBaiKT", baiKiemTra.TenBaiKT },
                    { "@MoTa", string.IsNullOrEmpty(baiKiemTra.MoTa) ? DBNull.Value : (object)baiKiemTra.MoTa },
                    { "@ThoiGianLamBai", baiKiemTra.ThoiGianLamBai },
                    { "@MaMH", baiKiemTra.MaMH },
                    { "@TrangThai", standardizedStatus },
                    { "@HocKy", baiKiemTra.HocKy },
                    { "@NamHoc", baiKiemTra.NamHoc },
                    { "@ThoiGianBatDau", baiKiemTra.ThoiGianBatDau },
                    { "@ThoiGianKetThuc", baiKiemTra.ThoiGianKetThuc },
                    { "@DiemDatYeuCau", baiKiemTra.DiemDatYeuCau },
                    { "@SoLanLamToiDa", baiKiemTra.SoLanLamToiDa },
                    { "@LoaiBaiKiemTra", string.IsNullOrEmpty(baiKiemTra.LoaiBaiKT) ? DBNull.Value : (object)baiKiemTra.LoaiBaiKT },
                    { "@HienThiKetQuaNgay", baiKiemTra.HienThiKetQuaNgay },
                    { "@XaoTronCauHoi", baiKiemTra.XaoTronCauHoi },
                    { "@GhiChuChamDiem", string.IsNullOrEmpty(baiKiemTra.GhiChuChamDiem) ? DBNull.Value : (object)baiKiemTra.GhiChuChamDiem },
                    { "@CoMatKhau", baiKiemTra.CoMatKhau },
                    { "@MatKhau", string.IsNullOrEmpty(baiKiemTra.MatKhau) ? DBNull.Value : (object)baiKiemTra.MatKhau }
                };

                int maBaiKT = db.ExecuteInsertAndGetId(insertTestQuery, parameters);

                // 2. Liên kết bài kiểm tra với lớp học
                if (maBaiKT > 0)
                {
                    DateTime ngayKiemTra = baiKiemTra.ThoiGianBatDau != DateTime.MinValue ?
                        baiKiemTra.ThoiGianBatDau : DateTime.Now;

                    string insertClassTestQuery = @"
                    INSERT INTO BaiKiemTra_LopHoc (
                        MaBaiKT, MaLop, NgayKiemTra, TrangThai
                    )
                    VALUES (
                        @MaBaiKT, @MaLop, @NgayKiemTra, @TrangThaiLop
                    )";

                    Dictionary<string, object> classParams = new Dictionary<string, object>
                    {
                        { "@MaBaiKT", maBaiKT },
                        { "@MaLop", baiKiemTra.MaLop },
                        { "@NgayKiemTra", ngayKiemTra },
                        { "@TrangThaiLop", "Đã công bố" }
                    };

                    bool success = db.ExecuteNonQuery(insertClassTestQuery, classParams);

                    if (!success)
                    {
                        // Xóa bài kiểm tra nếu không thể liên kết với lớp học
                        string deleteQuery = $"DELETE FROM BaiKiemTra WHERE MaBaiKT = {maBaiKT}";
                        db.ExecuteNonQuery(deleteQuery);
                        return -1;
                    }

                    // Thêm các câu hỏi
                    if (baiKiemTra.DanhSachCauHoi.Count > 0)
                    {
                        int thuTu = 1;
                        foreach (var cauHoi in baiKiemTra.DanhSachCauHoi)
                        {
                            cauHoi.MaBaiKT = maBaiKT;
                            cauHoi.ThuTu = thuTu++;

                            if (cauHoi is CauHoiTracNghiemDTO)
                            {
                                AddMultipleChoiceQuestion(cauHoi as CauHoiTracNghiemDTO);
                            }
                            else if (cauHoi is CauHoiTuLuanDTO)
                            {
                                AddEssayQuestion(cauHoi as CauHoiTuLuanDTO);
                            }
                        }
                    }
                }

                return maBaiKT;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating test: {ex.Message}");
                return -1;
            }
        }
        
        /// <summary>
        /// Add a multiple-choice question to the database
        /// </summary>
        /// <param name="question">The multiple-choice question data</param>
        /// <returns>ID of the created question or -1 if failed</returns>
        public int AddMultipleChoiceQuestion(CauHoiTracNghiemDTO question)
        {
            try
            {
                // Chuẩn bị dữ liệu hình ảnh nếu cần
                byte[] imageData = null;
                if (question.CoHinhAnh && !string.IsNullOrWhiteSpace(question.DuongDanHinhAnh))
                {
                    // Đọc dữ liệu nhị phân từ đường dẫn hình ảnh
                    imageData = File.ReadAllBytes(question.DuongDanHinhAnh);
                    question.HinhAnh = imageData;
                }

                // Truy vấn thêm câu hỏi
                string insertQuestionQuery = @"
                    INSERT INTO CauHoi (
                        MaBaiKT, LoaiCauHoi, NoiDung, DiemSo, CoHinhAnh, HinhAnh, ThuTu
                    )
                    VALUES (
                        @MaBaiKT, @LoaiCauHoi, @NoiDung, @DiemSo, @CoHinhAnh, @HinhAnh, @ThuTu
                    );
                    SELECT SCOPE_IDENTITY();";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", question.MaBaiKT },
                    { "@LoaiCauHoi", question.LoaiCauHoi },
                    { "@NoiDung", question.NoiDung },
                    { "@DiemSo", question.DiemSo },
                    { "@CoHinhAnh", question.CoHinhAnh ? 1 : 0 },
                    { "@HinhAnh", question.CoHinhAnh ? (object)imageData : DBNull.Value },
                    { "@ThuTu", question.ThuTu }
                };

                int maCauHoi = db.ExecuteInsertAndGetId(insertQuestionQuery, parameters);

                if (maCauHoi <= 0)
                {
                    return -1; // Thêm câu hỏi thất bại
                }

                question.MaCauHoi = maCauHoi;

                // Thêm các lựa chọn
                if (question.DanhSachLuaChon.Count > 0)
                {
                    foreach (var luaChon in question.DanhSachLuaChon)
                    {
                        luaChon.MaCauHoi = maCauHoi;
                        luaChon.LaDapAnDung = (luaChon.NhanDang == question.DapAnDung);

                        AddMultipleChoiceOption(luaChon);
                    }
                }

                return maCauHoi;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding multiple-choice question: {ex.Message}");
                return -1;
            }
        }
        
        /// <summary>
        /// Add an essay question to the database
        /// </summary>
        /// <param name="question">The essay question data</param>
        /// <returns>ID of the created question or -1 if failed</returns>
        public int AddEssayQuestion(CauHoiTuLuanDTO question)
        {
            try
            {
                // Prepare image data if needed
                byte[] imageData = null;
                if (question.CoHinhAnh && !string.IsNullOrWhiteSpace(question.DuongDanHinhAnh))
                {
                    imageData = File.ReadAllBytes(question.DuongDanHinhAnh);
                    question.HinhAnh = imageData;
                }
                
                // Insert the question
                string insertQuestionQuery = @"
                    INSERT INTO CauHoi (
                        MaBaiKT, LoaiCauHoi, NoiDung, DiemSo, CoHinhAnh, HinhAnh, ThuTu
                    )
                    VALUES (
                        @MaBaiKT, @LoaiCauHoi, @NoiDung, @DiemSo, @CoHinhAnh, @HinhAnh, @ThuTu
                    );
                    SELECT SCOPE_IDENTITY();";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", question.MaBaiKT },
                    { "@LoaiCauHoi", question.LoaiCauHoi },
                    { "@NoiDung", question.NoiDung },
                    { "@DiemSo", question.DiemSo },
                    { "@CoHinhAnh", question.CoHinhAnh ? 1 : 0 },
                    { "@HinhAnh", question.CoHinhAnh ? (object)imageData : DBNull.Value },
                    { "@ThuTu", question.ThuTu }
                };
                
                int maCauHoi = db.ExecuteInsertAndGetId(insertQuestionQuery, parameters);
                
                if (maCauHoi <= 0)
                {
                    return -1; // Failed to insert question
                }
                
                question.MaCauHoi = maCauHoi;
                
                // Add essay-specific information
                string insertEssayQuery = @"
                    INSERT INTO CauHoiTuLuan (
                        MaCauHoi, HuongDanTraLoi, CoGioiHanTu, GioiHanTu
                    )
                    VALUES (
                        @MaCauHoi, @HuongDanTraLoi, @CoGioiHanTu, @GioiHanTu
                    );";
                
                Dictionary<string, object> essayParameters = new Dictionary<string, object>
                {
                    { "@MaCauHoi", maCauHoi },
                    { "@HuongDanTraLoi", string.IsNullOrEmpty(question.HuongDanTraLoi) ? DBNull.Value : (object)question.HuongDanTraLoi },
                    { "@CoGioiHanTu", question.CoGioiHanTu ? 1 : 0 },
                    { "@GioiHanTu", question.GioiHanTu }
                };
                
                bool success = db.ExecuteNonQuery(insertEssayQuery, essayParameters);
                
                if (!success)
                {
                    // Try to delete the main question if essay info insert fails
                    string deleteQuery = $"DELETE FROM CauHoi WHERE MaCauHoi = {maCauHoi}";
                    db.ExecuteNonQuery(deleteQuery);
                    return -1;
                }
                
                return maCauHoi;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding essay question: {ex.Message}");
                return -1;
            }
        }
        
        /// <summary>
        /// Add a multiple-choice option to the database
        /// </summary>
        /// <param name="option">The multiple-choice option data</param>
        /// <returns>ID of the created option or -1 if failed</returns>
        public int AddMultipleChoiceOption(LuaChonDTO option)
        {
            try
            {
                string insertOptionQuery = @"
                    INSERT INTO LuaChon (
                        MaCauHoi, NoiDung, NhanDang, LaDapAnDung
                    )
                    VALUES (
                        @MaCauHoi, @NoiDung, @NhanDang, @LaDapAnDung
                    );
                    SELECT SCOPE_IDENTITY();";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaCauHoi", option.MaCauHoi },
                    { "@NoiDung", option.NoiDung },
                    { "@NhanDang", option.NhanDang },
                    { "@LaDapAnDung", option.LaDapAnDung ? 1 : 0 }
                };
                
                int maLuaChon = db.ExecuteInsertAndGetId(insertOptionQuery, parameters);
                option.MaLuaChon = maLuaChon;
                
                return maLuaChon;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding multiple-choice option: {ex.Message}");
                return -1;
            }
        }
        
        /// <summary>
        /// Get a test/quiz by ID
        /// </summary>
        /// <param name="maBaiKT">ID of the test to retrieve</param>
        /// <returns>The test data or null if not found</returns>
        public BaiKiemTraDTO GetBaiKiemTraById(int maBaiKT)
        {
            try
            {
                string query = @"
                    SELECT 
                        bk.*, 
                        mh.TenMon AS TenMonHoc, 
                        lh.TenLop AS TenLop,
                        bkl.MaLop,
                        bkl.NgayKiemTra AS ThoiGianBatDau,
                        bk.ThoiGianKetThuc
                    FROM 
                        BaiKiemTra bk
                    LEFT JOIN 
                        MonHoc mh ON bk.MaMon = mh.MaMon
                    LEFT JOIN 
                        BaiKiemTra_LopHoc bkl ON bk.MaBaiKT = bkl.MaBaiKT
                    LEFT JOIN 
                        LopHoc lh ON bkl.MaLop = lh.MaLop
                    WHERE 
                        bk.MaBaiKT = @MaBaiKT";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    
                    BaiKiemTraDTO baiKiemTra = new BaiKiemTraDTO
                    {
                        MaBaiKT = maBaiKT,
                        TenBaiKT = row["TenBaiKT"].ToString(),
                        MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                        MaGV = Convert.ToInt32(row["MaGV"]),
                        MaMH = Convert.ToInt32(row["MaMon"]),
                        TenMonHoc = row["TenMonHoc"] != DBNull.Value ? row["TenMonHoc"].ToString() : "",
                        LoaiBaiKT = row["LoaiBaiKiemTra"].ToString(),
                        ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                        SoLanLamToiDa = Convert.ToInt32(row["SoLanLamToiDa"]),
                        DiemDatYeuCau = Convert.ToDouble(row["DiemDatYeuCau"]),
                        HienThiKetQuaNgay = Convert.ToBoolean(row["HienThiKetQuaNgay"]),
                        XaoTronCauHoi = Convert.ToBoolean(row["XaoTronCauHoi"]),
                        GhiChuChamDiem = row["GhiChuChamDiem"] != DBNull.Value ? row["GhiChuChamDiem"].ToString() : null,
                        CoMatKhau = Convert.ToBoolean(row["CoMatKhau"]),
                        MatKhau = row["MatKhau"] != DBNull.Value ? row["MatKhau"].ToString() : null,
                        TrangThai = row["TrangThai"].ToString(),
                        NgayTao = Convert.ToDateTime(row["NgayTao"]),
                        HocKy = Convert.ToInt32(row["HocKy"]),
                        NamHoc = row["NamHoc"].ToString(),
                        ThoiGianKetThuc = row["ThoiGianKetThuc"] != DBNull.Value ? Convert.ToDateTime(row["ThoiGianKetThuc"]) : DateTime.MinValue
                    };
                    
                    // Handle class information if available in the join
                    if (row["MaLop"] != DBNull.Value)
                    {
                        baiKiemTra.MaLop = Convert.ToInt32(row["MaLop"]);
                        baiKiemTra.TenLop = row["TenLop"].ToString();
                        
                        // Get test schedule from BaiKiemTra_LopHoc
                        if (row["ThoiGianBatDau"] != DBNull.Value)
                        {
                            baiKiemTra.ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]);
                            // ThoiGianKetThuc được lấy trực tiếp từ cơ sở dữ liệu trong constructor
                        }
                    }
                    
                    // Load questions
                    baiKiemTra.DanhSachCauHoi = GetQuestionsByTestId(maBaiKT);
                    
                    return baiKiemTra;
                }
                
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving test: {ex.Message}");
                return null;
            }
        }
        
        /// <summary>
        /// Get all questions for a specific test
        /// </summary>
        /// <param name="maBaiKT">ID of the test</param>
        /// <returns>List of questions</returns>
        public List<CauHoiDTO> GetQuestionsByTestId(int maBaiKT)
        {
            List<CauHoiDTO> questions = new List<CauHoiDTO>();
            
            try
            {
                string query = @"
                    SELECT * FROM CauHoi
                    WHERE MaBaiKT = @MaBaiKT
                    ORDER BY ThuTu";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int maCauHoi = Convert.ToInt32(row["MaCauHoi"]);
                        string loaiCauHoi = row["LoaiCauHoi"].ToString();
                        
                        if (loaiCauHoi == "MultipleChoice")
                        {
                            CauHoiTracNghiemDTO question = new CauHoiTracNghiemDTO
                            {
                                MaCauHoi = maCauHoi,
                                MaBaiKT = maBaiKT,
                                LoaiCauHoi = loaiCauHoi,
                                NoiDung = row["NoiDung"].ToString(),
                                DiemSo = Convert.ToDouble(row["DiemSo"]),
                                CoHinhAnh = Convert.ToBoolean(row["CoHinhAnh"]),
                                ThuTu = Convert.ToInt32(row["ThuTu"])
                            };
                            
                            // Get image if available
                            if (question.CoHinhAnh && row["HinhAnh"] != DBNull.Value)
                            {
                                question.HinhAnh = (byte[])row["HinhAnh"];
                            }
                            
                            // Load options
                            question.DanhSachLuaChon = GetOptionsForQuestion(maCauHoi);
                            
                            // Determine the correct answer
                            foreach (var option in question.DanhSachLuaChon)
                            {
                                if (option.LaDapAnDung)
                                {
                                    question.DapAnDung = option.NhanDang;
                                    break;
                                }
                            }
                            
                            questions.Add(question);
                        }
                        else if (loaiCauHoi == "Essay")
                        {
                            CauHoiTuLuanDTO question = new CauHoiTuLuanDTO
                            {
                                MaCauHoi = maCauHoi,
                                MaBaiKT = maBaiKT,
                                LoaiCauHoi = loaiCauHoi,
                                NoiDung = row["NoiDung"].ToString(),
                                DiemSo = Convert.ToDouble(row["DiemSo"]),
                                CoHinhAnh = Convert.ToBoolean(row["CoHinhAnh"]),
                                ThuTu = Convert.ToInt32(row["ThuTu"])
                            };
                            
                            // Get image if available
                            if (question.CoHinhAnh && row["HinhAnh"] != DBNull.Value)
                            {
                                question.HinhAnh = (byte[])row["HinhAnh"];
                            }
                            
                            // Get essay-specific information
                            LoadEssayQuestionDetails(question);
                            
                            questions.Add(question);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving questions: {ex.Message}");
            }
            
            return questions;
        }
        
        /// <summary>
        /// Load additional details for an essay question
        /// </summary>
        /// <param name="question">The essay question to load details for</param>
        private void LoadEssayQuestionDetails(CauHoiTuLuanDTO question)
        {
            try
            {
                string query = @"
                    SELECT * FROM CauHoiTuLuan
                    WHERE MaCauHoi = @MaCauHoi";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaCauHoi", question.MaCauHoi }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    
                    question.HuongDanTraLoi = row["HuongDanTraLoi"] != DBNull.Value ? row["HuongDanTraLoi"].ToString() : null;
                    question.CoGioiHanTu = Convert.ToBoolean(row["CoGioiHanTu"]);
                    question.GioiHanTu = Convert.ToInt32(row["GioiHanTu"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading essay question details: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Get all options for a multiple-choice question
        /// </summary>
        /// <param name="maCauHoi">ID of the question</param>
        /// <returns>List of options</returns>
        public List<LuaChonDTO> GetOptionsForQuestion(int maCauHoi)
        {
            List<LuaChonDTO> options = new List<LuaChonDTO>();
            
            try
            {
                string query = @"
                    SELECT * FROM LuaChon
                    WHERE MaCauHoi = @MaCauHoi
                    ORDER BY NhanDang";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaCauHoi", maCauHoi }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        LuaChonDTO option = new LuaChonDTO
                        {
                            MaLuaChon = Convert.ToInt32(row["MaLuaChon"]),
                            MaCauHoi = maCauHoi,
                            NoiDung = row["NoiDung"].ToString(),
                            NhanDang = row["NhanDang"].ToString(),
                            LaDapAnDung = Convert.ToBoolean(row["LaDapAnDung"])
                        };
                        
                        options.Add(option);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving options: {ex.Message}");
            }
            
            return options;
        }
        
        /// <summary>
        /// Get all tests for a teacher
        /// </summary>
        /// <param name="maGV">ID of the teacher</param>
        /// <returns>List of tests</returns>
        public List<BaiKiemTraDTO> GetTestsByTeacher(int maGV)
        {
            List<BaiKiemTraDTO> tests = new List<BaiKiemTraDTO>();

            try
            {
                // Sửa câu truy vấn để không sử dụng bảng BaiKiemTra_CauHoi không tồn tại
                string query = @"
                    SELECT 
                        bk.*, 
                        mh.TenMon AS TenMonHoc,
                        (SELECT COUNT(*) FROM CauHoi WHERE MaBaiKT = bk.MaBaiKT) AS SoCauHoi
                    FROM 
                        BaiKiemTra bk
                    LEFT JOIN 
                        MonHoc mh ON bk.MaMon = mh.MaMon
                    WHERE 
                        bk.MaGV = @MaGV
                    ORDER BY 
                        bk.NgayTao DESC";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaGV", maGV }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BaiKiemTraDTO test = new BaiKiemTraDTO
                        {
                            MaBaiKT = Convert.ToInt32(row["MaBaiKT"]),
                            TenBaiKT = row["TenBaiKT"].ToString(),
                            MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                            MaGV = maGV,
                            MaMH = Convert.ToInt32(row["MaMon"]),
                            TenMonHoc = row["TenMonHoc"] != DBNull.Value ? row["TenMonHoc"].ToString() : "",
                            LoaiBaiKT = row["LoaiBaiKiemTra"] != DBNull.Value ? row["LoaiBaiKiemTra"].ToString() : "",
                            ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                            NgayTao = Convert.ToDateTime(row["NgayTao"]),
                            TrangThai = row["TrangThai"].ToString(),
                            HocKy = row["HocKy"] != DBNull.Value ? Convert.ToInt32(row["HocKy"]) : 0,
                            NamHoc = row["NamHoc"] != DBNull.Value ? row["NamHoc"].ToString() : ""
                        };

                        // Thêm các trường tùy chọn nếu tồn tại trong schema
                        if (dt.Columns.Contains("SoLanLamToiDa"))
                            test.SoLanLamToiDa = Convert.ToInt32(row["SoLanLamToiDa"]);
                        if (dt.Columns.Contains("DiemDatYeuCau"))
                            test.DiemDatYeuCau = Convert.ToDouble(row["DiemDatYeuCau"]);
                        if (dt.Columns.Contains("ThoiGianBatDau"))
                            test.ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]);
                        if (dt.Columns.Contains("ThoiGianKetThuc"))
                            test.ThoiGianKetThuc = Convert.ToDateTime(row["ThoiGianKetThuc"]);
                        if (dt.Columns.Contains("HienThiKetQuaNgay"))
                            test.HienThiKetQuaNgay = Convert.ToBoolean(row["HienThiKetQuaNgay"]);
                        if (dt.Columns.Contains("XaoTronCauHoi"))
                            test.XaoTronCauHoi = Convert.ToBoolean(row["XaoTronCauHoi"]);
                        if (dt.Columns.Contains("GhiChuChamDiem"))
                            test.GhiChuChamDiem = row["GhiChuChamDiem"] != DBNull.Value ? row["GhiChuChamDiem"].ToString() : null;
                        if (dt.Columns.Contains("CoMatKhau"))
                            test.CoMatKhau = Convert.ToBoolean(row["CoMatKhau"]);
                        if (dt.Columns.Contains("MatKhau"))
                            test.MatKhau = row["MatKhau"] != DBNull.Value ? row["MatKhau"].ToString() : null;

                        tests.Add(test);
                    }
                }

                return tests;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving tests for teacher: {ex.Message}");
                return tests;
            }
        }
        
        /// <summary>
        /// Update the status of a test
        /// </summary>
        /// <param name="maBaiKT">ID of the test</param>
        /// <param name="trangThai">New status</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdateTestStatus(int maBaiKT, string trangThai)
        {
            try
            {
                // Standardize to Vietnamese status
                string standardizedStatus = trangThai;
                if (trangThai == "Published")
                    standardizedStatus = "Đã công bố";
                else if (trangThai == "Draft")
                    standardizedStatus = "Chưa công bố";

                string query = @"
                    UPDATE BaiKiemTra
                    SET TrangThai = @TrangThai
                    WHERE MaBaiKT = @MaBaiKT";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT },
                    { "@TrangThai", standardizedStatus }
                };
                
                return db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating test status: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Delete a test and all its questions
        /// </summary>
        /// <param name="maBaiKT">ID of the test to delete</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool DeleteTest(int maBaiKT)
        {
            try
            {
                // Get all questions to delete options and essay details first
                List<CauHoiDTO> questions = GetQuestionsByTestId(maBaiKT);
                
                // Use a transaction to ensure all are deleted
                List<string> deleteCommands = new List<string>();
                
                // Delete options for multiple-choice questions
                foreach (var question in questions)
                {
                    if (question is CauHoiTracNghiemDTO)
                    {
                        deleteCommands.Add($"DELETE FROM LuaChon WHERE MaCauHoi = {question.MaCauHoi}");
                    }
                    else if (question is CauHoiTuLuanDTO)
                    {
                        deleteCommands.Add($"DELETE FROM CauHoiTuLuan WHERE MaCauHoi = {question.MaCauHoi}");
                    }
                }
                
                // Delete all questions
                deleteCommands.Add($"DELETE FROM CauHoi WHERE MaBaiKT = {maBaiKT}");
                
                // Delete the test itself
                deleteCommands.Add($"DELETE FROM BaiKiemTra WHERE MaBaiKT = {maBaiKT}");
                
                return db.ExecuteTransaction(deleteCommands);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting test: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Make sure all required tables exist in the database
        /// </summary>
        private void EnsureTablesExist()
        {
            try
            {
                // Check and create CauHoi table if it doesn't exist
                string checkCauHoiTable = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CauHoi')
                    BEGIN
                        CREATE TABLE CauHoi (
                            MaCauHoi INT IDENTITY(1,1) PRIMARY KEY,
                            MaBaiKT INT NOT NULL,
                            LoaiCauHoi NVARCHAR(20) NOT NULL,
                            NoiDung NVARCHAR(MAX) NOT NULL,
                            DiemSo FLOAT NOT NULL,
                            CoHinhAnh BIT DEFAULT 0,
                            HinhAnh VARBINARY(MAX) NULL,
                            ThuTu INT NOT NULL,
                            FOREIGN KEY (MaBaiKT) REFERENCES BaiKiemTra(MaBaiKT)
                        )
                    END";
                
                db.ExecuteNonQuery(checkCauHoiTable);
                
                // Check and create LuaChon table if it doesn't exist
                string checkLuaChonTable = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LuaChon')
                    BEGIN
                        CREATE TABLE LuaChon (
                            MaLuaChon INT IDENTITY(1,1) PRIMARY KEY,
                            MaCauHoi INT NOT NULL,
                            NoiDung NVARCHAR(500) NOT NULL,
                            NhanDang CHAR(1) NOT NULL,
                            LaDapAnDung BIT NOT NULL,
                            FOREIGN KEY (MaCauHoi) REFERENCES CauHoi(MaCauHoi)
                        )
                    END";
                
                db.ExecuteNonQuery(checkLuaChonTable);
                
                // Check and create CauHoiTuLuan table if it doesn't exist
                string checkCauHoiTuLuanTable = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CauHoiTuLuan')
                    BEGIN
                        CREATE TABLE CauHoiTuLuan (
                            MaCauHoi INT PRIMARY KEY,
                            HuongDanTraLoi NVARCHAR(MAX) NULL,
                            CoGioiHanTu BIT DEFAULT 0,
                            GioiHanTu INT DEFAULT 500,
                            FOREIGN KEY (MaCauHoi) REFERENCES CauHoi(MaCauHoi)
                        )
                    END";
                
                db.ExecuteNonQuery(checkCauHoiTuLuanTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ensuring tables exist: {ex.Message}");
            }
        }
        /// <summary>
        /// Lấy danh sách các lớp học được gán cho một bài kiểm tra
        /// </summary>
        /// <param name="maBaiKT">Mã bài kiểm tra</param>
        /// <returns>Danh sách các lớp học</returns>
        public List<dynamic> GetClassesForTest(int maBaiKT)
        {
            List<dynamic> classes = new List<dynamic>();

            try
            {
                string query = @"
                    SELECT bkl.*, lh.TenLop
                    FROM BaiKiemTra_LopHoc bkl
                    JOIN LopHoc lh ON bkl.MaLop = lh.MaLop
                    WHERE bkl.MaBaiKT = @MaBaiKT";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var classInfo = new
                        {
                            MaLop = Convert.ToInt32(row["MaLop"]),
                            TenLop = row["TenLop"].ToString(),
                            NgayKiemTra = Convert.ToDateTime(row["NgayKiemTra"]),
                            TrangThai = row["TrangThai"].ToString()
                        };

                        classes.Add(classInfo);
                    }
                }

                return classes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting classes for test: {ex.Message}");
                return classes;
            }
        }
        /// <summary>
        /// Get all submissions for a specific student
        /// </summary>
        /// <param name="maHS">Student ID</param>
        /// <returns>List of submissions</returns>
        public List<BaiLamDTO> GetSubmissionsByStudent(int maHS)
        {
            List<BaiLamDTO> submissions = new List<BaiLamDTO>();

            try
            {
                string query = @"
                    SELECT bl.*, bk.TenBaiKT
                    FROM BaiLam bl
                    INNER JOIN BaiKiemTra bk ON bl.MaBaiKT = bk.MaBaiKT
                    WHERE bl.MaHS = @MaHS
                    ORDER BY bl.NgayLam DESC";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BaiLamDTO submission = new BaiLamDTO
                        {
                            MaBaiLam = Convert.ToInt32(row["MaBaiLam"]),
                            MaBaiKT = Convert.ToInt32(row["MaBaiKT"]),
                            TenBaiKT = row["TenBaiKT"].ToString(),
                            MaHS = maHS,
                            NgayLam = Convert.ToDateTime(row["NgayLam"]),
                            ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                            DiemSo = row["DiemSo"] != DBNull.Value ? Convert.ToDouble(row["DiemSo"]) : (double?)null,
                            DaNop = Convert.ToBoolean(row["DaNop"])
                        };

                        submissions.Add(submission);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving submissions for student: {ex.Message}");
            }

            return submissions;
        }
        /// <summary>
        /// Get all tests assigned to a specific class
        /// </summary>
        /// <param name="maLop">Class ID</param>
        /// <param name="namHoc">School year (optional)</param>
        /// <param name="hocKy">Semester (optional)</param>
        /// <returns>List of tests</returns>
        public List<BaiKiemTraDTO> GetTestsForClass(int maLop, string namHoc = null, int? hocKy = null)
        {
            List<BaiKiemTraDTO> tests = new List<BaiKiemTraDTO>();

            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                // Base query - Explicitly name all columns to avoid field name confusion
                string query = @"
                    SELECT 
                        bk.MaBaiKT, bk.TenBaiKT, bk.MoTa, bk.MaGV, bk.MaMon AS MaMH,
                        bk.ThoiGianLamBai, bk.TrangThai, bk.NgayTao, bk.HocKy, bk.NamHoc,
                        bk.SoLanLamToiDa, bk.DiemDatYeuCau, bk.HienThiKetQuaNgay,
                        bk.XaoTronCauHoi, bk.GhiChuChamDiem, bk.CoMatKhau, bk.MatKhau,
                        bk.LoaiBaiKiemTra AS LoaiBaiKT, 
                        mh.TenMon AS TenMonHoc,
                        lh.TenLop,
                        bkl.NgayKiemTra AS ThoiGianBatDau,
                        bk.ThoiGianKetThuc
                    FROM 
                        BaiKiemTra bk
                    INNER JOIN 
                        BaiKiemTra_LopHoc bkl ON bk.MaBaiKT = bkl.MaBaiKT
                    INNER JOIN
                        MonHoc mh ON bk.MaMon = mh.MaMon
                    INNER JOIN
                        LopHoc lh ON bkl.MaLop = lh.MaLop
                    WHERE 
                        bkl.MaLop = @MaLop";

                parameters.Add("@MaLop", maLop);

                // Add optional filters
                if (!string.IsNullOrEmpty(namHoc))
                {
                    query += " AND bk.NamHoc = @NamHoc";
                    parameters.Add("@NamHoc", namHoc);
                }

                if (hocKy.HasValue)
                {
                    query += " AND bk.HocKy = @HocKy";
                    parameters.Add("@HocKy", hocKy.Value);
                }

                // Only get published tests (support both English and Vietnamese status)
                query += " AND (bk.TrangThai = N'Published' OR bk.TrangThai = N'Đã công bố')";

                // Order by test date
                query += " ORDER BY bkl.NgayKiemTra DESC";

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BaiKiemTraDTO test = new BaiKiemTraDTO
                        {
                            MaBaiKT = Convert.ToInt32(row["MaBaiKT"]),
                            TenBaiKT = row["TenBaiKT"].ToString(),
                            MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                            MaGV = Convert.ToInt32(row["MaGV"]),
                            MaMH = Convert.ToInt32(row["MaMH"]),
                            TenMonHoc = row["TenMonHoc"].ToString(),
                            MaLop = maLop,
                            TenLop = row["TenLop"].ToString(),
                            LoaiBaiKT = row["LoaiBaiKT"] != DBNull.Value ? row["LoaiBaiKT"].ToString() : "Bài kiểm tra",
                            ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                            ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]),
                            ThoiGianKetThuc = Convert.ToDateTime(row["ThoiGianKetThuc"]),
                            NgayTao = Convert.ToDateTime(row["NgayTao"]),
                            TrangThai = row["TrangThai"].ToString(),
                            HocKy = Convert.ToInt32(row["HocKy"]),
                            NamHoc = row["NamHoc"].ToString()
                        };

                        // Set other properties with null checks
                        test.SoLanLamToiDa = row["SoLanLamToiDa"] != DBNull.Value ? Convert.ToInt32(row["SoLanLamToiDa"]) : 1;
                        test.DiemDatYeuCau = row["DiemDatYeuCau"] != DBNull.Value ? Convert.ToDouble(row["DiemDatYeuCau"]) : 5.0;
                        test.HienThiKetQuaNgay = row["HienThiKetQuaNgay"] != DBNull.Value ? Convert.ToBoolean(row["HienThiKetQuaNgay"]) : false;
                        test.XaoTronCauHoi = row["XaoTronCauHoi"] != DBNull.Value ? Convert.ToBoolean(row["XaoTronCauHoi"]) : false;
                        test.CoMatKhau = row["CoMatKhau"] != DBNull.Value ? Convert.ToBoolean(row["CoMatKhau"]) : false;

                        tests.Add(test);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải danh sách bài kiểm tra cho lớp: {ex.Message}");
            }

            return tests;
        }

        /// <summary>
        /// Get all distinct school years from the database
        /// </summary>
        /// <returns>List of school years</returns>
        public List<string> GetDistinctSchoolYears()
        {
            List<string> years = new List<string>();

            try
            {
                string query = "SELECT DISTINCT NamHoc FROM BaiKiemTra ORDER BY NamHoc DESC";

                DataTable dt = db.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        years.Add(row["NamHoc"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving school years: {ex.Message}");
            }

            return years;
        }

        /// <summary>
        /// Get a test with class filter for a specific student
        /// </summary>
        /// <param name="maBaiKT">Test ID</param>
        /// <param name="maHS">Student ID</param>
        /// <returns>The test data or null if not found or not accessible to the student</returns>
        public BaiKiemTraDTO GetBaiKiemTraForStudent(int maBaiKT, int maHS)
        {
            try
            {
                // First, get the student's class
                string getClassQuery = @"
                    SELECT MaLop 
                    FROM HocSinh 
                    WHERE MaHS = @MaHS";
                
                Dictionary<string, object> studentParams = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };
                
                DataTable studentDt = db.ExecuteQuery(getClassQuery, studentParams);
                
                if (studentDt == null || studentDt.Rows.Count == 0)
                {
                    return null; // Student not found
                }
                
                int maLop = Convert.ToInt32(studentDt.Rows[0]["MaLop"]);
                
                // Then get the test but only if it's assigned to the student's class
                string query = @"
                    SELECT 
                        bk.*, 
                        mh.TenMon AS TenMonHoc, 
                        lh.TenLop AS TenLop,
                        bkl.NgayKiemTra AS ThoiGianBatDau,
                        bk.ThoiGianKetThuc AS ThoiGianKetThuc
                    FROM 
                        BaiKiemTra bk
                    INNER JOIN 
                        BaiKiemTra_LopHoc bkl ON bk.MaBaiKT = bkl.MaBaiKT
                    INNER JOIN 
                        LopHoc lh ON bkl.MaLop = lh.MaLop
                    INNER JOIN 
                        MonHoc mh ON bk.MaMon = mh.MaMon
                    WHERE 
                        bk.MaBaiKT = @MaBaiKT AND
                        bkl.MaLop = @MaLop AND
                        (bk.TrangThai = N'Published' OR bk.TrangThai = N'Đã công bố')";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT },
                    { "@MaLop", maLop }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    
                    BaiKiemTraDTO baiKiemTra = new BaiKiemTraDTO
                    {
                        MaBaiKT = maBaiKT,
                        TenBaiKT = row["TenBaiKT"].ToString(),
                        MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                        MaGV = Convert.ToInt32(row["MaGV"]),
                        MaMH = Convert.ToInt32(row["MaMon"]),
                        TenMonHoc = row["TenMonHoc"].ToString(),
                        MaLop = maLop,
                        TenLop = row["TenLop"].ToString(),
                        LoaiBaiKT = row["LoaiBaiKiemTra"].ToString(),
                        ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                        SoLanLamToiDa = Convert.ToInt32(row["SoLanLamToiDa"]),
                        DiemDatYeuCau = Convert.ToDouble(row["DiemDatYeuCau"]),
                        ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]),
                        ThoiGianKetThuc = Convert.ToDateTime(row["ThoiGianKetThuc"]),
                        HienThiKetQuaNgay = Convert.ToBoolean(row["HienThiKetQuaNgay"]),
                        XaoTronCauHoi = Convert.ToBoolean(row["XaoTronCauHoi"]),
                        GhiChuChamDiem = row["GhiChuChamDiem"] != DBNull.Value ? row["GhiChuChamDiem"].ToString() : null,
                        CoMatKhau = Convert.ToBoolean(row["CoMatKhau"]),
                        MatKhau = row["MatKhau"] != DBNull.Value ? row["MatKhau"].ToString() : null,
                        TrangThai = row["TrangThai"].ToString(),
                        NgayTao = Convert.ToDateTime(row["NgayTao"]),
                        HocKy = Convert.ToInt32(row["HocKy"]),
                        NamHoc = row["NamHoc"].ToString()
                    };
                    
                    // Load questions
                    baiKiemTra.DanhSachCauHoi = GetQuestionsByTestId(maBaiKT);
                    
                    return baiKiemTra;
                }
                
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving test for student: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get a list of available tests for a specific student based on their class
        /// </summary>
        /// <param name="maHS">Student ID</param>
        /// <param name="namHoc">School year (optional)</param>
        /// <param name="hocKy">Semester (optional)</param>
        /// <returns>List of available tests</returns>
        public List<BaiKiemTraDTO> GetAvailableTestsForStudent(int maHS, string namHoc = null, int? hocKy = null)
        {
            List<BaiKiemTraDTO> tests = new List<BaiKiemTraDTO>();

            try
            {
                // First, get the student's class
                string getClassQuery = @"
                    SELECT MaLop 
                    FROM HocSinh 
                    WHERE MaHS = @MaHS";
                
                Dictionary<string, object> studentParams = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };
                
                DataTable studentDt = db.ExecuteQuery(getClassQuery, studentParams);
                
                if (studentDt == null || studentDt.Rows.Count == 0)
                {
                    return tests; // Empty list if student not found
                }
                
                int maLop = Convert.ToInt32(studentDt.Rows[0]["MaLop"]);

                // Base query to get available tests for the student's class
                string query = @"
                    SELECT 
                        bk.MaBaiKT, bk.TenBaiKT, bk.MoTa, bk.MaGV, bk.MaMon AS MaMH,
                        bk.ThoiGianLamBai, bk.TrangThai, bk.NgayTao, bk.HocKy, bk.NamHoc,
                        bk.SoLanLamToiDa, bk.DiemDatYeuCau, bk.HienThiKetQuaNgay,
                        bk.XaoTronCauHoi, bk.GhiChuChamDiem, bk.CoMatKhau, bk.MatKhau,
                        bk.LoaiBaiKiemTra AS LoaiBaiKT, 
                        mh.TenMon AS TenMonHoc,
                        lh.TenLop,
                        bkl.NgayKiemTra AS ThoiGianBatDau,
                        bk.ThoiGianKetThuc,
                        (SELECT COUNT(*) FROM BaiLam bl WHERE bl.MaBaiKT = bk.MaBaiKT AND bl.MaHS = @MaHS AND bl.DaNop = 1) AS SoLanLamBai
                    FROM 
                        BaiKiemTra bk
                    INNER JOIN 
                        BaiKiemTra_LopHoc bkl ON bk.MaBaiKT = bkl.MaBaiKT
                    INNER JOIN
                        MonHoc mh ON bk.MaMon = mh.MaMon
                    INNER JOIN
                        LopHoc lh ON bkl.MaLop = lh.MaLop
                    WHERE 
                        bkl.MaLop = @MaLop
                        AND (bk.TrangThai = N'Published' OR bk.TrangThai = N'Đã công bố')
                        AND GETDATE() BETWEEN bkl.NgayKiemTra AND bk.ThoiGianKetThuc";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaLop", maLop },
                    { "@MaHS", maHS }
                };

                // Add optional filters
                if (!string.IsNullOrEmpty(namHoc))
                {
                    query += " AND bk.NamHoc = @NamHoc";
                    parameters.Add("@NamHoc", namHoc);
                }

                if (hocKy.HasValue)
                {
                    query += " AND bk.HocKy = @HocKy";
                    parameters.Add("@HocKy", hocKy.Value);
                }

                // Order by test date
                query += " ORDER BY bkl.NgayKiemTra ASC";

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int soLanLamBai = Convert.ToInt32(row["SoLanLamBai"]);
                        int soLanLamToiDa = row["SoLanLamToiDa"] != DBNull.Value ? Convert.ToInt32(row["SoLanLamToiDa"]) : 1;

                        // Skip tests that student has already taken the maximum number of times
                        if (soLanLamBai >= soLanLamToiDa)
                        {
                            continue;
                        }

                        BaiKiemTraDTO test = new BaiKiemTraDTO
                        {
                            MaBaiKT = Convert.ToInt32(row["MaBaiKT"]),
                            TenBaiKT = row["TenBaiKT"].ToString(),
                            MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                            MaGV = Convert.ToInt32(row["MaGV"]),
                            MaMH = Convert.ToInt32(row["MaMH"]),
                            TenMonHoc = row["TenMonHoc"].ToString(),
                            MaLop = maLop,
                            TenLop = row["TenLop"].ToString(),
                            LoaiBaiKT = row["LoaiBaiKT"] != DBNull.Value ? row["LoaiBaiKT"].ToString() : "Bài kiểm tra",
                            ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                            ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]),
                            ThoiGianKetThuc = Convert.ToDateTime(row["ThoiGianKetThuc"]),
                            NgayTao = Convert.ToDateTime(row["NgayTao"]),
                            TrangThai = row["TrangThai"].ToString(),
                            HocKy = Convert.ToInt32(row["HocKy"]),
                            NamHoc = row["NamHoc"].ToString(),
                            SoLanLamToiDa = soLanLamToiDa,
                            DiemDatYeuCau = row["DiemDatYeuCau"] != DBNull.Value ? Convert.ToDouble(row["DiemDatYeuCau"]) : 5.0,
                            HienThiKetQuaNgay = row["HienThiKetQuaNgay"] != DBNull.Value ? Convert.ToBoolean(row["HienThiKetQuaNgay"]) : false,
                            XaoTronCauHoi = row["XaoTronCauHoi"] != DBNull.Value ? Convert.ToBoolean(row["XaoTronCauHoi"]) : false,
                            CoMatKhau = row["CoMatKhau"] != DBNull.Value ? Convert.ToBoolean(row["CoMatKhau"]) : false,
                            MatKhau = row["MatKhau"] != DBNull.Value ? row["MatKhau"].ToString() : null
                        };

                        tests.Add(test);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải danh sách bài kiểm tra cho học sinh: {ex.Message}");
            }

            return tests;
        }
        
        /// <summary>
        /// Get a list of all tests (both available and completed) for a student
        /// </summary>
        /// <param name="maHS">Student ID</param>
        /// <param name="namHoc">School year (optional)</param>
        /// <param name="hocKy">Semester (optional)</param>
        /// <returns>List of all relevant tests</returns>
        public List<BaiKiemTraDTO> GetAllTestsForStudent(int maHS, string namHoc = null, int? hocKy = null)
        {
            try 
            {
                // First, get the student's class
                string getClassQuery = @"
                    SELECT MaLop 
                    FROM HocSinh 
                    WHERE MaHS = @MaHS";
                
                Dictionary<string, object> studentParams = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };
                
                DataTable studentDt = db.ExecuteQuery(getClassQuery, studentParams);
                
                if (studentDt == null || studentDt.Rows.Count == 0)
                {
                    return new List<BaiKiemTraDTO>(); 
                }
                
                int maLop = Convert.ToInt32(studentDt.Rows[0]["MaLop"]);
                
                // Get all tests for this class
                return GetTestsForClass(maLop, namHoc, hocKy);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải tất cả bài kiểm tra cho học sinh: {ex.Message}");
                return new List<BaiKiemTraDTO>();
            }
        }
    }
}
