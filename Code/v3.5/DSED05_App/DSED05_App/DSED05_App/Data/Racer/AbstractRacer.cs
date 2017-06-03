using System;
using System.Collections.Generic;
using System.Text;
using DSED05_App.Common;

namespace DSED05_App.Data.Racer
{
    public abstract class AbstractRacer : IData
    {
        public AbstractRacer()
        {
            ClassName = "Abstract Racer Class";
        }

        public int ID { get ; set ; }
        public string Name { get ; set ; }
        public string ClassName { get ; set ; }
        public Enum Type { get; set; }

        public bool CheckType(Enum type)
        {
            return (CommonClass.Racer_Type) Type == (CommonClass.Racer_Type) type;
        }
    }
}
