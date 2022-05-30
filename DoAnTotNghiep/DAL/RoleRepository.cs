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
    public class RoleRepository : IRoleRepository
    {
        SqlDataAdapter da;
        SqlConnection cn;
        DataTable dt;
        IDataHelper _dataHelper;
        string stringConnection;
        public RoleRepository(IDataHelper dataHelper, IConfiguration configuration)
        {
            this._dataHelper = dataHelper;
            stringConnection = configuration["ConnectionStrings:Default"];
        }
        public DataTable RoleModels()
        {
            dt = _dataHelper.ExecuteQueryReturnTable("Get_all_Role");
            return dt;
        }
    }
}
