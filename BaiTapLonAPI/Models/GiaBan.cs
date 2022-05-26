using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTotNghiep.Models
{
    public partial class GiaBan
    {
        public int MaTuiXach { get; set; }
        public double? GiaBan1 { get; set; }
        public DateTime? NgayHieuLuc { get; set; }
        public DateTime? NgayHetHieuLuc { get; set; }

        public virtual TuiXach MaTuiXachNavigation { get; set; }
    }
}
