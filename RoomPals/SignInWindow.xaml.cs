using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using RoomPals.Classes;

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
            EmailTextBox.Visibility = Visibility.Visible;
        }
        private void EmailTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string enteredEmail = EmailTextBox.Text;

                if (!IsValidEmail(enteredEmail))
                {
                    MessageBox.Show("Incorrect email format. Please try again.");
                }
                else
                {
                    UsernameTextBox.Visibility = Visibility.Visible;
                    UsernameTextBox.Focus();
                }
                e.Handled = true;


            }

        }
        private void Username_Click(object sender, RoutedEventArgs e)
        {
            UsernameTextBox.Visibility = Visibility.Visible;
        }

        private void UsernameTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string enteredUsername = UsernameTextBox.Text;

                if (!string.IsNullOrWhiteSpace(enteredUsername))
                {
                    PasswordBox.Visibility = Visibility.Visible;
                    PasswordBox.Focus();
                   
                }
                else
                {
                    MessageBox.Show("Enter username");
                }
                e.Handled = true;
            }
        }
        private void Password_Click(object sender, RoutedEventArgs e)
        {
              PasswordBox.Visibility = Visibility.Visible;
            
        }
        private void PasswordBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string enteredPassword = PasswordBox.Password;

                if (IsValidPassword(enteredPassword))
                {
                    RepeatPasswordBox.Visibility = Visibility.Visible;
                    RepeatPasswordBox.Focus();
                   
                }
                else
                {
                    MessageBox.Show("Incorrect password format. Password must contain: min 1 uppercase letter, min 1 lowercase letter, min 1 digit.");
                }
                e.Handled = true;
            }
        }
        private void RepeatPassword_Click(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Visible;
        }
        private void RepeatPasswordBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string enteredPassword = PasswordBox.Password;
                string repeatedPassword = RepeatPasswordBox.Password;

                if (!enteredPassword.Equals(repeatedPassword))
                {
                    MessageBox.Show("Password & Confirm Password do not match.");
                }
                e.Handled = true;
            }
        }
        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            string enteredEmail = EmailTextBox.Text;
            string enteredUsername = UsernameTextBox.Text;
            string enteredPassword = PasswordBox.Password;

            Student newStudent = new Student(enteredEmail, enteredUsername, enteredPassword);

            // dokoncze po treningu :3

            MessageBox.Show("Account has been successfully created!");

        }


        // Methods to check if email/password/username pass the requirements
        private bool IsValidEmail(string email)
        {
            string pattern_email = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$";
            return Regex.IsMatch(email, pattern_email);
        }

        private bool IsValidPassword(string password)
        {
            string pattern_password = "^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d).{8,16}$";  //requirements: password must contain: min 1 uppercase letter, min 1 lowercase letter, min 1 digit 
            return Regex.IsMatch(password, pattern_password);
        }

        private bool IsValidUsername(string username)
        {
            return !string.IsNullOrEmpty(username);
        }
    }
}