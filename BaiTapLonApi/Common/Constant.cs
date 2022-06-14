using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Common
{
    public static class Constant
    {
        public static class BillStatus
        {
            public const string UNFINISHED = "unfinished";
            public const string RECEIVE = "Receive";
            public const string PACK = "Pack";
            public const string DELIVERING = "Delivering";
            public const string DELIVERED = "Delivered";
        }
    }
}
