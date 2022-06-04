using DoAnTotNghiep.DAL.DataHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public class DonHangRepository:IDonHangRepository
    {
        IDataHelper _dataHelper;
        public DonHangRepository(IDataHelper dataHelper)
        {
            this._dataHelper = dataHelper;
        }
        public void addDonHang(string MaKhachHang, string MaNhaVien, string NgayDatHang, string DiaChiGiaoHang, string SoDienThoai,
           string TrangThaiDonHang, string TongTien, string GhiChu, string tenkhachHang)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@MaKhachHang");
            listname.Add("@MaNhaVien");
            listname.Add("@NgayDatHang");
            listname.Add("@DiaChiGiaoHang");
            listname.Add("@SoDienThoai");
            listname.Add("@TrangThaiDonHang");
            listname.Add("@TongTien");
            listname.Add("@GhiChu");
            listname.Add("@tenkhachHang");
            listvalue.Add(MaKhachHang);
            listvalue.Add(MaNhaVien);
            listvalue.Add(NgayDatHang);
            listvalue.Add(DiaChiGiaoHang);
            listvalue.Add(SoDienThoai);
            listvalue.Add(TrangThaiDonHang);
            listvalue.Add(TongTien);
            listvalue.Add(GhiChu);
            listvalue.Add(tenkhachHang);
            _dataHelper.ExecuteNonSProcedure("AddDonHang", listname, listvalue);
        }

        public DataTable countSearchDonHangin4(string key)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@hoten");
            listvalue.Add(key);
            return _dataHelper.ExecuteQueryReturnTable("countSearchDonHangin4", listname, listvalue);
        }

        public void DelDonHang(string id)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@id");
            listvalue.Add(id);
            _dataHelper.ExecuteNonSProcedure("DelDonHang", listname, listvalue);
        }

        public DataTable DonHangPaginate(int pageIndex)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@page_index");
            listname.Add("@page_size");
            listvalue.Add(pageIndex.ToString());
            listvalue.Add("4");
            return _dataHelper.ExecuteQueryReturnTable("DonHangPaginate", listname, listvalue);
        }

        public DataTable getAllDonHang()
        {
            return _dataHelper.ExecuteQueryReturnTable("Get_all_DonHang");
        }

        public DataTable getDonHangByUser_KhachHang(string email)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@email");
            listvalue.Add(email);
            return _dataHelper.ExecuteQueryReturnTable("getDonHangByUser_KhachHang", listname, listvalue);
        }

        public DataTable getDonHangByUser_KhachHang_Paginate(string PageIndex, string email)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@page_index");
            listname.Add("@page_size");
            listname.Add("@email");
            listvalue.Add(PageIndex);
            listvalue.Add("4");
            listvalue.Add(email);
            return _dataHelper.ExecuteQueryReturnTable("getDonHangByUser_KhachHang_Paginate", listname, listvalue);
        }

        public DataTable SearchDonHangPaginate(int pageIndex, string key)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@page_index");
            listname.Add("@page_size");
            listname.Add("@hoten");
            listvalue.Add(pageIndex.ToString());
            listvalue.Add("4");
            listvalue.Add(key);
            return _dataHelper.ExecuteQueryReturnTable("sp_DonHang_search", listname, listvalue);
        }

        public void UpdateDonHang(string id, string trangthaidonhang)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@id");
            listname.Add("@TrangThaiDonHang");
            listvalue.Add(id);
            listvalue.Add(trangthaidonhang);
            _dataHelper.ExecuteNonSProcedure("updateDonHang", listname, listvalue);
        }
    }
}
