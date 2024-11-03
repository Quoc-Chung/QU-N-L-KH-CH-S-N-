
namespace BAITAPLON
{
	partial class frmNV
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
			this.dTPicker_NSinh = new System.Windows.Forms.DateTimePicker();
			this.optNam = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnThemAnh = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtMaNV = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTenNV = new System.Windows.Forms.TextBox();
			this.txtMKhau = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDChi = new System.Windows.Forms.TextBox();
			this.txtDThoai = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.optNu = new System.Windows.Forms.RadioButton();
			this.dTPicker_NVaoLam = new System.Windows.Forms.DateTimePicker();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.grpFunction = new System.Windows.Forms.GroupBox();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.grpFunction.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// dTPicker_NSinh
			// 
			this.dTPicker_NSinh.CustomFormat = "\"dd mm yyyy\"";
			this.dTPicker_NSinh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dTPicker_NSinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dTPicker_NSinh.Location = new System.Drawing.Point(160, 172);
			this.dTPicker_NSinh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dTPicker_NSinh.Name = "dTPicker_NSinh";
			this.dTPicker_NSinh.Size = new System.Drawing.Size(169, 23);
			this.dTPicker_NSinh.TabIndex = 5;
			// 
			// optNam
			// 
			this.optNam.Checked = true;
			this.optNam.Location = new System.Drawing.Point(160, 221);
			this.optNam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.optNam.Name = "optNam";
			this.optNam.Size = new System.Drawing.Size(85, 38);
			this.optNam.TabIndex = 6;
			this.optNam.TabStop = true;
			this.optNam.Text = "Nam";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnThemAnh);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.dTPicker_NSinh);
			this.groupBox1.Controls.Add(this.optNam);
			this.groupBox1.Controls.Add(this.txtMaNV);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtTenNV);
			this.groupBox1.Controls.Add(this.txtMKhau);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtDChi);
			this.groupBox1.Controls.Add(this.txtDThoai);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.optNu);
			this.groupBox1.Controls.Add(this.dTPicker_NVaoLam);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(16, 19);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Size = new System.Drawing.Size(715, 403);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// btnThemAnh
			// 
			this.btnThemAnh.BackColor = System.Drawing.SystemColors.Control;
			this.btnThemAnh.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnThemAnh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThemAnh.Location = new System.Drawing.Point(551, 246);
			this.btnThemAnh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnThemAnh.Name = "btnThemAnh";
			this.btnThemAnh.Size = new System.Drawing.Size(96, 35);
			this.btnThemAnh.TabIndex = 4;
			this.btnThemAnh.Text = "Thêm ảnh";
			this.btnThemAnh.UseVisualStyleBackColor = false;
			this.btnThemAnh.Click += new System.EventHandler(this.btnThemAnh_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(510, 25);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(184, 204);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			// 
			// txtMaNV
			// 
			this.txtMaNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMaNV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaNV.Location = new System.Drawing.Point(160, 25);
			this.txtMaNV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtMaNV.Name = "txtMaNV";
			this.txtMaNV.Size = new System.Drawing.Size(169, 27);
			this.txtMaNV.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 18);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(149, 38);
			this.label2.TabIndex = 9;
			this.label2.Text = "Mã nhân viên:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 62);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(149, 38);
			this.label3.TabIndex = 8;
			this.label3.Text = "Họ tên:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTenNV
			// 
			this.txtTenNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTenNV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTenNV.Location = new System.Drawing.Point(160, 68);
			this.txtTenNV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtTenNV.Name = "txtTenNV";
			this.txtTenNV.Size = new System.Drawing.Size(255, 27);
			this.txtTenNV.TabIndex = 2;
			// 
			// txtMKhau
			// 
			this.txtMKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMKhau.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMKhau.Location = new System.Drawing.Point(160, 122);
			this.txtMKhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtMKhau.Name = "txtMKhau";
			this.txtMKhau.PasswordChar = '*';
			this.txtMKhau.Size = new System.Drawing.Size(116, 23);
			this.txtMKhau.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(11, 122);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149, 38);
			this.label1.TabIndex = 8;
			this.label1.Text = "Mật khẩu:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 165);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(139, 38);
			this.label4.TabIndex = 8;
			this.label4.Text = "Ngày sinh:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(11, 264);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(149, 38);
			this.label5.TabIndex = 8;
			this.label5.Text = "Địa chỉ:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDChi
			// 
			this.txtDChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDChi.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDChi.Location = new System.Drawing.Point(160, 271);
			this.txtDChi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDChi.Name = "txtDChi";
			this.txtDChi.Size = new System.Drawing.Size(255, 23);
			this.txtDChi.TabIndex = 8;
			// 
			// txtDThoai
			// 
			this.txtDThoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDThoai.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDThoai.Location = new System.Drawing.Point(160, 320);
			this.txtDThoai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDThoai.Name = "txtDThoai";
			this.txtDThoai.Size = new System.Drawing.Size(169, 23);
			this.txtDThoai.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(11, 311);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(149, 38);
			this.label6.TabIndex = 8;
			this.label6.Text = "Điện thoại:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(11, 358);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(149, 38);
			this.label7.TabIndex = 8;
			this.label7.Text = "Ngày vào làm:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(11, 221);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(139, 38);
			this.label9.TabIndex = 8;
			this.label9.Text = "Giới tính:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// optNu
			// 
			this.optNu.Location = new System.Drawing.Point(309, 221);
			this.optNu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.optNu.Name = "optNu";
			this.optNu.Size = new System.Drawing.Size(75, 38);
			this.optNu.TabIndex = 7;
			this.optNu.Text = "Nữ";
			// 
			// dTPicker_NVaoLam
			// 
			this.dTPicker_NVaoLam.CustomFormat = "\"dd mm yyyy\"";
			this.dTPicker_NVaoLam.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dTPicker_NVaoLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dTPicker_NVaoLam.Location = new System.Drawing.Point(160, 369);
			this.dTPicker_NVaoLam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dTPicker_NVaoLam.Name = "dTPicker_NVaoLam";
			this.dTPicker_NVaoLam.Size = new System.Drawing.Size(169, 23);
			this.dTPicker_NVaoLam.TabIndex = 10;
			// 
			// cmdExit
			// 
			this.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExit.Location = new System.Drawing.Point(11, 209);
			this.cmdExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.Size = new System.Drawing.Size(119, 35);
			this.cmdExit.TabIndex = 3;
			this.cmdExit.Text = "Thoát";
			this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdDelete.Location = new System.Drawing.Point(11, 146);
			this.cmdDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(119, 35);
			this.cmdDelete.TabIndex = 2;
			this.cmdDelete.Text = "Xóa";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdEdit.Location = new System.Drawing.Point(11, 86);
			this.cmdEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.Size = new System.Drawing.Size(119, 35);
			this.cmdEdit.TabIndex = 1;
			this.cmdEdit.Text = "Sửa";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAdd.Location = new System.Drawing.Point(11, 25);
			this.cmdAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(119, 35);
			this.cmdAdd.TabIndex = 0;
			this.cmdAdd.Text = "Thêm";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// grpFunction
			// 
			this.grpFunction.Controls.Add(this.cmdExit);
			this.grpFunction.Controls.Add(this.cmdDelete);
			this.grpFunction.Controls.Add(this.cmdEdit);
			this.grpFunction.Controls.Add(this.cmdAdd);
			this.grpFunction.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.grpFunction.Location = new System.Drawing.Point(741, 19);
			this.grpFunction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.grpFunction.Name = "grpFunction";
			this.grpFunction.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.grpFunction.Size = new System.Drawing.Size(138, 403);
			this.grpFunction.TabIndex = 8;
			this.grpFunction.TabStop = false;
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(16, 431);
			this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersWidth = 51;
			this.dataGridView.RowTemplate.Height = 24;
			this.dataGridView.Size = new System.Drawing.Size(863, 327);
			this.dataGridView.TabIndex = 10;
			this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
			// 
			// frmNV
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::BAITAPLON.Properties.Resources.anh9;
			this.ClientSize = new System.Drawing.Size(892, 772);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpFunction);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "frmNV";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NHÂN VIÊN";
			this.Load += new System.EventHandler(this.frmNV_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.grpFunction.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.DateTimePicker dTPicker_NSinh;
		private System.Windows.Forms.RadioButton optNam;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtMaNV;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTenNV;
		private System.Windows.Forms.TextBox txtMKhau;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDChi;
		private System.Windows.Forms.TextBox txtDThoai;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.RadioButton optNu;
		private System.Windows.Forms.DateTimePicker dTPicker_NVaoLam;
		private System.Windows.Forms.Button cmdExit;
		private System.Windows.Forms.Button cmdDelete;
		private System.Windows.Forms.Button cmdEdit;
		private System.Windows.Forms.Button cmdAdd;
		private System.Windows.Forms.GroupBox grpFunction;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button btnThemAnh;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}