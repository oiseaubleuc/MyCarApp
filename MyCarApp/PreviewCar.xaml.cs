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

using MyCarApp.Models;

namespace MyCarApp
{
    public partial class PreviewCar : Window
    {
        public PreviewCar(Car car)
        {
            InitializeComponent();
            DataContext = car;

            // Toon de afbeelding als er een afbeeldingspad is ingevoerd
            if (!string.IsNullOrEmpty(car.ImagePath))
            {
                CarImage.Source = new BitmapImage(new Uri(car.ImagePath));
            }
        }
    }
}
