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
using System.Windows;
using MyCarApp.Models;

namespace AutoProject
{
    public partial class AddCustomer : Window
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void SaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            var newCustomer = new Customer
            {
                Name = NameTextBox.Text,
                Email = EmailTextBox.Text,
                Phone = PhoneTextBox.Text
            };

            using (var context = new CarDealershipContext())
            {
                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }

            MessageBox.Show("Bedankt voor je interesse! We nemen snel contact met je op.");
            this.Close();
        }
    }
}


