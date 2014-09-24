using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

        public MainWindow()
        {
            InitializeComponent();
            
            dt.Tick += new EventHandler((sender, args) =>
            {
                TimeSpan ts = stopwatch.Elapsed;

                if (stopwatch.IsRunning && ts.TotalMilliseconds < desireTimeSpan.TotalMilliseconds)
                {
                    currentTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds/10);
                    tbRemain.Text = currentTime;
                }
                else
                {
                    stopwatch.Stop();
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

            cdBtn.Click += new RoutedEventHandler((sender, args) =>
            {
                var duration = Convert.ToInt32(inputBox.Text);

                desireTimeSpan = new TimeSpan(0,0,0,duration,0);

                stopwatch.Start();

                dt.Start();
            });
           
           
        }

        


    }
}
