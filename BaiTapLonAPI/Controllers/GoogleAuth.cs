using DoAnTotNghiep.BLL;
using DoAnTotNghiep.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleAuth : ControllerBase
    {
        private IUserBLL _UserBLL;
        public GoogleAuth(IUserBLL userBusiness)
        {
            _UserBLL = userBusiness;
        }
        [HttpPost("Google-Auth")]
        public IActionResult GoogleLogin([FromBody] GoogleAuthRes googleAuthRes)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(@"‪C:\Users\Hieu Vu\Desktop\GoogleRes.txt");
                streamWriter.WriteLine(googleAuthRes.AuthToken + "#" + googleAuthRes.Email + "#" + googleAuthRes.FirstName + "#" +
                    googleAuthRes.Id + "#" + googleAuthRes.IdToken + "#" + googleAuthRes.LastName + "#" + googleAuthRes.Name + "#" + googleAuthRes.PhotoUrl +
                    "#" + googleAuthRes.Provider);
                //File.AppendText(@"‪C:\Users\Hieu Vu\Desktop\GoogleRes.txt");

                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPost("Login-Google-Account")]
        public async Task<IActionResult> login([FromBody] string access_token)
        {

            try
            {
                HttpClient client = new HttpClient();
                var urlProfile = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + access_token;

                client.CancelPendingRequests();
                HttpResponseMessage output = await client.GetAsync(urlProfile);
                string outputData = await output.Content.ReadAsStringAsync();
                GoogleUserOutputData serStatus = JsonConvert.DeserializeObject<GoogleUserOutputData>(outputData);


                var user = _UserBLL.GetUserByEmail(serStatus.email);
                if (user == null) return null;

                var tokenHandler = new JwtSecurityTokenHandler();
                //string SecretKey = configuration["ClientId"];
                var key = Encoding.ASCII.GetBytes("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");
                var expires = DateTime.UtcNow.AddSeconds(864000);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                            new Claim(MyClaimTypes.UserAccount,serStatus.email),
                            new Claim(MyClaimTypes.UserId,serStatus.id.ToString()),
                            new Claim(MyClaimTypes.FullName,serStatus.name)
                    }),
                    Expires = expires,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var Restoken = new TokenGoogleVM()
                {
                    AccessToken = tokenHandler.WriteToken(token),
                    Expires = expires,
                    User = new TokenGoogleVM.GoogleUserOutputData()
                    {
                        id = user.Ma.ToString(),
                        name = user.TenDangNhap,
                        given_name = serStatus.given_name,
                        email = serStatus.email,
                        picture = serStatus.picture,
                        family_name = serStatus.family_name,
                        locale = serStatus.locale,
                        //Phone = user.PhoneNumber
                        //isActive = user.IsAcive,
                        //position = user.PositionId.ToString(),
                        //startWorkDate = user.StartWorkDate
                    }
                };
                return Ok(Restoken);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet("Get-User-By-Token")]
        public async Task<IActionResult> GetUserByToken(string token)
        {
            try
            {
                HttpClient client = new HttpClient();
                var urlProfile = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + token;

                client.CancelPendingRequests();
                HttpResponseMessage output = await client.GetAsync(urlProfile);
                string outputData = await output.Content.ReadAsStringAsync();
                GoogleUserOutputData serStatus = JsonConvert.DeserializeObject<GoogleUserOutputData>(outputData);


                var user = _UserBLL.GetUserByEmail(serStatus.email);
                if (user == null) return null;
                return Ok(serStatus);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
