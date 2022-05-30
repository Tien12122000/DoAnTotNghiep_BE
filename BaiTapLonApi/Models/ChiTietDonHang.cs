using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTotNghiep.Models
{
    public partial class ChiTietDonHang
    {
        public int MaCtdonHang { get; set; }
        public int? MaDonHang { get; set; }
        public int? MaTuiXach { get; set; }
        public int? SoLuong { get; set; }
        public double? DonGia { get; set; }

        public virtual DonHang MaDonHangNavigation { get; set; }
        public virtual TuiXach MaTuiXachNavigation { get; set; }
    }
}
