using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DoAnTotNghiep.DAL;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.BLL
{
    public class GioHangBLL : IGiohangBLL
    {
        IGioHangRepository _GioHangBLL;
        public GioHangBLL(IGioHangRepository giohangBLL)
        {
            _GioHangBLL = giohangBLL;
        }
        public void addGioHang(string makhachhang, string ngaymua, string Tongtien)
        {
            _GioHangBLL.addGioHang(makhachhang, ngaymua, Tongtien);
        }

        public List<GioHang> getAllGioHang()
        {
            List<GioHang> li = new List<GioHang>();
            DataTable dt = _GioHangBLL.getAllGioHang();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GioHang gio = new GioHang();
                gio.MaGioHang = int.Parse(dt.Rows[i][0].ToString());
                gio.NgayMua = dt.Rows[i][1].ToString();
                gio.TongTien = float.Parse(dt.Rows[i][2].ToString());
                gio.MaKhachHang = int.Parse(dt.Rows[i][3].ToString());
                li.Add(gio);
            }
            return li;
        }
    }
}
