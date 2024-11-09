using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MyCarApp.Models;

namespace MyCarApp.ViewModels
{
    public class CarViewModel : INotifyPropertyChanged
    {
        private readonly CarDealershipContext _context;
        private ObservableCollection<Car> _cars;
        private ObservableCollection<Car> _filteredCars;
        private string _modelFilter;
        private string _colorFilter;

        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set { _cars = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Car> FilteredCars
        {
            get => _filteredCars;
            set { _filteredCars = value; OnPropertyChanged(); }
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

        public CarViewModel()
        {
            _context = new CarDealershipContext();
            LoadCars();
        }

        private void LoadCars()
        {
            Cars = new ObservableCollection<Car>(_context.Cars.ToList());
            FilteredCars = new ObservableCollection<Car>(Cars);
        }

        private void ApplyFilters()
        {
            var filtered = _cars.Where(c =>
                (string.IsNullOrWhiteSpace(ModelFilter) || c.Model.Contains(ModelFilter)) &&
                (string.IsNullOrWhiteSpace(ColorFilter) || c.Color.Contains(ColorFilter))
            ).ToList();
            FilteredCars = new ObservableCollection<Car>(filtered);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
