using ClothingECommerce.Models;
using ClothingECommerce.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingECommerce.Services
{
    /// <summary>
    /// Provides business logic for product-related operations, such as retrieving product data.
    /// </summary>
    /// <remarks>
    /// This service interacts with the IProductRepository to perform CRUD operations on the Product entity.
    /// It is used by controllers (e.g., ProductsController) to fetch product data for the e-commerce frontend.
    /// The service is registered as a scoped service in Program.cs for dependency injection.
    /// </remarks>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the ProductService with dependency injection.
        /// </summary>
        /// <param name="productRepository">The IProductRepository instance for accessing product data.</param>
        /// <remarks>
        /// The constructor uses dependency injection to receive the IProductRepository, enabling data access.
        /// The repository is stored for use in service methods.
        /// </remarks>
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Retrieves a list of products, optionally filtered by category ID.
        /// </summary>
        /// <param name="categoryId">Optional category ID to filter the results. If null, all products are returned.</param>
        /// <returns>A Task containing a List of Product objects, representing the matching products.</returns>
        public async Task<List<Product>> GetAll(int? categoryId = null)
        {
            return await _productRepository.GetAllAsync(categoryId);
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>A Task containing the Product object if found, or null if no product matches the ID.</returns>
        public async Task<Product?> GetById(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Retrieves products in the men's clothing category (CategoryID = 1).
        /// </summary>
        /// <returns>A Task containing a List of Product objects representing men's clothing products.</returns>
        public async Task<List<Product>> GetMenProducts()
        {
            return await _productRepository.GetMenProductsAsync();
        }

        /// <summary>
        /// Retrieves products in the women's clothing category (CategoryID = 2).
        /// </summary>
        /// <returns>A Task containing a List of Product objects representing women's clothing products.</returns>
        public async Task<List<Product>> GetWomenProducts()
        {
            return await _productRepository.GetWomenProductsAsync();
        }

        /// <summary>
        /// Retrieves products in the kids' clothing category (CategoryID = 3).
        /// </summary>
        /// <returns>A Task containing a List of Product objects representing kids' clothing products.</returns>
        public async Task<List<Product>> GetKidsProducts()
        {
            return await _productRepository.GetKidsProductsAsync();
        }
    }
}