using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public interface IChiTietGioHangRepository
    {
        void addChiTietGioHang(string MaGioHang, string MaTuiXach, string DonGia, string soluong);
    }
}
