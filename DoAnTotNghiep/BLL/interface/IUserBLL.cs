using DoAnTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.BLL
{
    public interface IUserBLL
    {

        //UserModel Authenticate(string username, string password);
        User Authenticate(string TenDangNhap, string MatKhau);
        void updateUsers(string TenDangNhap, string MatKhau);
        public List<User> getAlluser();
        void addUser(string TenDangNhap, string MatKhau);
        public User GetUserByEmail(string email);
    }
}
