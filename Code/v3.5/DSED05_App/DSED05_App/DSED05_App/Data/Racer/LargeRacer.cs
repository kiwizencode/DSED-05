using System;
using System.Collections.Generic;
using System.Text;
using DSED05_App.Common;

namespace DSED05_App.Data.Racer
{
    public class LargeRacer : AbstractRacer
    {
        public LargeRacer()
        {
            ClassName = "Large Racer Class";
            Type = CommonClass.Racer_Type.Large;
        }
    }
}
