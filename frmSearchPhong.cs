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
			LOAD_DU_LIEU();
		}

        public void LOAD_DU_LIEU()
        {
            
            string DanhSachPhong = "SELECT DISTINCT MAPHONG FROM DANHMUCPHONG";
            string LoaiPhong = "SELECT DISTINCT LOAIPHONG FROM LOAIPHONG";
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (command = new SqlCommand(DanhSachPhong, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cboMaPhong.Items.Add(reader["MAPHONG"].ToString());
                            }
                        }
                    }
                    using (command = new SqlCommand(LoaiPhong, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cboLoaiPhong.Items.Add(reader["LOAIPHONG"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            using (connection = new SqlConnection(str))
            {
                connection.Open();
                string query = @"
            SELECT DMP.MAPHONG, DMP.MALOAIPHONG, LP.LOAIPHONG, DMP.TANG, DMP.TINHTRANG 
            FROM LoaiPhong LP 
            JOIN DANHMUCPHONG DMP ON LP.MALOAIPHONG = DMP.MALOAIPHONG 
            WHERE 1=1"; 
                if (cboMaPhong.SelectedIndex != -1 && cboMaPhong.SelectedItem != null)
                {
                    query += " AND DMP.MAPHONG = @MaPhong";
                }
                if (cboLoaiPhong.SelectedIndex != -1 && cboLoaiPhong.SelectedItem != null)
                {
                    query += " AND LP.LOAIPHONG = @LoaiPhong";
                }
                if (chkTrong.Checked)
                {
                    query += " AND DMP.TINHTRANG = 0"; 
                }
                command = new SqlCommand(query, connection);

                if (cboMaPhong.SelectedIndex != -1 && cboMaPhong.SelectedItem != null)
                {
                    command.Parameters.AddWithValue("@MaPhong", cboMaPhong.SelectedItem.ToString());
                }

                if (cboLoaiPhong.SelectedIndex != -1 && cboLoaiPhong.SelectedItem != null)
                {
                    command.Parameters.AddWithValue("@LoaiPhong", cboLoaiPhong.SelectedItem.ToString());
                }
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dtGrid.DataSource = table;

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp với điều kiện tìm kiếm!", "Thông báo");
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
