using System.Web.Mvc;
using WebShop.Domain;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IArticleRepository repository;

        public ShoppingCartController()
        {
            this.repository = DependencyResolver.Current.GetService<IArticleRepository>();
        }

        [HttpPost]
        public int AddItem(string id, ShoppingCart cart)
        {
            cart.AddItem(new ArticleViewModel(repository.GetArticle(id)));
            return cart.Articles.Count;

        }
        public int Count(ShoppingCart cart)
        {
            return cart.Articles.Count;
        }

        public ActionResult Index(string id, ShoppingCart cart)
        {

            return View(cart);
        }

        public ActionResult Checkout( ShoppingCart cart)
        {

            return View(cart);
        }
    }
}