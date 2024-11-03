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
    public partial class frmLoaiPhong : Form
    {
		string connectionstring = @"Data Source=LAPTOP-LACSE5QS\SQLEXPRESS;Initial Catalog=QUANLI_KHACHSAN_BTL;Integrated Security=True;";
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adt = new SqlDataAdapter();
		DataTable dt= new DataTable();
		DataView dv;
		public frmLoaiPhong()
        {
            InitializeComponent();
			dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
		}

		private void frmLoaiPhong_Load(object sender, EventArgs e)
		{
			con = new SqlConnection(connectionstring);
			cmd= con.CreateCommand();
			cmd.CommandText = "select * from LOAIPHONG";
			adt.SelectCommand = cmd;
			dt.Clear();
			adt.Fill(dt);
			dv = new DataView(dt);
			dataGridView1.DataSource = dt;


		}
		private void LoadData()
		{
			cmd = con.CreateCommand();
			cmd.CommandText = "SELECT * FROM LOAIPHONG";
			adt.SelectCommand = cmd;
			dt.Clear();
			adt.Fill(dt);
			dv = new DataView(dt);
			dataGridView1.DataSource = dt;
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			// Kiểm tra nếu các trường nhập liệu không rỗng
			if (string.IsNullOrWhiteSpace(txtMaLoaiP.Text) ||
				string.IsNullOrWhiteSpace(txtLoaiP.Text) ||
				string.IsNullOrWhiteSpace(txtGia.Text))
			{
				MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try
			{
				// Mở kết nối
				con.Open();

				// Tạo câu lệnh SQL để thêm loại phòng
				string sql = "INSERT INTO LOAIPHONG (MALOAIPHONG, LOAIPHONG, GIATIEN) VALUES (@MaLoaiP, @TenLoaiP, @Gia)";
				cmd = new SqlCommand(sql, con);

				// Thêm tham số vào câu lệnh
				cmd.Parameters.AddWithValue("@MaLoaiP", txtMaLoaiP.Text);
				cmd.Parameters.AddWithValue("@TenLoaiP", txtLoaiP.Text);
				cmd.Parameters.AddWithValue("@Gia", txtGia.Text); // Chuyển đổi kiểu nếu cần

				// Thực thi câu lệnh
				int rowsAffected = cmd.ExecuteNonQuery();

				// Kiểm tra số hàng bị ảnh hưởng
				if (rowsAffected > 0)
				{
					MessageBox.Show("Thêm loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					dt.Clear(); // Xóa dữ liệu cũ trong DataTable
					adt.Fill(dt); // Tải lại dữ liệu từ cơ sở dữ liệu
				}
				else
				{
					MessageBox.Show("Không thể thêm loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
		private void dataGridView1_SelectionChanged(object sender, EventArgs e)
		{
			// Kiểm tra xem có dòng nào được chọn không
			if (dataGridView1.SelectedRows.Count > 0)
			{
				// Lấy dòng đầu tiên được chọn
				DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

				// Gán giá trị vào các TextBox tương ứng
				txtMaLoaiP.Text = selectedRow.Cells["MALOAIPHONG"].Value.ToString(); // Giả sử cột mã loại phòng có tên là "MaLoaiP"
				txtLoaiP.Text = selectedRow.Cells["LOAIPHONG"].Value.ToString();  // Giả sử cột tên loại phòng có tên là "TenLoaiP"
				txtGia.Text = selectedRow.Cells["GIATIEN"].Value.ToString();          // Giả sử cột giá có tên là "Gia"
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			// Kiểm tra xem có dòng nào được chọn không
			if (dataGridView1.SelectedRows.Count > 0)
			{
				// Lấy dòng đầu tiên được chọn
				DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

				// Lấy mã loại phòng từ dòng đã chọn
				string maLoaiP = selectedRow.Cells["MALOAIPHONG"].Value.ToString(); // Sử dụng tên cột "MALOAIPHONG"

				// Xác nhận xóa
				var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ thông tin về mã loại phòng này không?",
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
						cmd = new SqlCommand("DELETE FROM LOAIPHONG WHERE MALOAIPHONG = @MaLoaiP", con);
						cmd.Parameters.AddWithValue("@MaLoaiP", maLoaiP);

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
							MessageBox.Show("Không tìm thấy mã loại phòng để xóa.");
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn một dòng để xóa.");
			}
		}
		private void btnSua_Click(object sender, EventArgs e)
		{
			// Kiểm tra xem có dòng nào được chọn không
			if (dataGridView1.SelectedRows.Count > 0)
			{
				// Lấy dòng đầu tiên được chọn
				DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

				// Lấy mã loại phòng từ dòng đã chọn
				string maLoaiP = selectedRow.Cells["MALOAIPHONG"].Value.ToString(); // Sử dụng tên cột "MALOAIPHONG"

				// Kiểm tra dữ liệu trong các TextBox trước khi cập nhật
				if (string.IsNullOrWhiteSpace(txtLoaiP.Text) || string.IsNullOrWhiteSpace(txtGia.Text))
				{
					MessageBox.Show("Vui lòng điền đầy đủ thông tin loại phòng và giá.");
					return;
				}

				// Kết nối tới cơ sở dữ liệu
				using (con = new SqlConnection(connectionstring))
				{
					// Mở kết nối
					con.Open();

					// Tạo câu lệnh cập nhật
					cmd = new SqlCommand("UPDATE LOAIPHONG SET LOAIPHONG = @TenLoaiP, GIATIEN = @Gia WHERE MALOAIPHONG = @MaLoaiP", con);
					cmd.Parameters.AddWithValue("@MaLoaiP", maLoaiP);
					cmd.Parameters.AddWithValue("@TenLoaiP", txtLoaiP.Text);
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
						MessageBox.Show("Không tìm thấy mã loại phòng để cập nhật.");
					}
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn một dòng để cập nhật.");
			}
		}
		

		private void btnThoat_Click(object sender, EventArgs e)
		{
			// Đóng form hiện tại
			this.Close();
		}

		private void btnHuyBo_Click(object sender, EventArgs e)
		{
			// Xóa nội dung trong các TextBox
			txtMaLoaiP.Clear();
			txtLoaiP.Clear();
			txtGia.Clear();

			// (Tùy chọn) Đặt lại focus về TextBox đầu tiên
			txtMaLoaiP.Focus();
		}

		
	}
}
