//Installing Package Microsoft.AspNetCore.Authentication.Cookies

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.User;

namespace Security.Bussiness.Implementations
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {

            _contextAccessor = contextAccessor;
        }


        public void Signout()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public UserInfo GetCurrentUserInfo()
        {

            if (_contextAccessor.HttpContext.User.Claims.FirstOrDefault() == null)
            {
                return new UserInfo();
            }

            var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            var UserID = int.Parse(claims.First(x => x.Type == "UserID").Value);
            var UserName = claims.First(x => x.Type == ClaimTypes.Name).Value;
            var RoleID = int.Parse(claims.First(x => x.Type == "RoleID").Value);
            var RoleName = claims.First(x => x.Type == "RoleName").Value;
            var FullName = claims.First(x => x.Type == "FullName").Value;
            var Mobile = claims.First(x => x.Type == "Mobile").Value;
            var Email = claims.First(x => x.Type == "Email").Value;
            return new UserInfo { FullName = FullName, RoleID = RoleID, RoleName = RoleName, UserID = UserID, UserName = UserName, Email = Email, Mobile = Mobile };
        }

        public void Signin(UserInfo UserInfo)
        {
            var claims = new List<Claim>
            {
                new Claim("UserID", UserInfo.UserID.ToString()),
                new Claim(ClaimTypes.Name, UserInfo.UserName),
                new Claim("RoleID", UserInfo.RoleID.ToString()),
                new Claim("RoleName", UserInfo.RoleName),
                new Claim("FullName", UserInfo.FullName),
                new Claim("Email", UserInfo.Email),
                new Claim("Mobile", UserInfo.Mobile),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
                ,
                IsPersistent = true

                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            _contextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}