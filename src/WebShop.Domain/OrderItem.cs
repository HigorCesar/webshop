using ServiceStack.DataAnnotations;

namespace WebShop.Domain
{
    public class OrderItem
    {
        [AutoIncrement]
        public int Id { get; set; }
        [StringLength(16)]
        public string OrderId { get; set; }
        public OrderItem(string orderId, string itemName)
        {
            OrderId = orderId;
            Name = itemName;
        }
        [StringLength(200)]
        public string Name { get; set; }
    }
}
