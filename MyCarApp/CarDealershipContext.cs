using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;


using System;

namespace MyCarApp.Models
{
    public class CarDealershipContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mycarapp.db");  // Gebruik hier eventueel een volledig pad
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Model = "Audi A3", Color = "Zwart", FuelTypeId = 1, Price = 20000 },
                new Car { Id = 2, Model = "BMW X5", Color = "Wit", FuelTypeId = 2, Price = 35000 }
            );

            modelBuilder.Entity<FuelType>().HasData(
                new FuelType { Id = 1, Name = "Benzine" },
                new FuelType { Id = 2, Name = "Diesel" },
                new FuelType { Id = 3, Name = "Elektrisch" }
            );
        }
    }
}