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
    public partial class Login_Page : Page
    {
        public Login_Page()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (email == "Admin" && password == "Admin")
            {
                MessageBox.Show("Welkom, Admin!");
                NavigationService.Navigate(new AdminHomePage());
                return;
            }

            var user = Database.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                MessageBox.Show("Foutieve inloggegevens.");
                return;
            }

           
            Database.CurrentUser = user;

            MessageBox.Show($"Welkom, {user.FirstName}!");

            if (user.Role == "Driver")
                NavigationService.Navigate(new DriverHomePage(user));
            else
                NavigationService.Navigate(new UserHomePage(user));
        }




        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }

        


    }

}
