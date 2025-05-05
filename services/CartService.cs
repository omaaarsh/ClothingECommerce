using ClothingECommerce.Data;
using ClothingECommerce.Models;
using ClothingECommerce.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ClothingECommerce.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly AppDbContext _context;

        public CartService(ICartRepository cartRepository, AppDbContext context)
        {
            _cartRepository = cartRepository;
            _context = context;
        }

        public async Task<Cart> GetCartAsync(int customerId)
        {
            return await _cartRepository.GetCartAsync(customerId);
        }

        public async Task AddItemAsync(int customerId, int productId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0.");

            var product = await _context.products.FindAsync(productId);
            if (product == null)
                throw new ArgumentException("Product does not exist.");

            if (product.Quantity < quantity)
                throw new ArgumentException("Insufficient stock available.");

            await _cartRepository.AddItemAsync(customerId, productId, quantity);
        }

        public async Task UpdateItemAsync(int customerId, int productId, int quantity)
        {
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");

            var product = await _context.products.FindAsync(productId);
            if (product == null)
                throw new ArgumentException("Product does not exist.");

            if (quantity > 0 && product.Quantity < quantity)
                throw new ArgumentException("Insufficient stock available.");

            await _cartRepository.UpdateItemAsync(customerId, productId, quantity);
        }

        public async Task RemoveItemAsync(int customerId, int productId)
        {
            await _cartRepository.RemoveItemAsync(customerId, productId);
        }

        public async Task ClearCartAsync(int customerId)
        {
            await _cartRepository.ClearCartAsync(customerId);
        }
    }
}