using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundApp.Data
{
    interface IDataClass
    {
        string Name { get; set; }
        string ClassName { get; set; }

        int GenerateID();
    }
}
