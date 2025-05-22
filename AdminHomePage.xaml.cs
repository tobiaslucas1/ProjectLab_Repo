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
    public partial class AdminHomePage : Page
    {
        public AdminHomePage()
        {
            InitializeComponent();

            UserListView.ItemsSource = Database.Users;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HomePage());
        }
        private void RemoveAccount_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UserListView.SelectedItem as User;

            if (selectedUser == null)
            {
                MessageBox.Show("Selecteer eerst een gebruiker om te verwijderen.");
                return;
            }

            var result = MessageBox.Show($"Weet je zeker dat je {selectedUser.FirstName} {selectedUser.LastName} wil verwijderen?",
                                         "Bevestig verwijdering", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Database.Users.Remove(selectedUser);

                UserListView.ItemsSource = null;
                UserListView.ItemsSource = Database.Users;

                MessageBox.Show("Account succesvol verwijderd.");
            }
        }

    }
}
