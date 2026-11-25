
namespace QuanLyCuaHangThietBiCongNghe.DTO
{
    public class SanPhamDTO
    {
        public string MaSanPham { get; set; } = string.Empty;

        public string TenSanPham { get; set; } = string.Empty;

        public string LoaiSanPham { get; set; } = string.Empty;

        public string ThuongHieu { get; set; } = string.Empty;

        public string DonViTinh { get; set; } = string.Empty;

        public decimal GiaBan { get; set; }

        public int SoLuongTon { get; set; }

        public string MoTa { get; set; } = string.Empty;

        public bool TrangThai { get; set; } = true;
    }
}
