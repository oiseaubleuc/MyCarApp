using System.Windows;
using Microsoft.Win32;
using MyCarApp.Models;

namespace MyCarApp.Views
{
    public partial class AddCar : Window
    {
        public AddCar()
        {
            InitializeComponent();
        }

        private void ChooseImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a file dialog for selecting an image
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Set the selected file path in the ImagePathTextBox
                ImagePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new CarDealershipContext())
                {
                    // Create a new car instance with provided data
                    var newCar = new Car
                    {
                        Model = ModelTextBox.Text,
                        Description = DescriptionTextBox.Text,
                        Color = ColorTextBox.Text,
                        Location = LocationTextBox.Text,
                        FuelType = FuelTypeComboBox.Text,
                        Kilometerstand = int.Parse(KilometerstandTextBox.Text),
                        Year = int.Parse(YearTextBox.Text),
                        ImagePath = ImagePathTextBox.Text,  // Save the image path
                    };

                    // Add the car to the database and save
                    context.Cars.Add(newCar);
                    context.SaveChanges();

                    MessageBox.Show("Auto succesvol toegevoegd!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Close the window after adding the car
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij het toevoegen van de auto: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
