using System;
using System.Collections.Generic;
using System.Text;

namespace CGH_App.Data.PunterClass
{
    public class RichPunterClass : PunterBaseClass
    {
        public RichPunterClass(string name) : base()
        {
            Name = name;
            _ClassName = "Rich Punter Class";
            Money = 100;
        }
    }
}
