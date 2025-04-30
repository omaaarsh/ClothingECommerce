using ClothingECommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingECommerce.Services
{
    /// <summary>
    /// Defines the contract for product-related business logic operations.
    /// </summary>
    /// <remarks>
    /// This interface is implemented by ProductService to provide methods for retrieving and managing product data.
    /// It is used by controllers (e.g., ProductsController) to fetch product data for the frontend.
    /// </remarks>
    public interface IProductService
    {
        /// <summary>
        /// Retrieves a list of products, optionally filtered by category ID.
        /// </summary>
        /// <param name="categoryId">Optional category ID to filter the results. If null, all products are returned.</param>
        /// <returns>A Task containing a List of Product objects, representing the matching products.</returns>
        Task<List<Product>> GetAll(int? categoryId = null);

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>A Task containing the Product object if found, or null if no product matches the ID.</returns>
        Task<Product?> GetById(int id);

        /// <summary>
        /// Retrieves products in the men's clothing category (CategoryID = 1).
        /// </summary>
        /// <returns>A Task containing a List of Product objects representing men's clothing products.</returns>
        Task<List<Product>> GetMenProducts();

        /// <summary>
        /// Retrieves products in the women's clothing category (CategoryID = 2).
        /// </summary>
        /// <returns>A Task containing a List of Product objects representing women's clothing products.</returns>
        Task<List<Product>> GetWomenProducts();

        /// <summary>
        /// Retrieves products in the kids' clothing category (CategoryID = 3).
        /// </summary>
        /// <returns>A Task containing a List of Product objects representing kids' clothing products.</returns>
        Task<List<Product>> GetKidsProducts();
    }
}