using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

using System.Collections.ObjectModel;
using System.Linq;

namespace MyCarApp.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalCars { get; set; }
        public decimal AverageCarPrice { get; set; }
        public ObservableCollection<CarStatistics> CarStatistics { get; set; }

        public DashboardViewModel()
        {
            // Voorbeelddata. Vervang dit door echte data uit de database.
            CarStatistics = new ObservableCollection<CarStatistics>
            {
                new CarStatistics { Model = "Audi A3", Color = "Zwart", Views = 120, Price = 20000 },
                new CarStatistics { Model = "BMW X5", Color = "Wit", Views = 85, Price = 35000 }
            };

            TotalCars = CarStatistics.Count;
            AverageCarPrice = CarStatistics.Average(car => car.Price);
        }
    }

    public class CarStatistics
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Views { get; set; }
        public decimal Price { get; set; }
    }


}
