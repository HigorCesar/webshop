using System;
using System.Xml.Serialization;

namespace WebShop.Domain
{
    public class Article
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public string Image { get; set; }

        public Article()
        {

        }
        public Article(string name, string description, decimal price, decimal vat, string image)
        {
            Name = name;
            Description = description;
            Price = price;
            Vat = vat;
            Image = image;
        }
    }
}
