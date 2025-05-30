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

            StartCityComboBox.ItemsSource = BelgiumCities.Cities;
            EndCityComboBox.ItemsSource = BelgiumCities.Cities;

            LoadRoadTripDetails();
        }


        private void LoadRoadTripDetails()
        {
            StartCityComboBox.SelectedItem = selectedRoadTrip.StartCity;
            EndCityComboBox.SelectedItem = selectedRoadTrip.EndCity;
            DepartureDatePicker.SelectedDate = selectedRoadTrip.DepartureDate;
            DepartureTimeTextBox.Text = selectedRoadTrip.DepartureTime;
        }


        public static class BelgiumCities
        {
            public static List<string> Cities = new List<string>
    {
        "Aalst", "Andenne", "Antwerpen", "Arlon", "Asse",
        "Aarschot", "Bastogne", "Beringen", "Bilzen", "Binche",
        "Boom", "Bouillon", "Braine-le-Château", "Braine-l’Alleud", "Brasschaat",
        "Brugge", "Brussel", "Châtelet", "Charleroi", "Chaudfontaine",
        "Ciney", "Courcelles", "Dinant", "Diest", "Dilbeek",
        "Dendermonde", "Eupen", "Eghezée", "Floreffe", "Fosses-la-Ville",
        "Frameries", "Genappe", "Genk", "Geel", "Gembloux",
        "Geraardsbergen", "Gent", "Grimbergen", "Habay", "Halle",
        "Hannut", "Hasselt", "Havelange", "Herentals", "Herstal",
        "Heusden-Zolder", "Houffalize", "Houthalen-Helchteren", "Huy", "Ieper",
        "Jodoigne", "Knokke-Heist", "Kortrijk", "La Louvière", "Leuven",
        "Libramont-Chevigny", "Liège", "Lier", "Lommel", "Lokeren",
        "Luik", "Manage", "Maasmechelen", "Marche-en-Famenne", "Mechelen",
        "Menen", "Mons", "Mortsel", "Mouscron", "Namur",
        "Namen", "Neufchâteau", "Ninove", "Nivelles", "Oostende",
        "Ottignies-Louvain-la-Neuve", "Oudenaarde", "Profondeville", "Rixensart", "Roeselare",
        "Saint-Hubert", "Saint-Nicolas", "Sambreville", "Seraing", "Sint-Niklaas",
        "Sint-Truiden", "Tielt", "Tienen", "Torhout", "Tongeren",
        "Tournai", "Turnhout", "Tubize", "Vilvoorde", "Visé",
        "Virton", "Wavre", "Waregem", "Waterloo", "Wetteren",
        "Willebroek", "Zaventem", "Zottegem"
    };
        }



        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            string startCity = StartCityComboBox.SelectedItem as string;
            string endCity = EndCityComboBox.SelectedItem as string;

            if (string.IsNullOrEmpty(startCity) || string.IsNullOrEmpty(endCity) ||
                !DepartureDatePicker.SelectedDate.HasValue ||
                string.IsNullOrWhiteSpace(DepartureTimeTextBox.Text))
            {
                MessageBox.Show("Gelieve alle velden correct in te vullen.");
                return;
            }

            selectedRoadTrip.StartCity = startCity;
            selectedRoadTrip.EndCity = endCity;
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
