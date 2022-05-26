using DoAnTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.BLL
{
    public interface IKhachHangBLL
    {

        List<KhachHang> getAllKhachHang();
        public void addKhachHang(string TenKhachHang, string SoDienThoai, string Email, string DiaChi);
    }
}
