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
        public static RacerBaseClass FactoryMethod(CommonClass.Size size, string name)
        {
            switch(size)
            {
                case CommonClass.Size.Small: return new SmallRacerClass(name);
                case CommonClass.Size.Medium: return new MediumRacerClass(name);
                case CommonClass.Size.Large: return new LargeRacerClass(name);
                case CommonClass.Size.Giant: return new GiantRacerClass(name);
                default: throw new NotImplementedException("No Racer Class Defined!!!");
            }
        }
    }
}
