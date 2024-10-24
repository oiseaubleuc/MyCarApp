using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace MyCarApp.Models
{
    public class FuelType
    {
        public int Id { get; set; }
        public string Name { get; set; }  // Benzine, Diesel, Elektrisch
        public ICollection<Car> Cars { get; set; }  // Een brandstoftype kan meerdere auto's hebben
    }
}