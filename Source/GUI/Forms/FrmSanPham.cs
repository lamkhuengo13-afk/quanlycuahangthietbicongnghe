
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using QuanLyCuaHangThietBiCongNghe.BUS;
using QuanLyCuaHangThietBiCongNghe.DTO;

namespace QuanLyCuaHangThietBiCongNghe.GUI.Forms
{
    public partial class FrmSanPham : Form
    {
        private readonly SanPhamBUS sanPhamBUS = new SanPhamBUS();

        private bool dangChonSanPham = false;

        public FrmSanPham()
        {
            InitializeComponent();

            Load += FrmSanPham_Load;
            dgvSanPham.CellClick += dgvSanPham_CellClick;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnNgungKinhDoanh.Click += btnNgungKinhDoanh_Click;

            btnLamMoi.Click += btnLamMoi_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnTaiLai.Click += btnTaiLai_Click;
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            NapDuLieuComboBox();
            TaiDanhSachSanPham();
            LamMoiThongTin();
        }

        // Nạp dữ liệu cho ComboBox
        private void NapDuLieuComboBox()
        {
            cboLoaiSP.Items.Clear();

            cboLoaiSP.Items.Add("Bàn phím");
            cboLoaiSP.Items.Add("Chuột máy tính");
            cboLoaiSP.Items.Add("Laptop");
            cboLoaiSP.Items.Add("Màn hình");
            cboLoaiSP.Items.Add("Tai nghe");

            cboDonViTinh.Items.Clear();
            cboDonViTinh.Items.Add("Chiếc");
        }

