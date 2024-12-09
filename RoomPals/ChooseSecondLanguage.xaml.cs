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
    public partial class ChooseSecondLanguage : Window
    {
        private Student _currentStudent;
        public ChooseSecondLanguage(Student student)
        {
            _currentStudent = student;
            InitializeComponent();
            UserNameTextBlock.Text = $"{_currentStudent.Name}";
            English.Content = "English";
            Polish.Content = "Polish";
            German.Content = "German";
            Spanish.Content = "Spanish";
            Ukrainian.Content = "Ukrainian";
            French.Content = "French";
        }


        private void Language_Click(object sender, RoutedEventArgs e)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton != null)
            {
                string selectedLan2 = clickedRadioButton.Content.ToString();
                _currentStudent.SecondLanguage = selectedLan2;

            }
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            // this has to show if in account creation otherwise the user has to exit through the go back click
            if (string.IsNullOrEmpty(_currentStudent.SecondLanguage))
            {
                MessageBox.Show("Please select a language before confirming.");
                return;
            }

            StudentData.UpdateStudent(_currentStudent);
            // last one wooooo 
            MessageBox.Show($"You have confirmed your choice: {_currentStudent.SecondLanguage}");

            QuizWindow quizWindow = new QuizWindow(_currentStudent);
            quizWindow.Show();
            this.Close();
        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentStudent.SecondLanguage))
            {
                MessageBox.Show("Please select a language before confirming.");
                return;
            }

            StudentData.UpdateStudent(_currentStudent);
            MessageBox.Show($"You have confirmed your choice: {_currentStudent.SecondLanguage}");

            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }
    }
}
