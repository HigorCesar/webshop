using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Moq;
using NUnit.Framework;
using WebShop.Domain;
using WebShop.Web.Controllers;

namespace WebShop.Tests.Unit.Web.Controllers
{
    public class ArticlesRestControllerTests
    {
        [Test]
        public void GetById_404()
        {
            var repository = new Mock<IArticleRepository>();

            repository
                .Setup(r => r.GetArticle(It.IsAny<string>()))
                .Returns((Article)null);

            var target = new ArticlesRestController(repository.Object) { Request = new HttpRequestMessage() };
            target.Request.SetRequestContext(new HttpRequestContext());
            var result = target.Get("9").ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Test]
        public void GetById()
        {
            var repository = new Mock<IArticleRepository>();
            var articleId = "1";
            repository
                .Setup(r => r.GetArticle(It.IsAny<string>()))
                .Returns(new Article { Id = articleId, Name = "Article 1" });

            var target = new ArticlesRestController(repository.Object)
            {
                ControllerContext = new HttpControllerContext { Configuration = new HttpConfiguration() },
                Request = new HttpRequestMessage()
            };
            var result = target.Get(articleId).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
        [Test]
        public void Get()
        {
            var repository = new Mock<IArticleRepository>();
            repository
                .Setup(r => r.GetArticles())
                .Returns(new List<Article>
                {
                    new Article { Id = "1", Name = "Article 1" },
                    new Article { Id = "2", Name = "Article 2" }
                });

            var target = new ArticlesRestController(repository.Object)
            {
                ControllerContext = new HttpControllerContext { Configuration = new HttpConfiguration() },
                Request = new HttpRequestMessage()
            };
            var result = target.Get().ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
