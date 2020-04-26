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
    public partial class SpalshScreen : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public SpalshScreen()
        {
            InitializeComponent();
          
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        int seconds = 20;
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            seconds += 20;
            if (seconds == 100)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Hide();
            }
            lblTimer.Content = $"Wait Time : {seconds}";
        }
    }
}
