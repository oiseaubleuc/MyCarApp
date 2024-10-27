using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.Models
{
    public class Customer
    {
        public int Id { get; set; }          // Primaire sleutel
        public string Name { get; set; }     // Naam van de klant
        public string Email { get; set; }    // E-mail van de klant
        public string Phone { get; set; }    // Telefoonnummer van de klant
    }
}
