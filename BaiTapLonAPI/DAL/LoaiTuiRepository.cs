using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DoAnTotNghiep.DAL.DataHelper;
using DoAnTotNghiep.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DoAnTotNghiep.DAL
{
    public class LoaiTuiRepository : ILoaiRepository
    {

        SqlDataAdapter da;
        SqlConnection cn;
        DataTable dt;
        IDataHelper _dataHelper;
        string stringConnection;
        public LoaiTuiRepository(IDataHelper dataHelper, IConfiguration configuration)
        {
            this._dataHelper = dataHelper;
            stringConnection = configuration["ConnectionStrings:Default"];
        }
        public DataTable getloai()
        {
            //_dataHelper.OpenConnection();
            cn = new SqlConnection(stringConnection);
            cn.Open();
            string query = "SELECT * from LoaiTuiXach";
            da = new SqlDataAdapter(query, cn);
            dt = new DataTable();
            da.Fill(dt);
            //_dataHelper.CloseConnection();
            cn.Close();
            return dt;
        }
        public void addloaituixach(string tenloai, string mota)
        {
            _dataHelper.OpenConnection();


            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@tenloai");
            listname.Add("@mota");
            listvalue.Add(tenloai);
            listvalue.Add(mota);
            _dataHelper.ExecuteNonSProcedure("AddloaiTuiXach", listname, listvalue);
            _dataHelper.CloseConnection();
        }
        
        public void Delloaituixach(string maloai)
        {
            _dataHelper.OpenConnection();
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@MaLoaiTuiXach");
            listvalue.Add(maloai);
            _dataHelper.ExecuteNonSProcedure("DelLoai", listname, listvalue);
            _dataHelper.CloseConnection();
        }
        public void Updateloaitui(string maloai, string tenloai, string mota)
        {
            _dataHelper.OpenConnection();
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@MaLoaiTuiXach");
            listname.Add("@TenLoai");
            listname.Add("@MoTa");
            listvalue.Add(maloai);
            listvalue.Add(tenloai);
            listvalue.Add(mota);
            _dataHelper.ExecuteNonSProcedure("updateloaiTuiXach", listname, listvalue);
            _dataHelper.CloseConnection();
        }

        public DataTable getAllPaginate(int pageIndex)
        {
            List<string> listName = new List<string>();
            List<string> listValue = new List<string>();
            listName.Add("@page_index");
            listName.Add("@page_size");
            listValue.Add(pageIndex.ToString());
            listValue.Add("8");
            dt = _dataHelper.ExecuteQueryReturnTable("LoaiTuiPagination", listName, listValue);
            return dt;
        }
        public
        DataTable GetLoaiTuiByID(int id)
        {
            List<string> listName = new List<string>();
            List<string> listValue = new List<string>();

            listName.Add("@MaLoaiTuiXach");
            listValue.Add(id.ToString());
            dt = new DataTable();
            dt = _dataHelper.ExecuteQueryReturnTable("GetLoaiTuiByID", listName, listValue);
            return dt;
        }
    }
}
