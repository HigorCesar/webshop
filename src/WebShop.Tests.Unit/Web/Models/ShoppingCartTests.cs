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
    public class ShoppingCartTests
    {
        [Test]
        public void Constructor()
        {
            var target = new ShoppingCart();
            Assert.IsEmpty(target.Items);
            Assert.AreEqual(0, target.Total);
            Assert.AreEqual(0, target.Vat);
            Assert.AreEqual(0, target.Subtotal);
            Assert.AreEqual(0, target.Count());
        }

        [Test]
        public void AddItem()
        {
            var target = new ShoppingCart();
            target.AddItem(new ArticleViewModel(new Article { Name = "Article A", Id = "1" }));
            Assert.AreEqual(1, target.Count());
        }

        [Test]
        public void AddItem_when_already_exist_dont_duplicate()
        {
            var target = new ShoppingCart();
            target.AddItem(new ArticleViewModel(new Article { Name = "Article A", Id = "1" }));
            target.AddItem(new ArticleViewModel(new Article { Name = "Article A", Id = "1" }));
            Assert.AreEqual(2, target.Count());
            Assert.AreEqual(1, target.Items.Count);
        }

        [Test]
        public void Clear_delete_all_items()
        {
            var target = new ShoppingCart();
            target.AddItem(new ArticleViewModel(new Article { Name = "Article A", Id = "1" }));
            Assert.AreEqual(1, target.Count());
            target.Clear();
            Assert.IsEmpty(target.Items);
        }

        [Test]
        public void Price_vat_total()
        {
            var target = new ShoppingCart();
            target.AddItem(new ArticleViewModel(new Article { Name = "Article A", Id = "1", Price = 20, Vat = 2 }));
            target.AddItem(new ArticleViewModel(new Article { Name = "Article A", Id = "2", Price = 30, Vat = 3 }));
            Assert.AreEqual(5, target.Vat);
            Assert.AreEqual(50, target.Subtotal);
            Assert.AreEqual(55, target.Total);
        }

    }
}
