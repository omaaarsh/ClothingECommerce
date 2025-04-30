using Microsoft.EntityFrameworkCore; // Imports the namespace for Entity Framework Core, enabling database context and ORM functionality.
using ClothingECommerce.Models; // Imports the namespace for model classes (Category, Product, Customer), used for database table mappings.

namespace ClothingECommerce.Data // Defines the namespace for data-related classes, organizing the AppDbContext in the application.
{
    /// <summary>
    /// Represents the database context for the e-commerce application, providing access to Categories, Products, and Customers tables.
    /// </summary>
    /// <remarks>
    /// This class inherits from DbContext and is used by Entity Framework Core to interact with the SQL Server database.
    /// It defines DbSets for Categories, Products, and Customers, and configures entity mappings and seed data.
    /// The context is registered in Program.cs with a SQL Server connection string for dependency injection.
    /// </remarks>
    public class AppDbContext : DbContext // Defines the AppDbContext class, inheriting from DbContext to manage database operations.
    {
        /// <summary>
        /// Gets or sets the DbSet for the Categories table, representing product categories.
        /// </summary>
        /// <remarks>
        /// This DbSet allows querying and manipulating category data, used by CategoryService to fetch categories.
        /// </remarks>
        public DbSet<Category> Categories { get; set; } // Defines a DbSet property for the Category entity, mapping to the Categories table in the database.

        /// <summary>
        /// Gets or sets the DbSet for the Products table, representing products in the e-commerce catalog.
        /// </summary>
        /// <remarks>
        /// This DbSet allows querying and manipulating product data, used by ProductService to fetch products.
        /// </remarks>
        public DbSet<Product> Products { get; set; } // Defines a DbSet property for the Product entity, mapping to the Products table in the database.

        /// <summary>
        /// Gets or sets the DbSet for the Customers table, representing registered customers.
        /// </summary>
        /// <remarks>
        /// This DbSet allows querying and manipulating customer data, used by CustomerService for authentication and profile management.
        /// </remarks>
        public DbSet<Customer> Customers { get; set; } // Defines a DbSet property for the Customer entity, mapping to the Customers table in the database.

        /// <summary>
        /// Initializes a new instance of the AppDbContext with the specified options.
        /// </summary>
        /// <param name="options">The DbContextOptions containing configuration details, such as the database connection string.</param>
        /// <remarks>
        /// The constructor passes the options to the base DbContext class, enabling database configuration (e.g., SQL Server connection).
        /// The options are configured in Program.cs with the connection string from appsettings.json.
        /// </remarks>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Defines the constructor, accepting DbContextOptions and passing it to the base DbContext.
        {
        }

