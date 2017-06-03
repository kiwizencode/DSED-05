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

namespace DSED05_App.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //
        // Please note: to implement the tuple, install System.ValueTuple using NuGet
        //
        private List<(double Top, double Left)> _RacerPositionList = new List<(double, double)>();

        private const int racer_count = 4;

        public MainWindow()
        {
            InitializeComponent();
            InitializeRacerImagePosition();
        }
        /// <summary>
        /// 
        /// </summary>
        private void InitializeRacerImagePosition()
        {
            //throw new NotImplementedException();
            for(int i = 0; i < racer_count; i++)
            {
                switch(i+1)
                {
                    case 1: _RacerPositionList.Add((Canvas.GetTop(SmallRacerImage), Canvas.GetLeft(SmallRacerImage)));
                            
                            break;
                    case 2:
                    case 3:
                    case 4:
                    default: throw new NotImplementedException("Racer Image on screen Not Implemented");
                }
            }
        }

        /// <summary>
        /// Exit Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
