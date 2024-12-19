using RoomPals.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RoomPals
{
    /// <summary>
    /// Logika interakcji dla klasy LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void UsernameButton_Click(object sender, RoutedEventArgs e)
        {
            UsernameButton.Visibility = Visibility.Collapsed;
            UsernameTextBox.Visibility = Visibility.Visible;
            UsernameTextBox.Focus();
        }

        private void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PasswordButton_Click(sender, e);
            }
        }

        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            PasswordButton.Visibility = Visibility.Collapsed;
            PasswordBox.Visibility = Visibility.Visible;
            PasswordBox.Focus();
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = UsernameTextBox.Text;
            string enteredPassword = PasswordBox.Password;

            Student authenticatedStudent = StudentData.Students.FirstOrDefault(student => student.Authenticate(enteredUsername, enteredPassword));

            if (authenticatedStudent != null)
            {
                StartWindow startWindow = new StartWindow(authenticatedStudent);
                startWindow.Show();
                this.Close();
            }
            else
            {
                // If authentication fails, show a message box
                MessageBox.Show("Invalid username or password. Please try again.");

                // Optionally, clear the password field for retrying
                PasswordBox.Clear();

                // Optionally, you can focus on the password box to guide the user
                PasswordBox.Focus();
            }
        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
