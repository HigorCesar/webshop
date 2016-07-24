using ServiceStack.DataAnnotations;

namespace WebShop.Domain
{
    public class Article
    {
        public string Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        [StringLength(200)]
        public string Image { get; set; }
        public decimal TotalPrice => Vat + Price;
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
    }
}
