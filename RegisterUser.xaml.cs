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
    
    public partial class RegisterUser : Page
    {
        public RegisterUser()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User
            {
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                Email = EmailBox.Text,
                Phone = PhoneBox.Text,
                City = CityBox.Text,
                Password = PasswordBox.Password
            };

            Database.Users.Add(newUser);

            MessageBox.Show($"Gebruiker {newUser.FirstName} {newUser.LastName} geregistreerd!");
            NavigationService.Navigate(new Login_Page());
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }
    }
}
