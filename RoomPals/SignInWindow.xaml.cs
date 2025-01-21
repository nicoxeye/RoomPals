using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
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
            RepeatPasswordBox.Visibility = RepeatPasswordBox.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
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

            if (string.IsNullOrWhiteSpace(enteredEmail) || string.IsNullOrWhiteSpace(enteredUsername) ||
                 string.IsNullOrWhiteSpace(enteredPassword))
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }

            if (!Regex.IsMatch(enteredEmail, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            if (!Regex.IsMatch(enteredPassword, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,30}$"))
            {
                MessageBox.Show("Password must be 8-30 characters long, with at least one uppercase letter, one lowercase letter, and one number.");
                return;
            }

            if (StudentData.Students.Any(student => student.Username == enteredUsername))
            {
                MessageBox.Show("Username already exists. Please choose another.");
                return;
            }

            Student newStudent = new Student(
            name: "Not set",
            surname: "Not set",
            age: 0,
            major: "Not set",
            university: "Not set",
            nightOrDay: "Not set",
            dogOrCat: "Not set",
            partyOrBook: "Not set",
            activeOrPassive: "Not set",
            mainLanguage: "Not set",
            secondLanguage: "Not set",
            username: enteredUsername,
            email: enteredEmail,
            password: enteredPassword,
            City: "Not set"
            );

            StudentData.AddStudent(newStudent);

            MessageBox.Show("Account has been successfully created!");

            CreateAccountWindow createAccountWindow = new CreateAccountWindow(newStudent);
            createAccountWindow.Show();
            this.Hide();

        }


        // Methods to check if email/password/username pass the requirements
        private bool IsValidEmail(string email)
        {
            string pattern_email = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$";
            return Regex.IsMatch(email, pattern_email);
        }

        private bool IsValidPassword(string password)
        {
            string pattern_password = "^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d).{8,30}$";  //requirements: password must contain: min 1 uppercase letter, min 1 lowercase letter, min 1 digit 
            return Regex.IsMatch(password, pattern_password);
        }

        private bool IsValidUsername(string username)
        {
            return !string.IsNullOrEmpty(username);
        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}