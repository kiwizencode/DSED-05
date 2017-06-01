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
        public enum Racer_Parameter_Type { Size, Speed, Punter};
        /// <summary>
        /// Define the "size" of the race object
        /// </summary>
        public enum Size { Small, Medium, Large, Giant };
        /// <summary>
        /// Define the "speed" of the race object
        /// </summary>
        public enum Speed { Level_1, Level_2, Level_3, Level_4 };
        public static dynamic GetValue(Racer_Parameter_Type type, dynamic value)
        {
            switch(type)
            {
                case Racer_Parameter_Type.Size: return GetImageURL(value);
                case Racer_Parameter_Type.Speed: return GetSteps(value);
                case Racer_Parameter_Type.Punter: return GetPunterImage(value);
                default: throw new NotImplementedException();
            }       
        }
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
        private static string GetImageURL(dynamic value)
        {
            switch (value)
            {
                case Size.Small: return "image/small_pig.png";
                case Size.Medium: return "image/medium_pig.png";
                case Size.Large: return "image/large_pig.png";
                case Size.Giant: return "image/giant_pig.png";
                default: throw new NotImplementedException();
            }
        }

        private static int _RacerCounter = 0;
        private static int _PunterCounter = 0;
        public enum ID_Class_Type { RacerClass, PunterClass };
        public static int GetID(ID_Class_Type class_type)
        {
            switch(class_type)
            {
                case ID_Class_Type.RacerClass: return ++_RacerCounter;
                case ID_Class_Type.PunterClass: return ++_PunterCounter;
                default: throw new NotImplementedException();
            }
        }

        public enum Punter_Type { Poor, Medium, Rich };
        private static string GetPunterImage(dynamic value)
        {
            switch (value)
            {
                case Punter_Type.Poor: return "image/punter_5.png";
                case Punter_Type.Medium: return "image/punter_3.png";
                case Punter_Type.Rich: return "image/punter_4.png";
                default: throw new NotImplementedException();
            }
        }
    }
}
