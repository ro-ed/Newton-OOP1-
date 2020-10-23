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

namespace GUI.Home
{
    /// <summary>
    /// Interaction logic for BossesHemsida.xaml
    /// </summary>
    public partial class BossesHemsida : Page
    {
        public BossesHemsida()
        {
            InitializeComponent();
        }

        private void signOutButton_Click(object sender, RoutedEventArgs e)
        {
            //LoginPage loginPage = new LoginPage();
            //this.NavigationService.Navigate(loginPage);
            Login.LoginPage loginPage = new Login.LoginPage();
            this.NavigationService.Navigate(loginPage);
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
