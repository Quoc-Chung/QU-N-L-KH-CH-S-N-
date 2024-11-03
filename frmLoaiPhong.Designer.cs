using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BAITAPLON
{
	partial class frmLoaiPhong
	{

		/// <summary>


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
			this.txtMaLoaiP = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLoaiP = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnThoat = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnSua = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.txtGia = new System.Windows.Forms.TextBox();
			this.grpFunction = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnHuyBo = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.grpFunction.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// txtMaLoaiP
			// 
			this.txtMaLoaiP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMaLoaiP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaLoaiP.Location = new System.Drawing.Point(140, 19);
			this.txtMaLoaiP.Margin = new System.Windows.Forms.Padding(4);
			this.txtMaLoaiP.Multiline = true;
			this.txtMaLoaiP.Name = "txtMaLoaiP";
			this.txtMaLoaiP.Size = new System.Drawing.Size(83, 21);
			this.txtMaLoaiP.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 12);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(131, 27);
			this.label2.TabIndex = 9;
			this.label2.Text = "Mã số loại phòng:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(9, 54);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(131, 27);
			this.label3.TabIndex = 8;
			this.label3.Text = "Loại phòng:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLoaiP
			// 
			this.txtLoaiP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtLoaiP.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLoaiP.Location = new System.Drawing.Point(140, 56);
			this.txtLoaiP.Margin = new System.Windows.Forms.Padding(4);
			this.txtLoaiP.Multiline = true;
			this.txtLoaiP.Name = "txtLoaiP";
			this.txtLoaiP.Size = new System.Drawing.Size(83, 21);
			this.txtLoaiP.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(9, 93);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 27);
			this.label1.TabIndex = 8;
			this.label1.Text = "Giá tiền:";
			// 
			// btnThoat
			// 
			this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThoat.Location = new System.Drawing.Point(9, 129);
			this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
			this.btnThoat.Name = "btnThoat";
			this.btnThoat.Size = new System.Drawing.Size(84, 26);
			this.btnThoat.TabIndex = 3;
			this.btnThoat.Text = "Thoát";
			this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnXoa.Location = new System.Drawing.Point(9, 93);
			this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(84, 26);
			this.btnXoa.TabIndex = 2;
			this.btnXoa.Text = "Xóa";
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// btnSua
			// 
			this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSua.Location = new System.Drawing.Point(9, 56);
			this.btnSua.Margin = new System.Windows.Forms.Padding(4);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(84, 26);
			this.btnSua.TabIndex = 1;
			this.btnSua.Text = "Sửa";
			this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
			// 
			// btnThem
			// 
			this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnThem.Location = new System.Drawing.Point(9, 19);
			this.btnThem.Margin = new System.Windows.Forms.Padding(4);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(84, 26);
			this.btnThem.TabIndex = 0;
			this.btnThem.Text = "Thêm";
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// txtGia
			// 
			this.txtGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGia.Location = new System.Drawing.Point(140, 93);
			this.txtGia.Margin = new System.Windows.Forms.Padding(4);
			this.txtGia.Multiline = true;
			this.txtGia.Name = "txtGia";
			this.txtGia.Size = new System.Drawing.Size(83, 21);
			this.txtGia.TabIndex = 5;
			// 
			// grpFunction
			// 
			this.grpFunction.Controls.Add(this.btnThoat);
			this.grpFunction.Controls.Add(this.btnXoa);
			this.grpFunction.Controls.Add(this.btnSua);
			this.grpFunction.Controls.Add(this.btnThem);
			this.grpFunction.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.grpFunction.Location = new System.Drawing.Point(346, 14);
			this.grpFunction.Margin = new System.Windows.Forms.Padding(4);
			this.grpFunction.Name = "grpFunction";
			this.grpFunction.Padding = new System.Windows.Forms.Padding(4);
			this.grpFunction.Size = new System.Drawing.Size(103, 248);
			this.grpFunction.TabIndex = 8;
			this.grpFunction.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnHuyBo);
			this.groupBox1.Controls.Add(this.txtMaLoaiP);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtLoaiP);
			this.groupBox1.Controls.Add(this.txtGia);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(14, 14);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(324, 129);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// btnHuyBo
			// 
			this.btnHuyBo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnHuyBo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnHuyBo.Location = new System.Drawing.Point(231, 53);
			this.btnHuyBo.Margin = new System.Windows.Forms.Padding(4);
			this.btnHuyBo.Name = "btnHuyBo";
			this.btnHuyBo.Size = new System.Drawing.Size(84, 26);
			this.btnHuyBo.TabIndex = 11;
			this.btnHuyBo.Text = "Hủy Bỏ";
			this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(14, 150);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.Size = new System.Drawing.Size(324, 112);
			this.dataGridView1.TabIndex = 10;
			// 
			// frmLoaiPhong
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::BAITAPLON.Properties.Resources.anh3;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(457, 272);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.grpFunction);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmLoaiPhong";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LOẠI PHÒNG";
			this.Load += new System.EventHandler(this.frmLoaiPhong_Load);
			this.grpFunction.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtMaLoaiP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtLoaiP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.Button btnHuyBo;
		private System.Windows.Forms.TextBox txtGia;
		private System.Windows.Forms.GroupBox grpFunction;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView dataGridView1;

	}
}