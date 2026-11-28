
using System;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangThietBiCongNghe.BUS;
using QuanLyCuaHangThietBiCongNghe.DTO;

namespace QuanLyCuaHangThietBiCongNghe.GUI.Forms
{
    // Form quản lý nhân viên (mục 3.2.3 b - Bảng 3.16).
    // Chỉ dành cho Người quản lý.
    public partial class FrmNhanVien : Form
    {
        private readonly NhanVienBUS nhanVienBUS = new NhanVienBUS();

        private const string DangLamViec = "Đang làm việc";
        private const string NgungHoatDong = "Ngừng hoạt động";

        private bool dangChonNhanVien = false;

        public FrmNhanVien()
        {
            InitializeComponent();

            Load += FrmNhanVien_Load;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnNgungHoatDong.Click += btnNgungHoatDong_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            btnTimKiem.Click += btnTimKiem_Click;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            if (!PhienDangNhap.LaQuanLy)
            {
                MessageBox.Show(
                    "Chức năng quản lý nhân viên chỉ dành cho Người quản lý.",
                    "Không có quyền truy cập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                BeginInvoke(new Action(Close));
                return;
            }

            NapDuLieuComboBox();
            TaiDanhSachNhanVien(nhanVienBUS.GetAll());
            LamMoiThongTin();
        }

        // Nạp dữ liệu cho ComboBox
        private void NapDuLieuComboBox()
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(NhanVienBUS.DanhSachGioiTinh);

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add(DangLamViec);
            cboTrangThai.Items.Add(NgungHoatDong);
        }

        // Hiển thị danh sách nhân viên lên DataGridView
        private void TaiDanhSachNhanVien(DataTable duLieu)
        {
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.DataSource = null;
            dgvNhanVien.DataSource = duLieu;
            dgvNhanVien.ClearSelection();
        }