        [Obsolete] // Marks the method as obsolete, indicating it may be removed in future versions (likely for documentation or maintenance purposes).
        /// <summary>
        /// Configures the database schema and seeds initial data for Categories, Customers, and Products.
        /// </summary>
        /// <param name="modelBuilder">The ModelBuilder instance used to define entity mappings and constraints.</param>
        /// <remarks>
        /// This method configures the Customer entity with validation rules (e.g., required fields, unique email) and check constraints.
        /// It also seeds initial data for Categories (e.g., Man, Women, Kid), Customers, and Products to populate the database on creation.
        /// The method is called by Entity Framework Core during database initialization.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder) // Overrides the OnModelCreating method to configure the database schema and seed data.
        {
            // Configure Customer entity
            modelBuilder.Entity<Customer>(entity => // Configures the Customer entity using the ModelBuilder, defining its schema and constraints.
            {
                // Primary key
                entity.HasKey(c => c.ID); // Specifies that the ID property is the primary key for the Customer entity.
                entity.Property(c => c.ID).ValueGeneratedOnAdd();
                // Configure Name
                entity.Property(c => c.Name) // Configures the Name property of the Customer entity.
                      .IsRequired() // Marks the Name property as required (cannot be null).
                      .HasMaxLength(100); // Sets a maximum length of 100 characters for the Name property.

                // Configure Email with unique index
                entity.Property(c => c.Email) // Configures the Email property of the Customer entity.
                      .IsRequired() // Marks the Email property as required (cannot be null).
                      .HasMaxLength(255); // Sets a maximum length of 255 characters for the Email property.
                entity.HasIndex(c => c.Email) // Creates an index on the Email property to improve query performance.
                      .IsUnique(); // Ensures the Email property is unique across all customers, preventing duplicate emails.

                // Configure Password
                entity.Property(c => c.Password) // Configures the Password property of the Customer entity.
                      .IsRequired() // Marks the Password property as required (cannot be null).
                      .HasMaxLength(100); // Sets a maximum length of 100 characters for the Password property.
                entity.HasCheckConstraint("CK_Customer_Password_Length", "LEN(Password) >= 6"); // Adds a database check constraint to ensure the Password is at least 6 characters long.

                // Configure PhoneNo
                entity.Property(c => c.PhoneNo) // Configures the PhoneNo property of the Customer entity.
                      .IsRequired() // Marks the PhoneNo property as required (cannot be null).
                      .HasMaxLength(11); // Sets a maximum length of 11 characters for the PhoneNo property.
                entity.HasCheckConstraint("CK_Customer_PhoneNo_Length", "LEN(PhoneNo) = 11"); // Adds a database check constraint to ensure the PhoneNo is exactly 11 characters long.
            }); // Closes the Customer entity configuration block.

            modelBuilder.Entity<Product>(entity =>
                {
                    entity.HasKey(p => p.ID);
                    entity.Property(p => p.ID).ValueGeneratedOnAdd();
                });

            modelBuilder.Entity<Category>(entity =>
                {
                    entity.HasKey(c => c.ID);
                    entity.Property(c => c.ID).ValueGeneratedOnAdd();
                });
            // Seed Categories (unchanged)
            modelBuilder.Entity<Category>().HasData( // Seeds initial data for the Category entity to populate the Categories table.
                new Category { ID = 1, Name = "Man" }, // Seeds a category with ID 1 and Name "Man" for men's clothing.
                new Category { ID = 2, Name = "Women" }, // Seeds a category with ID 2 and Name "Women" for women's clothing.
                new Category { ID = 3, Name = "Kid" } // Seeds a category with ID 3 and Name "Kid" for kids' clothing.
            ); // Closes the Category seeding block.

            // Seed Customers data
            modelBuilder.Entity<Customer>().HasData( // Seeds initial data for the Customer entity to populate the Customers table.
                new Customer // Seeds the first customer record.
                {
                    ID = 1, // Sets the customer ID to 1.
                    Name = "Omar Sherif", // Sets the customer name to "Omar Sherif".
                    Email = "omarsherifelghamry@gmail.com", // Sets the customer email to a valid email address.
                    Password = "hashed_omar_2004", // Sets a placeholder for a hashed password (insecure in production).
                    PhoneNo = "01030222769" // Sets the phone number to an 11-digit value.
                },
                new Customer // Seeds the second customer record.
                {
                    ID = 2, // Sets the customer ID to 2.
                    Name = "Jana Sameh", // Sets the customer name to "Jana Sameh".
                    Email = "janaSameh@gmail.com", // Sets the customer email to a valid email address.
                    Password = "hashed_jana_sameh_2", // Sets a placeholder for a hashed password (insecure in production).
                    PhoneNo = "01005033314" // Sets the phone number to an 11-digit value.
                }
            ); // Closes the Customer seeding block.

            // Seed Products (only modified image paths shown)
            modelBuilder.Entity<Product>().HasData( // Seeds initial data for the Product entity to populate the Products table.
                // Man 
                new Product
                {
                    ID = 1,
                    Name = "Boxy Fit Crew Neck Printed Sweatshirt",
                    Price = 1199m,
                    Image = "./photos/man/Boxy Fit Crew Neck Printed Sweatshirt 1199 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Effortlessly stylish Boxy Fit Crew Neck Printed Sweatshirt, crafted for ultimate comfort with a bold, vibrant print and relaxed silhouette."
                },
                new Product
                {
                    ID = 2,
                    Name = "Boxy Fit Crew Neck Printed Sweatshirt",
                    Price = 1199m,
                    Image = "./photos/man/Boxy Fit Crew Neck Printed Sweatshirt 1199 EGP2.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Iconic Boxy Fit Crew Neck Printed Sweatshirt, blending cozy softness with a striking graphic design for a standout casual look."
                },
                new Product
                {
                    ID = 3,
                    Name = "Boxy Fit Crew Neck Printed Sweatshirt",
                    Price = 1199m,
                    Image = "./photos/man/Boxy Fit Crew Neck Printed Sweatshirt 1199 EGP3.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Trendsetting Boxy Fit Crew Neck Printed Sweatshirt, offering plush comfort and a dynamic print for an effortlessly cool vibe."
                },
                new Product
                {
                    ID = 4,
                    Name = "PLAIN T-SHIRT WITH LABEL",
                    Price = 1199m,
                    Image = "./photos/man/Boxy Fit Crew Neck Printed Sweatshirt 1199 EGP4.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Timeless Plain T-Shirt with Label, featuring a sleek minimalist design and ultra-soft fabric for versatile, everyday wear."
                },
                new Product
                {
                    ID = 5,
                    Name = "Regular Fit Long Sleeve Shirt",
                    Price = 1499m,
                    Image = "./photos/man/Regular Fit Long Sleeve Shirt 1499 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Sophisticated Regular Fit Long Sleeve Shirt, tailored for a polished look with breathable, lightweight fabric for all-day comfort."
                },
                new Product
                {
                    ID = 6,
                    Name = "Relax Fit Apache Neck Cotton Shirt",
                    Price = 1299m,
                    Image = "./photos/man/Relax Fit Apache Neck Cotton Embroidered Short Sleeve Shirt 1299 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Breezy Relax Fit Apache Neck Cotton Shirt, adorned with intricate embroidery for a laid-back yet refined summer style."
                },
                new Product
                {
                    ID = 7,
                    Name = "Oversize Fit Resort Collar Patterned Shirt",
                    Price = 1390m,
                    Image = "./photos/man/Oversize Fit Resort Collar Patterned Cotton Shirt 999 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Vibrant Oversize Fit Resort Collar Patterned Shirt, crafted from airy cotton with a bold pattern for a relaxed, tropical flair."
                },
                new Product
                {
                    ID = 8,
                    Name = "Regular Fit Apache Neck Viscose Shirt",
                    Price = 999m,
                    Image = "./photos/man/Regular Fit Apache Neck Viscose Striped Short Sleeve Shirt 999 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Chic Regular Fit Apache Neck Viscose Shirt, featuring sleek stripes and silky-smooth fabric for a refined, casual elegance."
                },
                new Product
                {
                    ID = 9,
                    Name = "Modern Fit Blazer",
                    Price = 2999m,
                    Image = "./photos/man/Modern Fit Blazer 2999 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Sleek Modern Fit Blazer, expertly tailored for a sharp, contemporary silhouette with premium fabric for lasting sophistication."
                },
                new Product
                {
                    ID = 10,
                    Name = "Relax Fit Lined Blazer",
                    Price = 3599m,
                    Image = "./photos/man/Relax Fit Lined Blazer 3599 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Luxurious Relax Fit Lined Blazer, combining a laid-back cut with refined lining for unparalleled comfort and style."
                },
                new Product
                {
                    ID = 11,
                    Name = "Modern Fit Lined Blazer Jacket",
                    Price = 2499m,
                    Image = "./photos/man/Modern Fit Lined Blazer Jacket 2499 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Stylish Modern Fit Lined Blazer Jacket, offering a tailored fit with premium lining for a polished and comfortable look."
                },
                new Product
                {
                    ID = 12,
                    Name = "Regular Fit Lined Blazer",
                    Price = 3999m,
                    Image = "./photos/man/Regular Fit Lined Blazer 3999 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Elegant Regular Fit Lined Blazer, designed for a classic silhouette with high-quality lining for all-day comfort."
                },
                new Product
                {
                    ID = 13,
                    Name = "NBA Golden State Warriors Sports Shorts",
                    Price = 799m,
                    Image = "./photos/man/DeFactoFit NBA Golden State Warriors Standard Fit Sports Shorts 799 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Dynamic NBA Golden State Warriors Sports Shorts, crafted for comfort and style, perfect for fans and active wear."
                },
                new Product
                {
                    ID = 14,
                    Name = "Standard Fit Sports Shorts",
                    Price = 1299m,
                    Image = "./photos/man/DeFactoFit Standard Fit Sports Shorts 1299 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Versatile Standard Fit Sports Shorts, designed for performance and comfort during active pursuits."
                },
                new Product
                {
                    ID = 15,
                    Name = "Standard Fit Sports Woven Shorts",
                    Price = 999m,
                    Image = "./photos/man/DeFactoFit Standard Fit Sports Woven Shorts 999 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Comfortable Standard Fit Sports Woven Shorts, ideal for sports and casual wear with a lightweight, breathable design."
                },
                new Product
                {
                    ID = 16,
                    Name = "Standard Fit Woven Shorts",
                    Price = 999m,
                    Image = "./photos/man/DeFactoFit Standard Fit Woven Shorts 999 EGP.avif",
                    CategoryID = 1,
                    Quantity = 50,
                    Description = "Sleek Standard Fit Woven Shorts, offering a relaxed fit and durable fabric for everyday casual wear."
                },
                // Kids
                new Product
                {
                    ID = 17,
                    Name = "POPLIN BOW APPLIQUÉ T",
                    Price = 850m,
                    Image = "./photos/kids/01037521250-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Stylish poplin T-shirt with bow appliqué, perfect for a chic and playful kids' look."
                },
                new Product
                {
                    ID = 18,
                    Name = "CONTRAST TOP",
                    Price = 850m,
                    Image = "./photos/kids/00485516250-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Vibrant contrast top for kids, combining bold colors and comfortable fabric for everyday wear."
                },
                new Product
                {
                    ID = 19,
                    Name = "DENIM TOP WITH BUTTONS",
                    Price = 1390m,
                    Image = "./photos/kids/08614640427-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Trendy denim top with buttons, offering a stylish and durable option for kids' casual outfits."
                },
                new Product
                {
                    ID = 20,
                    Name = "PLAIN T-SHIRT WITH LABEL",
                    Price = 390m,
                    Image = "./photos/kids/01716390620-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Simple yet stylish plain T-shirt with a label, ideal for kids' versatile and comfortable wear."
                },
                new Product
                {
                    ID = 21,
                    Name = "EMBROIDERED TEXT SWEATSHIRT",
                    Price = 890m,
                    Image = "./photos/kids/01880930800-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Cozy sweatshirt with embroidered text, perfect for kids to stay warm and fashionable."
                },
                new Product
                {
                    ID = 22,
                    Name = "BEAR PRINT SWEATSHIRT",
                    Price = 1090m,
                    Image = "./photos/kids/05643504712-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Fun bear print sweatshirt, designed to keep kids cozy with a playful and charming design."
                },
                new Product
                {
                    ID = 23,
                    Name = "EMBROIDERED SLOGAN WITH ZIP",
                    Price = 1390m,
                    Image = "./photos/kids/05431527098-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Stylish zip-up with embroidered slogan, offering kids a trendy and comfortable outerwear option."
                },
                new Product
                {
                    ID = 24,
                    Name = "SHIRT WITH FLORAL APPLIQUÉ",
                    Price = 1390m,
                    Image = "./photos/kids/01099808250-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Charming shirt with floral appliqué, adding a touch of elegance to kids' casual wardrobes."
                },
                new Product
                {
                    ID = 25,
                    Name = "TEXTURED STRIPED BERMUDA SHORTS",
                    Price = 1190m,
                    Image = "./photos/kids/00794505400-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Cool textured striped Bermuda shorts, perfect for kids' active and stylish summer looks."
                },
                new Product
                {
                    ID = 26,
                    Name = "TEXTURED STRIPED SHIRT",
                    Price = 1290m,
                    Image = "./photos/kids/00794503400-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Sleek textured striped shirt, offering kids a polished yet comfortable option for any occasion."
                },
                new Product
                {
                    ID = 27,
                    Name = "LINEN BERMUDA SHORTS WITH BELT",
                    Price = 1290m,
                    Image = "./photos/kids/01258500052-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Lightweight linen Bermuda shorts with a belt, ideal for kids' breezy and stylish summer outfits."
                },
                new Product
                {
                    ID = 28,
                    Name = "LINEN PATCH BERMUDA SHORTS",
                    Price = 1190m,
                    Image = "./photos/kids/02878502712-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Casual linen patch Bermuda shorts, designed for kids' comfort and trendy summer adventures."
                },
                new Product
                {
                    ID = 29,
                    Name = "THE LION KING © DISNEY",
                    Price = 1090m,
                    Image = "./photos/kids/20310418999-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Exciting The Lion King © Disney themed clothing, perfect for kids who love iconic characters."
                },
                new Product
                {
                    ID = 30,
                    Name = "LILO & STITCH © DISNEY",
                    Price = 650m,
                    Image = "./photos/kids/20310373999-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Playful Lilo & Stitch © Disney themed clothing, bringing fun and comfort to kids' wardrobes."
                },
                new Product
                {
                    ID = 31,
                    Name = "MINNIE MOUSE © DISNEY",
                    Price = 1090m,
                    Image = "./photos/kids/20310338999-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Adorable Minnie Mouse © Disney themed clothing, ideal for kids with a love for classic characters."
                },
                new Product
                {
                    ID = 32,
                    Name = "MICKEY MOUSE FANTASIA © DISNEY",
                    Price = 1090m,
                    Image = "./photos/kids/00653546800-e1.jpg",
                    CategoryID = 3,
                    Quantity = 50,
                    Description = "Magical Mickey Mouse Fantasia © Disney themed clothing, perfect for kids' whimsical and cozy style."
                },
                // Women
            new Product
            {
                ID = 33,
                Name = "NFL GIANTS HOODIE",
                Price = 3290m,
                Image = "./photos/women/NFL GIANTS HOODIE  3,290 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Cozy NFL Giants hoodie, perfect for women to show team spirit with a comfortable and stylish fit."
            },
            new Product
            {
                ID = 34,
                Name = "HOODIE WITH POCKETS +2",
                Price = 1690m,
                Image = "./photos/women/HOODIE WITH POCKETS +2  1,690 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Casual hoodie with pockets, offering a relaxed fit and practical style for women."
            },
            new Product
            {
                ID = 35,
                Name = "HARVARD UNIVERSITY SWEATSHIRT",
                Price = 2290m,
                Image = "./photos/women/HARVARD UNIVERSITY CROPPED FLEECE SWEATSHIRT  2,290 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Cropped fleece Harvard University sweatshirt, combining collegiate pride with trendy women’s fashion."
            },
            new Product
            {
                ID = 36,
                Name = "NFL BILLS HOODIE",
                Price = 2990m,
                Image = "./photos/women/NFL BILLS HOODIE  2,990 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Stylish NFL Bills hoodie, designed for women to support their team in comfort."
            },
            new Product
            {
                ID = 37,
                Name = "HIGH-WAIST WIDE-LEG TRF JEANS +3",
                Price = 2990m,
                Image = "./photos/women/HIGH-WAIST WIDE-LEG TRF JEANS +3  2,990 EGP .jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Trendy high-waist wide-leg TRF jeans, offering a bold and fashionable look for women."
            },
            new Product
            {
                ID = 38,
                Name = "HIGH-WAIST WIDE-LEG TRF JEANS +3",
                Price = 2990m,
                Image = "./photos/women/HIGH-WAIST WIDE-LEG TRF JEANS +3  2,990 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Trendy high-waist wide-leg TRF jeans, offering a bold and fashionable look for women."
            },
            new Product
            {
                ID = 39,
                Name = "YALE™ POLO NECK SWEATSHIRT",
                Price = 2490m,
                Image = "./photos/women/YALE™ POLO NECK SWEATSHIRT  2,490 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Sophisticated Yale™ polo neck sweatshirt, blending classic style with modern women’s fashion."
            },
            new Product
            {
                ID = 40,
                Name = "WIDE-LEG MID-RISE DARTED JEANS",
                Price = 2490m,
                Image = "./photos/women/Z1975 WIDE-LEG MID-RISE DARTED JEANS  2,490 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Chic wide-leg mid-rise darted jeans, perfect for a stylish and comfortable women’s outfit."
            },
            new Product
            {
                ID = 41,
                Name = "DARK ROMANCE EDP 80 ML : 2.71 oz",
                Price = 1690m,
                Image = "./photos/women/DARK ROMANCE EDP 80 ML : 2.71 oz  1,690 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Alluring Dark Romance EDP 80ml, a captivating fragrance for women."
            },
            new Product
            {
                ID = 42,
                Name = "IMMORTAL VANILLA EDP 80 ML : 2.71 oz",
                Price = 1690m,
                Image = "./photos/women/IMMORTAL VANILLA EDP 80 ML : 2.71 oz  1,690 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Enchanting Immortal Vanilla EDP 80ml, a sweet and lasting scent for women."
            },
            new Product
            {
                ID = 43,
                Name = "HYPNOTIC VANILLA BLOOM EDP 80ML : 2.71 oz",
                Price = 1690m,
                Image = "./photos/women/HYPNOTIC VANILLA BLOOM EDP 80ML : 2.71 oz  1,690 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Mesmerizing Hypnotic Vanilla Bloom EDP 80ml, a floral-vanilla fragrance for women."
            },
            new Product
            {
                ID = 44,
                Name = "RED ZARA TEMPTATION EDP 80ML : 2.71 oz",
                Price = 1690m,
                Image = "./photos/women/RED ZARA TEMPTATION EDP 80ML : 2.71 oz  1,690 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Bold Red Zara Temptation EDP 80ml, a vibrant and tempting scent for women."
            },
            new Product
            {
                ID = 45,
                Name = "TURN-UP KNIT BEANIE",
                Price = 1090m,
                Image = "./photos/women/TURN-UP KNIT BEANIE  1,090 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Cozy turn-up knit beanie, a stylish and warm accessory for women."
            },
            new Product
            {
                ID = 46,
                Name = "FLOWER HAIR CLIP",
                Price = 1290m,
                Image = "./photos/women/FLOWER HAIR CLIP  1,290 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Elegant flower hair clip, adding a feminine touch to women’s hairstyles."
            },
            new Product
            {
                ID = 47,
                Name = "MAXI ENAMELLED FLOWER EARRINGS",
                Price = 1290m,
                Image = "./photos/women/MAXI ENAMELLED FLOWER EARRINGS  1,290 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Striking maxi enamelled flower earrings, a bold accessory for women."
            },
            new Product
            {
                ID = 48,
                Name = "CORD SUN NECKLACE",
                Price = 1490m,
                Image = "./photos/women/CORD SUN NECKLACE  1,490 EGP.jpg",
                CategoryID = 2,
                Quantity = 50,
                Description = "Unique cord sun necklace, a chic and summery accessory for women."
            }
            );
        }
    }
}