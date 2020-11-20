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
using static GUI.UserControls.UserControlNewErrand;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for ErandMechanicDetail.xaml
    /// </summary>
    public partial class ErandMechanicDetail : UserControl
    {
        public static Errands _test;
        public static Mechanic _test2;
        
        public ErandMechanicDetail()
        {
            InitializeComponent();

            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);            
            DataContext = readFromJson;

            Errands errands1 = _selectedErrand;

            Mechanic mechanic = readFromJson.FirstOrDefault(x => x.FirstName == errands1.FirstName);
            Mechanic mechanic1 = readFromJson.FirstOrDefault(x => x.SurName == errands1.LastName);

            Guid currentMechID = mechanic.MechID;

            //var findMechanic = readFromJson.FindIndex(x => x.ErrandIDs == errands1.ErrandID);

            //mechanics[findMechanic] = mechanic;

            tboldFirst.Text = mechanic.FirstName;
            tboldSur.Text = mechanic1.SurName;
            tboldBirth.Text = mechanic.DateOfBirth;
            tboldEmploy.Text = mechanic.DateOfEmployment;
            tboldEmployEnd.Text = mechanic.EndDate;
            tboldMechID.Text = currentMechID.ToString();
            tboldCFE.Text = mechanic.CanFixEngines;
            tboldCFT.Text = mechanic.CanFixTires;
            tboldCFB.Text = mechanic.CanFixBrakes;
            tboldCFWS.Text = mechanic.CanFixWindshields;
            tboldCFVB.Text = mechanic.CanFixVehicleBody;
            
            //mechanic.FirstName = this.tboldFirst.Text;
            //mechanic.SurName = this.tboldSur.Text;
            //mechanic.CanFixBrakes = this.tboldCFB.Text;
            //mechanic.CanFixEngines = this.tboldCFE.Text;
            //mechanic.CanFixTires = this.tboldCFT.Text;
            //mechanic.CanFixVehicleBody = this.tboldCFVB.Text;
            //mechanic.CanFixWindshields = this.tboldCFWS.Text;

            


            //DataContext = MechErrands;
            //MechLV.ItemsSource = (System.Collections.IEnumerable)MechErrands;

            //MechanicDetails.ItemsSource = mechanics;
            //MechanicDetailsList.ItemsSource = mechanics;
            //MechanicDetailsListCont.ItemsSource = mechanics;

            //Errands errands1 = _selectedErrand;

            //var mechanic = MechanicDetails.SelectedItem as Mechanic;

            //mechanic.ErrandIDs = errands1.ErrandID;

            //var indexOfMechanic = mechanics.FindIndex(x => x.ErrandIDs == errands1.ErrandID);

            //mechanics[indexOfMechanic] = mechanic;

            //errands1.FirstName = mechanic.FirstName;


            //Errands errands1 = _test;
            //Mechanic mechanic = _test2;

            //mechanic.FirstName = errands1.FirstName;


            //var test = mechanics.FirstOrDefault(x => x.FirstName == errands1.FirstName);

            //test = mechanic;

            //tboldSur.Text = mechanic.SurName;


            //Errands errands1 = _selectedErrand;

            ////var mechanic = MechanicViewer as Mechanic;
            //Mechanic mechanic = new Mechanic();

            ////mechanic.ErrandIDs = errands1.ErrandID;
            //mechanic.FirstName = errands1.FirstName;

            ////FIrst or default
            //var indexOfMechanic = mechanics.FirstOrDefault(x => x.FirstName == errands1.FirstName);

            ////mechanics[indexOfMechanic] = mechanic;
            ////string surName = tboldSur.Text;

            //errands1.FirstName = mechanic.FirstName;
            //mechanic.SurName = tboldSur.Text;



        }

        private void EditGoBackButton_Click(object sender, RoutedEventArgs e)
        {
            //Errands selectedErrand = MechanicChoose.SelectedItem as Errands;
            //_test = selectedErrand;
            //Errands errands1 = _selectedErrand;
            MechanicViewer.Children.Clear();
            MechanicViewer.Children.Add(new UserControlNewErrand());

        }

        
    }
}
