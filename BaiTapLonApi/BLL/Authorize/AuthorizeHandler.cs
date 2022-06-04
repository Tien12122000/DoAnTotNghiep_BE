using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTotNghiep.BLL.Authorize
{
    public class AuthorizeHandler : AuthorizationHandler<RoleRequirement>
    {
        private readonly IUserBLL _userBLL;
        public AuthorizeHandler(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            var userName = requirement.UserName;
            return Task.CompletedTask;
        }
    }
}
