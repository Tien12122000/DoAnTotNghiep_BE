using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public interface IGioHangRepository
    {

        public DataTable getAllGioHang();
        void addGioHang(string makhachhang, string ngaymua, string Tongtien);
    }
}
