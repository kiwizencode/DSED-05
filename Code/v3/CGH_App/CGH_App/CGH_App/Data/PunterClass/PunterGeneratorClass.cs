using System;
using System.Collections.Generic;
using System.Text;
using CGH_App.Common;

namespace CGH_App.Data.PunterClass
{
    public static class PunterGeneratorClass
    {
        public static PunterBaseClass FactoryMethod(CommonClass.Punter_Type size, string name)
        {
            switch (size)
            {
                case CommonClass.Punter_Type.Poor: return new PoorPunterClass(name);
                case CommonClass.Punter_Type.Medium: return new MediumPunterClass(name);
                case CommonClass.Punter_Type.Rich: return new RichPunterClass(name);
                default: throw new NotImplementedException("No Punter Class Defined!!!");
            }
        }
    }
}
