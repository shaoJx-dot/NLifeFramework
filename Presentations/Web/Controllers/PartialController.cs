using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [ChildActionOnly]
    public class PartialController : Controller
    {
        public PartialController()
        {
            
        }
        //
        // GET: /Partial/
        public ActionResult _LoginRightPartial()
        {
            return PartialView("_LoginRightPartial");
        }
        public ActionResult _CountPartial()
        {
            return PartialView("_CountPartial");
        }

        public ActionResult _AdvertPartial()
        {
            return PartialView("_AdvertPartial");
        }
        public ActionResult _LinkPartial()
        {
            var linkObj = new List<string>()
            {
                "开源中国", "零时差微社区", "博客园", "CSDN", "天涯论坛", "人民网"
            };
            return PartialView("_LinkPartial", linkObj);
        }
	}
}