using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public interface ILoaiRepository
    {
        public DataTable getloai();
        public void addloaituixach(string tenloai, string mota);
        public void Delloaituixach(string maloai);

        public void Updateloaitui(string maloai, string tenloai, string mota);
        DataTable getAllPaginate(int pageIndex);
        DataTable GetLoaiTuiByID(int id);
    }
}
