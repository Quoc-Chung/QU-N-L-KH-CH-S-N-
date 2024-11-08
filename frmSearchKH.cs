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
    public partial class frmSearchKH : Form
    {
		SqlConnection connection;
		SqlCommand command;

		string str = ConnectString.ConecString;
		SqlDataAdapter adapter = new SqlDataAdapter();
		DataTable table = new DataTable();
		public frmSearchKH()
        {
            InitializeComponent();  
        }

		private void frmSearchKH_Load(object sender, EventArgs e)
		{

		}

		private void btnTim_Click(object sender, EventArgs e)
		{
			string tenKhachHang = txtTenKhachHang.Text.Trim();
			string diaChi = txtDiaChi.Text.Trim();
			string soCMND = txtCMND.Text.Trim();

			// Thiết lập kết nối và truy vấn
			using (SqlConnection connection = new SqlConnection(str))
			{
				try
				{
					connection.Open();
					string query = "SELECT * FROM KHACHHANG WHERE (HOTEN LIKE @TenKhachHang OR @TenKhachHang = '') " +
								   "AND (DIACHI LIKE @DiaChi OR @DiaChi = '') " +
								   "AND (CMND LIKE @CMND OR @CMND = '')";

					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@TenKhachHang", "%" + tenKhachHang + "%");
					command.Parameters.AddWithValue("@DiaChi", "%" + diaChi + "%");
					command.Parameters.AddWithValue("@CMND", "%" + soCMND + "%");

					// Đổ dữ liệu vào DataTable và hiển thị trong DataGridView
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					DataTable table = new DataTable();
					adapter.Fill(table);
					dtGrid.DataSource = table;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message);
				}
			}
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			// Hiển thị hộp thoại xác nhận
			DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			// Kiểm tra nếu người dùng chọn "Yes" thì đóng form
			if (result == DialogResult.Yes)
			{
				this.Close();
			}
		}

	
	}
}
