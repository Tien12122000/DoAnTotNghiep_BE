using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTotNghiep.Models
{
    public partial class TuiXach
    {
        public TuiXach()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            ChiTietGioHangs = new HashSet<ChiTietGioHang>();
        }

        public int MaTuiXach { get; set; }
        public int? MaLoaiTuiXach { get; set; }
        public string TenTuiXach { get; set; }
        public double? Gia { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public int soluong { get; set; }
        public int luotmua { get; set; }

        public virtual LoaiTuiXach MaLoaiTuiXachNavigation { get; set; }
        public virtual GiaBan GiaBan { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; }
    }
}
