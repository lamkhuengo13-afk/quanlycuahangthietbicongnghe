namespace QuanLyCuaHangThietBiCongNghe.GUI.Forms
{
    partial class FrmRegister
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTieuDe = new Label();
            lblPhuDe = new Label();
            lblNhanVien = new Label();
            cboNhanVien = new ComboBox();
            lblTenDangNhap = new Label();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            lblXacNhanMatKhau = new Label();
            txtXacNhanMatKhau = new TextBox();
            lblVaiTro = new Label();
            txtVaiTro = new TextBox();
            btnDangKi = new Button();
            btnLamMoi = new Button();
            btnDong = new Button();
            lblThongBao = new Label();

            pnlHeader.SuspendLayout();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(31, 58, 138);
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Controls.Add(lblPhuDe);
            pnlHeader.Location = new Point(18, 18);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(584, 88);
            pnlHeader.TabIndex = 0;

            // lblTieuDe
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(24, 12);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(500, 41);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "ĐĂNG KÍ TÀI KHOẢN NHÂN VIÊN";

            // lblPhuDe
            lblPhuDe.AutoSize = true;
            lblPhuDe.Font = new Font("Segoe UI", 10F);
            lblPhuDe.ForeColor = Color.White;
            lblPhuDe.Location = new Point(25, 52);
            lblPhuDe.Name = "lblPhuDe";
            lblPhuDe.Size = new Size(450, 23);
            lblPhuDe.TabIndex = 1;
            lblPhuDe.Text = "Cấp tài khoản đăng nhập cho nhân viên chưa có tài khoản";

            // lblNhanVien
            lblNhanVien.AutoSize = true;
            lblNhanVien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNhanVien.ForeColor = Color.FromArgb(30, 41, 59);
            lblNhanVien.Location = new Point(40, 134);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(190, 23);
            lblNhanVien.TabIndex = 1;
            lblNhanVien.Text = "Nhân viên (*)";

            // cboNhanVien
            cboNhanVien.Location = new Point(240, 130);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(340, 30);
            cboNhanVien.TabIndex = 2;
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;

            // lblTenDangNhap
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTenDangNhap.ForeColor = Color.FromArgb(30, 41, 59);
            lblTenDangNhap.Location = new Point(40, 184);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(190, 23);
            lblTenDangNhap.TabIndex = 3;
            lblTenDangNhap.Text = "Tên đăng nhập (*)";

            // txtTenDangNhap
            txtTenDangNhap.Location = new Point(240, 180);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(340, 30);
            txtTenDangNhap.TabIndex = 4;
            txtTenDangNhap.MaxLength = 50;

            // lblMatKhau
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMatKhau.ForeColor = Color.FromArgb(30, 41, 59);
            lblMatKhau.Location = new Point(40, 234);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(190, 23);
            lblMatKhau.TabIndex = 5;
            lblMatKhau.Text = "Mật khẩu (*)";

            // txtMatKhau
            txtMatKhau.Location = new Point(240, 230);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(340, 30);
            txtMatKhau.TabIndex = 6;
            txtMatKhau.MaxLength = 100;
            txtMatKhau.UseSystemPasswordChar = true;

            // lblXacNhanMatKhau
            lblXacNhanMatKhau.AutoSize = true;
            lblXacNhanMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblXacNhanMatKhau.ForeColor = Color.FromArgb(30, 41, 59);
            lblXacNhanMatKhau.Location = new Point(40, 284);
            lblXacNhanMatKhau.Name = "lblXacNhanMatKhau";
            lblXacNhanMatKhau.Size = new Size(190, 23);
            lblXacNhanMatKhau.TabIndex = 7;
            lblXacNhanMatKhau.Text = "Xác nhận mật khẩu (*)";

            // txtXacNhanMatKhau
            txtXacNhanMatKhau.Location = new Point(240, 280);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.Size = new Size(340, 30);
            txtXacNhanMatKhau.TabIndex = 8;
            txtXacNhanMatKhau.MaxLength = 100;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;

            // lblVaiTro
            lblVaiTro.AutoSize = true;
            lblVaiTro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVaiTro.ForeColor = Color.FromArgb(30, 41, 59);
            lblVaiTro.Location = new Point(40, 334);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(190, 23);
            lblVaiTro.TabIndex = 9;
            lblVaiTro.Text = "Vai trò";

            // txtVaiTro
            txtVaiTro.Location = new Point(240, 330);
            txtVaiTro.Name = "txtVaiTro";
            txtVaiTro.Size = new Size(340, 30);
            txtVaiTro.TabIndex = 10;
            txtVaiTro.BackColor = Color.FromArgb(239, 246, 255);
            txtVaiTro.ReadOnly = true;
            txtVaiTro.TabStop = false;
            txtVaiTro.Text = "Nhân viên";

            // btnDangKi
            btnDangKi.BackColor = Color.FromArgb(37, 99, 235);
            btnDangKi.FlatAppearance.BorderSize = 0;
            btnDangKi.FlatStyle = FlatStyle.Flat;
            btnDangKi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDangKi.ForeColor = Color.White;
            btnDangKi.Location = new Point(75, 390);
            btnDangKi.Name = "btnDangKi";
            btnDangKi.Size = new Size(150, 42);
            btnDangKi.TabIndex = 11;
            btnDangKi.Text = "Đăng kí";
            btnDangKi.UseVisualStyleBackColor = false;

            // btnLamMoi
            btnLamMoi.BackColor = Color.FromArgb(239, 246, 255);
            btnLamMoi.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.FromArgb(30, 64, 175);
            btnLamMoi.Location = new Point(235, 390);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 42);
            btnLamMoi.TabIndex = 12;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;

            // btnDong
            btnDong.BackColor = Color.FromArgb(219, 234, 254);
            btnDong.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDong.ForeColor = Color.FromArgb(30, 64, 175);
            btnDong.Location = new Point(395, 390);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(150, 42);
            btnDong.TabIndex = 13;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;

            // lblThongBao
            lblThongBao.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblThongBao.Location = new Point(40, 445);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(540, 50);
            lblThongBao.TabIndex = 14;
            lblThongBao.TextAlign = ContentAlignment.MiddleCenter;

            // FrmRegister
            AcceptButton = btnDangKi;
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnDong;
            ClientSize = new Size(620, 510);
            Controls.Add(pnlHeader);
            Controls.Add(lblNhanVien);
            Controls.Add(cboNhanVien);
            Controls.Add(lblTenDangNhap);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblMatKhau);
            Controls.Add(txtMatKhau);
            Controls.Add(lblXacNhanMatKhau);
            Controls.Add(txtXacNhanMatKhau);
            Controls.Add(lblVaiTro);
            Controls.Add(txtVaiTro);
            Controls.Add(btnDangKi);
            Controls.Add(btnLamMoi);
            Controls.Add(btnDong);
            Controls.Add(lblThongBao);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ĐĂNG KÍ TÀI KHOẢN NHÂN VIÊN";

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTieuDe;
        private Label lblPhuDe;
        private Label lblNhanVien;
        private ComboBox cboNhanVien;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private Label lblXacNhanMatKhau;
        private TextBox txtXacNhanMatKhau;
        private Label lblVaiTro;
        private TextBox txtVaiTro;
        private Button btnDangKi;
        private Button btnLamMoi;
        private Button btnDong;
        private Label lblThongBao;
    }
}
