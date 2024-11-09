

using BCrypt.Net;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyCarApp.Models
{
    public class CarDealershipContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=mycarapp.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data voor FuelTypes
            modelBuilder.Entity<FuelType>().HasData(
                new FuelType { Id = 1, Name = "Benzine" },
                new FuelType { Id = 2, Name = "Diesel" },
                new FuelType { Id = 3, Name = "Elektrisch" }
            );

            // Seed data voor Cars
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Model = "Audi A3", Color = "Zwart", FuelTypeId = 1, Price = 20000 },
                new Car { Id = 2, Model = "BMW X5", Color = "Wit", FuelTypeId = 2, Price = 35000 }
            );

            // Seed data voor Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "ehbschool", Password = BCrypt.Net.BCrypt.HashPassword("password123") }
            );
        }
    }

  
    
}
