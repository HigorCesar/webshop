using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using WebShop.Domain;
using WebShop.Web.Controllers;
using WebShop.Web.Models;

namespace WebShop.Tests.Unit.Web.Controllers
{
    class ArticlesControllerTests
    {
        [Test]
        public void Index_when_there_is_no_article_return_view_with_empty_model()
        {
            var repository = new Mock<IArticleRepository>();

            repository.Setup(r => r.GetArticles(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new Paging<Article>(Enumerable.Empty<Article>(), 0, 1));

            var target = new ArticlesController(repository.Object);

            var result = (ViewResult)target.Index();
            var model = (ArticlePagingViewModel)result.Model;

            Assert.AreEqual(1, model.Page);
            Assert.AreEqual(0, model.Total);
            Assert.IsEmpty(model.Articles);
        }

        [Test]
        public void Index_with_articles()
        {
            var repository = new Mock<IArticleRepository>();

            var articles = new List<Article>
            {
               new Article("1", "article 1", "description", 11, 1, "image1") ,
               new Article("2", "article 2", "description", 11, 1, "image1")
            };
            repository.Setup(r => r.GetArticles(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new Paging<Article>(articles, 10, 1));

            var target = new ArticlesController(repository.Object);

            var result = (ViewResult)target.Index();
            var model = (ArticlePagingViewModel)result.Model;

            Assert.AreEqual(1, model.Page);
            Assert.AreEqual(10, model.Total);
            Assert.AreEqual(2, model.Articles.Count());
        }

        [Test]
        public void Articles()
        {
            var repository = new Mock<IArticleRepository>();

            var articles = new List<Article>
            {
                new Article("1", "article 1", "description", 11, 1, "image1"),
               new Article("2", "article 2", "description", 11, 1, "image1")
            };
            repository.Setup(r => r.GetArticles(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new Paging<Article>(articles, 10, 1));

            var target = new ArticlesController(repository.Object);

            var result = (PartialViewResult)target.Articles();
            var model = (IEnumerable<ArticleViewModel>)result.Model;

            Assert.AreEqual(2, model.Count());
        }

        [Test]
        public void Details()
        {
            var repository = new Mock<IArticleRepository>();
            var articleId = "1";
            repository
                .Setup(r => r.GetArticle(articleId))
                .Returns(new Article(articleId, "article 2", "description", 11, 1, "image1"));

            var target = new ArticlesController(repository.Object);

            var result = (ViewResult)target.Details(articleId);
            var model = (ArticleViewModel)result.Model;

            Assert.AreEqual(articleId, model.Id);
        }

        [Test]
        public void AllArticles()
        {
            var repository = new Mock<IArticleRepository>();
            var target = new ArticlesController(repository.Object);

            var result = (ViewResult)target.AllArticles();
            Assert.NotNull(result);
        }
    }
}
