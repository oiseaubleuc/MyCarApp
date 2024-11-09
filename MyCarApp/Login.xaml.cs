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
using BCrypt.Net;
using MyCarApp.Models;

using MyCarApp.Views;
using MyCarApp.ViewModels;


namespace MyCarApp
{
    public partial class Login : Window
    {
        private readonly CarDealershipContext _context;

        public Login()
        {
            InitializeComponent();
            _context = new CarDealershipContext();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Haal de ingevoerde gebruikersnaam en wachtwoord op
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Valideer invoervelden
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vul zowel de gebruikersnaam als het wachtwoord in.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Probeer de login
            try
            {
                // Zoek de gebruiker in de database op basis van gebruikersnaam
                var user = _context.Users.FirstOrDefault(u => u.Username == username);

                // Controleer of de gebruiker bestaat en het wachtwoord correct is
                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    MessageBox.Show("Login succesvol!");

                    // Open het dashboard na een succesvolle login
                    var dashboard = new DashboardWindow();
                    dashboard.Show();

                    // Sluit het loginvenster
                    this.Close();
                }
                else
                {
                    // Login mislukt
                    MessageBox.Show("Ongeldige gebruikersnaam of wachtwoord.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden tijdens het inloggen: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Methode om een nieuwe gebruiker te registreren en het wachtwoord te hashen
        public void RegisterUser(string username, string password)
        {
            // Valideer invoervelden
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Gebruikersnaam en wachtwoord zijn vereist.", "Waarschuwing", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Controleer of de gebruikersnaam al bestaat
                if (_context.Users.Any(u => u.Username == username))
                {
                    MessageBox.Show("Deze gebruikersnaam is al in gebruik. Kies een andere gebruikersnaam.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Hash het wachtwoord met BCrypt
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                // Maak een nieuwe gebruiker aan en sla deze op in de database
                var newUser = new User { Username = username, Password = hashedPassword };
                _context.Users.Add(newUser);
                _context.SaveChanges();

                MessageBox.Show("Gebruiker succesvol geregistreerd!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden tijdens de registratie: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
