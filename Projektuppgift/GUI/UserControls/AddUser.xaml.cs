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

			List<User> items = new List<User>();
            items.Add(new User() { Name = "Robin Edin", UserName = null, Ssn = "95-09-21", Mail = "robinedin@gmail.com", Phonenumber = "0704427402" });
            items.Add(new User() { Name = "Julia J", UserName = "julijonsson", Ssn = "75-05-06", Mail = "julijonsson@hotmail.com", Phonenumber = "0704427402" });
            items.Add(new User() { Name = "Timmy", UserName = "TMY", Ssn = "00-01-10", Mail = "mella@gmail.com", Phonenumber = "0704455402" });
        }

     
    }

    //private void AddUser_Click(object sender, RoutedEventArgs e)
    //{

    //}

    //private void DeleteUser_Click(object sender, RoutedEventArgs e)
    //{

    //}

    //private void Button_Click(object sender, RoutedEventArgs e)
    //{

    //}
}

public class User
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Ssn { get; set; }
    public string Mail { get; set; }

    public string Phonenumber { get; set; }


}

 
   
