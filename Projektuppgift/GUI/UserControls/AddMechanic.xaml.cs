using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Logic.Entities;
using System.IO;
using Newtonsoft.Json;
using static Logic.Services.AddMechanicService;
using GUI.UserControls;

namespace Projektuppgift.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlAddMechanic.xaml
    /// </summary>
    public partial class AddMechanic : UserControl
    {
        private const string AddMessage = "You have added a mechanic!";
        public AddMechanic()
        {
            InitializeComponent();
            //Hämta mekaniker från JSON.           
            //string jsonFromFile;
            //    using (var reader = new StreamReader(mechpath))
            //    {
            //        jsonFromFile = reader.ReadToEnd();
            //    }
            //    var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
            //Lägg till i listan.
            
            //mechanics.AddRange(readFromJson);

        }

        public void AddMechanicButton_Click(object sender, RoutedEventArgs e)
        {


            string firstName = this.tbFirstName.Text;
            string surName = this.tbSurName.Text;
            string dateOfBirth = this.tbDateOfBirth.Text;
            string dateOfEmployment = this.tbDateOfEmployment.Text;
            string employmentEnds = this.tbEmploymentEnds.Text;
            string MotorIsChecked = ((bool)cbMotorYes.IsChecked) ? "Yes" : "No";
            string TiresAreChecked = ((bool)cbTiresYes.IsChecked) ? "Yes" : "No";
            string BrakesAreChecked = ((bool)cbBrakesYes.IsChecked) ? "Yes" : "No";
            string WindshieldsAreChecked = ((bool)cbWindshieldsYes.IsChecked) ? "Yes" : "No";
            string VehicleBodyIsChecked = ((bool)cbVehicleBodyYes.IsChecked) ? "Yes" : "No";

            Mechanic mechanic = new Mechanic
            {
                FirstName = firstName,
                SurName = surName,
                DateOfBirth = dateOfBirth,
                DateOfEmployment = dateOfEmployment,
                EndDate = employmentEnds,
                MechID = Guid.NewGuid(),
                CanFixMotor = MotorIsChecked,
                CanFixTires = TiresAreChecked,
                CanFixBrakes = BrakesAreChecked,
                CanFixWindshield = WindshieldsAreChecked,
                CanFixVehicleBody = VehicleBodyIsChecked

            };
       
            //READ
            if (mechanics.Count >= 1)
            {
                string jsonFromFile;
                using (var reader = new StreamReader(mechpath))
                {
                    jsonFromFile = reader.ReadToEnd();
                }
                var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
                mechanics.Add(mechanic);
                var jsonToWrite = JsonConvert.SerializeObject(mechanics, Formatting.Indented);
                using (var writer = new StreamWriter(mechpath)) 
                {   
                writer.Write(jsonToWrite);
                
                }
            }
            //ADD
            else
            {
                mechanics.Add(mechanic);
                var jsonToWrite = JsonConvert.SerializeObject(mechanics, Formatting.Indented);
                using (var writer = new StreamWriter(mechpath))
                {
                    writer.Write(jsonToWrite);

                }
            }
            AddMechView.Children.Clear();
            AddMechView.Children.Add(new AddMechanic());

            MessageBox.Show(AddMessage);
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            AddMechView.Children.Clear();
            AddMechView.Children.Add(new MechanicHome());

        }
    }
}     

   


            //if (File.Exists(mechpath))
            //{
            //    File.OpenRead(mechpath);              
            //    var readText = File.ReadAllText(mechpath);
            //    if (readText.Length > 0)
            //    {
            //        JsonConvert.DeserializeObject(mechpath);
            //        mechanics.Add(mechanic);
            //        File.WriteAllText(mechpath, JsonConvert.SerializeObject(mechanics));
            //    }
            //}
            //else
            //{
            //    File.Create(mechpath);
            //    mechanics.Add(mechanic);
            //    File.WriteAllText(mechpath, JsonConvert.SerializeObject(mechanics));
            //}

            //AddMechanicService.SaveMechanic(AddMechanicService.mechanics);

            
 
            //if (File.Exists(AddMechanicService.mechpath) && AddMechanicService.mechanics.Count > 1)
            //{
            //    var jsonString = File.ReadAllText(AddMechanicService.mechpath);
            //    var list = JsonConvert.DeserializeObject<List<Mechanic>>(jsonString);
            //    list.Add(mechanic);             
            //    File.WriteAllText(AddMechanicService.mechpath, JsonConvert.SerializeObject(list, Formatting.Indented));

            //}
        
    

