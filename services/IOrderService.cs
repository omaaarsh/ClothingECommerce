using ClothingECommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingECommerce.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int customerId);
        Task<List<Order>> GetOrdersAsync(int customerId);
    }
}