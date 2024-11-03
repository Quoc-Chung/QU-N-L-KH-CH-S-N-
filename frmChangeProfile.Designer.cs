
namespace QLKS
{
    partial class frmChangeProfile
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMkCu = new System.Windows.Forms.TextBox();
			this.txtMkMoi = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtXacNhanMk = new System.Windows.Forms.TextBox();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdOK = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtMkCu);
			this.groupBox1.Controls.Add(this.txtMkMoi);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtXacNhanMk);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(16, 15);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(360, 148);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(11, 30);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 30);
			this.label1.TabIndex = 5;
			this.label1.Text = "Nhập MK cũ: ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtMkCu
			// 
			this.txtMkCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMkCu.Location = new System.Drawing.Point(140, 30);
			this.txtMkCu.Margin = new System.Windows.Forms.Padding(4);
			this.txtMkCu.Name = "txtMkCu";
			this.txtMkCu.Size = new System.Drawing.Size(191, 24);
			this.txtMkCu.TabIndex = 4;
			// 
			// txtMkMoi
			// 
			this.txtMkMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMkMoi.Location = new System.Drawing.Point(140, 68);
			this.txtMkMoi.Margin = new System.Windows.Forms.Padding(4);
			this.txtMkMoi.Name = "txtMkMoi";
			this.txtMkMoi.PasswordChar = '*';
			this.txtMkMoi.Size = new System.Drawing.Size(191, 24);
			this.txtMkMoi.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(11, 59);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 39);
			this.label2.TabIndex = 7;
			this.label2.Text = "Nhập MK mới:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(11, 98);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 39);
			this.label4.TabIndex = 6;
			this.label4.Text = "Xác nhận MK";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtXacNhanMk
			// 
			this.txtXacNhanMk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtXacNhanMk.Location = new System.Drawing.Point(140, 115);
			this.txtXacNhanMk.Margin = new System.Windows.Forms.Padding(4);
			this.txtXacNhanMk.Name = "txtXacNhanMk";
			this.txtXacNhanMk.PasswordChar = '*';
			this.txtXacNhanMk.Size = new System.Drawing.Size(191, 24);
			this.txtXacNhanMk.TabIndex = 3;
			// 
			// cmdCancel
			// 
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdCancel.Location = new System.Drawing.Point(197, 172);
			this.cmdCancel.Margin = new System.Windows.Forms.Padding(4);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(96, 30);
			this.cmdCancel.TabIndex = 4;
			this.cmdCancel.Text = "Thoát";
			// 
			// cmdOK
			// 
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdOK.Location = new System.Drawing.Point(59, 172);
			this.cmdOK.Margin = new System.Windows.Forms.Padding(4);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(96, 30);
			this.cmdOK.TabIndex = 5;
			this.cmdOK.Text = "Đồng ý";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmChangeProfile
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(389, 209);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmChangeProfile";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ĐỔI MẬT KHẨU";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMkCu;
        private System.Windows.Forms.TextBox txtMkMoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtXacNhanMk;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
    }
}