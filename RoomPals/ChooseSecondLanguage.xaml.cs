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
        private Student _loggedInStudent;
        private bool _isAccountCreation;
        public ChooseSecondLanguage(Student student, bool isAccountCreation)
        {
            _loggedInStudent = student;
            _isAccountCreation = isAccountCreation;
            InitializeComponent();
            UserNameTextBlock.Text = $"{_loggedInStudent.Name}";
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
                _loggedInStudent.SecondLanguage = selectedLan2;

            }
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            // this has to show if in account creation otherwise the user has to exit through the go back click
            if (string.IsNullOrEmpty(_loggedInStudent.SecondLanguage))
            {
                MessageBox.Show("Please select a language before confirming.");
                return;
            }

            StudentData.UpdateStudent(_loggedInStudent);
            MessageBox.Show($"You have confirmed your choice: {_loggedInStudent.SecondLanguage}");
            if (_isAccountCreation)
            {
                QuizWindow quizWindow = new QuizWindow(_loggedInStudent);
                quizWindow.Show();
                this.Close();
            }
            else
            {
                StartWindow startWindow = new StartWindow(_loggedInStudent);
                startWindow.Show();
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
            else
            {
                StartWindow startWindow = new StartWindow(_loggedInStudent);
                startWindow.Show();
                this.Close();
            }
        }
    }
}
