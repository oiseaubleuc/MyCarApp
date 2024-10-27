using Microsoft.EntityFrameworkCore;
using MyCarApp.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        private void LoadCars()
        {
            using (var context = new CarDealershipContext())
            {
                _cars = context.Cars.ToList();
                UpdateCarListView();
            }
        }

        private void UpdateCarListView()
        {
            var carsToShow = _cars.Skip((_currentPage - 1) * _itemsPerPage).Take(_itemsPerPage).ToList();
            CarListView.ItemsSource = carsToShow;
            PageInfoTextBlock.Text = $"Pagina {_currentPage}";
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
            // Hier kun je de logica toevoegen om een nieuwe auto toe te voegen.
            AddCar addCarWindow = new AddCar();
            addCarWindow.ShowDialog();
            LoadCars(); // Vernieuw de lijst nadat je een auto hebt toegevoegd
        }
    }

}