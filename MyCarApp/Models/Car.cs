using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;  // Standaardwaarde
        public string Color { get; set; } = string.Empty;  // Standaardwaarde
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;  // Standaardwaarde
        public string ImagePath { get; set; } = string.Empty;  // Standaardwaarde
        public int ViewCount { get; set; }  // Aantal weergaven voor statistieken

        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}