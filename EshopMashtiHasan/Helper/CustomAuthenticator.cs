﻿using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Security.BussinessServiceContract.Services;
using Security.Domain.DTO.User;

namespace EshopMashtiHasan.Helper
{
    public class CustomAuthenticator : ActionFilterAttribute
    {
        private readonly IAuthHelper _authHelper;
        private readonly IAccountBussiness _acountApp;


        public CustomAuthenticator(IAuthHelper authHelper, IAccountBussiness _acountApp)
        {
            _authHelper = authHelper;
            this._acountApp = _acountApp;


        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var username = context.HttpContext.User.Identity.Name;
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.HttpContext.Response.Redirect("/Account/Login");
            }

            var ControllerName = context.RouteData.Values["Controller"].ToString();
            var ActionName = context.RouteData.Values["Action"].ToString();

            var userInfo = _authHelper.GetCurrentUserInfo();

            //Checking SecurityInfo
            if (string.IsNullOrEmpty(userInfo.UserName))
            {
                context.HttpContext.Response.Redirect("/Account/Login");
            }
            
            CheckPermission permission = new CheckPermission
            {
                UserName = username
                ,
                Controller = ControllerName
                ,
                ActionName = ActionName
            };
            if (!_acountApp.CheckIfUserHasaccess(permission))
            {
                context.HttpContext.Response.Redirect("/Account/Login");
            }

            base.OnActionExecuting(context);
        }
    }
}