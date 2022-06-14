using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DoAnTotNghiep.Models;
namespace DoAnTotNghiep.DAL
{
    public interface ITuiRepositorycs
    {
        public DataTable getTui(DataTable dt);
        public void addtuixach(string maloai, string tenloai, string gia, string mota, string hinhAnh);
        public void Deltuixach(int maloai);

        public void Updatetui(string matuixah, string maloai, string tenloai, string gia, string mota, string hinhAnh);
        DataTable getAllPaginate(int pageIndex);
        DataTable GetTuibyID(int id);
        DataTable SearchTuiPaginate(int pageIndex, string key);
        DataTable countSearchin4(string key);
        DataTable getTuiByCateIdPaginate(int index, int id);
        DataTable getTuiByCateId_all(int id);
        void updateQuantity(int id, int quantity, int luotmua);
    }
}
