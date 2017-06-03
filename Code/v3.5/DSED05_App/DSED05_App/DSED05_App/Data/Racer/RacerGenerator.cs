using System;
using System.Collections.Generic;
using System.Text;
using DSED05_App.Common;

namespace DSED05_App.Data.Racer
{
    /// <summary>
    /// Factory Design Pattern
    /// </summary>
    public static class RacerGenerator
    {
        public static AbstractRacer FactoryMethod(CommonClass.Racer_Type type)
        {
            switch(type)
            {
                case CommonClass.Racer_Type.Small: return new SmallRacer();
                case CommonClass.Racer_Type.Medium: return new MediumRacer();
                case CommonClass.Racer_Type.Large: return new LargeRacer();
                case CommonClass.Racer_Type.Giant: return new GiantRacer();
                default: throw new NotImplementedException("Racer Class Not Defined !!!");
            }
        }
    }
}
