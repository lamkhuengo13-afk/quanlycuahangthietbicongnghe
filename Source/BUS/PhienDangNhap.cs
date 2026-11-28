
using QuanLyCuaHangThietBiCongNghe.DTO;

namespace QuanLyCuaHangThietBiCongNghe.BUS
{
    // Lưu tài khoản đang đăng nhập.
    // Form đăng nhập gán TaiKhoanHienTai sau khi xác thực thành công,
    // các BUS dùng LaQuanLy để kiểm tra quyền.
    public static class PhienDangNhap
    {
        public static TaiKhoanDTO TaiKhoanHienTai { get; set; }

        public static bool DaDangNhap => TaiKhoanHienTai != null;

        public static bool LaQuanLy =>
            TaiKhoanHienTai != null
            && TaiKhoanHienTai.VaiTro == TaiKhoanDTO.VaiTroQuanLy;

        public static void DangXuat()
        {
            TaiKhoanHienTai = null;
        }
    }
}
