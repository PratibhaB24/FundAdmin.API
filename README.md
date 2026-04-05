# 📘 Fund Administration API

## 🧩 Overview

This project is a **Fund Administration backend API** built using **ASP.NET Core (.NET 8)**.
It manages:

* Funds
* Investors
* Transactions (Subscriptions & Redemptions)

The application follows **clean architecture principles**, uses the **Repository Pattern**, and implements **JWT Authentication, Validation, and Global Exception Handling**.

---

## 🚀 Features

* ✅ CRUD operations for Funds and Investors
* ✅ Transaction management (Subscription / Redemption)
* ✅ Fund-level transaction summary
* ✅ Repository Pattern with Dependency Injection
* ✅ DTO-based architecture
* ✅ Global Exception Handling (ProblemDetails - RFC 7807)
* ✅ JWT Authentication
* ✅ Swagger (OpenAPI) with XML documentation
* ✅ Unit testing using xUnit and Moq

---

## 🛠️ Tech Stack

* .NET 8 Web API
* Entity Framework Core
* SQL Server
* xUnit & Moq (Unit Testing)
* Swagger / OpenAPI
* JWT Authentication

---

## 📂 Project Structure

```
FundAdmin.API
 ├── Controllers
 ├── Services
 ├── Repositories
 ├── DTOs
 ├── Models
 ├── Middleware
 ├── Data
 └── Program.cs

FundAdmin.Tests
 ├── Services
 └── Repositories
```

---

## ⚙️ Prerequisites

Make sure you have installed:

* .NET 8 SDK
* SQL Server (LocalDB / SQL Express / Full SQL Server)
* Visual Studio 2022+ or VS Code

---

## 📥 Setup Instructions

### 1️⃣ Clone Repository

```bash
git clone https://github.com/your-username/FundAdmin.git
cd FundAdmin
```

---

### 2️⃣ Configure Database

Update connection string in:

📁 `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=FundAdminDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

### 3️⃣ Run Migrations

Open Package Manager Console:

```bash
Add-Migration InitialCreate
Update-Database
```

👉 This will create database and tables automatically.

---

### 4️⃣ Run Application

```bash
dotnet run
```

OR press **F5** in Visual Studio

---

## 🔐 Authentication (JWT)

### 🔹 Login Endpoint

```
POST /api/auth/login
```

### 🔹 Mock Credentials

```
Username: admin
Password: password
```

### 🔹 Sample Request

```json
{
  "username": "admin",
  "password": "password"
}
```

---

### 🔹 Response

```json
{
  "token": "your-jwt-token"
}
```

---

## 🧪 Swagger Testing

Open Swagger:

```
https://localhost:xxxx/swagger
```

### Steps:

1. Call **/api/auth/login**
2. Copy token
3. Click **Authorize 🔐**
4. Enter:

```
Bearer your-token
```

5. Call secured APIs

---

## 📌 API Endpoints

### 🔹 Funds

* GET /api/funds
* GET /api/funds/{id}
* POST /api/funds
* PUT /api/funds/{id}
* DELETE /api/funds/{id}

---

### 🔹 Investors

* GET /api/investors
* POST /api/investors
* PUT /api/investors/{id}
* DELETE /api/investors/{id}

---

### 🔹 Transactions

* POST /api/transactions
* GET /api/transactions/investor/{investorId}
* GET /api/transactions/fund/{fundId}/summary

---

## ⚠️ Error Handling

All errors follow **RFC 7807 (ProblemDetails)** format:

```json
{
  "title": "Bad Request",
  "status": 400,
  "detail": "Validation failed"
}
```

---

## 🧪 Running Tests

```bash
dotnet test
```

Includes:

* Service layer tests (mocked using Moq)
* Repository tests (InMemory DB)

---

## 🔒 Security

* JWT Authentication
* HTTPS enforced
* Input validation using Data Annotations
* Centralised exception handling

---

## 📄 Documentation

* Swagger UI for API exploration
* XML comments for endpoint descriptions

---


## 🚀 Future Improvements

* AutoMapper integration
* Real user authentication (Now I have used hard-coded credentials)
* FluentValidation for request validation
* Structured logging with Serilog
* API versioning
* Health check endpoint
* Implementing bonus reporting features
* Docker support for containerization
* Environment-based configurations

---
