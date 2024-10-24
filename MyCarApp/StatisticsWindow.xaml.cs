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

using LiveCharts;
using LiveCharts.Wpf;
using System.Linq;
using System.Windows;
using MyCarApp.Models;

namespace MyCarApp
{
    public partial class StatisticsWindow : Window
    {
        public SeriesCollection CarViewValues { get; set; }
        public string[] CarLabels { get; set; }
        public Func<double, string> Formatter { get; set; }

        private readonly CarDealershipContext _context;

        public StatisticsWindow()
        {
            InitializeComponent();
            _context = new CarDealershipContext();
            LoadCarViewData();
            DataContext = this;
        }

        private void LoadCarViewData()
        {
            var topViewedCars = _context.Cars
                                        .OrderByDescending(c => c.ViewCount)
                                        .Take(5)
                                        .ToList();

            CarViewValues = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<int>(topViewedCars.Select(c => c.ViewCount))
                }
            };

            CarLabels = topViewedCars.Select(c => c.Model).ToArray();
            Formatter = value => value.ToString("N");
        }
    }
}
