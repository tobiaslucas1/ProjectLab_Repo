using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Test.Helpers;

namespace Test
{
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string hashedPassword = HashHelper.HashPassword(PasswordBox.Password);

            User newUser = new User
            {
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                Email = EmailBox.Text,
                Password = hashedPassword // ✅ hashed opgeslagen
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

