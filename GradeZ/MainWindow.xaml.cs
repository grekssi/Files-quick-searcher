using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Navigation;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/grekssi/GradeZ-File-Editor");
        }

        private void FileSearchButton(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("FileSearcherPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void FileRemoveButton(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("FileRemoverPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
