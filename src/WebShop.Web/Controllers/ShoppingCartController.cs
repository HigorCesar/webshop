using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebShop.Domain;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICheckoutRepository checkoutRepository;
        private readonly IArticleRepository articleRepository;

        public ShoppingCartController(ICheckoutRepository checkoutRepository, IArticleRepository articleRepository)
        {
            this.checkoutRepository = checkoutRepository;
            this.articleRepository = articleRepository;
        }

        [HttpPost]
        public int AddItem(string id, ShoppingCart cart)
        {
            cart.AddItem(new ArticleViewModel(articleRepository.GetArticle(id)));
            return cart.Count();

        }
        public int Count(ShoppingCart cart)
        {
            return cart.Count();
        }

        public ActionResult Index(string id, ShoppingCart cart)
        {

            return View(cart);
        }

        public ActionResult Checkout(ShoppingCart cart)
        {
            return View(cart);
        }

        [HttpPost]
        public async Task<ActionResult> Checkout(CustomerViewModel customer, ShoppingCart cart)
        {
            var domainCustomer = new Customer(customer.Title, customer.FirstName, customer.LastName, customer.Email,
                customer.Address, customer.HouseNumber, customer.ZipCode, customer.City);
            var articlesWithQuantity = cart.Items.Select(a => new Tuple<Article, int>(articleRepository.GetArticle(a.Value.Article.Id), a.Value.Quantity));
            var order = new Order(domainCustomer, articlesWithQuantity);
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(1)))
            {
                await checkoutRepository.Checkout(domainCustomer, order, cts.Token);
            }

            cart.Clear();

            return RedirectToAction("ThankYou", customer);
        }

        public ActionResult ThankYou(CustomerViewModel customer)
        {
            return View(customer);
        }

    }
}