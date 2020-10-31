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
using GUI.Home;
using System.Linq;
using Logic.Entities;
using Logic.Services;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using static Logic.Services.AddMechanicService;

namespace Projektuppgift.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlAddMechanic.xaml
    /// </summary>
    public partial class AddMechanic : UserControl
    {
        private const string AddMessage = "You have added a mechanic!";
        public AddMechanic()
        {
            InitializeComponent();
            //Hämta mekaniker från JSON.
            string jsonFromFile;
            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
            //Lägg till i listan.
            mechanics.AddRange(readFromJson);
            //Kollar om det funkar.

        }

        public void AddMechanicButton_Click(object sender, RoutedEventArgs e)
        {

            
            string firstName = this.tbFirstName.Text;
            string surName = this.tbSurName.Text;
            string dateOfBirth = this.tbDateOfBirth.Text;
            string dateOfEmployment = this.tbDateOfEmployment.Text;
            string employmentEnds = this.tbEmploymentEnds.Text;

            Mechanic mechanic = new Mechanic
            {
                FirstName = firstName,
                Surname = surName,
                DateOfBirth = dateOfBirth,
                DateOfEmployment = dateOfEmployment,
                EndDate = employmentEnds,
                MechID = Guid.NewGuid(),

            };

            //READ
            if (mechanics.Count >= 1)
            {
                string jsonFromFile;
                using (var reader = new StreamReader(mechpath))
                {
                    jsonFromFile = reader.ReadToEnd();
                }
                var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
                mechanics.Add(mechanic);
                var jsonToWrite = JsonConvert.SerializeObject(mechanics, Formatting.Indented);
                using (var writer = new StreamWriter(mechpath))
                {   
                writer.Write(jsonToWrite);
                
                }
            }
            //ADD
            else
            {
                mechanics.Add(mechanic);
                var jsonToWrite = JsonConvert.SerializeObject(mechanics, Formatting.Indented);
                using (var writer = new StreamWriter(mechpath))
                {
                    writer.Write(jsonToWrite);

                }
            }
            
            
            
           
            MessageBox.Show(AddMessage);
        }
    }
}
        
        
        

    




        

















            //if (File.Exists(mechpath))
            //{
            //    File.OpenRead(mechpath);              
            //    var readText = File.ReadAllText(mechpath);
            //    if (readText.Length > 0)
            //    {
            //        JsonConvert.DeserializeObject(mechpath);
            //        mechanics.Add(mechanic);
            //        File.WriteAllText(mechpath, JsonConvert.SerializeObject(mechanics));
            //    }
            //}
            //else
            //{
            //    File.Create(mechpath);
            //    mechanics.Add(mechanic);
            //    File.WriteAllText(mechpath, JsonConvert.SerializeObject(mechanics));
            //}

            //AddMechanicService.SaveMechanic(AddMechanicService.mechanics);

            
 
            //if (File.Exists(AddMechanicService.mechpath) && AddMechanicService.mechanics.Count > 1)
            //{
            //    var jsonString = File.ReadAllText(AddMechanicService.mechpath);
            //    var list = JsonConvert.DeserializeObject<List<Mechanic>>(jsonString);
            //    list.Add(mechanic);             
            //    File.WriteAllText(AddMechanicService.mechpath, JsonConvert.SerializeObject(list, Formatting.Indented));

            //}
        
    

