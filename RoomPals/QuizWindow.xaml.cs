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
    public partial class QuizWindow : Window
    {
        private Student _currentStudent;
        public QuizWindow(Student student)
        {
            _currentStudent = student;

            InitializeComponent();
            Night.Content = "Night";
            Day.Content = "Day";
            Dog.Content = "Dog";
            Cat.Content = "Cat";
            Party.Content = "Party";
            Book.Content = "Book";
            Active.Content= "Active";
            Passive.Content = "Passive";

            // to hide buttons' content 
            Night.Foreground = new SolidColorBrush(Colors.Transparent);
            Day.Foreground = new SolidColorBrush(Colors.Transparent);
            Dog.Foreground = new SolidColorBrush(Colors.Transparent);
            Cat.Foreground = new SolidColorBrush(Colors.Transparent);
            Party.Foreground = new SolidColorBrush(Colors.Transparent);
            Book.Foreground = new SolidColorBrush(Colors.Transparent);
            Active.Foreground = new SolidColorBrush(Colors.Transparent);
            Passive.Foreground = new SolidColorBrush(Colors.Transparent);
        }

        private void DogOrCat_Click(object sender, RoutedEventArgs e)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton != null)
            {
                string dogOrCat = clickedRadioButton.Content.ToString();
                _currentStudent.DogOrCat = dogOrCat;

            }
        }

        private void NightOrDay_Click(object sender, RoutedEventArgs e)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton != null)
            {
                string nightOrDay = clickedRadioButton.Content.ToString();
                _currentStudent.NightOrDay = nightOrDay;

            }
        }

        private void PartyOrBook_Click(object sender, RoutedEventArgs e)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton != null)
            {
                string partyOrBook = clickedRadioButton.Content.ToString();
                _currentStudent.PartyOrBook = partyOrBook;

            }
        }

        private void ActiveOrPassive_Click(object sender, RoutedEventArgs e)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton != null)
            {
                string activeOrPassive = clickedRadioButton.Content.ToString();
                _currentStudent.ActiveOrPassive = activeOrPassive;

            }
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            //bool to check if in every radiobutton group a option has been selected
            bool isNightOrDaySelected = Night.IsChecked.HasValue && Night.IsChecked.Value || Day.IsChecked.HasValue && Day.IsChecked.Value;
            bool isDogOrCatSelected = Dog.IsChecked.HasValue && Dog.IsChecked.Value || Cat.IsChecked.HasValue && Cat.IsChecked.Value;
            bool isPartyOrBookSelected = Party.IsChecked.HasValue && Party.IsChecked.Value || Book.IsChecked.HasValue && Book.IsChecked.Value;
            bool isActiveOrPassiveSelected = Active.IsChecked.HasValue && Active.IsChecked.Value || Passive.IsChecked.HasValue && Passive.IsChecked.Value;

            if (!isNightOrDaySelected || !isDogOrCatSelected || !isPartyOrBookSelected || !isActiveOrPassiveSelected)
            {
                MessageBox.Show("Please choose all the options before confirming.");
                return;
            }

            StudentData.UpdateStudent(_currentStudent);
            // messagebox to see if its working :3 (will be deleted in the final project)
            MessageBox.Show($"You have confirmed your choice: {_currentStudent.NightOrDay}," +
                $" {_currentStudent.DogOrCat}, {_currentStudent.PartyOrBook}, {_currentStudent.ActiveOrPassive}");

            LogInWindow logInWindow = new LogInWindow();
            logInWindow.Show();
            this.Close();
        }
    }
}
