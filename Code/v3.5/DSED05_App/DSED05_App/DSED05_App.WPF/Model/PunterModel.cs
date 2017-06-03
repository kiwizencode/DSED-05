using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DSED05_App.Common;
using DSED05_App.Data.Punter;

namespace DSED05_App.WPF.Model
{
    public class PunterModel
    {
        public Image Image { get; private set;}

        public string Name { get => _Punter.Name; set { _Punter.Name = value; } }
        public int Money { get => _Punter.Money; }
      
        private AbstractPunter _Punter;

        public PunterModel(CommonClass.Punter_Type type)
        {
            _Punter = PunterGenerator.FactoryMethod(type);
        }
    }
}
