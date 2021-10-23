using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApartmentManagement.Business.Business.Abstract;
using ApartmentManagement.Entities.Dtos.Authentication;
using Core.Utilities.Results;
using Core.Utilities.UserManagement;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Mvc.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }

        [Route("manager/login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("manager/login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }
            var result = _authService.ManagerLogin(loginDto);
            if (result.ResultType != ResultType.Success)
            {
                ModelState.AddModelError("Result", result.Messages[0]);
                return View(loginDto);
            }

            var claims = new List<Claim>();
            claims.AddRange(new List<Claim>
            {
                new(UserInfo.Id, result.Data.Id.ToString()),
                new(ClaimTypes.Name, result.Data.FullName),
                new(UserInfo.Role.Admin, "true")
            });
            var claimsIdentity = new ClaimsIdentity(claims, "manager");

            await _httpContextAccessor.HttpContext!
                .SignInAsync(
                    "manager",
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                        IsPersistent = true
                    }
                );

            return RedirectToAction("Index", "Home", new { area = "Manager" });
        }

        [Route("manager/logout")]
        public async Task<IActionResult> Logout()
        {
            await _httpContextAccessor.HttpContext!.SignOutAsync("manager");
            return RedirectToAction("Index", "Home", new { area = "Manager" });
        }
    }
}
