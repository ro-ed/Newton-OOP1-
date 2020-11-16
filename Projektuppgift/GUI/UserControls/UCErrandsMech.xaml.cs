using Logic.Entities;
using Logic.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using static Logic.Services.StaticLists;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCErrandsMech.xaml
    /// </summary>
    public partial class UCErrandsMech : UserControl
    {
        public UCErrandsMech()
        {
            InitializeComponent();

            string jsonFromFile;
            using (var reader = new StreamReader(pathforErrand))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Errands>>(jsonFromFile);
            errands = readFromJson;

            string jsonFromFile2;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile2 = reader.ReadToEnd();
            }
            var readFromJson2 = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
            mechanics = readFromJson2;
            
            Mechanic MechErrands = readFromJson2.FirstOrDefault(x => x.MechID == LoggedInUserService.LoggedInUser.UserID);
            
            

            DataContext = MechErrands;
            MechLV.ItemsSource = (System.Collections.IEnumerable)MechErrands;
        }


        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {
            //    var MechErrands = DataContext as Errands;
            //    {
            //        MechErrands.ErrandName =
            //        MechErrands.ErrandStartDate =
            //        MechErrands.ErrandEndDate =
            //        MechErrands.ErrandID =
            //        MechErrands.ErrandStatus =
            //        MechErrands.ComponentsNeeded =
            //        MechErrands.TypeOfVehicle =
            //        MechErrands.TypOfCar =
            //        MechErrands.ModelName =
            //        MechErrands.RegistrationNumber =
            //        MechErrands.Odometer =
            //        MechErrands.RegistrationDate =
            //        MechErrands.Propellant =
            //        MechErrands.HasTowbar =
            //        MechErrands.MaxNrPassengers =
            //        MechErrands.MaxLoad =
            //        MechErrands.Description =
            //        MechErrands.Amount =;


            //    }

            //var index = errands.FindIndex(x => x.ErrandID == MechErrands.ErrandID);
            //errands[index] = MechErrands;
            //DataContext = MechErrands;

        }


    }
}

