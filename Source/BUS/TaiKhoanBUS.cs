
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using QuanLyCuaHangThietBiCongNghe.DAL;
using QuanLyCuaHangThietBiCongNghe.DTO;

namespace QuanLyCuaHangThietBiCongNghe.BUS
{
    public class TaiKhoanBUS
    {
        private readonly TaiKhoanDAL taiKhoanDAL = new TaiKhoanDAL();
        private readonly NhanVienDAL nhanVienDAL = new NhanVienDAL();

        public const int DoDaiMatKhauToiThieu = 6;

        // Danh sách nhân viên đang làm việc, chưa có tài khoản
        public DataTable GetEmployeesWithoutAccount()
        {
            return nhanVienDAL.GetEmployeesWithoutAccount();
        }

        // Đăng kí tài khoản cho nhân viên (mục 3.2.2 - Bước 5 đến Bước 9)
        public bool Register(
            string maNhanVien,
            string tenDangNhap,
            string matKhau,
            string xacNhanMatKhau,
            out string message)
        {
            message = string.Empty;

            // Chỉ Người quản lý được tạo tài khoản
            if (!PhienDangNhap.LaQuanLy)
            {
                message = "Chỉ Người quản lý mới được tạo tài khoản.";
                return false;
            }

            // Bước 5: kiểm tra dữ liệu bắt buộc và mật khẩu
            if (string.IsNullOrWhiteSpace(maNhanVien))
            {
                message = "Vui lòng chọn nhân viên cần cấp tài khoản.";
                return false;
            }

            maNhanVien = maNhanVien.Trim();
            tenDangNhap = (tenDangNhap ?? string.Empty).Trim();
            matKhau ??= string.Empty;
            xacNhanMatKhau ??= string.Empty;

            if (tenDangNhap.Length == 0)
            {
                message = "Vui lòng nhập tên đăng nhập.";
                return false;
            }

            if (tenDangNhap.Length < 4 || tenDangNhap.Length > 50
                || !Regex.IsMatch(tenDangNhap, @"^[A-Za-z0-9_.]+$"))
            {
                message = "Tên đăng nhập dài 4 - 50 ký tự, chỉ gồm chữ không dấu, số, dấu chấm hoặc gạch dưới.";
                return false;
            }

            if (matKhau.Length == 0)
            {
                message = "Vui lòng nhập mật khẩu.";
                return false;
            }

            if (matKhau.Length < DoDaiMatKhauToiThieu
                || !matKhau.Any(char.IsLetter)
                || !matKhau.Any(char.IsDigit))
            {
                message = "Mật khẩu phải có ít nhất " + DoDaiMatKhauToiThieu
                    + " ký tự, gồm cả chữ và số.";
                return false;
            }

            if (matKhau.Contains(' '))
            {
                message = "Mật khẩu không được chứa khoảng trắng.";
                return false;
            }

            if (matKhau != xacNhanMatKhau)
            {
                message = "Mật khẩu xác nhận không khớp.";
                return false;
            }

            try
            {
                // Bước 6: kiểm tra nhân viên và tên đăng nhập
                NhanVienDTO nhanVien = nhanVienDAL.GetById(maNhanVien);

                if (nhanVien == null)
                {
                    message = "Nhân viên không tồn tại.";
                    return false;
                }

                if (!nhanVien.TrangThai)
                {
                    message = "Nhân viên đã ngừng hoạt động, không thể cấp tài khoản.";
                    return false;
                }

                if (taiKhoanDAL.HasAccount(maNhanVien))
                {
                    message = "Nhân viên này đã có tài khoản.";
                    return false;
                }

                if (taiKhoanDAL.IsUsernameExists(tenDangNhap))
                {
                    message = "Tên đăng nhập đã tồn tại, vui lòng chọn tên khác.";
                    return false;
                }

                // Bước 7 - 8: băm mật khẩu có Salt,
                // vai trò mặc định Employee, trạng thái hoạt động
                TaiKhoanDTO taiKhoan = new TaiKhoanDTO
                {
                    MaNhanVien = maNhanVien,
                    TenDangNhap = tenDangNhap,
                    MatKhauHash = MatKhauHelper.HashPassword(matKhau),
                    VaiTro = TaiKhoanDTO.VaiTroNhanVien,
                    TrangThai = true,
                    NgayTao = DateTime.Now
                };

                if (taiKhoanDAL.Insert(taiKhoan))
                {
                    // Bước 9
                    message = "Tạo tài khoản \"" + tenDangNhap + "\" cho nhân viên "
                        + nhanVien.HoTen + " thành công.";
                    return true;
                }

                message = "Không thể tạo tài khoản.";
                return false;
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // Vi phạm UNIQUE: có người vừa tạo cùng lúc
                message = "Tên đăng nhập đã tồn tại hoặc nhân viên đã có tài khoản.";
                return false;
            }
            catch (Exception ex)
            {
                message = "Lỗi khi tạo tài khoản: " + ex.Message;
                return false;
            }
        }
    }
}
