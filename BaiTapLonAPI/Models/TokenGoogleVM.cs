using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Models
{
    public class TokenGoogleVM
    {
        public string AccessToken { get; set; }
        public DateTime Expires { get; set; }
        public GoogleUserOutputData User { get; set; }
        public class GoogleUserOutputData
        {
            public string id { get; set; }
            public string name { get; set; }
            public string given_name { get; set; }
            public string email { get; set; }
            public string picture { get; set; }
            public string family_name { get; set; }
            public string locale { get; set; }
            //public string Phone { get; set; }
            //public bool? isActive { get; set; }
            //public string position { get; set; }
            //public DateTime? startWorkDate { get; set; }
        }
    }
}
