using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebShop.Domain
{
    public interface ICheckoutRepository
    {
        Task Checkout(Customer customer, Order order, CancellationToken cancellationToken);
        Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken);
    }
}
