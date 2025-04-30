using ClothingECommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingECommerce.Repositories
{
    /// <summary>
    /// Defines the contract for product-related data access operations.
    /// </summary>
    /// <remarks>
    /// This interface is implemented by ProductRepository to provide methods for accessing product data in the database.
    /// It is used by services (e.g., ProductService) to perform data operations via Entity Framework Core.
    /// </remarks>
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieves a list of products, optionally filtered by category ID.
        /// </summary>
        /// <param name="categoryId">Optional category ID to filter the results. If null, all products are returned.</param>
        /// <returns>A Task containing a List of Product objects, representing the matching products.</returns>
        Task<List<Product>> GetAllAsync(int? categoryId = null);

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>A Task containing the Product object if found, or null if no product matches the ID.</returns>
        Task<Product?> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves products in the men's clothing category (CategoryID = 1).
        /// </summary>
        /// <returns>A Task containing a List of Product objects representing men's clothing products.</returns>
        Task<List<Product>> GetMenProductsAsync();

        /// <summary>
        /// Retrieves products in the women's clothing category (CategoryID = 2).
        /// </summary>
        /// <returns>A Task containing a List of Product objects representing women's clothing products.</returns>
        Task<List<Product>> GetWomenProductsAsync();

        /// <summary>
        /// Retrieves products in the kids' clothing category (CategoryID = 3).
        /// </summary>
        /// <returns>A Task containing a List of Product objects representing kids' clothing products.</returns>
        Task<List<Product>> GetKidsProductsAsync();
    }
}