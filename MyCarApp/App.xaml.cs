using System.Configuration;
using System.Data;
using System.Windows;

namespace MyCarApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Login loginWindow = new Login();
            loginWindow.Show();
        }
    }
}

