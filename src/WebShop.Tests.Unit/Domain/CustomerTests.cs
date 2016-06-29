using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebShop.Domain;

namespace WebShop.Tests.Unit.Domain
{
    public class CustomerTests
    {
        [Test]
        public void Constructor()
        {
            var target = new Customer("Mr Higor", "Higor", "Ramos", "higor@mail.com", "abcd", "21", "20220-150",
                "Rio de janeiro");

            Assert.AreEqual("Mr Higor", target.Title);
            Assert.AreEqual("Higor", target.FirstName);
            Assert.AreEqual("Ramos", target.LastName);
            Assert.AreEqual("higor@mail.com", target.Email);
            Assert.AreEqual("20220-150", target.ZipCode);
            Assert.AreEqual("21", target.HouseNumber);
            Assert.AreEqual("Rio de janeiro", target.City);
        }
    }
}
