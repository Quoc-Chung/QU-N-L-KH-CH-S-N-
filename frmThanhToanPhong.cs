using BAITAPLON.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

/*- THÊM HAI THƯ VIỆN ĐỂ IN HÓA ĐƠN -*/
using Aspose.Words;
using System.IO;

namespace BAITAPLON
{
	public partial class frmThanhToanPhong : Form
    {
		private SqlConnection connection;
		private string connectionString = ConnectString.ConecString;
		private SqlCommand command;
		
		public String PhongDangChon; 
		
		public frmThanhToanPhong()
        {
            InitializeComponent();
			
		}
		private void frmThanhToanPhong_Load(object sender, EventArgs e)
		{
			LOAD_SO_HOA_DON();
		}
		public void LOAD_SO_HOA_DON()
		{
			// TRUY XUẤT NHỮNG PHÒNG ĐANG ĐƯỢC KHÁCH HÀNG THUÊ
			string truy_xuat_khach_hang_thue = @"
                                               SELECT DISTINCT THUEPHONG.SHDTHUEPHONG FROM THUEPHONG 
                                               INNER JOIN DANHMUCPHONG ON DANHMUCPHONG.MAPHONG = THUEPHONG.MAPHONG
                                               WHERE TINHTRANG = 1;";
			using (connection = new SqlConnection(connectionString))
			{
				using (command = new SqlCommand(truy_xuat_khach_hang_thue, connection))
				{
					try
					{
						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								// Thêm MAPHONG vào ComboBox
								cboMaPhong.Items.Add(reader["SHDTHUEPHONG"].ToString());
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
		}
		private void cboMaPhong_SelectedIndexChanged(object sender, EventArgs e)
		{
			PhongDangChon = cboMaPhong.SelectedItem.ToString();
		}

		private void btnThanhToan_Click(object sender, EventArgs e)
		{
			string maPhongThue = cboMaPhong.Text.Trim();
			if (string.IsNullOrEmpty(maPhongThue))
			{
				MessageBox.Show("Vui lòng chọn mã phòng thuê.");
				return;
			}

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();
					using (SqlTransaction transaction = conn.BeginTransaction())
					{
						try
						{
							// 1. Xóa thông tin dịch vụ sử dụng
							string deleteSuDungDichVuQuery = "DELETE FROM SUDUNGDICHVU WHERE SHDTHUEPHONG = @SHDThuePhong";
							using (SqlCommand cmd = new SqlCommand(deleteSuDungDichVuQuery, conn, transaction))
							{
								cmd.Parameters.AddWithValue("@SHDThuePhong", maPhongThue);
								cmd.ExecuteNonQuery();
							}

							// 2. Xóa thông tin chi tiết thuê phòng
							string deleteChiTietThuePhongQuery = "DELETE FROM CHITIETTHUEPHONG WHERE SHDTHUEPHONG = @SHDThuePhong";
							using (SqlCommand cmd = new SqlCommand(deleteChiTietThuePhongQuery, conn, transaction))
							{
								cmd.Parameters.AddWithValue("@SHDThuePhong", maPhongThue);
								cmd.ExecuteNonQuery();
							}

							// 3. Xóa thông tin thanh toán phòng
							string deleteHoaDonThanhToanQuery = "DELETE FROM HDTHANHTOANPHONG WHERE SHDTHUEPHONG = @SHDThuePhong";
							using (SqlCommand cmd = new SqlCommand(deleteHoaDonThanhToanQuery, conn, transaction))
							{
								cmd.Parameters.AddWithValue("@SHDThuePhong", maPhongThue);
								cmd.ExecuteNonQuery();
							}

							// 4. Lấy mã phòng từ thông tin thuê phòng
							string getMaPhongQuery = "SELECT MAPHONG FROM THUEPHONG WHERE SHDTHUEPHONG = @SHDThuePhong";
							string maPhong = null;
							using (SqlCommand cmd = new SqlCommand(getMaPhongQuery, conn, transaction))
							{
								cmd.Parameters.AddWithValue("@SHDThuePhong", maPhongThue);
								maPhong = (string)cmd.ExecuteScalar();
							}

							string deleteThuePhongQuery = "DELETE FROM THUEPHONG WHERE SHDTHUEPHONG = @SHDThuePhong";
							using (SqlCommand cmd = new SqlCommand(deleteThuePhongQuery, conn, transaction))
							{
								cmd.Parameters.AddWithValue("@SHDThuePhong", maPhongThue);
								cmd.ExecuteNonQuery();
							}

							if (maPhong != null)
							{
								string updatePhongQuery = "UPDATE DANHMUCPHONG SET TINHTRANG = 0 WHERE MAPHONG = @MaPhong";
								using (SqlCommand cmd = new SqlCommand(updatePhongQuery, conn, transaction))
								{
									cmd.Parameters.AddWithValue("@MaPhong", maPhong);
									cmd.ExecuteNonQuery();
								}
							}

							transaction.Commit();
							MessageBox.Show("Thanh toán phòng thành công!");
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							MessageBox.Show("Có lỗi xảy ra khi thanh toán  phòng: " + ex.Message);
						}
					}
				}
				catch (SqlException ex)
				{
					MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
				}
			}
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private HoaDon LayThongTinHoaDon(string maPhongThue, bool xuatHoaDon = false)
		{
			if (string.IsNullOrEmpty(maPhongThue))
			{
				MessageBox.Show("Vui lòng chọn mã phòng thuê.");
				return null;
			}

			HoaDon hoaDon = new HoaDon();
			hoaDon.DichVuList = new List<DichVu>();

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();

					// Query to get basic room rental details
					string query = @"
						SELECT tp.NGAYTHUE, tp.NGAYTRA, lp.GIATIEN AS GiaPhong, nv.HOTEN AS TenNhanVien, tp.MaPhong AS MaPhong
						FROM THUEPHONG tp
						INNER JOIN DANHMUCPHONG dp ON tp.MAPHONG = dp.MAPHONG
						INNER JOIN LOAIPHONG lp ON dp.MALOAIPHONG = lp.MALOAIPHONG
						LEFT JOIN NHANVIEN nv ON tp.MANHANVIEN = nv.MANHANVIEN
						WHERE tp.SHDTHUEPHONG = @SHDThuePhong;
					";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@SHDThuePhong", maPhongThue);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								hoaDon.NgayThue = reader.GetDateTime(reader.GetOrdinal("NGAYTHUE"));
								hoaDon.NgayTra = reader.GetDateTime(reader.GetOrdinal("NGAYTRA"));
								hoaDon.GiaPhong = reader.GetDecimal(reader.GetOrdinal("GiaPhong"));
								hoaDon.MaPhong = reader.IsDBNull(reader.GetOrdinal("MaPhong")) ? "N/A" : reader.GetString(reader.GetOrdinal("MaPhong"));
								hoaDon.TenNhanVien = reader.IsDBNull(reader.GetOrdinal("TenNhanVien")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNhanVien"));

								hoaDon.SoNgayThue = (hoaDon.NgayTra - hoaDon.NgayThue).Days;
								hoaDon.TongTienPhong = hoaDon.SoNgayThue * hoaDon.GiaPhong;
							}
						}
					}

