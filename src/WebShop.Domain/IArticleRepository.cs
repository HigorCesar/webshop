using System.Collections.Generic;
namespace WebShop.Domain
{
    public interface IArticleRepository
    {
        Paging<Article> GetArticles(int page, int pageSize);
        IEnumerable<Article> GetArticles();
        Article GetArticle(string id);
    }
}
