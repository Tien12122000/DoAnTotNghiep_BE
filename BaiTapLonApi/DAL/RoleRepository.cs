using DoAnTotNghiep.DAL.DataHelper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

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
            dt = _dataHelper.ExecuteQueryReturnTable("Get_all_Roles");
            return dt;
        }
        
    }
}
