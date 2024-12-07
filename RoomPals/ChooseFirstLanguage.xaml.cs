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
        private Student _currentStudent;
        public ChooseFirstLanguage(Student student)
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

        private void UniButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton != null)
            {
                string selectedLan = clickedRadioButton.Content.ToString();
                _currentStudent.MainLanguage = selectedLan;

            }
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentStudent.MainLanguage))
            {
                MessageBox.Show("Please select a language before confirming.");
                return;
            }

            StudentData.UpdateStudent(_currentStudent);
            // yk the deal 
            MessageBox.Show($"You have confirmed your choice: {_currentStudent.MainLanguage}");
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentStudent.MainLanguage))
            {
                MessageBox.Show("Please select a language before confirming.");
                return;
            }
            StudentData.UpdateStudent(_currentStudent);
            MessageBox.Show($"You have confirmed your choice: {_currentStudent.MainLanguage}");
            ChooseSecondLanguage chooseSecondLanguage = new ChooseSecondLanguage();
            chooseSecondLanguage.Show();
            this.Close();

        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }
    }
}
