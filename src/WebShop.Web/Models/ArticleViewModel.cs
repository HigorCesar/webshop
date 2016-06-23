using System;
using System.Linq;
using WebShop.Domain;

namespace WebShop.Web.Models
{
    public class ArticleViewModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Price { get; set; }
        public ArticleViewModel(Article article)
        {
            if (article == null)
                throw new ArgumentNullException();

            Name = article.Name;
            Description = article.Description;
            if (article.Description.Length > 100)
                ShortDescription = $"{article.Description.Substring(0, 100)}...";
            else
                ShortDescription = article.Description;
            Price = $"{article.Price:C}";
            Image = article.Image;
        }
    }
}