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
using System.IO;
using Newtonsoft.Json;
using static Logic.DAL.StockDataAccess;
using Logic.Entities;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCStock.xaml
    /// </summary>
    public partial class UCStock : UserControl
    {
        private const string AddStockMessage = "You have added items!"; 
        public int _selectedIndex = 0;
        public UCStock()
        {
            InitializeComponent();

            //AddStockManually();

            // Läser från JSON.
            string jsonFromFile;
            using (var reader = new StreamReader(stockpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Stock>>(jsonFromFile);
            ////// Lägger till i listan.
            //thestock.AddRange(readFromJson);




            DataContext = this;
            lv_stockdata.ItemsSource = thestock;
        }


        //public void AddStockManually()

        //{

        
        //Stock stock = new Stock
        //{
        //    Tires = 20,
        //    Brakes = 20,
        //    Motors = 10,
        //    Windshields = 15
        //};

        //    thestock.Add(stock);
        //    var jsonToWrite = JsonConvert.SerializeObject(thestock, Formatting.Indented);
        //    var fs = File.OpenWrite(stockpath);
        //    using (var writer = new StreamWriter(fs))
        //    {
        //        writer.Write(jsonToWrite);

        //    }
        //}

        private void lv_stockdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Stock s = (Stock)lv_stockdata.SelectedItem;

        }

        private void StockAdd_Click(object sender, RoutedEventArgs e)
        {
            string jsonFromFile;
            using (var reader = new StreamReader(stockpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Stock>>(jsonFromFile);
 
            Stock stock = new Stock();

            switch (_selectedIndex)
            {
                
                case 0:
                    if(stock.Tires == 0)
                    {
                    stock.Tires += int.Parse(tbAmount.Text);
                    }
                    else
                    {
                    stock.
                    }
                    
                    break;
                case 1:
                    stock.Brakes += int.Parse(tbAmount.Text);
                    break;
                case 2:
                    stock.Motors += int.Parse(tbAmount.Text);
                    break;
                case 3:
                    stock.Windshields += int.Parse(tbAmount.Text);
                    break;
            }
            thestock.Clear();
            thestock.Add(stock);

            File.WriteAllText(stockpath, JsonConvert.SerializeObject(thestock));

            MessageBox.Show(AddStockMessage);

            StockView.Children.Clear();
            StockView.Children.Add(new UCStock());

        }

        private void InvComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InvComboBox = sender as ComboBox;
            int selectedIndex = InvComboBox.SelectedIndex;
            _selectedIndex += selectedIndex;
        }
        
    }
}

