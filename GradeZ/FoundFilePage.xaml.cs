using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
using Application = System.Windows.Application;

namespace GradeZ
{
    /// <summary>
    /// Interaction logic for FoundFilePage.xaml
    /// </summary>
    public partial class FoundFilePage : Page
    {
        private FileInfo file;
        public FoundFilePage()
        {
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var content = new MainWindow();
            content.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
