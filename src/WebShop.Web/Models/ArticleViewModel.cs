using System;
using System.Linq;
using WebShop.Domain;

namespace WebShop.Web.Models
{
    public class ArticleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string FormattedPrice { get; set; }
        public decimal Price { get; set; }
        public ArticleViewModel(Article article)
        {
            if (article == null)
                throw new ArgumentNullException();

            Id = article.Id;
            Name = article.Name;
            Description = article.Description;
            if (article.Description.Length > 100)
                ShortDescription = $"{article.Description.Substring(0, 100)}...";
            else
                ShortDescription = article.Description;
            FormattedPrice = $"{article.Price:C}";
            Price = article.Price;
            Image = article.Image;
        }
    }
}