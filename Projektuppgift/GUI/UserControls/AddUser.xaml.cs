using Logic.Entities;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Logic.Services.AddUserService;
using static Logic.Services.AddMechanicService;


namespace GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlAddUser.xaml
    /// </summary>
    public partial class UserControlAddUser : UserControl
    {
        public UserControlAddUser()
        {
            InitializeComponent();
            string jsonFromFile;
            using (var reader = new StreamReader(userpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var readFromJson = JsonConvert.DeserializeObject<List<User>>(jsonFromFile);
            // Lägger till i listan.
            usersList.AddRange(readFromJson);

            using (var reader = new StreamReader(mechpath))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var mechanics = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
            // Lägger till i listan.
            mechanics.AddRange(mechanics);

            MechanicCb.ItemsSource = mechanics;
            UserCb.ItemsSource = usersList;


        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            var mechanic = MechanicCb.SelectedItem as Mechanic;

            if (mechanic == null)
            {
                MessageBox.Show("You need to select a mechanic.");
            }
            else

            {


                if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    MessageBox.Show("Enter a valid email.");
                    textBoxEmail.Select(0, textBoxEmail.Text.Length);
                    textBoxEmail.Focus();

                }

                if (PasswordBox.Password.Length == 0)
                {
                    MessageBox.Show("Enter password.");
                    PasswordBox.Focus();
                    return;
                }

                User user = new User()
                {
                    Username = textBoxEmail.Text,
                    Password = PasswordBox.Password,
                    UserID = Guid.NewGuid(),
                    IsAdmin = false
                };

                mechanic.UserID = user.UserID;

                var indexOfMechanic = mechanics.FindIndex(x => x.MechID == mechanic.MechID);

                mechanics[indexOfMechanic] = mechanic;




                usersList.Add(user);
                var jsonToWrite = JsonConvert.SerializeObject(usersList, Formatting.Indented);
                using (var writer = new StreamWriter(userpath))
                {
                    writer.Write(jsonToWrite);

                }

               jsonToWrite = JsonConvert.SerializeObject(mechanics, Formatting.Indented);
                using (var writer = new StreamWriter(mechpath))
                {
                    writer.Write(jsonToWrite);

                }

                MessageBox.Show("User Added!");




            }


        }
        

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Sure ??", "DELETE", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {

                User selectedUser = UserCb.SelectedItem as User;
                if (selectedUser != null)
                {
                    usersList.Remove(selectedUser);
                }


                var jsonToWrite = JsonConvert.SerializeObject(usersList, Formatting.Indented);
                using (var writer = new StreamWriter(userpath))
                {
                    writer.Write(jsonToWrite);

                }
                //Overrite();
                //MechanicView.Children.Clear();
                //MechanicView.Children.Add(new MechanicHome());

                //private void Overrite()
                //{
                //    File.WriteAllText(mechpath, JsonConvert.SerializeObject(mechanics));
                //    string jsonFromFile;
                //    using (var reader = new StreamReader(mechpath))
                //    {
                //        jsonFromFile = reader.ReadToEnd();
                //    }
                //    var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
                //}
                MessageBox.Show("User Removed!");
            }
        }


    }
}


























