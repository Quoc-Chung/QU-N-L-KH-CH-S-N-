using BAITAPLON.Model;
using BAITAPLON.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace BAITAPLON
{
	public partial class frmPhongThue : Form
	{
		private SqlConnection connection;

		private string connectionString = ConnectString.ConecString;
        private SqlCommand command;
		private DataTable table = new DataTable();

		public static string Phong_Nguoi_Dung_Chon;

		public string HoTenNhanVien;
		public frmPhongThue(string hoTenNhanVien)
		{
			InitializeComponent();

			HoTenNhanVien = hoTenNhanVien;
			lblHoTenNhanVien.Text = HoTenNhanVien;
		}
		public void LoadData()
		{
			lblHoTenNhanVien.Text = HoTenNhanVien;
			try
			{
				if (connection.State != ConnectionState.Open)
				{
					connection.Open();
				}

				string query = "SELECT * FROM DANHMUCPHONG";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					using (SqlDataAdapter adapter = new SqlDataAdapter(command))
					{
						table.Clear();
						adapter.Fill(table);
						Load_PhongListView(table);
					}
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
			}
			finally
			{

				if (connection.State == ConnectionState.Open)
				{
					connection.Close();
				}
			}
		}
		private void Load_PhongListView(DataTable table)
		{
			listView.Items.Clear(); 

			foreach (DataRow row in table.Rows)
			{
				string maPhong = row["MAPHONG"].ToString();
				string tang = row["TANG"].ToString();
				bool trangThai = Convert.ToBoolean(row["TINHTRANG"]);

				ListViewItem item = new ListViewItem(maPhong);
				item.SubItems.Add(tang);

				item.BackColor = trangThai ? Color.Red: Color.LimeGreen;
				item.SubItems.Add(trangThai ? "Đã thuê" : "Chưa có người thuê");
				listView.Items.Add(item);
			}
		}
		private void frmPhongThue_Load(object sender, EventArgs e)
		{
			lblHoTenNhanVien.Text = HoTenNhanVien;
			connection = new SqlConnection(connectionString);
			try
			{
				connection.Open();
				LoadData();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi kết nối cơ sở dữ liệu: " + ex.Message);
			}
		}

		private void LoadKhachHangTheoPhong(string maPhong)
		{
			// TRUY XUẤT NHỮNG CÁI CHỖ MÀ KHÁCH HÀNG THUÊ 
			string truy_xuat_khach_hang_thue = @"
					SELECT k.* 
					FROM KHACHHANG AS k 
					INNER JOIN CHITIETTHUEPHONG AS c ON k.MAKHACHHANG = c.MAKHACHHANG 
					INNER JOIN THUEPHONG AS t ON t.SHDTHUEPHONG = c.SHDTHUEPHONG 
					WHERE t.MAPHONG = @maPhong;";

			using (SqlCommand command = new SqlCommand(truy_xuat_khach_hang_thue, connection))
			{
				command.Parameters.AddWithValue("@maPhong", Phong_Nguoi_Dung_Chon);
				try
				{
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						listViewKhachHang.Items.Clear(); // Clear previous items
						while (reader.Read())
						{
							ListViewItem item = new ListViewItem(reader["MAKHACHHANG"].ToString());
							item.SubItems.Add(reader["HOTEN"].ToString());
							item.SubItems.Add(reader["CMND"].ToString());
							item.SubItems.Add((bool)reader["GIOITINH"] ? "Nam" : "Nữ");
							item.SubItems.Add(reader["DIACHI"].ToString());
							item.SubItems.Add(reader["DIENTHOAI"].ToString());

							listViewKhachHang.Items.Add(item);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi tải chi tiết phòng: " + ex.Message);
				}
				finally
				{
					connection.Close();
				}
			}
		}
		private void listView_SelectedIndexChanged(object sender, EventArgs e)
		{
			// NẾU MỘT PHÒNG ĐƯỢC CHỌN 
			if (listView.SelectedItems.Count > 0)
			{
				ResetHienThi();
				ListViewItem selectedItem = listView.SelectedItems[0];
				Phong_Nguoi_Dung_Chon = selectedItem.SubItems[0].Text;

				// Lấy trạng thái phòng từ ListViewItem đã chọn
				bool trangThai = selectedItem.SubItems[2].Text == "Đã thuê";

				// Kiểm tra trạng thái và bật/tắt nút tương ứng
				if (!trangThai) // Phòng trống
				{
					btnDangKiThue.Enabled = true;
					btnThem.Enabled = false;
					btnSua.Enabled = false;
					btnXoa.Enabled = false;
				}
				else // Phòng đã có người thuê
				{
					btnDangKiThue.Enabled = false;
					btnThem.Enabled = true;
					btnSua.Enabled = true;
					btnXoa.Enabled = true;
				}
				string truy_van_phong_da_thue = @"
													SELECT l.LOAIPHONG, tp.NGAYTHUE, tp.NGAYTRA, dm.ANHPHONG, dm.TINHTRANG
													FROM DANHMUCPHONG AS dm
													INNER JOIN LOAIPHONG AS l ON dm.MALOAIPHONG = l.MALOAIPHONG 
													INNER JOIN THUEPHONG AS tp ON tp.MAPHONG = dm.MAPHONG
													WHERE tp.MAPHONG = @maPhong;";

				using (SqlCommand command = new SqlCommand(truy_van_phong_da_thue, connection))
				{
					command.Parameters.AddWithValue("@maPhong", Phong_Nguoi_Dung_Chon);
					try
					{
						connection.Open();
						SqlDataReader reader = command.ExecuteReader();

					
						if (reader.Read())
						{

							txtMaPhong.Text = Phong_Nguoi_Dung_Chon;
							txtLoaiPhong.Text = reader["LOAIPHONG"].ToString();

							dtmNgayThue.Format = DateTimePickerFormat.Short; 
							dtmNgayTra.Format = DateTimePickerFormat.Short;

							if (!reader.IsDBNull(reader.GetOrdinal("NGAYTHUE")))
							{
								dtmNgayThue.Value = reader.GetDateTime(reader.GetOrdinal("NGAYTHUE"));
							}
							if (!reader.IsDBNull(reader.GetOrdinal("NGAYTRA")))
							{
								dtmNgayTra.Value = reader.GetDateTime(reader.GetOrdinal("NGAYTRA"));
							}
							if (!reader.IsDBNull(reader.GetOrdinal("ANHPHONG")))
							{
								string imageFileName = reader["ANHPHONG"].ToString();
								string imageFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resources\AnhPhong", imageFileName));


								if (File.Exists(imageFilePath))
								{
									picAnhPhong.Image = Image.FromFile(imageFilePath);
								}
								else
								{
									picAnhPhong.Image = null;
								}
							}
							else
							{
								picAnhPhong.Image = null;
							}
						}
						else
						{						
							reader.Close();
							string truyvan_phong_chua_thue = @"
																SELECT l.LOAIPHONG, dm.ANHPHONG
																FROM DANHMUCPHONG AS dm
																INNER JOIN LOAIPHONG AS l ON dm.MALOAIPHONG = l.MALOAIPHONG
																WHERE dm.MAPHONG = @maPhong;";
							using (SqlCommand command2 = new SqlCommand(truyvan_phong_chua_thue, connection))
							{
								command2.Parameters.AddWithValue("@maPhong", Phong_Nguoi_Dung_Chon);
								SqlDataReader reader2 = command2.ExecuteReader();
								if (reader2.Read())
								{
									txtMaPhong.Text = Phong_Nguoi_Dung_Chon;
									txtLoaiPhong.Text = reader2["LOAIPHONG"].ToString();

									dtmNgayThue.CustomFormat = " ";
									dtmNgayThue.Format = DateTimePickerFormat.Custom;
									dtmNgayTra.CustomFormat = " ";
									dtmNgayTra.Format = DateTimePickerFormat.Custom;

									if (!reader2.IsDBNull(reader2.GetOrdinal("ANHPHONG")))
									{
										string imageFileName = reader2["ANHPHONG"].ToString();
										string imageFilePath = Path.Combine(@"D:\KI_MOT_NAM_BA\WINFORM\ICON\AnhPhong", imageFileName);

										if (File.Exists(imageFilePath))
										{
											picAnhPhong.Image = Image.FromFile(imageFilePath);
										}
										else
										{
											picAnhPhong.Image = null;
										}
									}
									else
									{
										picAnhPhong.Image = null;
									}
								}
								else
								{
									MessageBox.Show("Không tìm thấy thông tin phòng.");
								}
								reader2.Close();
							}
						}
						reader.Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
					}
					finally
					{
						connection.Close();
					}
				}
				LoadKhachHangTheoPhong(Phong_Nguoi_Dung_Chon);
			}
		   }

        private void listViewKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn hay không
            if (listViewKhachHang.SelectedItems.Count > 0)
            {
                // Lấy mục được chọn
                ListViewItem selectedItem = listViewKhachHang.SelectedItems[0];

                // Lấy giá trị từ các subitem của mục đã chọn
                string MaKhachHang = selectedItem.SubItems[0].Text;
                string HoTen = selectedItem.SubItems[1].Text;
                string CMND = selectedItem.SubItems[2].Text;
                string GioiTinh = selectedItem.SubItems[3].Text;
                string DiaChi = selectedItem.SubItems[4].Text;
                string DienThoai = selectedItem.SubItems[5].Text;

                // Gán giá trị vào các textbox và radio button
                txtMaKhachHang.Text = MaKhachHang;
                txtHoTen.Text = HoTen;
                txtCMND.Text = CMND;

                if (GioiTinh == "Nam")
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNu.Checked = true;
                }

                txtDiaChi.Text = DiaChi;
                txtDienThoai.Text = DienThoai;
            }
            else
            {
                // Nếu không có mục nào được chọn, có thể làm sạch các trường nhập liệu
                txtMaKhachHang.Clear();
                txtHoTen.Clear();
                txtCMND.Clear();
                radNam.Checked = false;
                radNu.Checked = false;
                txtDiaChi.Clear();
                txtDienThoai.Clear();
            }
        }

        public void ResetHienThi()
		{
			txtMaKhachHang.Text = "";
			txtHoTen.Text = " ";
			txtCMND.Text = " ";
			radNam.Checked = false;
			radNu.Checked = false;

			txtDiaChi.Text = " ";
			txtDienThoai.Text = " ";
		}

		private bool KiemTraKhachHangTonTaiTrongPhong(string maKhachHang, string soHoaDonThue)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					connection.Open();
					string query = @"
									SELECT COUNT(*) 
									FROM CHITIETTHUEPHONG 
									WHERE MAKHACHHANG = @MAKHACHHANG 
									AND SHDTHUEPHONG = @SHDTHUEPHONG";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@MAKHACHHANG", maKhachHang);
						command.Parameters.AddWithValue("@SHDTHUEPHONG", soHoaDonThue);

						int count = (int)command.ExecuteScalar();
						return count > 0;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi kiểm tra khách hàng trong phòng: " + ex.Message);
					return false;
				}
			}
		}
        private bool IsValidMaKhachHang(string maKhachHang)
        {
            return !maKhachHang.Any(c => !Char.IsLetterOrDigit(c));
        }
        private bool IsValidHoTen(string hoTen)
        {     
            return hoTen.All(c => Char.IsLetter(c) || Char.IsWhiteSpace(c));
        }

        private bool IsValidDiaChi(string diaChi)
        {     
            return !diaChi.Any(c => !Char.IsLetterOrDigit(c) && !Char.IsWhiteSpace(c));
        }
        private bool IsValidCMND(string cmnd)
        {
            return cmnd.Length == 12 && cmnd.All(Char.IsDigit);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {      
            return phoneNumber.Length == 10 && phoneNumber.All(Char.IsDigit) && phoneNumber.StartsWith("0");
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            string maKhachHang = txtMaKhachHang.Text.Trim();
            string phongNguoiDungChon = Phong_Nguoi_Dung_Chon;

        
            if (string.IsNullOrEmpty(maKhachHang) || string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtCMND.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

       
            if (!IsValidMaKhachHang(maKhachHang))
            {
                MessageBox.Show("Mã khách hàng không được chứa ký tự đặc biệt.");
                txtMaKhachHang.Focus();
                return;
            }

         
            if (!IsValidHoTen(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được chứa số và ký tự đặc biệt.");
                txtHoTen.Focus();
                return;
            }

         
            if (!IsValidDiaChi(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được chứa ký tự đặc biệt.");
                txtDiaChi.Focus();
                return;
            }

            if (!IsValidCMND(txtCMND.Text.Trim()))
            {
                MessageBox.Show("CMND phải có 12 chữ số, không chứa ký tự đặc biệt hoặc chữ cái.");
                txtCMND.Focus();
                return;
            }

          
            if (!IsValidPhoneNumber(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số, không chứa ký tự đặc biệt, bắt đầu bằng số 0.");
                txtDienThoai.Focus();
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    
                    string checkCustomerQuery = "SELECT COUNT(*) FROM KHACHHANG WHERE MAKHACHHANG = @MAKHACHHANG";
                    using (SqlCommand checkCommand = new SqlCommand(checkCustomerQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MAKHACHHANG", maKhachHang);
                        int customerExists = (int)checkCommand.ExecuteScalar();

                        if (customerExists > 0)
                        {
                            MessageBox.Show("Mã khách hàng đã tồn tại! Vui lòng nhập mã khách hàng mới.");
                            txtMaKhachHang.Clear();
                            txtMaKhachHang.Focus();
                            return;
                        }
                    }

                
                    string querySoHoaDonThue = "SELECT SHDTHUEPHONG FROM THUEPHONG WHERE MAPHONG = @MAPHONG";
                    string soHoaDonThue = null;
                    using (SqlCommand command = new SqlCommand(querySoHoaDonThue, connection))
                    {
                        command.Parameters.AddWithValue("@MAPHONG", phongNguoiDungChon);
                        soHoaDonThue = command.ExecuteScalar() as string;
                    }

                    if (string.IsNullOrEmpty(soHoaDonThue))
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn thuê phòng cho phòng này!");
                        return;
                    }

                    if (KiemTraKhachHangTonTaiTrongPhong(maKhachHang, soHoaDonThue))
                    {
                        MessageBox.Show("Khách hàng đã tồn tại trong phòng này!");
                        return;
                    }   
                    string insertCustomerQuery = @"
												INSERT INTO KHACHHANG (MAKHACHHANG, HOTEN, CMND, GIOITINH, DIACHI, DIENTHOAI)
												VALUES (@MAKHACHHANG, @HOTEN, @CMND, @GIOITINH, @DIACHI, @DIENTHOAI)";
                    using (SqlCommand command = new SqlCommand(insertCustomerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MAKHACHHANG", maKhachHang);
                        command.Parameters.AddWithValue("@HOTEN", txtHoTen.Text.Trim());
                        command.Parameters.AddWithValue("@CMND", txtCMND.Text.Trim());
                        command.Parameters.AddWithValue("@GIOITINH", radNam.Checked ? 1 : 0);
                        command.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text);
                        command.Parameters.AddWithValue("@DIENTHOAI", txtDienThoai.Text.Trim());
                        command.ExecuteNonQuery();
                    }
                    string insertRoomDetailQuery = @"
													INSERT INTO CHITIETTHUEPHONG (SHDTHUEPHONG, MAKHACHHANG) 
													VALUES (@SHDTHUEPHONG, @MAKHACHHANG)";
                    using (SqlCommand roomCommand = new SqlCommand(insertRoomDetailQuery, connection))
                    {
                        roomCommand.Parameters.AddWithValue("@SHDTHUEPHONG", soHoaDonThue);
                        roomCommand.Parameters.AddWithValue("@MAKHACHHANG", maKhachHang);
                        roomCommand.ExecuteNonQuery();
                    }
                      
                    MessageBox.Show("Thêm khách hàng vào phòng thành công!");
                    LoadKhachHangTheoPhong(phongNguoiDungChon);
                }
                catch (Exception ex)
                {
                
                    MessageBox.Show("Lỗi khi thêm khách hàng vào phòng: " + ex.ToString());
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maKhachHang = txtMaKhachHang.Text.Trim(); // Mã khách hàng

            // Kiểm tra các trường không được để trống
            if (string.IsNullOrEmpty(maKhachHang) || string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtCMND.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            // Validate Mã khách hàng
            if (!IsValidMaKhachHang(maKhachHang))
            {
                MessageBox.Show("Mã khách hàng không được chứa ký tự đặc biệt.");
                txtMaKhachHang.Focus();
                return;
            }

            // Validate Họ tên
            if (!IsValidHoTen(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được chứa số và ký tự đặc biệt.");
                txtHoTen.Focus();
                return;
            }

            // Validate Địa chỉ
            if (!IsValidDiaChi(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được chứa ký tự đặc biệt.");
                txtDiaChi.Focus();
                return;
            }

            // Validate CMND
            if (!IsValidCMND(txtCMND.Text.Trim()))
            {
                MessageBox.Show("CMND phải có 12 chữ số, không chứa ký tự đặc biệt hoặc chữ cái.");
                txtCMND.Focus();
                return;
            }

            // Validate Số điện thoại
            if (!IsValidPhoneNumber(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số, không chứa ký tự đặc biệt, bắt đầu bằng số 0.");
                txtDienThoai.Focus();
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Kiểm tra xem mã khách hàng có tồn tại không
                    string checkCustomerQuery = "SELECT COUNT(*) FROM KHACHHANG WHERE MAKHACHHANG = @MAKHACHHANG";
                    using (SqlCommand checkCommand = new SqlCommand(checkCustomerQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MAKHACHHANG", maKhachHang);
                        int customerExists = (int)checkCommand.ExecuteScalar();

                        if (customerExists == 0)
                        {
                            MessageBox.Show("Mã khách hàng không tồn tại!");
                            return;
                        }
                    }

                    // Cập nhật thông tin khách hàng
                    string updateCustomerQuery = @"
                UPDATE KHACHHANG 
                SET HOTEN = @HOTEN, GIOITINH = @GIOITINH, DIACHI = @DIACHI, DIENTHOAI = @DIENTHOAI 
                WHERE MAKHACHHANG = @MAKHACHHANG";

                    using (SqlCommand updateCommand = new SqlCommand(updateCustomerQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@MAKHACHHANG", maKhachHang);
                        updateCommand.Parameters.AddWithValue("@HOTEN", txtHoTen.Text.Trim());
                        updateCommand.Parameters.AddWithValue("@GIOITINH", radNam.Checked ? 1 : 0);
                        updateCommand.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text.Trim());
                        updateCommand.Parameters.AddWithValue("@DIENTHOAI", txtDienThoai.Text.Trim());

                        int result = updateCommand.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Sửa thông tin khách hàng thành công!");
                            ResetHienThi();
                            LoadKhachHangTheoPhong(Phong_Nguoi_Dung_Chon);
                        }
                        else
                        {
                            MessageBox.Show("Sửa thông tin khách hàng thất bại.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa thông tin khách hàng: " + ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
		{
			string maKhachHang = txtMaKhachHang.Text.Trim();

			// Xác nhận người dùng có chắc chắn muốn xóa khách hàng
			if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					try
					{
						connection.Open();			
						string deleteDetailQuery = "DELETE FROM CHITIETTHUEPHONG WHERE MAKHACHHANG = @MAKHACHHANG";
						using (SqlCommand command = new SqlCommand(deleteDetailQuery, connection))
						{
							command.Parameters.AddWithValue("@MAKHACHHANG", maKhachHang);

							int result = command.ExecuteNonQuery();
							if (result > 0)
							{							
								string deleteCustomerQuery = "DELETE FROM KHACHHANG WHERE MAKHACHHANG = @MAKHACHHANG";
								using (SqlCommand deleteCustomerCommand = new SqlCommand(deleteCustomerQuery, connection))
								{
									deleteCustomerCommand.Parameters.AddWithValue("@MAKHACHHANG", maKhachHang);
									deleteCustomerCommand.ExecuteNonQuery();
								}

								MessageBox.Show("Xóa khách hàng thành công!");
								ResetHienThi();
								LoadKhachHangTheoPhong(Phong_Nguoi_Dung_Chon); // Cập nhật lại danh sách khách hàng theo phòng						
							}
							else
							{
								MessageBox.Show("Xóa khách hàng thất bại.");
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
					}
				}
			}
		}
		private void btnDangKiThue_Click(object sender, EventArgs e)
		{
			
			DangKiPhongThue dangKiPhongThue = new DangKiPhongThue(this,Phong_Nguoi_Dung_Chon);
			dangKiPhongThue.Show();
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
