using System.Windows.Controls;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using static Logic.Services.AddMechanicService;
using Logic.Entities;
using System.Collections.Generic;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for EditMechanic.xaml
    /// </summary>
    public partial class EditMechanic : UserControl
    {
        public EditMechanic()
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


           
        }

        private void EditMechanicButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
