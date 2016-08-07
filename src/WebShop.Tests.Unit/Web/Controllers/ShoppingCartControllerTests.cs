using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using WebShop.Domain;
using WebShop.Web.Controllers;
using WebShop.Web.Models;

namespace WebShop.Tests.Unit.Web.Controllers
{
    public class ShoppingCartControllerTests
    {
        [Test]
        public void Index()
        {
            var checkoutRepository = new Mock<ICheckoutRepository>();
            var articleRepository = new Mock<IArticleRepository>();

            var target = new ShoppingCartController(checkoutRepository.Object, articleRepository.Object);

            var result = (ViewResult)target.Index("1", null);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Checkout()
        {
            var checkoutRepository = new Mock<ICheckoutRepository>();
            var articleRepository = new Mock<IArticleRepository>();

            var target = new ShoppingCartController(checkoutRepository.Object, articleRepository.Object);

            var result = (ViewResult)target.Checkout(new ShoppingCart());

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model as CheckoutViewModel);
        }

        [Test]
        public void ThankYou()
        {
            var checkoutRepository = new Mock<ICheckoutRepository>();
            var articleRepository = new Mock<IArticleRepository>();

            var target = new ShoppingCartController(checkoutRepository.Object, articleRepository.Object);

            var result = (ViewResult)target.ThankYou(new ThankYouViewModel("Higor"));
            var model = result.Model as ThankYouViewModel;
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual("Higor", model.Customer);

        }

        [Test]
        public async Task Checkout_post()
        {
            var checkoutRepository = new Mock<ICheckoutRepository>();

            checkoutRepository
                .Setup(x => x.Checkout(It.IsAny<Customer>(), It.IsAny<Order>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(0));
            var articleRepository = new Mock<IArticleRepository>();
            articleRepository.Setup(r => r.GetArticle(It.IsAny<string>()))
                .Returns(new Article { Id = "1", Name = "Article B" });

            var target = new ShoppingCartController(checkoutRepository.Object, articleRepository.Object);

            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItem(new ArticleViewModel(new Article { Id = "1", Name = "Article B" }));

            var result = (RedirectToRouteResult)(await target.Checkout(new CheckoutViewModel(), shoppingCart));
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.RouteName);

        }
    }
}
