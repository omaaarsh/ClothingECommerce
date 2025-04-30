using ClothingECommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingECommerce.Services
{
    /// <summary>
    /// Defines the contract for category-related business logic operations.
    /// </summary>
    /// <remarks>
    /// This interface is implemented by CategoryService to provide methods for retrieving and managing category data.
    /// It is used by controllers (e.g., CategoriesController) to fetch category data for the frontend.
    /// </remarks>
    public interface ICategoryService
    {
        /// <summary>
        /// Retrieves all product categories.
        /// </summary>
        /// <returns>
        /// A Task containing a List of Category objects, representing all categories in the database.
        /// </returns>
        Task<List<Category>> GetAll();
    }
}