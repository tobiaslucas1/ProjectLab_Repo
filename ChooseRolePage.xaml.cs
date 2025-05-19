using System.Windows;
using System.Windows.Controls;

namespace Test
{
    public partial class ChooseRolePage : Page
    {
        public ChooseRolePage()
        {
            InitializeComponent();
        }

        private void RegisterUser_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new RegisterPage());
        }

        private void RegisterDriver_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Navigate(new RegisterDriver());
        }
    }
}

