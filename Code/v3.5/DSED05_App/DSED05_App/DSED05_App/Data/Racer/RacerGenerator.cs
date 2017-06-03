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
        public static AbstractRacer FactoryMethod(CommonClass.Racer_Size size)
        {
            switch(size)
            {
                case CommonClass.Racer_Size.Small: return new SmallRacer();
                case CommonClass.Racer_Size.Medium: return new MediumRacer();
                case CommonClass.Racer_Size.Large: return new LargeRacer();
                case CommonClass.Racer_Size.Giant: return new GiantRacer();
                default: throw new NotImplementedException("Racer Class Not Defined !!!");
            }
        }
    }
}
