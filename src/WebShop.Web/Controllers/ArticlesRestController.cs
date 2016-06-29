using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebShop.Domain;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class ArticlesRestController : ApiController
    {
        private readonly IArticleRepository articleRepository;

        public ArticlesRestController()
        {
            this.articleRepository = DependencyResolver.Current.GetService<IArticleRepository>();
        }
        [System.Web.Http.Route("api/articles")]
        public IHttpActionResult Get()
        {
            return Ok(articleRepository.GetArticles().Select(a => new ArticleViewModel(a)));
        }
        [System.Web.Http.Route("api/articles/{id}")]
        public IHttpActionResult Get(string id)
        {
            var article = articleRepository.GetArticle(id);

            if (article == null)
                return NotFound();

            return Ok(new ArticleViewModel(article));

        }
    }
}
