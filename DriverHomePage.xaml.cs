using System;
using System.Windows;
using System.Windows.Controls;

namespace Test
{
    public partial class DriverHomePage : Page
    {
        private User currentUser;

        public DriverHomePage(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new SettingsPage(currentUser));
        }

        private void CreateRoadTrip_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CreateRoadTripPage(currentUser));
        }

        private void OpenChat_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ChatPage(currentUser));
        }
    }
}
