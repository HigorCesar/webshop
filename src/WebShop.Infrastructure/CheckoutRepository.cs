using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using WebShop.Domain;

namespace WebShop.Infrastructure
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly IDbConnectionFactory connectionFactory;

        public CheckoutRepository(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task Checkout(Customer customer, Order order, CancellationToken cancellationToken)
        {
            using (var db = connectionFactory.Open())
            using (var dbTrans = db.OpenTransaction())
            {
                await db.SaveAsync(customer, false, cancellationToken);
                await db.SaveAsync(order, false, cancellationToken);
                dbTrans.Commit();
            }

        }

        public async Task<IEnumerable<Order>> GetOrders(CancellationToken cancellationToken)
        {
            using (var db = connectionFactory.Open())
            {
                return await db.SelectAsync<Order>(cancellationToken);
            }
        }
    }
}
