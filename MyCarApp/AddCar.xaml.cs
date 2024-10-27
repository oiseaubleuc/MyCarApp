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

using Microsoft.Win32;
using System.Windows;
using MyCarApp.Models;

namespace MyCarApp
{
    public partial class AddCar : Window
    {
        private readonly CarDealershipContext _context;

        public AddCar()
        {
            InitializeComponent();
            _context = new CarDealershipContext();
            LoadFuelTypesAndCategories();
        }

        
        private void LoadFuelTypesAndCategories()
        {
            try
            {
                FuelTypeComboBox.ItemsSource = _context.FuelTypes.ToList();
                CategoryComboBox.ItemsSource = _context.Categories.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij het laden van brandstoftypes of categorieën: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.png)|*.jpg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                ImagePathTextBox.Text = openFileDialog.FileName;
            }
        }

        
        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    var car = new Car
                    {
                        Model = ModelTextBox.Text,
                        Color = ColorTextBox.Text,
                        Price = decimal.Parse(PriceTextBox.Text),
                        Description = DescriptionTextBox.Text,
                        ImagePath = ImagePathTextBox.Text,
                        FuelTypeId = (FuelTypeComboBox.SelectedItem as FuelType)?.Id ?? 0,
                        CategoryId = (CategoryComboBox.SelectedItem as Category)?.Id ?? 0
                    };

                    _context.Cars.Add(car);
                    _context.SaveChanges();
                    MessageBox.Show("Auto succesvol toegevoegd!", "Informatie", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij het toevoegen van de auto: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(ModelTextBox.Text) ||
                string.IsNullOrWhiteSpace(ColorTextBox.Text) ||
                string.IsNullOrWhiteSpace(PriceTextBox.Text) ||
                !decimal.TryParse(PriceTextBox.Text, out _) ||
                FuelTypeComboBox.SelectedItem == null ||
                CategoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Alle velden moeten worden ingevuld en de prijs moet een geldig getal zijn.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}