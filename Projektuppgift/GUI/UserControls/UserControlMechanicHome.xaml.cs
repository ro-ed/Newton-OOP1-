using Logic.Entities;
using Newtonsoft.Json;
using Projektuppgift.GUI.UserControls;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using static Logic.Services.AddMechanicService;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlMechanicHome.xaml
    /// </summary>
    public partial class MechanicHome : UserControl
    {
        //public ObservableCollection<Mechanic> listToRead = new ObservableCollection<Mechanic>();

        public static Mechanic _selectedMechanic;
        public MechanicHome()
        {
            InitializeComponent();
            //Läser från JSON.
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
            Mechanic selectedMechanic = lv_data.SelectedItem as Mechanic;
            _selectedMechanic = selectedMechanic;
            
            MechanicView.Children.Clear();
            var child = new EditMechanic();
            child.DataContext = selectedMechanic;
            MechanicView.Children.Add(child); 
                      

        }

        private void lv_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mechanic m = (Mechanic)lv_data.SelectedItem;
            
            
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
