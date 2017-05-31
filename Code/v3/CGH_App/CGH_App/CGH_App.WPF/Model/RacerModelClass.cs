using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGH_App.Data.RacerClass;
using CGH_App.Common;
using System.Windows.Media.Imaging;

namespace CGH_App.WPF.Model
{
    public class RacerModelClass 
    {
        private RacerBaseClass _Racer;
        //public int Top;
        public double Left;
        public int ID { get => _Racer.ID; }
        public System.Windows.Controls.Image Image { get; private set; }
        //public delegate void DisplayView(RacerModelClass racer);
        //public DisplayView CallBackMethod = null;
        public CommonClass.Speed Speed { get; set; }
        public RacerModelClass(CommonClass.Size size, string name, System.Windows.Controls.Image screen_image_object)
        {
            _Racer = RacerGeneratorClass.FactoryMethod(size, name);
            Image = screen_image_object;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(CommonClass.GetValue(CommonClass.Racer_Parameter_Type.Size, size), UriKind.Relative);
            bi.EndInit();
            Image.Source = bi;
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        /*
        public void Move(object sender, EventArgs e)
        {
            if (CallBackMethod != null)
                CallBackMethod(this);
        }
        */
    }
}
