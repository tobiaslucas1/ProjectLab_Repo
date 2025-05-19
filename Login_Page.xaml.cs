using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Test.Helpers;

namespace Test
{
    public partial class Login_Page : Page
    {
        public Login_Page()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailBox.Text;
            string password = PasswordBox.Password;

            // 🔐 Check user
            var user = Database.Users.FirstOrDefault(u => u.Email == email);
            if (user != null && HashHelper.VerifyPassword(password, user.Password))
            {
                Session.CurrentUser = user;
                Session.CurrentDriver = null;

                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new UserHomePage());
                return;
            }

            // 🔐 Check driver
            var driver = Database.Drivers.FirstOrDefault(d => d.Email == email);
            if (driver != null && HashHelper.VerifyPassword(password, driver.Password))
            {
                Session.CurrentDriver = driver;
                Session.CurrentUser = null;

                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new DriverHomePage());
                return;
            }

            MessageBox.Show("Foutieve inloggegevens.");
        }

        private void RegisterLink_Click(object sender, RoutedEventArgs e)
        {
            // ✅ Ga direct naar keuzepagina (in plaats van MessageBox)
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new ChooseRolePage());
        }

        private void Drive2Gether_Click(object sender, MouseButtonEventArgs e)
        {
            if (Session.CurrentUser != null)
                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new UserHomePage());
            else if (Session.CurrentDriver != null)
                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new DriverHomePage());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new SettingsPage());
        }
    }
}

