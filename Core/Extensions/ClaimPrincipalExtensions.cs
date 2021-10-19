using System;
using System.Security.Claims;
using Core.Utilities.UserManagement;

namespace Core.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal) =>
            int.TryParse(principal.FindFirst(UserInfo.Id).Value, out var id) ? id : throw new Exception("User not found");

    }
}