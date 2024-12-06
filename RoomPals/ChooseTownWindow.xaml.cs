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
        private Student _currentStudent;
        public ChooseTownWindow(Student student)
        {
            _currentStudent = student;
            InitializeComponent();
            UserNameTextBlock.Text = $"{_currentStudent.Name}";

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
                _currentStudent.city = selectedCity; 

            }
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentStudent.city))
            {
                MessageBox.Show("Please select a town before confirming.");
                return;
            }

            StudentData.UpdateStudent(_currentStudent);
            // messagebox only for me to see if its working
            MessageBox.Show($"You have confirmed your choice: {_currentStudent.city}");
        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            // this will be blocked if the user is in the account creation -> will add it later :3
            StartWindow startWindow = new StartWindow(_currentStudent);
            startWindow.Show();
            this.Close();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentStudent.city))
            {
                MessageBox.Show("Please select a town before confirming.");
                return;
            }
            StudentData.UpdateStudent(_currentStudent);
            MessageBox.Show($"You have confirmed your choice: {_currentStudent.city}");
            ChooseYourUniversityWindow chooseYourUniversityWindow = new ChooseYourUniversityWindow();
            chooseYourUniversityWindow.Show();
            this.Hide();
        }
    }
}
