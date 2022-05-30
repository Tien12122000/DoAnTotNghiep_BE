using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTotNghiep.Models
{
    public partial class BaiViet
    {
        public int MaBaiViet { get; set; }
        public string TieuDe { get; set; }
        public string NguoiDang { get; set; }
        public DateTime? ThoiGianDang { get; set; }
        public string NoiDung { get; set; }
    }
}
