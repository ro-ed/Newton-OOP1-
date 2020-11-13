using Logic.Entities;
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
using static GUI.UserControls.UserControlNewErrand;
using static Logic.Services.StaticLists;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for EditErrand.xaml
    /// </summary>
    public partial class EditErrand : UserControl
    {
        public EditErrand()
        {
            InitializeComponent();
        }

        private void EditErrandButton_Click(object sender, RoutedEventArgs e)
        {
            Errands selectedErrand = _newSelectedErrandTest;

            Guid CurrentErrandID = selectedErrand.ErrandID;

            errands.Remove(selectedErrand);


        }

        private void ErrandEditGoBackButton_Click(object sender, RoutedEventArgs e)
        {
            EditErrandView.Children.Clear();
            EditErrandView.Children.Add(new UserControlNewErrand());
        }
    }
}
