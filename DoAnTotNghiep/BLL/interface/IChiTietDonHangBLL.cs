using DoAnTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.BLL
{
    public interface IChiTietDonHangBLL
    {
        List<ChiTietDonHang> GetAllChiTietDonByID(int id);
        List<ChiTietDonHang> sp_ChiTietDonHang_Paginate_By_ID(int page_index, int hoten);
        public void addChiTietDonHang(string MaDonHang, string MaTuiXach, string SoLuong, string DonGia);
    }
}
