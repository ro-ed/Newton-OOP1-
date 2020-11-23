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
using System.IO;
using Newtonsoft.Json;
using GUI.UserControls;
using static Logic.Services.StaticLists;
using Projektuppgift.GUI.UserControls;
using System.Linq;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Data;
using Logic.Services;
using static Logic.Entities.Errands;
using static GUI.UserControls.UserControlNewErrand;


namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for ChooseMechanicToErrand.xaml
    /// </summary>
    public partial class ChooseMechanicToErrand : UserControl
    {
        public static int _index;

        public static Errands _test;
        
        //private static Errands _selectedErrand;
        public ChooseMechanicToErrand()
        {
            InitializeComponent();
            //_selectedErrand = errands;
            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);

            DataContext = this;
            MechanicChoose.ItemsSource = mechanics;

            

           


        }

        private async void AssignMechanicToErrand_Click(object sender, RoutedEventArgs e)
        {
            Errands errands1 = _selectedErrand;

            var mechanic = MechanicChoose.SelectedItem as Mechanic;

            mechanic.ErrandIDMech = errands1.ErrandID;

            var indexOfMechanic = mechanics.FindIndex(x => x.ErrandIDMech == errands1.ErrandID);

            mechanics[indexOfMechanic] = mechanic;

            errands1.FirstName = mechanic.FirstName;
            errands1.LastName = mechanic.SurName;
            //errands1.ComponentsNeeded = mechanic.CanFixBrakes;
            //errands1.ComponentsNeeded = mechanic.CanFixEngines;
            //errands1.ComponentsNeeded = mechanic.CanFixTires;
            //errands1.ComponentsNeeded = mechanic.CanFixVehicleBody;
            //errands1.ComponentsNeeded = mechanic.CanFixWindshields;
            string CFB = mechanic.CanFixBrakes;
            string CFE = mechanic.CanFixEngines;
            string CFT = mechanic.CanFixTires;
            string CFV = mechanic.CanFixVehicleBody;
            string CFW = mechanic.CanFixWindshields;
            string compNeed = errands1.ComponentsNeeded;

            //=========================================================================================
            var totalElementsInArray = mechanic.ErrandIDArray;
           
            var numberOfElements = (bool)mechanic.HasErrands ? totalElementsInArray.Count(): 0;                                                                 

            if (mechanic.ErrandIDArray[0].Equals(Guid.Empty))
            {
                _index = 0;
                mechanic.ErrandIDArray[_index] = errands1.ErrandID;
                var SetValueToMechanic = mechanics.FindIndex(x => x.ErrandIDArray[_index] == errands1.ErrandID);
                mechanics[SetValueToMechanic] = mechanic;
                _index++;
            }
            else if ((mechanic.ErrandIDArray[1].Equals(Guid.Empty)))
            {
                _index = 1;
                mechanic.ErrandIDArray[_index] = errands1.ErrandID;
                var SetValueToMechanic = mechanics.FindIndex(x => x.ErrandIDArray[_index] == errands1.ErrandID);
                mechanics[SetValueToMechanic] = mechanic;
                _index++;
            }
            else
            {
                MessageBox.Show("This mechanic has 2 errands already.", "Choose another mechanic.",
                MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
          
            //=========================================================================================
          
            if (mechanics.Count >= 1)
            {
                string jsonFromFile;
                using (var reader = new StreamReader(mechpath))
                {
                    jsonFromFile = reader.ReadToEnd();
                }
                var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
                //mechanics.Clear();
                //mechanics.Add(mechanic);
                var jsonToWrite = JsonConvert.SerializeObject(mechanics, Formatting.Indented);
                using (var writer = new StreamWriter(mechpath))
                {
                    await writer.WriteAsync(jsonToWrite);



            //mechanic.ActiveErrands++;

            //if (mechanic.ActiveErrands == 2)
            //{
            //    //MessageBox.Show("Sure ??", "DELETE", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK;
            //    MessageBox.Show("This mechanic already has 2 active errands. Please select another mechanic.",
            //        "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            //    ChooseMechanic.Children.Clear();
            //    ChooseMechanic.Children.Add(new ChooseMechanicToErrand());

            //}

            //errands.Remove(_selectedErrand);


            //if (errands1.Competence == "No")
            //{


            //    MessageBox.Show("Does not have the competence, choose another mechanic!");

            //}

            //else
            //{

            //if (errands.Count >= 1)
            //{
            //    string jsonFromFile;
            //    using (var reader = new StreamReader(pathforErrand))
            //    {
            //        jsonFromFile = reader.ReadToEnd();
            //    }
            //    var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
            //    errands.Add(errands1);
            //    var jsonToWrite = JsonConvert.SerializeObject(errands, Formatting.Indented);
            //    using (var writer = new StreamWriter(pathforErrand))
            //    {
            //        await writer.WriteAsync(jsonToWrite);

            //    }

                }
            }
            //ADD        

            errands.Remove(_selectedErrand);

            //}
            ////ADD
            //else
            //{
            //    errands.Add(errands1);
            //    var jsonToWrite = JsonConvert.SerializeObject(errands, Formatting.Indented);
            //    var fs = File.OpenWrite(pathforErrand);
            //    using (var writer = new StreamWriter(fs))
            //    {
            //        await writer.WriteAsync(jsonToWrite);

            //    }

            //}
            //ChooseMechanic.Children.Clear();
            //ChooseMechanic.Children.Add(new UserControlNewErrand());


            if (((compNeed == "CarTires" || compNeed == "MCTires" || compNeed == "BusTires" || compNeed == "TruckTires") && CFT == "Yes") ||
                ((compNeed == "CarBrakes" || compNeed == "MCBrakes" || compNeed == "BusBrakes" || compNeed == "TruckBrakes") && CFB == "Yes") ||
                ((compNeed == "CarMotors" || compNeed == "MCMotors" || compNeed == "BusMotors" || compNeed == "TruckMotors") && CFE == "Yes") ||
                ((compNeed == "CarWindshields" || compNeed == "MCWindshields" || compNeed == "BusWindshields" || compNeed == "TruckWindshields") && CFW == "Yes") ||
                ((compNeed == "CarVehicleBodies" || compNeed == "MCVehicleBodies" || compNeed == "BusVehicleBodies" || compNeed == "TruckVehicleBodies") && CFV == "Yes"))
            {
                if (errands.Count >= 1)
                {
                    string jsonFromFile;
                    using (var reader = new StreamReader(pathforErrand))
                    {
                        jsonFromFile = reader.ReadToEnd();
                    }
                    var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
                    errands.Add(errands1);
                    var jsonToWrite = JsonConvert.SerializeObject(errands, Formatting.Indented);
                    using (var writer = new StreamWriter(pathforErrand))
                    {
                        await writer.WriteAsync(jsonToWrite);

                    }
                }
                //ADD
                else
                {
                    errands.Add(errands1);
                    var jsonToWrite = JsonConvert.SerializeObject(errands, Formatting.Indented);
                    var fs = File.OpenWrite(pathforErrand);
                    using (var writer = new StreamWriter(fs))
                    {
                        await writer.WriteAsync(jsonToWrite);
                    }


                }
            
            //ADD
           

            
                ChooseMechanic.Children.Clear();
                ChooseMechanic.Children.Add(new UserControlNewErrand());
            }
            else
            {
                MessageBox.Show("Does not have the competence, choose another mechanic!");
            }

            //mechanic.ErrandIDs.Append(_selectedErrand.ErrandID);

            //var indexOfMechanic = mechanics.FindIndex(x => x.MechID == mechanic.MechID);

            //mechanics[indexOfMechanic] = mechanic;

            ////spara mekanikern;

            //Errands errand = new Errands
            //{
            //    FirstName = mechanic.FirstName
            //};

            //foreach (var item in errands)
            //{
            //    if (errand.FirstName == mechanic.FirstName)
            //    {
            //        string json = File.ReadAllText(pathforErrand);
            //        dynamic jsonOB = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            //        jsonOB[0]["FirstName"] = mechanic.FirstName;
            //        string test = Newtonsoft.Json.JsonConvert.SerializeObject(jsonOB, Newtonsoft.Json.Formatting.Indented);
            //        using (var jsonWriter = new StreamWriter(pathforErrand))
            //        {
            //            jsonWriter.Write(jsonOB);
            //        }
            //    }
            //}

            //string json = File.ReadAllText(pathforErrand);
            //dynamic jsonOB = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            ////jsonOB[0]["FirstName"] = mechanic.FirstName + " " + mechanic.SurName;
            //jsonOB[0]["FirstName"] = mechanic.FirstName + " " + mechanic.SurName;                
            //string test = Newtonsoft.Json.JsonConvert.SerializeObject(jsonOB, Newtonsoft.Json.Formatting.Indented);
            //using (var jsonWriter = new StreamWriter(pathforErrand))
            //{
            //    jsonWriter.Write(jsonOB);
            //}


            //Errands errands = new Errands();
            //string json = File.ReadAllText(pathforErrand);
            //dynamic jsonOB = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            //jsonOB[0]["FirstName"] = mechanic.FirstName + " " + mechanic.SurName;
            ////jsonOB[errands.FirstName = "FirstName"] = mechanic.FirstName;

            //string test = Newtonsoft.Json.JsonConvert.SerializeObject(jsonOB, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText(pathforErrand, test);
            //using (var jsonWriter = new StreamWriter(pathforErrand))
            //{
            //    jsonWriter.Write(jsonOB);
            //}








            //string json = File.ReadAllText(pathforErrand);
            //dynamic jsonOB = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            //jsonOB[0]["FirstName"] = mechanic.FirstName;
            //string test = Newtonsoft.Json.JsonConvert.SerializeObject(jsonOB, Newtonsoft.Json.Formatting.Indented);
            //using (var jsonWriter = new StreamWriter(pathforErrand))
            //{
            //        jsonWriter.Write(jsonOB);
            //}

            //Errands errand = new Errands
            //{

            //    FirstName = mechanic.FirstName

            //};

            //if (errands.Count >= 1)
            //{
            //    string jsonFile;

            //    using (var reader = new StreamReader(pathforErrand))
            //    {
            //        jsonFile = reader.ReadToEnd();
            //    }

            //    var jsonRead = JsonConvert.DeserializeObject<List<Errands>>(jsonFile);
            //    //errands.Add(errand);
            //    var jsonWrite = JsonConvert.SerializeObject(errands, Formatting.Indented);
            //    using (var jsonWriter = new StreamWriter(pathforErrand))
            //    {
            //        jsonWriter.Write(jsonWrite);
            //    }

            //}

            //else
            //{
            //    //errands.Add(errand);
            //    var jsonWrite = JsonConvert.SerializeObject(errands, Formatting.Indented);
            //    using (var jsonWriter = new StreamWriter(pathforErrand))
            //    {
            //        jsonWriter.Write(jsonWrite);
            //    }
            //}








        }

        private void MechanicChoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mechanic mechanic = (Mechanic)MechanicChoose.SelectedItem;
        }

        
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseMechanic.Children.Clear();
            ChooseMechanic.Children.Add(new UserControlNewErrand());
        }
    }
}
