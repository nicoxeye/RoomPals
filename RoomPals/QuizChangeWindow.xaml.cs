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
    /// Interaction logic for QuizChangeWindow.xaml
    /// </summary>
    public partial class QuizChangeWindow : Window
    {
        public QuizChangeWindow()
        {
            InitializeComponent();
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }
    }
}
