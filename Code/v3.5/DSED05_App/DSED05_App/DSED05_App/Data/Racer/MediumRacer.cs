using System;
using System.Collections.Generic;
using System.Text;
using DSED05_App.Common;

namespace DSED05_App.Data.Racer
{
    public class MediumRacer : AbstractRacer
    {
        public MediumRacer()
        {
            ClassName = "Medium Racer Class";
            Type = CommonClass.Racer_Type.Medium;
        }
    }
}
