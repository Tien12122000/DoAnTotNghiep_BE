using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DoAnTotNghiep.DAL;
using DoAnTotNghiep.Models;

namespace DoAnTotNghiep.BLL
{
    public class DonHangBLL : IDonHangBLL
    {
        IDonHangRepository _DonHangBLL;
        public DonHangBLL(IDonHangRepository donHangBLL)
        {
            _DonHangBLL = donHangBLL;
        }
        public void addDonHang(string MaKhachHang, string MaNhaVien, string NgayDatHang, string DiaChiGiaoHang, 
            string SoDienThoai, string TrangThaiDonHang, string TongTien, string GhiChu, string tenkhachHang)
        {
            _DonHangBLL.addDonHang(MaKhachHang, MaNhaVien, NgayDatHang, DiaChiGiaoHang, SoDienThoai, TrangThaiDonHang
                , TongTien, GhiChu, tenkhachHang);
        }

        public List<DonHang> countSearchDonHangin4(string key)
        {
            List<DonHang> li = new List<DonHang>();
            DataTable dt = _DonHangBLL.countSearchDonHangin4(key);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DonHang donHang = new DonHang();
                donHang.MaDonHang = int.Parse(dt.Rows[i][0].ToString());
                donHang.MaKhachHang = int.Parse(dt.Rows[i][1].ToString());
                donHang.MaNhaVien = int.Parse(dt.Rows[i][2].ToString());
                donHang.NgayDatHang = dt.Rows[i][3].ToString();
                donHang.DiaChiGiaoHang = dt.Rows[i][4].ToString();
                donHang.SoDienThoai = dt.Rows[i][5].ToString();
                donHang.TrangThaiDonHang = dt.Rows[i][6].ToString();
                donHang.TongTien = float.Parse(dt.Rows[i][7].ToString());
                donHang.GhiChu = dt.Rows[i][8].ToString();
                donHang.tenKhachHang = dt.Rows[i][9].ToString();
                li.Add(donHang);
            }
            return li;
        }

        public void DelDonHang(string id)
        {
            _DonHangBLL.DelDonHang(id);
        }

