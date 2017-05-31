using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundApp.Data.DogClass
{
    public class BullDogClass : DogBaseClass
    {
        public BullDogClass()
        {
            Breed_Type = DogGeneratorClass.BULLDOG;
            Breed = "Bulldog";
            Origin = "United Kingdom";
            Size = M_TYPE;
            Steps = 4;
        }
    }
}
