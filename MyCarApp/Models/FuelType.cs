

using System.Collections.Generic;

namespace MyCarApp.Models
{
    public class FuelType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigatie-eigenschap voor de relatie terug naar Car
        public ICollection<Car> Cars { get; set; }
    }
}
