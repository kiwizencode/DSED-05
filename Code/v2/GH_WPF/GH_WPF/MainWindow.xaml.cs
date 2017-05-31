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

namespace GH_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += new EventHandler(MoveImage);
            timer.Start();
            //new Task(() => AnimateObject(image1, 0.0)).RunSynchronously();
        }


        private void MoveImage(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Canvas canvas = image1.Parent as Canvas;
            long pos = Convert.ToInt64(image1.GetValue(Canvas.LeftProperty));
            if ( pos >= canvas.Margin.Left + canvas.ActualWidth - image1.Width - canvas.Margin.Right)
            {
                timer.Stop();
                return;
            }
            else 
                Canvas.SetLeft(image1, pos + 10);
        }
    }
}
