using DoAnTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public interface IUserRepository
    {
        DataTable GetUser(string username, string password);
        public void updateUsers(string TenDangNhap, string MatKhau);
        public DataTable getAllUser();
        public void addUsers(string TenDangNhap, string MatKhau);
        public DataTable GetUserByEmail(string email);
    }
}
