using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopMashtiHasan.Helper.Keys;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ShoppingMashtiHasan.ViewModel;

namespace EshopMashtiHasan.Helper
{
    public class SessionHelper : ISessionHelper
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void AddCurrentUserToSession(CurrentUser user)
        {
            var key = "my-key";
            var str = JsonConvert.SerializeObject(user);
            httpContextAccessor.HttpContext.Session.SetString(SessionKeys.CurrentUserKey, str);


        }

        public void RemoveCurrenrtFromSession(string Key)
        {
            httpContextAccessor.HttpContext.Session.Remove(Key);
        }

        public CurrentUser GetCurrentUser()
        {
            var str = httpContextAccessor.HttpContext.Session.GetString(SessionKeys.CurrentUserKey);
            var currentUser = JsonConvert.DeserializeObject<CurrentUser>(str);
            return currentUser;
        }
    }
}
