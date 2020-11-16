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
using static Logic.DAL.GenericClass;
using Logic.Entities;
using Logic.Interfaces;
using Newtonsoft.Json;
using Projektuppgift.GUI.UserControls;
using System.IO;
using System.Linq;
using static Logic.Services.StaticLists;
using static Logic.Entities.Mechanic;
using static Logic.Entities.Errands;
using static GUI.UserControls.MechanicHome;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for ErandMechanicDetail.xaml
    /// </summary>
    public partial class ErandMechanicDetail : UserControl
    {
       
        public ErandMechanicDetail()
        {
            InitializeComponent();

            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);

        }

        private void EditGoBackButton_Click(object sender, RoutedEventArgs e)
        {
            //Errands selectedErrand = MechanicChoose.SelectedItem as Errands;
            //_test = selectedErrand;


            MechanicDetailView.Children.Clear();
            MechanicDetailView.Children.Add(new UserControlNewErrand());
        }
    }
}
