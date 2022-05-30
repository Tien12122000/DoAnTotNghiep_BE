using DoAnTotNghiep.BLL;
using DoAnTotNghiep.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleBLL _roleBll;
        public RoleController(IRoleBLL roleBll)
        {
            _roleBll = roleBll;
        }
        [HttpGet("Get-Roles-List")]
        public List<RoleModel> RoleModels()
        {
            return _roleBll.GetRoleList();
        }
    }
}
