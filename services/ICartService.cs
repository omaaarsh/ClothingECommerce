using ClothingECommerce.Models;
using System.Threading.Tasks;

namespace ClothingECommerce.Services
{
    public interface ICartService
    {
        Task<Cart> GetCartAsync(int customerId);
        Task AddItemAsync(int customerId, int productId, int quantity);
        Task UpdateItemAsync(int customerId, int productId, int quantity);
        Task RemoveItemAsync(int customerId, int productId);
        Task ClearCartAsync(int customerId);
    }
}