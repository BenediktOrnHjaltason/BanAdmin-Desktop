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
    /// Interaction logic for CreateBan.xaml
    /// </summary>
    public partial class CreateBan : Page
    {

        public CreateBan()
        {
            InitializeComponent();

            PartialBanSpecification.IsEnabled = false;
        }

        private void Male_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Female_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void FullBan_Checked(object sender, RoutedEventArgs e)
        {
            PartialBanSpecification.IsEnabled = false;
        }

        private void PartialBan_Checked(object sender, RoutedEventArgs e)
        {
            PartialBanSpecification.IsEnabled = true;
        }
    }
}
