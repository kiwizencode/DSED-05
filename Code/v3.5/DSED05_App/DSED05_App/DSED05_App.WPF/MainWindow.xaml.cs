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
using DSED05_App.WPF.Model;
using DSED05_App.Common;
using DSED05_App.Data.Racer;

namespace DSED05_App.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int racer_count = 4;
        //
        // Please note: to implement the tuple, install System.ValueTuple using NuGet
        //
        private List<(double Top, double Left)> _RacerPositionList = new List<(double, double)>();
        private List<RacerModel> _ModelList = new List<RacerModel>();


        public MainWindow()
        {
            InitializeComponent();

            InitializeRacerModel();

            RandomizeRacerPosition();
        }



        /// <summary>
        /// 
        /// </summary>
        private void InitializeRacerModel()
        {
            //throw new NotImplementedException();
            for(int i = 0; i < racer_count; i++)
            {
                Image image;
                CommonClass.Racer_Type type;
                switch(i+1)
                {
                    case 1: image = SmallRacerImage;
                            type = CommonClass.Racer_Type.Small;
                            break;
                    case 2: image = MediumRacerImage;
                            type = CommonClass.Racer_Type.Medium;
                            break;
                    case 3: image = LargeRacerImage;
                            type = CommonClass.Racer_Type.Large;
                            break;
                    case 4: image = GiantRacerImage;
                            type = CommonClass.Racer_Type.Giant;
                            break;
                    default: throw new NotImplementedException("Racer Image on screen Not Implemented");
                }
                _RacerPositionList.Add((Canvas.GetTop(image), Canvas.GetLeft(image)));
                RacerModel racer = new RacerModel(type,image);
            }
        }

        private void RandomizeRacerPosition()
        {
            foreach(var racer in )
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
