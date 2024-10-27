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

using BCrypt.Net;
using System.Windows;



namespace MyCarApp
{
    public partial class Login : Window
    {
        private readonly string storedHashedPassword = "$2a$11$XjQYdpOfjjwVRLk8frvPeOvTfTRgqXESY2piY.HITz5jTFBgwC5S6"; 

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = UsernameTextBox.Text;
                string password = PasswordBox.Password;

                if (username == "ehbschool" && BCrypt.Net.BCrypt.Verify(password, storedHashedPassword))
                {
                    MessageBox.Show("Login succesvol!");
            
                 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ongeldige gebruikersnaam of wachtwoord.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Er is een fout opgetreden tijdens het inloggen: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
