using System.Windows;
using System.Windows.Controls;

namespace Test
{
    public partial class DriverHomePage : Page
    {
        public DriverHomePage()
        {
            InitializeComponent();

            if (Session.CurrentDriver != null)
            {
                var d = Session.CurrentDriver;

                WelcomeTextBlock.Text = $"Welkom terug, {d.FirstName}";
                DriverEmailText.Text = $"📧 Email: {d.Email}";
                DriverCityText.Text = $"🏙️ Woonplaats: {d.City}";
                DriverCarText.Text = $"🚘 Auto: {d.CarModel} ({d.Color})";
                DriverPlateText.Text = $"🔢 Nummerplaat: {d.Plate}";
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Session.CurrentUser = null;
            Session.CurrentDriver = null;

            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new Login_Page());
        }

        private void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new SettingsPage());
        }
    }
}
