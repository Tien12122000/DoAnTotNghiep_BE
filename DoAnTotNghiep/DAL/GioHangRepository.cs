using DoAnTotNghiep.DAL.DataHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public class GioHangRepository:IGioHangRepository
    {
        IDataHelper _dataHelper;
        public GioHangRepository(IDataHelper dataHelper)
        {
            this._dataHelper = dataHelper;
        }
        public void addGioHang(string makhachhang, string ngaymua, string Tongtien)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@makhachhang");
            listname.Add("@ngaymua");
            listname.Add("@Tongtien");
            listvalue.Add(makhachhang);
            listvalue.Add(ngaymua);
            listvalue.Add(Tongtien);
            _dataHelper.ExecuteNonSProcedure("AddGioHang", listname, listvalue);
        }

        public DataTable getAllGioHang()
        {
            return _dataHelper.ExecuteQueryReturnTable("Get_all_GioHang");
        }
    }
}
