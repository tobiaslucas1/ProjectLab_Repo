using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Test
{
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }

        private void SavePassword_Click(object sender, RoutedEventArgs e)
        {
            string newPw = NewPasswordBox.Password;
            string confirmPw = ConfirmPasswordBox.Password;

            if (newPw != confirmPw)
            {
                MessageBox.Show("Wachtwoorden komen niet overeen.");
                return;
            }

            MessageBox.Show("Wachtwoord succesvol gewijzigd!");
        }

        private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTheme = (ThemeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedTheme == "Donker")
            {
                Application.Current.Resources["BackgroundColor"] = new SolidColorBrush(Color.FromRgb(30, 30, 30));
                Application.Current.Resources["TextColor"] = Brushes.White;
            }
            else
            {
                Application.Current.Resources["BackgroundColor"] = Brushes.White;
                Application.Current.Resources["TextColor"] = Brushes.Black;
            }
        }
    }
}



