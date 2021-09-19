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
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AttemptLogin(object sender, RoutedEventArgs e)
        {
            foreach (BanAdminDBContext.LoginDetails login in BanAdminDBContext.activeContext.loginDetails)
            {
                if (Input_Username.Text == login.Username && Input_Password.Text == login.Password)
                {
                    Application.Current.MainWindow.Content = new Dashboard();
                    return;
                }
                    
                else continue;
            }

            MessageBox.Show("Invalid login");

        }
    }
}
