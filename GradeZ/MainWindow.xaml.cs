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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GradeZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool hasBeenClicked = false;

        public MainWindow()
        {
            InitializeComponent();
            if (SpecificWordCheck.IsChecked == true)
            {
                
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (SpecifiedWord.IsFocused && hasBeenClicked == false)
            {
                SpecifiedWord.Text = "";
                hasBeenClicked = true;
            }
        }
    }
}
