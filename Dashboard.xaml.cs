using System;
using System.Collections.Generic;
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
using System.Diagnostics;

namespace BanAdmin
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void CreateBan(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("You clicked CreateBan");

        }

        private void RegisterIncident(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("You clicked RegisteredIncident");
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
