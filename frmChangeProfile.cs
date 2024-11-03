using BAITAPLON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class frmChangeProfile : Form
    {
		public string MaNhanVien { get; set; }
		public string MatKhauCu { get; set; }

		
		public frmChangeProfile()
        {
            InitializeComponent();
        }

		private void cmdOK_Click(object sender, EventArgs e)
		{

			if (string.IsNullOrWhiteSpace(txtMkCu.Text) || string.IsNullOrWhiteSpace(txtMkMoi.Text) || string.IsNullOrWhiteSpace(txtXacNhanMk.Text))
			{
				MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (txtMkMoi.Text != txtXacNhanMk.Text)
			{
				MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-LACSE5QS\\SQLEXPRESS;Initial Catalog=QUANLI_KHACHSAN_BTL;Integrated Security=True;"))
			{
				try
				{
					connection.Open();
					// Kiểm tra mật khẩu cũ
					string queryCheck = "SELECT COUNT(*) FROM NHANVIEN WHERE MANHANVIEN = @MaNhanVien AND MATKHAU = @MatKhauCu";
					using (SqlCommand commandCheck = new SqlCommand(queryCheck, connection))
					{
						commandCheck.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
						commandCheck.Parameters.AddWithValue("@MatKhauCu", txtMkCu.Text);

						int count = (int)commandCheck.ExecuteScalar();
						if (count == 0)
						{
							MessageBox.Show("Mật khẩu cũ không chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}
					}

					// Cập nhật mật khẩu mới
					string queryUpdate = "UPDATE NHANVIEN SET MATKHAU = @MatKhauMoi WHERE MANHANVIEN = @MaNhanVien";
					using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection))
					{
						commandUpdate.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
						commandUpdate.Parameters.AddWithValue("@MatKhauMoi", txtMkMoi.Text);
						commandUpdate.ExecuteNonQuery();
					}

					MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close(); // Đóng form thay đổi mật khẩu
								  // Hiển thị lại form đăng nhập
					
					frmDangNhap dangNhapForm = new frmDangNhap();
					dangNhapForm.Show();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message);
				}
			}
		}
	}

}
