using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

/***
 * http://www.wpf-tutorial.com/misc/dispatchertimer/
 */
namespace WPFCountDown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch stopwatch = new Stopwatch();
        string currentTime = string.Empty;
        TimeSpan desireTimeSpan;
        private int multiplexor = 1;
        private string State = "";

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                this.Hide();
            }
            else if (WindowState == WindowState.Normal)
            {
                this.Show();
                
            }
            base.OnStateChanged(e);
        }

        public MainWindow()
        {
            InitializeComponent();
            
            //
//            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
//            ni.Icon = new System.Drawing.Icon("Main.ico");
//            ni.Visible = true;
//            ni.DoubleClick += delegate(object sender, EventArgs args)
//                {
//                    this.Show();
//                    this.WindowState = WindowState.Normal;
//                };


            dt.Tick += new EventHandler((sender, args) =>
            {
                TimeSpan ts = stopwatch.Elapsed;

                if (stopwatch.IsRunning && ts.TotalMilliseconds < desireTimeSpan.TotalMilliseconds)
                {
                    currentTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds/10);
                    tbRemain.Text = currentTime;
                }
                else if (ts.TotalMilliseconds >= desireTimeSpan.TotalMilliseconds)
                {
                    stopwatch.Reset();
                    var result = MessageBox.Show("Times Up. Run again ?", "dd", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.No)
                    {
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                        Application.Current.Shutdown();
                    }
                }
            });

            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            //start button
            startBtn.Click += new RoutedEventHandler((sender, args) =>
            {
                if ( !string.IsNullOrEmpty(inputBox.Text))
                {
                    var duration = Convert.ToInt32(inputBox.Text);
                    //filter out bad input
                    if (duration >= 0)
                    {
                        //depends on different metrics e.g. second/minutes/hours
                        duration *= multiplexor;

                        desireTimeSpan = new TimeSpan(0, 0, 0, duration, 0);

                        stopwatch.Start();

                        dt.Start();
                    }
                }
            });
           
            //pause button
            pauseBtn.Click += new RoutedEventHandler((sender, args) =>
            {
                if (stopwatch.IsRunning)
                    stopwatch.Stop();
                else 
                    stopwatch.Start();
            });

            //reset button
            resetBtn.Click += new RoutedEventHandler((sender, args) =>
            {
                //clear ui
                inputBox.Text = "5";
                tbRemain.Text = "0";
                dt.Stop();
                stopwatch.Stop();
                stopwatch.Reset();                
            });
        }

        private void cboxUnit_Loaded(object sender, RoutedEventArgs e)
        {
            var data = new List<string>();
            data.Add("s");
            data.Add("m");
            data.Add("h");
            
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        private void cboxUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cboxUnit.SelectedIndex)
            {
                //second
                case 0:
                    multiplexor = 1;
                    break;
                //mins
                case 1:
                    multiplexor = 60;
                    break;
                //hour
                case 2:
                    multiplexor = 3600;
                    break;
            }
            
        }

        //show
        private void FirstItem_Click(object sender, RoutedEventArgs e)
        {
            if ( !IsVisible)
            {
                Show();
            }

            if (WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
            }

//            Topmost = true;  // important
//            Topmost = false; // important
//            Focus();         // important
        }

        //exit
        private void SecondItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
