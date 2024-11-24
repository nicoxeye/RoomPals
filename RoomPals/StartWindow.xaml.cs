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
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void match_Click(object sender, RoutedEventArgs e)
        {
            ViewMatchesWindow viewMatchesWindow = new ViewMatchesWindow();
            viewMatchesWindow.Show();
            this.Hide();
        }

        private void editprofile_Click(object sender, RoutedEventArgs e)
        {
            EditProfileWindow editProfileWindow = new EditProfileWindow();
            editProfileWindow.Show();
            this.Hide();
        }

        private void quiz_Click(object sender, RoutedEventArgs e)
        {
            QuizChangeWindow quizChangeWindow = new QuizChangeWindow();
            quizChangeWindow.Show();
            this.Hide();

        }
    }
}
