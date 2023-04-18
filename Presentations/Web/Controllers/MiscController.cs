using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class MiscController : Controller
    {
        public MiscController()
        {
            ViewBag.MenuClassDictionary = Application.Domain.NavigationService.GetCurrent(4);
        }
        public ActionResult Index()
        {
            return View();
        }
	}
}