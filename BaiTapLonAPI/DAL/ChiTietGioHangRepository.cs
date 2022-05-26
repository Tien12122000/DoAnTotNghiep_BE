using DoAnTotNghiep.DAL.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public class ChiTietGioHangRepository:IChiTietGioHangRepository
    {
        IDataHelper _dataHelper;
        public ChiTietGioHangRepository(IDataHelper dataHelper)
        {
            this._dataHelper = dataHelper;
        }
        public void addChiTietGioHang(string MaGioHang, string MaTuiXach, string DonGia, string soluong)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@MaGioHang");
            listname.Add("@MaTuiXach");
            listname.Add("@DonGia");
            listname.Add("@soluong");
            listvalue.Add(MaGioHang);
            listvalue.Add(MaTuiXach);
            listvalue.Add(DonGia);
            listvalue.Add(soluong);
            _dataHelper.ExecuteNonSProcedure("AddChiTietGioHang", listname, listvalue);
        }
    }
}
