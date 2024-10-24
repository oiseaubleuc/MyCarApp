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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void CarDetails_Click(object sender, RoutedEventArgs e)
        {
            var selectedCar = (Car)CarListView.SelectedItem;
            if (selectedCar != null)
            {
                selectedCar.ViewCount++;
                _context.SaveChanges();

                CarDetailsWindow detailsWindow = new CarDetailsWindow(selectedCar);
                detailsWindow.ShowDialog();
            }
        }

    }
}