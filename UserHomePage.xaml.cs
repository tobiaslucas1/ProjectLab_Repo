using System.Windows;
using System.Windows.Controls;

namespace Test
{
    public partial class UserHomePage : Page
    {
        private User currentUser;

        public UserHomePage(User user)
        {
            InitializeComponent();
            currentUser = user;

            // Zet de ItemsSource van de ListView gelijk aan de lijst van RoadTrips uit de Database
            RoadTripListView.ItemsSource = Database.RoadTrips;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SettingsPage(currentUser));
        }
    }
}
