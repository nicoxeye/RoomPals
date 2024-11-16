using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoomPals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadDataFromJson();
        }

        private void LoadDataFromJson()
        {

        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow logInWindow = new LogInWindow();
            logInWindow.Show();
            this.Close();
        }

        private void Sign_up_Click(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            signInWindow.Show();
            this.Close();
        }
    }
}