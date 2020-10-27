using GUI.UserControls;
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
    public partial class BosseHomePage : Page
    {
        public BosseHomePage()
        {
            InitializeComponent();
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            //LoginPage loginPage = new LoginPage();
            //this.NavigationService.Navigate(loginPage);
            Login.LoginPage loginPage = new Login.LoginPage();
            this.NavigationService.Navigate(loginPage);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //Hej
            Application.Current.Shutdown();
        }

        //private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    DragMove();
        //}

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    MainViewGrid.Children.Clear();
                    MainViewGrid.Children.Add(new UserControlHome());
                    break;
                case 1:
                    MainViewGrid.Children.Clear();
                    MainViewGrid.Children.Add(new UserControlAddMechanic());
                    break;
                default:
                    break;
            }
        }
        private void MoveCursorMenu(int index)
        {
            TransitionContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (170 + (60 * index)), 0, 0);
        }


    }
}
