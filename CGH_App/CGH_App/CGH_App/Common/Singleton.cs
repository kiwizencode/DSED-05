using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CGH_App.Common
{
    /// <summary>
    /// Singleton Design Pattern
    /// </summary>
    public sealed class CommonCodeSingleton
    {
        private static readonly Lazy<CommonCodeSingleton> lazy = new Lazy<CommonCodeSingleton>(() => new CommonCodeSingleton());
        public static CommonCodeSingleton Instance { get { return lazy.Value; } }

        private Random _random = new Random(System.DateTime.Now.Millisecond);
        public Random Seed { get { return _random; } }
        private CommonCodeSingleton(){}

        public IEnumerable<dynamic> getRandomSequence(CommonClass.Data_Type type)
        {
            switch (type)
            {
                case CommonClass.Data_Type.Size:
                    return Enum.GetValues(typeof(CommonClass.Size)).Cast<dynamic>().OrderBy(x => _random.Next()).ToArray();
                    //break;
                case CommonClass.Data_Type.Speed:
                    return Enum.GetValues(typeof(CommonClass.Speed)).Cast<dynamic>().OrderBy(x => _random.Next()).ToArray();
                    //break;
                default: throw new NotImplementedException();
            }
        }
    }
}
    

