using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTotNghiep.Models
{
    public partial class User
    {
        public int Ma { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string role { get; set; }
        public string token { get; set; }
    }
}
