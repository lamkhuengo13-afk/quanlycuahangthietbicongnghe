
using System;
using System.Data;
using QuanLyCuaHangThietBiCongNghe.DAL;
using QuanLyCuaHangThietBiCongNghe.DTO;

namespace QuanLyCuaHangThietBiCongNghe.BUS
{
    public class SanPhamBUS
    {
        private readonly SanPhamDAL sanPhamDAL = new SanPhamDAL();

        // Sinh mã sản phẩm tiếp theo
        public string GetNextProductCode()
        {
            return sanPhamDAL.GetNextProductCode();
        }

        // Lấy danh sách sản phẩm
        public DataTable GetAll()
        {
            return sanPhamDAL.GetAll();
        }

        // Tìm sản phẩm theo mã
        public SanPhamDTO GetById(string maSanPham)
        {
            if (string.IsNullOrWhiteSpace(maSanPham))
                return null;

            return sanPhamDAL.GetById(maSanPham.Trim());
        }

        // Kiểm tra thông tin sản phẩm dùng chung cho thêm và cập nhật
        private bool KiemTraThongTinSanPham(
            SanPhamDTO sanPham,
            out string message)
        {
            message = string.Empty;

            if (sanPham == null)
            {
                message = "Thông tin sản phẩm không hợp lệ.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sanPham.MaSanPham))
            {
                message = "Mã sản phẩm không được để trống.";
                return false;
            }

            if (sanPham.MaSanPham.Trim().Length > 10)
            {
                message = "Mã sản phẩm không được vượt quá 10 ký tự.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sanPham.TenSanPham))
            {
                message = "Vui lòng nhập tên sản phẩm.";
                return false;
            }

            if (sanPham.TenSanPham.Trim().Length > 150)
            {
                message = "Tên sản phẩm không được vượt quá 150 ký tự.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sanPham.LoaiSanPham))
            {
                message = "Vui lòng chọn loại sản phẩm.";
                return false;
            }

            if (sanPham.LoaiSanPham.Trim().Length > 100)
            {
                message = "Loại sản phẩm không được vượt quá 100 ký tự.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sanPham.ThuongHieu))
            {
                message = "Vui lòng nhập thương hiệu.";
                return false;
            }

            if (sanPham.ThuongHieu.Trim().Length > 100)
            {
                message = "Thương hiệu không được vượt quá 100 ký tự.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(sanPham.DonViTinh))
            {
                message = "Vui lòng chọn đơn vị tính.";
                return false;
            }

            if (sanPham.DonViTinh.Trim().Length > 30)
            {
                message = "Đơn vị tính không được vượt quá 30 ký tự.";
                return false;
            }

            if (sanPham.GiaBan <= 0)
            {
                message = "Giá bán phải lớn hơn 0.";
                return false;
            }

            if (sanPham.GiaBan > 9999999999999999.99m)
            {
                message = "Giá bán vượt quá giới hạn cho phép.";
                return false;
            }

            if (!string.IsNullOrEmpty(sanPham.MoTa)
                && sanPham.MoTa.Trim().Length > 500)
            {
                message = "Mô tả không được vượt quá 500 ký tự.";
                return false;
            }

            return true;
        }

        // Chuẩn hóa dữ liệu trước khi lưu
        private void ChuanHoaThongTinSanPham(SanPhamDTO sanPham)
        {
            sanPham.MaSanPham = sanPham.MaSanPham.Trim();
            sanPham.TenSanPham = sanPham.TenSanPham.Trim();
            sanPham.LoaiSanPham = sanPham.LoaiSanPham.Trim();
            sanPham.ThuongHieu = sanPham.ThuongHieu.Trim();
            sanPham.DonViTinh = sanPham.DonViTinh.Trim();
            sanPham.MoTa = sanPham.MoTa?.Trim() ?? string.Empty;
        }

        // Thêm sản phẩm
        public bool Insert(SanPhamDTO sanPham, out string message)
        {
            message = string.Empty;

            if (!KiemTraThongTinSanPham(sanPham, out message))
                return false;

            ChuanHoaThongTinSanPham(sanPham);

            try
            {
                if (sanPhamDAL.Insert(sanPham))
                {
                    message = "Thêm sản phẩm thành công.";
                    return true;
                }

                message = "Không thể thêm sản phẩm.";
                return false;
            }
            catch (Exception ex)
            {
                message = "Lỗi khi thêm sản phẩm: " + ex.Message;
                return false;
            }
        }

        // Cập nhật sản phẩm
        public bool Update(SanPhamDTO sanPham, out string message)
        {
            message = string.Empty;

            if (!KiemTraThongTinSanPham(sanPham, out message))
                return false;

            ChuanHoaThongTinSanPham(sanPham);

            try
            {
                if (sanPhamDAL.Update(sanPham))
                {
                    message = "Cập nhật sản phẩm thành công.";
                    return true;
                }

                message = "Không tìm thấy sản phẩm hoặc sản phẩm đã ngừng kinh doanh.";
                return false;
            }
            catch (Exception ex)
            {
                message = "Lỗi khi cập nhật sản phẩm: " + ex.Message;
                return false;
            }
        }

        // Ngừng kinh doanh sản phẩm
        public bool StopBusiness(string maSanPham, out string message)
        {
            message = string.Empty;

            if (string.IsNullOrWhiteSpace(maSanPham))
            {
                message = "Vui lòng chọn sản phẩm cần ngừng kinh doanh.";
                return false;
            }

            if (maSanPham.Trim().Length > 10)
            {
                message = "Mã sản phẩm không hợp lệ.";
                return false;
            }

            try
            {
                if (sanPhamDAL.StopBusiness(maSanPham.Trim()))
                {
                    message = "Đã ngừng kinh doanh sản phẩm.";
                    return true;
                }

                message = "Không tìm thấy sản phẩm hoặc sản phẩm đã ngừng kinh doanh.";
                return false;
            }
            catch (Exception ex)
            {
                message = "Lỗi khi ngừng kinh doanh: " + ex.Message;
                return false;
            }
        }

        // Tìm kiếm sản phẩm
        public DataTable Search(string keyword)
        {
            return sanPhamDAL.Search(keyword ?? string.Empty);
        }
    }
}
