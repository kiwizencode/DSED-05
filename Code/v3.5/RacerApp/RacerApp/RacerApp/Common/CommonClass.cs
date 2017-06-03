using System;
using System.Collections.Generic;
using System.Text;

namespace RacerApp.Common
{
    public static class CommonClass
    {
        /// <summary>
        /// Define the "Game" Parameter Type 
        /// </summary>
        public enum Game_Parameter_Type { Size, Speed, Punter_Type };
        /// <summary>
        /// Define the "size" of the race object
        /// </summary>
        public enum Size { Small, Medium, Large, Giant };
        /// <summary>
        /// Define the "speed" of the race object
        /// </summary>
        public enum Speed { Level_1, Level_2, Level_3, Level_4 };
        /// <summary>
        /// Define the "type" of punter object
        /// </summary>
        public enum Punter_Type { Poor, Medium, Rich };

        private static int GetSteps(dynamic value)
        {
            switch (value)
            {
                case Speed.Level_1: return 1;
                case Speed.Level_2: return 4;
                case Speed.Level_3: return 7;
                case Speed.Level_4: return 10;
                default: throw new NotImplementedException();
            }
        }
    }
}
