using BAITAPLON.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            cmd.CommandText = "SELECT * FROM THIETBI_DICHVU";
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtMaTB.Text = selectedRow.Cells["MATHIETBI"].Value.ToString();
                txtTenTB.Text = selectedRow.Cells["TENTHIETBI"].Value.ToString();       
                txtGia.Text = selectedRow.Cells["GIATIEN"].Value.ToString();
            }
        }


        private void cmdAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra tên thiết bị (chỉ cho phép chữ cái và dấu cách, bao gồm chữ có dấu)
            foreach (char c in txtTenTB.Text)
            {
                // Kiểm tra xem có ký tự nào là số hoặc ký tự đặc biệt không
                if (char.IsDigit(c) || !char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    MessageBox.Show("Tên thiết bị chỉ được phép chứa chữ cái (có dấu) và dấu cách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Kiểm tra giá (chỉ cho phép nhập số)
            if (!decimal.TryParse(txtGia.Text, out decimal gia) || gia <= 0)
            {
                MessageBox.Show("Giá chỉ được phép nhập số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaTB.Text) ||
                string.IsNullOrWhiteSpace(txtTenTB.Text) ||
                string.IsNullOrWhiteSpace(txtGia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra xem Mã thiết bị đã tồn tại trong cơ sở dữ liệu hay chưa
                using (SqlConnection conCheck = new SqlConnection(connectionstring))
                {
                    conCheck.Open();
                    string checkSql = "SELECT COUNT(*) FROM THIETBI_DICHVU WHERE MATHIETBI = @MaThietBi";
                    SqlCommand cmdCheck = new SqlCommand(checkSql, conCheck);
                    cmdCheck.Parameters.AddWithValue("@MaThietBi", txtMaTB.Text);
                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Mã thiết bị đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Thực hiện thêm thiết bị vào cơ sở dữ liệu
                con.Open();
                string sql = "INSERT INTO THIETBI_DICHVU (MATHIETBI, TENTHIETBI, GIATIEN) VALUES (@MaThietBi, @TenThietBi, @Gia)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaThietBi", txtMaTB.Text);
                cmd.Parameters.AddWithValue("@TenThietBi", txtTenTB.Text);
                cmd.Parameters.AddWithValue("@Gia", gia);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
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
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {

            // Kiểm tra tên thiết bị (chỉ cho phép nhập chữ và dấu cách)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTenTB.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Tên thiết bị chỉ được phép chứa chữ cái và dấu cách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra giá (chỉ cho phép nhập số)
            if (!decimal.TryParse(txtGia.Text, out decimal gia) || gia <= 0)
            {
                MessageBox.Show("Giá chỉ được phép nhập số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maThietBi = selectedRow.Cells["MATHIETBI"].Value.ToString();
                using (con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE THIETBI_DICHVU SET TENTHIETBI = @TenThietBi, GIATIEN = @Gia WHERE MATHIETBI = @MaThietBi", con);
                    cmd.Parameters.AddWithValue("@MaThietBi", maThietBi);
                    cmd.Parameters.AddWithValue("@TenThietBi", txtTenTB.Text);
                    cmd.Parameters.AddWithValue("@Gia", gia);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công.");
                        LoadData();
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
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maThietBi = selectedRow.Cells["MATHIETBI"].Value.ToString();

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ thông tin về thiết bị này không?",
"Xác nhận xóa",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    using (con = new SqlConnection(connectionstring))
                    {
                        con.Open();
                        cmd = new SqlCommand("DELETE FROM THIETBI_DICHVU WHERE MATHIETBI = @MaThietBi", con);
                        cmd.Parameters.AddWithValue("@MaThietBi", maThietBi);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa thành công thông tin.");
                            LoadData();
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
       
        private void cmdCancel_Click(object sender, EventArgs e)
        {    
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