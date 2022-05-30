using DoAnTotNghiep.DAL.DataHelper;
using DoAnTotNghiep.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public class TuiRepository:ITuiRepositorycs
    {
        IDataHelper _dataHelper;
        DataTable dt;
        SqlConnection cn;
        SqlDataAdapter da;
        string stringConnection;
        public TuiRepository(IDataHelper dataHelper, IConfiguration configuration)
        {
            this._dataHelper = dataHelper;
            stringConnection = configuration["ConnectionStrings:Default"];
        }
        public DataTable getTui(DataTable dta)
        {
            cn = new SqlConnection(stringConnection);
            cn.Open();
            string query = "SELECT * from TuiXach";
            da = new SqlDataAdapter(query, cn);
            dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }
        public void addtuixach(string maloai, string tenloai, string gia, string mota, string hinhAnh)
        {
            //_dataHelper.OpenConnection();


            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@MaLoaiTuiXach");
            listname.Add("@TenTuiXach");
            listname.Add("@Gia");
            listname.Add("@MoTa");
            listname.Add("@HinhAnh");
            listvalue.Add(maloai);
            listvalue.Add(tenloai);
            listvalue.Add(gia);
            listvalue.Add(mota);
            listvalue.Add(hinhAnh);
            _dataHelper.ExecuteNonSProcedure("addtui", listname, listvalue);
            //_dataHelper.CloseConnection();
        }
        public void Deltuixach(int maTui)
        {
            _dataHelper.OpenConnection();

            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@MaTuiXach");
            listvalue.Add(maTui.ToString());
            _dataHelper.ExecuteNonSProcedure("DelTui", listname, listvalue);
            _dataHelper.CloseConnection();
        }

        public void Updatetui(string matuixah, string maloai, string tenloai, string gia, string mota, string hinhAnh)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@MaTuiXach");
            listname.Add("@maloaitui");
            listname.Add("@TenTuiXach");
            listname.Add("@Gia");
            listname.Add("@MoTa");
            listname.Add("@HinhAnh");
            listvalue.Add(matuixah);
            listvalue.Add(maloai);
            listvalue.Add(tenloai);
            listvalue.Add(gia);
            listvalue.Add(mota);
            listvalue.Add(hinhAnh);
            _dataHelper.ExecuteNonSProcedure("updateTui", listname, listvalue);
        }
        public DataTable getAllPaginate(int pageIndex)
        {
            List<string> listName = new List<string>();
            List<string> listValue = new List<string>();
            listName.Add("@page_index");
            listName.Add("@page_size");
            listValue.Add(pageIndex.ToString());
            listValue.Add("8");
            dt = _dataHelper.ExecuteQueryReturnTable("TuiPagination", listName, listValue);
            return dt;
        }
        public DataTable GetTuibyID(int id)
        {
            List<string> listName = new List<string>();
            List<string> listValue = new List<string>();
            listName.Add("@matui");
            listValue.Add(id.ToString());
            dt = _dataHelper.ExecuteQueryReturnTable("Get_Tui_by_ID", listName, listValue);
            return dt;
        }
        public DataTable SearchTuiPaginate(int pageIndex, string key)
        {
            List<string> listName = new List<string>();
            List<string> listValue = new List<string>();
            listName.Add("@page_index");
            listName.Add("@page_size");
            listName.Add("@hoten");
            listValue.Add(pageIndex.ToString());
            listValue.Add("8");
            listValue.Add(key);
            dt = _dataHelper.ExecuteQueryReturnTable("sp_TuiXach_search", listName, listValue);
            return dt;
        }
        public DataTable countSearchin4(string key)
        {
            List<string> listName = new List<string>();
            List<string> listValue = new List<string>();
            listName.Add("@key");
            listValue.Add(key.ToString());
            dt = _dataHelper.ExecuteQueryReturnTable("countSearchin4", listName, listValue);
            return dt;
        }
        public DataTable getTuiByCateIdPaginate(int index,int id)
        {
            List<string> listName = new List<string>();
            List<string> listValue = new List<string>();
            listName.Add("@page_index");
            listName.Add("@page_size");
            listName.Add("@id");
            listValue.Add(index.ToString());
            listValue.Add("8");
            listValue.Add(id.ToString());
            dt = _dataHelper.ExecuteQueryReturnTable("getTuiByCateIdPaginate", listName, listValue);
            return dt;
        }
        public  DataTable getTuiByCateId_all(int id)
        {
            List<string> listName = new List<string>();
            List<string> listValue = new List<string>();
            listName.Add("@id");
            listValue.Add(id.ToString());
            dt = _dataHelper.ExecuteQueryReturnTable("getTuiByCateId_all", listName, listValue);
            return dt;
        }
    }
}
