using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundApp.Data.DogClass
{
    public class GermanShepherdClass : DogBaseClass
    {
        public GermanShepherdClass()
        {
            Breed_Type = DogGeneratorClass.GERMAN_SHEPHARD;
            Breed = "German Shepherd";
            Origin = "Germany";
            Size = M_TYPE;
            Steps = 5;
        }
    }
}
