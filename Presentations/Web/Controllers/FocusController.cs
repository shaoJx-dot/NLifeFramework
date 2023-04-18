using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class FocusController : Controller
    {
        public FocusController()
        {
            ViewBag.MenuClassDictionary = Application.Domain.NavigationService.GetCurrent(1);
        }
        public ActionResult Index()
        {
            return View();
        }
	}
}