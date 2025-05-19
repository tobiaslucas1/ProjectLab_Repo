using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Test
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User
            {
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                Email = EmailBox.Text,
                Password = PasswordBox.Password
            };

            Database.Users.Add(newUser);
            MessageBox.Show($"Gebruiker {newUser.FirstName} is geregistreerd.");
            NavigationService.Navigate(new Login_Page());
        }

        private void Drive2Gether_Click(object sender, MouseButtonEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new UserHomePage());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new SettingsPage());
        }
    }
}
