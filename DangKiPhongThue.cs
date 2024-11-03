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
	public partial class DangKiPhongThue : Form
	{
		String maPhong_DangKi;

		String MaNhanVien = "NV001";

		DateTime ngayThue;
		DateTime ngayTra;

		private SqlConnection connection;
		private string connectionString = "Data Source=LAPTOP-LACSE5QS\\SQLEXPRESS;Initial Catalog=QUANLI_KHACHSAN_BTL;Integrated Security=True;";
		private SqlCommand command;

		frmPhongThue frmPhongThue;

		public DangKiPhongThue(frmPhongThue phong,string maPhong_DangKi)
		{
			InitializeComponent();
			this.frmPhongThue = phong;
			this.maPhong_DangKi = maPhong_DangKi;

			connection = new SqlConnection(connectionString);
		}

		private void DangKiPhongThue_Load(object sender, EventArgs e)
		{
			txtSoHoaDon.Text = "THP0XX";
			txtMaPhongDangKi.Text = maPhong_DangKi;
		}
		private void btnDangKi_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(txtSoHoaDon.Text))
				{
					MessageBox.Show("Số hóa đơn không được để trống!");
					return;
				}
				DateTime ngayThue = dateTimeNgayThue.Value; 
				DateTime ngayTra = dateTimeNgayTra.Value; 
				if (ngayTra <= ngayThue)
				{
					MessageBox.Show("Ngày trả phải lớn hơn ngày thuê!");
					return;
				}
				connection.Open();
				string updateRoomQuery = "UPDATE DANHMUCPHONG SET TINHTRANG = 1 WHERE MAPHONG = @MAPHONG";
				using (SqlCommand updateRoomCommand = new SqlCommand(updateRoomQuery, connection))
				{
					updateRoomCommand.Parameters.AddWithValue("@MAPHONG", maPhong_DangKi);
					updateRoomCommand.ExecuteNonQuery();
				}

				// Thêm thông tin thuê phòng vào bảng THUEPHONG
				string insertRentalQuery = @"
                INSERT INTO THUEPHONG (SHDTHUEPHONG, MANHANVIEN, MAPHONG, NGAYTHUE, NGAYTRA)
                VALUES (@SHDTHUEPHONG, @MANHANVIEN, @MAPHONG, @NGAYTHUE, @NGAYTRA)";
				using (SqlCommand insertRentalCommand = new SqlCommand(insertRentalQuery, connection))
				{
					insertRentalCommand.Parameters.AddWithValue("@SHDTHUEPHONG", txtSoHoaDon.Text.Trim());
					insertRentalCommand.Parameters.AddWithValue("@MANHANVIEN", MaNhanVien);
					insertRentalCommand.Parameters.AddWithValue("@MAPHONG", maPhong_DangKi);
					insertRentalCommand.Parameters.AddWithValue("@NGAYTHUE", ngayThue);
					insertRentalCommand.Parameters.AddWithValue("@NGAYTRA", ngayTra);
					insertRentalCommand.ExecuteNonQuery();
				}
				MessageBox.Show("Đăng ký phòng thành công!Vui long thêm khách hàng vào phòng vừa đăng kí.");

				this.Close();

				frmPhongThue.LoadData(); 
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi đăng ký phòng: " + ex.Message);
			}
			finally
			{
				if (connection.State == ConnectionState.Open)
				{
					connection.Close(); 
				}
			}
		}
	}
}
