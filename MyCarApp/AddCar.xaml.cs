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

        // Laad brandstoftypes en categorieën
        private void LoadFuelTypesAndCategories()
        {
            FuelTypeComboBox.ItemsSource = _context.FuelTypes.ToList();
            CategoryComboBox.ItemsSource = _context.Categories.ToList();
        }

        // Methode om een afbeelding toe te voegen
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

        // Auto toevoegen
        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            var car = new Car
            {
                Model = ModelTextBox.Text,
                Color = ColorTextBox.Text,
                Price = decimal.Parse(PriceTextBox.Text),
                Description = DescriptionTextBox.Text,
                ImagePath = ImagePathTextBox.Text,
                FuelTypeId = (FuelTypeComboBox.SelectedItem as FuelType).Id,
                CategoryId = (CategoryComboBox.SelectedItem as Category).Id
            };

            _context.Cars.Add(car);
            _context.SaveChanges();
            MessageBox.Show("Auto succesvol toegevoegd!");
            this.Close();
        }
    }
}
