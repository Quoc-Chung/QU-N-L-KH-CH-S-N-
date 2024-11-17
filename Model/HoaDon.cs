using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAITAPLON.Model
{
	internal class HoaDon
	{
		public string SoHoaDonThue {  get; set; }
		public string maKhachHang { get; set; }
		public string TenNhanVien { get; set; }
		public string MaPhong { get; set; }
		public string MaPhongThue { get; set; }
		public DateTime NgayThue { get; set; }
		public DateTime NgayTra { get; set; }
		public int SoNgayThue { get; set; }
		public decimal GiaPhong { get; set; }
		public decimal TongTienPhong { get; set; }
		public List<DichVu> DichVuList { get; set; }
		public decimal TongTienDichVu { get; set; }
		public decimal TongTien { get; set; }
	}
}
