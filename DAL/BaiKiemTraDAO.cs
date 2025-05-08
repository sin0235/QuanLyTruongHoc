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
                // Check if the required tables exist, if not create them
                EnsureTablesExist();
                
                // Insert the test and get its ID
                string insertTestQuery = @"
    INSERT INTO BaiKiemTra (
        MaGV, TenBaiKT, MoTa, ThoiGianLamBai, 
        ThoiGianBatDau, ThoiGianKetThuc, DiemDatYeuCau, SoLanLamToiDa, 
        MaLop, MaMon, LoaiBaiKiemTra, HienThiKetQuaNgay, XaoTronCauHoi, 
        GhiChuChamDiem, CoMatKhau, MatKhau, TrangThai, NgayTao, HocKy, NamHoc
    )
    VALUES (
        @MaGV, @TenBaiKT, @MoTa, @ThoiGianLamBai, 
        @ThoiGianBatDau, @ThoiGianKetThuc, @DiemDatYeuCau, @SoLanLamToiDa, 
        @MaLop, @MaMH, @LoaiBaiKiemTra, @HienThiKetQuaNgay, @XaoTronCauHoi, 
        @GhiChuChamDiem, @CoMatKhau, @MatKhau, @TrangThai, GETDATE(), @HocKy, @NamHoc
    );
    SELECT SCOPE_IDENTITY();";
                
Dictionary<string, object> parameters = new Dictionary<string, object>
{
    { "@MaGV", baiKiemTra.MaGV },
    { "@TenBaiKT", baiKiemTra.TenBaiKT },
    { "@MoTa", string.IsNullOrEmpty(baiKiemTra.MoTa) ? DBNull.Value : (object)baiKiemTra.MoTa },
    { "@ThoiGianLamBai", baiKiemTra.ThoiGianLamBai },
    { "@ThoiGianBatDau", baiKiemTra.ThoiGianBatDau },
    { "@ThoiGianKetThuc", baiKiemTra.ThoiGianKetThuc },
    { "@DiemDatYeuCau", baiKiemTra.DiemDatYeuCau },
    { "@SoLanLamToiDa", baiKiemTra.SoLanLamToiDa },
    { "@MaLop", baiKiemTra.MaLop },
    { "@MaMH", baiKiemTra.MaMH > 0 ? baiKiemTra.MaMH : throw new InvalidOperationException("MaMH không được phép là 0 hoặc null") },
    { "@LoaiBaiKiemTra", baiKiemTra.LoaiBaiKT },
    { "@HienThiKetQuaNgay", baiKiemTra.HienThiKetQuaNgay ? 1 : 0 },
    { "@XaoTronCauHoi", baiKiemTra.XaoTronCauHoi ? 1 : 0 },
    { "@GhiChuChamDiem", string.IsNullOrEmpty(baiKiemTra.GhiChuChamDiem) ? DBNull.Value : (object)baiKiemTra.GhiChuChamDiem },
    { "@CoMatKhau", baiKiemTra.CoMatKhau ? 1 : 0 },
    { "@MatKhau", baiKiemTra.CoMatKhau ? (object)baiKiemTra.MatKhau : DBNull.Value },
    { "@TrangThai", baiKiemTra.TrangThai },
     { "@HocKy", baiKiemTra.HocKy },
    { "@NamHoc", baiKiemTra.NamHoc }
};
                
                int maBaiKT = db.ExecuteInsertAndGetId(insertTestQuery, parameters);
                
                if (maBaiKT <= 0)
                {
                    return -1; // Failed to insert test
                }
                
                // Now add all the questions
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
                
                // Now add all the options
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
                        lh.TenLop AS TenLop 
                    FROM 
                        BaiKiemTra bk
                    LEFT JOIN 
                        MonHoc mh ON bk.MaMH = mh.MaMon
                    LEFT JOIN 
                        LopHoc lh ON bk.MaLop = lh.MaLop
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
                        MaMH = Convert.ToInt32(row["MaMH"]),
                        TenMonHoc = row["TenMonHoc"] != DBNull.Value ? row["TenMonHoc"].ToString() : "",
                        MaLop = Convert.ToInt32(row["MaLop"]),
                        TenLop = row["TenLop"] != DBNull.Value ? row["TenLop"].ToString() : "",
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
                        NgayTao = Convert.ToDateTime(row["NgayTao"])
                    };
                    
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
                string query = @"
                    SELECT 
                        bk.*, 
                        mh.TenMon AS TenMonHoc, 
                        lh.TenLop AS TenLop,
                        (SELECT COUNT(*) FROM CauHoi WHERE MaBaiKT = bk.MaBaiKT) AS SoCauHoi
                    FROM 
                        BaiKiemTra bk
                    LEFT JOIN 
                        MonHoc mh ON bk.MaMH = mh.MaMon
                    LEFT JOIN 
                        LopHoc lh ON bk.MaLop = lh.MaLop
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
                            MaMH = Convert.ToInt32(row["MaMH"]),
                            TenMonHoc = row["TenMonHoc"] != DBNull.Value ? row["TenMonHoc"].ToString() : "",
                            MaLop = Convert.ToInt32(row["MaLop"]),
                            TenLop = row["TenLop"] != DBNull.Value ? row["TenLop"].ToString() : "",
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
                            NgayTao = Convert.ToDateTime(row["NgayTao"])
                        };
                        
                        tests.Add(test);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving tests for teacher: {ex.Message}");
            }
            
            return tests;
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
                string query = @"
                    UPDATE BaiKiemTra
                    SET TrangThai = @TrangThai
                    WHERE MaBaiKT = @MaBaiKT";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT },
                    { "@TrangThai", trangThai }
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
    }
}
