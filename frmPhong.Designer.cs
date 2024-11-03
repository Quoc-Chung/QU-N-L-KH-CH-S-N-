
namespace BAITAPLON
{
	partial class frmPhong
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
			this.cboLoaiPhong = new System.Windows.Forms.ComboBox();
			this.txtMaPhong = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.radKhongTrong = new System.Windows.Forms.RadioButton();
			this.radTrong = new System.Windows.Forms.RadioButton();
			this.btnThoat = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnSua = new System.Windows.Forms.Button();
			this.grpFunction = new System.Windows.Forms.GroupBox();
			this.btnThem = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.grpFunction.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// cboLoaiPhong
			// 
			this.cboLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboLoaiPhong.Location = new System.Drawing.Point(98, 54);
			this.cboLoaiPhong.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.cboLoaiPhong.Name = "cboLoaiPhong";
			this.cboLoaiPhong.Size = new System.Drawing.Size(188, 23);
			this.cboLoaiPhong.TabIndex = 6;
			// 
			// txtMaPhong
			// 
			this.txtMaPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMaPhong.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaPhong.Location = new System.Drawing.Point(98, 19);
			this.txtMaPhong.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.txtMaPhong.Multiline = true;
			this.txtMaPhong.Name = "txtMaPhong";
			this.txtMaPhong.Size = new System.Drawing.Size(171, 25);
			this.txtMaPhong.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(9, 15);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(129, 28);
			this.label2.TabIndex = 9;
			this.label2.Text = "Mã số phòng:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(10, 54);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 28);
			this.label3.TabIndex = 8;
			this.label3.Text = "Loại phòng:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(7, 122);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 28);
			this.label1.TabIndex = 8;
			this.label1.Text = "Tình trạng:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.radKhongTrong);
			this.groupBox1.Controls.Add(this.radTrong);
			this.groupBox1.Controls.Add(this.cboLoaiPhong);
			this.groupBox1.Controls.Add(this.txtMaPhong);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(14, 15);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.groupBox1.Size = new System.Drawing.Size(323, 152);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(98, 86);
			this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(53, 25);
			this.numericUpDown1.TabIndex = 15;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(10, 86);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 28);
			this.label4.TabIndex = 14;
			this.label4.Text = "Tầng";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radKhongTrong
			// 
			this.radKhongTrong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radKhongTrong.Location = new System.Drawing.Point(157, 124);
			this.radKhongTrong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.radKhongTrong.Name = "radKhongTrong";
			this.radKhongTrong.Size = new System.Drawing.Size(84, 28);
			this.radKhongTrong.TabIndex = 13;
			this.radKhongTrong.TabStop = true;
			this.radKhongTrong.Text = "Không Trống";
			this.radKhongTrong.UseVisualStyleBackColor = true;
			this.radKhongTrong.CheckedChanged += new System.EventHandler(this.radKhongTrong_CheckedChanged);
			// 
			// radTrong
			// 
			this.radTrong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radTrong.Location = new System.Drawing.Point(98, 122);
			this.radTrong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.radTrong.Name = "radTrong";
			this.radTrong.Size = new System.Drawing.Size(53, 28);
			this.radTrong.TabIndex = 12;
			this.radTrong.TabStop = true;
			this.radTrong.Text = "Trống";
			this.radTrong.UseVisualStyleBackColor = true;
			// 
			// btnThoat
			// 
			this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThoat.Location = new System.Drawing.Point(9, 124);
			this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(94, 27);
			this.btnThoat.TabIndex = 3;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXoa.Location = new System.Drawing.Point(9, 83);
			this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(94, 27);
			this.btnXoa.TabIndex = 2;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// btnSua
			// 
			this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSua.Location = new System.Drawing.Point(8, 49);
			this.btnSua.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(94, 27);
			this.btnSua.TabIndex = 1;
			this.btnSua.Text = "Sửa";
			this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
			// 
			// grpFunction
			// 
			this.grpFunction.Controls.Add(this.btnThoat);
			this.grpFunction.Controls.Add(this.btnXoa);
			this.grpFunction.Controls.Add(this.btnSua);
			this.grpFunction.Controls.Add(this.btnThem);
			this.grpFunction.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.grpFunction.Location = new System.Drawing.Point(339, 15);
			this.grpFunction.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.grpFunction.Name = "grpFunction";
			this.grpFunction.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.grpFunction.Size = new System.Drawing.Size(110, 152);
			this.grpFunction.TabIndex = 8;
			this.grpFunction.TabStop = false;
			// 
			// btnThem
			// 
			this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThem.Location = new System.Drawing.Point(9, 15);
			this.btnThem.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(94, 27);
			this.btnThem.TabIndex = 0;
			this.btnThem.Text = "Thêm";
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// dataGridView
			// 
			this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(15, 177);
			this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersWidth = 51;
			this.dataGridView.RowTemplate.Height = 24;
			this.dataGridView.Size = new System.Drawing.Size(433, 150);
			this.dataGridView.TabIndex = 10;
			// 
			// frmPhong
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::BAITAPLON.Properties.Resources.anh4;
			this.ClientSize = new System.Drawing.Size(462, 338);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpFunction);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.Name = "frmPhong";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PHÒNG ";
			this.Load += new System.EventHandler(this.frmPhong_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.grpFunction.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ComboBox cboLoaiPhong;
		private System.Windows.Forms.TextBox txtMaPhong;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.GroupBox grpFunction;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.RadioButton radKhongTrong;
		private System.Windows.Forms.RadioButton radTrong;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
	}
}