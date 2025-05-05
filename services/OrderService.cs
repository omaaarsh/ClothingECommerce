using ClothingECommerce.Data;
using ClothingECommerce.Models;
using ClothingECommerce.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ClothingECommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartService _cartService;
        private readonly AppDbContext _context;

        public OrderService(IOrderRepository orderRepository, ICartService cartService, AppDbContext context)
        {
            _orderRepository = orderRepository;
            _cartService = cartService;
            _context = context;
        }

        public async Task CreateOrderAsync(int customerId)
        {
            var cart = await _cartService.GetCartAsync(customerId);
            if (!cart.Items.Any())
                throw new InvalidOperationException("Cart is empty.");

            var order = new Order
            {
                CustomerID = customerId,
                OrderDate = DateTime.UtcNow,
                Status = "Pending",
                Items = new List<OrderItem>(),
                TotalAmount = 0
            };

            foreach (var item in cart.Items)
            {
                var product = await _context.products.FindAsync(item.ProductID);
                if (product == null)
                    throw new ArgumentException($"Product with ID {item.ProductID} does not exist.");

                if (product.Quantity < item.Quantity)
                    throw new ArgumentException($"Insufficient stock for product {product.Name}.");

                var orderItem = new OrderItem
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };

                order.Items.Add(orderItem);
                order.TotalAmount += item.Quantity * product.Price;
                product.Quantity -= item.Quantity; // Update stock
            }

            await _orderRepository.CreateOrderAsync(order);
            await _cartService.ClearCartAsync(customerId); // Clear cart after order creation
        }

        public async Task<List<Order>> GetOrdersAsync(int customerId)
        {
            return await _orderRepository.GetOrdersAsync(customerId);
        }
    }
}