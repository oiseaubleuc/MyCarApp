using System.Collections.Generic;

namespace MyCarApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int FuelTypeId { get; set; }
        public decimal Price { get; set; }

        // Voeg deze eigenschappen toe
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public int ViewCount { get; set; }

        // Navigatie-eigenschap voor de relatie met FuelType
        public FuelType FuelType { get; set; }
    }
}

