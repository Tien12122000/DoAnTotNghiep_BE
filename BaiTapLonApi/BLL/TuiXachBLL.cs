using DoAnTotNghiep.DAL;
using DoAnTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.BLL
{
    public class TuiXachBLL : ITuiXachBLL
    {
        DataTable dt;
        ITuiRepositorycs _dats;
        public TuiXachBLL(ITuiRepositorycs tuiRepositorycs)
        {
            this._dats = tuiRepositorycs;
        }
        public void addTui(string maloai, string tenloai, string gia, string mota, string hinhAnh)
        {
            _dats.addtuixach(maloai, tenloai, gia, mota, hinhAnh);
        }

        public void delTui(int matui)
        {
            _dats.Deltuixach(matui);
        }

        public List<TuiXach> getdatatuixach()
        {
            dt = new DataTable();
            dt = _dats.getTui(dt);
            TuiXach tui;
            List<TuiXach> tuiLi = new List<TuiXach>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tui = new TuiXach();
                tui.MaTuiXach = int.Parse(dt.Rows[i][0].ToString());
                tui.MaLoaiTuiXach = int.Parse(dt.Rows[i][1].ToString());
                tui.TenTuiXach = dt.Rows[i][2].ToString();
                tui.Gia = float.Parse(dt.Rows[i][3].ToString());
                tui.MoTa = dt.Rows[i][4].ToString();
                tui.HinhAnh = dt.Rows[i][5].ToString();
                tui.soluong = int.Parse(dt.Rows[i][6].ToString());
                tui.luotmua = int.Parse(dt.Rows[i][7].ToString());
                tuiLi.Add(tui);
            }
            return tuiLi;
        }

        public List<TuiXach> tuipaginate(int pageIndex)
        {
            dt = new DataTable();
            dt = _dats.getAllPaginate(pageIndex);
            TuiXach tui;
            List<TuiXach> tuiLi = new List<TuiXach>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tui = new TuiXach();
                tui.MaTuiXach = int.Parse(dt.Rows[i][1].ToString());
                tui.MaLoaiTuiXach = int.Parse(dt.Rows[i][2].ToString());
                tui.TenTuiXach = dt.Rows[i][3].ToString();
                tui.Gia = float.Parse(dt.Rows[i][4].ToString());
                tui.MoTa = dt.Rows[i][5].ToString();
                tui.HinhAnh = dt.Rows[i][6].ToString();
                tui.soluong = int.Parse(dt.Rows[i][7].ToString());
                tui.luotmua = int.Parse(dt.Rows[i][8].ToString());
                tuiLi.Add(tui);
            }
            return tuiLi;
        }

        public List<TuiXach> SearchTuiPaginate(int pageIndex, string key)
        {
            dt = new DataTable();
            dt = _dats.SearchTuiPaginate(pageIndex, key);
            TuiXach tui;
            List<TuiXach> tuiLi = new List<TuiXach>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tui = new TuiXach();
                tui.MaTuiXach = int.Parse(dt.Rows[i][1].ToString());
                tui.MaLoaiTuiXach = int.Parse(dt.Rows[i][2].ToString());
                tui.TenTuiXach = dt.Rows[i][3].ToString();
                tui.Gia = float.Parse(dt.Rows[i][4].ToString());
                tui.MoTa = dt.Rows[i][5].ToString();
                tui.HinhAnh = dt.Rows[i][6].ToString();
                tui.soluong = int.Parse(dt.Rows[i][7].ToString());
                tui.luotmua = int.Parse(dt.Rows[i][8].ToString());
                tuiLi.Add(tui);
            }
            return tuiLi;
        }



        public void UpdateTui(string matuixah, string maloai, string tenloai, string gia, string mota, string hinhAnh)
        {
            _dats.Updatetui(matuixah, maloai, tenloai, gia, mota, hinhAnh);
        }
        public TuiXach GetTuiByID(int id)
        {
            TuiXach tui = new TuiXach();
            dt = new DataTable();
            dt = _dats.GetTuibyID(id);
            tui.MaTuiXach = int.Parse(dt.Rows[0][0].ToString());
            tui.MaLoaiTuiXach = int.Parse(dt.Rows[0][1].ToString());
            tui.TenTuiXach = dt.Rows[0][2].ToString();
            tui.Gia = float.Parse(dt.Rows[0][3].ToString());
            tui.MoTa = dt.Rows[0][4].ToString();
            tui.HinhAnh = dt.Rows[0][5].ToString();
            tui.soluong = int.Parse(dt.Rows[0][6].ToString());
            tui.luotmua = int.Parse(dt.Rows[0][7].ToString());
            return tui;
        }

        public List<TuiXach> countSearchin4(string key)
        {
            dt = new DataTable();
            dt = _dats.countSearchin4(key);
            TuiXach tui;
            List<TuiXach> tuiLi = new List<TuiXach>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tui = new TuiXach();
                tui.MaTuiXach = int.Parse(dt.Rows[i][0].ToString());
                tui.MaLoaiTuiXach = int.Parse(dt.Rows[i][1].ToString());
                tui.TenTuiXach = dt.Rows[i][2].ToString();
                tui.Gia = float.Parse(dt.Rows[i][3].ToString());
                tui.MoTa = dt.Rows[i][4].ToString();
                tui.HinhAnh = dt.Rows[i][5].ToString();
                tui.soluong = int.Parse(dt.Rows[i][6].ToString());
                tui.luotmua = int.Parse(dt.Rows[i][7].ToString());
                tuiLi.Add(tui);
            }
            return tuiLi;
        }

        public List<TuiXach> getTuiByCateIdPaginate(int index, int id)
        {
            dt = new DataTable();
            dt = _dats.getTuiByCateIdPaginate(index, id);
            TuiXach tui;
            List<TuiXach> tuiLi = new List<TuiXach>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tui = new TuiXach();
                tui.MaTuiXach = int.Parse(dt.Rows[i][1].ToString());
                tui.MaLoaiTuiXach = int.Parse(dt.Rows[i][2].ToString());
                tui.TenTuiXach = dt.Rows[i][3].ToString();
                tui.Gia = float.Parse(dt.Rows[i][4].ToString());
                tui.MoTa = dt.Rows[i][5].ToString();
                tui.HinhAnh = dt.Rows[i][6].ToString();
                //tui.soluong = int.Parse(dt.Rows[i][7].ToString());
                //tui.luotmua = int.Parse(dt.Rows[i][8].ToString());
                tuiLi.Add(tui);
            }
            return tuiLi;
        }
        public List<TuiXach> getTuiByCateId_all(int id)
        {
            dt = new DataTable();
            dt = _dats.getTuiByCateId_all(id);
            TuiXach tui;
            List<TuiXach> tuiLi = new List<TuiXach>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tui = new TuiXach();
                tui.MaTuiXach = int.Parse(dt.Rows[i][0].ToString());
                tui.MaLoaiTuiXach = int.Parse(dt.Rows[i][1].ToString());
                tui.TenTuiXach = dt.Rows[i][2].ToString();
                tui.Gia = float.Parse(dt.Rows[i][3].ToString());
                tui.MoTa = dt.Rows[i][4].ToString();
                tui.HinhAnh = dt.Rows[i][5].ToString();
                tui.soluong = int.Parse(dt.Rows[i][6].ToString());
                tui.luotmua = int.Parse(dt.Rows[i][7].ToString());
                tuiLi.Add(tui);
            }
            return tuiLi;
        }

        public void updateQuantity(int id, int quantity, int luotmua)
        {
            _dats.updateQuantity(id, quantity, luotmua);
        }
    }
}
