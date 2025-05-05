using ClothingECommerce.Data;
using ClothingECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClothingECommerce.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartAsync(int customerId)
        {
            return await _context.carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.CustomerID == customerId) ?? new Cart { CustomerID = customerId, Items = new List<CartItem>() };
        }

        public async Task AddItemAsync(int customerId, int productId, int quantity)
        {
            var cart = await GetCartAsync(customerId);
            if (cart.CartID == 0)
            {
                cart = new Cart { CustomerID = customerId };
                _context.carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductID == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Items.Add(new CartItem
                {
                    CartID = cart.CartID,
                    ProductID = productId,
                    Quantity = quantity
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(int customerId, int productId, int quantity)
        {
            var cart = await GetCartAsync(customerId);
            var item = cart.Items.FirstOrDefault(i => i.ProductID == productId);
            if (item != null)
            {
                if (quantity > 0)
                {
                    item.Quantity = quantity;
                }
                else
                {
                    cart.Items.Remove(item);
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveItemAsync(int customerId, int productId)
        {
            var cart = await GetCartAsync(customerId);
            var item = cart.Items.FirstOrDefault(i => i.ProductID == productId);
            if (item != null)
            {
                cart.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(int customerId)
        {
            var cart = await GetCartAsync(customerId);
            _context.cartItems.RemoveRange(cart.Items);
            await _context.SaveChangesAsync();
        }
    }
}