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
    public partial class CreateAccountWindow : Window
    {
        private Student _currentStudent;
        public CreateAccountWindow(Student student)
        {
            InitializeComponent();
           _currentStudent = student;

        }

        private string FormatText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            input = input.Trim(); 
            return char.ToUpper(input[0]) + input.Substring(1).ToLower(); //name, lastname and major now 
                                                                          //always start with upper letter
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            _currentStudent.Name = FormatText(NameTextBox.Text);
            _currentStudent.Surname = FormatText(LastNameTextBox.Text);
            _currentStudent.Major = FormatText(MajorTextBox.Text);

            if (int.TryParse(AgeTextBox.Text.Trim(), out int age) && age > 0)
            {
                _currentStudent.Age = age;
            }
            else
            {
                MessageBox.Show("Invalid age. Please enter a valid number.");
                return;
            }

            _currentStudent.Major = MajorTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(_currentStudent.Name) || string.IsNullOrWhiteSpace(_currentStudent.Surname) || string.IsNullOrWhiteSpace(_currentStudent.Major))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            try
            {
                StudentData.AddStudent(_currentStudent); 
                MessageBox.Show("Your data has been saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving student data: {ex.Message}");
                return;
            }

            ChooseTownWindow chooseTownWindow = new ChooseTownWindow();
            chooseTownWindow.Show();
            this.Hide();
        }

        private void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LastNameTextBox.Focus();
            }
        }

        private void LastNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AgeTextBox.Focus();
            }
        }

        private void AgeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MajorTextBox.Focus();
            }
        }

        private void MajorTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmButton.Focus();
            }
        }
    }
}
