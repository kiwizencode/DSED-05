using System;
using System.Collections.Generic;
using System.Text;
using CGH_App.Common;

namespace CGH_App.Data.RacerClass
{
    /// <summary>
    /// Factory Design Pattern
    /// </summary>
    public static class RacerGeneratorClass
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
