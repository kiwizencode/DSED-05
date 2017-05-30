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
            /*
            int i = 1;
            //foreach(var value in CommonCodeSingleton.Instance.getRandomSequence(CommonClass.Data_Type.Size))
            List<CommonClass.Size>  list = CommonCodeSingleton.Instance.getRandomSequence(CommonClass.Data_Type.Size).Cast < CommonClass.Size >;

            if(true)
            {
                Image image;
                switch(i++)
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
            }
            */
        }
    }
}
