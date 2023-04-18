using Application.Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsersService _UsersService;
        private readonly CategoryService _categoryService;
        private readonly TopicService _topicService;
        public HomeController(UsersService _UsersService, CategoryService _categoryService, TopicService _topicService)
        {
            ViewBag.MenuClassDictionary = Application.Domain.NavigationService.GetCurrent(0);
            this._UsersService = _UsersService;
            this._categoryService = _categoryService;
            this._topicService = _topicService;
        }
        public ActionResult Index(string id)
        {
            //var value = RouteData.Values["id"];
            //数据总量
            int dataCount = _topicService.GetRecord();
            //每页显示的数据条数
            int pageDataCount = 10;
            int pageNumber = 1;

            if (!string.IsNullOrEmpty(id))
            {
                pageNumber = int.Parse(id);
            }

            //总页数
            int pageCount = (int)Math.Ceiling(dataCount / (pageDataCount * 1.0));
            int startLine = (pageNumber - 1) * pageDataCount + 1;
            int endLine = startLine + pageDataCount - 1;

            var list = _topicService.GetPage(startLine, endLine);
            //var list = _topicService.FindALL();
            ViewData["DataCount"] = dataCount;
            ViewData["PageDataCount"] = pageDataCount;
            ViewData["TopicList"] = list;
            return View();
        }

        public ActionResult Category(string enName, string id)
        {
            enName = "dev" + enName;
            Category category = _categoryService.Find(enName);
            //数据总量
            int dataCount = _categoryService.GetRecord(enName);
            //每页显示的数据条数
            int pageDataCount = 10;
            int pageNumber = 1;

            if (!string.IsNullOrEmpty(id))
            {
                pageNumber = int.Parse(id);
            }

            //总页数
            int pageCount = (int)Math.Ceiling(dataCount / (pageDataCount * 1.0));
            int startLine = (pageNumber - 1) * pageDataCount + 1;
            int endLine = startLine + pageDataCount - 1;

            var list = _categoryService.GetPage(enName, startLine, endLine);

            ViewData["Category"] = category;
            ViewData["DataCount"] = dataCount;
            ViewData["PageDataCount"] = pageDataCount;
            ViewData["TopicList"] = list;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}