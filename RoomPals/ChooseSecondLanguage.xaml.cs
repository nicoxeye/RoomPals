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
    /// Logika interakcji dla klasy ChooseSecondLanguage.xaml
    /// </summary>
    public partial class ChooseSecondLanguage : Window
    {
        public ChooseSecondLanguage()
        {
            InitializeComponent();
            UserNameTextBlock.Text = "Example:)!";
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            // this has to show if in account creation otherwise the user has to exit through the go back click
            QuizWindow quizWindow = new QuizWindow();
            quizWindow.Show();
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
