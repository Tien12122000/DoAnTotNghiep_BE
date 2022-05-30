using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTotNghiep.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            DonHangs = new HashSet<DonHang>();
            HoaDonNhaps = new HashSet<HoaDonNhap>();
        }

        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }
    }
}
