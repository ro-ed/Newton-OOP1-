﻿using System;
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
using GUI.Login;
using System.Threading.Tasks;
using System.Threading;


namespace GUI.Home
{
    /// <summary>
    /// Interaction logic for LoadingScreen.xaml
    /// </summary>
    public partial class LoadingScreen : Page
    {
        public LoadingScreen()
        {
            InitializeComponent();

            LoadingScreenMethod();


        }
        public void LoadingScreenMethod()
        {
            Thread.Sleep(2000);





        }


    }
}
