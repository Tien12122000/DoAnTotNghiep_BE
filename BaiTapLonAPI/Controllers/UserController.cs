
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;using DoAnTotNghiep.Models;
using DoAnTotNghiep.BLL;
//using BaiTapLonAPI.Models;
//using BaiTapLonAPI.BLL;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private  IUserBLL _UserBLL;
        //private string _path;
        public UserController(IUserBLL userBusiness)
        {
            _UserBLL = userBusiness;
            //_path = configuration["AppSettings:PATH"];
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _UserBLL.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(new { user_id = user.Ma, taikhoan = user.TenDangNhap, token = user.token, Role=user.role });
        }
        
        //[Route("Check-Role/{admin}")]
        //public IActionResult CheckRole(string admin)
        //{
        //    if (admin == Role.Admin)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest(new { message = "Username or password is incorrect" });
        //    }
        //}
    }
}
