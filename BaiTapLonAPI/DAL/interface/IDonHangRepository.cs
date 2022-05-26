using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public interface IDonHangRepository
    {
        DataTable getDonHangByUser_KhachHang_Paginate(string PageIndex, string email);
        DataTable getDonHangByUser_KhachHang(string email);
        DataTable countSearchDonHangin4(string key);
        public DataTable SearchDonHangPaginate(int pageIndex, string key);
        public void DelDonHang(string id);
        public void UpdateDonHang(string id, string trangthaidonhang);
        public DataTable DonHangPaginate(int pageIndex);
        public DataTable getAllDonHang();
        public void addDonHang(string MaKhachHang, string MaNhaVien, string NgayDatHang, string DiaChiGiaoHang, string SoDienThoai,
            string TrangThaiDonHang, string TongTien, string GhiChu, string tenkhachHang);
    }
}
