using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.DataAnnotations;

namespace WebShop.Domain
{
    public class Order
    {
        [PrimaryKey]
        public string Id { get; private set; }
        public DateTime PlaceDate { get; private set; }
        public int CustomerId { get; private set; }
        public decimal SubTotal { get; private set; }
        public decimal Vat { get; private set; }
        public decimal Total { get; private set; }
        [Reference]
        public List<OrderItem> Articles { get; set; }

        public Order()
        {

        }
        public Order(Customer customer, IEnumerable<Tuple<Article, int>> articles)
        {
            Id = Guid.NewGuid().ToString("N");
            PlaceDate = DateTime.UtcNow;
            CustomerId = customer.Id;
            var enumerable = articles as Tuple<Article, int>[] ?? articles.ToArray();
            Articles = enumerable.Select(a => new OrderItem(Id,a.Item1.Name)).ToList();
            SubTotal = enumerable.Sum(x => x.Item2 * x.Item1.Price);
            Vat = enumerable.Sum(x => x.Item2 * x.Item1.Vat);
            Total = enumerable.Sum(x => x.Item2 * x.Item1.TotalPrice);

        }
    }
}
