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
    public partial class CreateAccountWindow : Window
    {
        private Student _currentStudent;
        public CreateAccountWindow(Student student)
        {
            InitializeComponent();
           _currentStudent = student;

        }

        private void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseTownWindow chooseTownWindow = new ChooseTownWindow();
            chooseTownWindow.Show();
            this.Hide();
        }
    }
}
