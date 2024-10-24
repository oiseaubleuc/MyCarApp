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

namespace MyCarApp
{
    public partial class ImageGallery : Window
    {
        private List<string> _imagePaths;
        private int _currentImageIndex = 0;

        public ImageGallery(List<string> imagePaths)
        {
            InitializeComponent();
            _imagePaths = imagePaths;
            ShowImage();
        }

        private void ShowImage()
        {
            CarImage.Source = new BitmapImage(new Uri(_imagePaths[_currentImageIndex]));
        }

        private void NextImage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentImageIndex < _imagePaths.Count - 1)
                _currentImageIndex++;
            ShowImage();
        }

        private void PreviousImage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentImageIndex > 0)
                _currentImageIndex--;
            ShowImage();
        }
    }
}
    
