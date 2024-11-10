using Microsoft.EntityFrameworkCore;
using MyCarApp.Models;
using MyCarApp.Models.MyCarApp.Models;


namespace MyCarApp.Models
{
    public class CarDealershipContext : DbContext
    {
     public DbSet <vehicle> Vehicles { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mycarapp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuelType>().HasData(
                new FuelType { Id = 1, Name = "Benzine" },
                new FuelType { Id = 2, Name = "Diesel" },
                new FuelType { Id = 3, Name = "Elektrisch" }
            );

            modelBuilder.Entity<vehicle>().HasData(
                new vehicle { Id = 1, Model = "Audi A3", Color = "Zwart", FuelTypeId = 1, Price = 20000 },
                new vehicle { Id = 2, Model = "BMW X5", Color = "Wit", FuelTypeId = 2, Price = 35000 }
            );
        }
    }

}
