using System;
using System.Collections.Generic;
using System.Text;
using DSED05_App.Common;

namespace DSED05_App.Data.Punter
{
    public abstract class AbstractPunter : IData
    {
        public AbstractPunter()
        {
            ClassName = "Abstract Punter Class";
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public Enum Type { get; set; }
        /// <summary>
        /// Money that the punter have
        /// </summary>
        public int Money { get; set; }

        public bool CheckType(Enum type)
        {
            return (CommonClass.Punter_Type)Type == (CommonClass.Punter_Type)type;
        }

        public abstract void Reset();

    }
}
