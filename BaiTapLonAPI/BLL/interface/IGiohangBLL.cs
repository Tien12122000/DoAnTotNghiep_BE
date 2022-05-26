using DoAnTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.BLL
{
    public interface IGiohangBLL
    {

        List<GioHang> getAllGioHang();
        public void addGioHang(string makhachhang, string ngaymua, string Tongtien);
    }
}
