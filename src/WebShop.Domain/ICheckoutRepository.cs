using System.Threading;
using System.Threading.Tasks;

namespace WebShop.Domain
{
    public interface ICheckoutRepository
    {
        Task Checkout(Customer customer, Order order, CancellationToken cancellationToken);
    }
}
