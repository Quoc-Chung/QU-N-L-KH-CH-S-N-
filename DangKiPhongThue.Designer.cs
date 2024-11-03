namespace BAITAPLON
{
	partial class DangKiPhongThue
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
			System.Windows.Forms.Label txtMaPhong;
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnDangKi = new System.Windows.Forms.Button();
			this.btnThoat = new System.Windows.Forms.Button();
			this.dateTimeNgayThue = new System.Windows.Forms.DateTimePicker();
			this.dateTimeNgayTra = new System.Windows.Forms.DateTimePicker();
			this.txtMaPhongDangKi = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSoHoaDon = new System.Windows.Forms.TextBox();
			txtMaPhong = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtMaPhong
			// 
			txtMaPhong.AutoSize = true;
			txtMaPhong.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			txtMaPhong.ForeColor = System.Drawing.Color.Red;
			txtMaPhong.Location = new System.Drawing.Point(145, 26);
			txtMaPhong.Name = "txtMaPhong";
			txtMaPhong.Size = new System.Drawing.Size(0, 23);
			txtMaPhong.TabIndex = 18;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(27, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(84, 20);
			this.label6.TabIndex = 11;
			this.label6.Text = "Mã phòng:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(25, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 20);
			this.label4.TabIndex = 12;
			this.label4.Text = "Ngày thuê:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(27, 141);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 20);
			this.label5.TabIndex = 13;
			this.label5.Text = "Ngày trả";
			// 
			// btnDangKi
			// 
			this.btnDangKi.BackgroundImage = global::BAITAPLON.Properties.Resources.anh1;
			this.btnDangKi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnDangKi.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDangKi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDangKi.Location = new System.Drawing.Point(31, 183);
			this.btnDangKi.Margin = new System.Windows.Forms.Padding(4);
			this.btnDangKi.Name = "btnDangKi";
			this.btnDangKi.Size = new System.Drawing.Size(155, 41);
			this.btnDangKi.TabIndex = 14;
			this.btnDangKi.Text = "Đăng kí";
			this.btnDangKi.Click += new System.EventHandler(this.btnDangKi_Click);
			// 
			// btnThoat
			// 
			this.btnThoat.BackgroundImage = global::BAITAPLON.Properties.Resources.anh1;
			this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThoat.Location = new System.Drawing.Point(206, 183);
			this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(155, 41);
			this.btnThoat.TabIndex = 15;
			this.btnThoat.Text = "Thoát";
			// 
			// dateTimeNgayThue
			// 
			this.dateTimeNgayThue.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimeNgayThue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimeNgayThue.Location = new System.Drawing.Point(149, 80);
			this.dateTimeNgayThue.Name = "dateTimeNgayThue";
			this.dateTimeNgayThue.Size = new System.Drawing.Size(230, 30);
			this.dateTimeNgayThue.TabIndex = 16;
			// 
			// dateTimeNgayTra
			// 
			this.dateTimeNgayTra.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimeNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimeNgayTra.Location = new System.Drawing.Point(149, 131);
			this.dateTimeNgayTra.Name = "dateTimeNgayTra";
			this.dateTimeNgayTra.Size = new System.Drawing.Size(230, 30);
			this.dateTimeNgayTra.TabIndex = 17;
			// 
			// txtMaPhongDangKi
			// 
			this.txtMaPhongDangKi.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaPhongDangKi.ForeColor = System.Drawing.Color.Red;
			this.txtMaPhongDangKi.Location = new System.Drawing.Point(151, -1);
			this.txtMaPhongDangKi.Name = "txtMaPhongDangKi";
			this.txtMaPhongDangKi.Size = new System.Drawing.Size(131, 37);
			this.txtMaPhongDangKi.TabIndex = 19;
			this.txtMaPhongDangKi.Text = "Mã phòng";
			this.txtMaPhongDangKi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(27, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 20);
			this.label1.TabIndex = 20;
			this.label1.Text = "Số hóa đơn";
			// 
			// txtSoHoaDon
			// 
			this.txtSoHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSoHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSoHoaDon.Location = new System.Drawing.Point(152, 40);
			this.txtSoHoaDon.Name = "txtSoHoaDon";
			this.txtSoHoaDon.Size = new System.Drawing.Size(107, 27);
			this.txtSoHoaDon.TabIndex = 21;
			// 
			// DangKiPhongThue
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 244);
			this.Controls.Add(this.txtSoHoaDon);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtMaPhongDangKi);
			this.Controls.Add(txtMaPhong);
			this.Controls.Add(this.dateTimeNgayTra);
			this.Controls.Add(this.dateTimeNgayThue);
			this.Controls.Add(this.btnThoat);
			this.Controls.Add(this.btnDangKi);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Name = "DangKiPhongThue";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ĐĂNG KÍ PHÒNG THUÊ";
			this.Load += new System.EventHandler(this.DangKiPhongThue_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnDangKi;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.DateTimePicker dateTimeNgayThue;
		private System.Windows.Forms.DateTimePicker dateTimeNgayTra;
		private System.Windows.Forms.Label txtMaPhongDangKi;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSoHoaDon;
	}
}