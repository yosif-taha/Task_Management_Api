# Project & Task Management API

A scalable, secure, and production-ready backend system built with **.NET 9** following **Clean Architecture** and **SOLID Principles**. This project was developed as a technical assessment task for the Backend .NET Developer position.

---

## 🏗️ Architecture Overview

The solution is structured using **Clean Architecture** to ensure separation of concerns, maintainability, and testability. It is divided into four main layers:

1. **Domain (Core):** Contains enterprise business objects, Entities (`User`, `Project`, `Task`), Enums, and core domain logic. Fully independent of external libraries.
2. **Application:** Contains application business logic, Interfaces, DTOs, Mapping Profiles, and Features implemented using the **CQRS Pattern** with **MediatR**.
3. **Infrastructure:** Handles data persistence, SQL Server configuration using **Entity Framework Core**, and external services like JWT token generation.
4. **Presentation (Web API):** The entry point of the application containing Controllers, Middlewares, and configurations.

---

## 🛠️ Technical Stack & Patterns

* **Framework:** .NET 9 (ASP.NET Core Web API)
* **Database & ORM:** SQL Server & Entity Framework Core
* **Design Patterns:** CQRS (Command Query Responsibility Segregation) via **MediatR**
* **Object Mapping:** **AutoMapper** with optimized `ProjectTo` database-level projections
* **Validation:** **FluentValidation** integrated seamlessly into MediatR Pipelines
* **Security:** **JWT Authentication** (Token-based authorization per user)
* **Error Handling:** **Global Exception Handling Middleware**
* **API Response:** Implemented a **Generic Response Wrapper** (`ApiResponse<T>`) for consistent API designs

---

## ⚙️ Setup & Installation Instructions

### Prerequisites
* **.NET 9 SDK** installed.
* **SQL Server** (LocalDB or Express) running.

### Configuration
1. Open the `appsettings.json` file inside the `Presentation` project.
2. Update the `ConnectionStrings:DefaultConnection` to match your SQL Server instance:
```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=TaskManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }

---

## 👨‍💻 Author

**Youssef Taha**  
- 📧 Email: yousif.t.abdulwahab@gmail.com 
- 🔗 [LinkedIn](https://www.linkedin.com/in/yousif-taha-89454922b/)  
- 🔗 [GitHub](https://github.com/yosif-taha)  
