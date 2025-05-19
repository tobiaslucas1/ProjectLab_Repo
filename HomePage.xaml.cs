using System;
using System.Windows;
using System.Windows.Controls;

namespace Test
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new Login_Page());
        }

        // ✅ Nieuw: Registreer als gebruiker
        private void UserRegister_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new RegisterPage());
        }

        // ✅ Nieuw: Registreer als bestuurder
        private void DriverRegister_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new RegisterDriver());
        }
    }
}
