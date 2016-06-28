using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebShop.Domain;

namespace WebShop.Tests.Unit.Domain
{
    public class PagingTests
    {
        [Test]
        public void Constructor_thows_exception_when_articles_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new Paging<Article>(null, 0, 0));
        }

        [Test]
        public void Constructor_mapping()
        {

            var articles = new List<Article> { new Article(DateTime.UtcNow.ToString("hhmmssfff"), "name", "description", 10, 1, "image") };
            var target = new Paging<Article>(articles, 100, 1);

            Assert.AreEqual(100, target.Quantity);
            Assert.AreEqual(1, target.Page);
            Assert.AreEqual(1, target.Values.Count());
        }
    }
}
