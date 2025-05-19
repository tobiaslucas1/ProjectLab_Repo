using System;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

            var user = Database.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                Session.CurrentUser = user;
                Session.CurrentDriver = null;

                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new UserHomePage());
                return;
            }

            var driver = Database.Drivers.FirstOrDefault(d => d.Email == email);
            if (driver != null)
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
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new RegisterDriver());
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
