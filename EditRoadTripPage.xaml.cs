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
    public partial class EditRoadTripPage : Page
    {
        private RoadTrip selectedRoadTrip;

        public EditRoadTripPage(RoadTrip roadTrip)
        {
            InitializeComponent();
            selectedRoadTrip = roadTrip;
            LoadRoadTripDetails();
        }

        private void LoadRoadTripDetails()
        {
            StartCityTextBox.Text = selectedRoadTrip.StartCity;
            EndCityTextBox.Text = selectedRoadTrip.EndCity;
            DepartureDatePicker.SelectedDate = selectedRoadTrip.DepartureDate;
            DepartureTimeTextBox.Text = selectedRoadTrip.DepartureTime;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StartCityTextBox.Text) ||
                string.IsNullOrWhiteSpace(EndCityTextBox.Text) ||
                !DepartureDatePicker.SelectedDate.HasValue ||
                string.IsNullOrWhiteSpace(DepartureTimeTextBox.Text))
            {
                MessageBox.Show("Gelieve alle velden correct in te vullen.");
                return;
            }

            selectedRoadTrip.StartCity = StartCityTextBox.Text;
            selectedRoadTrip.EndCity = EndCityTextBox.Text;
            selectedRoadTrip.DepartureDate = DepartureDatePicker.SelectedDate.Value;
            selectedRoadTrip.DepartureTime = DepartureTimeTextBox.Text;

            MessageBox.Show("Roadtrip succesvol aangepast!");
            NavigationService?.Navigate(new Admin_RoadTrips());
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }
    }
}
