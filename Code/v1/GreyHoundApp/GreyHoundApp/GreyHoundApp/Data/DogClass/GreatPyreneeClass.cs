using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundApp.Data.DogClass
{
    public class GreatPyreneeClass : DogBaseClass
    {
        public GreatPyreneeClass()
        {
            Breed_Type = DogGeneratorClass.GREAT_PYTENEES;
            Breed = "Great Pyrenees";
            Origin = "France, Spain";
            Size = G_TYPE;
            Steps = 6;
        }
    }
}
