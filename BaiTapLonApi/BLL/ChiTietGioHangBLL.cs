using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnTotNghiep.DAL;

namespace DoAnTotNghiep.BLL
{
    public class ChiTietGioHangBLL : IChiTietGioHangBLL
    {
        IChiTietGioHangRepository _ChiTietGioHangRepository;
        public ChiTietGioHangBLL(IChiTietGioHangRepository chiTietGioHangRepository)
        {
            this._ChiTietGioHangRepository = chiTietGioHangRepository;
        }
        public void addChiTietGioHang(string MaGioHang, string MaTuiXach, string DonGia, string soluong)
        {
            _ChiTietGioHangRepository.addChiTietGioHang(MaGioHang, MaTuiXach, DonGia, soluong);
        }
    }
}
