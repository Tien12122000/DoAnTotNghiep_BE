using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTotNghiep.Models
{
    public partial class ChiTietGioHang
    {
        public int MaCtgioHang { get; set; }
        public int? MaGioHang { get; set; }
        public int? MaTuiXach { get; set; }
        public double? DonGia { get; set; }
        public int soluong { get; set; }

        public virtual GioHang MaGioHangNavigation { get; set; }
        public virtual TuiXach MaTuiXachNavigation { get; set; }
    }
}
