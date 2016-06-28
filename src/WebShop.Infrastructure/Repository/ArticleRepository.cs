using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using WebShop.Domain;

namespace WebShop.Infrastructure.Repository
{
    [XmlRoot("articles")]
    public class ArticleList
    {
        [XmlElement("article")]
        public Article[] Articles { get; set; }
    }
    public class ArticleRepository : IArticleRepository
    {
        private readonly Article[] articles;
        public ArticleRepository(string articlesFile)
        {
            if (String.IsNullOrWhiteSpace(articlesFile))
                throw new ArgumentNullException(nameof(articlesFile));

            var deserializer = new XmlSerializer(typeof(ArticleList));
            var textReader = new StreamReader(articlesFile);
            var response = (ArticleList)deserializer.Deserialize(textReader);
            articles = response.Articles;
            textReader.Close();

        }
        public Paging<Article> GetArticles(int page, int pageSize)
        {
            return new Paging<Article>(articles.Skip((page - 1) * pageSize).Take(pageSize), articles.Count(), page);
        }

        public Article GetArticle(string id)
        {
            return articles.FirstOrDefault(a => a.Id == id);
        }
    }
}
