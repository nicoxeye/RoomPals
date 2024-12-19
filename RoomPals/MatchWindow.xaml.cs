using Microsoft.Extensions.FileSystemGlobbing;
using RoomPals.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RoomPals
{
    public partial class MatchWindow : Window
    {
        private Student _loggedInStudent;
        private List<Student> _allStudents = StudentPersistence.LoadStudents();
        private List<Student> _acceptedMatches;
        private List<(Student, int)> _matches;
        private int _currentMatchIndex;

        public MatchWindow(Student loggedInStudent, List<Student> allStudents, List<Student> acceptedMatches, int currentMatchIndex)
        {
            InitializeComponent();
            _loggedInStudent = loggedInStudent;
            _allStudents = allStudents;
            _acceptedMatches = acceptedMatches;
            _currentMatchIndex = currentMatchIndex;
            _matches = Matchmaking.FindMatches(loggedInStudent, _allStudents);
        }

        private void StartChatting_Click(object sender, RoutedEventArgs e)
        {
            //its supposed to open chat with a matched_student (but we have default chatWindow for now :))
            
            ChatroomWindow chatroomWindow = new ChatroomWindow(_loggedInStudent, _allStudents, _acceptedMatches, _currentMatchIndex);
            chatroomWindow.Show();
            this.Close();

        }

        private void SaveToFavs_Click(object sender, RoutedEventArgs e)
        {
            //its supposed to add certain match to favourites (but we need a new Window for viewing all matches we accepted)
            //unavailable for now
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (_matches.Count != null && _matches.Count > 0)
            {
                if (_currentMatchIndex < _matches.Count - 1)
                {
                    _currentMatchIndex++;  //display another match
                }
                else
                {
                    MessageBox.Show("No more matches available, return to the MainPage to refresh your Matches.");
                    StartWindow startWindow = new StartWindow(_loggedInStudent); //nothing more in matches -> user is transfered to the MainPage
                    startWindow.Show();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("No matches found");
            }
       
            



        }
    }
}
