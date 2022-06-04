using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DoAnTotNghiep.DAL;
using DoAnTotNghiep.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DoAnTotNghiep.BLL
{
    public class UserBLL : IUserBLL
    {
        private string Secret;
        IUserRepository _userRepository;
        public UserBLL(IUserRepository userBLL, IConfiguration configuration)
        {
            _userRepository = userBLL;
            Secret = configuration["AppSettings:Secret"];
        }
        public void addUser(string TenDangNhap, string MatKhau)
        {
            _userRepository.addUsers(TenDangNhap, MatKhau);
        }

        public List<User> getAlluser()
        {
            List<User> li = new List<User>();
            DataTable dt = new DataTable();
            dt = _userRepository.getAllUser();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                User user = new User();
                user.Ma = int.Parse(dt.Rows[i][0].ToString());
                user.TenDangNhap= dt.Rows[i][1].ToString();
                user.MatKhau = dt.Rows[i][2].ToString();
                li.Add(user);
            }
            return li;
        }

        public User GetUser(string TenDangNhap, string MatKhau)
        {
            User li = new User();
            try
            {
                
                //DataTable dt = new DataTable();
                DataTable dt = _userRepository.GetUser(TenDangNhap, MatKhau);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //User li = new User();
                    li.Ma = int.Parse(dt.Rows[i][0].ToString());
                    li.TenDangNhap = dt.Rows[i][1].ToString();
                    li.MatKhau = dt.Rows[i][2].ToString();
                    li.role = dt.Rows[i][3].ToString();
                }
                return li;
            }
            catch(Exception e)
            {
                li = null;
                return li;
            }
        }
        public User Authenticate(string username, string password)
        {
            var user = GetUser(username, password);
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Subject = new ClaimsIdentity(new Claim[]
                //{
                //    new Claim(ClaimTypes.Name, user.TenDangNhap.ToString()),
                //    new Claim(ClaimTypes.StreetAddress, user.MatKhau)
                //}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.token = tokenHandler.WriteToken(token);

            return user;

        }
        public void updateUsers(string TenDangNhap, string MatKhau)
        {
            _userRepository.updateUsers(TenDangNhap, MatKhau);
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                User user = new User();
                var dt = new DataTable();
                dt = _userRepository.GetUserByEmail(email);
                user.Ma = int.Parse(dt.Rows[0][0].ToString());
                user.TenDangNhap = dt.Rows[0][1].ToString();
                user.MatKhau = dt.Rows[0][2].ToString();
                return user;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
