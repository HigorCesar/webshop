using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WebShop.Domain;
using WebShop.Web.Models;

namespace WebShop.Tests.Unit.Web.Models
{
    public class ArticleViewModelTests
    {
        [Test]
        public void Constructor_thows_exception_when_article_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new ArticleViewModel(null));
        }


        [Test]
        public void Constructor_mapping()
        {
            var description =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam et augue semper, mattis velit in, convallis ligula. Curabitur enim ante, iaculis nec purus a, vulputate cursus libero. Mauris ut dapibus enim. Donec ut viverra tortor, at commodo libero. Suspendisse potenti. Sed pretium nibh ac justo molestie pellentesque. Nullam et dignissim nulla, et laoreet nisl. Sed placerat, odio a venenatis consectetur, lacus velit vestibulum tortor, in tristique libero diam non quam. Phasellus molestie dui eu auctor finibus.";
            var article = new Article(DateTime.UtcNow.ToString("hhmmssfff"), "Lorem ipsum", description, 20.00m, 2.00m, "image");

            var target = new ArticleViewModel(article);

            Assert.AreEqual(article.Name, target.Name);
            Assert.AreEqual($"{article.Price:C}", target.FormattedPrice);
            Assert.AreEqual($"{article.Description.Substring(0, 100)}...", target.ShortDescription);
            Assert.AreEqual(article.Description, target.Description);
            Assert.AreEqual(article.Image, target.Image);
        }
    }
}
