using System;
using System.Collections.Generic;
using System.Text;

namespace CGH_App.Data
{
    /// <summary>
    /// Interface for all classes declared under Data folder
    /// </summary>
    interface IDataClass
    {
        /// <summary>
        /// A ID for every IDataClass Object
        /// </summary>
        int ID { get; set; }
        /// <summary>
        /// Name of the Data Object Class
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Class Name of the Data Object Class
        /// </summary>
        string ClassName { get; set; }
    }
}
