using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using BAITAPLON.Model;

namespace BAITAPLON
{
    public partial class frmPhong : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        string strConnection =ConnectString.ConecString;

        public frmPhong()
        {
            InitializeComponent();
        }

        private void frmPhong_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(strConnection);
            connection.Open();
            LoadLoaiPhong();
            LoadDataGridView();
        }
        private void LoadLoaiPhong()
        {
            command = new SqlCommand("SELECT * FROM LOAIPHONG", connection);
            SqlDataReader reader = command.ExecuteReader();

            cboLoaiPhong.DisplayMember = "Text";
            cboLoaiPhong.ValueMember = "Value";

            var roomTypes = new List<object>();
            while (reader.Read())
            {
                roomTypes.Add(new { Text = reader["LOAIPHONG"].ToString(), Value = reader["MALOAIPHONG"].ToString() });
            }
            reader.Close();
            cboLoaiPhong.DataSource = roomTypes;
        }

        private void LoadDataGridView()
        {
            string query = "SELECT DP.MAPHONG, LP.LOAIPHONG, DP.TINHTRANG, DP.TANG FROM DANHMUCPHONG DP JOIN LOAIPHONG LP ON DP.MALOAIPHONG = LP.MALOAIPHONG";
            adapter.SelectCommand = new SqlCommand(query, connection);
            table.Clear();
            adapter.Fill(table);

            // Kiểm tra xem cột "TINHTRANG_STRING" đã tồn tại chưa
            if (!table.Columns.Contains("TINHTRANG_STRING"))
            {
                // Thêm cột mới để lưu trữ tình trạng phòng dưới dạng string
                table.Columns.Add("TINHTRANG_STRING", typeof(string));
            }

            foreach (DataRow row in table.Rows)
            {
                // Chuyển đổi giá trị TINHTRANG từ BIT sang string
                row["TINHTRANG_STRING"] = Convert.ToBoolean(row["TINHTRANG"]) ? "Không trống" : "Trống";
            }
            dataGridView.DataSource = table;
            dataGridView.Columns["MAPHONG"].HeaderText = "Mã số phòng";
            dataGridView.Columns["LOAIPHONG"].HeaderText = "Loại phòng";
            dataGridView.Columns["TINHTRANG_STRING"].HeaderText = "Tình trạng";
            dataGridView.Columns["TANG"].HeaderText = "Tầng";

            // Ẩn cột gốc TINHTRANG để không hiển thị trong DataGridView
            dataGridView.Columns["TINHTRANG"].Visible = false;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Mã phòng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

      
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                // Truy vấn để cập nhật thông tin phòng dựa trên MAPHONG
                string query = "UPDATE DANHMUCPHONG SET MALOAIPHONG = @MALOAIPHONG, TINHTRANG = @TINHTRANG, TANG = @TANG WHERE MAPHONG = @MAPHONG";
                command = new SqlCommand(query, connection);

                // Gán các giá trị từ giao diện vào các tham số truy vấn
                command.Parameters.AddWithValue("@MAPHONG", txtMaPhong.Text); // Mã phòng từ textbox (khóa chính, không thể thay đổi)
                command.Parameters.AddWithValue("@MALOAIPHONG", cboLoaiPhong.SelectedValue); // Loại phòng từ combobox
                command.Parameters.AddWithValue("@TINHTRANG", radKhongTrong.Checked); // Tình trạng từ radio button
                command.Parameters.AddWithValue("@TANG", numericUpDown1.Value); // Số tầng từ numericUpDown

                // Thực hiện truy vấn cập nhật dữ liệu
                command.ExecuteNonQuery();

                // Cập nhật lại DataGridView sau khi sửa thành công
                LoadDataGridView();

                // Thông báo sửa thành công
                MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string query = "DELETE FROM DANHMUCPHONG WHERE MAPHONG = @MAPHONG";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MAPHONG", txtMaPhong.Text);
                command.ExecuteNonQuery();
                LoadDataGridView(); // Cập nhật lại DataGridView
                MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng được chọn
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                // Kiểm tra null trước khi gán giá trị cho TextBox
                txtMaPhong.Text = row.Cells["MAPHONG"].Value?.ToString() ?? string.Empty;

                // Kiểm tra giá trị hợp lệ cho ComboBox
                if (row.Cells["LOAIPHONG"].Value != DBNull.Value)
                {
                    string loaiPhong = row.Cells["LOAIPHONG"].Value.ToString();
                    // Kiểm tra xem giá trị có tồn tại trong ComboBox không
                    if (cboLoaiPhong.Items.Contains(loaiPhong))
                    {
                        cboLoaiPhong.SelectedItem = loaiPhong;
                    }
                }

                // Kiểm tra tình trạng phòng
                if (row.Cells["TINHTRANG"].Value != DBNull.Value)
                {
                    bool tinhTrang = Convert.ToBoolean(row.Cells["TINHTRANG"].Value);
                    radKhongTrong.Checked = tinhTrang;
                    radTrong.Checked = !tinhTrang;
                }

                // Cập nhật giá trị tầng
                if (row.Cells["TANG"].Value != DBNull.Value)
                {
                    numericUpDown1.Value = Convert.ToDecimal(row.Cells["TANG"].Value);
                }
            }
        }
    }
}
