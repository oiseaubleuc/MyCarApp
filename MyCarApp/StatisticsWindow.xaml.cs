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

using System;
using System.Linq;
using System.Windows;
using MyCarApp.Models;

using System;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using MyCarApp.Models;

namespace MyCarApp.Views
{
    public partial class StatisticsWindow : Window
    {
        public ObservableCollection<Car> TopViewedCars { get; set; }
        private readonly CarDealershipContext _context;

        public StatisticsWindow()
        {
            InitializeComponent();
            _context = new CarDealershipContext();
            LoadCarViewData();
            DataContext = this; // Bind de data aan de View
        }

        private void LoadCarViewData()
        {
            // Haal de top 5 meest bekeken auto's op
            var topViewedCars = _context.Cars
                                        .OrderByDescending(c => c.ViewCount)
                                        .Take(5)
                                        .ToList();

            // Controleer of er auto's zijn om te tonen
            if (!topViewedCars.Any())
            {
                MessageBox.Show("Er zijn geen gegevens beschikbaar om weer te geven.", "Geen Data", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Voeg de top 5 auto's toe aan de collectie voor de DataGrid
            TopViewedCars = new ObservableCollection<Car>(topViewedCars);
        }
    }
}