					// Query to get service details
					string serviceQuery = @"
                SELECT tb.TENTHIETBI, sd.SOLUONG, tb.GIATIEN, (sd.SOLUONG * tb.GIATIEN) AS ThanhTien
                FROM SUDUNGDICHVU sd
                INNER JOIN THIETBI_DICHVU tb ON sd.MATHIETBI = tb.MATHIETBI
                WHERE sd.SHDTHUEPHONG = @SHDThuePhong;
            ";

					using (SqlCommand serviceCmd = new SqlCommand(serviceQuery, conn))
					{
						serviceCmd.Parameters.AddWithValue("@SHDThuePhong", maPhongThue);

						using (SqlDataReader serviceReader = serviceCmd.ExecuteReader())
						{
							hoaDon.TongTienDichVu = 0;
							bool hasService = false;

							while (serviceReader.Read())
							{
								hasService = true;
								DichVu dichVu = new DichVu
								{
									TenDichVu = serviceReader.GetString(serviceReader.GetOrdinal("TENTHIETBI")),
									SoLuong = serviceReader.GetInt32(serviceReader.GetOrdinal("SOLUONG")),
									GiaDichVu = serviceReader.GetDecimal(serviceReader.GetOrdinal("GIATIEN")),
									ThanhTien = serviceReader.GetDecimal(serviceReader.GetOrdinal("ThanhTien"))
								};

								hoaDon.DichVuList.Add(dichVu);
								hoaDon.TongTienDichVu += dichVu.ThanhTien;
							}
							if (!hasService)
							{
								hoaDon.DichVuList.Add(new DichVu { TenDichVu = "Không có dịch vụ nào được sử dụng." });
							}
							hoaDon.TongTien = hoaDon.TongTienPhong + hoaDon.TongTienDichVu;
						}
					}
				}
				catch (SqlException ex)
				{
					MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
					return null;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
					return null;
				}
			}

			return hoaDon;
		}

		private void btnXem_Click(object sender, EventArgs e)
		{
			string maPhongThue = cboMaPhong.Text.Trim();
			HoaDon hoaDon = LayThongTinHoaDon(maPhongThue, xuatHoaDon: false);

			if (hoaDon != null)
			{
				txtBaoCao.Clear();
				txtBaoCao.Text += "Nhân viên thanh toán: \t" + hoaDon.TenNhanVien + "\r\n";
				txtBaoCao.Text += "Mã phòng \t\t" + hoaDon.MaPhong + "\r\n";
				txtBaoCao.Text += "Mã số phòng thuê: \t\t" + hoaDon.MaPhongThue + "\r\n";
				txtBaoCao.Text += "Ngày thuê: \t\t" + hoaDon.NgayThue.ToShortDateString() + "\r\n";
				txtBaoCao.Text += "Ngày trả: \t\t\t" + hoaDon.NgayTra.ToShortDateString() + "\r\n";
				txtBaoCao.Text += "Số ngày thuê: \t\t" + hoaDon.SoNgayThue + "\r\n";
				txtBaoCao.Text += "Phí thuê phòng: \t\t" + hoaDon.GiaPhong.ToString("c") + "\r\n";
				txtBaoCao.Text += "Tổng tiền phòng: \t\t" + hoaDon.TongTienPhong.ToString("c") + "\r\n";
				txtBaoCao.Text += "Dịch vụ sử dụng:\r\n";

				foreach (var dichVu in hoaDon.DichVuList)
				{
					txtBaoCao.Text += $"- {dichVu.TenDichVu}: {dichVu.SoLuong} x {dichVu.GiaDichVu.ToString("c")} = {dichVu.ThanhTien.ToString("c")}\r\n";
				}

				txtBaoCao.Text += "Tổng tiền dịch vụ: \t" + hoaDon.TongTienDichVu.ToString("c") + "\r\n";
				txtBaoCao.Text += "--------------------------------------------------------\r\n";
				txtBaoCao.Text += "Tổng cộng: \t\t" + hoaDon.TongTien.ToString("c");
			}
		}

		private void btnInHoaDon_Click(object sender, EventArgs e)
		{
			string maPhongThue = cboMaPhong.Text.Trim();
			HoaDon hoaDon = LayThongTinHoaDon(maPhongThue, xuatHoaDon: true);

			if (hoaDon != null)
			{
				try
				{
					string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template\\Mau_Bao_Cao.doc");
					Document baoCao = new Document(templatePath);


					// Bước 2: Tạo danh sách các trường và giá trị tương ứng
					var fields = new Dictionary<string, string>
			{
				{ "HO_TEN", hoaDon.TenNhanVien },
				{ "Ma_Phong", hoaDon.MaPhong },
				{ "Ma_So_Phong_Thue", hoaDon.MaPhongThue },
				{ "Ngay_Thue", hoaDon.NgayThue.ToShortDateString() },
				{ "Ngay_Tra", hoaDon.NgayTra.ToShortDateString() },
				{ "So_Ngay_Thue", hoaDon.SoNgayThue.ToString() },
				{ "Phi_Tien_Phong", hoaDon.GiaPhong.ToString("c") },
				{ "Tong_Tien_Phong", hoaDon.TongTienPhong.ToString("c") },
				{ "Tong_Tien_Dich_Vu", hoaDon.TongTienDichVu.ToString("c") },
				{ "Tong_Tien", hoaDon.TongTien.ToString("c") }
			};

					// Bước 3: Điền các trường vào mẫu bằng MailMerge
					foreach (var field in fields)
					{
						baoCao.MailMerge.Execute(new[] { field.Key }, new[] { field.Value });
					}

					// Bước 4: Sử dụng SaveFileDialog để chọn vị trí lưu
					using (SaveFileDialog saveFileDialog = new SaveFileDialog())
					{
						saveFileDialog.Filter = "Word Document (*.docx)|*.docx";
						saveFileDialog.FileName = "HoaDon_" + hoaDon.MaPhongThue + ".docx";

						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							baoCao.Save(saveFileDialog.FileName); // Lưu file theo đường dẫn người dùng chọn

							// Mở file sau khi lưu (tuỳ chọn)
							System.Diagnostics.Process.Start(saveFileDialog.FileName);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Có lỗi xảy ra khi in hóa đơn: " + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Không tìm thấy thông tin hóa đơn.");
			}
		}

	}
}
