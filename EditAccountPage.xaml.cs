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
    public partial class EditAccountPage : Page
    {
        private User selectedUser;

        public EditAccountPage(User user)
        {
            InitializeComponent();
            selectedUser = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            FirstNameBox.Text = selectedUser.FirstName;
            LastNameBox.Text = selectedUser.LastName;
            EmailBox.Text = selectedUser.Email;
            PhoneBox.Text = selectedUser.Phone;
            CityBox.Text = selectedUser.City;
            PasswordBox.Password = selectedUser.Password;
            RoleBox.Text = selectedUser.Role;

            if (selectedUser.Role == "Driver")
            {
                CarModelPanel.Visibility = Visibility.Visible;
                PlatePanel.Visibility = Visibility.Visible;
                ColorPanel.Visibility = Visibility.Visible;
                SmokingPanel.Visibility = Visibility.Visible;
                MusicPanel.Visibility = Visibility.Visible;

                CarModelBox.Text = selectedUser.CarModel;
                PlateBox.Text = selectedUser.Plate;
                ColorComboBox.Text = selectedUser.Color;
                SmokingCheckBox.IsChecked = selectedUser.AllowsSmoking;
                MusicCheckBox.IsChecked = selectedUser.PlaysMusic;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            selectedUser.FirstName = FirstNameBox.Text;
            selectedUser.LastName = LastNameBox.Text;
            selectedUser.Email = EmailBox.Text;
            selectedUser.Phone = PhoneBox.Text;
            selectedUser.City = CityBox.Text;
            selectedUser.Password = PasswordBox.Password;

            if (selectedUser.Role == "Driver")
            {
                selectedUser.CarModel = CarModelBox.Text;
                selectedUser.Plate = PlateBox.Text;
                selectedUser.Color = ColorComboBox.Text;
                selectedUser.AllowsSmoking = SmokingCheckBox.IsChecked == true;
                selectedUser.PlaysMusic = MusicCheckBox.IsChecked == true;
            }

            MessageBox.Show("Accountgegevens succesvol bijgewerkt!");
            NavigationService?.GoBack();
        }
    }
}
