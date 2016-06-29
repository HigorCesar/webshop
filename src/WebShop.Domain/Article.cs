using System;
using System.Xml.Serialization;

namespace WebShop.Domain
{
    public class Article
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public string Image { get; set; }

        public Article()
        {

        }
        public Article(string id, string name, string description, decimal price, decimal vat, string image)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Vat = vat;
            Image = image;
        }

        public decimal TotalPrice()
        {
            return Vat + Price;
        }
    }
}
