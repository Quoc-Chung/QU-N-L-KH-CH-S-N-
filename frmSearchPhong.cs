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
    public partial class frmSearchPhong : Form
    {
		SqlConnection connection;
		SqlCommand command;

		string str = ConnectString.ConecString;
		SqlDataAdapter adapter = new SqlDataAdapter();
		DataTable table = new DataTable();

		public frmSearchPhong()
        {
            InitializeComponent();
          
        }

		private void frmSearchPhong_Load(object sender, EventArgs e)
		{

		}

		private void btnTim_Click(object sender, EventArgs e)
		{
			using (connection = new SqlConnection(str))
			{
				connection.Open();
				string query = "SELECT DMP.MAPHONG,DMP.MALOAIPHONG,LP.LOAIPHONG,DMP.TANG,DMP.TINHTRANG FROM LoaiPhong LP JOIN DANHMUCPHONG DMP ON LP.MALOAIPHONG = DMP.MALOAIPHONG WHERE 1=1";

				// Điều kiện tìm theo mã số phòng
				if (!string.IsNullOrWhiteSpace(txtMaSo.Text))
				{
					query += " AND DMP.MAPHONG = @MaPhong";
				}

				// Điều kiện tìm theo loại phòng
				if (cboLoaiPhong.SelectedIndex != -1)
				{
					query += " AND LP.LOAIPHONG = @LoaiPhong";
				}

				// Điều kiện tìm phòng trống
				if (chkTrong.Checked)
				{
					query += " AND DMP.TinhTrang = 0";
				}

				command = new SqlCommand(query, connection);

				// Thêm các tham số cho truy vấn
				if (!string.IsNullOrWhiteSpace(txtMaSo.Text))
				{
					command.Parameters.AddWithValue("@MaPhong", txtMaSo.Text);
				}

				if (cboLoaiPhong.SelectedIndex != -1)
				{
					command.Parameters.AddWithValue("@LoaiPhong", cboLoaiPhong.SelectedItem.ToString());
				}

				adapter.SelectCommand = command;
				table.Clear();
				adapter.Fill(table);

				dtGrid.DataSource = table;
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
