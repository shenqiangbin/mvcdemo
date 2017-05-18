using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppPage.Service;
using PagedList;
using WebAppPage.Models;

namespace WebAppPage.Controllers
{
    public class HomeController : Controller
    {
        private ArticleService articleService;

        public HomeController()
        {
            this.articleService = new ArticleService();
        }

        public ActionResult Index(int pageIndex = 1)
        {
            int pageSize = 2;
            var response = articleService.GetPaged(pageSize, pageIndex);

            var pageList = new StaticPagedList<Article>(response.List, pageIndex, pageSize, response.TotalCount);
            return View(pageList);
        }

        public ActionResult AjaxIndex(int pageIndex = 1)
        {
            int pageSize = 2;
            var response = articleService.GetPaged(pageSize, pageIndex);

            var pageList = new StaticPagedList<Article>(response.List, pageIndex, pageSize, response.TotalCount);

            if (Request.IsAjaxRequest())
                return PartialView("_ArticleList", pageList);

            return View(pageList);
        }
    }
}