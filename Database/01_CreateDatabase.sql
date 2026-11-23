
/*
    ============================================================
    DU AN: QUAN LY CUA HANG THIET BI CONG NGHE
    DATABASE: QuanLyCuaHangThietBiCongNghe
    DBMS: Microsoft SQL Server
    SCRIPT: 01_CreateDatabase.sql
    ============================================================
*/

USE master;
GO

-- Kiem tra Database da ton tai hay chua
IF DB_ID(N'QuanLyCuaHangThietBiCongNghe') IS NULL
BEGIN
    CREATE DATABASE QuanLyCuaHangThietBiCongNghe;

    PRINT N'Tao Database thanh cong.';
END
ELSE
BEGIN
    PRINT N'Database da ton tai, khong tao lai.';
END
GO

-- Kiem tra ket qua
SELECT
    name AS DatabaseName,
    state_desc AS DatabaseState,
    create_date AS CreatedDate
FROM sys.databases
WHERE name = N'QuanLyCuaHangThietBiCongNghe';
GO

