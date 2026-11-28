
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using QuanLyCuaHangThietBiCongNghe.DAL;
using QuanLyCuaHangThietBiCongNghe.DTO;

namespace QuanLyCuaHangThietBiCongNghe.BUS
{
    public class NhanVienBUS
    {
        private readonly NhanVienDAL nhanVienDAL = new NhanVienDAL();

        public static readonly string[] DanhSachGioiTinh = { "Nam", "Nữ", "Khác" };

        // Sinh mã nhân viên tiếp theo
        public string GetNextEmployeeCode()
        {
            return nhanVienDAL.GetNextEmployeeCode();
        }

        // Lấy danh sách nhân viên
        public DataTable GetAll()
        {
            return nhanVienDAL.GetAll();
        }

        // Tìm kiếm nhân viên theo mã, họ tên hoặc số điện thoại
        public DataTable Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return nhanVienDAL.GetAll();

            return nhanVienDAL.Search(keyword.Trim());
        }

        // Lấy nhân viên theo mã
        public NhanVienDTO GetById(string maNhanVien)
        {
            if (string.IsNullOrWhiteSpace(maNhanVien))
                return null;

            return nhanVienDAL.GetById(maNhanVien.Trim());
        }

        // Chuẩn hóa dữ liệu trước khi kiểm tra và lưu
        private void ChuanHoaThongTinNhanVien(NhanVienDTO nhanVien)
        {
            nhanVien.MaNhanVien = (nhanVien.MaNhanVien ?? string.Empty).Trim();
            nhanVien.HoTen = Regex.Replace((nhanVien.HoTen ?? string.Empty).Trim(), @"\s+", " ");
            nhanVien.GioiTinh = (nhanVien.GioiTinh ?? string.Empty).Trim();
            nhanVien.SoDienThoai = (nhanVien.SoDienThoai ?? string.Empty).Trim();
            nhanVien.Email = (nhanVien.Email ?? string.Empty).Trim();
            nhanVien.DiaChi = (nhanVien.DiaChi ?? string.Empty).Trim();
        }

