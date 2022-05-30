using DoAnTotNghiep.DAL;
using DoAnTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.BLL
{
    public class RoleBLL : IRoleBLL
    {
        DataTable dt;
        IRoleRepository _dats;
        public RoleBLL(IRoleRepository dats)
        {
            this._dats = dats;
        }
        public List<RoleModel> GetRoleList()
        {
            List<RoleModel> li = new List<RoleModel>();
            dt = new DataTable();
            dt = _dats.RoleModels();
            RoleModel role;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                role = new RoleModel();
                role.RoleId = int.Parse(dt.Rows[i][0].ToString());
                role.UserId = int.Parse(dt.Rows[i][1].ToString());
                role.RoleName = dt.Rows[i][2].ToString();
                li.Add(role);
            }
            return li;
        }
    }
}
