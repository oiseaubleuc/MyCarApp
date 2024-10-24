using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace MyCarApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }  // Naam van de categorie (bijv. SUV, Sedan)
        public ICollection<Car> Cars { get; set; }  // Een categorie kan meerdere auto's hebben
    }
}
