using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Controls;
using Logic.Entities;
using static Logic.Services.AddMechanicService;
using System.IO;
using System.Windows;
using Projektuppgift.GUI.UserControls;
using System.Linq;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Data;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlMechanicHome.xaml
    /// </summary>
    public partial class MechanicHome : UserControl
    {
        //public ObservableCollection<Mechanic> listToRead = new ObservableCollection<Mechanic>();
        public MechanicHome()
        {
            InitializeComponent();
            // Läser från JSON.
            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
            //// Lägger till i listan.
            //mechanics.AddRange(readFromJson);



            DataContext = this;
            lv_data.ItemsSource = mechanics;
        }

        private void ChangeToAdd_Click(object sender, RoutedEventArgs e)
        {
            MechanicView.Children.Clear();
            MechanicView.Children.Add(new AddMechanic());
        }

        private void DeleteMech_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Sure ??", "DELETE", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
               
                Mechanic selectedMechanic = lv_data.SelectedItem as Mechanic;
                if (selectedMechanic != null)
                {
                    mechanics.Remove(selectedMechanic);
                }
                Overrite();
                MechanicView.Children.Clear();
                MechanicView.Children.Add(new MechanicHome());

            }
        }
        private void ChangeToEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lv_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mechanic m = (Mechanic)lv_data.SelectedItem;
            
            
        }     

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //Metod som används när man tar bort mekaniker.
        private void Overrite()
        {
            File.WriteAllText(mechpath, JsonConvert.SerializeObject(mechanics));
            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
        }


    }
}
