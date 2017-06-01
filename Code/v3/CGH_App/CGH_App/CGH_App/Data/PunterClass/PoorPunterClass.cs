using System;
using System.Collections.Generic;
using System.Text;

namespace CGH_App.Data.PunterClass
{
    public class PoorPunterClass : PunterBaseClass
    {
        public PoorPunterClass(string name) : base()
        {
            Name = name;
            _ClassName = "Poor Punter Class";
            Money = 25;
        }
    }
}
