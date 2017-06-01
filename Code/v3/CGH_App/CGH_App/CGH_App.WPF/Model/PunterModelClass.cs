using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGH_App.Data.PunterClass;
using CGH_App.Common;
using System.Windows.Media.Imaging;

namespace CGH_App.WPF.Model
{
    public class PunterModelClass
    {
        private PunterBaseClass _Punter;
        public PunterBaseClass Punter { get => _Punter; }
        public string Name { get => _Punter.Name; }
        public System.Windows.Controls.Image Image { get; private set; }
        public CommonClass.Punter_Type Type { get; set; }
        public int Money { get => _Punter.Money; }

        public PunterModelClass(CommonClass.Punter_Type type, string name)
        {
            _Punter = PunterGeneratorClass.FactoryMethod(type, name);
            Type = type;
            Image = new System.Windows.Controls.Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(CommonClass.GetValue(CommonClass.Racer_Parameter_Type.Punter, type), UriKind.Relative);
            bi.DecodePixelHeight = 420;
            bi.DecodePixelWidth = 250;
            bi.EndInit();
            Image.Source = bi;
        }
    }
}
