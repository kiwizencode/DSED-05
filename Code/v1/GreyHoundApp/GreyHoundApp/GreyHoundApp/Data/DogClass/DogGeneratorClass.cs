using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundApp.Data.DogClass
{
    public static class DogGeneratorClass
    {
        public const int BEAGLE = 0;
        public const int BULLDOG = 1;
        public const int GERMAN_SHEPHARD = 3;
        public const int GREAT_PYTENEES = 4;
        /// <summary>
        /// dog counter
        /// </summary>
        static private int _counter = 0;
        /// <summary>
        /// generate an unique ID for the dog object.
        /// </summary>
        /// <returns>return an integer</returns>
        public static int GenerateID() { return ++_counter; }
        /// <summary>
        /// randam number generator
        /// </summary>
        private static Random _seed = new Random(System.DateTime.Now.Millisecond);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="breed"></param>
        /// <param name="name"></param>
        /// <returns></returns>        
        public static DogBaseClass FactoryMethod(int breed, string name)
        {
            DogBaseClass dog;
            switch (breed)
            {
                case BEAGLE:
                    dog = new BeagleClass();
                    break;
                case BULLDOG:
                    dog = new BullDogClass();
                    break;
                case GERMAN_SHEPHARD:
                    dog = new GermanShepherdClass();
                    break;
                case GREAT_PYTENEES:
                    dog = new GreatPyreneeClass();
                    break;
                default:
                    throw new Exception("No Dog Class Defined!");
            }
            dog.Name = name;
            return dog;
        }
        /// <summary>
        /// Generate a random step for the input dog object
        /// </summary>
        /// <param name="dog"></param>
        /// <returns></returns>
        public static int GenerateSteps(DogBaseClass dog)
        {
            return _seed.Next(1, dog.Steps) * 3;
        }
    }
}
