using System;
using System.IO;

namespace WebShop.Tests.Unit
{
    internal class ResourceHelper
    {
        private readonly string article1File;
        private readonly string article2File;
        private readonly string article22File;
        public ResourceHelper()
        {
            article1File = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/article_1.xml");
            article2File = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/articles_2.xml");
            article22File = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/articles_22.xml");
        }
        public string GetArticle2File()
        {
            return article2File;
        }
        public string GetArticle22File()
        {
            return article22File;
        }
        public string GetArticle1File()
        {
            return article1File;
        }
    }
}
