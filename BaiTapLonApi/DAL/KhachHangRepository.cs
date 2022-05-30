using DoAnTotNghiep.DAL.DataHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public class KhachHangRepository:IKhachHangRepository
    {
        IDataHelper _dataHelper;
        public KhachHangRepository(IDataHelper dataHelper)
        {
            this._dataHelper = dataHelper;
        }
        public void addkhachhang(string TenKhachHang, string SoDienThoai, string Email, string DiaChi)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@TenKhachHang");
            listname.Add("@SoDienThoai");
            listname.Add("@Email");
            listname.Add("@DiaChi");
            listvalue.Add(TenKhachHang);
            listvalue.Add(SoDienThoai);
            listvalue.Add(Email);
            listvalue.Add(DiaChi);
            _dataHelper.ExecuteNonSProcedure("addKhachHang", listname, listvalue);
        }

        public DataTable getAllKhachHang()
        {
            return _dataHelper.ExecuteQueryReturnTable("Get_all_KhachHang");
        }
    }
}
