using System;
using System.Collections.Generic;
using System.Text;
using DSED05_App.Common;

namespace DSED05_App.Data.Racer
{
    public class GiantRacer : AbstractRacer
    {
        public GiantRacer()
        {
            ClassName = "Gaint Racer Class";
            Type = CommonClass.Racer_Type.Giant;
        }
    }
}
