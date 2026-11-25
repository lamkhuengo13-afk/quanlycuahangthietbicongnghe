
namespace QuanLyCuaHangThietBiCongNghe.GUI.Forms
{
    partial class FrmSanPham
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlTimKiem;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblPhuDe;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblLoaiSP;
        private System.Windows.Forms.Label lblThuongHieu;
        private System.Windows.Forms.Label lblDonViTinh;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.Label lblSoLuongTon;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTimKiem;

        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtThuongHieu;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.ComboBox cboDonViTinh;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnNgungKinhDoanh;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTaiLai;

        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThuongHieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongTon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();

            pnlHeader = new Panel();
            lblTieuDe = new Label();
            lblPhuDe = new Label();

            pnlTimKiem = new Panel();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnTaiLai = new Button();

            lblMaSP = new Label();
            lblTenSP = new Label();
            lblLoaiSP = new Label();
            lblThuongHieu = new Label();
            lblDonViTinh = new Label();
            lblGiaBan = new Label();
            lblSoLuongTon = new Label();
            lblMoTa = new Label();

            txtMaSP = new TextBox();
            txtTenSP = new TextBox();
            txtThuongHieu = new TextBox();
            txtGiaBan = new TextBox();
            txtSoLuongTon = new TextBox();
            txtMoTa = new TextBox();

            cboLoaiSP = new ComboBox();
            cboDonViTinh = new ComboBox();

            btnThem = new Button();
            btnSua = new Button();
            btnLamMoi = new Button();
            btnNgungKinhDoanh = new Button();

            dgvSanPham = new DataGridView();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colGiaBan = new DataGridViewTextBoxColumn();
            colSoLuongTon = new DataGridViewTextBoxColumn();

            pnlHeader.SuspendLayout();
            pnlTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
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
            lblTieuDe.Size = new Size(359, 46);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÝ SẢN PHẨM";

            // lblPhuDe
            lblPhuDe.AutoSize = true;
            lblPhuDe.Font = new Font("Segoe UI", 10F);
            lblPhuDe.ForeColor = Color.White;
            lblPhuDe.Location = new Point(25, 52);
            lblPhuDe.Name = "lblPhuDe";
            lblPhuDe.Size = new Size(329, 23);
            lblPhuDe.TabIndex = 1;
            lblPhuDe.Text = "Quản lý danh mục và thông tin sản phẩm";

            // pnlTimKiem
            pnlTimKiem.BackColor = Color.FromArgb(239, 246, 255);
            pnlTimKiem.Controls.Add(lblTimKiem);
            pnlTimKiem.Controls.Add(txtTimKiem);
            pnlTimKiem.Controls.Add(btnTimKiem);
            pnlTimKiem.Controls.Add(btnTaiLai);
            pnlTimKiem.Location = new Point(30, 425);
            pnlTimKiem.Name = "pnlTimKiem";
            pnlTimKiem.Size = new Size(1205, 65);
            pnlTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTimKiem.TabIndex = 21;

            // lblTimKiem
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTimKiem.ForeColor = Color.FromArgb(30, 64, 175);
            lblTimKiem.Location = new Point(25, 21);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(168, 23);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm sản phẩm";

            // txtTimKiem
            txtTimKiem.Location = new Point(220, 16);
            txtTimKiem.Name = "txtTimKiem";
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

            // btnTaiLai
            btnTaiLai.BackColor = Color.FromArgb(219, 234, 254);
            btnTaiLai.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            btnTaiLai.FlatStyle = FlatStyle.Flat;
            btnTaiLai.ForeColor = Color.FromArgb(30, 64, 175);
            btnTaiLai.Location = new Point(755, 13);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(110, 36);
            btnTaiLai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTaiLai.TabIndex = 3;
            btnTaiLai.Text = "Tải lại";
            btnTaiLai.UseVisualStyleBackColor = false;

            // lblMaSP
            lblMaSP.AutoSize = true;
            lblMaSP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaSP.ForeColor = Color.FromArgb(30, 41, 59);
            lblMaSP.Location = new Point(30, 130);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(122, 23);
            lblMaSP.TabIndex = 1;
            lblMaSP.Text = "Mã sản phẩm:";

            // lblTenSP
            lblTenSP.AutoSize = true;
            lblTenSP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTenSP.ForeColor = Color.FromArgb(30, 41, 59);
            lblTenSP.Location = new Point(530, 130);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(124, 23);
            lblTenSP.TabIndex = 3;
            lblTenSP.Text = "Tên sản phẩm:";

            // lblLoaiSP
            lblLoaiSP.AutoSize = true;
            lblLoaiSP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLoaiSP.ForeColor = Color.FromArgb(30, 41, 59);
            lblLoaiSP.Location = new Point(30, 180);
            lblLoaiSP.Name = "lblLoaiSP";
            lblLoaiSP.Size = new Size(130, 23);
            lblLoaiSP.TabIndex = 5;
            lblLoaiSP.Text = "Loại sản phẩm:";

