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
using static Logic.Services.AddErrandService;
using static Logic.Services.AddMechanicService;
using Projektuppgift.GUI.UserControls;
using System.Linq;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Data;
using Logic.Services;
using static Logic.Entities.Errands;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for ChooseMechanicToErrand.xaml
    /// </summary>
    public partial class ChooseMechanicToErrand : UserControl
    {
        private readonly Errands _selectedErrand;
        public ChooseMechanicToErrand(Errands errands)
        {
            InitializeComponent();
            _selectedErrand = errands;
            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);

            DataContext = this;
            MechanicChoose.ItemsSource = mechanics;
            



        }

        private void AssignMechanicToErrand_Click(object sender, RoutedEventArgs e)
        {
            var mechanic = MechanicChoose.SelectedItem as Mechanic;

          
            mechanic.ErrandIDs.Append(_selectedErrand.ErrandID);

            var indexOfMechanic = mechanics.FindIndex(x => x.MechID == mechanic.MechID);

            mechanics[indexOfMechanic] = mechanic;

            //spara mekanikern;

            Errands errand = new Errands
            {
                FirstName = mechanic.FirstName
            };

            foreach (var item in errands)
            {
                if (errand.FirstName == mechanic.FirstName)
                {
                    string json = File.ReadAllText(pathforErrand);
                    dynamic jsonOB = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                    jsonOB[0]["FirstName"] = mechanic.FirstName;
                    string test = Newtonsoft.Json.JsonConvert.SerializeObject(jsonOB, Newtonsoft.Json.Formatting.Indented);
                    using (var jsonWriter = new StreamWriter(pathforErrand))
                    {
                        jsonWriter.Write(jsonOB);
                    }
                }
            }

            

            //MechanicChoose.Children.Clear();
            //MechanicChoose.Children.Add(new UserControlNewErrand());

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
