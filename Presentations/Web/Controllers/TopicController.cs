using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Domain;

namespace Web.Controllers
{
    public class TopicController : Controller
    {
        private readonly TopicService _topicService;
        private readonly TopicCommentService _topicCommentService;
        public TopicController(TopicService _topicService, TopicCommentService topicCommentService)
        {
            ViewBag.MenuClassDictionary = Application.Domain.NavigationService.GetCurrent(0);
            this._topicService = _topicService;
            this._topicCommentService = topicCommentService;

        }
        // GET: /Topic/
        public ActionResult Index(string id, string page)
        {
            var topic = _topicService.Find(int.Parse(id));

            //每页显示的数据条数
            int pageDataCount = 10;
            int pageNumber = 1;

            if (!string.IsNullOrEmpty(page))
            {
                pageNumber = int.Parse(page);
            }

            //数据总量
            int dataCount = _topicCommentService.GetRecord(int.Parse(id));

            //总页数
            int pageCount = (int)Math.Ceiling(dataCount / (pageDataCount * 1.0));
            int startLine = (pageNumber - 1) * pageDataCount + 1;
            int endLine = startLine + pageDataCount - 1;

            var list = _topicCommentService.GetPage(int.Parse(id), startLine, endLine);
            //var list = _topicService.FindALL();

            ViewData["TopicData"] = topic;
            ViewData["DataCount"] = dataCount;
            ViewData["PageDataCount"] = pageDataCount;
            ViewData["TopicCommentList"] = list;
            ViewData["TopicID"] = id;
            ViewData["Page"] = page;

            return View();
        }

	}
}