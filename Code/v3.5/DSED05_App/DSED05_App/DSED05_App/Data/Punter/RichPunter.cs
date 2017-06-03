using System;
using System.Collections.Generic;
using System.Text;
using DSED05_App.Common;

namespace DSED05_App.Data.Punter
{
    public class RichPunter : AbstractPunter
    {
        public RichPunter()
        {
            ClassName = "Rich Punter Class";
            Money = 25;
            Type = CommonClass.Punter_Type.Rich;
        }
    }
}
