using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Threading;
using GradeZ.Searchers;
using MessageBox = System.Windows.MessageBox;
namespace GradeZ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ISearcher searcher;
        bool hasBeenClicked = false;
        private string _selectedPath = string.Empty;
        private string target = string.Empty;
        private string foundPath = string.Empty;
        private Thread T;
        public MainWindow()
        {
            InitializeComponent();
        }

        public string GetPath()
        {
            return this.FoundAt.Text;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            searcher = new NameSearcher();
            this.SpecifiedWord.Visibility = Visibility.Visible;
            this.FolderSearcher.Visibility = Visibility.Visible;
            this.Search.Visibility = Visibility.Visible;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            searcher = new ExtensionSearcher();
            this.SpecifiedWord.Visibility = Visibility.Visible;
            this.FolderSearcher.Visibility = Visibility.Visible;
            this.Search.Visibility = Visibility.Visible;
        }

        private void FolderSearch_OnChecked(object sender, RoutedEventArgs e)
        {
            searcher = new FolderSearcher();
            this.SpecifiedWord.Visibility = Visibility.Visible;
            this.FolderSearcher.Visibility = Visibility.Visible;
            this.Search.Visibility = Visibility.Visible;
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
                T = new Thread(x => searcher.Iterate(dirInfo, target), 200);
                T.Start();
                if (searcher.IsReady)
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
                System.Diagnostics.Process.Start(FoundAt.Text); //HERERERERRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
            }
        }

        private void FoundAt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //editFile
        {
           MainFrame.Navigate(new Uri("FoundFilePage.xaml",UriKind.RelativeOrAbsolute));
        }

    }
}
