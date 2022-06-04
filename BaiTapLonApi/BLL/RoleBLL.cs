using DoAnTotNghiep.DAL;
using DoAnTotNghiep.Models;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RoleBLL(IRoleRepository dats, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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
        public bool ChecAdminkRole(string userID)
        {
            try
            {
                var listRole = GetRoleList();
                if (listRole == null)
                {
                    throw new Exception();
                }
                var role = listRole.Select(m => m.UserId == int.Parse(userID) && m.RoleName.Trim().ToLower() == Role.Admin.ToLower()).FirstOrDefault();
                if (!role)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
