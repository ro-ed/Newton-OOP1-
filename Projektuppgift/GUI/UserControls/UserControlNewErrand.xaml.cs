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
using static Logic.Services.AddErrandService;
using GUI.UserControls;
using Projektuppgift.GUI.UserControls;

namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlNewErrand.xaml
    /// </summary>
    public partial class UserControlNewErrand : UserControl
    {
        // public List<Errands> listRead { get; set; }
        public UserControlNewErrand()
        {
            InitializeComponent();

            // listRead = new List<Errands>();

            string jsonFile;

            using (var reader = new StreamReader(pathforErrand))
            {
                jsonFile = reader.ReadToEnd();
            }

            var jsonRead = JsonConvert.DeserializeObject<List<Errands>>(jsonFile);

            //errands.AddRange(jsonRead);
            //listRead.AddRange(jsonRead);

            DataContext = this;
            ErrandView.ItemsSource = errands;
        }

        public void CreateErrand_Click(object sender, RoutedEventArgs e)
        {
            string errandName = this.tbErrandName.Text;
            string errandStart = this.tbErrandStart.Text;
            string errandEnd = this.tbErrandEnd.Text;
            string errandStatus = ((bool)cbStatusStart.IsChecked) ? "Started" : "Finished";


            Errands errand = new Errands
            {
                ErrandName = errandName,
                ErrandStartDate = errandStart,
                ErrandEndDate = errandEnd,
                ErrandID = Guid.NewGuid(),
                ErrandStatus = errandStatus


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
                using (var jsonWriter = new StreamWriter(pathforErrand))
                {
                    jsonWriter.Write(jsonWrite);
                }

            }

            else
            {
                errands.Add(errand);
                var jsonWrite = JsonConvert.SerializeObject(errands, Formatting.Indented);
                using (var jsonWriter = new StreamWriter(pathforErrand))
                {
                    jsonWriter.Write(jsonWrite);
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


            Errands errandSelected = ErrandView.SelectedItem as Errands;
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
            Errands errands = (Errands)ErrandView.SelectedItem;
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
            ErrandViewer.Children.Clear();
            ErrandViewer.Children.Add(new ChooseMechanicToErrand());
        }
    }
}