        // Tải danh sách sản phẩm đang kinh doanh
        private void TaiDanhSachSanPham()
        {
            try
            {
                dgvSanPham.AutoGenerateColumns = false;
                dgvSanPham.DataSource = null;
                dgvSanPham.DataSource = sanPhamBUS.GetAll();

                colGiaBan.DefaultCellStyle.Format = "N0";

                dgvSanPham.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách sản phẩm từ cơ sở dữ liệu.\n\n"
                    + ex.Message,
                    "Lỗi tải dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Làm mới thông tin nhập liệu
        private void LamMoiThongTin()
        {
            try
            {
                dangChonSanPham = false;

                txtMaSP.Text = sanPhamBUS.GetNextProductCode();

                txtTenSP.Clear();
                cboLoaiSP.SelectedIndex = -1;
                txtThuongHieu.Clear();
                cboDonViTinh.SelectedIndex = -1;
                txtGiaBan.Clear();
                txtSoLuongTon.Text = "0";
                txtMoTa.Clear();

                dgvSanPham.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tạo mã sản phẩm mới.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Lấy và kiểm tra thông tin sản phẩm
        private bool TryLayThongTinSanPham(out SanPhamDTO sanPham)
        {
            sanPham = null;

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên sản phẩm.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtTenSP.Focus();
                return false;
            }

            if (cboLoaiSP.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn loại sản phẩm.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                cboLoaiSP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtThuongHieu.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập thương hiệu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtThuongHieu.Focus();
                return false;
            }

            if (cboDonViTinh.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Vui lòng chọn đơn vị tính.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                cboDonViTinh.Focus();
                return false;
            }

            if (!decimal.TryParse(
                txtGiaBan.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.GetCultureInfo("vi-VN"),
                out decimal giaBan))
            {
                MessageBox.Show(
                    "Giá bán không hợp lệ. Vui lòng nhập lại.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtGiaBan.Focus();
                return false;
            }

            if (giaBan <= 0)
            {
                MessageBox.Show(
                    "Giá bán phải lớn hơn 0.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtGiaBan.Focus();
                return false;
            }

            sanPham = new SanPhamDTO
            {
                MaSanPham = txtMaSP.Text.Trim(),
                TenSanPham = txtTenSP.Text.Trim(),
                LoaiSanPham = cboLoaiSP.SelectedItem.ToString(),
                ThuongHieu = txtThuongHieu.Text.Trim(),
                DonViTinh = cboDonViTinh.SelectedItem.ToString(),
                GiaBan = giaBan,
                SoLuongTon = 0,
                MoTa = txtMoTa.Text.Trim(),
                TrangThai = true
            };

            return true;
        }

        // Thêm sản phẩm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dangChonSanPham)
            {
                MessageBox.Show(
                    "Em đang chọn một sản phẩm có sẵn.\n"
                    + "Hãy nhấn nút Làm mới trước khi thêm sản phẩm mới.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!TryLayThongTinSanPham(out SanPhamDTO sanPham))
                return;

            if (sanPhamBUS.Insert(sanPham, out string message))
            {
                MessageBox.Show(
                    message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                TaiDanhSachSanPham();
                LamMoiThongTin();
            }
            else
            {
                MessageBox.Show(
                    message,
                    "Không thể thêm sản phẩm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // Cập nhật sản phẩm
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!dangChonSanPham)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm trong danh sách trước khi cập nhật.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!TryLayThongTinSanPham(out SanPhamDTO sanPham))
                return;

            if (sanPhamBUS.Update(sanPham, out string message))
            {
                MessageBox.Show(
                    message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                TaiDanhSachSanPham();
                LamMoiThongTin();
            }
            else
            {
                MessageBox.Show(
                    message,
                    "Không thể cập nhật sản phẩm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // Ngừng kinh doanh sản phẩm
        private void btnNgungKinhDoanh_Click(object sender, EventArgs e)
        {
            if (!dangChonSanPham)
            {
                MessageBox.Show(
                    "Vui lòng chọn sản phẩm cần ngừng kinh doanh.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string maSP = txtMaSP.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();

            DialogResult ketQua = MessageBox.Show(
                "Em có chắc chắn muốn ngừng kinh doanh sản phẩm:\n\n"
                + maSP + " - " + tenSP + " không?\n\n"
                + "Sản phẩm sẽ không còn xuất hiện trong danh sách đang kinh doanh.",
                "Xác nhận ngừng kinh doanh",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (ketQua != DialogResult.Yes)
                return;

            if (sanPhamBUS.StopBusiness(maSP, out string message))
            {
                MessageBox.Show(
                    message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                TaiDanhSachSanPham();
                LamMoiThongTin();
            }
            else
            {
                MessageBox.Show(
                    message,
                    "Không thể ngừng kinh doanh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // Làm mới thông tin trên form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiThongTin();
        }

        // Tìm kiếm sản phẩm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                MessageBox.Show(
                    "Vui lòng nhập từ khóa cần tìm kiếm.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTimKiem.Focus();
                return;
            }

            try
            {
                DataTable ketQua = sanPhamBUS.Search(tuKhoa);

                dgvSanPham.AutoGenerateColumns = false;
                dgvSanPham.DataSource = null;
                dgvSanPham.DataSource = ketQua;

                colGiaBan.DefaultCellStyle.Format = "N0";

                dgvSanPham.ClearSelection();

                LamMoiThongTin();

                if (ketQua.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Không tìm thấy sản phẩm phù hợp với từ khóa: "
                        + tuKhoa,
                        "Kết quả tìm kiếm",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tìm kiếm sản phẩm.\n\n" + ex.Message,
                    "Lỗi tìm kiếm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Tải lại toàn bộ danh sách sản phẩm
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();

            TaiDanhSachSanPham();
            LamMoiThongTin();
        }

        // Hiển thị thông tin sản phẩm khi chọn một dòng
        private void dgvSanPham_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                string maSP = dgvSanPham.Rows[e.RowIndex]
                    .Cells["colMaSP"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(maSP))
                    return;

                SanPhamDTO sanPham = sanPhamBUS.GetById(maSP);

                if (sanPham == null)
                    return;

                dangChonSanPham = true;

                txtMaSP.Text = sanPham.MaSanPham;
                txtTenSP.Text = sanPham.TenSanPham;

                cboLoaiSP.SelectedItem = sanPham.LoaiSanPham;
                txtThuongHieu.Text = sanPham.ThuongHieu;

                cboDonViTinh.SelectedItem = sanPham.DonViTinh;

                txtGiaBan.Text = sanPham.GiaBan.ToString("N0");
                txtSoLuongTon.Text = sanPham.SoLuongTon.ToString();

                txtMoTa.Text = sanPham.MoTa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể hiển thị thông tin sản phẩm.\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvSanPham_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
