using DoAnTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.BLL
{
    public interface ITuiXachBLL
    {
        List<TuiXach> getdatatuixach();
        void addTui(string maloai, string tenloai, string gia, string mota, string hinhAnh);
        void delTui(int matui);
        void UpdateTui(string matuixah, string maloai, string tenloai, string gia, string mota, string hinhAnh);
        List<TuiXach> tuipaginate(int pageIndex);
        TuiXach GetTuiByID(int id);

        List<TuiXach> SearchTuiPaginate(int pageIndex, string key);
        List<TuiXach> countSearchin4(string key);
        List<TuiXach> getTuiByCateIdPaginate(int index, int id);
        List<TuiXach> getTuiByCateId_all(int id);
    }
}
