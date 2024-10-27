using Microsoft.EntityFrameworkCore;
using MyCarApp.Models;
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
        private List<Car> _cars;

        public MainWindow()
        {
            InitializeComponent();
            LoadCars();
            SetupFilters();
        }

        private void LoadCars()
        {
            using (var context = new CarDealershipContext())
            {
                _cars = context.Cars.Include(c => c.FuelType).ToList();
                UpdateCarListView();
            }
        }

        private void UpdateCarListView()
        {
            var carsToShow = _cars.Skip((_currentPage - 1) * _itemsPerPage).Take(_itemsPerPage).ToList();
            CarListView.ItemsSource = carsToShow;
            PageInfoTextBlock.Text = $"Pagina {_currentPage} van {(_cars.Count + _itemsPerPage - 1) / _itemsPerPage}";
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
            if (_currentPage * _itemsPerPage < _cars.Count)
            {
                _currentPage++;
                UpdateCarListView();
            }
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            AddCar addCarWindow = new AddCar();
            addCarWindow.ShowDialog();
            LoadCars();
        }

        private void SetupFilters()
        {
            ModelFilterTextBox.TextChanged += (s, e) => FilterCars();
            ColorFilterTextBox.TextChanged += (s, e) => FilterCars();
            FuelTypeFilterComboBox.SelectionChanged += (s, e) => FilterCars();
        }

        private void FilterCars()
        {
            var selectedFuelType = FuelTypeFilterComboBox.SelectedItem as ComboBoxItem;
            string fuelType = selectedFuelType?.Content.ToString();

            var filteredCars = _cars.Where(c =>
                (string.IsNullOrWhiteSpace(ModelFilterTextBox.Text) || c.Model.Contains(ModelFilterTextBox.Text)) &&
                (string.IsNullOrWhiteSpace(ColorFilterTextBox.Text) || c.Color.Contains(ColorFilterTextBox.Text)) &&
                (FuelTypeFilterComboBox.SelectedIndex == 0 || c.FuelType.Name == fuelType)).ToList();

            CarListView.ItemsSource = filteredCars.Skip((_currentPage - 1) * _itemsPerPage).Take(_itemsPerPage).ToList();
        }
    }
}
