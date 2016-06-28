using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.DataAnnotations;

namespace WebShop.Domain
{
    public class Order
    {
        [PrimaryKey]
        public string Id { get; set; }
        public DateTime PlaceDate { get; set; }
        public string CustomerId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Vat { get; set; }
        public decimal Total { get; set; }
        public List<string> Articles { get; set; }

        public Order(Customer customer, IEnumerable<Article> articles)
        {
            Id = DateTime.UtcNow.ToString("hhmmssfff");
            PlaceDate = DateTime.UtcNow;
            CustomerId = customer.Id;
            Articles = articles.Select(a => a.Name).ToList();
            SubTotal = articles.Sum(x => x.Price);
            Vat = articles.Sum(x => x.Vat);
            Total = articles.Sum(x => x.Price + x.Vat);

        }
    }
}
