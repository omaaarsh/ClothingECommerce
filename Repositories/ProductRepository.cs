using ClothingECommerce.Data;
using ClothingECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingECommerce.Repositories
{
    /// <summary>
    /// Handles data access operations for products using Entity Framework Core.
    /// </summary>
    /// <remarks>
    /// This repository interacts with the AppDbContext to perform CRUD operations on the Product entity.
    /// It is used by ProductService to fetch product data for the e-commerce application.
    /// The repository is registered as a scoped service in Program.cs for dependency injection.
    /// </remarks>
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the ProductRepository with dependency injection.
        /// </summary>
        /// <param name="context">The AppDbContext instance for accessing the database.</param>
        /// <remarks>
        /// The constructor uses dependency injection to receive the AppDbContext, enabling database operations.
        /// The context is stored for use in repository methods.
        /// </remarks>
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of products, optionally filtered by category ID.
        /// </summary>
        /// <param name="categoryId">Optional category ID to filter the results. If null, all products are returned.</param>
        /// <returns>A Task containing a List of Product objects, representing the matching products.</returns>
        public async Task<List<Product>> GetAllAsync(int? categoryId = null)
        {
            var query = _context.Products.AsQueryable();
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryID == categoryId.Value);
            }
            return await query.ToListAsync();
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>A Task containing the Product object if found, or null if no product matches the ID.</returns>
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        /// <summary>
        /// Retrieves products in the men's clothing category (CategoryID = 1).
        /// </summary>
        /// <returns>A Task containing a List of Product objects representing men's clothing products.</returns>
        public async Task<List<Product>> GetMenProductsAsync()
        {
            return await _context.Products.Where(p => p.CategoryID == 1).ToListAsync();
        }

        /// <summary>
        /// Retrieves products in the women's clothing category (CategoryID = 2).
        /// </summary>
        /// <returns>A Task containing a List of Product objects representing women's clothing products.</returns>
        public async Task<List<Product>> GetWomenProductsAsync()
        {
            return await _context.Products.Where(p => p.CategoryID == 2).ToListAsync();
        }

        /// <summary>
        /// Retrieves products in the kids' clothing category (CategoryID = 3).
        /// </summary>
        /// <returns>A Task containing a List of Product objects representing kids' clothing products.</returns>
        public async Task<List<Product>> GetKidsProductsAsync()
        {
            return await _context.Products.Where(p => p.CategoryID == 3).ToListAsync();
        }
    }
}