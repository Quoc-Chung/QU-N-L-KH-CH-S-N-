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

		public static string  maPhongThue;
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
            string truy_xuat_khach_hang_thue = @"
        SELECT DISTINCT THUEPHONG.SHDTHUEPHONG 
        FROM THUEPHONG 
        INNER JOIN DANHMUCPHONG ON DANHMUCPHONG.MAPHONG = THUEPHONG.MAPHONG
        WHERE TINHTRANG = 1;";

            using (connection = new SqlConnection(connectionString))
            {
                using (command = new SqlCommand(truy_xuat_khach_hang_thue, connection))
                {
                    try
                    {
                        connection.Open();
                        // Xóa hết các mục trong ComboBox trước khi tải lại
                        cboMaPhong.Items.Clear();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Thêm mục mới vào ComboBox
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
            maPhongThue = cboMaPhong.Text.Trim();
            HoaDon hoaDon = LayThongTinHoaDon(maPhongThue, xuatHoaDon: false);
            if (hoaDon != null)
            {
                string insertQuery = @"
    INSERT INTO LICHSUDATPHONG 
    (SHDTHUEPHONG, MAPHONG, TENNHANVIEN, MAKHACHHANG, NGAYTHUE, NGAYTRA, SONGAYTHUE, TONGTIENPHONG, TONGTIENDICHVU)
    VALUES (@SHDTHUEPHONG, @MAPHONG, @TENNHANVIEN, @MAKHACHHANG, @NGAYTHUE, @NGAYTRA, @SONGAYTHUE, @TONGTIENPHONG, @TONGTIENDICHVU);
";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@SHDTHUEPHONG", hoaDon.MaPhongThue);
                            cmd.Parameters.AddWithValue("@MAPHONG", hoaDon.MaPhong);
                            cmd.Parameters.AddWithValue("@TENNHANVIEN", hoaDon.TenNhanVien);  // Đã sửa từ TENTAIKHOAN thành TENNHANVIEN
                            cmd.Parameters.AddWithValue("@MAKHACHHANG", hoaDon.maKhachHang);
                            cmd.Parameters.AddWithValue("@NGAYTHUE", hoaDon.NgayThue);
                            cmd.Parameters.AddWithValue("@NGAYTRA", hoaDon.NgayTra);
                            cmd.Parameters.AddWithValue("@SONGAYTHUE", hoaDon.SoNgayThue);
                            cmd.Parameters.AddWithValue("@TONGTIENPHONG", hoaDon.TongTienPhong);
                            cmd.Parameters.AddWithValue("@TONGTIENDICHVU", hoaDon.TongTienDichVu);

                            cmd.ExecuteNonQuery();  // Thực thi câu lệnh INSERT
                            MessageBox.Show("Dữ liệu đã được chèn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi khi chèn dữ liệu vào bảng LICHSUDATPHONG: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    }
                }


            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin hóa đơn.");
                return;
            }

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
                            // Xóa dữ liệu từ các bảng khác
                            string deleteSuDungDichVuQuery = "DELETE FROM SUDUNGDICHVU WHERE SHDTHUEPHONG = @SHDThuePhong";
                            using (SqlCommand cmd = new SqlCommand(deleteSuDungDichVuQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@SHDThuePhong", maPhongThue);
                                cmd.ExecuteNonQuery();
                            }

                            string deleteChiTietThuePhongQuery = "DELETE FROM CHITIETTHUEPHONG WHERE SHDTHUEPHONG = @SHDThuePhong";
                            using (SqlCommand cmd = new SqlCommand(deleteChiTietThuePhongQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@SHDThuePhong", maPhongThue);
                                cmd.ExecuteNonQuery();
                            }

                            string deleteHoaDonThanhToanQuery = "DELETE FROM HDTHANHTOANPHONG WHERE SHDTHUEPHONG = @SHDThuePhong";
                            using (SqlCommand cmd = new SqlCommand(deleteHoaDonThanhToanQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@SHDThuePhong", maPhongThue);
                                cmd.ExecuteNonQuery();
                            }

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
                            cboMaPhong.Items.Clear();
                            LOAD_SO_HOA_DON();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Có lỗi xảy ra khi thanh toán phòng: " + ex.Message);
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

        private HoaDon LayThongTinHoaDon(string maSoThuePhong, bool xuatHoaDon = false)
        {
            if (string.IsNullOrEmpty(maSoThuePhong))
            {
                MessageBox.Show("Vui lòng chọn mã số thuê phòng.");
                return null;
            }

            HoaDon hoaDon = new HoaDon
            {
                MaPhongThue = maSoThuePhong,
                DichVuList = new List<DichVu>()
            };

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Lấy thông tin thuê phòng
                    string query = @"
                        SELECT tp.NGAYTHUE, tp.NGAYTRA, lp.GIATIEN AS GiaPhong, nv.HOTEN AS TenNhanVien, tp.MaPhong AS MaPhong, ct.MaKhachHang AS MaKhachHang
                        FROM THUEPHONG tp
                        INNER JOIN DANHMUCPHONG dp ON tp.MAPHONG = dp.MAPHONG
                        INNER JOIN LOAIPHONG lp ON dp.MALOAIPHONG = lp.MALOAIPHONG
                        INNER JOIN CHITIETTHUEPHONG ct ON ct.SHDTHUEPHONG = tp.SHDTHUEPHONG
                        LEFT JOIN TAI_KHOAN nv ON tp.MATAIKHOAN = nv.MATAIKHOAN
                        WHERE tp.SHDTHUEPHONG = @SHDThuePhong;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SHDThuePhong", maSoThuePhong);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hoaDon.maKhachHang = reader.IsDBNull(reader.GetOrdinal("MaKhachHang")) ? "N/A" : reader.GetString(reader.GetOrdinal("MaKhachHang"));
                                hoaDon.NgayThue = reader.GetDateTime(reader.GetOrdinal("NGAYTHUE"));
                                hoaDon.NgayTra = reader.GetDateTime(reader.GetOrdinal("NGAYTRA"));
                                hoaDon.GiaPhong = reader.GetDecimal(reader.GetOrdinal("GiaPhong"));
                                hoaDon.MaPhong = reader["MaPhong"] as string ?? "N/A";
                                hoaDon.TenNhanVien = reader["TenNhanVien"] as string ?? "N/A";

                                if (hoaDon.NgayTra < hoaDon.NgayThue)
                                {
                                    MessageBox.Show("Ngày trả không hợp lệ.");
                                    return null;
                                }

                                hoaDon.SoNgayThue = (hoaDon.NgayTra - hoaDon.NgayThue).Days;
                                hoaDon.TongTienPhong = hoaDon.SoNgayThue * hoaDon.GiaPhong;
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy thông tin thuê phòng.");
                                return null;
                            }
                        }
                    }
                    string serviceQuery = @"
            SELECT tb.TENTHIETBI, sd.SOLUONG, tb.GIATIEN, (sd.SOLUONG * tb.GIATIEN) AS ThanhTien
            FROM SUDUNGDICHVU sd
            INNER JOIN THIETBI_DICHVU tb ON sd.MATHIETBI = tb.MATHIETBI
            WHERE sd.SHDTHUEPHONG = @SHDThuePhong;";

                    using (SqlCommand serviceCmd = new SqlCommand(serviceQuery, conn))
                    {
                        serviceCmd.Parameters.AddWithValue("@SHDThuePhong", maSoThuePhong);

                        using (SqlDataReader serviceReader = serviceCmd.ExecuteReader())
                        {
                            hoaDon.TongTienDichVu = 0;

                            while (serviceReader.Read())
                            {
                                var dichVu = new DichVu
                                {
                                    TenDichVu = serviceReader["TENTHIETBI"] as string,
                                    SoLuong = serviceReader.GetInt32(serviceReader.GetOrdinal("SOLUONG")),
                                    GiaDichVu = serviceReader.GetDecimal(serviceReader.GetOrdinal("GIATIEN")),
                                    ThanhTien = serviceReader.GetDecimal(serviceReader.GetOrdinal("ThanhTien"))
                                };

                                hoaDon.DichVuList.Add(dichVu);
                                hoaDon.TongTienDichVu += dichVu.ThanhTien;
                            }
                        }
                    }

                    hoaDon.TongTien = hoaDon.TongTienPhong + hoaDon.TongTienDichVu;
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
                txtBaoCao.Text += "Phí thuê phòng: \t\t" + hoaDon.GiaPhong.ToString("0.##") + "\r\n";
                txtBaoCao.Text += "Tổng tiền phòng: \t\t" + hoaDon.TongTienPhong.ToString("0.##") + "\r\n";
                txtBaoCao.Text += "Dịch vụ sử dụng:\r\n";

                foreach (var dichVu in hoaDon.DichVuList)
                {
                    txtBaoCao.Text += $"- {dichVu.TenDichVu}: {dichVu.SoLuong} x {dichVu.GiaDichVu.ToString("0.##")} = {dichVu.ThanhTien.ToString("0.##")}\r\n";
                }

                txtBaoCao.Text += "Tổng tiền dịch vụ: \t" + hoaDon.TongTienDichVu.ToString("0.##") + "\r\n";
                txtBaoCao.Text += "--------------------------------------------------------\r\n";
                txtBaoCao.Text += "Tổng cộng: \t\t" + hoaDon.TongTien.ToString("0.##");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
				{ "Phi_Tien_Phong", hoaDon.GiaPhong.ToString("0.##") },
				{ "Tong_Tien_Phong", hoaDon.TongTienPhong.ToString("0.##") },
				{ "Tong_Tien_Dich_Vu", hoaDon.TongTienDichVu.ToString("0.##") },
				{ "Tong_Tien", hoaDon.TongTien.ToString("0.##") }
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
