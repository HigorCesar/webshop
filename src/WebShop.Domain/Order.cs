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

        public Order(Customer customer, IEnumerable<Tuple<Article, int>> articles)
        {
            Id = DateTime.UtcNow.ToString("hhmmssfff");
            PlaceDate = DateTime.UtcNow;
            CustomerId = customer.Id;
            var enumerable = articles as Tuple<Article, int>[] ?? articles.ToArray();
            Articles = enumerable.Select(a => a.Item1.Name).ToList();
            SubTotal = enumerable.Sum(x => x.Item2 * x.Item1.Price);
            Vat = enumerable.Sum(x => x.Item2 * x.Item1.Vat);
            Total = enumerable.Sum(x => x.Item2 * x.Item1.TotalPrice());

        }
    }
}
