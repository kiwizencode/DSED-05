using System;
using System.Collections.Generic;
using System.Text;

namespace CGH_App.Data.PunterClass
{
    public class MediumPunterClass : PunterBaseClass
    {
        public MediumPunterClass(string name) : base()
        {
            Name = name;
            _ClassName = "Medium Punter Class";
            Money = 65;
        }
    }
}
