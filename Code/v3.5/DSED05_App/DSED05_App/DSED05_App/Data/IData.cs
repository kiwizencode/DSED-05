using System;
using System.Collections.Generic;
using System.Text;

namespace DSED05_App.Data
{
    /// <summary>
    /// Interface for all classes declared under Data folder
    /// </summary>
    interface IData
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
        /// <summary>
        /// Type Definition for the Data Object Class
        /// </summary>
        Enum Type { get; set; }
        /// <summary>
        /// Check whether Type Data Object Class match the input Enum Type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool CheckType(Enum type);
    }
}
