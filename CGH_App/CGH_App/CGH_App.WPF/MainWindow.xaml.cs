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

namespace CGH_App.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {          
            int i = 1;
            foreach (var value in CommonCodeSingleton.Instance.getRandomSequence(CommonClass.Data_Type.Size))
            {
                Image image;
                switch(i)
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
                bi.UriSource = new Uri(CommonClass.getURL(CommonClass.Data_Type.Size, value), UriKind.Relative);
                bi.EndInit();
                image.Source = bi ;

                //LoadAnimation(image, value);
                i++;
            }           
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
    }
}
