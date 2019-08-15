using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Forms;
using System.Windows.Threading;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;

namespace GradeZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool hasBeenClicked = false;
        private string selectedPath = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            if (SpecificWordCheck.IsChecked == true)
            {
                
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //specifiedword
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            //extension
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SpecificWordCheck.IsChecked == true)
            {
                Output.TextTrimming = TextTrimming.CharacterEllipsis;
                for (int i = 0; i < 40; i++)
                {
                   
                }
            }
        }
        //if (SpecifiedWord.Text == "Type Here")
                //{
                //    MessageBox.Show("Please enter valid word");
                //}

                //if (SelectedFolder.Text == string.Empty)
                //{
                //    MessageBox.Show("Please choose a starting folder");
                //}

        [DisplayName("Folder"), Browsable(true), ReadOnly(true)]
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                folderBrowser.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowser.Description = "Select starting folder";
                folderBrowser.ShowDialog();
                SelectedFolder.Text = folderBrowser.SelectedPath;
            }
        }
    }
}
