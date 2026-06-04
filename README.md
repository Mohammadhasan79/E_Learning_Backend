<div align="center">

# E-Learning Backend API

**A production-style RESTful API for an online learning platform**  
Built with ASP.NET Core · Entity Framework Core · SQL Server · JWT

[![C#](https://img.shields.io/badge/C%23-100%25-239120?logo=c-sharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![EF Core](https://img.shields.io/badge/EF%20Core-Code%20First-512BD4?logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)
[![JWT](https://img.shields.io/badge/JWT-Auth-000000?logo=jsonwebtokens&logoColor=white)](https://jwt.io/)

</div>

---

## Overview

E-Learning Backend is a RESTful API that powers an online learning platform. It handles user authentication, product (course) management, and a shopping cart system — built with a clean service-layer architecture that mirrors real-world .NET backend practices.

---

## Tech Stack

| Concern | Technology |
|---|---|
| Framework | ASP.NET Core Web API |
| ORM | Entity Framework Core (Code First) |
| Database | Microsoft SQL Server |
| Authentication | JWT — Access Token + Refresh Token |
| Password Hashing | BCrypt.Net |
| Validation | FluentValidation |
| Logging | Serilog (file sink) |
| Testing | xUnit |

---

## Project Structure

```
E_Learning_Solution/
├── E_Learning_Backend/
│   ├── Controllers/        # Route handlers
│   ├── Services/           # Business logic
│   ├── DTOs/               # Request/response models
│   ├── Models/             # Domain entities
│   ├── Data/               # DbContext & EF configuration
│   ├── Common/             # Result pattern & shared utilities
│   ├── Middlewares/        # Global exception handling
│   └── Validators/         # FluentValidation rules
│
└── E_Learning_Solution.Test/   # Unit test project
```

---

## Authentication Flow

```
Register   →  Password hashed with BCrypt  →  User stored in DB
Login      →  Credentials verified         →  Access Token + Refresh Token returned
API call   →  Bearer <AccessToken>         →  Authorized
Refresh    →  POST /api/auth/refresh       →  New Access Token issued
```

---

## API Endpoints

### Auth
| Method | Endpoint | Description |
|---|---|---|
| `POST` | `/api/auth/register` | Register a new user |
| `POST` | `/api/auth/login` | Login and receive tokens |
| `POST` | `/api/auth/refresh` | Refresh access token |

### Products
| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/product` | List all products |
| `POST` | `/api/product` | Create a product |
| `PUT` | `/api/product/{id}` | Update a product |
| `DELETE` | `/api/product/{id}` | Delete a product |

### Cart
| Method | Endpoint | Description |
|---|---|---|
| `POST` | `/api/addtocart/add` | Add item to cart |
| `GET` | `/api/addtocart/getall` | Get all cart items |
| `DELETE` | `/api/addtocart/deletecartitem` | Remove a cart item |

---

## Standard Response Format

```json
{
  "success": true,
  "message": "Operation completed successfully.",
  "data": {}
}
```

All endpoints — including errors — return this consistent envelope.

---

## Getting Started

**Prerequisites:** .NET SDK 6+ · SQL Server

```bash
# 1. Clone
git clone https://github.com/Mohammadhasan79/E_Learning_Backend.git
cd E_Learning_Backend

# 2. Set your connection string in appsettings.json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ELearningDb;Trusted_Connection=True;"
}

# 3. Apply migrations
dotnet ef database update --project E_Learning_Backend

# 4. Run
dotnet run --project E_Learning_Backend
```

---

## Running Tests

```bash
dotnet test E_Learning_Solution.Test
```

---

## Roadmap

- [ ] Clean Architecture refactor (Domain / Application / Infrastructure / API)
- [ ] Role-based authorization (Admin · Instructor · Student)
- [ ] Pagination and filtering on list endpoints
- [ ] Swagger / OpenAPI documentation
- [ ] Docker support
- [ ] GitHub Actions CI pipeline
- [ ] Redis caching

---

## About

Built for learning and portfolio purposes, following real-world .NET backend patterns.

**Mohammad Hasan** — Backend Developer (.NET / ASP.NET Core)
