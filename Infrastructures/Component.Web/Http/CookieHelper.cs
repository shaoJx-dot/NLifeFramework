using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Component.Web.Http
{
    public class CookieHelper
    {
        private static string cookieName = "User";
        public static void SetLoginState(string name = "")
        {
            if (string.IsNullOrEmpty(name)) name = cookieName;

            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                if (HttpContext.Current.Session["userName"] == null)
                {
                    HttpCookie cook = HttpContext.Current.Request.Cookies[name];
                    HttpContext.Current.Session["userName"] = cook.Values["userName"].ToString();
                    HttpContext.Current.Session["userDisplayName"] = cook.Values["userDisplayName"].ToString();
                    HttpContext.Current.Session["userID"] = cook.Values["userID"].ToString();
                }
            }
        }
        public static void AddCookie(string ID, string name, string displayName = "", int days = 1)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Values.Add("userID", ID);
            cookie.Values.Add("userName", name);
            cookie.Values.Add("userDisplayName", displayName);
            cookie.Expires = System.DateTime.Today.AddDays(days);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static void RemoveCookie()
        {
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                HttpCookie _cookie = HttpContext.Current.Request.Cookies[cookieName];
                _cookie.Expires = System.DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Cookies.Add(_cookie);
            }
        }
    }
}
