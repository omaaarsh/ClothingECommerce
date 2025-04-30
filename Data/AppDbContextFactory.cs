using Microsoft.EntityFrameworkCore; // Imports the namespace for Entity Framework Core, enabling database context and configuration functionality.
using Microsoft.EntityFrameworkCore.Design; // Imports the namespace for design-time DbContext creation, providing the IDesignTimeDbContextFactory interface.
using Microsoft.Extensions.Configuration; // Imports the namespace for configuration management, used to read settings from appsettings.json.
using System.IO; // Imports the namespace for file and directory operations, used to access the current directory.

namespace ClothingECommerce.Data // Defines the namespace for data-related classes, organizing the AppDbContextFactory in the application.
{
    /// <summary>
    /// A factory class for creating instances of AppDbContext at design time, used by Entity Framework Core tools.
    /// </summary>
    /// <remarks>
    /// This class implements the IDesignTimeDbContextFactory interface to provide a way to create AppDbContext instances
    /// during design-time operations, such as running EF Core migrations or scaffolding.
    /// It reads the database connection string from appsettings.json and configures the DbContext to use SQL Server.
    /// The factory is not used at runtime; it is specifically for EF Core tooling.
    /// </remarks>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext> // Defines the AppDbContextFactory class, implementing IDesignTimeDbContextFactory for AppDbContext.
    {
        /// <summary>
        /// Creates an instance of AppDbContext for design-time operations.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the EF Core tools (not used in this implementation).</param>
        /// <returns>
        /// An instance of AppDbContext configured with the SQL Server connection string from appsettings.json.
        /// </returns>
        /// <remarks>
        /// This method is called by EF Core tools (e.g., `dotnet ef migrations add`) to create an AppDbContext instance.
        /// It loads the connection string from appsettings.json, configures the DbContextOptions, and returns a new AppDbContext.
        /// The method ensures that migrations and other design-time operations can access the database configuration.
        /// </remarks>
        public AppDbContext CreateDbContext(string[] args) // Implements the CreateDbContext method required by IDesignTimeDbContextFactory.
        {
            var configuration = new ConfigurationBuilder() // Creates a new ConfigurationBuilder to build the configuration object for reading settings.
                .SetBasePath(Directory.GetCurrentDirectory()) // Sets the base path to the current working directory, where appsettings.json is located.
                .AddJsonFile("appsettings.json") // Adds the appsettings.json file as a configuration source.
                .Build(); // Builds the configuration object, loading the settings from appsettings.json.

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>(); // Creates a new DbContextOptionsBuilder for configuring AppDbContext options.
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); // Configures the DbContext to use SQL Server with the "DefaultConnection" string from appsettings.json.

            return new AppDbContext(optionsBuilder.Options); // Creates and returns a new AppDbContext instance with the configured options.
        }
    }
}