using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Domain;

namespace WebShop.Web.Models
{
    public class ArticlePagingViewModel
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int Total { get; set; }
        public IEnumerable<ArticleViewModel> Articles { get; set; }
        public ArticlePagingViewModel(Paging<Article> articles, int pageSize)
        {
            if (articles == null)
                throw new ArgumentNullException(nameof(articles));
            Page = articles.Page;
            Total = articles.Quantity;
            Pages = (int)Math.Ceiling((double)Total / pageSize);
            Articles = articles.Values.Select(v => new ArticleViewModel(v));
        }
    }
}