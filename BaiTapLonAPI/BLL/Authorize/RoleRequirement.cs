using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.BLL.Authorize
{
    public class RoleRequirement: IAuthorizationRequirement
    {
        public RoleRequirement(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; }
    }
}
