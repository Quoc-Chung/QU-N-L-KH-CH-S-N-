
namespace BAITAPLON
{
    partial class frmThietBi
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
			this.txtMaTB = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTenTB = new System.Windows.Forms.TextBox();
			this.txtDVT = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtGia = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.grpFunction = new System.Windows.Forms.GroupBox();
			this.cmdExit = new System.Windows.Forms.Button();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdEdit = new System.Windows.Forms.Button();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.grpFunction.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtMaTB
			// 
			this.txtMaTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMaTB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaTB.Location = new System.Drawing.Point(160, 20);
			this.txtMaTB.Margin = new System.Windows.Forms.Padding(4);
			this.txtMaTB.Name = "txtMaTB";
			this.txtMaTB.Size = new System.Drawing.Size(105, 23);
			this.txtMaTB.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(11, 15);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(149, 30);
			this.label2.TabIndex = 9;
			this.label2.Text = "Mã thiết bị:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(11, 58);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(149, 30);
			this.label3.TabIndex = 8;
			this.label3.Text = "Tên thiết bị:";
			// 
			// txtTenTB
			// 
			this.txtTenTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTenTB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTenTB.Location = new System.Drawing.Point(160, 59);
			this.txtTenTB.Margin = new System.Windows.Forms.Padding(4);
			this.txtTenTB.Name = "txtTenTB";
			this.txtTenTB.Size = new System.Drawing.Size(308, 25);
			this.txtTenTB.TabIndex = 5;
			// 
			// txtDVT
			// 
			this.txtDVT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDVT.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDVT.Location = new System.Drawing.Point(160, 98);
			this.txtDVT.Margin = new System.Windows.Forms.Padding(4);
			this.txtDVT.Name = "txtDVT";
			this.txtDVT.Size = new System.Drawing.Size(95, 23);
			this.txtDVT.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(11, 98);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149, 30);
			this.label1.TabIndex = 8;
			this.label1.Text = "Đơn vị tính:";
			// 
			// txtGia
			// 
			this.txtGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGia.Location = new System.Drawing.Point(352, 98);
			this.txtGia.Margin = new System.Windows.Forms.Padding(4);
			this.txtGia.Name = "txtGia";
			this.txtGia.Size = new System.Drawing.Size(116, 23);
			this.txtGia.TabIndex = 5;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmdCancel);
			this.groupBox1.Controls.Add(this.txtMaTB);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtTenTB);
			this.groupBox1.Controls.Add(this.txtDVT);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtGia);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(16, 15);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(640, 138);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			// 
			// cmdCancel
			// 
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdCancel.Location = new System.Drawing.Point(523, 71);
			this.cmdCancel.Margin = new System.Windows.Forms.Padding(4);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(96, 28);
			this.cmdCancel.TabIndex = 10;
			this.cmdCancel.Text = "Hủy bỏ";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(299, 98);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 30);
			this.label4.TabIndex = 8;
			this.label4.Text = "Giá:";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 171);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(644, 316);
			this.dataGridView1.TabIndex = 10;
			// 
			// grpFunction
			// 
			this.grpFunction.BackgroundImage = global::BAITAPLON.Properties.Resources.anh51;
			this.grpFunction.Controls.Add(this.cmdExit);
			this.grpFunction.Controls.Add(this.cmdDelete);
			this.grpFunction.Controls.Add(this.cmdEdit);
			this.grpFunction.Controls.Add(this.cmdAdd);
			this.grpFunction.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.grpFunction.Location = new System.Drawing.Point(667, 15);
			this.grpFunction.Margin = new System.Windows.Forms.Padding(4);
			this.grpFunction.Name = "grpFunction";
			this.grpFunction.Padding = new System.Windows.Forms.Padding(4);
			this.grpFunction.Size = new System.Drawing.Size(139, 223);
			this.grpFunction.TabIndex = 8;
			this.grpFunction.TabStop = false;
			// 
			// cmdExit
			// 
			this.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdExit.Location = new System.Drawing.Point(22, 175);
			this.cmdExit.Margin = new System.Windows.Forms.Padding(4);
			this.cmdExit.Name = "cmdExit";
			this.cmdExit.Size = new System.Drawing.Size(96, 28);
			this.cmdExit.TabIndex = 3;
			this.cmdExit.Text = "Thoát";
			this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
			// 
			// cmdDelete
			// 
			this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdDelete.Location = new System.Drawing.Point(22, 123);
			this.cmdDelete.Margin = new System.Windows.Forms.Padding(4);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(96, 28);
			this.cmdDelete.TabIndex = 2;
			this.cmdDelete.Text = "Xóa";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdEdit
			// 
			this.cmdEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdEdit.Location = new System.Drawing.Point(22, 71);
			this.cmdEdit.Margin = new System.Windows.Forms.Padding(4);
			this.cmdEdit.Name = "cmdEdit";
			this.cmdEdit.Size = new System.Drawing.Size(96, 28);
			this.cmdEdit.TabIndex = 1;
			this.cmdEdit.Text = "Sửa";
			this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
			// 
			// cmdAdd
			// 
			this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdAdd.Location = new System.Drawing.Point(22, 23);
			this.cmdAdd.Margin = new System.Windows.Forms.Padding(4);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(96, 28);
			this.cmdAdd.TabIndex = 0;
			this.cmdAdd.Text = "Thêm";
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// frmThietBi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::BAITAPLON.Properties.Resources.anh51;
			this.ClientSize = new System.Drawing.Size(833, 516);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpFunction);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmThietBi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "THIẾT BỊ";
			this.Load += new System.EventHandler(this.frmThietBi_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.grpFunction.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtMaTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.GroupBox grpFunction;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox txtDVT;
		private System.Windows.Forms.Button cmdCancel;
	}
}