﻿namespace BAITAPLON
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQLKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSDDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThanhToan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTimKiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTimKiemPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnCauHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTrangBi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTrangBiPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLoaiPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTrangThietBi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTrangThietBiPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpLạiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.lblTenTaiKhoan = new System.Windows.Forms.Label();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnQuanLy,
            this.mnTimKiem,
            this.mnCauHinh,
            this.trợGiúpToolStripMenuItem,
            this.quanliToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(729, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnQuanLy
            // 
            this.mnQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnQLKhachHang,
            this.mnSDDichVu,
            this.mnThanhToan,
            this.mnThoat});
            this.mnQuanLy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnQuanLy.Image = global::BAITAPLON.Properties.Resources.icons8_service_50;
            this.mnQuanLy.Name = "mnQuanLy";
            this.mnQuanLy.Size = new System.Drawing.Size(89, 24);
            this.mnQuanLy.Text = "Dịch Vụ";
            // 
            // mnQLKhachHang
            // 
            this.mnQLKhachHang.Name = "mnQLKhachHang";
            this.mnQLKhachHang.Size = new System.Drawing.Size(220, 22);
            this.mnQLKhachHang.Text = "Khách Hàng Đặt Phòng";
            this.mnQLKhachHang.Click += new System.EventHandler(this.mnQLKhachHang_Click);
            // 
            // mnSDDichVu
            // 
            this.mnSDDichVu.Name = "mnSDDichVu";
            this.mnSDDichVu.Size = new System.Drawing.Size(220, 22);
            this.mnSDDichVu.Text = "Sử Dụng Dịch Vụ";
            this.mnSDDichVu.Click += new System.EventHandler(this.mnSDDichVu_Click);
            // 
            // mnThanhToan
            // 
            this.mnThanhToan.Name = "mnThanhToan";
            this.mnThanhToan.Size = new System.Drawing.Size(220, 22);
            this.mnThanhToan.Text = "Thanh Toán Phòng";
            this.mnThanhToan.Click += new System.EventHandler(this.mnThanhToan_Click);
            // 
            // mnThoat
            // 
            this.mnThoat.Name = "mnThoat";
            this.mnThoat.Size = new System.Drawing.Size(220, 22);
            this.mnThoat.Text = "Thoát";
            // 
            // mnTimKiem
            // 
            this.mnTimKiem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnTimKiemPhong,
            this.mnKhachHang});
            this.mnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnTimKiem.Image = global::BAITAPLON.Properties.Resources.icons8_search_100;
            this.mnTimKiem.Name = "mnTimKiem";
            this.mnTimKiem.Size = new System.Drawing.Size(99, 24);
            this.mnTimKiem.Text = "Tìm Kiếm";
            // 
            // mnTimKiemPhong
            // 
            this.mnTimKiemPhong.Name = "mnTimKiemPhong";
            this.mnTimKiemPhong.Size = new System.Drawing.Size(150, 22);
            this.mnTimKiemPhong.Text = "Phòng";
            this.mnTimKiemPhong.Click += new System.EventHandler(this.mnTimKiemPhong_Click);
            // 
            // mnKhachHang
            // 
            this.mnKhachHang.Name = "mnKhachHang";
            this.mnKhachHang.Size = new System.Drawing.Size(150, 22);
            this.mnKhachHang.Text = "Khách Hàng";
            this.mnKhachHang.Click += new System.EventHandler(this.mnKhachHang_Click);
            // 
            // mnCauHinh
            // 
            this.mnCauHinh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnTrangBi});
            this.mnCauHinh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnCauHinh.Image = global::BAITAPLON.Properties.Resources.icons8_config_100__1_;
            this.mnCauHinh.Name = "mnCauHinh";
            this.mnCauHinh.Size = new System.Drawing.Size(97, 24);
            this.mnCauHinh.Text = "Cấu Hình";
            // 
            // mnTrangBi
            // 
            this.mnTrangBi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnTrangBiPhong,
            this.mnLoaiPhong,
            this.mnTrangThietBi,
            this.mnTrangThietBiPhong});
            this.mnTrangBi.Name = "mnTrangBi";
            this.mnTrangBi.Size = new System.Drawing.Size(127, 22);
            this.mnTrangBi.Text = "Trang Bị";
            // 
            // mnTrangBiPhong
            // 
            this.mnTrangBiPhong.Name = "mnTrangBiPhong";
            this.mnTrangBiPhong.Size = new System.Drawing.Size(290, 22);
            this.mnTrangBiPhong.Text = "Phòng";
            this.mnTrangBiPhong.Click += new System.EventHandler(this.mnTrangBiPhong_Click);
            // 
            // mnLoaiPhong
            // 
            this.mnLoaiPhong.Name = "mnLoaiPhong";
            this.mnLoaiPhong.Size = new System.Drawing.Size(290, 22);
            this.mnLoaiPhong.Text = "Loại Phòng";
            this.mnLoaiPhong.Click += new System.EventHandler(this.mnLoaiPhong_Click);
            // 
            // mnTrangThietBi
            // 
            this.mnTrangThietBi.Name = "mnTrangThietBi";
            this.mnTrangThietBi.Size = new System.Drawing.Size(290, 22);
            this.mnTrangThietBi.Text = "Nhập Trang Thiết Bị";
            this.mnTrangThietBi.Click += new System.EventHandler(this.mnTrangThietBi_Click);
            // 
            // mnTrangThietBiPhong
            // 
            this.mnTrangThietBiPhong.Name = "mnTrangThietBiPhong";
            this.mnTrangThietBiPhong.Size = new System.Drawing.Size(290, 22);
            this.mnTrangThietBiPhong.Text = "Trang Bị Trang Thiết Bị Cho Phòng";
            this.mnTrangThietBiPhong.Click += new System.EventHandler(this.mnTrangThietBiPhong_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpLạiMậtKhẩuToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.trợGiúpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trợGiúpToolStripMenuItem.Image = global::BAITAPLON.Properties.Resources.icons8_support_100;
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.trợGiúpToolStripMenuItem.Text = "Trợ Giúp";
            // 
            // nhậpLạiMậtKhẩuToolStripMenuItem
            // 
            this.nhậpLạiMậtKhẩuToolStripMenuItem.Name = "nhậpLạiMậtKhẩuToolStripMenuItem";
            this.nhậpLạiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.nhậpLạiMậtKhẩuToolStripMenuItem.Text = "Nhập  Lại Mật Khẩu";
            this.nhậpLạiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.nhậpLạiMậtKhẩuToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // quanliToolStripMenuItem
            // 
            this.quanliToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLíNhânViênToolStripMenuItem,
            this.quảnLýToolStripMenuItem1});
            this.quanliToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanliToolStripMenuItem.Image = global::BAITAPLON.Properties.Resources.icons8_manage_100;
            this.quanliToolStripMenuItem.Name = "quanliToolStripMenuItem";
            this.quanliToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.quanliToolStripMenuItem.Text = "Quản Lý";
            // 
            // quảnLíNhânViênToolStripMenuItem
            // 
            this.quảnLíNhânViênToolStripMenuItem.Name = "quảnLíNhânViênToolStripMenuItem";
            this.quảnLíNhânViênToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.quảnLíNhânViênToolStripMenuItem.Text = "Quản Lý Nhân Viên";
            this.quảnLíNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLíNhânViênToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem1
            // 
            this.quảnLýToolStripMenuItem1.Name = "quảnLýToolStripMenuItem1";
            this.quảnLýToolStripMenuItem1.Size = new System.Drawing.Size(200, 22);
            this.quảnLýToolStripMenuItem1.Text = "Quản Lý Doanh Thu";
            this.quảnLýToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýToolStripMenuItem1_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(273, 0);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(8, 8);
            this.hScrollBar1.TabIndex = 1;
            // 
            // lblTenTaiKhoan
            // 
            this.lblTenTaiKhoan.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblTenTaiKhoan.Location = new System.Drawing.Point(42, 335);
            this.lblTenTaiKhoan.Name = "lblTenTaiKhoan";
            this.lblTenTaiKhoan.Size = new System.Drawing.Size(105, 22);
            this.lblTenTaiKhoan.TabIndex = 3;
            this.lblTenTaiKhoan.Text = "NHÂN VIÊN";
            this.lblTenTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNhanVien.ForeColor = System.Drawing.Color.Red;
            this.lblTenNhanVien.Location = new System.Drawing.Point(153, 335);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(194, 22);
            this.lblTenNhanVien.TabIndex = 4;
            this.lblTenNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(393, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "NGÀY SINH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.ForeColor = System.Drawing.Color.Red;
            this.lblNgaySinh.Location = new System.Drawing.Point(493, 335);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(194, 22);
            this.lblNgaySinh.TabIndex = 6;
            this.lblNgaySinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BAITAPLON.Properties.Resources.lodo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(12, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 292);
            this.panel1.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 373);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTenNhanVien);
            this.Controls.Add(this.lblTenTaiKhoan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRANG CHỦ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnQuanLy;
		private System.Windows.Forms.ToolStripMenuItem mnQLKhachHang;
		private System.Windows.Forms.ToolStripMenuItem mnSDDichVu;
		private System.Windows.Forms.ToolStripMenuItem mnThanhToan;
		private System.Windows.Forms.ToolStripMenuItem mnThoat;
		private System.Windows.Forms.ToolStripMenuItem mnTimKiem;
		private System.Windows.Forms.ToolStripMenuItem mnTimKiemPhong;
		private System.Windows.Forms.ToolStripMenuItem mnKhachHang;
		private System.Windows.Forms.ToolStripMenuItem mnCauHinh;
		private System.Windows.Forms.HScrollBar hScrollBar1;
		private System.Windows.Forms.ToolStripMenuItem mnTrangBi;
		private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnTrangBiPhong;
		private System.Windows.Forms.ToolStripMenuItem mnLoaiPhong;
		private System.Windows.Forms.ToolStripMenuItem mnTrangThietBi;
		private System.Windows.Forms.ToolStripMenuItem mnTrangThietBiPhong;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblTenTaiKhoan;
		private System.Windows.Forms.Label lblTenNhanVien;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblNgaySinh;
		private System.Windows.Forms.ToolStripMenuItem nhậpLạiMậtKhẩuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem1;
    }
}

