using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTotNghiep.Models
{
    public partial class ChiTietHoaDonNhap
    {
        public int MaCthoaDonNhap { get; set; }
        public int? MaHoaDonNhap { get; set; }
        public int? SoLuong { get; set; }
        public double? DonGia { get; set; }
        public string DonViTinh { get; set; }
        public string HanSuDung { get; set; }

        public virtual HoaDonNhap MaHoaDonNhapNavigation { get; set; }
    }
}
