using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundApp.Data.PunterClass
{
    public static class PunterGeneratorClass
    {
        public const int JOE_CLASS = 1;
        public const int BOB_CLASS = 2;
        public const int AI_CLASS = 3;

        /// <summary>
        /// punter counter
        /// </summary>
        static private int _counter = 0;
        /// <summary>
        /// generate an unique ID for the punter object.
        /// </summary>
        /// <returns>return an integer</returns>
        public static int GenerateID() { return ++_counter; }
        
        public static PunterBaseClass FactoryMethod(int punter_id)
        {
            PunterBaseClass punter;
            switch (punter_id)
            {
                case JOE_CLASS:
                    punter = new JoeClass();
                    break;
                case BOB_CLASS:
                    punter = new BobClass();
                    break;
                case AI_CLASS:
                    punter = new ComputerClass();
                    break;
                default:
                    throw new Exception("No Punter Class Defined!");
            }
            return punter;
        }
        
    }
}
