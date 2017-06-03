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
using System.Windows.Threading;

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
        private List<RacerModel> _RacerModelList = new List<RacerModel>();

        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            InitializeTimer();

            InitializeRacerModel();

            Randomize();
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 50)
            };
        }

        /// <summary>
        /// 1. Store the origin starting position for all racer
        /// 2. Also create the racer model
        /// </summary>
        private void InitializeRacerModel()
        {
            Image image;
            CommonClass.Racer_Type type;
            for (int i = 0; i < racer_count; i++)
            {
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
                _RacerModelList.Add(racer);

                timer.Tick += (sender, e) => Timer_Tick_Method(racer, e);
            }
        }

        private void Timer_Tick_Method(RacerModel racer, EventArgs e)
        {
            Image image = racer.Image;
            long Left = Convert.ToInt64(image.GetValue(Canvas.LeftProperty));
            int pace = racer.Pace;
            if (Left >= ImageBackground.Width - image.Width) 
            {
                timer.Stop();
                MessageBox.Show($"{racer.Name} has won!!!");
                //int id = int.Parse(racer.Name.Substring(6));
                //CheckForWinner(id);
                Randomize();
            }
            else
            {
                Canvas.SetLeft(image, Left + pace);
            }
        }

        private void Randomize()
        {
            RandomizeRacerPosition();
            RandomizeRacerPace();
        }

        /// <summary>
        /// Randomize the lane where the racer start for each race
        /// </summary>
        private void RandomizeRacerPosition()
        {
            int i = 0;
            foreach(CommonClass.Racer_Type type in RandomGenerator.Instance.getRandomSequence(CommonClass.Game_Parameter_Type.Racer_Type))
            {
                (double Top, double Left) = _RacerPositionList[i];
                foreach(var racer in _RacerModelList)
                {
                    if( racer.Type == type)
                    {
                        Canvas.SetTop(racer.Image, Top);
                        Canvas.SetLeft(racer.Image, Left);
                        racer.Lane = ++i;
                        racer.Name = "Racer " + i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Randomize the steps that racer take each time (for each race)
        /// </summary>
        private void RandomizeRacerPace()
        {
            int i = 0;
            foreach(CommonClass.Speed value in RandomGenerator.Instance.getRandomSequence(CommonClass.Game_Parameter_Type.Speed))
            {
                _RacerModelList[i++].Speed = value;
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

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}
