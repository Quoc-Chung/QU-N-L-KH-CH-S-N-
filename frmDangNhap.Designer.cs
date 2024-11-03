namespace BAITAPLON
{
	partial class frmDangNhap
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtMatKhau = new System.Windows.Forms.TextBox();
			this.txtMaNhanVien = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnThoat = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnDangNhap = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.NavajoWhite;
			this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel2.Controls.Add(this.txtMatKhau);
			this.panel2.Controls.Add(this.txtMaNhanVien);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.btnThoat);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.btnDangNhap);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(378, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(238, 288);
			this.panel2.TabIndex = 8;
			// 
			// txtMatKhau
			// 
			this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMatKhau.Location = new System.Drawing.Point(80, 102);
			this.txtMatKhau.Multiline = true;
			this.txtMatKhau.Name = "txtMatKhau";
			this.txtMatKhau.Size = new System.Drawing.Size(141, 23);
			this.txtMatKhau.TabIndex = 3;
			// 
			// txtMaNhanVien
			// 
			this.txtMaNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMaNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaNhanVien.Location = new System.Drawing.Point(80, 54);
			this.txtMaNhanVien.Multiline = true;
			this.txtMaNhanVien.Name = "txtMaNhanVien";
			this.txtMaNhanVien.Size = new System.Drawing.Size(138, 23);
			this.txtMaNhanVien.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mã Số NV:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnThoat
			// 
			this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThoat.Location = new System.Drawing.Point(127, 151);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(78, 28);
			this.btnThoat.TabIndex = 6;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.UseVisualStyleBackColor = true;
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Mật Khẩu:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnDangNhap
			// 
			this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDangNhap.Location = new System.Drawing.Point(28, 151);
			this.btnDangNhap.Name = "btnDangNhap";
			this.btnDangNhap.Size = new System.Drawing.Size(80, 28);
			this.btnDangNhap.TabIndex = 5;
			this.btnDangNhap.Text = "Đăng Nhập";
			this.btnDangNhap.UseVisualStyleBackColor = true;
			this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
			// 
			// panel1
			// 
			this.panel1.BackgroundImage = global::BAITAPLON.Properties.Resources.lodo;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(378, 288);
			this.panel1.TabIndex = 7;
			// 
			// frmDangNhap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(616, 288);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmDangNhap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ĐĂNG NHẬP";
			this.Load += new System.EventHandler(this.frmDangNhap_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMatKhau;
		private System.Windows.Forms.TextBox txtMaNhanVien;
		private System.Windows.Forms.Button btnDangNhap;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
	}
}