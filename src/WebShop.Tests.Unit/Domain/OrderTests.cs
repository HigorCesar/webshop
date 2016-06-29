using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebShop.Domain;

namespace WebShop.Tests.Unit.Domain
{
    public class OrderTests
    {
        [Test]
        public void Constructor()
        {
            var customer = new Customer("Mr Higor", "Higor", "Ramos", "higor@mail.com", "abcd", "21", "20220-150",
              "Rio de janeiro");
            var articles = new List<Tuple<Article, int>>
            {
                new Tuple<Article, int>(new Article {Name = "a1", Price = 10, Vat = 1}, 1),
                new Tuple<Article, int>(new Article {Name = "a2", Price = 12, Vat = 2}, 2)
            };
            var target = new Order(customer, articles);

            Assert.AreEqual(5, target.Vat);
            Assert.AreEqual(34, target.SubTotal);
            Assert.AreEqual(39, target.Total);

        }
    }
}
