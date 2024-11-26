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
        public ChooseTownWindow()
        {
            InitializeComponent();
            UserNameTextBlock.Text = "Example:)!"; //(temporary solution) here the code will enable to display
                                                   //the previously collected username
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
            StartWindow startWindow = new StartWindow();
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
