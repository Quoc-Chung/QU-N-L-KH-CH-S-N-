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
    public partial class frmThanhToanPhong : Form
    {
		private SqlConnection connection;
		private string connectionString = "Data Source=LAPTOP-LACSE5QS\\SQLEXPRESS;Initial Catalog=QUANLI_KHACHSAN_BTL;Integrated Security=True;";
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


		private void btnXem_Click(object sender, EventArgs e)
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

					// Query to get basic room rental details
					string query = @"
									SELECT tp.NGAYTHUE, tp.NGAYTRA, lp.GIATIEN AS GiaPhong, nv.HOTEN AS TenNhanVien
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
								DateTime ngayThue = reader.GetDateTime(reader.GetOrdinal("NGAYTHUE"));
								DateTime ngayTra = reader.GetDateTime(reader.GetOrdinal("NGAYTRA"));
								decimal giaPhong = reader.GetDecimal(reader.GetOrdinal("GiaPhong"));
								string HOTEN = reader.IsDBNull(reader.GetOrdinal("TenNhanVien")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNhanVien"));

								int soNgayThue = (ngayTra - ngayThue).Days;
								decimal tongTienPhong = soNgayThue * giaPhong;

								txtBaoCao.Clear();
								txtBaoCao.Text += "Nhân viên thanh toán: \t" + HOTEN + "\r\n";
								txtBaoCao.Text += "Mã số phòng thuê: \t\t" + maPhongThue + "\r\n";
								txtBaoCao.Text += "Ngày thuê: \t\t" + ngayThue.ToShortDateString() + "\r\n";
								txtBaoCao.Text += "Ngày trả: \t\t\t" + ngayTra.ToShortDateString() + "\r\n";
								txtBaoCao.Text += "Số ngày thuê: \t\t" + soNgayThue + "\r\n";
								txtBaoCao.Text += "Phí thuê phòng: \t\t" + giaPhong.ToString("c") + "\r\n";
								txtBaoCao.Text += "Tổng tiền phòng: \t\t" + tongTienPhong.ToString("c") + "\r\n";
								txtBaoCao.Text += "Dịch vụ sử dụng:\r\n";

								reader.Close();

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
										decimal tongTienDichVu = 0;
										bool hasService = false;

										while (serviceReader.Read())
										{
											hasService = true;
											string tenDichVu = serviceReader.GetString(serviceReader.GetOrdinal("TENTHIETBI"));
											int soLuong = serviceReader.GetInt32(serviceReader.GetOrdinal("SOLUONG"));
											decimal giaDichVu = serviceReader.GetDecimal(serviceReader.GetOrdinal("GIATIEN"));
											decimal thanhTien = serviceReader.GetDecimal(serviceReader.GetOrdinal("ThanhTien"));

											tongTienDichVu += thanhTien;

											txtBaoCao.Text += $"- {tenDichVu}: {soLuong} x {giaDichVu.ToString("c")} = {thanhTien.ToString("c")}\r\n";
										}

										if (!hasService)
										{
											txtBaoCao.Text += "- Không có dịch vụ nào được sử dụng.\r\n";
										}

										txtBaoCao.Text += "Tổng tiền dịch vụ: \t" + tongTienDichVu.ToString("c") + "\r\n";
										txtBaoCao.Text += "--------------------------------------------------------\r\n";
										txtBaoCao.Text += "Tổng cộng: \t\t" + (tongTienPhong + tongTienDichVu).ToString("c");
									}
								}
							}
							else
							{
								MessageBox.Show("Không tìm thấy thông tin cho mã phòng này.");
							}
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



		private void cboMaPhong_SelectedIndexChanged(object sender, EventArgs e)
		{
			PhongDangChon= cboMaPhong.SelectedItem.ToString();
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

							// 5. Xóa thông tin thuê phòng
							string deleteThuePhongQuery = "DELETE FROM THUEPHONG WHERE SHDTHUEPHONG = @SHDThuePhong";
							using (SqlCommand cmd = new SqlCommand(deleteThuePhongQuery, conn, transaction))
							{
								cmd.Parameters.AddWithValue("@SHDThuePhong", maPhongThue);
								cmd.ExecuteNonQuery();
							}

							// 6. Cập nhật trạng thái phòng về "Chưa Thuê"
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
							MessageBox.Show("Xóa phòng thành công!");
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							MessageBox.Show("Có lỗi xảy ra khi xóa phòng: " + ex.Message);
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

	}
}
