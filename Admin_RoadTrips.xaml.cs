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
    public partial class Admin_RoadTrips : Page
    {
        public Admin_RoadTrips()
        {
            InitializeComponent();
            RoadTripListView.ItemsSource = Database.RoadTrips;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }

        private void RemoveRoadTrip_Click(object sender, RoutedEventArgs e)
        {
            var selectedTrip = RoadTripListView.SelectedItem as RoadTrip;
            if (selectedTrip == null)
            {
                MessageBox.Show("Selecteer een roadtrip om te verwijderen.");
                return;
            }

            var result = MessageBox.Show("Weet je zeker dat je deze roadtrip wilt verwijderen?", "Bevestiging", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Database.RoadTrips.Remove(selectedTrip);
                RoadTripListView.ItemsSource = null;
                RoadTripListView.ItemsSource = Database.RoadTrips;
            }
        }

        private void EditRoadTrip_Click(object sender, RoutedEventArgs e)
        {
            var selectedTrip = RoadTripListView.SelectedItem as RoadTrip;
            if (selectedTrip == null)
            {
                MessageBox.Show("Selecteer een roadtrip om te bewerken.");
                return;
            }

            NavigationService?.Navigate(new EditRoadTripPage(selectedTrip));
        }

    }
}
