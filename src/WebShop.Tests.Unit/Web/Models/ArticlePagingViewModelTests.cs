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
    public class ArticlePagingViewModelTests
    {
        private Article BuildFakeArticle()
        {
            return new Article("name", "description", 0, 0, "image");
        }
        [Test]
        public void Constructor_thows_exception_when_articles_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new ArticlePagingViewModel(null, 0));
        }
        [Test]
        public void Pages_equals_2_when_there_are_3_articles_and_pagesize_equals_to_2()
        {
            var articles = new List<Article>() { BuildFakeArticle(), BuildFakeArticle(), BuildFakeArticle() };
            var pagingArticle = new Paging<Article>(articles, 3, 1);

            var target = new ArticlePagingViewModel(pagingArticle, 2);

            Assert.AreEqual(2, target.Pages);
        }
        [Test]
        public void Constructor_mapping()
        {
            var articles = new List<Article>() { BuildFakeArticle(), BuildFakeArticle(), BuildFakeArticle() };
            var pagingArticle = new Paging<Article>(articles, 3, 1);

            var target = new ArticlePagingViewModel(pagingArticle, 2);

            Assert.AreEqual(pagingArticle.Page, target.Page);
            Assert.AreEqual(pagingArticle.Quantity, target.Total);
            Assert.AreEqual(3, target.Articles.Count());
        }
    }
}
