using DoAnTotNghiep.DAL.DataHelper;
using DoAnTotNghiep.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.DAL
{
    public class UserRepository:IUserRepository
    {
        IDataHelper _dataHelper;
        public UserRepository(IDataHelper dataHelper)
        {
            this._dataHelper = dataHelper;
        }
        public void addUsers(string TenDangNhap, string MatKhau)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@TenDangNhap");
            listname.Add("@MatKhau");
            listvalue.Add(TenDangNhap);
            listvalue.Add(MatKhau);
            _dataHelper.ExecuteNonSProcedure("AddUsers", listname, listvalue);
        }

        public DataTable getAllUser()
        {
            return _dataHelper.ExecuteQueryReturnTable("Get_all_User");
        }

        public DataTable GetUser(string TenDangNhap, string MatKhau)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@TenDangNhap");
            listname.Add("@MatKhau");
            listvalue.Add(TenDangNhap);
            listvalue.Add(MatKhau);
            return _dataHelper.ExecuteQueryReturnTable("GetUser", listname, listvalue);
        }

        public void updateUsers(string TenDangNhap, string MatKhau)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@TenDangNhap");
            listname.Add("@MatKhau");
            listvalue.Add(TenDangNhap);
            listvalue.Add(MatKhau);
            _dataHelper.ExecuteNonSProcedure("UpdateUsers", listname, listvalue);
        }
        public DataTable GetUserByEmail(string email)
        {
            List<string> listvalue = new List<string>();
            List<string> listname = new List<string>();
            listname.Add("@email");
            listvalue.Add(email);
            return _dataHelper.ExecuteQueryReturnTable("get_user_by_email", listname, listvalue);
        }
    }
}