        private void TaiLaiDanhSach()
        {
            try
            {
                TaiDanhSachNhanVien(nhanVienBUS.Search(txtTimKiem.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách nhân viên từ cơ sở dữ liệu.\n\n" + ex.Message,
                    "Lỗi tải dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Làm mới thông tin nhập liệu, chuẩn bị thêm nhân viên mới
        private void LamMoiThongTin()
        {
            dangChonNhanVien = false;

            try
            {
                txtMaNhanVien.Text = nhanVienBUS.GetNextEmployeeCode();
            }
            catch (Exception ex)
            {
                txtMaNhanVien.Text = string.Empty;

                MessageBox.Show(
                    "Không thể kết nối cơ sở dữ liệu.\n\n" + ex.Message,
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Today.AddYears(-18);
            dtpNgaySinh.Checked = false;
            cboGioiTinh.SelectedIndex = -1;
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            dtpNgayVaoLam.Value = DateTime.Today;

            cboTrangThai.SelectedItem = DangLamViec;
            cboTrangThai.Enabled = false;

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnNgungHoatDong.Enabled = false;

            dgvNhanVien.ClearSelection();
            txtHoTen.Focus();
        }

        // Đọc dữ liệu trên Form thành NhanVienDTO
        private NhanVienDTO LayThongTinTuForm()
        {
            return new NhanVienDTO
            {
                MaNhanVien = txtMaNhanVien.Text,
                HoTen = txtHoTen.Text,
                NgaySinh = dtpNgaySinh.Checked ? dtpNgaySinh.Value.Date : null,
                GioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? string.Empty,
                SoDienThoai = txtSoDienThoai.Text,
                Email = txtEmail.Text,
                DiaChi = txtDiaChi.Text,
                NgayVaoLam = dtpNgayVaoLam.Value.Date,
                TrangThai = cboTrangThai.SelectedItem?.ToString() != NgungHoatDong
            };
        }

        // Chọn một dòng trên bảng: đổ thông tin lên Form
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string maNhanVien =
                dgvNhanVien.Rows[e.RowIndex].Cells[colMaNhanVien.Name].Value?.ToString();

            NhanVienDTO nhanVien;

            try
            {
                nhanVien = nhanVienBUS.GetById(maNhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể lấy thông tin nhân viên.\n\n" + ex.Message,
                    "Lỗi tải dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (nhanVien == null)
                return;

            dangChonNhanVien = true;

            txtMaNhanVien.Text = nhanVien.MaNhanVien;
            txtHoTen.Text = nhanVien.HoTen;

            if (nhanVien.NgaySinh.HasValue)
            {
                dtpNgaySinh.Value = nhanVien.NgaySinh.Value;
                dtpNgaySinh.Checked = true;
            }
            else
            {
                dtpNgaySinh.Value = DateTime.Today.AddYears(-18);
                dtpNgaySinh.Checked = false;
            }

            cboGioiTinh.SelectedIndex = cboGioiTinh.Items.IndexOf(nhanVien.GioiTinh);
            txtSoDienThoai.Text = nhanVien.SoDienThoai;
            txtEmail.Text = nhanVien.Email;
            txtDiaChi.Text = nhanVien.DiaChi;
            dtpNgayVaoLam.Value = nhanVien.NgayVaoLam;

            cboTrangThai.SelectedItem = nhanVien.TrangThai ? DangLamViec : NgungHoatDong;
            cboTrangThai.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnNgungHoatDong.Enabled = nhanVien.TrangThai;
        }

        // Thêm nhân viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dangChonNhanVien)
            {
                MessageBox.Show(
                    "Bạn đang xem một nhân viên có sẵn. Bấm \"Làm mới\" trước khi thêm nhân viên mới.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            NhanVienDTO nhanVien = LayThongTinTuForm();

            if (nhanVienBUS.Insert(nhanVien, out string message))
            {
                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TaiLaiDanhSach();
                LamMoiThongTin();
            }
            else
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Cập nhật nhân viên
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!dangChonNhanVien)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhân viên cần cập nhật trên bảng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            NhanVienDTO nhanVien = LayThongTinTuForm();

            if (!nhanVien.TrangThai && btnNgungHoatDong.Enabled)
            {
                DialogResult xacNhan = MessageBox.Show(
                    "Bạn đang chuyển nhân viên sang \"Ngừng hoạt động\".\n"
                    + "Tài khoản đăng nhập của nhân viên này (nếu có) cũng sẽ bị khóa.\n\nTiếp tục?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (xacNhan != DialogResult.Yes)
                    return;
            }

            if (nhanVienBUS.Update(nhanVien, out string message))
            {
                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TaiLaiDanhSach();
                LamMoiThongTin();
            }
            else
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Ngừng hoạt động nhân viên (không xóa khỏi database)
        private void btnNgungHoatDong_Click(object sender, EventArgs e)
        {
            if (!dangChonNhanVien)
            {
                MessageBox.Show(
                    "Vui lòng chọn nhân viên cần ngừng hoạt động.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Chuyển nhân viên " + txtMaNhanVien.Text + " - " + txtHoTen.Text
                + " sang trạng thái \"Ngừng hoạt động\"?\n"
                + "Tài khoản đăng nhập của nhân viên này (nếu có) cũng sẽ bị khóa.",
                "Xác nhận ngừng hoạt động",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (xacNhan != DialogResult.Yes)
                return;

            if (nhanVienBUS.StopWorking(txtMaNhanVien.Text, out string message))
            {
                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TaiLaiDanhSach();
                LamMoiThongTin();
            }
            else
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Làm mới Form và tải lại toàn bộ danh sách
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            TaiLaiDanhSach();
            LamMoiThongTin();
        }

        // Tìm kiếm theo mã, họ tên hoặc số điện thoại
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaiLaiDanhSach();

            if (dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy nhân viên phù hợp.",
                    "Kết quả tìm kiếm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // Nhấn Enter trong ô tìm kiếm
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnTimKiem_Click(sender, EventArgs.Empty);
            }
        }
    }
}
