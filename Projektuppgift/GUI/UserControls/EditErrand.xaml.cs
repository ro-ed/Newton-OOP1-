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
using Newtonsoft.Json;
using System.IO;
using GUI.UserControls;
using Projektuppgift.GUI.UserControls;
using System.Linq;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Serialization;
using static Logic.Entities.Stock;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for EditErrand.xaml
    /// </summary>
    public partial class EditErrand : UserControl
    {
        
        public int _selectedIndex = 0;
        public int _selectedIndexNeed = 0;
        public EditErrand()
        {
            InitializeComponent();

            //string jsonFile;
            //using (var reader = new StreamReader(pathforErrand))
            //{
            //    jsonFile = reader.ReadToEnd();
            //}

            //var jsonRead = JsonConvert.DeserializeObject<List<Errands>>(jsonFile);
            //errands = jsonRead;

            string jsonFromFile6;
            using (var reader = new StreamReader(stockpath))
            {
                jsonFromFile6 = reader.ReadToEnd();
            }
            var stockread = JsonConvert.DeserializeObject<Stock>(jsonFromFile6);
            
            DataContext = stockread;
        }

        private void EditErrandButton_Click(object sender, RoutedEventArgs e)
        {
            Errands selectedErrand = _newSelectedErrandTest;

            var currentMechanic = selectedErrand.FirstName;

            Guid CurrentErrandID = selectedErrand.ErrandID;

            errands.Remove(selectedErrand);
                      

            StockChangeNeed();
            StockChangeAdd();

            string errandName = this.tbErrandName.Text;
            string errandStart = this.tbStartDate.Text;
            string errandEnd = this.tbEndDate.Text;
            string componentsNeed = this.InvComboBoxNeed.Text;
            string componentsReturned = this.InvComboBoxReturned.Text;
            int amountOfComp = int.Parse(this.tbAmountNeed.Text);

            string vehicleType = this.VehicleComboBox.Text;
            string carType = this.TypeCarComboBox.Text;

            string modelType = this.tbModel.Text;
            string regNr = this.tbRegistrationNumber.Text;
            int odoMeterm = int.Parse(this.tbOdometer.Text);
            DateTime regDate = DateTime.Parse(this.tbRegistrationDate.Text);
            string typePropellant = this.TypePropellantComboBox.Text;
            string hasTow = this.tbHasTowbar.Text;
            int maxPass = int.Parse(this.tbMaxNrPass.Text);
            int loadMax = int.Parse(this.tbMaxLoad.Text);
            string writeDescription = this.tbDescription.Text;

            string finished = ((bool)cbStatusFinished.IsChecked) ? "Finished" : "OnGoing";

            Errands errand = new Errands
            {
                ErrandName = errandName,
                ErrandStartDate = errandStart,
                ErrandEndDate = errandEnd,
                ErrandID = CurrentErrandID,
                ErrandStatus = finished,
                ComponentsNeeded = componentsNeed,
                TypeOfVehicle = vehicleType,
                TypOfCar = carType,
                ModelName = modelType,
                RegistrationNumber = regNr,
                Odometer = odoMeterm,
                RegistrationDate = regDate,
                Propellant = typePropellant,
                HasTowbar = hasTow,
                MaxNrPassengers = maxPass,
                MaxLoad = loadMax,
                Description = writeDescription,
                Amount = amountOfComp,
                FirstName = currentMechanic

            };

            //if (errands.Count >= 1)
            //{
            //    string jsonFile;

            //    using (var reader = new StreamReader(pathforErrand))
            //    {
            //        jsonFile = reader.ReadToEnd();
            //    }

            //    var jsonRead = JsonConvert.DeserializeObject<List<Errands>>(jsonFile);
            //    errands.Add(errand);
            //    var jsonWrite = JsonConvert.SerializeObject(errands, Formatting.Indented);
            //    var fs = File.OpenWrite(pathforErrand);
            //    using (var jsonWriter = new StreamWriter(fs))
            //    {
            //        await jsonWriter.WriteAsync(jsonWrite);
            //    }

            //}

            //else
            //{
            //errands.Add(errand);
            //var jsonWrite = JsonConvert.SerializeObject(errands, Formatting.Indented);
            //var fs = File.OpenWrite(pathforErrand);
            //using (var jsonWriter = new StreamWriter(fs))
            //{
            //    await jsonWriter.WriteAsync(jsonWrite);
            //}
            //}

            errands.Add(errand);
            var jsonWrite = JsonConvert.SerializeObject(errands, Formatting.Indented);
            using (var jsonWriter = new StreamWriter(pathforErrand))
            {
                jsonWriter.Write(jsonWrite);
            }
            

            EditErrandView.Children.Clear();
            EditErrandView.Children.Add(new UserControlNewErrand());

        }

        public void ErrandEditGoBackButton_Click(object sender, RoutedEventArgs e)
        {
            EditErrandView.Children.Clear();
            EditErrandView.Children.Add(new UserControlNewErrand());
        }

        public void StockChangeNeed()
        {
            string jsonFromFile;
            using (var reader = new StreamReader(stockpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var stock = JsonConvert.DeserializeObject<Stock>(jsonFromFile);

            switch (_selectedIndexNeed)
            {

                case 0:
                    stock.CarTires -= int.Parse(tbAmountNeed.Text);
                    break;
                case 1:
                    stock.CarBrakes -= int.Parse(tbAmountNeed.Text);
                    break;
                case 2:
                    stock.CarEngines -= int.Parse(tbAmountNeed.Text);
                    break;
                case 3:
                    stock.CarWindshields -= int.Parse(tbAmountNeed.Text);
                    break;
                case 4:
                    stock.CarVehicleBodies -= int.Parse(tbAmountNeed.Text);
                    break;
                case 5:
                    stock.MCTires -= int.Parse(tbAmountNeed.Text);
                    break;
                case 6:
                    stock.MCBrakes -= int.Parse(tbAmountNeed.Text);
                    break;
                case 7:
                    stock.MCEngines -= int.Parse(tbAmountNeed.Text);
                    break;
                case 8:
                    stock.MCWindshields -= int.Parse(tbAmountNeed.Text);
                    break;
                case 9:
                    stock.MCVehicleBodies -= int.Parse(tbAmountNeed.Text);
                    break;
                case 10:
                    stock.BusTires -= int.Parse(tbAmountNeed.Text);
                    break;
                case 11:
                    stock.BusBrakes -= int.Parse(tbAmountNeed.Text);
                    break;
                case 12:
                    stock.BusEngines -= int.Parse(tbAmountNeed.Text);
                    break;
                case 13:
                    stock.BusWindshields -= int.Parse(tbAmountNeed.Text);
                    break;
                case 14:
                    stock.BusVehicleBodies -= int.Parse(tbAmountNeed.Text);
                    break;
                case 15:
                    stock.TruckTires -= int.Parse(tbAmountNeed.Text);
                    break;
                case 16:
                    stock.TruckBrakes -= int.Parse(tbAmountNeed.Text);
                    break;
                case 17:
                    stock.TruckEngines -= int.Parse(tbAmountNeed.Text);
                    break;
                case 18:
                    stock.TruckWindshields -= int.Parse(tbAmountNeed.Text);
                    break;
                case 19:
                    stock.TruckVehicleBodies -= int.Parse(tbAmountNeed.Text);
                    break;

            }

            File.WriteAllText(stockpath, JsonConvert.SerializeObject(stock));
        }

        public void StockChangeAdd()
        {
            string jsonFromFile;
            using (var reader = new StreamReader(stockpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var stock = JsonConvert.DeserializeObject<Stock>(jsonFromFile);

            switch (_selectedIndex)
            {

                case 0:
                    stock.CarTires += int.Parse(tbAmount.Text);
                    break;
                case 1:
                    stock.CarBrakes += int.Parse(tbAmount.Text);
                    break;
                case 2:
                    stock.CarEngines += int.Parse(tbAmount.Text);
                    break;
                case 3:
                    stock.CarWindshields += int.Parse(tbAmount.Text);
                    break;
                case 4:
                    stock.CarVehicleBodies += int.Parse(tbAmount.Text);
                    break;
                case 5:
                    stock.MCTires += int.Parse(tbAmount.Text);
                    break;
                case 6:
                    stock.MCBrakes += int.Parse(tbAmount.Text);
                    break;
                case 7:
                    stock.MCEngines += int.Parse(tbAmount.Text);
                    break;
                case 8:
                    stock.MCWindshields += int.Parse(tbAmount.Text);
                    break;
                case 9:
                    stock.MCVehicleBodies += int.Parse(tbAmount.Text);
                    break;
                case 10:
                    stock.BusTires += int.Parse(tbAmount.Text);
                    break;
                case 11:
                    stock.BusBrakes += int.Parse(tbAmount.Text);
                    break;
                case 12:
                    stock.BusEngines += int.Parse(tbAmount.Text);
                    break;
                case 13:
                    stock.BusWindshields += int.Parse(tbAmount.Text);
                    break;
                case 14:
                    stock.BusVehicleBodies += int.Parse(tbAmount.Text);
                    break;
                case 15:
                    stock.TruckTires += int.Parse(tbAmount.Text);
                    break;
                case 16:
                    stock.TruckBrakes += int.Parse(tbAmount.Text);
                    break;
                case 17:
                    stock.TruckEngines += int.Parse(tbAmount.Text);
                    break;
                case 18:
                    stock.TruckWindshields += int.Parse(tbAmount.Text);
                    break;
                case 19:
                    stock.TruckVehicleBodies += int.Parse(tbAmount.Text);
                    break;

            }

            File.WriteAllText(stockpath, JsonConvert.SerializeObject(stock));
        }

        private void InvComboBoxNeed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InvComboBoxNeed = sender as ComboBox;
            int selectedIndex = InvComboBoxNeed.SelectedIndex;
            _selectedIndexNeed += selectedIndex;
        }

        private void InvComboBoxReturned_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InvComboBoxReturned = sender as ComboBox;
            int selectedIndex = InvComboBoxReturned.SelectedIndex;
            _selectedIndex += selectedIndex;
        }
    }
}
