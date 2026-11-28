
using System;

namespace QuanLyCuaHangThietBiCongNghe.DTO
{
    public class NhanVienDTO
    {
        public string MaNhanVien { get; set; } = string.Empty;

        public string HoTen { get; set; } = string.Empty;

        // NULL trong database
        public DateTime? NgaySinh { get; set; }

        public string GioiTinh { get; set; } = string.Empty;

        public string SoDienThoai { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string DiaChi { get; set; } = string.Empty;

        public DateTime NgayVaoLam { get; set; } = DateTime.Today;

        // true: đang làm việc, false: ngừng hoạt động
        public bool TrangThai { get; set; } = true;
    }
}
