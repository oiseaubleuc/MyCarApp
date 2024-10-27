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

using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MyCarApp.Models;

namespace AutoProject
{
    public partial class CarList : Window
    {
        public ObservableCollection<Car> Cars { get; set; }

        public CarList()
        {
            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {
            using (var context = new CarDealershipContext())
            {
                Cars = new ObservableCollection<Car>(context.Cars.ToList());
                CarListView.ItemsSource = Cars;
            }
        }
    }
}
