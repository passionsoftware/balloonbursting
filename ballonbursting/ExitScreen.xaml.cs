﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ballonbuster
{

   
    /// <summary>
    /// Interaction logic for SpalshScreen.xaml
    /// </summary>
    public partial class ExitScreen : Window
    {
        public int LevelNumber { get; set; }
        public string Message { get; set; }


        public ExitScreen()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
            
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lblName.Content = "Do you really want to exit!!";
        }

        private void ImgNo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
        }

        private void ImgYes_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
                System.Windows.Application.Current.Shutdown();
            
        }
    }
}
