using System;
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
    public partial class LevelFinishScreen : Window
    {
        public int LevelNumber { get; set; }
        public string Message { get; set; }


        public LevelFinishScreen()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
            
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lblName.Content = Message;
        }

        private void ImgRestart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (LevelNumber == 1)
            {
               
                MainWindow mainWindow = new MainWindow();
                mainWindow.Close();
                this.Hide();

                MainWindow mainWindow1 = new MainWindow();
                mainWindow1.Show();
            }
            if (LevelNumber == 2)
            {

            }
        }

       

        private void ImgNext_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (LevelNumber == 1)
            {

            }
            if (LevelNumber == 2)
            {

            }
        }
    }
}
