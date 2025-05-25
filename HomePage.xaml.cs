using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Test
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            // 🗺️ Dynamisch map-image laden van internet
            string mapUrl = "https://static.vecteezy.com/ti/gratis-vector/p1/22966737-stedelijk-stad-kaart-stad-straten-gps-navigatie-downtown-kaart-met-wegen-parken-en-rivier-abstract-routekaart-navigatie-regeling-illustratie-vector.jpg";
            MapImage.Source = new BitmapImage(new Uri(mapUrl));
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new Login_Page());
        }

        private void Register_Click_Driver(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new RegisterDriver());
        }

        private void Register_Click_User(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new RegisterUser());
        }
    }
}
