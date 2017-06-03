using System;
using System.Collections.Generic;
using System.Text;
using DSED05_App.Common;

namespace DSED05_App.Data.Punter
{
    public static class PunterGenerator
    {
        public static AbstractPunter FactoryMethod(CommonClass.Punter_Type size)
        {
            switch (size)
            {
                case CommonClass.Punter_Type.Poor: return new PoorPunter();
                case CommonClass.Punter_Type.Mid: return new MidPunter();
                case CommonClass.Punter_Type.Rich: return new RichPunter();
                default: throw new NotImplementedException("Punter Class Not Defined !!!");
            }
        }
    }
}
