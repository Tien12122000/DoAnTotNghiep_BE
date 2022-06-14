using System;
using System.Collections.Generic;

#nullable disable

namespace DoAnTotNghiep.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        public int MaDonHang { get; set; }
        public int? MaKhachHang { get; set; }
        public int? MaNhaVien { get; set; }
        public string NgayDatHang { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public string SoDienThoai { get; set; }
        public string TrangThaiDonHang { get; set; }
        public double? TongTien { get; set; }
        public string GhiChu { get; set; }
        public string tenKhachHang { get; set; }

        public virtual KhachHang MaKhachHangNavigation { get; set; }
        public virtual NhanVien MaNhaVienNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
