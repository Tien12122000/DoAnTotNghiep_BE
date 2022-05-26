using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DoAnTotNghiep.DAL.DataHelper
{
    public class DataHelper: IDataHelper
    {

        SqlDataAdapter da;
        SqlConnection cn;
        string connect;
        SqlCommand sqlcm;
        DataTable dt;
        public DataHelper(IConfiguration configuration)
        {
            this.connect = configuration["ConnectionStrings:Default"];
        }
        public void OpenConnection()
        {
            cn = new SqlConnection(connect);
            if(cn.State== ConnectionState.Closed)
            {
                cn.Open();
            }
        }
        public void CloseConnection()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        public void ExecuteNonSProcedure(string sprocedureName,List<string> paramaternames, List<string> paramObjects)
        {
            OpenConnection();
            sqlcm = new SqlCommand(sprocedureName, cn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < paramaternames.Count; i++)
            {
                string a = paramObjects[i].ToString();
                a = a.Trim();
                sqlcm.Parameters.AddWithValue(paramaternames[i],a);
            }
            sqlcm.ExecuteNonQuery();
            CloseConnection();
        }
        public DataTable ExecuteQueryReturnTable(string sprocedureName, List<string> paramaternames, List<string> paramObjects)
        {
            OpenConnection();
            sqlcm = new SqlCommand(sprocedureName, cn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < paramaternames.Count; i++)
            {
                sqlcm.Parameters.AddWithValue(paramaternames[i], paramObjects[i]);
            }
            da = new SqlDataAdapter(sqlcm);
            dt = new DataTable();
            da.Fill(dt);

            da.Dispose();
            sqlcm.Dispose();
            CloseConnection();
            return dt;
        }

        public DataTable ExecuteQueryReturnTable(string sprocedureName)
        {
            dt = new DataTable();
            OpenConnection();
            sqlcm = new SqlCommand(sprocedureName, cn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(sqlcm);
            da.Fill(dt);
            da.Dispose();
            sqlcm.Dispose();
            CloseConnection();
            return dt;
        }
    }
}
