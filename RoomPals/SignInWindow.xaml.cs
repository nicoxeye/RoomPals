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
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                // Jeśli TextBox jest pusty, przełącz widoczność
                EmailTextBox.Visibility = EmailTextBox.Visibility == Visibility.Collapsed
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
            else
            {
                // Jeśli TextBox ma tekst, to pozostaw go Visible
                EmailTextBox.Visibility = Visibility.Visible;
            }

        }
        private void EmailTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string enteredEmail = EmailTextBox.Text;
                MessageBox.Show(enteredEmail);

                this.Focus();
                
            }

        }
        private void Username_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                // Jeśli TextBox jest pusty, przełącz widoczność
                UsernameTextBox.Visibility = UsernameTextBox.Visibility == Visibility.Collapsed
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
            else
            {
                // Jeśli TextBox ma tekst, to pozostaw go Visible
                UsernameTextBox.Visibility = Visibility.Visible;
            }
        }
        
        private void UsernameTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string enteredUsername = UsernameTextBox.Text;
                MessageBox.Show(enteredUsername); //tego nie musi tu byc jbc, tylko sprawdzam

                this.Focus();

            }
        }
        private void Password_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                // Jeśli PasswordBox jest pusty, przełącz widoczność
                PasswordBox.Visibility = PasswordBox.Visibility == Visibility.Collapsed
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
            else
            {
                // Jeśli PasswordBox ma tekst, to pozostaw go Visible
                PasswordBox.Visibility = Visibility.Visible;
            }
        }
        private void PasswordBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string enteredPassword = PasswordBox.Password;

                this.Focus();

            }
        }
        private void RepeatPassword_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RepeatPasswordBox.Password))
            {
                // Jeśli PasswordBox jest pusty, przełącz widoczność
                RepeatPasswordBox.Visibility = RepeatPasswordBox.Visibility == Visibility.Collapsed
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
            else
            {
                // Jeśli PasswordBox ma tekst, to pozostaw go Visible
                PasswordBox.Visibility = Visibility.Visible;
            }
        }
        private void RepeatPasswordBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string repeatedPassword = RepeatPasswordBox.Password;

                this.Focus();

            }
        }
        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}