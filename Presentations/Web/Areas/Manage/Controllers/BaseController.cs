using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Manage.Controllers
{
    public class BaseController : Controller
    {
        protected string hostUrl = "";
        /// <summary>
        /// Action执行前判断
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // url
            this.hostUrl = "http://" + this.Request.Url.Host;
            this.hostUrl += this.Request.Url.Port.ToString() == "80" ? "" : ":" + this.Request.Url.Port;
            this.hostUrl += this.Request.ApplicationPath;

            if (!this.CheckLogin())// 判断是否登录
            {
                filterContext.Result = RedirectToRoute("Default", new { Controller = "Login", Action = "Index" });
            }

            base.OnActionExecuting(filterContext);

        }


        /// <summary>
        /// 判断是否登录
        /// </summary>
        protected bool CheckLogin()
        {
            if (this.Session["userinfo"] == null)
            {
                return false;
            }
            return true;
        }

    }
}