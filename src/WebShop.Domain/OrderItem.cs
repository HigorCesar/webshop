using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace WebShop.Domain
{
    public class OrderItem
    {
        public OrderItem()
        {

        }

        [AutoIncrement]
        public int Id { get; set; }
        public string OrderId { get; set; }
        public OrderItem(string orderId, string itemName)
        {
            OrderId = orderId;
            Name = itemName;
        }
        public string Name { get; set; }
    }
}
