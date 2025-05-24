using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Test
{
    public partial class UserHomePage : Page
    {
        private User currentUser;

        public UserHomePage(User user)
        {
            InitializeComponent();
            currentUser = user;

            // Laad ritten
            RoadTripListView.ItemsSource = Database.RoadTrips;

            // Dubbelklik activeert chat
            RoadTripListView.MouseDoubleClick += RoadTripListView_MouseDoubleClick;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SettingsPage(currentUser));
        }

        private void RoadTripListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RoadTripListView.SelectedItem is RoadTrip selectedTrip)
            {
                User driver = selectedTrip.Driver;

                if (driver != null && currentUser != null)
                {
                    // Zorg dat driver-email key bestaat
                    if (!ChatMemory.AllChats.ContainsKey(driver.Email))
                        ChatMemory.AllChats[driver.Email] = new();

                    // Zorg dat user-chat bestaat
                    if (!ChatMemory.AllChats[driver.Email].ContainsKey(currentUser.Email))
                        ChatMemory.AllChats[driver.Email][currentUser.Email] = new ObservableCollection<ChatMessage>();

                    // Navigeer naar de chatpagina met deze driver
                    NavigationService.Navigate(new ChatPage(currentUser, driver));
                }
            }
        }
    }
}
