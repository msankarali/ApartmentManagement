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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Mvc.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = _authService.Login(loginDto);
            if (result.ResultType != ResultType.Success)
            {
                ModelState.AddModelError("Result", result.Messages[0]);
                return View(loginDto);
            }

            var claims = new List<Claim>();
            claims.AddRange(new List<Claim>
            {
                new(UserInfo.Id, result.Data.Id.ToString()),
                new(UserInfo.Role.User, "true")
            });
            var claimsIdentity = new ClaimsIdentity(claims);

            await _httpContextAccessor.HttpContext!
                .SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity)
                );

            return RedirectToAction("Index", "Home");
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