            // lblThuongHieu
            lblThuongHieu.AutoSize = true;
            lblThuongHieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblThuongHieu.ForeColor = Color.FromArgb(30, 41, 59);
            lblThuongHieu.Location = new Point(530, 180);
            lblThuongHieu.Name = "lblThuongHieu";
            lblThuongHieu.Size = new Size(117, 23);
            lblThuongHieu.TabIndex = 7;
            lblThuongHieu.Text = "Thương hiệu:";

            // lblDonViTinh
            lblDonViTinh.AutoSize = true;
            lblDonViTinh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDonViTinh.ForeColor = Color.FromArgb(30, 41, 59);
            lblDonViTinh.Location = new Point(530, 230);
            lblDonViTinh.Name = "lblDonViTinh";
            lblDonViTinh.Size = new Size(105, 23);
            lblDonViTinh.TabIndex = 11;
            lblDonViTinh.Text = "Đơn vị tính:";

            // lblGiaBan
            lblGiaBan.AutoSize = true;
            lblGiaBan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGiaBan.ForeColor = Color.FromArgb(30, 41, 59);
            lblGiaBan.Location = new Point(30, 230);
            lblGiaBan.Name = "lblGiaBan";
            lblGiaBan.Size = new Size(130, 23);
            lblGiaBan.TabIndex = 9;
            lblGiaBan.Text = "Giá bán (VNĐ):";

            // lblSoLuongTon
            lblSoLuongTon.AutoSize = true;
            lblSoLuongTon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSoLuongTon.ForeColor = Color.FromArgb(30, 41, 59);
            lblSoLuongTon.Location = new Point(30, 280);
            lblSoLuongTon.Name = "lblSoLuongTon";
            lblSoLuongTon.Size = new Size(120, 23);
            lblSoLuongTon.TabIndex = 13;
            lblSoLuongTon.Text = "Số lượng tồn:";

            // lblMoTa
            lblMoTa.AutoSize = true;
            lblMoTa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMoTa.ForeColor = Color.FromArgb(30, 41, 59);
            lblMoTa.Location = new Point(530, 280);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(62, 23);
            lblMoTa.TabIndex = 15;
            lblMoTa.Text = "Mô tả:";

            // txtMaSP
            txtMaSP.BackColor = Color.FromArgb(239, 246, 255);
            txtMaSP.Location = new Point(180, 126);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.ReadOnly = true;
            txtMaSP.Size = new Size(300, 30);
            txtMaSP.TabIndex = 2;

            // txtTenSP
            txtTenSP.Location = new Point(680, 126);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(400, 30);
            txtTenSP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTenSP.TabIndex = 4;

            // txtThuongHieu
            txtThuongHieu.Location = new Point(680, 176);
            txtThuongHieu.Name = "txtThuongHieu";
            txtThuongHieu.Size = new Size(400, 30);
            txtThuongHieu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtThuongHieu.TabIndex = 8;

            // txtGiaBan
            txtGiaBan.Location = new Point(180, 226);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(300, 30);
            txtGiaBan.TabIndex = 10;

            // txtSoLuongTon
            txtSoLuongTon.BackColor = Color.FromArgb(239, 246, 255);
            txtSoLuongTon.Location = new Point(180, 276);
            txtSoLuongTon.Name = "txtSoLuongTon";
            txtSoLuongTon.ReadOnly = true;
            txtSoLuongTon.Size = new Size(300, 30);
            txtSoLuongTon.TabIndex = 14;

            // txtMoTa
            txtMoTa.Location = new Point(680, 276);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(500, 55);
            txtMoTa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMoTa.TabIndex = 16;

            // cboLoaiSP
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.Location = new Point(180, 176);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(300, 31);
            cboLoaiSP.TabIndex = 6;

            // cboDonViTinh
            cboDonViTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDonViTinh.Location = new Point(680, 226);
            cboDonViTinh.Name = "cboDonViTinh";
            cboDonViTinh.Size = new Size(400, 31);
            cboDonViTinh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboDonViTinh.TabIndex = 12;

            // btnThem
            btnThem.BackColor = Color.FromArgb(37, 99, 235);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(30, 355);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(150, 42);
            btnThem.TabIndex = 17;
            btnThem.Text = "Thêm sản phẩm";
            btnThem.UseVisualStyleBackColor = false;

            // btnSua
            btnSua.BackColor = Color.FromArgb(219, 234, 254);
            btnSua.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.FromArgb(30, 64, 175);
            btnSua.Location = new Point(195, 355);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(150, 42);
            btnSua.TabIndex = 18;
            btnSua.Text = "Cập nhật";
            btnSua.UseVisualStyleBackColor = false;

