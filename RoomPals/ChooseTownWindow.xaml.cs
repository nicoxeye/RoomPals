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
        public ChooseTownWindow()
        {
            InitializeComponent();
            UserNameTextBlock.Text = "Example:)!"; //(temporary solution) here the code will enable to display
                                                   //the previously collected username
        }

        public ChooseTownWindow(Student loggedinStudent)
        {
            _loggedInStudent = loggedinStudent;
            InitializeComponent();
            UserNameTextBlock.Text = $"{loggedinStudent.Name}"; 
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //code that adds the town to the database of users
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {


        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            // this will be blocked if the user is in the account creation -> will add it later :3
            StartWindow startWindow = new StartWindow(_loggedInStudent);
            startWindow.Show();
            this.Close();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseYourUniversityWindow chooseYourUniversityWindow = new ChooseYourUniversityWindow();
            chooseYourUniversityWindow.Show();
            this.Hide();
        }
    }
}
