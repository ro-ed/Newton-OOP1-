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
    /// Interaction logic for UserControlCompetenceMech.xaml
    /// </summary>
    public partial class UserControlCompetenceMech : UserControl
    {
        public UserControlCompetenceMech()
        {
            InitializeComponent();
            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
            mechanics = readFromJson;

            Mechanic LoggedInMechanic = readFromJson.FirstOrDefault(x => x.UserID == LoggedInUserService.LoggedInUser.UserID);

            DataContext = LoggedInMechanic;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string MotorIsChecked = ((bool)cbMotorYes3.IsChecked) ? "Yes" : "No";
            string TiresAreChecked = ((bool)cbTiresYes3.IsChecked) ? "Yes" : "No";
            string BrakesAreChecked = ((bool)cbBrakesYes3.IsChecked) ? "Yes" : "No";
            string WindshieldsAreChecked = ((bool)cbWindshieldsYes3.IsChecked) ? "Yes" : "No";
            string VehicleBodyIsChecked = ((bool)cbVehicleBodyYes3.IsChecked) ? "Yes" : "No";

            var LoggedInMechanic = DataContext as Mechanic;

            LoggedInMechanic.CanFixEngines = MotorIsChecked;
            LoggedInMechanic.CanFixTires = TiresAreChecked;
            LoggedInMechanic.CanFixBrakes = BrakesAreChecked;
            LoggedInMechanic.CanFixWindshields = WindshieldsAreChecked;
            LoggedInMechanic.CanFixVehicleBody = VehicleBodyIsChecked;


            //Mechanic mechanic = new Mechanic
            //{
            //    CanFixMotor = MotorIsChecked,
            //    CanFixTires = TiresAreChecked,
            //    CanFixBrakes = BrakesAreChecked,
            //    CanFixWindshield = WindshieldsAreChecked,
            //    CanFixVehicleBody = VehicleBodyIsChecked
            //};

            var index = mechanics.FindIndex(x => x.MechID == LoggedInMechanic.MechID);
            mechanics[index] = LoggedInMechanic;
            DataContext = LoggedInMechanic;

            var jsonToWrite = JsonConvert.SerializeObject(mechanics, Formatting.Indented);
            var fs = File.OpenWrite(mechpath);
            using (var writer = new StreamWriter(mechpath))
            {
                writer.Write(jsonToWrite);

            }

            MessageBox.Show("Competence Changed!");
        }

    }


  }

