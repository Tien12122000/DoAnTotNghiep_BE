using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public interface IKhachHangRepository
    {

        public DataTable getAllKhachHang();
        void addkhachhang(string TenKhachHang, string SoDienThoai, string Email, string DiaChi);
    }
}
