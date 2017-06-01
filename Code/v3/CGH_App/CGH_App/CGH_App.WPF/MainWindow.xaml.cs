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
using CGH_App.Common;
using System.Windows.Media.Animation;
using System.Windows.Interactivity;
using Microsoft.Expression.Interactivity.Media;
using System.Windows.Threading;
using CGH_App.WPF.Model;
using CGH_App.Data.PunterClass;

namespace CGH_App.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        List<RacerModelClass> RacerList = new List<RacerModelClass>();
        List<dynamic> PunterList = new List<dynamic>();
        //bool winflag = false;
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            InitializeRacerModel();
            InitializePunter();
        }

        private void InitializePunter()
        {
            int i = 0;
            foreach(var punter in CommonCodeSingleton.Instance.getRandomSequence(CommonClass.Racer_Parameter_Type.Punter))
            {
                string name = "";
                switch(++i)
                {
                    case 1: name = "Punter 1"; break;
                    case 2: name = "Punter 2"; break;
                    case 3: name = "Punter 3"; break;
                    default: throw new NotImplementedException("Punter Class not defined.");
                }

                PunterModelClass model = new PunterModelClass(punter, name);

                PunterList.Add( new { ImageSource=model.Image.Source, Model=model });
                //PunterListView.Items.Add(model);

                //PunterListView.MouseDown += (sender, e) => PunterListView_MouseDown(model, e);
            }
            PunterListView.ItemsSource = PunterList;
            
        }



        /// <summary>
        /// Initialize the timer control
        /// </summary>
        private void InitializeTimer()
        {
            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 50)
            };
        }
        private void InitializeDogModelPosition()
        {
            
            foreach (RacerModelClass model in RacerList)
            {
                //Canvas.SetTop(model.Image, model.Top);
                Canvas.SetLeft(model.Image, model.Left);
                //model.Image.SetValue(Canvas.LeftProperty, model.Left);
                //model.Left = 0;
            }
            
            /*
            Canvas.SetLeft(image1, 10);
            Canvas.SetLeft(image2, 0);
            Canvas.SetLeft(image3, 0);
            Canvas.SetLeft(image4, 0);
            */
            //winflag = false;
            int i = 0;
            foreach (var value in CommonCodeSingleton.Instance.getRandomSequence(CommonClass.Racer_Parameter_Type.Speed))
            {
                RacerList[i].Speed = value;
                i++;
            }
            i = 0;
            foreach (var size in CommonCodeSingleton.Instance.getRandomSequence(CommonClass.Racer_Parameter_Type.Size))
            {
                Image image;
                switch (++i)
                {
                    case 1: image = image1; break;
                    case 2: image = image2; break;
                    case 3: image = image3; break;
                    case 4: image = image4; break;
                    default: throw new NotImplementedException("Image Control not defined.");
                }
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(CommonClass.GetValue(CommonClass.Racer_Parameter_Type.Size, size), UriKind.Relative);
                bi.EndInit();
                image.Source = bi;
            }

        }
        private void InitializeRacerModel()
        {
            int i = 1;
            foreach (var value in CommonCodeSingleton.Instance.getRandomSequence(CommonClass.Racer_Parameter_Type.Size))
            {
                Image image;
                //int Top, Left=7;
                string name;
                switch (i)
                {
                    case 1: image = image1;
                            name = "Piggy 1";
                            //Top = 3;
                            break;
                    case 2: image = image2;
                            name = "Piggy 2";
                            //Top = 45;
                            break;
                    case 3: image = image3;
                            name = "Piggy 3";
                            //Top = 90;
                            break;
                    case 4: image = image4;
                            name = "Piggy 4";
                            //Top = 130;
                            break;
                    default:
                        throw new NotSupportedException();
                }
                RacerModelClass model = new RacerModelClass(value, name, image);
                {
                    //    //model.Top = Top;
                    Left = 0;
                };
                
                //model.CallBackMethod = DisplayImage;
                i++;
                RacerList.Add(model);
                //timer.Tick += new EventHandler(model.Move);
                timer.Tick += (sender, e) => Timer_Tick_Method(model, e);
            }
            i = 0;
            foreach(var value in CommonCodeSingleton.Instance.getRandomSequence(CommonClass.Racer_Parameter_Type.Speed))
            {
                RacerList[i].Speed = value;
                i++;
            }
        }

        private void Timer_Tick_Method(object sender, EventArgs e) 
        {
            RacerModelClass racer = sender as RacerModelClass;
            Image image = racer.Image;
            long leftPosition = Convert.ToInt64(image.GetValue(Canvas.LeftProperty));
            int pace = CommonClass.GetValue(CommonClass.Racer_Parameter_Type.Speed, racer.Speed);
            if (leftPosition >= ImageBackground.Width - image.Width) //800 is the width of the panel
            {
                timer.Stop();
                MessageBox.Show($"{racer.Name} has won!!!");
                int id = int.Parse(racer.Name.Substring(6));
                CheckForWinner(id);
                //winflag = true;
                //RacerList[racer.ID - 1].Left = 10;
                InitializeDogModelPosition();
                //PunterList.Items.Refresh();
            }
            else
            {
                Canvas.SetLeft(image, leftPosition + pace);
            }
        }

        private void CheckForWinner(int winner_id)
        {
            foreach (dynamic item in PunterList)
            {
                PunterModelClass model = item.Model;
                PunterBaseClass punter = model.Punter;
                if (punter.RacerID != PunterBaseClass.NO_RACER_SELECTED)
                {
                    if (punter.RacerID == winner_id)
                        punter.WinGame();
                    else
                        punter.LoseGame();
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //InitializeDogModelPosition();
            timer.Start();
        }



        private void RunnerImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            SelectedRunner.Source = image.Source;
            SelectedRunnerName.Content = "Piggy " +   image.Name.Substring(5);
        }
        
        private void PunterListView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            dynamic Content = (sender as ListBoxItem).Content;
            PunterModelClass model = Content.Model as PunterModelClass;
            PunterBaseClass punter = model.Punter;
            /*
            //MessageBox.Show($"{Content.Model.Name} has been selected!!!");
            SelectedPunter.Source = model.Image.Source;
            SelectedPunterName.Content = model.Name;
             */
            if (punter.RacerID != PunterBaseClass.NO_RACER_SELECTED && punter.Bet > 0)
            {
                Image image = null;
                string name = string.Empty;
                switch (punter.RacerID)
                {
                    case 1: image = image1; name = "1"; break;
                    case 2: image = image2; name = "2"; break;
                    case 3: image = image3; name = "3"; break;
                    case 4: image = image4; name = "4"; break;
                    default: throw new NotSupportedException();
                }
                SelectedRunner.Source = image.Source;
                SelectedRunnerName.Content = "Piggy " + name;
            }
            else
            {
                SelectedRunner.Source = null;
                SelectedRunnerName.Content = string.Empty;
            }

            MoneyLabel.Content = punter.Bet;
            BetSlider.Maximum = punter.Money;
            BetSlider.Value = punter.Bet;
        }
       
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BettingButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRunnerName.Content.ToString() != string.Empty)
            {
                //int runner_ID = int.Parse(SelectedRunnerName.Content.ToString().Substring(6));

                if (PunterListView.SelectedIndex > -1)
                {
                    //int index = PunterListView.SelectedIndex;

                    dynamic Content = PunterListView.SelectedItem;
                    PunterModelClass model = Content.Model as PunterModelClass;
                    PunterBaseClass punter = model.Punter;

                    punter.Bet = Convert.ToInt32(BetSlider.Value);
                    punter.RacerID = int.Parse(SelectedRunnerName.Content.ToString().Substring(6));

                    if (punter.Bet == 0)
                    {
                        punter.RacerID = PunterBaseClass.NO_RACER_SELECTED;
                    }
                }
            }
            SelectedRunner.Source = null;
            SelectedRunnerName.Content = string.Empty;
            MoneyLabel.Content = string.Empty;
            PunterListView.SelectedIndex = -1;
        }

        private void BetSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MoneyLabel.Content = BetSlider.Value;
        }



        #region Future enhance features : to be coded in the future
        // TODO : attached the animation to specific image 
        /*
        public void LoadAnimation(object obj, CommonClass.Size value)
        {
            Image image = obj as Image;
            var storyboard = new Storyboard();
            
            storyboard.RepeatBehavior = RepeatBehavior.Forever;

            var myDoubleAnimationUsingKeyFrames = new DoubleAnimationUsingKeyFrames();
            switch (value)
            {
                case CommonClass.Size.Small :
                    storyboard.Name = "small_story";
                    var myEasingDoubleKeyFrame = new EasingDoubleKeyFrame();
                    for(int i = 1; i <= 7;i++)
                    {
                        myEasingDoubleKeyFrame.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.15*i));
                        myEasingDoubleKeyFrame.Value = (i % 2 == 0 ? 0 : -14);
                        myDoubleAnimationUsingKeyFrames.KeyFrames.Add(myEasingDoubleKeyFrame);
                    }
                    Storyboard.SetTargetName(myDoubleAnimationUsingKeyFrames, "small_bouncing");
                    break;
                case CommonClass.Size.Medium: break;
                case CommonClass.Size.Large: break;
                case CommonClass.Size.Giant: break;
            }
            //Storyboard.TargetProperty = "(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)"
            Storyboard.SetTargetProperty(myDoubleAnimationUsingKeyFrames, new PropertyPath("TransformGroup.Children[3].TranslateTransform.Y"));
            storyboard.Children.Add(myDoubleAnimationUsingKeyFrames);
            
            var eventTrigger = new System.Windows.Interactivity.EventTrigger() { EventName = "FrameworkElement.Loaded" };

            var controlStoryboardAction = new ControlStoryboardAction();
            controlStoryboardAction.Storyboard = storyboard;
            controlStoryboardAction.ControlStoryboardOption = ControlStoryboardOption.Play;
            eventTrigger.Actions.Add(controlStoryboardAction);
        }
        */
        #endregion

        #region obsolete Method
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 1;
            foreach (var value in CommonCodeSingleton.Instance.getRandomSequence(CommonClass.Racer_Parameter_Type.Size))
            {
                Image image;
                switch (i)
                {
                    case 1: image = image1; break;
                    case 2: image = image2; break;
                    case 3: image = image3; break;
                    case 4: image = image4; break;
                    default:
                        throw new NotSupportedException();
                }

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(CommonClass.GetValue(CommonClass.Racer_Parameter_Type.Size, value), UriKind.Relative);
                bi.EndInit();
                image.Source = bi;

                //LoadAnimation(image, value);
                i++;
            }
        }

        private void DisplayImage(RacerModelClass racer)
        {
            /*
            if(winflag)
            { 
                timer.Stop();
                return;
            }
            */

            //calculating the dog postion with respect to left property
            Image image = racer.Image;
            long leftPosition = Convert.ToInt64(image.GetValue(Canvas.LeftProperty));
            int pace = CommonClass.GetValue(CommonClass.Racer_Parameter_Type.Speed, CommonClass.Speed.Level_4);
            if (leftPosition >= ImageBackground.Width - image.Width) //800 is the width of the panel
            {
                timer.Stop();

                //if (!winflag)
                //{
                MessageBox.Show($"Dog {racer.ID} has won!!!");
                //CheckForWinner(id);
                //winflag = true;
                InitializeDogModelPosition();
                //InitializeComponent();
                //PunterList.Items.Refresh();
                //}

            }
            else
            {

                Canvas.SetLeft(image, leftPosition + pace);
            }
        }
        #endregion
    }
}
