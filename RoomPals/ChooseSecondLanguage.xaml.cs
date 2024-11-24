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
            QuizWindow quizWindow = new QuizWindow();
            quizWindow.Show();
            this.Close();
        }
    }
}
