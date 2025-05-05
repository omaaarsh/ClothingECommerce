using ClothingECommerce.Data;
using ClothingECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingECommerce.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(Order order)
        {
            _context.orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrdersAsync(int customerId)
        {
            return await _context.orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.CustomerID == customerId)
                .ToListAsync();
        }
    }
}