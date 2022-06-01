using DoAnTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.BLL
{
    public interface IRoleBLL
    {
        List<RoleModel> GetRoleList();
        public bool ChecAdminkRole(string userID);
    }
}
