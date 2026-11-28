
using System;

namespace QuanLyCuaHangThietBiCongNghe.DTO
{
    public class TaiKhoanDTO
    {
        // Giá trị hợp lệ của cột VaiTro (CK_TaiKhoan_VaiTro)
        public const string VaiTroQuanLy = "Manager";
        public const string VaiTroNhanVien = "Employee";

        public string MaTaiKhoan { get; set; } = string.Empty;

        public string MaNhanVien { get; set; } = string.Empty;

        public string TenDangNhap { get; set; } = string.Empty;

        public string MatKhauHash { get; set; } = string.Empty;

        public string VaiTro { get; set; } = VaiTroNhanVien;

        public bool TrangThai { get; set; } = true;

        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}
