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
    /// Interaction logic for EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        private Student _loggedInStudent;
        public EditProfileWindow(Student loggedInStudent)
        {
            InitializeComponent();
            _loggedInStudent = loggedInStudent;
        }

        private void go_back_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow(_loggedInStudent);
            startWindow.Show();
            this.Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            //edit
            NameTextBox.Text = _loggedInStudent.Name;
            LastNameTextBox.Text = _loggedInStudent.Surname;
            EmailTextBox.Text = _loggedInStudent.Email;
            UsernameTextBox.Text = _loggedInStudent.Username;
            PasswordTextBox.Text = _loggedInStudent.Password;
            MajorTextBox.Text = _loggedInStudent.Major;
        }
    }
}
