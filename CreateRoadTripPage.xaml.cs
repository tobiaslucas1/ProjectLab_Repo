using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Test
{
    public partial class CreateRoadTripPage : Page
    {
        private User currentUser;

        public CreateRoadTripPage(User user)
        {
            InitializeComponent();
            currentUser = user;

            // Steden inladen in comboboxes
            StartCityComboBox.ItemsSource = BelgiumCities.Cities;
            EndCityComboBox.ItemsSource = BelgiumCities.Cities;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }

        private void CreateRoadTrip_Click(object sender, RoutedEventArgs e)
        {
            string startCity = StartCityComboBox.SelectedItem as string;
            string endCity = EndCityComboBox.SelectedItem as string;
            DateTime? date = DepartureDatePicker.SelectedDate;
            string time = DepartureTimeTextBox.Text;

            // Validaties
            if (string.IsNullOrEmpty(startCity))
            {
                MessageBox.Show("Kies een startstad.");
                return;
            }
            if (string.IsNullOrEmpty(endCity))
            {
                MessageBox.Show("Kies een eindstad.");
                return;
            }
            if (startCity == endCity)
            {
                MessageBox.Show("Startstad en eindstad mogen niet hetzelfde zijn.");
                return;
            }
            if (!date.HasValue)
            {
                MessageBox.Show("Kies een vertrekdatum.");
                return;
            }
            if (string.IsNullOrWhiteSpace(time))
            {
                MessageBox.Show("Vul een vertrektijd in.");
                return;
            }
            if (!TimeSpan.TryParse(time, out _))
            {
                MessageBox.Show("Vertrektijd moet in het formaat 'HH:mm' zijn.");
                return;
            }

            var roadtrip = new RoadTrip
            {
                Driver = currentUser,
                StartCity = startCity,
                EndCity = endCity,
                DepartureDate = date.Value,
                DepartureTime = time
            };

            Database.RoadTrips.Add(roadtrip);
            MessageBox.Show("Roadtrip succesvol aangemaakt!");

            NavigationService?.Navigate(new DriverHomePage(currentUser));
        }
        public static class BelgiumCities
        {
            public static List<string> Cities = new List<string>
    {
        "Antwerpen", "Brussel", "Gent", "Leuven", "Luik",
        "Charleroi", "Brugge", "Namur", "Hasselt", "Mechelen"
    };
        }

    }
}
