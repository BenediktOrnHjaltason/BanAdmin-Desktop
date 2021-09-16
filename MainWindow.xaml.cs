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
using System.Diagnostics;

namespace BanAdmin
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }

        private void CreateBan(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("You clicked CreateBan");
        }

        private void OpenOverview(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("You clicked Overview");
        }

        private void PrintReport(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("You clicked PrintReport");
        }

        private void OpenConfig(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("You clicked Config!");
        }
    }
}
