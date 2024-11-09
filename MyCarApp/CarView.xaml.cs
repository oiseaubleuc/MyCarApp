using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using MyCarApp.Models;

using System.Collections.ObjectModel;
using MyCarApp.Models;

namespace MyCarApp.ViewModels
{
    public class CarViewModel
    {
        public ObservableCollection<Car> Cars { get; set; }

        private Car _selectedCar;
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set { _selectedCar = value; }
        }

        public CarViewModel()
        {
            // Voeg testdata toe of haal data op uit de database
            Cars = new ObservableCollection<Car>
            {
                new Car { Model = "Toyota", Color = "Rood", FuelType = new FuelType { Name = "Benzine" }, Price = 10000 },
                new Car { Model = "Honda", Color = "Blauw", FuelType = new FuelType { Name = "Diesel" }, Price = 12000 }
            };

            // Stel een default geselecteerde auto in
            SelectedCar = Car[0];
        }
    }
}

