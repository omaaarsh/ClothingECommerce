using ClothingECommerce.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WearlyEcommerce.Controllers
{
    /// <summary>
    /// Handles HTTP requests related to products, such as retrieving product data.
    /// </summary>
    /// <remarks>
    /// This controller interacts with the IProductService to perform business logic for product operations.
    /// It uses the allow-frontend CORS policy to allow requests from the frontend (e.g., http://localhost:3000).
    /// The controller is registered in Program.cs for dependency injection and supports API versioning with the 'api/v1' prefix.
    /// </remarks>
    [Route("api/v1/products")] // Updated: Use /api/v1/products for versioning
    [ApiController]
    [EnableCors("allow-frontend")] // Added: Apply CORS policy
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Initializes a new instance of the ProductsController with dependency injection.
        /// </summary>
        /// <param name="productService">The IProductService instance for handling product-related business logic.</param>
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Retrieves all products, optionally filtered by category.
        /// </summary>
        /// <param name="categoryId">Optional category ID to filter products.</param>
        /// <returns>A Task containing an IActionResult with a JSON response of matching products.</returns>
        /// <remarks>
        /// Accessible via GET /api/v1/products or GET /api/v1/products?categoryId={id}.
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> GetAll(int? categoryId = null)
        {
            var products = await _productService.GetAll(categoryId);
            return Ok(products);
        }

        /// <summary>
        /// Retrieves a single product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>A Task containing an IActionResult with the product in JSON format, or 404 if not found.</returns>
        /// <remarks>
        /// Accessible via GET /api/v1/products/{id}.
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            return product != null ? Ok(product) : NotFound();
        }

        /// <summary>
        /// Retrieves products categorized as men's clothing.
        /// </summary>
        /// <returns>A Task containing an IActionResult with a JSON response of men's products.</returns>
        /// <remarks>
        /// Accessible via GET /api/v1/products/men.
        /// </remarks>
        [HttpGet("men")]
        public async Task<IActionResult> GetMenProducts()
        {
            var products = await _productService.GetMenProducts();
            return Ok(products);
        }

        /// <summary>
        /// Retrieves products categorized as women's clothing.
        /// </summary>
        /// <returns>A Task containing an IActionResult with a JSON response of women's products.</returns>
        /// <remarks>
        /// Accessible via GET /api/v1/products/women.
        /// </remarks>
        [HttpGet("women")]
        public async Task<IActionResult> GetWomenProducts()
        {
            var products = await _productService.GetWomenProducts();
            return Ok(products);
        }

        /// <summary>
        /// Retrieves products categorized as kids' clothing.
        /// </summary>
        /// <returns>A Task containing an IActionResult with a JSON response of kids' products.</returns>
        /// <remarks>
        /// Accessible via GET /api/v1/products/kids.
        /// </remarks>
        [HttpGet("kids")]
        public async Task<IActionResult> GetKidsProducts()
        {
            var products = await _productService.GetKidsProducts();
            return Ok(products);
        }
    }
}