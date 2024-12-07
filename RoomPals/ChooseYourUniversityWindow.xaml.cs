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
        private Student _currentStudent;
        public ChooseYourUniversityWindow(Student student)
        {
            _currentStudent = student;
            InitializeComponent();
            UserNameTextBlock.Text = $"{_currentStudent.Name}";
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
                _currentStudent.University = selectedUni;
            }
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentStudent.University))
            {
                MessageBox.Show("Please select a university before confirming.");
                return;
            }

            StudentData.UpdateStudent(_currentStudent);
            // messagebox only for me to see if its working (again hehe)
            MessageBox.Show($"You have confirmed your choice: {_currentStudent.University}");
        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            // this will be blocked if the user is in the account creation -> will add it later :3
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_currentStudent.University))
            {
                MessageBox.Show("Please select a university before confirming.");
                return;
            }

            StudentData.UpdateStudent(_currentStudent);

            // messagebox only for me to see if its working (again hehe)
            MessageBox.Show($"You have confirmed your choice: {_currentStudent.University}");
            ChooseFirstLanguage chooseFirstLanguage = new ChooseFirstLanguage();
            chooseFirstLanguage.Show();
            this.Hide();
        }
    }
}
