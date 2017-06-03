using System;
using System.Collections.Generic;
using System.Text;

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
            return Type == type;
        }
    }
}
