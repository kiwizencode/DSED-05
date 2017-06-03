using System;
using System.Collections.Generic;
using System.Text;

namespace DSED05_App.Common
{
    public static class CommonClass
    {
        /// <summary>
        /// Define the "Game" Parameter Type 
        /// </summary>
        public enum Game_Parameter_Type { Racer_Type, Speed, Punter_Type };
        /// <summary>
        /// Define the "size" of the race object
        /// </summary>
        public enum Racer_Type { Small, Medium, Large, Giant };
        /// <summary>
        /// Define the "speed" of the race object
        /// </summary>
        public enum Speed { Level_1, Level_2, Level_3, Level_4 };
        /// <summary>
        /// Define the "type" of punter object
        /// </summary>
        public enum Punter_Type { Poor, Medium, Rich };

    }
}
