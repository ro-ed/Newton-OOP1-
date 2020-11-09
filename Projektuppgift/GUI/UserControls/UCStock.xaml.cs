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
            var stockread = JsonConvert.DeserializeObject<Stock>(jsonFromFile);
           
            DataContext = stockread;    
        }
        private void lv_stockdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void StockAdd_Click(object sender, RoutedEventArgs e)
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
                    stock.Tires += int.Parse(tbAmount.Text);
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
                case 4:
                    stock.VehicleBodies += int.Parse(tbAmount.Text);
                    break;
            }

            File.WriteAllText(stockpath, JsonConvert.SerializeObject(stock));

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

