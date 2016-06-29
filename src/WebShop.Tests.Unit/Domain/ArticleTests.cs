using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebShop.Domain;

namespace WebShop.Tests.Unit.Domain
{

    public class ArticleTests
    {
        [Test]
        public void Constructor()
        {
            var target = new Article("123", "I, Robot", "I, Robot...", 10, 2, "https://images-na.ssl-images-amazon.com/images/I/51+uc9PwVOL._AC_US160_.jpg");
            Assert.AreEqual(10, target.Price);
            Assert.AreEqual(2, target.Vat);
            Assert.AreEqual(12, target.TotalPrice);
            Assert.AreEqual("I, Robot", target.Name);
           
        }
    }
}
