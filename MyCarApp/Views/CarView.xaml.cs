using System.Windows;
using MyCarApp.Models;

namespace MyCarApp.Views
{
    public partial class CarView : Window
    {
        public CarView(Vehicle selectedCar)
        {
            InitializeComponent();
            DataContext = selectedCar; // Bind de geselecteerde auto aan de DataContext
        }
    }
}
