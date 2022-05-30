using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DoAnTotNghiep.DAL.DataHelper;

namespace DoAnTotNghiep.DAL
{
    public class ChiTietDonHangRepository:IChiTietDonHangRepository
    {
        IDataHelper _dataHelper;
        public ChiTietDonHangRepository(IDataHelper dataHelper)
        {
            this._dataHelper = dataHelper;
        }
        public void addChiTietDonHang(string MaDonHang, string MaTuiXach, string SoLuong, string DonGia)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@MaDonHang");
            listname.Add("@MaTuiXach");
            listname.Add("@SoLuong");
            listname.Add("@DonGia");
            listvalue.Add(MaDonHang);
            listvalue.Add(MaTuiXach);
            listvalue.Add(SoLuong);
            listvalue.Add(DonGia);
            _dataHelper.ExecuteNonSProcedure("AddChiTietDonHang", listname, listvalue);
        }

        public DataTable GetAllChiTietDonByID(int id)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@id");
            listvalue.Add(id.ToString());
            return _dataHelper.ExecuteQueryReturnTable("GetAllChiTietDonByID", listname, listvalue);
        }

        public DataTable sp_ChiTietDonHang_Paginate_By_ID(int page_index, int hoten)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@page_index");
            listname.Add("@page_size");
            listname.Add("@hoten");
            listvalue.Add(page_index.ToString());
            listvalue.Add("4");
            listvalue.Add(hoten.ToString());
            return _dataHelper.ExecuteQueryReturnTable("sp_ChiTietDonHang_Paginate_By_ID", listname, listvalue);
        }
    }
}
