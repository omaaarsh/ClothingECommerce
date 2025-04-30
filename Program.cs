/*
 * Clothing E-Commerce API Configuration
 * 
 * This file configures:
 * - Dependency Injection
 * - Middleware Pipeline
 * - Authentication/Authorization
 * - Database Context
 * - API Documentation
 * - Cross-Origin Policies
 * 
 * Entry Point: WebApplication.CreateBuilder() -> app.Run()
 */

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ClothingECommerce.Data;
using ClothingECommerce.Services;
using ClothingECommerce.Repositories;
using Microsoft.Extensions.Logging;

// Initialize web application builder with preconfigured defaults
// - Loads appsettings.json configuration
// - Configures logging
// - Sets up dependency injection container
var builder = WebApplication.CreateBuilder(args);

/*******************************************
 * SERVICE REGISTRATION SECTION
 *******************************************/

// Add MVC Controllers
// - Registers all Controller classes
// - Uses default camelCase JSON serialization for REST API compatibility
builder.Services.AddControllers();

// Configure Swagger documentation generator
// - Creates OpenAPI specification
// - Enables API exploration UI
builder.Services.AddSwaggerGen(c =>
{
    // Define basic API metadata
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Clothing E-Commerce API",  // API title
        Version = "v1",                     // API version
        Description = "Core backend service for clothing e-commerce operations",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "API Support",
            Email = "support@clothingcommerce.com"
        }
    });

    // Include XML comments from documentation file
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);  // Links XML docs to Swagger
});

// Configure Entity Framework Core with SQL Server
// - Registers AppDbContext as a service
// - Uses connection string from configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),  // Connection string name
        sqlOptions => sqlOptions.EnableRetryOnFailure(    // Connection resiliency
            maxRetryCount: 5,             // Maximum retry attempts
            maxRetryDelay: TimeSpan.FromSeconds(30),  // Delay between retries
            errorNumbersToAdd: null)      // Specific SQL error codes to retry
    ));

// Register application services with scoped lifetime
// - Created once per client request
builder.Services.AddScoped<IProductService,ProductService>();    // Handles product CRUD operations
builder.Services.AddScoped<ICategoryService,CategoryService>();   // Manages product categories
builder.Services.AddScoped<ICustomerService,CustomerService>(); // Manages user accounts/authentication
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>(); // Handles customer data access
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // Handles product categories data access
builder.Services.AddScoped<IProductRepository,ProductRepository>(); // Handles product data access

/*******************************************
 * SECURITY CONFIGURATION SECTION
 *******************************************/

// Configure Cross-Origin Resource Sharing (CORS)
// - Controls cross-domain requests
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "allow-frontend", policy =>
    {
        policy.WithOrigins(    // Allowed origin URLs
            "http://127.0.0.1:3000",  // Frontend IP address
            "http://localhost:3000"   // Local development
        )
        .WithMethods("GET", "POST", "OPTIONS") // Updated: Explicitly allow OPTIONS for preflight
        .WithHeaders("Content-Type", "Authorization") // Restricted to required headers
        .AllowCredentials()   // Allows cookies/authentication headers
        .WithExposedHeaders("Set-Cookie");  // Exposes custom headers
    });
});

// Configure cookie-based authentication
// - Handles user session management
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // Cookie Configuration
        options.Cookie.Name = ".clothing-ecommerce.session"; // Custom application-specific name
        options.Cookie.HttpOnly = true;      // Prevent XSS access
        options.Cookie.SameSite = SameSiteMode.Lax;  // CSRF protection
        options.Cookie.SecurePolicy = builder.Environment.IsDevelopment() ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
        options.Cookie.Path = "/";          // Valid for entire site
        options.Cookie.Domain = "localhost"; // Restrict cookie domain
        
        // Session Configuration
        options.ExpireTimeSpan = TimeSpan.FromDays(30); // Absolute timeout
        options.SlidingExpiration = true;    // Reset timeout on activity
        
        // Event Handlers
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            context.Response.WriteAsync(
                System.Text.Json.JsonSerializer.Serialize(new
                {
                    message = "Unauthorized: Please log in.",
                    errors = new string[] { }
                }));
            return Task.CompletedTask;
        };
        
        options.Events.OnRedirectToLogout = context =>
        {
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            context.Response.WriteAsync(
                System.Text.Json.JsonSerializer.Serialize(new
                {
                    message = "Logged out successfully.",
                    errors = new string[] { }
                }));
            return Task.CompletedTask;
        };
    });

/*******************************************
 * INFRASTRUCTURE CONFIGURATION
 *******************************************/

// Configure logging infrastructure
// - Routes log messages to different outputs
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();  // Write to console output
    logging.AddDebug();    // Write to debug output
    // Log levels configured in appsettings.json
});

// Build application instance
// - Finalizes service configuration
// - Creates middleware pipeline
var app = builder.Build();

/*******************************************
 * MIDDLEWARE PIPELINE CONFIGURATION
 *******************************************/

// Development-specific configuration
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Show detailed error pages

    // Enable Swagger documentation endpoints
    app.UseSwagger();       // Serves OpenAPI JSON
    app.UseSwaggerUI(c =>   // Provides UI explorer
    {
        c.SwaggerEndpoint(
            url: "/swagger/v1/swagger.json",  // JSON spec location
            name :"Clothing E-Commerce API v1");
        c.RoutePrefix = "swagger";  // Access UI at /swagger
    });
}

// Add global exception handling
// - Ensures consistent JSON error responses for unhandled exceptions
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                message = "An unexpected error occurred.",
                errors = new string[] { }
            }));
    });
}); // Added: Global error handling

// Middleware ordering is critical
app.UseCors("allow-frontend");  // Use new CORS policy name
app.UseAuthentication();       // Identify user (WHO)
app.UseAuthorization();        // Verify permissions (WHAT)
app.MapControllers();          // Register controller routes

// Start application execution
// - Begins listening for HTTP requests
// - Blocks until application shutdown
app.Run();