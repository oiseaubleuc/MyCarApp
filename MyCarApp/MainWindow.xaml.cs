﻿using Microsoft.EntityFrameworkCore;
using MyCarApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Microsoft.EntityFrameworkCore;
using MyCarApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new CarViewModel();
                LoadCars();
                SetupFilters();
            }
        }

        private void LoadCars()
        {
            try
            {
                using (var context = new CarDealershipContext())
                {
                    _cars = context.Cars.Include(c => c.FuelType).ToList();
                }
                UpdateCarListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij het laden van auto's: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateCarListView()
        {
            try
            {
                var carsToShow = _cars.Skip((_currentPage - 1) * _itemsPerPage).Take(_itemsPerPage).ToList();
                CarListView.ItemsSource = carsToShow;
                PageInfoTextBlock.Text = $"Pagina {_currentPage} van {(_cars.Count + _itemsPerPage - 1) / _itemsPerPage}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij het updaten van de lijst: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            try
            {
                AddCar addCarWindow = new AddCar();
                addCarWindow.ShowDialog();
                LoadCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij het toevoegen van een auto: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetupFilters()
        {
            try
            {
                ModelFilterTextBox.TextChanged += ModelFilterTextBox_TextChanged;
                ColorFilterTextBox.TextChanged += ColorFilterTextBox_TextChanged;
                FuelTypeFilterComboBox.SelectionChanged += FuelTypeFilterComboBox_SelectionChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij het instellen van filters: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ModelFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterCars();
        }

        private void ColorFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterCars();
        }

        private void FuelTypeFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterCars();
        }

        private void FilterCars()
        {
            try
            {
                var selectedFuelType = FuelTypeFilterComboBox.SelectedItem as ComboBoxItem;
                string fuelType = selectedFuelType?.Content.ToString();

                var filteredCars = _cars.Where(c =>
                    (string.IsNullOrWhiteSpace(ModelFilterTextBox.Text) || c.Model.Contains(ModelFilterTextBox.Text)) &&
                    (string.IsNullOrWhiteSpace(ColorFilterTextBox.Text) || c.Color.Contains(ColorFilterTextBox.Text)) &&
                    (FuelTypeFilterComboBox.SelectedIndex == 0 || c.FuelType.Name == fuelType)).ToList();

                CarListView.ItemsSource = filteredCars.Skip((_currentPage - 1) * _itemsPerPage).Take(_itemsPerPage).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fout bij het filteren van auto's: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

