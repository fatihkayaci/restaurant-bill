using RestaurantBill.Core;
using RestaurantBill.Infrastructure.Context;

namespace RestaurantBill.Infrastructure.Seeds;

public static class DefaultData
{
    public static void Seed(RestaurantBillDbContext context)
    {
        // 1. CATEGORIES (If not exists)
        if (!context.Categories.Any())
        {
            context.Categories.AddRange(
                new Category { Name = "Main Courses" }, // Ana Yemekler
                new Category { Name = "Beverages" },    // İçecekler
                new Category { Name = "Desserts" }      // Tatlılar
            );
            context.SaveChanges();
        }

        // 2. PRODUCTS (If not exists - Fetch categories first)
        if (!context.Products.Any())
        {
            var mainCourse = context.Categories.FirstOrDefault(x => x.Name == "Main Courses");
            var beverage = context.Categories.FirstOrDefault(x => x.Name == "Beverages");
            var dessert = context.Categories.FirstOrDefault(x => x.Name == "Desserts");

            context.Products.AddRange(
                new Product { Name = "Grilled Meatballs", Price = 250, CategoryId = mainCourse.Id },
                new Product { Name = "Chicken Skewers", Price = 200, CategoryId = mainCourse.Id },
                new Product { Name = "Ayran", Price = 30, CategoryId = beverage.Id },
                new Product { Name = "Coke", Price = 40, CategoryId = beverage.Id },
                new Product { Name = "Rice Pudding", Price = 90, CategoryId = dessert.Id }
            );
            context.SaveChanges();
        }

        // 3. TABLES (If not exists)
        if (!context.Tables.Any())
        {
            context.Tables.AddRange(
                new Table { Name = "Table-1 (Empty)", Status = TableStatus.Available },
                new Table { Name = "Table-2 (Occupied)", Status = TableStatus.Occupied }, // Test Case: Active
                new Table { Name = "Garden-1 (Paid)", Status = TableStatus.Available }    // Test Case: Past
            );
            context.SaveChanges();
        }

        // 4. USERS (If not exists)
        if (!context.Users.Any())
        {
            context.Users.Add(new User
            {
                UserName = "admin",
                PasswordHash = "123", 
                Role = UserRole.Admin,
                FullName = "System Administrator",
            });
            context.SaveChanges();
        }

        // 5. ORDERS (The Critical Part for Testing)
        if (!context.Orders.Any())
        {
            // Fetch IDs needed for relationships
            var table2 = context.Tables.FirstOrDefault(x => x.Name == "Table-2 (Occupied)");
            var garden1 = context.Tables.FirstOrDefault(x => x.Name == "Garden-1 (Paid)");
            
            var meatballs = context.Products.FirstOrDefault(x => x.Name == "Grilled Meatballs");
            var ayran = context.Products.FirstOrDefault(x => x.Name == "Ayran");

            // SCENARIO 1: Table-2 is currently eating (ACTIVE ORDER)
            // You MUST see this data in Frontend.
            var activeOrder = new Order
            {
                TableId = table2.Id,
                Status = OrderStatus.Preparing, // Or Served
                TotalPrice = 530, // (2 Meatballs + 1 Ayran)
                CreatedAt = DateTime.Now,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = meatballs.Id, Quantity = 2, Price = 250 },
                    new OrderItem { ProductId = ayran.Id, Quantity = 1, Price = 30 }
                }
            };

            // SCENARIO 2: Garden-1 finished eating and left (PAST ORDER)
            // You MUST NOT see this data in Frontend active view.
            var paidOrder = new Order
            {
                TableId = garden1.Id,
                Status = OrderStatus.Paid, // Paid & Closed
                TotalPrice = 250,
                CreatedAt = DateTime.Now.AddHours(-2), 
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { ProductId = meatballs.Id, Quantity = 1, Price = 250 }
                }
            };

            context.Orders.AddRange(activeOrder, paidOrder);
            context.SaveChanges();
        }
    }
}