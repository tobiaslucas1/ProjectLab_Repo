using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Test
{
    public partial class ChatPage : Page
    {
        private User currentUser;
        private User currentDriver;
        private ObservableCollection<ChatMessage> currentMessages;
        private string selectedUserEmail;

        // ✅ Voor passagier: chat met 1 driver
        public ChatPage(User user, User driver)
        {
            InitializeComponent();
            currentUser = user;
            currentDriver = driver;

            ChatTitle.Text = $"Chat met {driver.FirstName}";

            if (!ChatMemory.AllChats.ContainsKey(driver.Email))
                ChatMemory.AllChats[driver.Email] = new();

            if (!ChatMemory.AllChats[driver.Email].ContainsKey(user.Email))
                ChatMemory.AllChats[driver.Email][user.Email] = new ObservableCollection<ChatMessage>();

            currentMessages = ChatMemory.AllChats[driver.Email][user.Email];
            ChatList.ItemsSource = currentMessages;

            UserList.Items.Clear();
            UserList.Items.Add(driver.Email);
            UserList.SelectedIndex = 0;

            selectedUserEmail = user.Email;
        }

        // ✅ Voor bestuurder: inbox van passagiers
        public ChatPage(User driver)
        {
            InitializeComponent();
            currentDriver = driver;
            LoadUserList();
        }

        private void LoadUserList()
        {
            UserList.Items.Clear();

            if (ChatMemory.AllChats.TryGetValue(currentDriver.Email, out var userChats))
            {
                foreach (var userEmail in userChats.Keys)
                {
                    UserList.Items.Add(userEmail);
                }
            }
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserList.SelectedItem is string userEmail)
            {
                selectedUserEmail = userEmail;
                ChatTitle.Text = $"Chat met {userEmail}";

                if (ChatMemory.AllChats[currentDriver.Email].TryGetValue(userEmail, out var messages))
                {
                    currentMessages = messages;
                    ChatList.ItemsSource = currentMessages;
                }
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MessageBox.Text) || selectedUserEmail == null)
                return;

            // 🔐 Bepaal verzender dynamisch
            string senderEmail = currentUser != null ? currentUser.Email : currentDriver.Email;
            string senderName = currentUser != null ? currentUser.FirstName : currentDriver.FirstName;

            // 🧠 Kies juiste sleutels
            string chatKey = currentDriver != null ? currentDriver.Email : currentUser.Email;
            string targetKey = selectedUserEmail;

            // 🔧 Init structuur indien nodig
            if (!ChatMemory.AllChats.ContainsKey(chatKey))
                ChatMemory.AllChats[chatKey] = new();

            if (!ChatMemory.AllChats[chatKey].ContainsKey(targetKey))
                ChatMemory.AllChats[chatKey][targetKey] = new ObservableCollection<ChatMessage>();

            // ✅ Bericht maken
            var message = new ChatMessage
            {
                SenderEmail = senderEmail,
                SenderName = senderName,
                Text = MessageBox.Text,
                Timestamp = DateTime.Now.ToShortTimeString()
            };

            ChatMemory.AllChats[chatKey][targetKey].Add(message);

            // 🔁 Update UI
            currentMessages = ChatMemory.AllChats[chatKey][targetKey];
            ChatList.ItemsSource = currentMessages;

            MessageBox.Text = "";
        }

        private void MessageBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Text == "Typ een bericht...")
            {
                MessageBox.Text = "";
                MessageBox.Foreground = Brushes.Black;
            }
        }

        private void MessageBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MessageBox.Text))
            {
                MessageBox.Text = "Typ een bericht...";
                MessageBox.Foreground = Brushes.Gray;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (currentUser != null)
                NavigationService?.Navigate(new UserHomePage(currentUser));
            else if (currentDriver != null)
                NavigationService?.Navigate(new DriverHomePage(currentDriver));
        }
    }
}
