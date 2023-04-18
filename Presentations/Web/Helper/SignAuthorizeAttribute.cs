using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public class SignAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool _pass = false;
            Component.Web.Http.CookieHelper.SetLoginState();
            if (httpContext.Session["userName"] != null) _pass = true;
            return _pass;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Account/Login");
        }
    }
}