using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebShop.Domain;
using WebShop.Web.Models;

namespace WebShop.Tests.Unit.Web.Models
{
    public class ShoppingCartItemTests
    {
        [Test]
        public void Constructor()
        {
            var articleA = new ArticleViewModel(new Article { Name = "ArticleA", Id = "1", Price = 11, Vat = 1 });
            var target = new ShoppingCartItem(articleA);

            Assert.AreEqual(1, target.Quantity);
            Assert.AreEqual(11, target.Price());
            Assert.AreEqual(1, target.Vat());
            Assert.AreEqual(12, target.Total());
        }
        [Test]
        public void AddArticle()
        {
            var articleA = new ArticleViewModel(new Article { Name = "ArticleA", Id = "1", Price = 11, Vat = 1 });
            var target = new ShoppingCartItem(articleA);
            target.Add();
            target.Add();
            Assert.AreEqual(3, target.Quantity);
            Assert.AreEqual(33, target.Price());
            Assert.AreEqual(3, target.Vat());
            Assert.AreEqual(36, target.Total());
        }
    }
}
