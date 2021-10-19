using System.Security.Claims;
using Core.Extensions;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.UserManagement
{
    public class CurrentUser
    {
        private static readonly ClaimsPrincipal User = ServiceTool.GetService<IHttpContextAccessor>().HttpContext.User;
        public static int Id => User.GetUserId();
        public static bool IsInRole(UserInfo.Role role) => User.IsInRole(role.ToString());
    }
}