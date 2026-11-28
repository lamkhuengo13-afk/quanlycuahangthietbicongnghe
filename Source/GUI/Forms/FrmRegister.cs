
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyCuaHangThietBiCongNghe.BUS;

namespace QuanLyCuaHangThietBiCongNghe.GUI.Forms
{
    // Form đăng kí tài khoản nhân viên (mục 3.2.2 - Bảng 3.14).
    // Chỉ Người quản lý được tạo tài khoản; vai trò mặc định là Nhân viên.
    public partial class FrmRegister : Form
    {
        private readonly TaiKhoanBUS taiKhoanBUS = new TaiKhoanBUS();

        public FrmRegister()
        {
            InitializeComponent();

            Load += FrmRegister_Load;

            btnDangKi.Click += btnDangKi_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnDong.Click += btnDong_Click;
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            if (!PhienDangNhap.LaQuanLy)
            {
                MessageBox.Show(
                    "Chỉ Người quản lý mới được tạo tài khoản cho nhân viên.",
                    "Không có quyền truy cập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                BeginInvoke(new Action(Close));
                return;
            }

            txtVaiTro.Text = "Nhân viên";
            TaiDanhSachNhanVien();
            LamMoiThongTin();
        }

        // Bước 2: lấy danh sách nhân viên chưa có tài khoản đổ vào ComboBox
        private void TaiDanhSachNhanVien()
        {
            try
            {
                DataTable duLieu = taiKhoanBUS.GetEmployeesWithoutAccount();

                cboNhanVien.DataSource = null;
                cboNhanVien.DisplayMember = "HienThi";
                cboNhanVien.ValueMember = "MaNhanVien";
                cboNhanVien.DataSource = duLieu;
                cboNhanVien.SelectedIndex = -1;

                if (duLieu.Rows.Count == 0)
                {
                    HienThongBao("Tất cả nhân viên đang làm việc đều đã có tài khoản.", false);
                }
            }
            catch (Exception ex)
            {
                HienThongBao("Không thể tải danh sách nhân viên: " + ex.Message, true);
            }
        }

        // Bước 4 - 9: kiểm tra dữ liệu và tạo tài khoản
        private void btnDangKi_Click(object sender, EventArgs e)
        {
            string maNhanVien = cboNhanVien.SelectedIndex >= 0
                ? cboNhanVien.SelectedValue?.ToString()
                : null;

            bool thanhCong = taiKhoanBUS.Register(
                maNhanVien,
                txtTenDangNhap.Text,
                txtMatKhau.Text,
                txtXacNhanMatKhau.Text,
                out string message);

            if (thanhCong)
            {
                TaiDanhSachNhanVien();
                LamMoiThongTin();
                HienThongBao(message, false);
            }
            else
            {
                HienThongBao(message, true);

                // Sai mật khẩu thì xóa 2 ô mật khẩu để nhập lại
                if (message.Contains("Mật khẩu"))
                {
                    txtMatKhau.Clear();
                    txtXacNhanMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiThongTin();
            lblThongBao.Text = string.Empty;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Đưa Form về trạng thái ban đầu
        private void LamMoiThongTin()
        {
            cboNhanVien.SelectedIndex = -1;
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtXacNhanMatKhau.Clear();
            cboNhanVien.Focus();
        }

        // Hiển thị kết quả lên lblThongBao: đỏ là lỗi, xanh là thành công
        private void HienThongBao(string noiDung, bool laLoi)
        {
            lblThongBao.ForeColor = laLoi
                ? Color.FromArgb(185, 28, 28)
                : Color.FromArgb(21, 128, 61);

            lblThongBao.Text = noiDung;
        }
    }
}
