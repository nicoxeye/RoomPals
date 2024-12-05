using RoomPals.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        private Student _loggedInStudent;
        public EditProfileWindow(Student loggedInStudent)
        {
            InitializeComponent();
            _loggedInStudent = loggedInStudent;

            NameTextBox.Text = _loggedInStudent.Name;
            LastNameTextBox.Text = _loggedInStudent.Surname;
            EmailTextBox.Text = _loggedInStudent.Email;
            UsernameTextBox.Text = _loggedInStudent.Username;
            PasswordTextBox.Text = _loggedInStudent.Password;
            MajorTextBox.Text = _loggedInStudent.Major;

        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save your changes before leaving?",
                              "Unsaved Changes",
                              MessageBoxButton.YesNoCancel);

            if (result == MessageBoxResult.Yes)
            {
                ConfirmButton_Click(sender, e); // Save changes
                StartWindow startWindow = new StartWindow(_loggedInStudent);
                startWindow.Show();
                this.Close();
            }
            else if (result == MessageBoxResult.No)
            {
                StartWindow startWindow = new StartWindow(_loggedInStudent);
                startWindow.Show();
                this.Close();
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text))
                _loggedInStudent.Name = NameTextBox.Text;

            if (!string.IsNullOrWhiteSpace(LastNameTextBox.Text))
                _loggedInStudent.Surname = LastNameTextBox.Text;


            if (!string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                // Validate email format
                if (Regex.IsMatch(EmailTextBox.Text, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"))
                {
                    // Check if email already exists in the database (excluding the current user)
                    bool emailExists = StudentData.Students.Any(student =>
                        student.Email.Equals(EmailTextBox.Text, StringComparison.OrdinalIgnoreCase) && student != _loggedInStudent);

                    if (emailExists)
                    {
                        MessageBox.Show("This email is already in use. Please use a different one.");
                        return;
                    }

                    _loggedInStudent.Email = EmailTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Invalid email format.");
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                // Check if the username already exists in the database (excluding the current user)
                bool usernameExists = StudentData.Students.Any(student =>
                    student.Username.Equals(UsernameTextBox.Text, StringComparison.OrdinalIgnoreCase) && student != _loggedInStudent);

                if (usernameExists)
                {
                    MessageBox.Show("This username is already taken. Please choose a different one.");
                    return;
                }

                _loggedInStudent.Username = UsernameTextBox.Text;
            }

            if (!string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                if (Regex.IsMatch(PasswordTextBox.Text, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,16}$"))
                    _loggedInStudent.Password = PasswordTextBox.Text;
                else
                {
                    MessageBox.Show("Password must be 8-16 characters long and include uppercase, lowercase, and a number.");
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(MajorTextBox.Text))
                _loggedInStudent.Major = MajorTextBox.Text;



            StudentPersistence.SaveStudents(StudentData.Students);

            MessageBox.Show("Changes saved successfully!");
            // Reload the main page to reflect changes
            StartWindow startWindow = new StartWindow(_loggedInStudent);
            startWindow.Show();
            this.Close();
        }
    }
}
