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
    /// Logika interakcji dla klasy ChooseFirstLanguage.xaml
    /// </summary>
    public partial class ChooseFirstLanguage : Window
    {
        public ChooseFirstLanguage()
        {
            InitializeComponent();
            UserNameTextBlock.Text = "Example:)!";
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseSecondLanguage chooseSecondLanguage = new ChooseSecondLanguage();
            chooseSecondLanguage.Show();
            this.Hide();
        }
    }
}
