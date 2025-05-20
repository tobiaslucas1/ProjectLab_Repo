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
            string firstName = FirstNameBox.Text;
            string lastName = LastNameBox.Text;
            string email = EmailBox.Text;
            string phone = PhoneBox.Text;
            string city = CityBox.Text;
            string password = PasswordBox.Password;

            MessageBox.Show($"Gebruiker {firstName} {lastName} geregistreerd!");
        }
    }
}
