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

    public partial class ChooseFirstLanguage : Window
    {
        private Student _loggedInStudent;
        private bool _isAccountCreation;
        public ChooseFirstLanguage(Student student, bool isAccountCreation)
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

        private void UniButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton != null)
            {
                string selectedLan = clickedRadioButton.Content.ToString();
                _loggedInStudent.MainLanguage = selectedLan;

            }
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_loggedInStudent.MainLanguage))
            {
                MessageBox.Show("Please select a language before confirming.");
                return;
            }

            StudentData.UpdateStudent(_loggedInStudent);
            // yk the deal 
            MessageBox.Show($"You have confirmed your choice: {_loggedInStudent.MainLanguage}");
            if (_isAccountCreation)
            {
                ChooseSecondLanguage chooseSecondLanguage1 = new ChooseSecondLanguage(_loggedInStudent, true);
                chooseSecondLanguage1.Show();
                this.Hide();
            }
            else
            {
                ChooseSecondLanguage chooseSecondLangugage = new ChooseSecondLanguage(_loggedInStudent, false);
                chooseSecondLangugage.Show();
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
            StartWindow startWindow = new StartWindow(_loggedInStudent);
            startWindow.Show();
            this.Close();
        }
    }
}
