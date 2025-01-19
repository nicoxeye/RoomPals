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
    /// Logika interakcji dla klasy ChatroomWindow.xaml
    /// </summary>
    
    public partial class ChatroomWindow : Window
    {
        private Student _loggedInStudent;
        private List<Student> _allStudents;
        private List<Student> _acceptedMatches;
        private List<(Student, int)> _matches;
        private int _currentMatchIndex;
        private bool isViewingMatches = false;

        public ChatroomWindow(Student loggedInStudent)
        {
            InitializeComponent();
            _loggedInStudent = loggedInStudent;
            isViewingMatches=false;
    }
        public ChatroomWindow(Student loggedInStudent, List<Student> allStudents, List<Student> acceptedMatches, int currentMatchIndex)
        {
            InitializeComponent();
            _loggedInStudent = loggedInStudent;
            _currentMatchIndex = currentMatchIndex;
            _allStudents = allStudents ?? new List<Student>();  // Default to an empty list if null
            _matches = Matchmaking.FindMatches(loggedInStudent, _allStudents);
            _acceptedMatches = acceptedMatches ?? new List<Student>();  // Default to an empty list if null
            isViewingMatches = true;
        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("isViewingMatches: " + isViewingMatches);
            if (isViewingMatches)  // if user was viewingmatches:
            {
                if (_currentMatchIndex < _matches.Count - 1)
                {
                    _currentMatchIndex++;  // Przechodzimy do następnego matcha
                }
                else
                {
                    MessageBox.Show("No more matches available, return to the Main Page to refresh your Matches.");
                    StartWindow startWindow = new StartWindow(_loggedInStudent); // nothing else in matches -> user is transfered to Main Page
                    startWindow.Show();
                    this.Close();
                }
                ViewMatchesWindow viewMatchesWindow = new ViewMatchesWindow(_loggedInStudent, _allStudents, _acceptedMatches, _currentMatchIndex);
                viewMatchesWindow.Show();
                this.Close();
            }
            else
            {
                // if user wasn't viewing matches, just go to Main Page
                StartWindow startWindow = new StartWindow(_loggedInStudent);
                startWindow.Show();
                this.Close();
            }
        }

        private void toButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void subjectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
