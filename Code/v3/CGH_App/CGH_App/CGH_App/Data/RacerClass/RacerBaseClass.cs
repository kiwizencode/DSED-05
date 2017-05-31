using System;
using System.Collections.Generic;
using System.Text;
using CGH_App.Common;

namespace CGH_App.Data.RacerClass
{
    public abstract class RacerBaseClass : IDataClass
    {
        /// <summary>
        /// A unqiue number for the Racer Class Object.
        /// </summary>
        public int ID { get => _RacerID; set { int temp = value; } }
        private int _RacerID;
        /// <summary>
        /// Name of the Racer Class Object.
        /// </summary>
        public string Name { get => _RacerName; set => _RacerName = value; }
        private string _RacerName;
        /// <summary>
        /// Racer Base Class Name
        /// </summary>
        public string ClassName { get => _ClassName; set { string temp = value; } }
        protected string _ClassName = "Racer Base Class";

        protected RacerBaseClass()
        {
            _RacerID = CommonClass.GetID(CommonClass.ID_Class_Type.RacerClass);
        }
    }
}
