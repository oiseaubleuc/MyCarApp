using System.Collections.Generic;

namespace MyCarApp.Models
{
    using System;

    namespace MyCarApp.Models
    {
        public class vehicle
        {
            public int Id { get; set; }
            public string Model { get; set; }
            public string? Description { get; set; }
            public decimal Price { get; set; }

            public string Color { get; set; }
            public string Location { get; set; }
            public int? FuelTypeId { get; set; }
            public int Kilometerstand { get; set; }
            public int Year { get; set; }
            public string? ImagePath { get; set; } 

            public DateTime DatePosted { get; set; }
        }
    }


}

