using System.Collections.ObjectModel;
using MyCarApp.Models;

namespace MyCarApp.ViewModels
{
    public class CarViewModels
    {
        public ObservableCollection<Car> Cars { get; set; }

        private Car _selectedCar;
        public Car SelectedCar
        {
            get { return _selectedCar; }
            set { _selectedCar = value; }
        }

        public CarViewModels()
        {
            // Voeg testdata toe of haal data op uit de database
            Cars = new ObservableCollection<Car>
            {
                new Car { Model = "Toyota", Color = "Rood", FuelType = new FuelType { Name = "Benzine" }, Price = 10000 },
                new Car { Model = "Honda", Color = "Blauw", FuelType = new FuelType { Name = "Diesel" }, Price = 12000 }
            };

            // Stel een default geselecteerde auto in
            SelectedCar = Cars.FirstOrDefault(); // Zet de eerste auto in de lijst als standaard geselecteerde auto
        }
    }
}
