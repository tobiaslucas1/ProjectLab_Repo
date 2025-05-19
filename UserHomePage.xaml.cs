using System.Windows;
using System.Windows.Controls;

namespace Test
{
    public partial class UserHomePage : Page
    {
        public UserHomePage()
        {
            InitializeComponent();

            if (Session.CurrentUser != null)
            {
                var user = Session.CurrentUser;

                WelcomeTextBlock.Text = $"Welkom terug, {user.FirstName}";
                UserEmailText.Text = $"📧 Email: {user.Email}";
                UserCityText.Text = $"🏙️ Woonplaats: onbekend"; // Voeg toe in model als je wilt
                UserBirthText.Text = $"🎂 Geboortedatum: onbekend"; // idem
                UserGenderText.Text = $"👤 Geslacht: onbekend"; // idem
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
