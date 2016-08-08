using System.Linq;
using System.Web.Http;
using WebShop.Domain;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class ArticlesRestController : ApiController
    {
        private readonly IArticleRepository articleRepository;

        public ArticlesRestController(IArticleRepository repository)
        {
            articleRepository = repository;
        }
        [Route("api/articles")]
        public IHttpActionResult Get()
        {
            return Ok(articleRepository.GetArticles().Select(a => new ArticleViewModel(a)));
        }
        [Route("api/articles/{id}")]
        public IHttpActionResult Get(string id)
        {
            var article = articleRepository.GetArticle(id);

            if (article == null)
                return NotFound();

            return Ok(new ArticleViewModel(article));

        }
    }
}
