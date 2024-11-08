using BAITAPLON.Model;
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
    public partial class frmThietBi : Form
    {
		string connectionstring = ConnectString.ConecString;
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adt = new SqlDataAdapter();
		DataTable dt = new DataTable();
		DataView dv;
		public frmThietBi()
        {
            InitializeComponent();
			dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
		}

		private void frmThietBi_Load(object sender, EventArgs e)
		{
			con = new SqlConnection(connectionstring);
			cmd = con.CreateCommand();
			cmd.CommandText = "select * from THIETBI_DICHVU";
			adt.SelectCommand = cmd;
			dt.Clear();
			adt.Fill(dt);
			dv = new DataView(dt);
			dataGridView1.DataSource = dt;
		}
		private void LoadData()
		{
			cmd = con.CreateCommand();
			cmd.CommandText = "SELECT * FROM THIETBI_DICHVU";
			adt.SelectCommand = cmd;
			dt.Clear();
			adt.Fill(dt);
			dv = new DataView(dt);
			dataGridView1.DataSource = dt;
		}
		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			// Kiểm tra xem có dòng nào được chọn không
			if (dataGridView1.SelectedRows.Count > 0)
			{
				// Lấy dòng đầu tiên được chọn
				DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

				// Gán giá trị vào các TextBox tương ứng
				txtMaTB.Text = selectedRow.Cells["MATHIETBI"].Value.ToString(); // Giả sử cột mã loại phòng có tên là "MaLoaiP"
				txtTenTB.Text = selectedRow.Cells["TENTHIETBI"].Value.ToString();  // Giả sử cột tên loại phòng có tên là "TenLoaiP"
				txtDVT.Text = selectedRow.Cells["DONVITINH"].Value.ToString();          // Giả sử cột giá có tên là "Gia"
				txtGia.Text = selectedRow.Cells["GIATIEN"].Value.ToString();

			}
		}

		private void cmdAdd_Click(object sender, EventArgs e)
		{
			
				// Kiểm tra nếu các trường nhập liệu không rỗng
				if (string.IsNullOrWhiteSpace(txtMaTB.Text) ||
					string.IsNullOrWhiteSpace(txtTenTB.Text) ||
					string.IsNullOrWhiteSpace(txtDVT.Text) ||
					string.IsNullOrWhiteSpace(txtGia.Text))
				{
					MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				try
				{
					// Mở kết nối
					con.Open();

					// Tạo câu lệnh SQL để thêm thiết bị
					string sql = "INSERT INTO THIETBI_DICHVU (MATHIETBI, TENTHIETBI, DONVITINH, GIATIEN) VALUES (@MaThietBi, @TenThietBi, @DonViTinh, @Gia)";
					cmd = new SqlCommand(sql, con);

					// Thêm tham số vào câu lệnh
					cmd.Parameters.AddWithValue("@MaThietBi", txtMaTB.Text);
					cmd.Parameters.AddWithValue("@TenThietBi", txtTenTB.Text);
					cmd.Parameters.AddWithValue("@DonViTinh", txtDVT.Text);
					cmd.Parameters.AddWithValue("@Gia", txtGia.Text); // Chuyển đổi kiểu nếu cần

					// Thực thi câu lệnh
					int rowsAffected = cmd.ExecuteNonQuery();

					// Kiểm tra số hàng bị ảnh hưởng
					if (rowsAffected > 0)
					{
						MessageBox.Show("Thêm thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						dt.Clear(); // Xóa dữ liệu cũ trong DataTable
						adt.Fill(dt); // Tải lại dữ liệu từ cơ sở dữ liệu
					}
					else
					{
						MessageBox.Show("Không thể thêm thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					// Đóng kết nối
					if (con.State == ConnectionState.Open)
					{
						con.Close();
					}
				}
			

		}

		private void cmdDelete_Click(object sender, EventArgs e)
		{
		
				// Kiểm tra xem có dòng nào được chọn không
				if (dataGridView1.SelectedRows.Count > 0)
				{
					// Lấy dòng đầu tiên được chọn
					DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

					// Lấy mã thiết bị từ dòng đã chọn
					string maThietBi = selectedRow.Cells["MATHIETBI"].Value.ToString(); // Sử dụng tên cột "MATHIETBI"

					// Xác nhận xóa
					var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ thông tin về thiết bị này không?",
														 "Xác nhận xóa",
														 MessageBoxButtons.YesNo);
					if (confirmResult == DialogResult.Yes)
					{
						// Kết nối tới cơ sở dữ liệu
						using (con = new SqlConnection(connectionstring))
						{
							// Mở kết nối
							con.Open();

							// Tạo câu lệnh xóa
							cmd = new SqlCommand("DELETE FROM THIETBI_DICHVU WHERE MATHIETBI = @MaThietBi", con);
							cmd.Parameters.AddWithValue("@MaThietBi", maThietBi);

							// Thực thi câu lệnh
							int rowsAffected = cmd.ExecuteNonQuery();

							// Kiểm tra kết quả
							if (rowsAffected > 0)
							{
								MessageBox.Show("Xóa thành công thông tin.");
								// Cập nhật lại DataGridView
								LoadData(); // Gọi phương thức để tải lại dữ liệu
							}
							else
							{
								MessageBox.Show("Không tìm thấy mã thiết bị để xóa.");
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Vui lòng chọn một dòng để xóa.");
				}
		}

		private void cmdEdit_Click(object sender, EventArgs e)
		{
		
				// Kiểm tra xem có dòng nào được chọn không
				if (dataGridView1.SelectedRows.Count > 0)
				{
					// Lấy dòng đầu tiên được chọn
					DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

					// Lấy mã thiết bị từ dòng đã chọn
					string maThietBi = selectedRow.Cells["MATHIETBI"].Value.ToString(); // Sử dụng tên cột "MATHIETBI"

					// Kiểm tra dữ liệu trong các TextBox trước khi cập nhật
					if (string.IsNullOrWhiteSpace(txtTenTB.Text) ||
						string.IsNullOrWhiteSpace(txtDVT.Text) ||
						string.IsNullOrWhiteSpace(txtGia.Text))
					{
						MessageBox.Show("Vui lòng điền đầy đủ thông tin thiết bị, đơn vị tính và giá.");
						return;
					}

					// Kết nối tới cơ sở dữ liệu
					using (con = new SqlConnection(connectionstring))
					{
						// Mở kết nối
						con.Open();

						// Tạo câu lệnh cập nhật
						cmd = new SqlCommand("UPDATE THIETBI_DICHVU SET TENTHIETBI = @TenThietBi, DONVITINH = @DonViTinh, GIATIEN = @Gia WHERE MATHIETBI = @MaThietBi", con);
						cmd.Parameters.AddWithValue("@MaThietBi", maThietBi);
						cmd.Parameters.AddWithValue("@TenThietBi", txtTenTB.Text);
						cmd.Parameters.AddWithValue("@DonViTinh", txtDVT.Text);
						cmd.Parameters.AddWithValue("@Gia", decimal.Parse(txtGia.Text)); // Chuyển đổi kiểu nếu cần

						// Thực thi câu lệnh
						int rowsAffected = cmd.ExecuteNonQuery();

						// Kiểm tra kết quả
						if (rowsAffected > 0)
						{
							MessageBox.Show("Cập nhật thông tin thành công.");
							// Cập nhật lại DataGridView
							LoadData(); // Gọi phương thức để tải lại dữ liệu
						}
						else
						{
							MessageBox.Show("Không tìm thấy mã thiết bị để cập nhật.");
						}
					}
				}
				else
				{
					MessageBox.Show("Vui lòng chọn một dòng để cập nhật.");
				}
			

		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			txtDVT.Clear();
			txtTenTB.Clear();
			txtGia.Clear();
			txtMaTB.Clear();

			txtMaTB.Focus();
		}

		private void cmdExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
