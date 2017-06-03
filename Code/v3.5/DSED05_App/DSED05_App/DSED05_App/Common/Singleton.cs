using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSED05_App.Common
{
    /// <summary>
    /// Singleton Design Pattern
    /// </summary>
    public sealed class RandomGenerator
    {
        /// <summary>
        /// using .NET 4's Lazy<T> type
        /// </summary>
        private static readonly Lazy<RandomGenerator> lazy = new Lazy<RandomGenerator>(() => new RandomGenerator());
        public static RandomGenerator Instance { get { return lazy.Value; } }

        private Random _random;
        public Random Seed { get { return _random; } }
        private RandomGenerator()
        {
            _random = new Random(System.DateTime.Now.Millisecond);
        }

        /// <summary>
        /// Generate a random sequence of enum type specified by the input parameter
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<Enum> getRandomSequence(CommonClass.Game_Parameter_Type type)
        {
            switch (type)
            {
                case CommonClass.Game_Parameter_Type.Racer_Type:
                    return Enum.GetValues(typeof(CommonClass.Racer_Type)).Cast<Enum>().OrderBy(x => _random.Next()).ToArray();
                case CommonClass.Game_Parameter_Type.Speed:
                    return Enum.GetValues(typeof(CommonClass.Speed)).Cast<Enum>().OrderBy(x => _random.Next()).ToArray();
                case CommonClass.Game_Parameter_Type.Punter_Type:
                    return Enum.GetValues(typeof(CommonClass.Punter_Type)).Cast<Enum>().OrderBy(x => _random.Next()).ToArray();
                default: throw new NotImplementedException();
            }
        }
    }
}
    

