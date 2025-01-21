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
    /// Logika interakcji dla klasy ChooseYourUniversityWindow.xaml
    /// </summary>
    public partial class ChooseYourUniversityWindow : Window
    {
        private Student _loggedInStudent;
        private bool _isAccountCreation;
        public ChooseYourUniversityWindow(Student student, bool isAccountCreation)
        {
            _loggedInStudent = student;
            _isAccountCreation = isAccountCreation;
            InitializeComponent();
            UserNameTextBlock.Text = $"{_loggedInStudent.Name}";
            UOE.Content = "University Of Economics";
            SUOT.Content = "Silesian University Of Technology";
            UOS.Content = "University Of Silesia";
            UOCF.Content = "University Of Catching Fishes";
            UOMH.Content = "University Of Mushroom Hunting";
            MAOS.Content = "Midwich Academy Of Shadows";
        }

        private void UniButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton != null)
            {
                string selectedUni = clickedRadioButton.Content.ToString();
                _loggedInStudent.University = selectedUni;
            }
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_loggedInStudent.University))
            {
                MessageBox.Show("Please select a university before confirming.");
                return;
            }

            StudentData.UpdateStudent(_loggedInStudent);
            MessageBox.Show($"You have confirmed your choice: {_loggedInStudent.University}");
            if (_isAccountCreation)
            {
                ChooseFirstLanguage chooseFirstLanguage1 = new ChooseFirstLanguage(_loggedInStudent, true);
                chooseFirstLanguage1.Show();
                this.Hide();
            }
            else
            {
                ChooseFirstLanguage chooseFirstLangugage= new ChooseFirstLanguage(_loggedInStudent, false);
                chooseFirstLangugage.Show();
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
