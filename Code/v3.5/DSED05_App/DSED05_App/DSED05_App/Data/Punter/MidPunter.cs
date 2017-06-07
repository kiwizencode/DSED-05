using System;
using System.Collections.Generic;
using System.Text;
using DSED05_App.Common;

namespace DSED05_App.Data.Punter
{
    public class MidPunter : AbstractPunter
    {
        public MidPunter()
        {
            ClassName = "Mid Punter Class";
            Money = 65;
            Type = CommonClass.Punter_Type.Mid;
        }

        public override void Reset()
        {
            Money = 65;
        }
    }
}
