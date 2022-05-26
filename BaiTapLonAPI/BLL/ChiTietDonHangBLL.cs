using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DoAnTotNghiep.DAL;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.BLL
{
    public class ChiTietDonHangBLL : IChiTietDonHangBLL
    {
        IChiTietDonHangRepository _ChiTietDonHangBll;
        public ChiTietDonHangBLL (IChiTietDonHangRepository chiTietDonHangBLL)
        {
            _ChiTietDonHangBll = chiTietDonHangBLL;
        }
        public void addChiTietDonHang(string MaDonHang, string MaTuiXach, string SoLuong, string DonGia)
        {
            _ChiTietDonHangBll.addChiTietDonHang(MaDonHang, MaTuiXach, SoLuong, DonGia);
        }

        public List<ChiTietDonHang> GetAllChiTietDonByID(int id)
        {
            List<ChiTietDonHang> li = new List<ChiTietDonHang>();
            DataTable dt = _ChiTietDonHangBll.GetAllChiTietDonByID(id);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChiTietDonHang ChitietdonHang = new ChiTietDonHang();
                ChitietdonHang.MaCtdonHang = int.Parse(dt.Rows[i][0].ToString());
                ChitietdonHang.MaDonHang = int.Parse(dt.Rows[i][1].ToString());
                ChitietdonHang.MaTuiXach = int.Parse(dt.Rows[i][2].ToString());
                ChitietdonHang.SoLuong = int.Parse(dt.Rows[i][3].ToString());
                ChitietdonHang.DonGia = float.Parse(dt.Rows[i][4].ToString());
                li.Add(ChitietdonHang);
            }
            return li;
        }

        public List<ChiTietDonHang> sp_ChiTietDonHang_Paginate_By_ID(int page_index, int hoten)
        {
            List<ChiTietDonHang> li = new List<ChiTietDonHang>();
            DataTable dt = _ChiTietDonHangBll.sp_ChiTietDonHang_Paginate_By_ID(page_index, hoten);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChiTietDonHang ChitietdonHang = new ChiTietDonHang();
                ChitietdonHang.MaCtdonHang = int.Parse(dt.Rows[i][1].ToString());
                ChitietdonHang.MaDonHang = int.Parse(dt.Rows[i][2].ToString());
                ChitietdonHang.MaTuiXach = int.Parse(dt.Rows[i][3].ToString());
                ChitietdonHang.SoLuong = int.Parse(dt.Rows[i][4].ToString());
                ChitietdonHang.DonGia = float.Parse(dt.Rows[i][5].ToString());
                li.Add(ChitietdonHang);
            }
            return li;
        }
    }
}