            // btnLamMoi
            btnLamMoi.BackColor = Color.FromArgb(239, 246, 255);
            btnLamMoi.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.FromArgb(30, 64, 175);
            btnLamMoi.Location = new Point(360, 355);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(150, 42);
            btnLamMoi.TabIndex = 19;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;

            // btnNgungKinhDoanh
            btnNgungKinhDoanh.BackColor = Color.FromArgb(254, 226, 226);
            btnNgungKinhDoanh.FlatAppearance.BorderColor = Color.FromArgb(220, 38, 38);
            btnNgungKinhDoanh.FlatStyle = FlatStyle.Flat;
            btnNgungKinhDoanh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNgungKinhDoanh.ForeColor = Color.FromArgb(185, 28, 28);
            btnNgungKinhDoanh.Location = new Point(525, 355);
            btnNgungKinhDoanh.Name = "btnNgungKinhDoanh";
            btnNgungKinhDoanh.Size = new Size(180, 42);
            btnNgungKinhDoanh.TabIndex = 20;
            btnNgungKinhDoanh.Text = "Ngừng kinh doanh";
            btnNgungKinhDoanh.UseVisualStyleBackColor = false;

            // dgvSanPham
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;

            dataGridViewCellStyle1.BackColor = Color.FromArgb(239, 246, 255);
            dgvSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;

            dgvSanPham.BackgroundColor = Color.White;
            dgvSanPham.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSanPham.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;

            dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSanPham.ColumnHeadersHeight = 40;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvSanPham.Columns.AddRange(new DataGridViewColumn[]
            {
                colMaSP,
                colTenSP,
                colGiaBan,
                colSoLuongTon
            });

            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(30, 64, 175);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(191, 219, 254);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(30, 64, 175);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;

            dgvSanPham.DefaultCellStyle = dataGridViewCellStyle3;
            dgvSanPham.EnableHeadersVisualStyles = false;

            dgvSanPham.Location = new Point(30, 510);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.Size = new Size(1205, 315);

            // Quan trọng: bảng co giãn theo cả chiều ngang và chiều dọc
            dgvSanPham.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            // Các cột tự chia đều chiều rộng bảng
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvSanPham.MultiSelect = false;
            dgvSanPham.ReadOnly = true;
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.RowTemplate.Height = 36;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.TabIndex = 22;
            dgvSanPham.CellContentClick += dgvSanPham_CellContentClick;

            // colMaSP
            colMaSP.DataPropertyName = "MaSanPham";
            colMaSP.HeaderText = "Mã sản phẩm";
            colMaSP.MinimumWidth = 100;
            colMaSP.Name = "colMaSP";
            colMaSP.ReadOnly = true;
            colMaSP.FillWeight = 20;

            // colTenSP
            colTenSP.DataPropertyName = "TenSanPham";
            colTenSP.HeaderText = "Tên sản phẩm";
            colTenSP.MinimumWidth = 150;
            colTenSP.Name = "colTenSP";
            colTenSP.ReadOnly = true;
            colTenSP.FillWeight = 40;

            // colGiaBan
            colGiaBan.DataPropertyName = "GiaBan";
            colGiaBan.HeaderText = "Giá bán (VNĐ)";
            colGiaBan.MinimumWidth = 120;
            colGiaBan.Name = "colGiaBan";
            colGiaBan.ReadOnly = true;
            colGiaBan.FillWeight = 25;

            // colSoLuongTon
            colSoLuongTon.DataPropertyName = "SoLuongTon";
            colSoLuongTon.HeaderText = "Số lượng tồn";
            colSoLuongTon.MinimumWidth = 110;
            colSoLuongTon.Name = "colSoLuongTon";
            colSoLuongTon.ReadOnly = true;
            colSoLuongTon.FillWeight = 15;

            // FrmSanPham
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1265, 824);

            Controls.Add(pnlHeader);
            Controls.Add(lblMaSP);
            Controls.Add(txtMaSP);
            Controls.Add(lblTenSP);
            Controls.Add(txtTenSP);
            Controls.Add(lblLoaiSP);
            Controls.Add(cboLoaiSP);
            Controls.Add(lblThuongHieu);
            Controls.Add(txtThuongHieu);
            Controls.Add(lblGiaBan);
            Controls.Add(txtGiaBan);
            Controls.Add(lblDonViTinh);
            Controls.Add(cboDonViTinh);
            Controls.Add(lblSoLuongTon);
            Controls.Add(txtSoLuongTon);
            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnLamMoi);
            Controls.Add(btnNgungKinhDoanh);
            Controls.Add(pnlTimKiem);
            Controls.Add(dgvSanPham);

            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1100, 750);
            Name = "FrmSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ SẢN PHẨM";

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlTimKiem.ResumeLayout(false);
            pnlTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
