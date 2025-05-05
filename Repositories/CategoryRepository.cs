using ClothingECommerce.Data;
using ClothingECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingECommerce.Repositories
{
    /// <summary>
    /// Handles data access operations for product categories using Entity Framework Core.
    /// </summary>
    /// <remarks>
    /// This repository interacts with the AppDbContext to perform CRUD operations on the Category entity.
    /// It is used by CategoryService to fetch category data for the e-commerce application.
    /// The repository is registered as a scoped service in Program.cs for dependency injection.
    /// </remarks>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the CategoryRepository with dependency injection.
        /// </summary>
        /// <param name="context">The AppDbContext instance for accessing the database.</param>
        /// <remarks>
        /// The constructor uses dependency injection to receive the AppDbContext, enabling database operations.
        /// The context is stored for use in repository methods.
        /// </remarks>
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all product categories from the database.
        /// </summary>
        /// <returns>
        /// A Task containing a List of Category objects, representing all categories in the database.
        /// </returns>
        /// <remarks>
        /// This method queries the Categories DbSet in the AppDbContext to fetch all category data asynchronously.
        /// </remarks>
        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.categories.ToListAsync();
        }
    }
}