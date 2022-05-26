using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public interface IChiTietDonHangRepository
    {
        DataTable GetAllChiTietDonByID(int id);
        DataTable sp_ChiTietDonHang_Paginate_By_ID(int page_index, int hoten);
        void addChiTietDonHang(string MaDonHang, string MaTuiXach, string SoLuong, string DonGia);
    }
}
