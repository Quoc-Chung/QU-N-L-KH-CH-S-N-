using BAITAPLON.Model;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BAITAPLON
{
	public partial class frmDangNhap : Form
	{
		private SqlConnection connection;
		private string connectionString = ConnectString.ConecString;

		private string imagePath1 = System.IO.Path.Combine(Application.StartupPath, "Resources", "Ani", "1.png");
		private string imagePath2 = System.IO.Path.Combine(Application.StartupPath, "Resources", "Ani", "2.png");
		private string imagePath3 = System.IO.Path.Combine(Application.StartupPath, "Resources", "Ani", "3.gif");
		private string imagePath4 = System.IO.Path.Combine(Application.StartupPath, "Resources", "Ani", "4.png");

		private bool gifShown = false; // Biến để kiểm tra GIF đã được hiển thị hay chưa

		public frmDangNhap()
		{
			InitializeComponent();

			pictureBoxStatus.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBoxStatus.Image = Image.FromFile(imagePath1);
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

								MessageBox.Show($"Đăng nhập thành công! Chào mừng {hoTen}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
			
			foreach (Form form in Application.OpenForms)
			{
				if (form != this) 
				{
					form.Hide();
				}
			}
		}
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			
			if (!checkBox1.Checked)
			{
				txtMatKhau.UseSystemPasswordChar = false;
			}
			else 
			{
				txtMatKhau.UseSystemPasswordChar = true;
			}
		}

		private void txtMaNhanVien_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
			{
				pictureBoxStatus.Image = Image.FromFile(imagePath2);
			}
			else
			{
				pictureBoxStatus.Image = Image.FromFile(imagePath1);
			}
		}

		private void txtMatKhau_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
			{
				if (!gifShown)  // Nếu GIF chưa được hiển thị
				{
					pictureBoxStatus.Image = Image.FromFile(imagePath3); // Hiển thị GIF
					gifShown = true; // Đánh dấu là GIF đã hiển thị
				}
			}
			else
			{
				// Nếu mật khẩu trống, quay lại ảnh mặc định
				pictureBoxStatus.Image = Image.FromFile(imagePath1);
				gifShown = false; // Reset lại trạng thái GIF
			}
		}
	}
}
