﻿using System;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GradeZ.Searchers;
using MessageBox = System.Windows.MessageBox;

namespace GradeZ
{
    /// <summary>
    /// Interaction logic for FileSearcherPage.xaml
    /// </summary>
    public partial class FileSearcherPage : Page
    {
        public FileSearcherPage()
        {
            InitializeComponent();
        }
        private static ISearcher searcher;
        bool hasBeenClicked = false;
        private string _selectedPath = string.Empty;
        private string target = string.Empty;
        private string foundPath = string.Empty;
        private Thread T;

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
        private async void Button_Click(object sender, RoutedEventArgs e)
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
                await Task.Run(() => searcher.Iterate(dirInfo, target));
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
            MainFrame.Navigate(new Uri("FoundFilePage.xaml", UriKind.RelativeOrAbsolute));
        }

    }
}
