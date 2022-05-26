using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DoAnTotNghiep.DAL;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.BLL
{
    public class KhachHangBLL : IKhachHangBLL
    {
        IKhachHangRepository _KhachHangBLL;
        public KhachHangBLL(IKhachHangRepository khachHangBLL)
        {
            _KhachHangBLL = khachHangBLL;
        }
        public void addKhachHang(string TenKhachHang, string SoDienThoai, string Email, string DiaChi)
        {
            _KhachHangBLL.addkhachhang(TenKhachHang, SoDienThoai, Email, DiaChi);
        }

        public List<KhachHang> getAllKhachHang()
        {
            DataTable dt = new DataTable();
            dt = _KhachHangBLL.getAllKhachHang();
            List<KhachHang> li = new List<KhachHang>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                KhachHang khachHang = new KhachHang();
                khachHang.MaKhachHang = int.Parse(dt.Rows[i][0].ToString());
                khachHang.TenKhachHang = dt.Rows[i][1].ToString();
                khachHang.SoDienThoai = dt.Rows[i][2].ToString();
                khachHang.Email = dt.Rows[i][3].ToString();
                khachHang.DiaChi = dt.Rows[i][4].ToString();
                li.Add(khachHang);
            }
            return li;
        }
    }
}
