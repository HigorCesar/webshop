using System;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using WebShop.Infrastructure;

namespace WebShop.Tests.Unit.Infrastructure.Repository
{
    public class ArticleRepositoryTests
    {
        [Test]
        public void GetArticles_null_path_throws_exception()
        {
            Assert.Throws<ArgumentNullException>(() => new ArticleRepository(null));
        }

        [Test]
        public void GetArticles_one_article_mapping()
        {
            var repo = new ArticleRepository("./resources/article_1.xml");
            var target = repo.GetArticles(1, 10).Values.First();

            Assert.AreEqual("Domain-Driven Design: Tackling Complexity in the Heart of Software", target.Name);
            Assert.AreEqual("If you have even been involved in a software project...", target.Description);
            Assert.AreEqual(30.00, target.Price);
            Assert.AreEqual(2.00, target.Vat);
            Assert.AreEqual("https://images-na.ssl-images-amazon.com/images/I/515FeOFonQL._SX378_BO1,204,203,200_.jpg", target.Image);

        }

        [Test]
        public void GetArticles_only_2_articles()
        {
            var target = new ArticleRepository("./resources/articles_2.xml");
            Assert.AreEqual(2, target.GetArticles(1, 10).Quantity);
        }

        [Test]
        public void GetArticles_22_articles()
        {
            var target = new ArticleRepository("./resources/articles_22.xml");
            var result = target.GetArticles(3, 10);
            Assert.AreEqual(22, result.Quantity);
            Assert.AreEqual(2, result.Values.Count());
            Assert.AreEqual(3, result.Page);
        }

        [Test]
        public void GetArticles_non_valid_page_returns_empty()
        {
            var target = new ArticleRepository("./resources/articles_22.xml");
            var result = target.GetArticles(21, 10);
            Assert.AreEqual(22, result.Quantity);
            Assert.AreEqual(0, result.Values.Count());
            Assert.AreEqual(21, result.Page);
        }
        [Test]
        public void GetArticle_null_when_do_not_find()
        {
            var target = new ArticleRepository("./resources/articles_2.xml");
            Assert.IsNull(target.GetArticle("99"));
        }
        [Test]
        public void GetArticle()
        {
            var target = new ArticleRepository("./resources/articles_2.xml");
            var article = target.GetArticle("1");
            Assert.AreEqual("1", article.Id);
        }
    }
}
