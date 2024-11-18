// MenuGor.Infrastructure/Data/DbInitializer.cs
using MenuGor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BCrypt.Net;

namespace MenuGor.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task SeedData(MenuGorDbContext context)
        {
            await context.Database.MigrateAsync();

            if (!await context.Admins.AnyAsync())
            {
                var admin = new Admin
                {
                    Username = "admin@menugor.com", // Email'i username olarak kullanıyoruz
                    Email = "admin@menugor.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                    FirstName = "Admin",
                    LastName = "User",
                    IsActive = true,
                    CreatedBy = "System",
                    CreatedDate = System.DateTime.Now,
                    DeletedBy = "",
                    DeletedDate = null,
                    IsDeleted = false,
                    LastLoginDate = System.DateTime.Now,
                    UpdatedBy = "",
                    UpdatedDate = null
                };

                await context.Admins.AddAsync(admin);
                await context.SaveChangesAsync();
            }
        }
    }
}