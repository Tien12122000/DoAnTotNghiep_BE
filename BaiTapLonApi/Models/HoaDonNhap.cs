using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTotNghiep.Models
{
    public partial class HoaDonNhap
    {
        public HoaDonNhap()
        {
            ChiTietHoaDonNhaps = new HashSet<ChiTietHoaDonNhap>();
        }

        public int MaHoaDonNhap { get; set; }
        public int? MaNhaCungCap { get; set; }
        public DateTime? NgayNhap { get; set; }
        public double? TongTien { get; set; }
        public int? MaNhaVien { get; set; }

        public virtual NhaCungCap MaNhaCungCapNavigation { get; set; }
        public virtual NhanVien MaNhaVienNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }
    }
}
