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
using System.Windows.Shapes;
using Test;


namespace Test
{

    public partial class RegisterDriver : Page
    {
        public RegisterDriver()
        {
            InitializeComponent();
        }

       
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            User newDriver = new User
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
                Password = PasswordBox.Password,
                Role = "Driver",
            };
            Database.Users.Add(newDriver);

            MessageBox.Show($"Nieuwe driver: {newDriver.FirstName} {newDriver.LastName}\nAuto: {newDriver.CarModel} ({newDriver.Color})");
            
            NavigationService.Navigate(new Login_Page());

        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }
    }
}
