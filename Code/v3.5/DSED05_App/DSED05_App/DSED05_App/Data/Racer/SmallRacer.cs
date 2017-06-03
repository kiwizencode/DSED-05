using System;
using System.Collections.Generic;
using System.Text;
using DSED05_App.Common;

namespace DSED05_App.Data.Racer
{
    public class SmallRacer : AbstractRacer
    {
        public SmallRacer()
        {
            ClassName = "Small Racer Class";
            Type = CommonClass.Racer_Type.Small;
        }
    }
}
