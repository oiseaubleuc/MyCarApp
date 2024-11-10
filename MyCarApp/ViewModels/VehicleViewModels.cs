using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MyCarApp.Models;
using MyCarApp.Models.MyCarApp.Models;

namespace MyCarApp.ViewModels
{
    public class VehicleViewModel : INotifyPropertyChanged
    {
        private readonly CarDealershipContext _context;
        private ObservableCollection<Vehicle> _vehicles;
        private ObservableCollection<Vehicle> _filteredVehicles;
        private string _modelFilter;
        private string _colorFilter;

        public ObservableCollection<Vehicle> Vehicles
        {
            get => _vehicles;
            set { _vehicles = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Vehicle> FilteredVehicles
        {
            get => _filteredVehicles;
            set { _filteredVehicles = value; OnPropertyChanged(); }
        }

        public string ModelFilter
        {
            get => _modelFilter;
            set { _modelFilter = value; ApplyFilters(); }
        }

        public string ColorFilter
        {
            get => _colorFilter;
            set { _colorFilter = value; ApplyFilters(); }
        }

        public VehicleViewModel()
        {
            _context = new CarDealershipContext();
            LoadVehicles();
        }

        private void LoadVehicles()
        {
            Vehicles = new ObservableCollection<Vehicle>(_context.Vehicles.ToList());
            FilteredVehicles = new ObservableCollection<Vehicle>(Vehicles);
        }

        private void ApplyFilters()
        {
            var filtered = _vehicles.Where(v =>
                (string.IsNullOrWhiteSpace(ModelFilter) || v.Model.Contains(ModelFilter)) &&
                (string.IsNullOrWhiteSpace(ColorFilter) || v.Color.Contains(ColorFilter))
            ).ToList();
            FilteredVehicles = new ObservableCollection<Vehicle>(filtered);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
