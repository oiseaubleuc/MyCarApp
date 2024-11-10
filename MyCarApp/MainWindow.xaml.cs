using Microsoft.EntityFrameworkCore;
using MyCarApp.Models;
using MyCarApp.Models.MyCarApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyCarApp
{
    public partial class MainWindow : Window
    {
        private int _currentPage = 1;
        private const int _itemsPerPage = 10;
        private List<vehicle> _vehicles;

        public MainWindow()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            try
            {
                using (var context = new CarDealershipContext())
                {
                    _vehicles = context.Vehicles.Include(c => c.FuelTypeId).ToList();
                }
                UpdateCarListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij het laden van auto's: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateCarListView()
        {
            var carsToShow = _vehicles.Skip((_currentPage - 1) * _itemsPerPage).Take(_itemsPerPage).ToList();
            // Je kunt hier een ListView of andere controle instellen om auto's te tonen.
            // Bijvoorbeeld: CarListView.ItemsSource = carsToShow;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            FilterCars();
        }

        private void FilterCars()
        {
            // Deze functie past de filters toe op basis van de invoerwaarden uit de TextBoxen en ComboBoxen.
            var minPrice = GetComboBoxValueAsInt(MinPriceComboBox);
            var maxPrice = GetComboBoxValueAsInt(MaxPriceComboBox);
            var minKm = GetComboBoxValueAsInt(MinKilometerstandComboBox);
            var maxKm = GetComboBoxValueAsInt(MaxKilometerstandComboBox);
            var minYear = GetComboBoxValueAsInt(MinJaarComboBox);
            var maxYear = GetComboBoxValueAsInt(MaxJaarComboBox);

            var filteredCars = _vehicles.Where(c =>
                (string.IsNullOrWhiteSpace(ModelTextBox.Text) || c.Model.Contains(ModelTextBox.Text)) &&
                (string.IsNullOrWhiteSpace(LocationTextBox.Text) || c.Location.Contains(LocationTextBox.Text)) &&
                (!minPrice.HasValue || c.Price >= minPrice) &&
                (!maxPrice.HasValue || c.Price <= maxPrice) &&
                (!minKm.HasValue || c.Kilometerstand >= minKm) &&
                (!maxKm.HasValue || c.Kilometerstand <= maxKm) &&
                (!minYear.HasValue || c.Jaar >= minYear) &&
                (!maxYear.HasValue || c.Jaar <= maxYear)
            ).ToList();

            // Update de UI met de gefilterde resultaten
            // CarListView.ItemsSource = filteredCars;
        }

        private int? GetComboBoxValueAsInt(ComboBox comboBox)
        {
            if (comboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                int.TryParse(selectedItem.Content.ToString(), out int value);
                return value;
            }
            return null;
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                UpdateCarListView();
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage * _itemsPerPage < _vehicles.Count)
            {
                _currentPage++;
                UpdateCarListView();
            }
        }
    }
}
