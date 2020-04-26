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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ballonbuster
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        List<Image> lstControls = new List<Image>();
        List<BallonSelection> ballonSelectionList = new List<BallonSelection>();
        public static int totalNumberofBallon = 0;
        private int seconds = 0;
        private int minute = 0;
        private int totalSeconds = 0;

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            ballonSelectionList.Add(new BallonSelection { ID = 1, Photo = "Images/blueballon.png", Name = "Blue" });
            ballonSelectionList.Add(new BallonSelection { ID = 2, Photo = "Images/pinkballon.png", Name = "Pink" });
            ballonSelectionList.Add(new BallonSelection { ID = 3, Photo = "Images/greenballon.png", Name = "Green" });

            lstwithimg.ItemsSource = ballonSelectionList;
            lstwithimg.SelectedIndex = 1;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            double height = System.Windows.SystemParameters.PrimaryScreenHeight;
            double width = System.Windows.SystemParameters.PrimaryScreenWidth - 100;

            int ballonCount = 0;
            int stackpanelcount = 4;
            //  int count = 0;
            for (int i = 0; i < stackpanelcount; i++)
            {
                int controlwidth = 0;
                for (int j = 0; controlwidth < width; j++)
                {
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri("Images/pinkballon.png", UriKind.Relative);
                    bi3.EndInit();
                    var imageControl = new Image();
                    imageControl.Source = bi3;
                    imageControl.Width = 110;
                    imageControl.Height = 135;
                    imageControl.Margin = new Thickness(20, 0, 20, 20);
                    imageControl.VerticalAlignment = VerticalAlignment.Top;
                    imageControl.MouseEnter += ImageControl_MouseEnter;
                    imageControl.MouseLeave += ImageControl_MouseLeave;
                    imageControl.MouseLeftButtonDown += ImageControl_MouseLeftButtonDown;

                    //   imageControl.cl += ImageControl_MouseLeave;

                    imageControl.Name = "ImageControl_" + i + "_" + j;

                    lstControls.Add(imageControl);
                    var newStack = this.FindName("stack" + i);
                    // var arr = Window.contro.contr.Where(c => c.Name == "Name");
                    ((StackPanel)newStack).Children.Add(imageControl);

                    controlwidth += 150;
                    ballonCount += 1;
                }
                // i++;
            }
            totalNumberofBallon = ballonCount;
            lblNumberOfBallon.Content = totalNumberofBallon;

        }

        private void ImageControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // MessageBox.Show(((Image)sender).Name);
            ((Image)sender).Visibility = Visibility.Hidden;
            int value = Convert.ToInt32(lblNumberOfBallonBlast.Content ?? 0) + 1;
            lblNumberOfBallonBlast.Content = value.ToString();
            lblNumberOfBallon.Content = Convert.ToString(totalNumberofBallon - value);
            PlaySound();



            if (value == 1)
            {

                dispatcherTimer.Start();
            }

            if (value == totalNumberofBallon)
            {
                dispatcherTimer.Stop();
                LevelFinishScreen levelFinishScreen = new LevelFinishScreen();
                levelFinishScreen.LevelNumber = 1;

                int timePending = totalSeconds - totalNumberofBallon;

                if (timePending < -10)
                {
                    levelFinishScreen.Message = "Awesome !!";
                }
                else if (timePending > -10 && timePending < 10)
                {
                    levelFinishScreen.Message = "Excellent !!";
                }
                else if (timePending >= 10 && timePending < 30)
                {
                    levelFinishScreen.Message = "Very Good !!";
                }
                else if (timePending >= 30)
                {
                    levelFinishScreen.Message = "Good !!";
                }

                levelFinishScreen.ShowDialog();

            }
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            seconds += 1;
            totalSeconds += 1;

            if (seconds == 60)
            {
                seconds = 0;
                minute = minute + 1;
            }
            string minuteString = minute.ToString().Length == 1 ? "0" + Convert.ToString(minute) : Convert.ToString(minute);
            string secondString = seconds.ToString().Length == 1 ? "0" + Convert.ToString(seconds) : Convert.ToString(seconds);
            lblTimers.Content = minuteString + " : " + secondString;
        }

        private void ImageControl_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            if (((BallonSelection)lstwithimg.SelectedItem).Name.ToUpper() == "PINK")
            {
                bi3.UriSource = new Uri("Images/pinkballon.png", UriKind.Relative);
            }
            else if (((BallonSelection)lstwithimg.SelectedItem).Name.ToUpper() == "BLUE")
            {
                bi3.UriSource = new Uri("Images/blueballon.png", UriKind.Relative);
            }
            else if (((BallonSelection)lstwithimg.SelectedItem).Name.ToUpper() == "GREEN")
            {
                bi3.UriSource = new Uri("Images/greenballon.png", UriKind.Relative);
            }
            bi3.EndInit();

            ((Image)sender).Source = bi3;
        }

        private void ImageControl_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Images/grayballon.png", UriKind.Relative);
            bi3.EndInit();

            ((Image)sender).Source = bi3;
        }



        private void BallonFirst_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Images/Grayballon.png", UriKind.Relative);
            bi3.EndInit();

            ((Image)sender).Source = bi3;
        }

        private void BallonFirst_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("Images/blueballon.png", UriKind.Relative);
            bi3.EndInit();
            ((Image)sender).Source = bi3;
        }


        private void PlaySound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            player.SoundLocation = "Assets/Balloonpopping.wav";
            player.Play();
        }

        private void ImgRestart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //InitializeComponent();
            //Loaded += new RoutedEventHandler(MainWindow_Loaded);
            seconds = 0;
            totalSeconds = 0;
            minute = 0;

            foreach (var cntrl in lstControls)
            {
                cntrl.Visibility = Visibility.Visible;
                //  ((Image)cntrl).Visibility = Visibility.Visible;
            }
            lblTimers.Content = "00 : 00";

            lblNumberOfBallonBlast.Content = "00";
            lblNumberOfBallon.Content = Convert.ToString(totalNumberofBallon);

            dispatcherTimer.Stop();
        }

        private void ImgExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ExitScreen exitScreen = new ExitScreen();
            exitScreen.Show();
        }


        private void Lstwithimg_DropDownClosed(object sender, EventArgs e)
        {

            foreach (var cntrl in lstControls)
            {

                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                if (((BallonSelection)lstwithimg.SelectedItem).Name.ToUpper() == "PINK")
                {
                    bi3.UriSource = new Uri("Images/pinkballon.png", UriKind.Relative);
                }
                else if (((BallonSelection)lstwithimg.SelectedItem).Name.ToUpper() == "BLUE")
                {
                    bi3.UriSource = new Uri("Images/blueballon.png", UriKind.Relative);
                }
                else if (((BallonSelection)lstwithimg.SelectedItem).Name.ToUpper() == "GREEN")
                {
                    bi3.UriSource = new Uri("Images/greenballon.png", UriKind.Relative);
                }
                bi3.EndInit();
                ((Image)cntrl).Source = bi3;

            }
        }

    }

    public class BallonSelection
    {
        public int ID { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
    }
}
