using System.Threading.Tasks;

namespace WebShop.Domain
{
    public interface ICustomerRepository
    {
        Task Save(Customer customer);
    }
}
