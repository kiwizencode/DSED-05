using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundApp.Data.DogClass
{
    public class BeagleClass : DogBaseClass
    {
        public BeagleClass()
        {
            Breed_Type = DogGeneratorClass.BEAGLE;
            Breed = "Beagle";
            Origin = "United Kingdom";
            Size = S_TYPE;
            Steps = 3;
        }
    }
}
