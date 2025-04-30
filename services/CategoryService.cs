using ClothingECommerce.Models;
using ClothingECommerce.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingECommerce.Services
{
    /// <summary>
    /// Provides business logic for category-related operations, such as retrieving category data.
    /// </summary>
    /// <remarks>
    /// This service interacts with the ICategoryRepository to perform operations on the Category entity.
    /// It is used by controllers (e.g., CategoriesController) to fetch category data for display on the e-commerce frontend.
    /// The service is registered as a scoped service in Program.cs for dependency injection.
    /// </remarks>
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Initializes a new instance of the CategoryService with dependency injection.
        /// </summary>
        /// <param name="categoryRepository">The ICategoryRepository instance for accessing category data.</param>
        /// <remarks>
        /// The constructor uses dependency injection to receive the ICategoryRepository, enabling data access.
        /// The repository is stored for use in service methods.
        /// </remarks>
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Retrieves all product categories.
        /// </summary>
        /// <returns>
        /// A Task containing a List of Category objects, representing all categories in the database.
        /// </returns>
        /// <remarks>
        /// This method delegates to the ICategoryRepository to fetch all category data.
        /// It is used by the /api/v1/categories endpoint to provide category data for navigation menus or product filtering.
        /// </remarks>
        public async Task<List<Category>> GetAll()
        {
            return await _categoryRepository.GetAllAsync();
        }
    }
}