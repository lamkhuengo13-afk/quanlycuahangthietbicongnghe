namespace QuanLyCuaHangThietBiCongNghe.GUI.Forms
{
    partial class FrmNhanVien
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblTieuDe = new Label();
            lblPhuDe = new Label();
            lblMaNhanVien = new Label();
            txtMaNhanVien = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblGioiTinh = new Label();
            cboGioiTinh = new ComboBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblNgayVaoLam = new Label();
            dtpNgayVaoLam = new DateTimePicker();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnLamMoi = new Button();
            btnNgungHoatDong = new Button();
            pnlTimKiem = new Panel();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvNhanVien = new DataGridView();
            colMaNhanVien = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colNgaySinh = new DataGridViewTextBoxColumn();
            colGioiTinh = new DataGridViewTextBoxColumn();
            colSoDienThoai = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colNgayVaoLam = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();

            pnlHeader.SuspendLayout();
            pnlTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(31, 58, 138);
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Controls.Add(lblPhuDe);
            pnlHeader.Location = new Point(18, 18);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1240, 88);
            pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHeader.TabIndex = 0;

            // lblTieuDe
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(24, 12);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(380, 46);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÝ NHÂN VIÊN";

            // lblPhuDe
            lblPhuDe.AutoSize = true;
            lblPhuDe.Font = new Font("Segoe UI", 10F);
            lblPhuDe.ForeColor = Color.White;
            lblPhuDe.Location = new Point(25, 52);
            lblPhuDe.Name = "lblPhuDe";
            lblPhuDe.Size = new Size(400, 23);
            lblPhuDe.TabIndex = 1;
            lblPhuDe.Text = "Quản lý hồ sơ và trạng thái làm việc của nhân viên";

            // lblMaNhanVien
            lblMaNhanVien.AutoSize = true;
            lblMaNhanVien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaNhanVien.ForeColor = Color.FromArgb(30, 41, 59);
            lblMaNhanVien.Location = new Point(30, 130);
            lblMaNhanVien.Name = "lblMaNhanVien";
            lblMaNhanVien.Size = new Size(140, 23);
            lblMaNhanVien.TabIndex = 1;
            lblMaNhanVien.Text = "Mã nhân viên";

            // txtMaNhanVien
            txtMaNhanVien.Location = new Point(180, 126);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(300, 30);
            txtMaNhanVien.TabIndex = 2;
            txtMaNhanVien.BackColor = Color.FromArgb(239, 246, 255);
            txtMaNhanVien.ReadOnly = true;
            txtMaNhanVien.TabStop = false;

            // lblHoTen
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHoTen.ForeColor = Color.FromArgb(30, 41, 59);
            lblHoTen.Location = new Point(530, 130);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(140, 23);
            lblHoTen.TabIndex = 3;
            lblHoTen.Text = "Họ tên (*)";

            // txtHoTen
            txtHoTen.Location = new Point(680, 126);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(400, 30);
            txtHoTen.TabIndex = 4;
            txtHoTen.MaxLength = 100;

            // lblNgaySinh
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNgaySinh.ForeColor = Color.FromArgb(30, 41, 59);
            lblNgaySinh.Location = new Point(30, 180);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(140, 23);
            lblNgaySinh.TabIndex = 5;
            lblNgaySinh.Text = "Ngày sinh";

            // dtpNgaySinh
            dtpNgaySinh.Location = new Point(180, 176);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(300, 30);
            dtpNgaySinh.TabIndex = 6;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.ShowCheckBox = true;

            // lblGioiTinh
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGioiTinh.ForeColor = Color.FromArgb(30, 41, 59);
            lblGioiTinh.Location = new Point(530, 180);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(140, 23);
            lblGioiTinh.TabIndex = 7;
            lblGioiTinh.Text = "Giới tính";

            // cboGioiTinh
            cboGioiTinh.Location = new Point(680, 176);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(400, 30);
            cboGioiTinh.TabIndex = 8;
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;

            // lblSoDienThoai
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSoDienThoai.ForeColor = Color.FromArgb(30, 41, 59);
            lblSoDienThoai.Location = new Point(30, 230);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(140, 23);
            lblSoDienThoai.TabIndex = 9;
            lblSoDienThoai.Text = "Số điện thoại (*)";

            // txtSoDienThoai
            txtSoDienThoai.Location = new Point(180, 226);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(300, 30);
            txtSoDienThoai.TabIndex = 10;
            txtSoDienThoai.MaxLength = 10;

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(30, 41, 59);
            lblEmail.Location = new Point(530, 230);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(140, 23);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "Email";

            // txtEmail
            txtEmail.Location = new Point(680, 226);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 30);
            txtEmail.TabIndex = 12;
            txtEmail.MaxLength = 254;

            // lblNgayVaoLam
            lblNgayVaoLam.AutoSize = true;
            lblNgayVaoLam.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNgayVaoLam.ForeColor = Color.FromArgb(30, 41, 59);
            lblNgayVaoLam.Location = new Point(30, 280);
            lblNgayVaoLam.Name = "lblNgayVaoLam";
            lblNgayVaoLam.Size = new Size(140, 23);
            lblNgayVaoLam.TabIndex = 13;
            lblNgayVaoLam.Text = "Ngày vào làm (*)";

            // dtpNgayVaoLam
            dtpNgayVaoLam.Location = new Point(180, 276);
            dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            dtpNgayVaoLam.Size = new Size(300, 30);
            dtpNgayVaoLam.TabIndex = 14;
            dtpNgayVaoLam.CustomFormat = "dd/MM/yyyy";
            dtpNgayVaoLam.Format = DateTimePickerFormat.Custom;

            // lblTrangThai
            lblTrangThai.AutoSize = true;
            lblTrangThai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTrangThai.ForeColor = Color.FromArgb(30, 41, 59);
            lblTrangThai.Location = new Point(530, 280);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(140, 23);
            lblTrangThai.TabIndex = 15;
            lblTrangThai.Text = "Trạng thái";

            // cboTrangThai
            cboTrangThai.Location = new Point(680, 276);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(400, 30);
            cboTrangThai.TabIndex = 16;
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

            // lblDiaChi
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDiaChi.ForeColor = Color.FromArgb(30, 41, 59);
            lblDiaChi.Location = new Point(30, 330);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(140, 23);
            lblDiaChi.TabIndex = 17;
            lblDiaChi.Text = "Địa chỉ";

            // txtDiaChi
            txtDiaChi.Location = new Point(180, 326);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(900, 30);
            txtDiaChi.TabIndex = 18;
            txtDiaChi.MaxLength = 255;

            // btnThem
            btnThem.BackColor = Color.FromArgb(37, 99, 235);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(30, 380);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(150, 42);
            btnThem.TabIndex = 19;
            btnThem.Text = "Thêm nhân viên";
            btnThem.UseVisualStyleBackColor = false;

            // btnSua
            btnSua.BackColor = Color.FromArgb(219, 234, 254);
            btnSua.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.FromArgb(30, 64, 175);
            btnSua.Location = new Point(195, 380);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(150, 42);
            btnSua.TabIndex = 20;
            btnSua.Text = "Cập nhật";
            btnSua.UseVisualStyleBackColor = false;

            // btnLamMoi
            btnLamMoi.BackColor = Color.FromArgb(239, 246, 255);
            btnLamMoi.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.FromArgb(30, 64, 175);
            btnLamMoi.Location = new Point(360, 380);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 42);
            btnLamMoi.TabIndex = 21;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;

            // btnNgungHoatDong
            btnNgungHoatDong.BackColor = Color.FromArgb(254, 226, 226);
            btnNgungHoatDong.FlatAppearance.BorderColor = Color.FromArgb(220, 38, 38);
            btnNgungHoatDong.FlatStyle = FlatStyle.Flat;
            btnNgungHoatDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNgungHoatDong.ForeColor = Color.FromArgb(185, 28, 28);
            btnNgungHoatDong.Location = new Point(525, 380);
            btnNgungHoatDong.Name = "btnNgungHoatDong";
            btnNgungHoatDong.Size = new Size(180, 42);
            btnNgungHoatDong.TabIndex = 22;
            btnNgungHoatDong.Text = "Ngừng hoạt động";
            btnNgungHoatDong.UseVisualStyleBackColor = false;

            // pnlTimKiem
            pnlTimKiem.BackColor = Color.FromArgb(239, 246, 255);
            pnlTimKiem.Controls.Add(lblTimKiem);
            pnlTimKiem.Controls.Add(txtTimKiem);
            pnlTimKiem.Controls.Add(btnTimKiem);
            pnlTimKiem.Location = new Point(30, 440);
            pnlTimKiem.Name = "pnlTimKiem";
            pnlTimKiem.Size = new Size(1205, 65);
            pnlTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTimKiem.TabIndex = 23;

            // lblTimKiem
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTimKiem.ForeColor = Color.FromArgb(30, 64, 175);
            lblTimKiem.Location = new Point(25, 21);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(170, 23);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm nhân viên";

            // txtTimKiem
            txtTimKiem.Location = new Point(220, 16);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã, họ tên hoặc số điện thoại";
            txtTimKiem.Size = new Size(400, 30);
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.TabIndex = 1;

            // btnTimKiem
            btnTimKiem.BackColor = Color.FromArgb(37, 99, 235);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(635, 13);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(110, 36);
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;

            // dgvNhanVien
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(239, 246, 255);
            dgvNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvNhanVien.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvNhanVien.ColumnHeadersHeight = 40;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNhanVien.Columns.AddRange(new DataGridViewColumn[]
            {
                colMaNhanVien,
                colHoTen,
                colNgaySinh,
                colGioiTinh,
                colSoDienThoai,
                colEmail,
                colNgayVaoLam,
                colTrangThai,
            });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(30, 64, 175);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(191, 219, 254);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(30, 64, 175);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            dgvNhanVien.EnableHeadersVisualStyles = false;
            dgvNhanVien.Location = new Point(30, 525);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.Size = new Size(1205, 300);
            dgvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.RowTemplate.Height = 36;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.TabIndex = 24;

            // colMaNhanVien
            colMaNhanVien.DataPropertyName = "MaNhanVien";
            colMaNhanVien.HeaderText = "Mã NV";
            colMaNhanVien.MinimumWidth = 80;
            colMaNhanVien.Name = "colMaNhanVien";
            colMaNhanVien.ReadOnly = true;
            colMaNhanVien.FillWeight = 10;

            // colHoTen
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.HeaderText = "Họ tên";
            colHoTen.MinimumWidth = 150;
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            colHoTen.FillWeight = 22;

            // colNgaySinh
            colNgaySinh.DataPropertyName = "NgaySinh";
            colNgaySinh.HeaderText = "Ngày sinh";
            colNgaySinh.MinimumWidth = 100;
            colNgaySinh.Name = "colNgaySinh";
            colNgaySinh.ReadOnly = true;
            colNgaySinh.FillWeight = 11;
            colNgaySinh.DefaultCellStyle.Format = "dd/MM/yyyy";

            // colGioiTinh
            colGioiTinh.DataPropertyName = "GioiTinh";
            colGioiTinh.HeaderText = "Giới tính";
            colGioiTinh.MinimumWidth = 80;
            colGioiTinh.Name = "colGioiTinh";
            colGioiTinh.ReadOnly = true;
            colGioiTinh.FillWeight = 8;

            // colSoDienThoai
            colSoDienThoai.DataPropertyName = "SoDienThoai";
            colSoDienThoai.HeaderText = "Số điện thoại";
            colSoDienThoai.MinimumWidth = 110;
            colSoDienThoai.Name = "colSoDienThoai";
            colSoDienThoai.ReadOnly = true;
            colSoDienThoai.FillWeight = 12;

            // colEmail
            colEmail.DataPropertyName = "Email";
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 150;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            colEmail.FillWeight = 18;

            // colNgayVaoLam
            colNgayVaoLam.DataPropertyName = "NgayVaoLam";
            colNgayVaoLam.HeaderText = "Ngày vào làm";
            colNgayVaoLam.MinimumWidth = 110;
            colNgayVaoLam.Name = "colNgayVaoLam";
            colNgayVaoLam.ReadOnly = true;
            colNgayVaoLam.FillWeight = 11;
            colNgayVaoLam.DefaultCellStyle.Format = "dd/MM/yyyy";

            // colTrangThai
            colTrangThai.DataPropertyName = "TrangThaiHienThi";
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 120;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            colTrangThai.FillWeight = 12;

            // FrmNhanVien
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1265, 845);
            Controls.Add(pnlHeader);
            Controls.Add(lblMaNhanVien);
            Controls.Add(txtMaNhanVien);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblNgaySinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblGioiTinh);
            Controls.Add(cboGioiTinh);
            Controls.Add(lblSoDienThoai);
            Controls.Add(txtSoDienThoai);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblNgayVaoLam);
            Controls.Add(dtpNgayVaoLam);
            Controls.Add(lblTrangThai);
            Controls.Add(cboTrangThai);
            Controls.Add(lblDiaChi);
            Controls.Add(txtDiaChi);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnLamMoi);
            Controls.Add(btnNgungHoatDong);
            Controls.Add(pnlTimKiem);
            Controls.Add(dgvNhanVien);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1100, 760);
            Name = "FrmNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ NHÂN VIÊN";

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlTimKiem.ResumeLayout(false);
            pnlTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTieuDe;
        private Label lblPhuDe;
        private Label lblMaNhanVien;
        private TextBox txtMaNhanVien;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblGioiTinh;
        private ComboBox cboGioiTinh;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblNgayVaoLam;
        private DateTimePicker dtpNgayVaoLam;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Button btnThem;
        private Button btnSua;
        private Button btnLamMoi;
        private Button btnNgungHoatDong;
        private Panel pnlTimKiem;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvNhanVien;
        private DataGridViewTextBoxColumn colMaNhanVien;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colNgaySinh;
        private DataGridViewTextBoxColumn colGioiTinh;
        private DataGridViewTextBoxColumn colSoDienThoai;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colNgayVaoLam;
        private DataGridViewTextBoxColumn colTrangThai;
    }
}
