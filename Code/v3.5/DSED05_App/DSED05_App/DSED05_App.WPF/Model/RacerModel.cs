using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSED05_App.Data;
using DSED05_App.Data.Racer;
using DSED05_App.Common;
using System.Windows.Controls;

namespace DSED05_App.WPF.Model
{
    public class RacerModel 
    {
        /// <summary>
        /// The lane where the racer is running on
        /// </summary>
        public int Lane { get; set; }
        /// <summary>
        /// The Image control point to the racer Image on the screen
        /// </summary>
        public Image Image { get; private set; }
        
        public string Name { get => _Racer.Name; set { _Racer.Name = value; }  }
        private AbstractRacer _Racer;

        public RacerModel(CommonClass.Racer_Size racer, Image image)
        {
            _Racer = RacerGenerator.FactoryMethod(racer)
        }
    }
}
