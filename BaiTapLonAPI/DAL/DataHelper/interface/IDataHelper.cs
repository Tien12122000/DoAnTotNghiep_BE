using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL.DataHelper
{
    public interface IDataHelper
    {
        //void setConnection();
        void OpenConnection();
        void CloseConnection();

        DataTable ExecuteQueryReturnTable(string sprocedureName);


        DataTable ExecuteQueryReturnTable(string sprocedureName, List<string> paramaternames, List<string> paramObjects);

        void ExecuteNonSProcedure(string sprocedureName, List<string> paramaternames, List<string> paramObjects);
    }
}
