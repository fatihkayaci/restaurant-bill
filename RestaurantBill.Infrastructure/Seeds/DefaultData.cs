using RestaurantBill.Core;
using RestaurantBill.Infrastructure.Context;

namespace RestaurantBill.Infrastructure.Seeds;

public static class DefaultData
{
    public static void Seed(RestaurantBillDbContext context)
    {
        // 1. Önce Masalara bak, hiç masa yoksa ekle
        if (!context.Tables.Any())
        {
            context.Tables.AddRange(
                new Table { Name = "Masa-1", Status = TableStatus.Available },
                new Table { Name = "Masa-2", Status = TableStatus.Available },
                new Table { Name = "Bahçe-1", Status = TableStatus.Available }
            );
            context.SaveChanges();
        }

        // 2. Kullanıcılara bak, hiç kullanıcı yoksa ekle
        if (!context.Users.Any())
        {
            context.Users.Add(new User
            {
                UserName = "admin",
                PasswordHash = "123", // Gerçek hayatta şifrelenmeli ama şimdilik böyle kalsın
                Role = UserRole.Admin,
                FullName = "Sistem Yöneticisi",
            });
            context.SaveChanges();
        }
        
        // 3. Kategorilere bak (Bunu zaten test etmiştin ama dursun)
        if (!context.Categories.Any())
        {
             context.Categories.Add(new Category { Name = "Başlangıçlar" });
             context.SaveChanges();
        }
    }
}