        // Kiểm tra thông tin nhân viên dùng chung cho thêm và cập nhật
        private bool KiemTraThongTinNhanVien(
            NhanVienDTO nhanVien,
            bool laThemMoi,
            out string message)
        {
            message = string.Empty;

            if (nhanVien == null)
            {
                message = "Thông tin nhân viên không hợp lệ.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nhanVien.MaNhanVien)
                || nhanVien.MaNhanVien.Length > 10)
            {
                message = "Mã nhân viên không hợp lệ.";
                return false;
            }

            if (nhanVien.HoTen.Length == 0)
            {
                message = "Vui lòng nhập họ tên nhân viên.";
                return false;
            }

            if (nhanVien.HoTen.Length > 100)
            {
                message = "Họ tên không được vượt quá 100 ký tự.";
                return false;
            }

            if (nhanVien.HoTen.Any(char.IsDigit))
            {
                message = "Họ tên không được chứa chữ số.";
                return false;
            }

            if (nhanVien.NgaySinh.HasValue)
            {
                DateTime ngaySinh = nhanVien.NgaySinh.Value.Date;
                int tuoi = DateTime.Today.Year - ngaySinh.Year;

                if (ngaySinh > DateTime.Today.AddYears(-tuoi))
                    tuoi--;

                if (tuoi < 18)
                {
                    message = "Nhân viên phải đủ 18 tuổi.";
                    return false;
                }

                if (tuoi > 70)
                {
                    message = "Ngày sinh không hợp lệ.";
                    return false;
                }

                if (nhanVien.NgayVaoLam.Date <= ngaySinh)
                {
                    message = "Ngày vào làm phải sau ngày sinh.";
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(nhanVien.GioiTinh)
                && !DanhSachGioiTinh.Contains(nhanVien.GioiTinh))
            {
                message = "Giới tính không hợp lệ.";
                return false;
            }

            if (nhanVien.SoDienThoai.Length == 0)
            {
                message = "Vui lòng nhập số điện thoại.";
                return false;
            }

            if (!Regex.IsMatch(nhanVien.SoDienThoai, @"^0\d{9}$"))
            {
                message = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0.";
                return false;
            }

            if (nhanVien.Email.Length > 0)
            {
                if (nhanVien.Email.Length > 254
                    || !Regex.IsMatch(nhanVien.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    message = "Email không đúng định dạng.";
                    return false;
                }
            }

            if (nhanVien.DiaChi.Length > 255)
            {
                message = "Địa chỉ không được vượt quá 255 ký tự.";
                return false;
            }

            if (nhanVien.NgayVaoLam.Date > DateTime.Today)
            {
                message = "Ngày vào làm không được sau ngày hôm nay.";
                return false;
            }

            string maBoQua = laThemMoi ? null : nhanVien.MaNhanVien;

            if (nhanVienDAL.IsPhoneExists(nhanVien.SoDienThoai, maBoQua))
            {
                message = "Số điện thoại đã được dùng cho nhân viên khác.";
                return false;
            }

            if (nhanVien.Email.Length > 0
                && nhanVienDAL.IsEmailExists(nhanVien.Email, maBoQua))
            {
                message = "Email đã được dùng cho nhân viên khác.";
                return false;
            }

            return true;
        }

        // Thêm nhân viên
        public bool Insert(NhanVienDTO nhanVien, out string message)
        {
            message = string.Empty;

            if (!PhienDangNhap.LaQuanLy)
            {
                message = "Chỉ Người quản lý được thêm nhân viên.";
                return false;
            }

            try
            {
                ChuanHoaThongTinNhanVien(nhanVien);

                // Lấy lại mã mới ngay lúc lưu để tránh trùng mã
                nhanVien.MaNhanVien = nhanVienDAL.GetNextEmployeeCode();

                if (!KiemTraThongTinNhanVien(nhanVien, true, out message))
                    return false;

                if (nhanVienDAL.Insert(nhanVien))
                {
                    message = "Thêm nhân viên " + nhanVien.MaNhanVien + " thành công.";
                    return true;
                }

                message = "Không thể thêm nhân viên.";
                return false;
            }
            catch (Exception ex)
            {
                message = "Lỗi khi thêm nhân viên: " + ex.Message;
                return false;
            }
        }

        // Cập nhật nhân viên.
        // Nếu đổi trạng thái trên ComboBox thì xử lý ngừng hoạt động / làm việc lại.
        public bool Update(NhanVienDTO nhanVien, out string message)
        {
            message = string.Empty;

            if (!PhienDangNhap.LaQuanLy)
            {
                message = "Chỉ Người quản lý được cập nhật nhân viên.";
                return false;
            }

            try
            {
                ChuanHoaThongTinNhanVien(nhanVien);

                if (!KiemTraThongTinNhanVien(nhanVien, false, out message))
                    return false;

                NhanVienDTO hienTai = nhanVienDAL.GetById(nhanVien.MaNhanVien);

                if (hienTai == null)
                {
                    message = "Không tìm thấy nhân viên cần cập nhật.";
                    return false;
                }

                if (!nhanVien.TrangThai && IsCurrentUser(nhanVien.MaNhanVien))
                {
                    message = "Không thể ngừng hoạt động chính tài khoản đang đăng nhập.";
                    return false;
                }

                if (!nhanVienDAL.Update(nhanVien))
                {
                    message = "Không thể cập nhật nhân viên.";
                    return false;
                }

                if (hienTai.TrangThai && !nhanVien.TrangThai)
                    nhanVienDAL.StopWorking(nhanVien.MaNhanVien);
                else if (!hienTai.TrangThai && nhanVien.TrangThai)
                    nhanVienDAL.Reactivate(nhanVien.MaNhanVien);

                message = "Cập nhật nhân viên thành công.";
                return true;
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật nhân viên: " + ex.Message;
                return false;
            }
        }

        // Ngừng hoạt động nhân viên (không xóa), khóa luôn tài khoản
        public bool StopWorking(string maNhanVien, out string message)
        {
            message = string.Empty;

            if (!PhienDangNhap.LaQuanLy)
            {
                message = "Chỉ Người quản lý được thay đổi trạng thái nhân viên.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(maNhanVien))
            {
                message = "Vui lòng chọn nhân viên cần ngừng hoạt động.";
                return false;
            }

            maNhanVien = maNhanVien.Trim();

            if (IsCurrentUser(maNhanVien))
            {
                message = "Không thể ngừng hoạt động chính tài khoản đang đăng nhập.";
                return false;
            }

            try
            {
                if (nhanVienDAL.StopWorking(maNhanVien))
                {
                    message = "Đã chuyển nhân viên sang trạng thái ngừng hoạt động.";
                    return true;
                }

                message = "Không tìm thấy nhân viên hoặc nhân viên đã ngừng hoạt động.";
                return false;
            }
            catch (Exception ex)
            {
                message = "Lỗi khi ngừng hoạt động: " + ex.Message;
                return false;
            }
        }

        private static bool IsCurrentUser(string maNhanVien)
        {
            return PhienDangNhap.TaiKhoanHienTai != null
                && PhienDangNhap.TaiKhoanHienTai.MaNhanVien == maNhanVien;
        }
    }
}
