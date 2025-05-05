using ClothingECommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingECommerce.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
        Task<List<Order>> GetOrdersAsync(int customerId);
    }
}