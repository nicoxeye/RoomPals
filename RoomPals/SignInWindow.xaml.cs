using System.Windows;
using System.Windows.Input;

namespace RoomPals
{
    /// <summary>
    /// Logika interakcji dla klasy SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
        }

        private void Email_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Visibility == Visibility.Collapsed)
            {
                EmailTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                EmailTextBox.Visibility = Visibility.Collapsed;
            }
            ////sprawdzenie:
            //if (EmailTextBox.Visibility == Visibility.Collapsed)
            //{
            //    EmailTextBox.Visibility = Visibility.Visible;
            //    MessageBox.Show("TextBox is now visible."); // Debug: sprawdzenie
            //}
            //else
            //{
            //    EmailTextBox.Visibility = Visibility.Collapsed;
            //    MessageBox.Show("TextBox is now collapsed."); // Debug: sprawdzenie
            //}

        }
        private void EmailTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string enteredEmail = EmailTextBox.Text;
                MessageBox.Show(enteredEmail);
                // EmailTextBox.Visibility = Visibility.Collapsed;

                this.Focus();
                
            }

        }
        private void Username_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Visibility == Visibility.Collapsed)
            {
                UsernameTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                UsernameTextBox.Visibility = Visibility.Collapsed;
            }
        }
        private void Password_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Visibility == Visibility.Collapsed)
            {
                PasswordBox.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordBox.Visibility = Visibility.Collapsed;
            }
        }
        private void RepeatPassword_Click(object sender, RoutedEventArgs e)
        {
            if (RepeatPasswordBox.Visibility == Visibility.Collapsed)
            {
                RepeatPasswordBox.Visibility = Visibility.Visible;
            }
            else
            {
                RepeatPasswordBox.Visibility= Visibility.Collapsed;
            }
        }
        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccountWindow createAccountWindow = new CreateAccountWindow();
            createAccountWindow.Show();
            this.Hide();
        }
    }
}