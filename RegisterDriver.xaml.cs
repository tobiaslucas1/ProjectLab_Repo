using System;
using System.Windows;
using System.Windows.Controls;

namespace Test
{
    public partial class RegisterDriver : Page
    {
        public RegisterDriver()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Your original empty handler — left untouched
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // ✅ Extract password
            string wachtwoord = PasswordBox.Password;

            // ✅ Create new driver with password included
            Driver newDriver = new Driver
            {
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                BirthDate = $"{DayBox.Text}/{MonthBox.Text}/{YearBox.Text}",
                Gender = (GenderMale.IsChecked == true) ? "Man" : "Vrouw",
                Email = EmailBox.Text,
                Phone = PhoneBox.Text,
                City = CityBox.Text,
                CarModel = CarModelBox.Text,
                Plate = PlateBox.Text,
                Color = (ColorComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                AllowsSmoking = SmokingCheckBox.IsChecked == true,
                PlaysMusic = MusicCheckBox.IsChecked == true,
                Password = wachtwoord // ✅ Assuming your Driver model has this property
            };

            Database.Drivers.Add(newDriver);

            MessageBox.Show($"Nieuwe driver: {newDriver.FirstName} {newDriver.LastName}\nAuto: {newDriver.CarModel} ({newDriver.Color})");

            NavigationService.Navigate(new Login_Page());
        }

        // ✅ NEW: Navigate back to homepage
        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }
    }
}

