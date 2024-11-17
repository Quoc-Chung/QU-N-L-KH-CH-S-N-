using QLKS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAITAPLON
{
	public partial class frmMain : Form
	{
		public  string MaNhanVien { get; set; }
		public string HoTen { get; set; }

		public string PassWord { get; set; }
		public DateTime NgaySinh { get; set; } 
		public string Quyen { get; set ; }

		public frmMain()
		{
			InitializeComponent();		
		}
        public void LoadData()
        {
            if (Quyen == "NV")
            {
                lblTenTaiKhoan.Text = "NHÂN VIÊN:";
                quanliToolStripMenuItem.Enabled = false;
                quanliToolStripMenuItem.HideDropDown(); // Ẩn các menu con nếu có
            }
            else
            {
                lblTenTaiKhoan.Text = "QUẢN LÍ:";
                quanliToolStripMenuItem.Enabled = true; // Cho phép nếu là quản lý
            }

            lblTenNhanVien.Text = HoTen;
            lblNgaySinh.Text = NgaySinh.ToString("dd/MM/yyyy");
        }

        private void mnLoaiPhong_Click(object sender, EventArgs e)
		{
			frmLoaiPhong form = new frmLoaiPhong();
			form.Show(); 
		}
		private void mnTrangBiPhong_Click(object sender, EventArgs e)
		{
			frmPhong form = new frmPhong();
			form.Show();
		}

		private void mnTimKiemPhong_Click(object sender, EventArgs e)
		{
			frmSearchPhong form = new frmSearchPhong();
			form.Show();
		}
		private void mnKhachHang_Click(object sender, EventArgs e)
		{
			frmSearchKH form  = new frmSearchKH();
			form.Show();
		}

		private void mnTrangThietBiPhong_Click(object sender, EventArgs e)
		{
			frmTBTrangThietBi frmTBTrangThietBi = new frmTBTrangThietBi();
			frmTBTrangThietBi.Show();
		}

		private void mnTrangThietBi_Click(object sender, EventArgs e)
		{
			frmThietBi frm = new frmThietBi();
			frm.Show();
		}

		private void mnSDDichVu_Click(object sender, EventArgs e)
		{
			frmSDDichVu form = new frmSDDichVu();
			form.Show();
		}
		private void mnHoSoNhanVien_Click(object sender, EventArgs e)
		{
			frmNV frmNV = new frmNV();
			frmNV.Show();
		}

		private void nhậpLạiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmChangeProfile frmChangeProfile = new frmChangeProfile
			{
				MaNhanVien = this.MaNhanVien,
				MatKhauCu = this.PassWord
			};
			frmChangeProfile.Show();
		}

	
		private void mnQLKhachHang_Click(object sender, EventArgs e)
		{
			frmPhongThue frmPhongThue = new frmPhongThue(HoTen);
			frmPhongThue.Show();
		}

		private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
				// Hỏi người dùng có muốn đăng xuất không
				var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result == DialogResult.Yes)
				{
					
					// Quay lại form đăng nhập
					frmDangNhap dangNhapForm = new frmDangNhap();
					this.Hide(); // Ẩn form hiện tại
					dangNhapForm.Show(); 
				}
			}

		private void mnThanhToan_Click(object sender, EventArgs e)
		{
			frmThanhToanPhong thanhToan = new frmThanhToanPhong();
			thanhToan.Show();
		}


        private void quảnLíNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
			frmNV frmNV = new frmNV();
			frmNV.Show();
        }

        private void quảnLýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
			frmDoanhThu frmDoanhThu = new frmDoanhThu();
			frmDoanhThu.Show();
        }
    }

}
