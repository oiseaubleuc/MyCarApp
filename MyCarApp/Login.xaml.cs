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
        // Replace with your hashed password
        private readonly string storedHashedPassword = "$2a$11$XjQYdpOfjjwVRLk8frvPeOvTfTRgqXESY2piY.HITz5jTFBgwC5S6"; // Hashed "framework123"

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Check username and password
            if (username == "ehbschool" && BCrypt.Verify(password, storedHashedPassword))
            {
                MessageBox.Show("Login succesvol!");
                AdminPage adminPage = new AdminPage(); // Assuming AdminPage is the name of the admin window
                adminPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ongeldige gebruikersnaam of wachtwoord.");
            }
        }
    }
}