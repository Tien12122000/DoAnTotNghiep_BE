using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.Models
{
    public class GoogleAuthRes
    {
        string authToken;
        string email;
        string firstName;
        string id;
        string idToken;
        string lastName;
        string name;
        string photoUrl;
        string provider;
        //response response;

        public string AuthToken { get ; set ; }
        public string Email { get; set; }
        public string FirstName { get ; set ; }
        public string Id { get ; set ; }
        public string IdToken { get ; set; }
        public string LastName { get ; set ; }
        public string Name { get; set; }
        public string PhotoUrl { get ; set ; }
        public string Provider { get; set; }
        //public response Response { get => response; set => response = value; }
    }
    public class response
    {
        string access_token;
        string expires_at;
        string expires_in;
        string first_issued_at;
        string id_token;
        string idpId;
        string login_hint;
        string scope;
        string token_type;

        public string Access_token { get => access_token; set => access_token = value; }
        public string Expires_at { get => expires_at; set => expires_at = value; }
        public string Expires_in { get => expires_in; set => expires_in = value; }
        public string First_issued_at { get => first_issued_at; set => first_issued_at = value; }
        public string Id_token { get => id_token; set => id_token = value; }
        public string IdpId { get => idpId; set => idpId = value; }
        public string Login_hint { get => login_hint; set => login_hint = value; }
        public string Scope { get => scope; set => scope = value; }
        public string Token_type { get => token_type; set => token_type = value; }
    }
}
