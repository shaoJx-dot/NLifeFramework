using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CaseController : Controller
    {
        public CaseController()
        {
            ViewBag.MenuClassDictionary = Application.Domain.NavigationService.GetCurrent(2);
        }
        public ActionResult Index()
        {
            return View();
        }
	}
}