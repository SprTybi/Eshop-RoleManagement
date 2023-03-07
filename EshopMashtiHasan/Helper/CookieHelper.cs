using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EshopMashtiHasan.Helper
{
    public class CookieHelper : ICookieHelper
    {
        private readonly IHttpContextAccessor httpContext;

        public CookieHelper(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }
        public bool WriteItemToCookie(string Key, string Value)
        {
            try
            {
                CookieOptions opt = new CookieOptions();
                opt.Expires = DateTime.Now.AddDays(90);

                httpContext.HttpContext.Response.Cookies.Append(Key, Value, opt);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string ReadItemFromCookie(string Key)
        {
            return httpContext.HttpContext.Request.Cookies[Key] ?? "";
        }
    }
}
