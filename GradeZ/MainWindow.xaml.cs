using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using GradeZ.Searchers;
using MessageBox = System.Windows.MessageBox;
using TextBox = System.Windows.Controls.TextBox;
using UserControl = System.Windows.Controls.UserControl;
namespace GradeZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool hasBeenClicked = false;
        private string _selectedPath = string.Empty;
        private string target = string.Empty;
        private string foundPath = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.SpecifiedWord.Visibility = Visibility.Visible;
            this.FolderSearch.Visibility = Visibility.Visible;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            this.SpecifiedWord.Visibility = Visibility.Visible;
            this.FolderSearch.Visibility = Visibility.Visible;
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

            target = SpecifiedWord.Text;
        }

        //make async
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //for (int i = 0; i < 40; i++)
            //{
            //    await Task.Delay(100);
            //    Output.Text += $"Text{i}\n";
            //}
            if (SpecifiedWord.Text == "Type Here" || SelectedFolder.Text == string.Empty)
            {
                MessageBox.Show("Please enter valid File Name or choose a valid folder!");
            }
            else
            {
                DirectoryInfo dirInfo = new DirectoryInfo(_selectedPath);
                NameSearcher searcher = new NameSearcher();
                if (searcher.Iterate(dirInfo, target))
                {
                    Status.Visibility = Visibility.Visible;
                    Status.Text = "Found";
                    FoundAtText.Visibility = Visibility.Visible;
                    foundAt.Visibility = Visibility.Visible;
                    FoundAt.Visibility = Visibility.Visible;
                    FoundAt.Text = searcher.GetDirectory();
                    OpenFolder.Visibility = Visibility.Visible;
                    EditFile.Visibility = Visibility.Visible;

                }
                else
                {
                    Status.Visibility = Visibility.Visible;
                    Status.Text = "NotFound";
                }
            }
        }


        [DisplayName("Folder"), Browsable(true), ReadOnly(true)]
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                folderBrowser.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowser.Description = "Select starting folder";
                folderBrowser.ShowDialog();
                SelectedFolder.Visibility = Visibility.Visible;
                SelectedFolder.Text = folderBrowser.SelectedPath;
                _selectedPath = folderBrowser.SelectedPath;
                if (_selectedPath != string.Empty && SpecifiedWord.Text != "Type Here" && SelectedFolder.Text != string.Empty)
                {
                    Search.Visibility = Visibility.Visible;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //open folder
        {
            if (FoundAt.Text == string.Empty)
            {
                MessageBox.Show("Invalid Operation");
            }
            else
            {
                System.Diagnostics.Process.Start(FoundAt.Text);
            }
        }

        private void FoundAt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //editFile
        {
            var contentToDisplay = new FoundFile();
            this.Content = contentToDisplay.Content;
        }
    }
}
