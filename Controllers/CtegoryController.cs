using ClothingECommerce.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WearlyEcommerce.Controllers
{
    /// <summary>
    /// Handles HTTP requests related to product categories, such as retrieving category data.
    /// </summary>
    /// <remarks>
    /// This controller interacts with the ICategoryService to perform business logic for category operations.
    /// It uses the allow-frontend CORS policy to allow requests from the frontend (e.g., http://localhost:3000).
    /// The controller is registered in Program.cs for dependency injection and supports API versioning with the 'api/v1' prefix.
    /// </remarks>
    [Route("api/v1/categories")] // Updated: Use /api/v1/categories for versioning
    [ApiController]
    [EnableCors("allow-frontend")] // Added: Apply CORS policy
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Initializes a new instance of the CategoriesController with dependency injection.
        /// </summary>
        /// <param name="categoryService">The ICategoryService instance for handling category-related business logic.</param>
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Retrieves all product categories.
        /// </summary>
        /// <returns>
        /// A Task containing an IActionResult with a JSON response of all categories.
        /// </returns>
        /// <remarks>
        /// This method calls ICategoryService.GetAll to fetch category data and returns it in JSON format.
        /// Accessible via GET /api/v1/categories.
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }
    }
}