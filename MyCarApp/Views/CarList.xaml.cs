using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MyCarApp.Models;
using MyCarApp.Models.MyCarApp.Models;

namespace MyCarApp.Views
{
    public partial class CarList : Window
    {
        private List<MyCarApp.Models.Vehicle> _postedCars;

        public CarList()
        {
            InitializeComponent();
            LoadPostedCars();
            CarListView.MouseDoubleClick += CarListView_MouseDoubleClick; // Dubbelklik event om detailweergave te openen
        }

        private void LoadPostedCars()
        {
            try
            {
                using (var context = new CarDealershipContext())
                {
                    _postedCars = context.Vehicles.Include(c => c.FuelType).ToList();
                }
                CarListView.ItemsSource = _postedCars; // Bind de lijst aan de ListView
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Fout bij het laden van auto's: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CarListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CarListView.SelectedItem is Vehicle selectedCar)
            {
                CarView carView = new CarView(selectedCar);
                carView.ShowDialog(); // Open het venster met gedetailleerde gegevens
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Filterlogica gebaseerd op zoekvelden
            var filteredCars = _postedCars.Where(c =>
                (string.IsNullOrWhiteSpace(ModelTextBox.Text) || c.Model.Contains(ModelTextBox.Text)) &&
                (string.IsNullOrWhiteSpace(LocationTextBox.Text) || c.Location.Contains(LocationTextBox.Text)) &&
                (MinPriceComboBox.SelectedItem == null || c.Price >= decimal.Parse((string)((ComboBoxItem)MinPriceComboBox.SelectedItem).Content)) &&
                (MaxPriceComboBox.SelectedItem == null || c.Price <= decimal.Parse((string)((ComboBoxItem)MaxPriceComboBox.SelectedItem).Content)) &&
                (MinKilometerstandComboBox.SelectedItem == null || c.Kilometerstand >= int.Parse((string)((ComboBoxItem)MinKilometerstandComboBox.SelectedItem).Content)) &&
                (MaxKilometerstandComboBox.SelectedItem == null || c.Kilometerstand <= int.Parse((string)((ComboBoxItem)MaxKilometerstandComboBox.SelectedItem).Content)) &&
                (MinJaarComboBox.SelectedItem == null || c.Year >= int.Parse((string)((ComboBoxItem)MinJaarComboBox.SelectedItem).Content)) &&
                (MaxJaarComboBox.SelectedItem == null || c.Year <= int.Parse((string)((ComboBoxItem)MaxJaarComboBox.SelectedItem).Content))
            ).ToList();

            CarListView.ItemsSource = filteredCars; // Update ListView met gefilterde resultaten
        }
    }
}
