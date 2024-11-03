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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BAITAPLON
{
    public partial class frmTBTrangThietBi : Form
    {
        SqlConnection connection;
        SqlCommand command;

        string str = "Data Source=LAPTOP-LACSE5QS\\SQLEXPRESS;Initial Catalog=QUANLI_KHACHSAN_BTL;Integrated Security=True;";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public frmTBTrangThietBi()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT t.MALOAIPHONG,d.TENTHIETBI,t.SOLUONG FROM THIETBI_PHONG AS t"+
                " JOIN LOAIPHONG AS l ON l.MALOAIPHONG=t.MALOAIPHONG"+ " JOIN THIETBI_DICHVU AS d ON d.MATHIETBI=t.MATHIETBI";

            /* - CÂU LỆNH THỰC THI CÂU TRUY VẤN -*/
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;

            table.Clear();
            adapter.Fill(table);

            dataGridView.DataSource = table;
        }
        
        private void frmTBTrangThietBi_Load(object sender, EventArgs e)
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

        private void cmdSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn loại phòng hay chưa
            if (cboLoaiP.SelectedItem == null)
            {
                MessageBox.Show("Bạn vui lòng chọn loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy tên LOAIPHONG từ ComboBox
            string selectedLoaiPhongName = cboLoaiP.Text;

            // Truy vấn bảng LOAIPHONG để lấy MALOAIPHONG dựa trên tên LOAIPHONG
            string selectedLoaiPhong = null;
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT MALOAIPHONG FROM LOAIPHONG WHERE LOAIPHONG = @LoaiPhong";
                command.Parameters.AddWithValue("@LoaiPhong", selectedLoaiPhongName);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        selectedLoaiPhong = reader["MALOAIPHONG"].ToString();
                    }
                }

                if (string.IsNullOrEmpty(selectedLoaiPhong))
                {
                    MessageBox.Show("Không tìm thấy mã loại phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã loại phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            int dieuHoaValue = int.Parse(domainUpDownDieuhoa.Text);
            int tiviValue = int.Parse(domainUpDownTivi.Text);
            int giuongValue = int.Parse(domainUpDownGiuong.Text);
            int mayChoiGameValue = int.Parse(domainUpDownMaychoigame.Text);
            int binhNongLanhValue = int.Parse(domainUpDownBinhnonglanh.Text);
            int denDienValue = int.Parse(domainUpDownDendien.Text);
            int banValue = int.Parse(domainUpDownBan.Text);
            int gheValue = int.Parse(domainUpDownGhe.Text);

            // Tạo câu lệnh SQL INSERT
            command = connection.CreateCommand();
            command.CommandText = "UPDATE THIETBI_PHONG SET SOLUONG =(CASE  "+
                "WHEN THIETBI_PHONG.MATHIETBI='MTB01' THEN @Dieuhoa " +
                "WHEN THIETBI_PHONG.MATHIETBI='MTB02' THEN @Tivi " +
                "WHEN THIETBI_PHONG.MATHIETBI='MTB03' THEN @Giuong " +
                "WHEN THIETBI_PHONG.MATHIETBI='MTB04' THEN @Maychoigame " +
                "WHEN THIETBI_PHONG.MATHIETBI='MTB05' THEN @Binhnonglanh " +
                "WHEN THIETBI_PHONG.MATHIETBI='MTB06' THEN @Dendien " +
                "WHEN THIETBI_PHONG.MATHIETBI='MTB07' THEN @Ban " +
                "WHEN THIETBI_PHONG.MATHIETBI='MTB08' THEN @Ghe " +
                "ELSE  NULL END ) " +
                "From THIETBI_PHONG "+
                "JOIN LOAIPHONG ON LOAIPHONG.MALOAIPHONG=THIETBI_PHONG.MALOAIPHONG " +
                "WHERE LOAIPHONG.LOAIPHONG=@Maloaiphong";

            



            // Thêm các tham số vào câu lệnh SQL
            command.Parameters.AddWithValue("@Maloaiphong", cboLoaiP.Text);
            command.Parameters.AddWithValue("@Dieuhoa", dieuHoaValue);
            command.Parameters.AddWithValue("@Tivi", tiviValue);
            command.Parameters.AddWithValue("@Giuong", giuongValue);
            command.Parameters.AddWithValue("@Maychoigame", mayChoiGameValue);
            command.Parameters.AddWithValue("@Binhnonglanh", binhNongLanhValue);
            command.Parameters.AddWithValue("@Dendien", denDienValue);
            command.Parameters.AddWithValue("@Ban", banValue);
            command.Parameters.AddWithValue("@Ghe", gheValue);

            // Sử dụng biến selectedImagePath trong btnThem_Click
            

            // Thực thi câu lệnh SQL
            command.ExecuteNonQuery();

            MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Tải lại dữ liệu sau khi thêm mới
            LoadData();
            

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void checkBoxDieuHoa_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDownDieuhoa.Enabled = checkBoxDieuHoa.Checked;
        }

        private void checkBoxTivi_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDownTivi.Enabled = checkBoxTivi.Checked;
        }

        private void checkBoxGiuong_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDownGiuong.Enabled = checkBoxGiuong.Checked;

        }

        private void checkBoxMaychoigame_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDownMaychoigame.Enabled = checkBoxMaychoigame.Checked;

        }

        private void checkBoxBinhnonglanh_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDownBinhnonglanh.Enabled = checkBoxBinhnonglanh.Checked;

        }

        private void checkBoxDendien_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDownDendien.Enabled = checkBoxDendien.Checked;

        }

        private void checkBoxBan_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDownBan.Enabled = checkBoxBan.Checked;

        }

        private void checkBoxGhe_CheckedChanged(object sender, EventArgs e)
        {
            domainUpDownGhe.Enabled = checkBoxGhe.Checked;

        }

        private void domainUpDownDieuhoa_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
