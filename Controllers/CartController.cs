using ClothingECommerce.Models;
using ClothingECommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClothingECommerce.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        private int GetCustomerId()
        {
            var customerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(customerIdClaim) || !int.TryParse(customerIdClaim, out var customerId))
                throw new UnauthorizedAccessException("Invalid customer ID.");
            return customerId;
        }

        [HttpGet]
        public async Task<ActionResult<CartDto>> GetCart()
        {
            var customerId = GetCustomerId();
            var cart = await _cartService.GetCartAsync(customerId);
            var cartDto = new CartDto
            {
                CustomerID = cart.CustomerID,
                Items = cart.Items.Select(i => new CartItemDto
                {
                    ProductID = i.ProductID,
                    ProductName = i.Product.Name,
                    Price = i.Product.Price,
                    Quantity = i.Quantity,
                    Image = i.Product.Image
                }).ToList(),
                TotalPrice = cart.Items.Sum(i => i.Quantity * i.Product.Price)
            };
            return Ok(cartDto);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddItem([FromBody] AddCartItemRequest request)
        {
            if (request.Quantity <= 0)
                return BadRequest("Quantity must be greater than 0.");

            var customerId = GetCustomerId();
            try
            {
                await _cartService.AddItemAsync(customerId, request.ProductId, request.Quantity);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult> UpdateItem([FromBody] UpdateCartItemRequest request)
        {
            if (request.Quantity < 0)
                return BadRequest("Quantity cannot be negative.");

            var customerId = GetCustomerId();
            try
            {
                await _cartService.UpdateItemAsync(customerId, request.ProductId, request.Quantity);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("remove")]
        public async Task<ActionResult> RemoveItem([FromBody] RemoveCartItemRequest request)
        {
            var customerId = GetCustomerId();
            await _cartService.RemoveItemAsync(customerId, request.ProductId);
            return Ok();
        }

        [HttpPost("clear")]
        public async Task<ActionResult> ClearCart()
        {
            var customerId = GetCustomerId();
            await _cartService.ClearCartAsync(customerId);
            return Ok();
        }
    }

    public class AddCartItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateCartItemRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class RemoveCartItemRequest
    {
        public int ProductId { get; set; }
    }
}