using System;
using System.Collections.Generic;
using System.Text;

namespace CGH_App.Common
{
    public static class CommonClass
    {
        /// <summary>
        /// Define the "class" of object to be return
        /// </summary>
        public enum Data_Type { Size, Speed};

        /// <summary>
        /// Define the "size" of the race object
        /// </summary>
        public enum Size { Small, Medium, Large, Giant };
        /// <summary>
        /// Define the "speed" of the race object
        /// </summary>
        public enum Speed { Level_1, Level_2, Level_3, Level_4 };

        public static string getURL(Data_Type type, dynamic value)
        {
            switch(type)
            {
                case Data_Type.Size: return getSize(value);
                case Data_Type.Speed: return getSpeed(value);
                default: throw new NotImplementedException();
            }
            
        }

        private static string getSpeed(dynamic value)
        {
            throw new NotImplementedException();
        }

        private static string getSize(dynamic value)
        {
            switch (value)
            {
                case Size.Small: return "image/small_pig.png";
                case Size.Medium: return "image/medium_pig.png";
                case Size.Large: return "image/large_pig.png";
                case Size.Giant: return "image/gaint_pig.png";
                default: throw new NotImplementedException();
            }
        }
    }
}
