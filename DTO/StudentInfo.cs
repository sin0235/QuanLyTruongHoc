// Cấu trúc dữ liệu học sinh
using System;
using System.Drawing;

public class StudentInfo
{
    // Thông tin học sinh
    public string StudentId { get; set; }        // Mã học sinh
    public string FullName { get; set; }         // Họ tên
    public DateTime DateOfBirth { get; set; }    // Ngày sinh
    public string PlaceOfBirth { get; set; }     // Nơi sinh
    public string Gender { get; set; }           // Giới tính
    public string IdentityCode { get; set; }     // Mã định danh
    public string Ethnicity { get; set; }        // Dân tộc
    public string Religion { get; set; }         // Tôn giáo
    public string ClassName { get; set; }        // Lớp

    // Thông tin liên lạc
    public string Country { get; set; }          // Quốc gia
    public string Province { get; set; }         // Tỉnh thành
    public string District { get; set; }         // Quận huyện
    public string Ward { get; set; }             // Phường/xã
    public string Address { get; set; }          // Địa chỉ
    public string PermanentAddress { get; set; } // Địa chỉ thường trú
    public string Phone { get; set; }            // Số điện thoại
    public string Mobile { get; set; }           // Di động
    public string Email { get; set; }            // Email cá nhân

    // Thông tin gia đình
    public string FatherName { get; set; }       // Họ tên cha
    public string FatherPhone { get; set; }      // Điện thoại cha
    public string MotherName { get; set; }       // Họ tên mẹ
    public string MotherPhone { get; set; }      // Điện thoại mẹ
  


    public Image Avatar { get; set; }            // Ảnh đại diện
}
