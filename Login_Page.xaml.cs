using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
                MessageBox.Show("Welkom gewone gebruiker");
                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new UserHomePage());
                return;
            }

            var driver = Database.Drivers.FirstOrDefault(d => d.Email == email);
            if (driver != null)
            {
                MessageBox.Show("Welkom chauffeur");
                ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new DriverHomePage());
                return;
            }

            MessageBox.Show("Foutieve inloggegevens.");
        }

        private void RegisterLink_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new RegisterDriver());
        }
    }
}

