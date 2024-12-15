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
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private Student _loggedInStudent;
        List<Student> allStudents = StudentData.Students;
        public StartWindow()
        {
            InitializeComponent();
        }
        public StartWindow(Student loggedInStudent)
        {
            InitializeComponent();
            _loggedInStudent = loggedInStudent;
            UsernameTextBlock.Text = $"{_loggedInStudent.Name}";
        }

        private void match_Click(object sender, RoutedEventArgs e)
        {
            ViewMatchesWindow viewMatchesWindow = new ViewMatchesWindow(_loggedInStudent, allStudents);
            viewMatchesWindow.Show();
            this.Close();
        }

        private void editprofile_Click(object sender, RoutedEventArgs e)
        {
            EditProfileWindow editProfileWindow = new EditProfileWindow(_loggedInStudent);
            editProfileWindow.Show();
            this.Hide();
        }

        private void quiz_Click(object sender, RoutedEventArgs e)
        {
            QuizChangeWindow quizChangeWindow = new QuizChangeWindow();
            quizChangeWindow.Show();
            this.Hide();

        }

        private void town_Click(object sender, RoutedEventArgs e)
        {
            ChooseTownWindow chooseTownWindow = new ChooseTownWindow(_loggedInStudent, false);
            chooseTownWindow.Show();
            this.Hide();
        }

        private void uni_Click(object sender, RoutedEventArgs e)
        {
            ChooseYourUniversityWindow chooseYourUniversityWindow = new ChooseYourUniversityWindow(_loggedInStudent, false);
            chooseYourUniversityWindow.Show();
            this.Hide();
        }

        private void language1_Click(object sender, RoutedEventArgs e)
        {
            ChooseFirstLanguage chooseFirstLanguage = new ChooseFirstLanguage(_loggedInStudent, false);
            chooseFirstLanguage.Show();
            this.Hide();
        }

        private void language2_Click(object sender, RoutedEventArgs e)
        {
            ChooseSecondLanguage chooseSecondLanguage = new ChooseSecondLanguage(_loggedInStudent, false);
            chooseSecondLanguage.Show();
            this.Hide();
        }

        private void chat_Click(object sender, RoutedEventArgs e)
        {
            ChatroomWindow chatroomWindow = new ChatroomWindow(_loggedInStudent);  
            chatroomWindow.Show();
            this.Hide();
        }
    }
}
