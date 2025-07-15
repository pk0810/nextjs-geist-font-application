using Microsoft.EntityFrameworkCore;
using WebAppMVC.Data;
using WebAppMVC.Models;

namespace WebAppMVC.Services
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context, IAuthService authService)
        {
            // Ensure database is created
            await context.Database.EnsureCreatedAsync();

            // Check if users already exist
            if (await context.Users.AnyAsync())
            {
                return; // Database has been seeded
            }

            // Create demo users
            var demoUsers = new List<User>
            {
                new User
                {
                    Username = "admin",
                    Email = "admin@webappmvc.com",
                    FirstName = "Admin",
                    LastName = "User",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Username = "demo",
                    Email = "demo@webappmvc.com",
                    FirstName = "Demo",
                    LastName = "User",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new User
                {
                    Username = "testuser",
                    Email = "test@webappmvc.com",
                    FirstName = "Test",
                    LastName = "User",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            };

            // Add users with hashed passwords
            foreach (var user in demoUsers)
            {
                string password = user.Username == "admin" ? "admin123" : "password123";
                await authService.RegisterAsync(user, password);
            }

            Console.WriteLine("Database seeded successfully!");
            Console.WriteLine("Demo credentials:");
            Console.WriteLine("Username: admin, Password: admin123");
            Console.WriteLine("Username: demo, Password: password123");
            Console.WriteLine("Username: testuser, Password: password123");
        }
    }
}
