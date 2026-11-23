
/*
===============================================================================
DU AN: QUAN LY CUA HANG THIET BI CONG NGHE
DATABASE: QuanLyCuaHangThietBiCongNghe
DBMS: Microsoft SQL Server
SCRIPT: 02_CreateTables.sql

CHUC NANG:
    Tao cau truc 9 bang du lieu cua he thong.

CAC BANG:
    1. SanPham
    2. KhachHang
    3. NhaCungCap
    4. NhanVien
    5. TaiKhoan
    6. DonHang
    7. ChiTietDonHang
    8. HoaDonNhapHang
    9. ChiTietHoaDonNhap

LUU Y:
    - Khoa chinh duoc khai bao trong script nay.
    - Khoa ngoai, UNIQUE va CHECK se duoc khai bao
      trong script 03_CreateConstraints.sql.
===============================================================================
*/

USE [QuanLyCuaHangThietBiCongNghe];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

BEGIN TRY
    BEGIN TRANSACTION;

    ---------------------------------------------------------------------------
    -- 1. BANG SAN PHAM
    ---------------------------------------------------------------------------
    IF OBJECT_ID(N'dbo.SanPham', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.SanPham
        (
            MaSanPham       VARCHAR(10)      NOT NULL,
            TenSanPham      NVARCHAR(150)    NOT NULL,
            LoaiSanPham     NVARCHAR(100)    NOT NULL,
            ThuongHieu      NVARCHAR(100)    NOT NULL,
            DonViTinh       NVARCHAR(30)     NOT NULL,
            GiaBan          DECIMAL(18,2)    NOT NULL,
            SoLuongTon      INT              NOT NULL
                CONSTRAINT DF_SanPham_SoLuongTon DEFAULT (0),
            MoTa            NVARCHAR(500)    NULL,
            TrangThai       BIT              NOT NULL
                CONSTRAINT DF_SanPham_TrangThai DEFAULT (1),

            CONSTRAINT PK_SanPham
                PRIMARY KEY (MaSanPham)
        );

        PRINT N'Da tao bang SanPham.';
    END
    ELSE
        PRINT N'Bang SanPham da ton tai. Bo qua.';


    ---------------------------------------------------------------------------
    -- 2. BANG KHACH HANG
    ---------------------------------------------------------------------------
    IF OBJECT_ID(N'dbo.KhachHang', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.KhachHang
        (
            MaKhachHang    VARCHAR(10)      NOT NULL,
            HoTen          NVARCHAR(100)    NOT NULL,
            SoDienThoai    VARCHAR(15)      NOT NULL,
            Email          NVARCHAR(254)    NULL,
            DiaChi         NVARCHAR(255)    NULL,

            CONSTRAINT PK_KhachHang
                PRIMARY KEY (MaKhachHang)
        );

        PRINT N'Da tao bang KhachHang.';
    END
    ELSE
        PRINT N'Bang KhachHang da ton tai. Bo qua.';


    ---------------------------------------------------------------------------
    -- 3. BANG NHA CUNG CAP
    ---------------------------------------------------------------------------
    IF OBJECT_ID(N'dbo.NhaCungCap', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.NhaCungCap
        (
            MaNhaCungCap   VARCHAR(10)      NOT NULL,
            TenNhaCungCap  NVARCHAR(150)    NOT NULL,
            SoDienThoai    VARCHAR(15)      NOT NULL,
            Email          NVARCHAR(254)    NULL,
            DiaChi         NVARCHAR(255)    NULL,
            TrangThai      BIT              NOT NULL
                CONSTRAINT DF_NhaCungCap_TrangThai DEFAULT (1),

            CONSTRAINT PK_NhaCungCap
                PRIMARY KEY (MaNhaCungCap)
        );

        PRINT N'Da tao bang NhaCungCap.';
    END
    ELSE
        PRINT N'Bang NhaCungCap da ton tai. Bo qua.';


    ---------------------------------------------------------------------------
    -- 4. BANG NHAN VIEN
    ---------------------------------------------------------------------------
    IF OBJECT_ID(N'dbo.NhanVien', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.NhanVien
        (
            MaNhanVien    VARCHAR(10)      NOT NULL,
            HoTen          NVARCHAR(100)    NOT NULL,
            NgaySinh       DATE             NULL,
            GioiTinh       NVARCHAR(10)     NULL,
            SoDienThoai    VARCHAR(15)      NOT NULL,
            Email          NVARCHAR(254)    NULL,
            DiaChi         NVARCHAR(255)    NULL,
            NgayVaoLam     DATE             NOT NULL,
            TrangThai      BIT              NOT NULL
                CONSTRAINT DF_NhanVien_TrangThai DEFAULT (1),

            CONSTRAINT PK_NhanVien
                PRIMARY KEY (MaNhanVien)
        );

        PRINT N'Da tao bang NhanVien.';
    END
    ELSE
        PRINT N'Bang NhanVien da ton tai. Bo qua.';


    ---------------------------------------------------------------------------
    -- 5. BANG TAI KHOAN
    ---------------------------------------------------------------------------
    IF OBJECT_ID(N'dbo.TaiKhoan', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.TaiKhoan
        (
            MaTaiKhoan     VARCHAR(10)      NOT NULL,
            MaNhanVien     VARCHAR(10)      NOT NULL,
            TenDangNhap    VARCHAR(50)      NOT NULL,
            MatKhauHash    NVARCHAR(255)    NOT NULL,
            VaiTro         VARCHAR(20)      NOT NULL,
            TrangThai      BIT              NOT NULL
                CONSTRAINT DF_TaiKhoan_TrangThai DEFAULT (1),
            NgayTao        DATETIME2        NOT NULL
                CONSTRAINT DF_TaiKhoan_NgayTao DEFAULT (SYSDATETIME()),

            CONSTRAINT PK_TaiKhoan
                PRIMARY KEY (MaTaiKhoan)
        );

        PRINT N'Da tao bang TaiKhoan.';
    END
    ELSE
        PRINT N'Bang TaiKhoan da ton tai. Bo qua.';


    ---------------------------------------------------------------------------
    -- 6. BANG DON HANG
    ---------------------------------------------------------------------------
    IF OBJECT_ID(N'dbo.DonHang', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.DonHang
        (
            MaDonHang      VARCHAR(10)      NOT NULL,
            MaKhachHang    VARCHAR(10)      NULL,
            MaNhanVien     VARCHAR(10)      NOT NULL,
            NgayLap        DATETIME2        NOT NULL
                CONSTRAINT DF_DonHang_NgayLap DEFAULT (SYSDATETIME()),
            TongTien       DECIMAL(18,2)    NOT NULL
                CONSTRAINT DF_DonHang_TongTien DEFAULT (0),
            TrangThai      VARCHAR(20)      NOT NULL,

            CONSTRAINT PK_DonHang
                PRIMARY KEY (MaDonHang)
        );

        PRINT N'Da tao bang DonHang.';
    END
    ELSE
        PRINT N'Bang DonHang da ton tai. Bo qua.';


    ---------------------------------------------------------------------------
    -- 7. BANG CHI TIET DON HANG
    ---------------------------------------------------------------------------
    IF OBJECT_ID(N'dbo.ChiTietDonHang', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.ChiTietDonHang
        (
            MaDonHang      VARCHAR(10)      NOT NULL,
            MaSanPham      VARCHAR(10)      NOT NULL,
            SoLuong        INT              NOT NULL,
            DonGiaBan      DECIMAL(18,2)    NOT NULL,
            ThanhTien      DECIMAL(18,2)    NOT NULL,

            CONSTRAINT PK_ChiTietDonHang
                PRIMARY KEY (MaDonHang, MaSanPham)
        );

        PRINT N'Da tao bang ChiTietDonHang.';
    END
    ELSE
        PRINT N'Bang ChiTietDonHang da ton tai. Bo qua.';


    ---------------------------------------------------------------------------
    -- 8. BANG HOA DON NHAP HANG
    ---------------------------------------------------------------------------
    IF OBJECT_ID(N'dbo.HoaDonNhapHang', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.HoaDonNhapHang
        (
            MaHoaDonNhap   VARCHAR(10)      NOT NULL,
            MaNhaCungCap   VARCHAR(10)      NOT NULL,
            MaNhanVien     VARCHAR(10)      NOT NULL,
            NgayNhap       DATETIME2        NOT NULL
                CONSTRAINT DF_HoaDonNhapHang_NgayNhap DEFAULT (SYSDATETIME()),
            TongTien       DECIMAL(18,2)    NOT NULL
                CONSTRAINT DF_HoaDonNhapHang_TongTien DEFAULT (0),
            TrangThai      VARCHAR(20)      NOT NULL,

            CONSTRAINT PK_HoaDonNhapHang
                PRIMARY KEY (MaHoaDonNhap)
        );

        PRINT N'Da tao bang HoaDonNhapHang.';
    END
    ELSE
        PRINT N'Bang HoaDonNhapHang da ton tai. Bo qua.';


    ---------------------------------------------------------------------------
    -- 9. BANG CHI TIET HOA DON NHAP
    ---------------------------------------------------------------------------
    IF OBJECT_ID(N'dbo.ChiTietHoaDonNhap', N'U') IS NULL
    BEGIN
        CREATE TABLE dbo.ChiTietHoaDonNhap
        (
            MaHoaDonNhap   VARCHAR(10)      NOT NULL,
            MaSanPham      VARCHAR(10)      NOT NULL,
            SoLuong        INT              NOT NULL,
            GiaNhap        DECIMAL(18,2)    NOT NULL,
            ThanhTien      DECIMAL(18,2)    NOT NULL,

            CONSTRAINT PK_ChiTietHoaDonNhap
                PRIMARY KEY (MaHoaDonNhap, MaSanPham)
        );

        PRINT N'Da tao bang ChiTietHoaDonNhap.';
    END
    ELSE
        PRINT N'Bang ChiTietHoaDonNhap da ton tai. Bo qua.';


    ---------------------------------------------------------------------------
    -- HOAN TAT
    ---------------------------------------------------------------------------
    COMMIT TRANSACTION;

    PRINT N'================================================';
    PRINT N'TAO CAU TRUC 9 BANG THANH CONG.';
    PRINT N'Database: QuanLyCuaHangThietBiCongNghe';
    PRINT N'================================================';

END TRY
BEGIN CATCH

    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;

    PRINT N'CO LOI XAY RA KHI TAO CAC BANG.';
    PRINT ERROR_MESSAGE();

    THROW;

END CATCH;
GO


---------------------------------------------------------------------------
-- KIEM TRA DANH SACH CAC BANG DA TAO
---------------------------------------------------------------------------
SELECT
    TABLE_SCHEMA AS SchemaName,
    TABLE_NAME AS TableName
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
    AND TABLE_SCHEMA = 'dbo'
ORDER BY TABLE_NAME;
GO


---------------------------------------------------------------------------
-- KIEM TRA SO LUONG BANG
---------------------------------------------------------------------------
SELECT
    COUNT(*) AS TotalTables
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
    AND TABLE_SCHEMA = 'dbo';
GO

