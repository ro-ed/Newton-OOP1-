using Logic.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using GUI.UserControls;
using Projektuppgift.GUI.UserControls;
using System.Linq;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Serialization;
using static Logic.Entities.Stock;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlNewErrand.xaml
    /// </summary>
    public partial class UserControlNewErrand : UserControl
    {
        public int _selectedIndex = 0;
        public int _selectedIndexVehicle = 0;
        // public List<Errands> listRead { get; set; }
        public static Errands _newSelectedErrandTest;
        public UserControlNewErrand()
        {
            InitializeComponent();

            // listRead = new List<Errands>();

            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
            mechanics = readFromJson;

            string jsonFile;

            using (var reader = new StreamReader(pathforErrand))
            {
                jsonFile = reader.ReadToEnd();
            }

            var jsonRead = JsonConvert.DeserializeObject<List<Errands>>(jsonFile);
            errands = jsonRead;
            //jsonRead.ForEach(x => {
            //    var m = mechanics.FirstOrDefault(y => y.ErrandIDs.Contains(x.ErrandID));
            //    x.FirstName = m?.FirstName ?? "";
            //    x.LastName = m?.SurName ?? "";

            //});

            string jsonFromFile6;
            using (var reader = new StreamReader(stockpath))
            {
                jsonFromFile6 = reader.ReadToEnd();
            }
            var stockread = JsonConvert.DeserializeObject<Stock>(jsonFromFile6);

            DataContext = stockread;





            //errands.AddRange(jsonRead);
            //listRead.AddRange(jsonRead);

            DataContext = this;
            lv_Errand.ItemsSource = errands;
            

        }

        public async void CreateErrand_Click(object sender, RoutedEventArgs e)
        {
            StockChange();
            //ChooseVehicle();


            string errandName = this.tbErrandName.Text;
            string errandStart = this.tbErrandStart.Text;
            string errandEnd = this.tbErrandEnd.Text;
            //string errandStatus = ((bool)cbStatusStart.IsChecked) ? "New" : "Finished";
            string errandStatus = "";
            if ((bool)cbStatusNew.IsChecked)
            {
                errandStatus = "New";
            }
            else if ((bool)cbStatusOnGoing.IsChecked)
            {
                errandStatus = "Ongoing";
            }
            else if ((bool)cbStatusFinished.IsChecked)
            {
                errandStatus = "Finished";
            }



            Errands errand = new Errands
            {
                ErrandName = errandName,
                ErrandStartDate = errandStart,
                ErrandEndDate = errandEnd,
                ErrandID = Guid.NewGuid(),
                ErrandStatus = errandStatus, 
                
            };



            

            if (errands.Count >= 1)
            {
                string jsonFile;

                using (var reader = new StreamReader(pathforErrand))
                {
                    jsonFile = reader.ReadToEnd();
                }

                var jsonRead = JsonConvert.DeserializeObject<List<Errands>>(jsonFile);
                errands.Add(errand);
                var jsonWrite = JsonConvert.SerializeObject(errands, Formatting.Indented);
                var fs = File.OpenWrite(pathforErrand);
                using (var jsonWriter = new StreamWriter(pathforErrand))
                {
                    await jsonWriter.WriteAsync(jsonWrite);
                }

            }

            else
            {
                errands.Add(errand);
                var jsonWrite = JsonConvert.SerializeObject(errands, Formatting.Indented);
                var fs = File.OpenWrite(pathforErrand);
                using (var jsonWriter = new StreamWriter(pathforErrand))
                {
                    await jsonWriter.WriteAsync(jsonWrite);
                }
            }
            ErrandViewer.Children.Clear();
            ErrandViewer.Children.Add(new UserControlNewErrand());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //Errands errandSelected = ErrandView.SelectedItem as Errands;
            //if (errandSelected != null)
            //{
            //    errands.Remove(errandSelected);
            //}
            //DeleteTheErrand();
            //ErrandView.Children.Clear();
            //ErrandView.Children.Add(new UserControlNewErrand());


            Errands errandSelected = lv_Errand.SelectedItem as Errands;
            if (errandSelected != null)
            {
                errands.Remove(errandSelected);
            }
            DeleteTheErrand();
            ErrandViewer.Children.Clear();
            ErrandViewer.Children.Add(new UserControlNewErrand());



        }


        //public void Test()
        //{
        //    List<Errands> listRead;

        //    listRead = new List<Errands>();
        //    string jsonFile;
        //    using (var reader = new StreamReader(pathforErrand))
        //    {
        //        jsonFile = reader.ReadToEnd();
        //    }
        //    var readFromJson = JsonConvert.DeserializeObject<List<Errands>>(jsonFile);

        //    listRead.AddRange(readFromJson);

        //    DataContext = this;
        //}

        private void ErrandView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Errands errands = (Errands)lv_Errand.SelectedItem;
        }


        private void DeleteTheErrand()
        {
            File.WriteAllText(pathforErrand, JsonConvert.SerializeObject(errands));
            string ErrandJsonFile;
            using (var writer = new StreamReader(pathforErrand))
            {
                ErrandJsonFile = writer.ReadToEnd();
            }
            var readFromErrandJson = JsonConvert.DeserializeObject<List<Errands>>(ErrandJsonFile);
        }

        private void AssignMechanicToErrand_Click(object sender, RoutedEventArgs e)
        {
            Errands errands = lv_Errand.SelectedItem as Errands;
            


            ErrandViewer.Children.Clear();
            ErrandViewer.Children.Add(new ChooseMechanicToErrand(errands));

            
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Errands selectedErrand = lv_Errand.SelectedItem as Errands;
            _newSelectedErrandTest = selectedErrand;

            ErrandViewer.Children.Clear();
            var child = new EditErrand();
            child.DataContext = selectedErrand;
            ErrandViewer.Children.Add(child);
        }

        private void InvComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InvComboBox = sender as ComboBox;
            int selectedIndex = InvComboBox.SelectedIndex;
            _selectedIndex += selectedIndex;
        }

        public void StockChange()
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
                    stock.CarTires -= int.Parse(tbAmount.Text);
                    break;
                case 1:
                    stock.CarBrakes -= int.Parse(tbAmount.Text);
                    break;
                case 2:
                    stock.CarEngines -= int.Parse(tbAmount.Text);
                    break;
                case 3:
                    stock.CarWindshields -= int.Parse(tbAmount.Text);
                    break;
                case 4:
                    stock.CarVehicleBodies -= int.Parse(tbAmount.Text);
                    break;
                case 5:
                    stock.MCTires -= int.Parse(tbAmount.Text);
                    break;
                case 6:
                    stock.MCBrakes -= int.Parse(tbAmount.Text);
                    break;
                case 7:
                    stock.MCEngines -= int.Parse(tbAmount.Text);
                    break;
                case 8:
                    stock.MCWindshields -= int.Parse(tbAmount.Text);
                    break;
                case 9:
                    stock.MCVehicleBodies -= int.Parse(tbAmount.Text);
                    break;
                case 10:
                    stock.BusTires -= int.Parse(tbAmount.Text);
                    break;
                case 11:
                    stock.BusBrakes -= int.Parse(tbAmount.Text);
                    break;
                case 12:
                    stock.BusEngines -= int.Parse(tbAmount.Text);
                    break;
                case 13:
                    stock.BusWindshields -= int.Parse(tbAmount.Text);
                    break;
                case 14:
                    stock.BusVehicleBodies -= int.Parse(tbAmount.Text);
                    break;
                case 15:
                    stock.TruckTires -= int.Parse(tbAmount.Text);
                    break;
                case 16:
                    stock.TruckBrakes -= int.Parse(tbAmount.Text);
                    break;
                case 17:
                    stock.TruckEngines -= int.Parse(tbAmount.Text);
                    break;
                case 18:
                    stock.TruckWindshields -= int.Parse(tbAmount.Text);
                    break;
                case 19:
                    stock.TruckVehicleBodies -= int.Parse(tbAmount.Text);
                    break;

            }

            File.WriteAllText(stockpath, JsonConvert.SerializeObject(stock));
        }

        private void VehicleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VehicleComboBox = sender as ComboBox;
            int selectedIndex = VehicleComboBox.SelectedIndex;
            _selectedIndexVehicle = selectedIndex;
        }

        //public void ChooseVehicle()
        //{
            
        //}

        
    }
}

