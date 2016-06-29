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
        public string FormattedVat { get; set; }
        public string FormattedTotal { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Vat { get; set; }
        public ArticleViewModel(Article article)
        {
            if (article == null)
                throw new ArgumentNullException();

            Id = article.Id;
            Name = article.Name;
            Description = article.Description;
            ShortDescription = article.Description.Length > 100 ? $"{article.Description.Substring(0, 100)}..." : article.Description;
            Price = article.Price;
            Vat = article.Vat;
            TotalPrice = Price + Vat;
            Image = article.Image;

            FormattedPrice = $"{article.Price:C}";
            FormattedTotal = $"{article.TotalPrice:C}";
            FormattedVat = $"{article.Vat:C}";
        }
    }
}