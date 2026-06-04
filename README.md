📚 E-Learning Backend API

A backend RESTful API built with ASP.NET Core for an E-Learning platform.
This project includes authentication, cart system, product management, and clean service-based architecture.

🚀 Features
🔐 JWT Authentication (Access Token + Refresh Token)
👤 User Registration & Login
🛒 Shopping Cart System
📦 Product Management (CRUD)
⚡ FluentValidation for input validation
🧱 Service Layer Architecture
📡 Global Exception Handling Middleware
📊 Structured Logging (Serilog)
🔄 Entity Framework Core (Code First)
🏗️ Project Architecture
ShopApi/
│
├── Controllers
├── Services
├── DTOs
├── Models
├── Data (DbContext)
├── Common (Result Pattern)
├── Middlewares
└── Validators
⚙️ Tech Stack
ASP.NET Core Web API
Entity Framework Core
SQL Server
JWT Authentication
FluentValidation
Serilog
BCrypt Password Hashing
🔐 Authentication Flow
User registers → password hashed (BCrypt)
Login → returns:
Access Token (JWT)
Refresh Token
Access Token used for API authorization
Refresh Token used to generate new Access Token
📦 API Endpoints
Auth
POST /api/auth/register
POST /api/auth/login
POST /api/auth/refresh
Products
GET    /api/product
POST   /api/product
PUT    /api/product/{id}
DELETE /api/product/{id}
Cart
POST   /api/addtocart/add
GET    /api/addtocart/getall
DELETE /api/addtocart/deletecartitem
🧠 Response Format

All API responses follow a standard structure:

{
  "success": true,
  "message": "Success",
  "data": {}
}
📊 Logging

This project uses Serilog for structured logging.

Logs include:

User actions
Authentication attempts
Business warnings (e.g. stock issues)
System errors

Logs are stored in:

/logs/log.txt
⚠️ Exception Handling

Global exception handling is implemented using middleware:

Catches unhandled exceptions
Logs errors automatically
Returns consistent API responses
🧪 Validation

Input validation is handled using FluentValidation:

Clean separation of validation rules
Automatic validation on request models
🛠️ How to Run
1. Clone repository
git clone https://github.com/your-username/E_Learning_Backend.git
2. Set up database

Update connection string in appsettings.json

3. Run migrations
dotnet ef database update
4. Run project
dotnet run
📌 Future Improvements
Clean Architecture implementation
Unit Testing (xUnit)
Pagination & Filtering
Role-based Authorization improvement
API Versioning
Redis caching
👨‍💻 Author

Mohammad Hasan
Backend Developer (.NET / ASP.NET Core)

⭐ Notes

This project is built for learning and portfolio purposes, but follows real-world backend patterns used in production systems.
