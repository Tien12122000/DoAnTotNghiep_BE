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
        [HttpGet("CheckRole/{userId}")]
        public IActionResult CheckRole(string userID)
        {
            try
            {
                var listRole = _roleBll.GetRoleList();
                if (listRole==null)
                {
                    throw new Exception();
                }
                var role = listRole.Select(m => m.UserId == int.Parse(userID) && m.RoleName.Trim().ToLower() == Role.Admin.ToLower()).FirstOrDefault();
                if (!role)
                {
                    throw new Exception();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}
