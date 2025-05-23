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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Test
{
    public partial class ChangePasswordPage : Page
    {
        private User currentUser;

        public ChangePasswordPage(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void SaveNewPassword_Click(object sender, RoutedEventArgs e)
        {
            string newPassword = NewPasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword != confirmPassword)
            {
                MessageBox.Show("Wachtwoorden komen niet overeen of zijn leeg.");
                return;
            }

            currentUser.Password = newPassword;
            MessageBox.Show("Wachtwoord succesvol gewijzigd.");
            NavigationService.Navigate(new SettingsPage(currentUser));
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new SettingsPage(currentUser));
        }
    }
}

