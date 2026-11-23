
/*
===============================================================================
DU AN: QUAN LY CUA HANG THIET BI CONG NGHE
DATABASE: QuanLyCuaHangThietBiCongNghe
DBMS: Microsoft SQL Server
SCRIPT: 03_CreateConstraints.sql

CHUC NANG:
    1. Tao 9 khoa ngoai (FOREIGN KEY).
    2. Tao 2 rang buoc UNIQUE.
    3. Tao cac rang buoc CHECK.
    4. Kiem tra tinh toan ven cua du lieu.

NGUYEN TAC:
    - Khong su dung ON DELETE CASCADE.
    - Bao ve du lieu lich su giao dich.
    - Kiem tra du lieu hien co khi them rang buoc.
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
    -- PHAN 1. TAO 9 KHOA NGOAI (FOREIGN KEY)
    ---------------------------------------------------------------------------

    -- 1. TaiKhoan -> NhanVien
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.foreign_keys
        WHERE name = N'FK_TaiKhoan_NhanVien'
    )
    BEGIN
        ALTER TABLE dbo.TaiKhoan
        WITH CHECK ADD CONSTRAINT FK_TaiKhoan_NhanVien
        FOREIGN KEY (MaNhanVien)
        REFERENCES dbo.NhanVien (MaNhanVien);

        PRINT N'Da tao FK_TaiKhoan_NhanVien.';
    END
    ELSE
        PRINT N'FK_TaiKhoan_NhanVien da ton tai.';


    -- 2. DonHang -> KhachHang
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.foreign_keys
        WHERE name = N'FK_DonHang_KhachHang'
    )
    BEGIN
        ALTER TABLE dbo.DonHang
        WITH CHECK ADD CONSTRAINT FK_DonHang_KhachHang
        FOREIGN KEY (MaKhachHang)
        REFERENCES dbo.KhachHang (MaKhachHang);

        PRINT N'Da tao FK_DonHang_KhachHang.';
    END
    ELSE
        PRINT N'FK_DonHang_KhachHang da ton tai.';


    -- 3. DonHang -> NhanVien
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.foreign_keys
        WHERE name = N'FK_DonHang_NhanVien'
    )
    BEGIN
        ALTER TABLE dbo.DonHang
        WITH CHECK ADD CONSTRAINT FK_DonHang_NhanVien
        FOREIGN KEY (MaNhanVien)
        REFERENCES dbo.NhanVien (MaNhanVien);

        PRINT N'Da tao FK_DonHang_NhanVien.';
    END
    ELSE
        PRINT N'FK_DonHang_NhanVien da ton tai.';


    -- 4. ChiTietDonHang -> DonHang
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.foreign_keys
        WHERE name = N'FK_ChiTietDonHang_DonHang'
    )
    BEGIN
        ALTER TABLE dbo.ChiTietDonHang
        WITH CHECK ADD CONSTRAINT FK_ChiTietDonHang_DonHang
        FOREIGN KEY (MaDonHang)
        REFERENCES dbo.DonHang (MaDonHang);

        PRINT N'Da tao FK_ChiTietDonHang_DonHang.';
    END
    ELSE
        PRINT N'FK_ChiTietDonHang_DonHang da ton tai.';


    -- 5. ChiTietDonHang -> SanPham
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.foreign_keys
        WHERE name = N'FK_ChiTietDonHang_SanPham'
    )
    BEGIN
        ALTER TABLE dbo.ChiTietDonHang
        WITH CHECK ADD CONSTRAINT FK_ChiTietDonHang_SanPham
        FOREIGN KEY (MaSanPham)
        REFERENCES dbo.SanPham (MaSanPham);

        PRINT N'Da tao FK_ChiTietDonHang_SanPham.';
    END
    ELSE
        PRINT N'FK_ChiTietDonHang_SanPham da ton tai.';


    -- 6. HoaDonNhapHang -> NhaCungCap
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.foreign_keys
        WHERE name = N'FK_HoaDonNhapHang_NhaCungCap'
    )
    BEGIN
        ALTER TABLE dbo.HoaDonNhapHang
        WITH CHECK ADD CONSTRAINT FK_HoaDonNhapHang_NhaCungCap
        FOREIGN KEY (MaNhaCungCap)
        REFERENCES dbo.NhaCungCap (MaNhaCungCap);

        PRINT N'Da tao FK_HoaDonNhapHang_NhaCungCap.';
    END
    ELSE
        PRINT N'FK_HoaDonNhapHang_NhaCungCap da ton tai.';


    -- 7. HoaDonNhapHang -> NhanVien
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.foreign_keys
        WHERE name = N'FK_HoaDonNhapHang_NhanVien'
    )
    BEGIN
        ALTER TABLE dbo.HoaDonNhapHang
        WITH CHECK ADD CONSTRAINT FK_HoaDonNhapHang_NhanVien
        FOREIGN KEY (MaNhanVien)
        REFERENCES dbo.NhanVien (MaNhanVien);

        PRINT N'Da tao FK_HoaDonNhapHang_NhanVien.';
    END
    ELSE
        PRINT N'FK_HoaDonNhapHang_NhanVien da ton tai.';


    -- 8. ChiTietHoaDonNhap -> HoaDonNhapHang
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.foreign_keys
        WHERE name = N'FK_ChiTietHoaDonNhap_HoaDonNhapHang'
    )
    BEGIN
        ALTER TABLE dbo.ChiTietHoaDonNhap
        WITH CHECK ADD CONSTRAINT FK_ChiTietHoaDonNhap_HoaDonNhapHang
        FOREIGN KEY (MaHoaDonNhap)
        REFERENCES dbo.HoaDonNhapHang (MaHoaDonNhap);

        PRINT N'Da tao FK_ChiTietHoaDonNhap_HoaDonNhapHang.';
    END
    ELSE
        PRINT N'FK_ChiTietHoaDonNhap_HoaDonNhapHang da ton tai.';


    -- 9. ChiTietHoaDonNhap -> SanPham
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.foreign_keys
        WHERE name = N'FK_ChiTietHoaDonNhap_SanPham'
    )
    BEGIN
        ALTER TABLE dbo.ChiTietHoaDonNhap
        WITH CHECK ADD CONSTRAINT FK_ChiTietHoaDonNhap_SanPham
        FOREIGN KEY (MaSanPham)
        REFERENCES dbo.SanPham (MaSanPham);

        PRINT N'Da tao FK_ChiTietHoaDonNhap_SanPham.';
    END
    ELSE
        PRINT N'FK_ChiTietHoaDonNhap_SanPham da ton tai.';


    ---------------------------------------------------------------------------
    -- PHAN 2. TAO 2 RANG BUOC UNIQUE
    ---------------------------------------------------------------------------

    -- Moi nhan vien chi co toi da mot tai khoan
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.key_constraints
        WHERE name = N'UQ_TaiKhoan_MaNhanVien'
    )
    BEGIN
        ALTER TABLE dbo.TaiKhoan
        ADD CONSTRAINT UQ_TaiKhoan_MaNhanVien
        UNIQUE (MaNhanVien);

        PRINT N'Da tao UQ_TaiKhoan_MaNhanVien.';
    END
    ELSE
        PRINT N'UQ_TaiKhoan_MaNhanVien da ton tai.';


    -- Ten dang nhap khong duoc trung nhau
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.key_constraints
        WHERE name = N'UQ_TaiKhoan_TenDangNhap'
    )
    BEGIN
        ALTER TABLE dbo.TaiKhoan
        ADD CONSTRAINT UQ_TaiKhoan_TenDangNhap
        UNIQUE (TenDangNhap);

        PRINT N'Da tao UQ_TaiKhoan_TenDangNhap.';
    END
    ELSE
        PRINT N'UQ_TaiKhoan_TenDangNhap da ton tai.';


    ---------------------------------------------------------------------------
    -- PHAN 3. TAO CAC RANG BUOC CHECK
    ---------------------------------------------------------------------------

    -- SAN PHAM
    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_SanPham_GiaBan'
    )
    BEGIN
        ALTER TABLE dbo.SanPham
        WITH CHECK ADD CONSTRAINT CK_SanPham_GiaBan
        CHECK (GiaBan >= 0);
    END

    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_SanPham_SoLuongTon'
    )
    BEGIN
        ALTER TABLE dbo.SanPham
        WITH CHECK ADD CONSTRAINT CK_SanPham_SoLuongTon
        CHECK (SoLuongTon >= 0);
    END


    -- TAI KHOAN
    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_TaiKhoan_VaiTro'
    )
    BEGIN
        ALTER TABLE dbo.TaiKhoan
        WITH CHECK ADD CONSTRAINT CK_TaiKhoan_VaiTro
        CHECK (VaiTro IN ('Manager', 'Employee'));
    END


    -- DON HANG
    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_DonHang_TongTien'
    )
    BEGIN
        ALTER TABLE dbo.DonHang
        WITH CHECK ADD CONSTRAINT CK_DonHang_TongTien
        CHECK (TongTien >= 0);
    END

    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_DonHang_TrangThai'
    )
    BEGIN
        ALTER TABLE dbo.DonHang
        WITH CHECK ADD CONSTRAINT CK_DonHang_TrangThai
        CHECK (TrangThai IN ('Completed', 'Cancelled'));
    END


    -- CHI TIET DON HANG
    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_ChiTietDonHang_SoLuong'
    )
    BEGIN
        ALTER TABLE dbo.ChiTietDonHang
        WITH CHECK ADD CONSTRAINT CK_ChiTietDonHang_SoLuong
        CHECK (SoLuong > 0);
    END

    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_ChiTietDonHang_DonGiaBan'
    )
    BEGIN
        ALTER TABLE dbo.ChiTietDonHang
        WITH CHECK ADD CONSTRAINT CK_ChiTietDonHang_DonGiaBan
        CHECK (DonGiaBan >= 0);
    END

    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_ChiTietDonHang_ThanhTien'
    )
    BEGIN
        ALTER TABLE dbo.ChiTietDonHang
        WITH CHECK ADD CONSTRAINT CK_ChiTietDonHang_ThanhTien
        CHECK
        (
            ThanhTien >= 0
            AND ThanhTien = SoLuong * DonGiaBan
        );
    END


    -- HOA DON NHAP HANG
    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_HoaDonNhapHang_TongTien'
    )
    BEGIN
        ALTER TABLE dbo.HoaDonNhapHang
        WITH CHECK ADD CONSTRAINT CK_HoaDonNhapHang_TongTien
        CHECK (TongTien >= 0);
    END

    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_HoaDonNhapHang_TrangThai'
    )
    BEGIN
        ALTER TABLE dbo.HoaDonNhapHang
        WITH CHECK ADD CONSTRAINT CK_HoaDonNhapHang_TrangThai
        CHECK (TrangThai IN ('Completed', 'Cancelled'));
    END


    -- CHI TIET HOA DON NHAP
    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_ChiTietHoaDonNhap_SoLuong'
    )
    BEGIN
        ALTER TABLE dbo.ChiTietHoaDonNhap
        WITH CHECK ADD CONSTRAINT CK_ChiTietHoaDonNhap_SoLuong
        CHECK (SoLuong > 0);
    END

    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_ChiTietHoaDonNhap_GiaNhap'
    )
    BEGIN
        ALTER TABLE dbo.ChiTietHoaDonNhap
        WITH CHECK ADD CONSTRAINT CK_ChiTietHoaDonNhap_GiaNhap
        CHECK (GiaNhap >= 0);
    END

    IF NOT EXISTS
    (
        SELECT 1 FROM sys.check_constraints
        WHERE name = N'CK_ChiTietHoaDonNhap_ThanhTien'
    )
    BEGIN
        ALTER TABLE dbo.ChiTietHoaDonNhap
        WITH CHECK ADD CONSTRAINT CK_ChiTietHoaDonNhap_ThanhTien
        CHECK
        (
            ThanhTien >= 0
            AND ThanhTien = SoLuong * GiaNhap
        );
    END


    ---------------------------------------------------------------------------
    -- HOAN TAT
    ---------------------------------------------------------------------------
    COMMIT TRANSACTION;

    PRINT N'================================================';
    PRINT N'TAO CAC RANG BUOC THANH CONG.';
    PRINT N'9 FOREIGN KEY - 2 UNIQUE - 14 CHECK.';
    PRINT N'================================================';

END TRY
BEGIN CATCH

    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;

    PRINT N'CO LOI KHI TAO RANG BUOC.';
    PRINT ERROR_MESSAGE();

    THROW;

END CATCH;
GO


---------------------------------------------------------------------------
-- KIEM TRA 1: DANH SACH KHOA NGOAI
---------------------------------------------------------------------------
SELECT
    fk.name AS ForeignKeyName,
    OBJECT_NAME(fk.parent_object_id) AS TableName,
    OBJECT_NAME(fk.referenced_object_id) AS ReferencedTable,
    fk.is_disabled AS IsDisabled,
    fk.is_not_trusted AS IsNotTrusted
FROM sys.foreign_keys AS fk
WHERE fk.schema_id = SCHEMA_ID('dbo')
ORDER BY TableName, ForeignKeyName;
GO


---------------------------------------------------------------------------
-- KIEM TRA 2: DANH SACH UNIQUE CONSTRAINT
---------------------------------------------------------------------------
SELECT
    kc.name AS UniqueConstraintName,
    OBJECT_NAME(kc.parent_object_id) AS TableName
FROM sys.key_constraints AS kc
WHERE kc.type = 'UQ'
    AND kc.schema_id = SCHEMA_ID('dbo')
ORDER BY TableName, UniqueConstraintName;
GO


---------------------------------------------------------------------------
-- KIEM TRA 3: DANH SACH CHECK CONSTRAINT
---------------------------------------------------------------------------
SELECT
    cc.name AS CheckConstraintName,
    OBJECT_NAME(cc.parent_object_id) AS TableName,
    cc.definition AS ConstraintDefinition,
    cc.is_disabled AS IsDisabled,
    cc.is_not_trusted AS IsNotTrusted
FROM sys.check_constraints AS cc
WHERE cc.schema_id = SCHEMA_ID('dbo')
ORDER BY TableName, CheckConstraintName;
GO


---------------------------------------------------------------------------
-- KIEM TRA 4: TONG HOP SO LUONG RANG BUOC
---------------------------------------------------------------------------
SELECT
    (SELECT COUNT(*)
     FROM sys.foreign_keys
     WHERE schema_id = SCHEMA_ID('dbo')) AS TotalForeignKeys,

    (SELECT COUNT(*)
     FROM sys.key_constraints
     WHERE type = 'UQ'
       AND schema_id = SCHEMA_ID('dbo')) AS TotalUniqueConstraints,

    (SELECT COUNT(*)
     FROM sys.check_constraints
     WHERE schema_id = SCHEMA_ID('dbo')) AS TotalCheckConstraints;
GO

