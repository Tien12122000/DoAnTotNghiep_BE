using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Models
{
    public class MyClaimTypes
    {
        public const string UserId = "UserId";
        public const string UserAccount = "UserAccount";
        public const string FullName = "FullName";
    }
    public class UserInfo
    {
        public int UserId { get; set; }
        public string Account { get; set; }
        public string FullName { get; set; }
    }
}
