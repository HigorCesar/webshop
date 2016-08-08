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
            var checkoutViewModel = new CheckoutViewModel(cart);
            return View(checkoutViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Checkout(CheckoutViewModel viewModel, ShoppingCart cart)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var domainCustomer = new Customer(viewModel.Title, viewModel.FirstName, viewModel.LastName, viewModel.Email,
                viewModel.Address, viewModel.HouseNumber, viewModel.ZipCode, viewModel.City);
            var articlesWithQuantity = cart.Items.Values.Select(i => new Tuple<Article,int>(articleRepository.GetArticle(i.Article.Id), i.Quantity));
            var order = new Order(domainCustomer, articlesWithQuantity);
            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(1)))
            {
                await checkoutRepository.Checkout(domainCustomer, order, cts.Token);
            }

            cart.Clear();

            return RedirectToAction("ThankYou", new ThankYouViewModel(viewModel.Title));
        }

        public ActionResult ThankYou(ThankYouViewModel model)
        {
            return View(model);
        }

    }
}