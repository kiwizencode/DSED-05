using System;
using System.Collections.Generic;
using System.Text;
using DSED05_App.Common;

namespace DSED05_App.Data.Punter
{
    public class PoorPunter : AbstractPunter
    {
        public PoorPunter()
        {
            ClassName = "Poor Punter Class";
            Money = 25;
            Type = CommonClass.Punter_Type.Poor;
        }

        public override void Reset()
        {
            Money = 25;
        }
    }

}
