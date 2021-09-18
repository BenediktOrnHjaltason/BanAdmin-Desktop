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
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BanAdmin
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();

            BanAdminDBContext.Initialize();

            Debug.WriteLine("LOGIN CONSTRUCTOR CALLED!");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AttemptLogin(object sender, RoutedEventArgs e)
        {
            if (BanAdminDBContext.ValidateLoginAttempt(Input_Username.Text, Input_Password.Text))
            {
                Application.Current.MainWindow.Content = new Dashboard();
            }
            else MessageBox.Show("Invalid login");
        }
    }
}
