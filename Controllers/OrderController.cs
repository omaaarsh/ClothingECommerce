using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ClothingECommerce.Services;
using ClothingECommerce.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ClothingECommerce.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        private int GetCustomerId()
        {
            var customerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(customerIdClaim) || !int.TryParse(customerIdClaim, out var customerId))
                throw new UnauthorizedAccessException("Invalid customer ID.");
            return customerId;
        }

        [HttpPost("order")]
        public async Task<ActionResult> CreateOrder()
        {
            var customerId = GetCustomerId();
            try
            {
                await _orderService.CreateOrderAsync(customerId);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("order")]
        public async Task<ActionResult<List<OrderDto>>> GetOrders()
        {
            var customerId = GetCustomerId();
            var orders = await _orderService.GetOrdersAsync(customerId);
            var orderDtos = orders.Select(o => new OrderDto
            {
                ID = o.OrderID,
                CustomerID = o.CustomerID,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                Items = o.Items.Select(i => new OrderItemDto
                {
                    ProductID = i.ProductID,
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Image = i.Product.Image
                }).ToList()
            }).ToList();
            return Ok(orderDtos);
        }
    }
}