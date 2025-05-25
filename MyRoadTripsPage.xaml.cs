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
    public partial class MyRoadTripsPage : Page
    {
        public MyRoadTripsPage()
        {
            InitializeComponent();
            LoadMyRoadTrips();
        }

        private void LoadMyRoadTrips()
        {
            var roadtrips = Database.RoadTrips
                .Where(rt => rt.Driver == Database.CurrentUser)
                .ToList();

            MyRoadTripsListView.ItemsSource = roadtrips;
        }

        private void DeleteRoadTrip_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is RoadTrip roadtrip)
            {
                var result = MessageBox.Show("Ben je zeker dat je deze roadtrip wilt verwijderen?", "Bevestiging", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Database.RoadTrips.Remove(roadtrip);
                    LoadMyRoadTrips(); // refresh view
                    MessageBox.Show("Roadtrip verwijderd.");
                }
            }
        }

        private void EditRoadTrip_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is RoadTrip roadtrip)
            {
                NavigationService?.Navigate(new EditRoadTripPage(roadtrip));
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Database.CurrentUser != null)
            {
                NavigationService?.Navigate(new DriverHomePage(Database.CurrentUser));
            }
            else
            {
                MessageBox.Show("Er is geen ingelogde gebruiker gevonden.");
            }
        }

    }
}
