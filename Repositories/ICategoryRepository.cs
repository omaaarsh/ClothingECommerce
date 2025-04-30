using ClothingECommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingECommerce.Repositories
{
    /// <summary>
    /// Defines the contract for category-related data access operations.
    /// </summary>
    /// <remarks>
    /// This interface is implemented by CategoryRepository to provide methods for accessing category data in the database.
    /// It is used by services (e.g., CategoryService) to perform data operations via Entity Framework Core.
    /// </remarks>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Retrieves all product categories from the database.
        /// </summary>
        /// <returns>
        /// A Task containing a List of Category objects, representing all categories in the database.
        /// </returns>
        Task<List<Category>> GetAllAsync();
    }
}