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
    public partial class frmDoanhThu : Form
    {
        private SqlConnection connection;
        private string connectionString = ConnectString.ConecString;
        private SqlCommand command;

        private DataTable table = new DataTable();
        public frmDoanhThu()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString); // Khởi tạo kết nối
        }

        public void LoadData()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT * FROM LICHSUDATPHONG";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        table.Clear();
                        adapter.Fill(table);

                        // Gán dữ liệu vào DataGridView
                        dataGridView1.DataSource = table;

                        // Tính tổng doanh thu
                        decimal totalRevenue = 0;

                        foreach (DataRow row in table.Rows)
                        {
                            if (decimal.TryParse(row["TongTien"].ToString(), out decimal revenue))
                            {
                                totalRevenue += revenue;
                            }
                        }
                        TongDoanhThu.Text = $"Tổng doanh thu: {totalRevenue:C}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }



        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn cả tháng và năm để lọc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int month = int.Parse(comboBox1.SelectedItem.ToString());
            int year = int.Parse(comboBox2.SelectedItem.ToString());

            string query = "SELECT * FROM LICHSUDATPHONG WHERE MONTH(NgayThue) = @Month AND YEAR(NgayThue) = @Year";

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable filteredTable = new DataTable();
                        adapter.Fill(filteredTable);

                        // Gán dữ liệu vào DataGridView
                        dataGridView1.DataSource = filteredTable;

                        // Tính tổng doanh thu
                        decimal totalRevenue = 0;

                        foreach (DataRow row in filteredTable.Rows)
                        {
                            if (decimal.TryParse(row["TongTien"].ToString(), out decimal revenue))
                            {
                                totalRevenue += revenue;
                            }
                        }
                        TongDoanhThu.Text =totalRevenue.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
