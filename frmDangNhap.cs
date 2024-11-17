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

		private bool gifShown = false; 

		public frmDangNhap()
		{
			InitializeComponent();

			pictureBoxStatus.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBoxStatus.Image = Image.FromFile(imagePath1);
			txtTaiKhoan.Focus();
		}

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem mã tài khoản có hợp lệ không
            string username = txtTaiKhoan.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập mã tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }

            // Kiểm tra mã tài khoản có chứa ký tự đặc biệt hoặc khoảng trắng không
            if (username.Contains(" ") || !System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Mã tài khoản không được chứa khoảng trắng hoặc ký tự đặc biệt. Chỉ chấp nhận chữ, số và '_'.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Text = ""; // Xóa nội dung không hợp lệ
                txtTaiKhoan.Focus();
                return;
            }
            // Kiểm tra xem mật khẩu có để trống không
            string password = txtMatKhau.Text.Trim();
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // Thực hiện kiểm tra thông tin đăng nhập
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM TAI_KHOAN WHERE MATAIKHOAN = @username AND MATKHAU = @password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hoTen = reader["HOTEN"].ToString();
                                string quyen = reader["QUYEN"].ToString();
                                DateTime ngaySinh = Convert.ToDateTime(reader["NGAYSINH"]);

                                MessageBox.Show($"Đăng nhập thành công! Chào mừng {hoTen}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.Hide(); // Ẩn form đăng nhập
								TaiKhoan.maTaiKhoan = username;
								TaiKhoan.tenTaiKhoan = hoTen;
								TaiKhoan.Quyen = quyen;
                                frmMain mainForm = new frmMain
                                {
                                    MaNhanVien = username,
                                    HoTen = hoTen,
                                    PassWord = password,
                                    NgaySinh = ngaySinh,
									Quyen = quyen

                                };
                                mainForm.LoadData();
                                mainForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			if (!string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
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
