using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Windows.Input;

using MyCarApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace MyCarApp.ViewModels
{
    public class CarViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Car> _cars;
        private ObservableCollection<Car> _filteredCars;
        private string _modelFilter;
        private string _colorFilter;
        private string _fuelTypeFilter;

        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Car> FilteredCars
        {
            get => _filteredCars;
            set
            {
                _filteredCars = value;
                OnPropertyChanged();
            }
        }

        public string ModelFilter
        {
            get => _modelFilter;
            set
            {
                _modelFilter = value;
                OnPropertyChanged();
                ApplyFilters();
            }
        }

        public string ColorFilter
        {
            get => _colorFilter;
            set
            {
                _colorFilter = value;
                OnPropertyChanged();
                ApplyFilters();
            }
        }

        public string FuelTypeFilter
        {
            get => _fuelTypeFilter;
            set
            {
                _fuelTypeFilter = value;
                OnPropertyChanged();
                ApplyFilters();
            }
        }

        public CarViewModel()
        {
            // Laad auto's vanuit de database (dit kan aangepast worden voor je context)
            LoadCars();
            FilteredCars = new ObservableCollection<Car>(_cars);
        }

        private void LoadCars()
        {
            using (var context = new CarDealershipContext())
            {
                Cars = new ObservableCollection<Car>(context.Cars.ToList());
            }
        }

        private void ApplyFilters()
        {
            var filtered = _cars.Where(c =>
                (string.IsNullOrWhiteSpace(ModelFilter) || c.Model.Contains(ModelFilter)) &&
                (string.IsNullOrWhiteSpace(ColorFilter) || c.Color.Contains(ColorFilter)) &&
                (string.IsNullOrWhiteSpace(FuelTypeFilter) || c.FuelType.Name == FuelTypeFilter)).ToList();

            FilteredCars = new ObservableCollection<Car>(filtered);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}


