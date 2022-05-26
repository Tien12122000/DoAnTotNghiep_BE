using DoAnTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.BLL
{
    public interface IDonHangBLL
    {

        public List<DonHang> getDonHangByUser_KhachHang_Paginate(string pageIndex, string email);
        public List<DonHang> getDonHangByUser_KhachHang(string email);
        public List<DonHang> countSearchDonHangin4(string key);
        public List<DonHang> SearchDonHangPaginate(int pageIndex, string key);
        public void DelDonHang(string id);
        public List<DonHang> DonHangPaginate(int pageIndex);
        List<DonHang> getAllDonHang();
        public void addDonHang(string MaKhachHang, string MaNhaVien, string NgayDatHang, string DiaChiGiaoHang, string SoDienThoai,
            string TrangThaiDonHang, string TongTien, string GhiChu, string tenkhachHang);
        void UpdateDonHang(string id, string trangthaidonhang);
    }
}
