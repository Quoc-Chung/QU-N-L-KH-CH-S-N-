
namespace BAITAPLON
{
    partial class frmTBTrangThietBi
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.cboLoaiP = new System.Windows.Forms.ComboBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxDieuHoa = new System.Windows.Forms.CheckBox();
            this.checkBoxTivi = new System.Windows.Forms.CheckBox();
            this.checkBoxGiuong = new System.Windows.Forms.CheckBox();
            this.checkBoxMaychoigame = new System.Windows.Forms.CheckBox();
            this.checkBoxBinhnonglanh = new System.Windows.Forms.CheckBox();
            this.checkBoxDendien = new System.Windows.Forms.CheckBox();
            this.checkBoxBan = new System.Windows.Forms.CheckBox();
            this.checkBoxGhe = new System.Windows.Forms.CheckBox();
            this.domainUpDownDieuhoa = new System.Windows.Forms.DomainUpDown();
            this.domainUpDownTivi = new System.Windows.Forms.DomainUpDown();
            this.domainUpDownGiuong = new System.Windows.Forms.DomainUpDown();
            this.domainUpDownMaychoigame = new System.Windows.Forms.DomainUpDown();
            this.domainUpDownBinhnonglanh = new System.Windows.Forms.DomainUpDown();
            this.domainUpDownDendien = new System.Windows.Forms.DomainUpDown();
            this.domainUpDownBan = new System.Windows.Forms.DomainUpDown();
            this.domainUpDownGhe = new System.Windows.Forms.DomainUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView);
            this.groupBox1.Controls.Add(this.cboLoaiP);
            this.groupBox1.Controls.Add(this.cmdCancel);
            this.groupBox1.Controls.Add(this.cmdSave);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 352);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(10, 57);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(386, 289);
            this.dataGridView.TabIndex = 13;
            // 
            // cboLoaiP
            // 
            this.cboLoaiP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiP.Items.AddRange(new object[] {
            "Phòng vip",
            "Phòng tầm trung",
            "Phòng thường"});
            this.cboLoaiP.Location = new System.Drawing.Point(76, 15);
            this.cboLoaiP.Name = "cboLoaiP";
            this.cboLoaiP.Size = new System.Drawing.Size(168, 23);
            this.cboLoaiP.TabIndex = 12;
            this.cboLoaiP.Text = "Chọn loại phòng";
            // 
            // cmdCancel
            // 
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.Location = new System.Drawing.Point(332, 16);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(64, 23);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Thoát";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSave.Location = new System.Drawing.Point(260, 16);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(64, 23);
            this.cmdSave.TabIndex = 10;
            this.cmdSave.Text = "Lưu";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Loại phòng:";
            // 
            // checkBoxDieuHoa
            // 
            this.checkBoxDieuHoa.AutoSize = true;
            this.checkBoxDieuHoa.Location = new System.Drawing.Point(442, 37);
            this.checkBoxDieuHoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxDieuHoa.Name = "checkBoxDieuHoa";
            this.checkBoxDieuHoa.Size = new System.Drawing.Size(69, 17);
            this.checkBoxDieuHoa.TabIndex = 17;
            this.checkBoxDieuHoa.Text = "Điều hoà";
            this.checkBoxDieuHoa.UseVisualStyleBackColor = true;
            this.checkBoxDieuHoa.CheckedChanged += new System.EventHandler(this.checkBoxDieuHoa_CheckedChanged);
            // 
            // checkBoxTivi
            // 
            this.checkBoxTivi.AutoSize = true;
            this.checkBoxTivi.Location = new System.Drawing.Point(442, 60);
            this.checkBoxTivi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxTivi.Name = "checkBoxTivi";
            this.checkBoxTivi.Size = new System.Drawing.Size(43, 17);
            this.checkBoxTivi.TabIndex = 18;
            this.checkBoxTivi.Text = "Tivi";
            this.checkBoxTivi.UseVisualStyleBackColor = true;
            this.checkBoxTivi.CheckedChanged += new System.EventHandler(this.checkBoxTivi_CheckedChanged);
            // 
            // checkBoxGiuong
            // 
            this.checkBoxGiuong.AutoSize = true;
            this.checkBoxGiuong.Location = new System.Drawing.Point(442, 84);
            this.checkBoxGiuong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxGiuong.Name = "checkBoxGiuong";
            this.checkBoxGiuong.Size = new System.Drawing.Size(60, 17);
            this.checkBoxGiuong.TabIndex = 19;
            this.checkBoxGiuong.Text = "Giường";
            this.checkBoxGiuong.UseVisualStyleBackColor = true;
            this.checkBoxGiuong.CheckedChanged += new System.EventHandler(this.checkBoxGiuong_CheckedChanged);
            // 
            // checkBoxMaychoigame
            // 
            this.checkBoxMaychoigame.AutoSize = true;
            this.checkBoxMaychoigame.Location = new System.Drawing.Point(442, 107);
            this.checkBoxMaychoigame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxMaychoigame.Name = "checkBoxMaychoigame";
            this.checkBoxMaychoigame.Size = new System.Drawing.Size(98, 17);
            this.checkBoxMaychoigame.TabIndex = 20;
            this.checkBoxMaychoigame.Text = "Máy chơi game";
            this.checkBoxMaychoigame.UseVisualStyleBackColor = true;
            this.checkBoxMaychoigame.CheckedChanged += new System.EventHandler(this.checkBoxMaychoigame_CheckedChanged);
            // 
            // checkBoxBinhnonglanh
            // 
            this.checkBoxBinhnonglanh.AutoSize = true;
            this.checkBoxBinhnonglanh.Location = new System.Drawing.Point(442, 130);
            this.checkBoxBinhnonglanh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxBinhnonglanh.Name = "checkBoxBinhnonglanh";
            this.checkBoxBinhnonglanh.Size = new System.Drawing.Size(97, 17);
            this.checkBoxBinhnonglanh.TabIndex = 21;
            this.checkBoxBinhnonglanh.Text = "Bình nóng lạnh";
            this.checkBoxBinhnonglanh.UseVisualStyleBackColor = true;
            this.checkBoxBinhnonglanh.CheckedChanged += new System.EventHandler(this.checkBoxBinhnonglanh_CheckedChanged);
            // 
            // checkBoxDendien
            // 
            this.checkBoxDendien.AutoSize = true;
            this.checkBoxDendien.Location = new System.Drawing.Point(442, 153);
            this.checkBoxDendien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxDendien.Name = "checkBoxDendien";
            this.checkBoxDendien.Size = new System.Drawing.Size(70, 17);
            this.checkBoxDendien.TabIndex = 22;
            this.checkBoxDendien.Text = "Đèn điện";
            this.checkBoxDendien.UseVisualStyleBackColor = true;
            this.checkBoxDendien.CheckedChanged += new System.EventHandler(this.checkBoxDendien_CheckedChanged);
            // 
            // checkBoxBan
            // 
            this.checkBoxBan.AutoSize = true;
            this.checkBoxBan.Location = new System.Drawing.Point(442, 176);
            this.checkBoxBan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxBan.Name = "checkBoxBan";
            this.checkBoxBan.Size = new System.Drawing.Size(48, 17);
            this.checkBoxBan.TabIndex = 23;
            this.checkBoxBan.Text = "Bàn ";
            this.checkBoxBan.UseVisualStyleBackColor = true;
            this.checkBoxBan.CheckedChanged += new System.EventHandler(this.checkBoxBan_CheckedChanged);
            // 
            // checkBoxGhe
            // 
            this.checkBoxGhe.AutoSize = true;
            this.checkBoxGhe.Location = new System.Drawing.Point(442, 198);
            this.checkBoxGhe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxGhe.Name = "checkBoxGhe";
            this.checkBoxGhe.Size = new System.Drawing.Size(46, 17);
            this.checkBoxGhe.TabIndex = 24;
            this.checkBoxGhe.Text = "Ghế";
            this.checkBoxGhe.UseVisualStyleBackColor = true;
            this.checkBoxGhe.CheckedChanged += new System.EventHandler(this.checkBoxGhe_CheckedChanged);
            // 
            // domainUpDownDieuhoa
            // 
            this.domainUpDownDieuhoa.Enabled = false;
            this.domainUpDownDieuhoa.Items.Add("10");
            this.domainUpDownDieuhoa.Items.Add("9");
            this.domainUpDownDieuhoa.Items.Add("8");
            this.domainUpDownDieuhoa.Items.Add("7");
            this.domainUpDownDieuhoa.Items.Add("6");
            this.domainUpDownDieuhoa.Items.Add("5");
            this.domainUpDownDieuhoa.Items.Add("4");
            this.domainUpDownDieuhoa.Items.Add("3");
            this.domainUpDownDieuhoa.Items.Add("2");
            this.domainUpDownDieuhoa.Items.Add("1");
            this.domainUpDownDieuhoa.Items.Add("0");
            this.domainUpDownDieuhoa.Location = new System.Drawing.Point(621, 37);
            this.domainUpDownDieuhoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.domainUpDownDieuhoa.Name = "domainUpDownDieuhoa";
            this.domainUpDownDieuhoa.Size = new System.Drawing.Size(43, 20);
            this.domainUpDownDieuhoa.TabIndex = 25;
            this.domainUpDownDieuhoa.Text = "0";
            this.domainUpDownDieuhoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.domainUpDownDieuhoa.SelectedItemChanged += new System.EventHandler(this.domainUpDownDieuhoa_SelectedItemChanged);
            // 
            // domainUpDownTivi
            // 
            this.domainUpDownTivi.Enabled = false;
            this.domainUpDownTivi.Items.Add("10");
            this.domainUpDownTivi.Items.Add("9");
            this.domainUpDownTivi.Items.Add("8");
            this.domainUpDownTivi.Items.Add("7");
            this.domainUpDownTivi.Items.Add("6");
            this.domainUpDownTivi.Items.Add("5");
            this.domainUpDownTivi.Items.Add("4");
            this.domainUpDownTivi.Items.Add("3");
            this.domainUpDownTivi.Items.Add("2");
            this.domainUpDownTivi.Items.Add("1");
            this.domainUpDownTivi.Items.Add("0");
            this.domainUpDownTivi.Location = new System.Drawing.Point(621, 59);
            this.domainUpDownTivi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.domainUpDownTivi.Name = "domainUpDownTivi";
            this.domainUpDownTivi.Size = new System.Drawing.Size(43, 20);
            this.domainUpDownTivi.TabIndex = 26;
            this.domainUpDownTivi.Text = "0";
            this.domainUpDownTivi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // domainUpDownGiuong
            // 
            this.domainUpDownGiuong.Enabled = false;
            this.domainUpDownGiuong.Items.Add("10");
            this.domainUpDownGiuong.Items.Add("9");
            this.domainUpDownGiuong.Items.Add("8");
            this.domainUpDownGiuong.Items.Add("7");
            this.domainUpDownGiuong.Items.Add("6");
            this.domainUpDownGiuong.Items.Add("5");
            this.domainUpDownGiuong.Items.Add("4");
            this.domainUpDownGiuong.Items.Add("3");
            this.domainUpDownGiuong.Items.Add("2");
            this.domainUpDownGiuong.Items.Add("1");
            this.domainUpDownGiuong.Items.Add("0");
            this.domainUpDownGiuong.Location = new System.Drawing.Point(621, 82);
            this.domainUpDownGiuong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.domainUpDownGiuong.Name = "domainUpDownGiuong";
            this.domainUpDownGiuong.Size = new System.Drawing.Size(43, 20);
            this.domainUpDownGiuong.TabIndex = 27;
            this.domainUpDownGiuong.Text = "0";
            this.domainUpDownGiuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // domainUpDownMaychoigame
            // 
            this.domainUpDownMaychoigame.Enabled = false;
            this.domainUpDownMaychoigame.Items.Add("10");
            this.domainUpDownMaychoigame.Items.Add("9");
            this.domainUpDownMaychoigame.Items.Add("8");
            this.domainUpDownMaychoigame.Items.Add("7");
            this.domainUpDownMaychoigame.Items.Add("6");
            this.domainUpDownMaychoigame.Items.Add("5");
            this.domainUpDownMaychoigame.Items.Add("4");
            this.domainUpDownMaychoigame.Items.Add("3");
            this.domainUpDownMaychoigame.Items.Add("2");
            this.domainUpDownMaychoigame.Items.Add("1");
            this.domainUpDownMaychoigame.Items.Add("0");
            this.domainUpDownMaychoigame.Location = new System.Drawing.Point(621, 106);
            this.domainUpDownMaychoigame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.domainUpDownMaychoigame.Name = "domainUpDownMaychoigame";
            this.domainUpDownMaychoigame.Size = new System.Drawing.Size(43, 20);
            this.domainUpDownMaychoigame.TabIndex = 28;
            this.domainUpDownMaychoigame.Text = "0";
            this.domainUpDownMaychoigame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // domainUpDownBinhnonglanh
            // 
            this.domainUpDownBinhnonglanh.Enabled = false;
            this.domainUpDownBinhnonglanh.Items.Add("10");
            this.domainUpDownBinhnonglanh.Items.Add("9");
            this.domainUpDownBinhnonglanh.Items.Add("8");
            this.domainUpDownBinhnonglanh.Items.Add("7");
            this.domainUpDownBinhnonglanh.Items.Add("6");
            this.domainUpDownBinhnonglanh.Items.Add("5");
            this.domainUpDownBinhnonglanh.Items.Add("4");
            this.domainUpDownBinhnonglanh.Items.Add("3");
            this.domainUpDownBinhnonglanh.Items.Add("2");
            this.domainUpDownBinhnonglanh.Items.Add("0");
            this.domainUpDownBinhnonglanh.Location = new System.Drawing.Point(621, 129);
            this.domainUpDownBinhnonglanh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.domainUpDownBinhnonglanh.Name = "domainUpDownBinhnonglanh";
            this.domainUpDownBinhnonglanh.Size = new System.Drawing.Size(43, 20);
            this.domainUpDownBinhnonglanh.TabIndex = 29;
            this.domainUpDownBinhnonglanh.Text = "0";
            this.domainUpDownBinhnonglanh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // domainUpDownDendien
            // 
            this.domainUpDownDendien.Enabled = false;
            this.domainUpDownDendien.Items.Add("10");
            this.domainUpDownDendien.Items.Add("9");
            this.domainUpDownDendien.Items.Add("8");
            this.domainUpDownDendien.Items.Add("7");
            this.domainUpDownDendien.Items.Add("6");
            this.domainUpDownDendien.Items.Add("5");
            this.domainUpDownDendien.Items.Add("4");
            this.domainUpDownDendien.Items.Add("3");
            this.domainUpDownDendien.Items.Add("2");
            this.domainUpDownDendien.Items.Add("1");
            this.domainUpDownDendien.Items.Add("0");
            this.domainUpDownDendien.Location = new System.Drawing.Point(621, 152);
            this.domainUpDownDendien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.domainUpDownDendien.Name = "domainUpDownDendien";
            this.domainUpDownDendien.Size = new System.Drawing.Size(43, 20);
            this.domainUpDownDendien.TabIndex = 30;
            this.domainUpDownDendien.Text = "0";
            this.domainUpDownDendien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // domainUpDownBan
            // 
            this.domainUpDownBan.Enabled = false;
            this.domainUpDownBan.Items.Add("10");
            this.domainUpDownBan.Items.Add("9");
            this.domainUpDownBan.Items.Add("8");
            this.domainUpDownBan.Items.Add("7");
            this.domainUpDownBan.Items.Add("6");
            this.domainUpDownBan.Items.Add("5");
            this.domainUpDownBan.Items.Add("4");
            this.domainUpDownBan.Items.Add("3");
            this.domainUpDownBan.Items.Add("2");
            this.domainUpDownBan.Items.Add("1");
            this.domainUpDownBan.Items.Add("0");
            this.domainUpDownBan.Location = new System.Drawing.Point(621, 175);
            this.domainUpDownBan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.domainUpDownBan.Name = "domainUpDownBan";
            this.domainUpDownBan.Size = new System.Drawing.Size(43, 20);
            this.domainUpDownBan.TabIndex = 31;
            this.domainUpDownBan.Text = "0";
            this.domainUpDownBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // domainUpDownGhe
            // 
            this.domainUpDownGhe.Enabled = false;
            this.domainUpDownGhe.Items.Add("10");
            this.domainUpDownGhe.Items.Add("9");
            this.domainUpDownGhe.Items.Add("8");
            this.domainUpDownGhe.Items.Add("7");
            this.domainUpDownGhe.Items.Add("6");
            this.domainUpDownGhe.Items.Add("5");
            this.domainUpDownGhe.Items.Add("4");
            this.domainUpDownGhe.Items.Add("3");
            this.domainUpDownGhe.Items.Add("2");
            this.domainUpDownGhe.Items.Add("1");
            this.domainUpDownGhe.Items.Add("0");
            this.domainUpDownGhe.Location = new System.Drawing.Point(621, 197);
            this.domainUpDownGhe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.domainUpDownGhe.Name = "domainUpDownGhe";
            this.domainUpDownGhe.Size = new System.Drawing.Size(43, 20);
            this.domainUpDownGhe.TabIndex = 32;
            this.domainUpDownGhe.Text = "0";
            this.domainUpDownGhe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmTBTrangThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 374);
            this.Controls.Add(this.domainUpDownGhe);
            this.Controls.Add(this.domainUpDownBan);
            this.Controls.Add(this.domainUpDownDendien);
            this.Controls.Add(this.domainUpDownBinhnonglanh);
            this.Controls.Add(this.domainUpDownMaychoigame);
            this.Controls.Add(this.domainUpDownGiuong);
            this.Controls.Add(this.domainUpDownTivi);
            this.Controls.Add(this.domainUpDownDieuhoa);
            this.Controls.Add(this.checkBoxGhe);
            this.Controls.Add(this.checkBoxBan);
            this.Controls.Add(this.checkBoxDendien);
            this.Controls.Add(this.checkBoxBinhnonglanh);
            this.Controls.Add(this.checkBoxMaychoigame);
            this.Controls.Add(this.checkBoxGiuong);
            this.Controls.Add(this.checkBoxTivi);
            this.Controls.Add(this.checkBoxDieuHoa);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTBTrangThietBi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRANG THIẾT BỊ CHO LOẠI PHÒNG";
            this.Load += new System.EventHandler(this.frmTBTrangThietBi_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboLoaiP;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.CheckBox checkBoxDieuHoa;
        private System.Windows.Forms.CheckBox checkBoxTivi;
        private System.Windows.Forms.CheckBox checkBoxGiuong;
        private System.Windows.Forms.CheckBox checkBoxMaychoigame;
        private System.Windows.Forms.CheckBox checkBoxBinhnonglanh;
        private System.Windows.Forms.CheckBox checkBoxDendien;
        private System.Windows.Forms.CheckBox checkBoxBan;
        private System.Windows.Forms.CheckBox checkBoxGhe;
        private System.Windows.Forms.DomainUpDown domainUpDownDieuhoa;
        private System.Windows.Forms.DomainUpDown domainUpDownTivi;
        private System.Windows.Forms.DomainUpDown domainUpDownGiuong;
        private System.Windows.Forms.DomainUpDown domainUpDownMaychoigame;
        private System.Windows.Forms.DomainUpDown domainUpDownBinhnonglanh;
        private System.Windows.Forms.DomainUpDown domainUpDownDendien;
        private System.Windows.Forms.DomainUpDown domainUpDownBan;
        private System.Windows.Forms.DomainUpDown domainUpDownGhe;
    }
}