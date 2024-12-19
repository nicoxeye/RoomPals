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
    public partial class ChooseTownWindow : Window
    {
        private Student _loggedInStudent;
        private bool _isAccountCreation;
        public ChooseTownWindow(Student student, bool isAccountCreation)
        {
            _loggedInStudent = student;
            _isAccountCreation = isAccountCreation;
            InitializeComponent();
            UserNameTextBlock.Text = $"{_loggedInStudent.Name}";

            Katowice.Content = "Katowice";
            Myslowice.Content = "Myslowice";
            Chorzow.Content = "Chorzow";
            Zabrze.Content = "Zabrze";
            Sosnowiec.Content = "Sosnowiec";
            Rybnik.Content = "Rybnik";
        }

        private void CityButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton clickedRadioButton = sender as RadioButton; 
            if (clickedRadioButton != null)
            {
                string selectedCity = clickedRadioButton.Content.ToString();
                _loggedInStudent.city = selectedCity; 

            }
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_loggedInStudent.city))
            {
                MessageBox.Show("Please select a town before confirming.");
                return;
            }
            StudentData.UpdateStudent(_loggedInStudent);
            MessageBox.Show($"You have confirmed your choice: {_loggedInStudent.city}");
            if (_isAccountCreation)
            {
                ChooseYourUniversityWindow chooseYourUniversityWindow1 = new ChooseYourUniversityWindow(_loggedInStudent, true);
                chooseYourUniversityWindow1.Show();
                this.Hide();
            }
            else
            {
                ChooseYourUniversityWindow chooseYourUniversityWindow = new ChooseYourUniversityWindow(_loggedInStudent, false);
                chooseYourUniversityWindow.Show();
                this.Hide();
            }
        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            if (_isAccountCreation)
            {
                MessageBox.Show("You cannot go back during account creation.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Otherwise, navigate back
            StartWindow startWindow = new StartWindow(_loggedInStudent);
            startWindow.Show();
            this.Close();
        }

    }
}
