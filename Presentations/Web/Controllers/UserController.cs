using Application.Domain;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [SignAuthorizeAttribute]
    public class UserController : Controller
    {
        private readonly UsersService _UsersService;
        private readonly CategoryService _categoryService;
        private readonly TopicService _topicService;

        public UserController(UsersService _UsersService, CategoryService _categoryService, TopicService _topicService)
        {
            ViewBag.MenuClassDictionary = Application.Domain.NavigationService.GetCurrent(-1);
            this._UsersService = _UsersService;
            this._categoryService = _categoryService;
            this._topicService = _topicService;
        }
        //
        // GET: /User/
        public ActionResult Index(string id)
        {
            int userID = -1;
            if (System.Web.HttpContext.Current.Session["userID"] != null)
            {
                userID = Convert.ToInt32(System.Web.HttpContext.Current.Session["userID"]);
            }

            var list = _topicService.FindByUser(userID);
            ViewData["Topics"] = list;
            
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }
        public ActionResult Avatar()
        {
            return View();
        }

        public ActionResult Passwd()
        {
            return View();
        }

        public ActionResult Favorites()
        {
            return View();
        }

        public ActionResult Follow()
        {
            return View();
        }

        public ActionResult Message()
        {
            return View();
        }

        public ActionResult Add()
        {
            int userID = -1;
            if (System.Web.HttpContext.Current.Session["userID"] != null)
            {
                userID = Convert.ToInt32(System.Web.HttpContext.Current.Session["userID"]);
            }

            var list = _categoryService.Find(userID);
            ViewData["Categories"] = new SelectList(list, "ID", "Name");
            
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(FormCollection fc)
        {
            var Contents = fc["editor"];
            var topic = new Topic();
            try
            {
                TryUpdateModel(topic, fc);
            }
            catch (Exception)
            {
                throw;
            }

            topic.Body = Contents;
            topic.CreateTime = DateTime.Now;
            topic.ReplyCount = 0;
            topic.UserID = Convert.ToInt32( System.Web.HttpContext.Current.Session["userID"] );
            topic.UserName = System.Web.HttpContext.Current.Session["userDisplayName"].ToString();
            _topicService.Insert(topic);
            if (topic.ID > 0)
            {
                return RedirectToAction("Index", "User");
            }
            return View(topic);
        }
    }
}