# ✨👗 **Wearly Backend** — Architecture Overview

Welcome to the **Wearly** backend! 🚀  
This powers our cutting-edge **clothing e-commerce** platform, built with ❤️ using **ASP.NET Core MVC** and a robust, layered architecture.

---

## 📂 **Project Structure**

Wearly-Backend/
│
├── /Controllers/                   # API layer (handles HTTP requests)
│   ├── AccountController.cs        # User auth (register, login, logout, status)
│   ├── ProductController.cs        # Product APIs (list, detail, search)
│   ├── CategoryController.cs       # Category APIs (list, detail)
│   ├── CartController.cs           # Shopping cart APIs (add, remove, view)
│   ├── WishlistController.cs       # Wishlist APIs (add, remove, view)
│   └── …                         # More feature-specific controllers
│
├── /Services/                      # Business logic layer
│   ├── Interfaces/                 # Service interfaces (contracts)
│   │   ├── IAccountService.cs
│   │   ├── IProductService.cs
│   │   ├── ICategoryService.cs
│   │   ├── ICartService.cs
│   │   └── IOrderService.cs
│   └── Implementations/            # Concrete service implementations
│       ├── AccountService.cs
│       ├── ProductService.cs
│       ├── CategoryService.cs
│       ├── CartService.cs
│       └── OrderService.cs
│
├── /Repositories/                  # Data access layer (repositories)
│   ├── Interfaces/                 # Repository interfaces (data contracts)
│   │   ├── IAccountRepository.cs
│   │   ├── IProductRepository.cs
│   │   ├── ICategoryRepository.cs
│   │   ├── ICartRepository.cs
│   │   └── IOrderRepository.cs
│   └── Implementations/            # EF Core repository implementations
│       ├── AccountRepository.cs
│       ├── ProductRepository.cs
│       ├── CategoryRepository.cs
│       ├── CartRepository.cs
│       └── OrderRepository.cs
│
├── /Models/                        # Domain models (EF Core entities)
│   ├── Customer.cs                 # Customer/user entity
│   ├── Product.cs                  # Product entity
│   ├── Category.cs                 # Product category entity
│   ├── CartItem.cs                 # Cart item entity
│   └── Order.cs                    # Order entity
│
├── /Data/                          # Database context and migrations
│   ├── AppDbContext.cs             # EF Core DbContext
│   └── /Migrations/                # Database migration files
│
├── /Configurations/                # Application configurations
│   ├── CorsPolicy.cs               # Cross-Origin setup
│   ├── AuthenticationConfig.cs     # Auth setup (cookies, sessions)
│   ├── SwaggerConfig.cs            # Swagger API docs setup
│   └── …                         # Additional configs
│
├── appsettings.json                # Global configuration (DB strings, keys)
├── Program.cs                      # Application startup + middleware pipeline
├── Dockerfile                      # Docker container setup (SQL Server)
└── README.md                       # Documentation
---

## 🏛️ **Layered Architecture**

| 🏗️ **Layer**    | 🔍 **Purpose**                                                                          |
|-----------------|-----------------------------------------------------------------------------------------|
| 🎯 Controller    | Handles HTTP requests → calls services → returns responses (API layer)                   |
| 🛠️ Service       | Business rules, validation, orchestrates repo calls (logic layer)                       |
| 🗄️ Repository    | CRUD operations on database using EF Core (data access layer)                           |
| 📦 Models        | Entity definitions + relationships (domain layer)                                       |

---

## 🌟 **Key Features**

✅ Modular, clean REST APIs (products, categories, accounts, cart, wishlist, orders)  
✅ Secure auth with **cookie-based sessions** (30-day expiry)  
✅ **BCrypt** password hashing for top-notch security 🔐  
✅ **SQL Server** (via Docker) with seamless EF Core migrations 🛳️  
✅ Interactive **Swagger** UI for testing and exploring APIs 🧪  
✅ Fully scalable + maintainable architecture using interfaces + DI 💡

---

## ⚙️ **Tech Stack**

- 🌐 **ASP.NET Core MVC**
- 🏛️ **Entity Framework Core** (SQL Server)
- 🐳 **Docker** (SQL Server container)
- 🔐 **BCrypt.Net** (password security)
- 🧪 **Swagger** (API documentation/testing)

---

## 🌍 **API Endpoints Overview**

| 🛍️ **Feature**   | 🌐 **Endpoints**                                                                                             |
|------------------|------------------------------------------------------------------------------------------------------------|
| Products         | `GET /api/v1/products` → all products<br>`GET /api/v1/products/{id}` → single product                        |
| Categories       | `GET /api/v1/categories`                                                                                   |
| Accounts         | `POST /api/v1/accounts/register` → sign up<br>`POST /api/v1/accounts/login` → sign in<br>`POST /api/v1/accounts/logout` → log out<br>`GET /api/v1/accounts/status` → auth check<br>`GET /api/v1/accounts/profile` → user details |
| Cart            | `GET /api/v1/cart` → view cart<br>`POST /api/v1/cart/add` → add item<br>`POST /api/v1/cart/remove` → remove item |
| Orders         | `GET /api/v1/orders` → list orders<br>`POST /api/v1/orders` → place order                                     |

🔗 **Swagger UI live at:** [http://localhost:5107/swagger](http://localhost:5107/swagger)

---

## 🚀 **Quick Start**

```bash
# 1️⃣ Clone the repo
git clone <backend-repo-url>
cd Wearly-Backend

# 2️⃣ Run SQL Server in Docker
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Passw0rd" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

# 3️⃣ Update DB connection in appsettings.json (if needed)
"DefaultConnection": "Server=localhost,1433;Database=WearlyDb;User=sa;Password=YourStrong@Passw0rd;"

# 4️⃣ Run backend
dotnet restore
dotnet ef database update
dotnet run

✅ Backend live at: http://localhost:5107
✅ Swagger UI ready at: http://localhost:5107/swagger
