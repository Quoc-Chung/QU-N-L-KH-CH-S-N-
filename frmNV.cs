using BAITAPLON.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
namespace BAITAPLON
{
    public partial class frmNV : Form
    {
        SqlConnection connection;
        SqlCommand command;

        string str = ConnectString.ConecString;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public frmNV()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            // Tạo command
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM TAI_KHOAN WHERE QUYEN != 'ADMIN'";

            // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
            adapter.SelectCommand = command;

            // Clear dữ liệu trong DataTable trước khi tải lại
            table.Clear();

            adapter.Fill(table);

            dataGridView.DataSource = table;
        }

        private void frmNV_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(str);
                connection.Open();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
        private string selectedImagePath = ""; // Biến lưu đường dẫn ảnh
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã nhân viên phải đủ 5 ký tự
            if (txtMaNV.Text.Length != 5)
            {
                MessageBox.Show("Mã nhân viên phải đủ 5 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenNV.Text) || string.IsNullOrWhiteSpace(txtDChi.Text))
            {
                MessageBox.Show("Họ tên và địa chỉ nhân viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtMKhau.Text) ||
                string.IsNullOrEmpty(txtDThoai.Text))
            {
                MessageBox.Show("Bạn vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDThoai.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đủ 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int sdt;
                if (!int.TryParse(txtDThoai.Text, out sdt))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem mã nhân viên đã tồn tại trong cơ sở dữ liệu chưa
                command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM TAI_KHOAN WHERE MATAIKHOAN = @MaTaiKhoan";
                command.Parameters.AddWithValue("@MaTaiKhoan", txtMaNV.Text);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tiến hành thêm dữ liệu nếu không trùng khóa chính
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO TAI_KHOAN (MATAIKHOAN, MATKHAU, HOTEN, NGAYSINH, GIOITINH, DIACHI, SODIENTHOAI, NGAYVAOLAM, ANH) " +
                                      "VALUES (@MaTaiKhoan, @MatKhau, @HoTen, @NgaySinh, @GioiTinh, @DiaCHi, @SoDienThoai, @NgayVaoLam, @Anh)";

                command.Parameters.AddWithValue("@MaTaiKhoan", txtMaNV.Text);
                command.Parameters.AddWithValue("@MatKhau", txtMKhau.Text);
                command.Parameters.AddWithValue("@HoTen", txtTenNV.Text);
                command.Parameters.AddWithValue("@NgaySinh", dTPicker_NSinh.Value);
                command.Parameters.AddWithValue("@DiaCHi", txtDChi.Text);
                command.Parameters.AddWithValue("@SoDienThoai", txtDThoai.Text);
                command.Parameters.AddWithValue("@NgayVaoLam", dTPicker_NVaoLam.Value);

                string gioiTinh = optNam.Checked ? "True" : (optNu.Checked ? "False" : null);

                if (gioiTinh != null)
                {
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn giới tính.");
                    return;
                }

                command.Parameters.AddWithValue("@Anh", string.IsNullOrEmpty(selectedImagePath) ? DBNull.Value : (object)selectedImagePath);

                command.ExecuteNonQuery();

                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại dữ liệu sau khi thêm mới
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã nhân viên phải đủ 5 ký tự
            if (txtMaNV.Text.Length != 5)
            {
                MessageBox.Show("Mã nhân viên phải đủ 5 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra Họ tên và Địa chỉ không được bỏ trống
            if (string.IsNullOrWhiteSpace(txtTenNV.Text) || string.IsNullOrWhiteSpace(txtDChi.Text))
            {
                MessageBox.Show("Họ tên và địa chỉ nhân viên không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra các trường nhập liệu khác
            if (string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtMKhau.Text) ||
                string.IsNullOrEmpty(txtDThoai.Text))
            {
                MessageBox.Show("Bạn vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtDThoai.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đủ 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Chuyển đổi các giá trị kiểu số từ TextBox
                int sdt;
                if (!int.TryParse(txtDThoai.Text, out sdt))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string oldMaNV = dataGridView.CurrentRow.Cells["MATAIKHOAN"].Value.ToString();
                // Tạo câu lệnh SQL INSERT
                command = connection.CreateCommand();
                command.CommandText = "UPDATE TAI_KHOAN SET MATAIKHOAN=@MATAIKHOAN, MATKHAU=@MatKhau, HOTEN=@HoTen, NGAYSINH=@NgaySinh, GIOITINH=@GioiTinh, DIACHI=@DiaCHi, SODIENTHOAI=@SoDienThoai,NGAYVAOLAM=@NgayVaoLam,ANH=@Anh " +
                                      " WHERE MATAIKHOAN = @OldMaNV";

                // Thêm các tham số vào câu lệnh SQL
                command.Parameters.AddWithValue("@MaTaiKhoan", txtMaNV.Text);
                command.Parameters.AddWithValue("@MatKhau", txtMKhau.Text);
                command.Parameters.AddWithValue("@HoTen", txtTenNV.Text);
                command.Parameters.AddWithValue("@NgaySinh", dTPicker_NSinh.Value);
                command.Parameters.AddWithValue("@DiaCHi", txtDChi.Text);
                command.Parameters.AddWithValue("@SoDienThoai", txtDThoai.Text);
                command.Parameters.AddWithValue("@NgayVaoLam", dTPicker_NVaoLam.Value);
                command.Parameters.AddWithValue("@OldMaNV", oldMaNV);

                string gioiTinh = optNam.Checked ? "True" : (optNu.Checked ? "False" : null);

                if (gioiTinh != null)
                {
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn giới tính.");
                }

                command.Parameters.AddWithValue("@Anh", string.IsNullOrEmpty(selectedImagePath) ? DBNull.Value : (object)selectedImagePath);

                command.ExecuteNonQuery();

                MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại dữ liệu sau khi thêm mới
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã nhập mã hàng chưa
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Bạn vui lòng nhập mã nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Hỏi người dùng xác nhận việc xóa
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    // Tạo câu lệnh SQL DELETE
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM TAI_KHOAN WHERE MATAIKHOAN = @MaNV";

                    // Thêm tham số vào câu lệnh SQL
                    command.Parameters.AddWithValue("@MaNV", txtMaNV.Text);

                    // Thực thi câu lệnh SQL
                    command.ExecuteNonQuery();

                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại dữ liệu sau khi xóa
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            // Khởi tạo OpenFileDialog để chọn ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            // Nếu người dùng chọn tệp thành công
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(selectedImagePath); // Hiển thị trong PictureBox nếu cần
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có click vào hàng hợp lệ hay không
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy hàng được click
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                // Kiểm tra và gán giá trị vào các TextBox
                txtMaNV.Text = row.Cells["MATAIKHOAN"].Value?.ToString() ?? string.Empty;
                txtMKhau.Text = row.Cells["MATKHAU"].Value?.ToString() ?? string.Empty;
                txtTenNV.Text = row.Cells["HOTEN"].Value?.ToString() ?? string.Empty;

                // Xử lý ngày sinh
                if (DateTime.TryParse(row.Cells["NGAYSINH"].Value?.ToString(), out DateTime ngaySinh))
                {
                    dTPicker_NSinh.Value = ngaySinh;
                }
                else
                {
                    dTPicker_NSinh.Value = DateTime.Now; // Giá trị mặc định
                }

                txtDChi.Text = row.Cells["DIACHI"].Value?.ToString() ?? string.Empty;
                txtDThoai.Text = row.Cells["SODIENTHOAI"].Value?.ToString() ?? string.Empty;

                // Xử lý ngày vào làm
                if (DateTime.TryParse(row.Cells["NGAYVAOLAM"].Value?.ToString(), out DateTime ngayVaoLam))
                {
                    dTPicker_NVaoLam.Value = ngayVaoLam;
                }
                else
                {
                    dTPicker_NVaoLam.Value = DateTime.Now; // Giá trị mặc định
                }

                // Xử lý giới tính
                string gioiTinh = row.Cells["GIOITINH"].Value?.ToString();
                if (gioiTinh == "True")
                {
                    optNam.Checked = true;
                    optNu.Checked = false;
                }
                else if (gioiTinh == "False")
                {
                    optNam.Checked = false;
                    optNu.Checked = true;
                }
                else
                {
                    optNam.Checked = false;
                    optNu.Checked = false; // Không xác định
                }

                // Xử lý ảnh
                string imageName = row.Cells["ANH"].Value?.ToString();
                if (!string.IsNullOrEmpty(imageName))
                {
                    string imagePath = Path.Combine(@"..\..\Resources\AnhThe", imageName);

                    try
                    {
                        pictureBox1.Image = Image.FromFile(imagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pictureBox1.Image = null;
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

    }
}