        public List<DonHang> DonHangPaginate(int pageIndex)
        {
            List<DonHang> li = new List<DonHang>();
            DataTable dt = _DonHangBLL.DonHangPaginate(pageIndex);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DonHang donHang = new DonHang();
                donHang.MaDonHang = int.Parse(dt.Rows[i][1].ToString());
                donHang.MaKhachHang = int.Parse(dt.Rows[i][2].ToString());
                donHang.MaNhaVien = int.Parse(dt.Rows[i][3].ToString());
                donHang.NgayDatHang = dt.Rows[i][4].ToString();
                donHang.DiaChiGiaoHang = dt.Rows[i][5].ToString();
                donHang.SoDienThoai = dt.Rows[i][6].ToString();
                donHang.TrangThaiDonHang = dt.Rows[i][7].ToString();
                donHang.TongTien = float.Parse(dt.Rows[i][8].ToString());
                donHang.GhiChu = dt.Rows[i][9].ToString();
                donHang.tenKhachHang = dt.Rows[i][10].ToString();
                li.Add(donHang);
            }
            return li;
        }

        public List<DonHang> getAllDonHang()
        {
            List<DonHang> li = new List<DonHang>();
            DataTable dt = _DonHangBLL.getAllDonHang();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DonHang donHang = new DonHang();
                donHang.MaDonHang = int.Parse(dt.Rows[i][0].ToString());
                donHang.MaKhachHang= int.Parse(dt.Rows[i][1].ToString());
                donHang.MaNhaVien= int.Parse(dt.Rows[i][2].ToString());
                donHang.NgayDatHang = dt.Rows[i][3].ToString();
                donHang.DiaChiGiaoHang = dt.Rows[i][4].ToString();
                donHang.SoDienThoai = dt.Rows[i][5].ToString();
                donHang.TrangThaiDonHang = dt.Rows[i][6].ToString();
                donHang.TongTien = float.Parse(dt.Rows[i][7].ToString());
                donHang.GhiChu = dt.Rows[i][8].ToString();
                donHang.tenKhachHang = dt.Rows[i][9].ToString();
                li.Add(donHang);
            }
            return li;
        }

        public List<DonHang> getDonHangByUser_KhachHang(string email)
        {
            List<DonHang> li = new List<DonHang>();
            DataTable dt = _DonHangBLL.getDonHangByUser_KhachHang(email);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DonHang donHang = new DonHang();
                donHang.MaDonHang = int.Parse(dt.Rows[i][0].ToString());
                donHang.MaKhachHang = int.Parse(dt.Rows[i][1].ToString());
                donHang.MaNhaVien = int.Parse(dt.Rows[i][2].ToString());
                donHang.NgayDatHang = dt.Rows[i][3].ToString();
                donHang.DiaChiGiaoHang = dt.Rows[i][4].ToString();
                donHang.SoDienThoai = dt.Rows[i][5].ToString();
                donHang.TrangThaiDonHang = dt.Rows[i][6].ToString();
                donHang.TongTien = float.Parse(dt.Rows[i][7].ToString());
                donHang.GhiChu = dt.Rows[i][8].ToString();
                donHang.tenKhachHang = dt.Rows[i][9].ToString();
                li.Add(donHang);
            }
            return li;
        }

        public List<DonHang> getDonHangByUser_KhachHang_Paginate(string pageIndex, string email)
        {
            List<DonHang> li = new List<DonHang>();
            DataTable dt = _DonHangBLL.getDonHangByUser_KhachHang_Paginate(pageIndex, email);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DonHang donHang = new DonHang();
                donHang.MaDonHang = int.Parse(dt.Rows[i][1].ToString());
                donHang.MaKhachHang = int.Parse(dt.Rows[i][2].ToString());
                donHang.MaNhaVien = int.Parse(dt.Rows[i][3].ToString());
                donHang.NgayDatHang = dt.Rows[i][4].ToString();
                donHang.DiaChiGiaoHang = dt.Rows[i][5].ToString();
                donHang.SoDienThoai = dt.Rows[i][6].ToString();
                donHang.TrangThaiDonHang = dt.Rows[i][7].ToString();
                donHang.TongTien = float.Parse(dt.Rows[i][8].ToString());
                donHang.GhiChu = dt.Rows[i][9].ToString();
                donHang.tenKhachHang = dt.Rows[i][10].ToString();
                li.Add(donHang);
            }
            return li;
        }

        public List<DonHang> SearchDonHangPaginate(int pageIndex, string key)
        {
            List<DonHang> li = new List<DonHang>();
            DataTable dt = _DonHangBLL.SearchDonHangPaginate(pageIndex, key);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DonHang donHang = new DonHang();
                donHang.MaDonHang = int.Parse(dt.Rows[i][1].ToString());
                donHang.MaKhachHang = int.Parse(dt.Rows[i][2].ToString());
                donHang.MaNhaVien = int.Parse(dt.Rows[i][3].ToString());
                donHang.NgayDatHang = dt.Rows[i][4].ToString();
                donHang.DiaChiGiaoHang = dt.Rows[i][5].ToString();
                donHang.SoDienThoai = dt.Rows[i][6].ToString();
                donHang.TrangThaiDonHang = dt.Rows[i][7].ToString();
                donHang.TongTien = float.Parse(dt.Rows[i][8].ToString());
                donHang.GhiChu = dt.Rows[i][9].ToString();
                donHang.tenKhachHang = dt.Rows[i][10].ToString();
                li.Add(donHang);
            }
            return li;
        }

        public void UpdateDonHang(string id, string trangthaidonhang)
        {
            _DonHangBLL.UpdateDonHang(id, trangthaidonhang);
        }
    }
}
