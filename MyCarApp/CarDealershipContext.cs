using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;


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
            optionsBuilder.UseSqlite("Data Source=mycarapp.db");
        }
    }
}