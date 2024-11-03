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

namespace BAITAPLON
{
	public partial class frmDangNhap : Form
	{
		private SqlConnection connection;
		private string connectionString = "Data Source=LAPTOP-LACSE5QS\\SQLEXPRESS;Initial Catalog=QUANLI_KHACHSAN_BTL;Integrated Security=True;";
		public frmDangNhap()
		{
			
			InitializeComponent();
			txtMaNhanVien.Focus();

		}

		private void btnDangNhap_Click(object sender, EventArgs e)
		{
			// Kiểm tra xem người dùng đã nhập đủ thông tin chưa
			if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
			{
				MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtMaNhanVien.Focus();
				return;
			}

			if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
			{
				MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtMatKhau.Focus();
				return;
			}

			// Kiểm tra thông tin đăng nhập
			string username = txtMaNhanVien.Text;
			string password = txtMatKhau.Text;

			using (connection = new SqlConnection(connectionString))
			{
				try
				{
					connection.Open();
					string query = "SELECT * FROM NHANVIEN WHERE MANHANVIEN = @username AND MATKHAU = @password";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@username", username);
						command.Parameters.AddWithValue("@password", password);

						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								string hoTen = reader["HOTEN"].ToString();
								DateTime ngaySinh = Convert.ToDateTime(reader["NGAYSINH"]);

								// Show debug message to confirm values
								MessageBox.Show($"HoTen: {hoTen}, NgaySinh: {ngaySinh.ToShortDateString()}");

								this.Hide(); // Hide the login form

								frmMain mainForm = new frmMain
								{
									MaNhanVien = username,
									HoTen = hoTen,
									PassWord = password,
									NgaySinh = ngaySinh
								};
								mainForm.LoadData();
								mainForm.Show();
							}
							else
							{
								MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message);
				}
			}
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void frmDangNhap_Load(object sender, EventArgs e)
		{
			// Ẩn tất cả các form đang hoạt động
			foreach (Form form in Application.OpenForms)
			{
				if (form != this) // Đảm bảo không ẩn form đăng nhập
				{
					form.Hide();
				}
			}
		}
	}
}
