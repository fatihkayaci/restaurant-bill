# 🍽️ Restaurant Order API (Backend)

This is the backend service for the Restaurant Management System, built with **.NET 9** and **Clean Architecture** principles. It handles table management, order processing, and product inventory.

## 🚀 Tech Stack

* **Framework:** .NET 9 (WebAPI)
* **Database:** PostgreSQL
* **Containerization:** Docker
* **ORM:** Entity Framework Core
* **Architecture:** Clean Architecture & Generic Repository Pattern
* **Documentation:** Swagger / OpenAPI

## 🛠️ Getting Started

### Prerequisites

* .NET 9 SDK
* Docker Desktop

### 1. Database Setup

Ensure Docker is running and start the PostgreSQL container:

```bash
docker start restoran-db

# Or create a new one:
docker run --name restoran-db -e POSTGRES_PASSWORD=12345 -p 5432:5432 -d postgres
```

### 2. Apply Migrations

Navigate to the project root and run:

```bash
dotnet ef database update --project RestaurantBill.Infrastructure --startup-project RestaurantBill.WebAPI
```

### 3. Run the Application

```bash
cd RestaurantBill.WebAPI
dotnet run
```

Access the API documentation at: `http://localhost:<PORT>/swagger`

## ✅ Key Features

- [x] **Category Management:** CRUD operations for menu categories.
- [x] **Product Management:** Add products with prices and descriptions.
- [x] **Table Management:** Create tables and track occupancy.
- [x] **Order System:** Open checks for tables and add items dynamically.
- [x] **Smart Pricing:** Automatically fetches unit prices from the product catalog when adding items to an order.