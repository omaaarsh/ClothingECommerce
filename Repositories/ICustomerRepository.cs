using System.Threading.Tasks;
using ClothingECommerce.Models;

namespace ClothingECommerce.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByEmailAsync(string email);
        Task AddAsync(Customer customer);
    }
}