using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Domain;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private const int Pagesize = 10;
        private readonly IArticleRepository repository;

        public ArticlesController()
        {
            this.repository = DependencyResolver.Current.GetService<IArticleRepository>();
        }

        public ActionResult Index(int page = 1)
        {
            return View(new ArticlePagingViewModel(repository.GetArticles(page, Pagesize), Pagesize));
        }
        public ActionResult Articles(int page = 1)
        {
            return PartialView(repository.GetArticles(page, Pagesize).Values.Select(a => new ArticleViewModel(a)));
        }

    }
}