using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Controls;
using Logic.Entities;
using static Logic.Services.AddMechanicService;
using System.IO;
using System.Windows;
using Projektuppgift.GUI.UserControls;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlMechanicHome.xaml
    /// </summary>
    public partial class MechanicHome : UserControl
    {
        public List<Mechanic> listToRead { get; set; }
        public MechanicHome()
        {
            InitializeComponent();

            listToRead = new List<Mechanic>();

            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
            //Lägg till i listan.
            listToRead.AddRange(readFromJson);
            //Kollar om det funkar.
            DataContext = this;

           
        }

        private void ChangeToAdd_Click(object sender, RoutedEventArgs e)
        {
            MechanicView.Children.Clear();
            MechanicView.Children.Add(new AddMechanic());
        }

        private void DeleteMech_Click(object sender, RoutedEventArgs e)
        {
            //var itemToRemove = Mechanic.mechanics.FirstOrDefault(r => r.id == ddl.SelectedValue);
            //if (itemToRemove != null)
            //    bookList.bookList.Remove(itemToRemove);
        }

        private void ChangeToEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
