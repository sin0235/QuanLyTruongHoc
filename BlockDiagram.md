# Sơ đồ khối hệ thống Quản lý Trường học

## Kiến trúc tổng quan
```
┌─────────────────────────────────────────────────────────────────┐
│                                                                 │
│                        PRESENTATION LAYER                       │
│                                                                 │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────┐  ┌────────┐ │
│  │  Giao diện  │  │  Giao diện  │  │  Giao diện  │  │  Các   │ │
│  │  Giáo viên  │  │  Học sinh   │  │   Quản lý   │  │ form   │ │
│  └─────────────┘  └─────────────┘  └─────────────┘  │ khác   │ │
│                                                     └────────┘ │
└───────────────────────────────┬─────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────────┐
│                                                                 │
│                        BUSINESS LOGIC LAYER                     │
│                                                                 │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────┐  ┌────────┐ │
│  │  Quản lý    │  │  Quản lý    │  │  Quản lý    │  │ Quản lý│ │
│  │  Học sinh   │  │  Điểm số    │  │  Bài kiểm   │  │ Thông  │ │
│  │             │  │             │  │  tra        │  │ báo    │ │
│  └─────────────┘  └─────────────┘  └─────────────┘  └────────┘ │
│                                                                 │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────┐             │
│  │  Quản lý    │  │  Quản lý    │  │  Quản lý    │             │
│  │  Lớp học    │  │  Thời khóa  │  │  Đơn xin    │             │
│  │             │  │  biểu       │  │  nghỉ       │             │
│  └─────────────┘  └─────────────┘  └─────────────┘             │
│                                                                 │
└───────────────────────────────┬─────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────────┐
│                                                                 │
│                        DATA ACCESS LAYER                        │
│                                                                 │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────┐  ┌────────┐ │
│  │ HocSinhDAO  │  │  DiemSoDAO  │  │BaiKiemTraDAO│  │TKBDAO  │ │
│  └─────────────┘  └─────────────┘  └─────────────┘  └────────┘ │
│                                                                 │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────┐             │
│  │ThongBaoDAO  │  │  BaiLamDAO  │  │DonXinNghiDAO│             │
│  └─────────────┘  └─────────────┘  └─────────────┘             │
│                                                                 │
│  ┌─────────────────────────────────────────────────────────────┐│
│  │                     DatabaseHelper                          ││
│  └─────────────────────────────────────────────────────────────┘│
│                                                                 │
└───────────────────────────────┬─────────────────────────────────┘
                                │
                                ▼
┌─────────────────────────────────────────────────────────────────┐
│                                                                 │
│                        DATABASE                                 │
│                                                                 │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────┐  ┌────────┐ │
│  │  Học sinh   │  │   Điểm số   │  │ Bài kiểm tra│  │  Lớp   │ │
│  └─────────────┘  └─────────────┘  └─────────────┘  └────────┘ │
│                                                                 │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────┐  ┌────────┐ │
│  │ Thời khóa   │  │  Thông báo  │  │  Đơn xin    │  │Bài làm │ │
│  │   biểu      │  │             │  │    nghỉ     │  │        │ │
│  └─────────────┘  └─────────────┘  └─────────────┘  └────────┘ │
│                                                                 │
└─────────────────────────────────────────────────────────────────┘
```

## Mô tả các thành phần

### 1. Presentation Layer (Tầng giao diện)
- **Giao diện Giáo viên**: Các form dành cho giáo viên (frmGV, frmGiaoVien)
- **Giao diện Học sinh**: Các form dành cho học sinh (frmHS)
- **Giao diện Quản lý**: Các form dành cho quản lý (frmQuanLyEx, frmBGH, frmPhongNoiVu)
- **Các form khác**: frmLogin, frmChangePW, frmThongBaoChiTiet, frmNhapDiem, frmChinhSuaDiem, v.v.

### 2. Business Logic Layer (Tầng logic nghiệp vụ)
Xử lý các quy trình nghiệp vụ chính của hệ thống:
- Quản lý Học sinh
- Quản lý Điểm số
- Quản lý Bài kiểm tra
- Quản lý Thông báo
- Quản lý Lớp học
- Quản lý Thời khóa biểu
- Quản lý Đơn xin nghỉ

### 3. Data Access Layer (Tầng truy cập dữ liệu)
Các lớp DAO (Data Access Object) để truy xuất dữ liệu:
- **HocSinhDAO**: Quản lý dữ liệu học sinh
- **DiemSoDAO**: Quản lý dữ liệu điểm số
- **BaiKiemTraDAO**: Quản lý dữ liệu bài kiểm tra
- **TKBDAO**: Quản lý dữ liệu thời khóa biểu
- **ThongBaoDAO**: Quản lý dữ liệu thông báo
- **BaiLamDAO**: Quản lý dữ liệu bài làm
- **DonXinNghiDAO**: Quản lý dữ liệu đơn xin nghỉ
- **DatabaseHelper**: Lớp hỗ trợ kết nối và thao tác với cơ sở dữ liệu

### 4. Database (Cơ sở dữ liệu)
Lưu trữ dữ liệu của hệ thống:
- Học sinh
- Điểm số
- Bài kiểm tra
- Lớp học
- Thời khóa biểu
- Thông báo
- Đơn xin nghỉ
- Bài làm

## Luồng dữ liệu
1. Người dùng tương tác với giao diện (Presentation Layer)
2. Giao diện gọi các phương thức xử lý nghiệp vụ (Business Logic Layer)
3. Tầng nghiệp vụ gọi các phương thức truy xuất dữ liệu (Data Access Layer)
4. Tầng truy xuất dữ liệu kết nối với cơ sở dữ liệu để lấy hoặc cập nhật thông tin
5. Dữ liệu được trả về theo chiều ngược lại đến người dùng

## Các đối tượng dữ liệu chính (DTO)
- ThongTinHSDTO: Thông tin học sinh
- DiemSoDTO: Thông tin điểm số
- BaiKiemTraDTO: Thông tin bài kiểm tra
- TKBDTO: Thông tin thời khóa biểu
- ThongBaoDTO: Thông tin thông báo
- DonXinNghiDTO: Thông tin đơn xin nghỉ
- BaiLamDTO: Thông tin bài làm
- NguoiDung: Thông tin người dùng 