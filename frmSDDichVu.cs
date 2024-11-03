using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BAITAPLON
{
    public partial class frmSDDichVu : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        string str1 = @"Data Source=LAPTOP-LACSE5QS\SQLEXPRESS;Initial Catalog=QUANLI_KHACHSAN_BTL;Integrated Security=True;";

        public frmSDDichVu()
        {
            InitializeComponent();
            InitializeDataGridView();
            dataGridView1.CellClick += DataGridView1_CellClick; // Thêm sự kiện CellClick
        }

        private void InitializeDataGridView()
        {
            // Thiết lập cột cho DataGridView
            
        }

        private void LoadMaPhong()
        {
            SqlCommand command = new SqlCommand("SELECT SHDTHUEPHONG FROM THUEPHONG", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                cboMaP.Items.Add(reader["SHDTHUEPHONG"].ToString());
            }
            reader.Close();
        }

        void loaddata()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT MATHIETBI, TENTHIETBI FROM THIETBI_DICHVU";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);

                List<CheckBox> checkboxes = new List<CheckBox>
                {
                    cbThietBi1, cbThietBi2, cbThietBi3, cbThietBi4, cbThietBi5,
                    cbThietBi6, cbThietBi7, cbThietBi8, cbThietBi9, cbThietBi10,
                    cbThietBi11, cbThietBi12, cbThietBi13, cbThietBi14, cbThietBi15,
                    cbThietBi16, cbThietBi17, cbThietBi18
                };

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    checkboxes[i].Text = table.Rows[i]["TENTHIETBI"].ToString();
                    checkboxes[i].Tag = table.Rows[i]["MATHIETBI"].ToString(); // Lưu mã thiết bị vào Tag
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void frmSDDichVu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str1);
            connection.Open();
            loaddata();
            LoadMaPhong();
            LoadDataGridView(); // Gọi hàm để tải dữ liệu vào DataGridView
        }

        private void LoadDataGridView()
        {
            try
            {
                // Tạo câu lệnh truy vấn để lấy dữ liệu từ bảng SUDUNGDICHVU kết hợp với THIETBI_DICHVU
                string query = @"
                    SELECT 
                        S.SHDTHUEPHONG, 
                        T.TENTHIETBI, 
                        S.NGAYSUDUNG, 
                        S.SOLUONG 
                    FROM 
                        SUDUNGDICHVU S
                    JOIN 
                        THIETBI_DICHVU T ON S.MATHIETBI = T.MATHIETBI";

                command = new SqlCommand(query, connection);
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Gán DataTable cho DataGridView
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu vào DataGridView: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                List<CheckBox> checkboxes = new List<CheckBox>
                {
                    cbThietBi1, cbThietBi2, cbThietBi3, cbThietBi4, cbThietBi5,
                    cbThietBi6, cbThietBi7, cbThietBi8, cbThietBi9, cbThietBi10,
                    cbThietBi11, cbThietBi12, cbThietBi13, cbThietBi14, cbThietBi15,
                    cbThietBi16, cbThietBi17, cbThietBi18
                };

                List<NumericUpDown> numerics = new List<NumericUpDown>
                {
                    numThietBi1, numThietBi2, numThietBi3, numThietBi4, numThietBi5,
                    numThietBi6, numThietBi7, numThietBi8, numThietBi9, numThietBi10,
                    numThietBi11, numThietBi12, numThietBi13, numThietBi14, numThietBi15,
                    numThietBi16, numThietBi17, numThietBi18
                };

                string maPhong = cboMaP.SelectedItem != null ? cboMaP.SelectedItem.ToString() : string.Empty;
                DateTime ngaySuDung = dTPicker_NgaySD.Value;

                bool hasCheckedCheckbox = false;
                bool hasNumericSelected = false;

                for (int i = 0; i < checkboxes.Count; i++)
                {
                    if (checkboxes[i].Checked)
                    {
                        hasCheckedCheckbox = true; // Đã chọn ít nhất 1 checkbox
                    }

                    if (numerics[i].Value > 0)
                    {
                        hasNumericSelected = true; // Đã chọn ít nhất 1 numeric
                    }

                    if (checkboxes[i].Checked && numerics[i].Value > 0)
                    {
                        string maThietBi = checkboxes[i].Tag.ToString();
                        int soLuong = (int)numerics[i].Value;

                        command = connection.CreateCommand();
                        command.CommandText = "INSERT INTO SUDUNGDICHVU (SHDTHUEPHONG, MATHIETBI, NGAYSUDUNG, SOLUONG) " +
                                              "VALUES (@SHDTHUEPHONG, @MATHIETBI, @NGAYSUDUNG, @SOLUONG)";
                        command.Parameters.AddWithValue("@SHDTHUEPHONG", maPhong);
                        command.Parameters.AddWithValue("@MATHIETBI", maThietBi);
                        command.Parameters.AddWithValue("@NGAYSUDUNG", ngaySuDung);
                        command.Parameters.AddWithValue("@SOLUONG", soLuong);
                        command.ExecuteNonQuery();
                    }
                }

                if (hasNumericSelected && !hasCheckedCheckbox)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một thiết bị để lưu dữ liệu.");
                    return; // Ngừng thực hiện nếu không có checkbox nào được chọn
                }

                if (!hasCheckedCheckbox)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một thiết bị để lưu dữ liệu.");
                    return;
                }

                MessageBox.Show("Lưu dữ liệu thành công!");

                LoadDataGridView(); // Tải lại dữ liệu vào DataGridView sau khi lưu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu click vào một dòng hợp lệ
            {
                // Lấy dữ liệu từ dòng được chọn
                string shdThuePhong = dataGridView1.Rows[e.RowIndex].Cells["SHDTHUEPHONG"].Value.ToString();
                string tenThietBi = dataGridView1.Rows[e.RowIndex].Cells["TENTHIETBI"].Value.ToString();
                DateTime ngaySuDung = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["NGAYSUDUNG"].Value);
                int soLuong = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SOLUONG"].Value);

                // Cập nhật vào ComboBox
                cboMaP.SelectedItem = shdThuePhong;

                // Cập nhật các CheckBox và NumericUpDown
                List<CheckBox> checkboxes = new List<CheckBox>
        {
            cbThietBi1, cbThietBi2, cbThietBi3, cbThietBi4, cbThietBi5,
            cbThietBi6, cbThietBi7, cbThietBi8, cbThietBi9, cbThietBi10,
            cbThietBi11, cbThietBi12, cbThietBi13, cbThietBi14, cbThietBi15,
            cbThietBi16, cbThietBi17, cbThietBi18
        };

                List<NumericUpDown> numerics = new List<NumericUpDown>
        {
            numThietBi1, numThietBi2, numThietBi3, numThietBi4, numThietBi5,
            numThietBi6, numThietBi7, numThietBi8, numThietBi9, numThietBi10,
            numThietBi11, numThietBi12, numThietBi13, numThietBi14, numThietBi15,
            numThietBi16, numThietBi17, numThietBi18
        };

                // Xóa hết chọn trước đó
                foreach (var cb in checkboxes)
                {
                    cb.Checked = false;
                }

                // Đặt giá trị cho các NumericUpDown và CheckBox
                for (int i = 0; i < checkboxes.Count; i++)
                {
                    if (checkboxes[i].Text == tenThietBi)
                    {
                        checkboxes[i].Checked = true;
                        numerics[i].Value = soLuong; // Cập nhật số lượng
                    }
                }

                // Cập nhật ngày sử dụng
                dTPicker_NgaySD.Value = ngaySuDung;
            }
        }
        


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Kiểm tra xem có dòng nào được chọn không
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                string shdThuePhong = selectedRow.Cells["SHDTHUEPHONG"].Value.ToString();

                // Xác nhận trước khi xóa
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Kết nối với cơ sở dữ liệu và xóa
                        using (SqlConnection connection = new SqlConnection(str1))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand("DELETE FROM SUDUNGDICHVU WHERE SHDTHUEPHONG = @SHDTHUEPHONG", connection))
                            {
                                command.Parameters.AddWithValue("@SHDTHUEPHONG", shdThuePhong);
                                command.ExecuteNonQuery(); // Thực hiện câu lệnh xóa
                            }
                        }

                        // Cập nhật lại DataGridView
                        LoadDataGridView();
                        MessageBox.Show("Xóa dữ liệu thành công.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }
    }
}
