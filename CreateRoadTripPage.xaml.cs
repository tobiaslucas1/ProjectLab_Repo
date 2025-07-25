﻿using System;
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
            if (Database.CurrentUser != null)
            {
                NavigationService?.Navigate(new DriverHomePage(Database.CurrentUser));
            }
            else
            {
                MessageBox.Show("Er is geen ingelogde gebruiker gevonden.");
            }
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



    }
}
